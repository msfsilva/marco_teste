using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTCustomControls;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class GeradorOpAgrupadorClass
    {
        AcsUsuarioClass Usuario;
        IWTPostgreNpgsqlConnection conn;
        List<ItemOpAgrupadorClass> Itens;
        private IOrdemProducaoFactory iOrdemProducaoFactory;


        public GeradorOpAgrupadorClass(List<ItemOpAgrupadorClass> itens, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
            Itens = itens;
            Usuario = usuario;
            this.conn = conn;
            this.iOrdemProducaoFactory = iOrdemProducaoFactory;
        }

        public List<OrdemProducaoClass> Gerar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                List<OrdemProducaoClass> OPs = new List<OrdemProducaoClass>();
                OrdemProducaoGrupoClass Grupo = this.iOrdemProducaoFactory.getInstanceOPGrupo(this.conn, this.Usuario);

                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                foreach (ItemOpAgrupadorClass item in Itens)
                {
                    string mensagemInconsistencia;
                    if (!item.verificaEstruturas(out mensagemInconsistencia,ref command))
                    {
                        if (MessageBox.Show(null, "O item " + item.Codigo + "(" + item.Dimensao + ") possui as seguintes inconsistências de estrutura/roteiro:\r\n"+mensagemInconsistencia+"\r\n\r\n Deseja gerar utilizando o primeiro item?", "Inconsistência", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    //Gera a OP para o item
                    OPs.Add(
                        Grupo.addOrdemProducao(
                            item.IdProduto,
                            item.VersaoEstruturaAtual,
                            item.Codigo,
                            item.Descricao,
                            "",
                            "",
                            "",
                            item.Dimensao,
                            false,
                            false,
                            item.IdProdutoK
                            )
                     );

                    OPs[OPs.Count - 1].qtdExtra = Math.Round(item.Quantidade, 2, MidpointRounding.ToEven);
                    OPs[OPs.Count - 1].quantidadeEstoque = Math.Round(EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(OPs[OPs.Count - 1].ProdutoK, ref command), 2, MidpointRounding.ToEven);
                    OPs[OPs.Count - 1].qtdExtra += Math.Round(OPs[OPs.Count - 1].quantidadeEstoque,2,MidpointRounding.ToEven);

                }


                List<OrdemProducaoErroDocumentoClass> Erros = new List<OrdemProducaoErroDocumentoClass>();
                string erroGeral = "";
                PlanoCorteClass planoCorte = new PlanoCorteClass(LoginClass.UsuarioLogado.loggedUser, this.conn);

                for (int i = 0; i < OPs.Count; i++)
                {
                   
                    

                    OrdemProducaoClass Value = OPs[i];
                    

                    string error = "";

                    List<PedidoItemConfiguradoMaterialClass> itensIncluirPlanoCorte;
                    if (Value.preencherOP(ref command, out error, ref Erros, out itensIncluirPlanoCorte))
                    {
                        foreach (PedidoItemConfiguradoMaterialClass pedidoMaterial in itensIncluirPlanoCorte)
                        {
                            Value.ItensPlanoCorte.Add(planoCorte.AdicionarItemOP(pedidoMaterial, Value));
                        }
                    }
                    else
                    {
                        erroGeral += error + "\r\n";
                        OPs.RemoveAt(i);
                        Grupo.OPs.Remove(Value);
                        i--;

                    }
                }

                if (erroGeral.Length > 0)
                {

                    DialogResult res = DialogResult.No;

                    if (erroGeral.Length > 1000)
                    {
                        ScrollableMessageBox message = new ScrollableMessageBox(null, "Algumas ops não foram geradas pelos seguintes motivos.\r\n" + erroGeral + "\r\nVocê deseja continuar com a geração das ops das ordens que não apresentaram erros?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        res = message.ShowDialog();
                    }
                    else
                    {
                        res = MessageBox.Show(null, "Algumas ops não foram geradas pelos seguintes motivos.\r\n" + erroGeral + "\r\nVocê deseja continuar com a geração das ops das ordens que não apresentaram erros?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }

                    if (res == DialogResult.No)
                    {
                        command.Transaction.Rollback();
                        return new List<OrdemProducaoClass>();
                    }

                }


                Grupo.Save(ref command);

                Grupo.ordernaOPs();


                command.Transaction.Commit();

                foreach (OrdemProducaoClass op in OPs)
                {
                    op.AtualizarItensPlanoCorte();
                }

                if (planoCorte.CollectionPlanoCorteItemClassPlanoCorte.Count > 0)
                {
                    planoCorte.Save();
                }

                return Grupo.OPs;

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao gerar as Ordens de Produção\r\n" + e.Message, e);
            }

        }
    }

    public class ItemOpAgrupadorClass
    {
        public int IdProduto { get; private set; }
        public int VersaoEstruturaAtual { get; private set; }
        public int IdProdutoK { get; private set; }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Dimensao { get; private set; }
        public double Quantidade { get; private set; }

        List<ItemInternoOpAgrupadorClass> itensInternos; 

        public ItemOpAgrupadorClass(string codigo,string descricao, string dimensao, double quantidade)
        {
            Codigo = codigo;
            Descricao = descricao;
            Dimensao = dimensao;
            Quantidade = quantidade;
            itensInternos = new List<ItemInternoOpAgrupadorClass>();
        }

        public bool verificaEstruturas(out string mensagemInconsitencia, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                command.CommandText =
                    "SELECT    " +
                    "  public.produto_k.id_produto_k,  " +
                    "  public.produto_k_produto.id_produto,  " +
                    "  public.produto.pro_versao_estrutura_atual,  " +
                    "  public.produto.pro_codigo  " +
                    "FROM  " +
                    "  public.produto_k  " +
                    "  INNER JOIN public.produto_k_produto ON (public.produto_k.id_produto_k = public.produto_k_produto.id_produto_k) " +
                    "  INNER JOIN public.produto ON (public.produto_k_produto.id_produto = public.produto.id_produto)   " +
                    "WHERE " +
                    "  public.produto_k.prk_codigo LIKE '" + Codigo + "' AND  " +
                    "  public.produto_k.prk_dimensao = '" + Dimensao + "' ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("Código / Dimensão Inválidos");
                }



                while (read.Read())
                {
                    itensInternos.Add(
                        new ItemInternoOpAgrupadorClass()
                        {
                            IdProduto = Convert.ToInt32(read["id_produto"]),
                            IdProdutoK = Convert.ToInt32(read["id_produto_k"]),
                            VersaoAtualEstrutura = Convert.ToInt32(read["pro_versao_estrutura_atual"]),
                            Codigo = read["pro_codigo"].ToString()
                        }
                        );
                }

                read.Close();
                this.IdProduto = this.itensInternos[0].IdProduto;
                this.IdProdutoK = this.itensInternos[0].IdProdutoK;
                this.VersaoEstruturaAtual = this.itensInternos[0].VersaoAtualEstrutura;

                if (itensInternos.Count == 1)
                {
                    mensagemInconsitencia = "";
                    return true;
                }

                //Tem mais do que um item verificar a estrutura
                
                #region Itens Filhos
                /*
                command.CommandText =
                "SELECT  " +
                "  public.produto_pai_filho.id_produto_filho, " +
                "  public.produto_pai_filho.ppf_quantidade_filho " +
                "FROM " +
                "  public.produto " +
                "  INNER JOIN public.produto_pai_filho ON (public.produto.id_produto = public.produto_pai_filho.id_produto_pai) " +
                "  AND (public.produto.pro_versao_estrutura_atual = public.produto_pai_filho.ppf_versao_estrutura) " +
                "WHERE " +
                "  public.produto.id_produto = " + this.IdProduto + " ";

                Dictionary<int, FilhoInternoOpAgrupadorClass> filhosPrincipal = new Dictionary<int, FilhoInternoOpAgrupadorClass>();

                read = command.ExecuteReader();
                while (read.Read())
                {
                    filhosPrincipal.Add(
                        Convert.ToInt32(read["id_produto_filho"]),
                        new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_produto_filho"]),
                            Quantidade = Convert.ToDouble(read["ppf_quantidade_filho"])
                        });
                }
                read.Close();

                foreach (ItemInternoOpAgrupadorClass item in itensInternos)
                {
                    if (item.IdProduto != this.IdProduto)
                    {
                        command.CommandText =
                           "SELECT  " +
                           "  public.produto_pai_filho.id_produto_filho, " +
                           "  public.produto_pai_filho.ppf_quantidade_filho " +
                           "FROM " +
                           "  public.produto " +
                           "  INNER JOIN public.produto_pai_filho ON (public.produto.id_produto = public.produto_pai_filho.id_produto_pai) " +
                           "  AND (public.produto.pro_versao_estrutura_atual = public.produto_pai_filho.ppf_versao_estrutura) " +
                           "WHERE " +
                           "  public.produto.id_produto = " + item.IdProduto + " ";
                        read = command.ExecuteReader();
                        while (read.Read())
                        {
                            if (filhosPrincipal.ContainsKey(Convert.ToInt32(read["id_produto_filho"])))
                            {
                                if (!filhosPrincipal[Convert.ToInt32(read["id_produto_filho"])].Quantidade.Equals(Convert.ToDouble(read["ppf_quantidade_filho"])))
                                {
                                    return false;
                                }
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        read.Close();
                    }
                }
                */ 
                #endregion

                #region Materiais
                command.CommandText =
                "SELECT  " +
                "  public.produto_material.id_material, "+
                "  public.produto_material.prm_quantidade, " +
                "  public.familia_material.fam_codigo ||' ' || public.material.mat_codigo as codigo "+
                "FROM " +
                "  public.produto " +
                "  INNER JOIN public.produto_material ON (public.produto.id_produto = public.produto_material.id_produto) " +
                "  AND (public.produto.pro_versao_estrutura_atual = public.produto_material.prm_versao_estrutura) " +
                "  INNER JOIN public.material ON (public.produto_material.id_material = public.material.id_material) "+
                "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                "WHERE " +
                "  public.produto.id_produto = " + this.IdProduto + " ";

                Dictionary<int, FilhoInternoOpAgrupadorClass> materiaisPrincipal = new Dictionary<int, FilhoInternoOpAgrupadorClass>();

                read = command.ExecuteReader();
                while (read.Read())
                {
                    materiaisPrincipal.Add(
                        Convert.ToInt32(read["id_material"]),
                        new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_material"]),
                            Quantidade = Convert.ToDouble(read["prm_quantidade"]),
                            Codigo = read["codigo"].ToString()
                        });
                }
                read.Close();

                foreach (ItemInternoOpAgrupadorClass item in itensInternos)
                {
                    if (item.IdProduto != this.IdProduto)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_material.id_material, " +
                            "  public.produto_material.prm_quantidade, " +
                            "  public.familia_material.fam_codigo ||' ' || public.material.mat_codigo as codigo " +
                            "FROM " +
                            "  public.produto " +
                            "  INNER JOIN public.produto_material ON (public.produto.id_produto = public.produto_material.id_produto) " +
                            "  AND (public.produto.pro_versao_estrutura_atual = public.produto_material.prm_versao_estrutura) " +
                            "  INNER JOIN public.material ON (public.produto_material.id_material = public.material.id_material) " +
                            "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +                         
                            "WHERE " +
                            "  public.produto.id_produto = " + item.IdProduto + " ";
                        read = command.ExecuteReader();
                        bool found = false;
                        while (read.Read())
                        {
                            FilhoInternoOpAgrupadorClass materialTmp = new FilhoInternoOpAgrupadorClass
                                {
                                    Id = Convert.ToInt32(read["id_material"]),
                                    Quantidade = Convert.ToDouble(read["prm_quantidade"]),
                                    Codigo = read["codigo"].ToString()
                                };
                            
                            if (materiaisPrincipal.ContainsKey(materialTmp.Id))
                            {
                                if (!materiaisPrincipal[materialTmp.Id].Quantidade.Equals(Convert.ToDouble(read["prm_quantidade"])))
                                {
                                    mensagemInconsitencia = "Quantidade do material " + materialTmp.Codigo + " inválida no item " + item.Codigo;
                                    return false;
                                }
                                found = true;
                                continue;
                            }
                            else
                            {
                                mensagemInconsitencia = "Material " + materialTmp.Codigo + " existente no item " + item.Codigo + " e não no " + itensInternos[0].Codigo;
                                return false;
                            }
                        }
                        if (!found && materiaisPrincipal.Count > 0)
                        {
                            mensagemInconsitencia = "O item " + item.Codigo + " não possui materiais e o " + itensInternos[0].Codigo + " possui";
                            return false;
                        }
                        read.Close();
                    }
                }
                #endregion

                #region Documentos
                command.CommandText =
                "SELECT  " +
                "  public.produto_documento_tipo.id_documento_tipo_familia, " +
                "  public.familia_documento.fad_codigo || ' ' ||  public.documento_tipo.dot_identificacao as codigo "+
                "FROM " +
                "  public.produto " +
                "  INNER JOIN public.produto_documento_tipo ON (public.produto.id_produto = public.produto_documento_tipo.id_produto) " +
                "  AND (public.produto.pro_versao_estrutura_atual = public.produto_documento_tipo.pdt_versao_estrutura) " +
                "  INNER JOIN public.documento_tipo_familia ON (public.produto_documento_tipo.id_documento_tipo_familia = public.documento_tipo_familia.id_documento_tipo_familia) " +
                "  INNER JOIN public.documento_tipo ON (public.documento_tipo_familia.id_documento_tipo = public.documento_tipo.id_documento_tipo) "+
                "  INNER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento) "+
                "WHERE " +
                "  public.produto.id_produto = " + this.IdProduto + " ";

                Dictionary<int, FilhoInternoOpAgrupadorClass> documentosPrincipal = new Dictionary<int, FilhoInternoOpAgrupadorClass>();

                read = command.ExecuteReader();
                while (read.Read())
                {
                    documentosPrincipal.Add(
                        Convert.ToInt32(read["id_documento_tipo_familia"]),
                        new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_documento_tipo_familia"]),
                            Quantidade = 1,
                            Codigo = read["codigo"].ToString()
                        });
                }
                read.Close();

                foreach (ItemInternoOpAgrupadorClass item in itensInternos)
                {
                    if (item.IdProduto != this.IdProduto)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_documento_tipo.id_documento_tipo_familia, " +
                            "  public.familia_documento.fad_codigo || ' ' ||  public.documento_tipo.dot_identificacao as codigo " +
                            "FROM " +
                            "  public.produto " +
                            "  INNER JOIN public.produto_documento_tipo ON (public.produto.id_produto = public.produto_documento_tipo.id_produto) " +
                            "  AND (public.produto.pro_versao_estrutura_atual = public.produto_documento_tipo.pdt_versao_estrutura) " +
                            "  INNER JOIN public.documento_tipo_familia ON (public.produto_documento_tipo.id_documento_tipo_familia = public.documento_tipo_familia.id_documento_tipo_familia) " +
                            "  INNER JOIN public.documento_tipo ON (public.documento_tipo_familia.id_documento_tipo = public.documento_tipo.id_documento_tipo) " +
                            "  INNER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento) " +
                            "WHERE " +
                            "  public.produto.id_produto = " + item.IdProduto + " ";
                        read = command.ExecuteReader();
                        bool found = false;
                        while (read.Read())
                        {
                            FilhoInternoOpAgrupadorClass documentoTmp = new FilhoInternoOpAgrupadorClass
                            {
                                Id = Convert.ToInt32(read["id_documento_tipo_familia"]),
                                Quantidade = 1,
                                Codigo = read["codigo"].ToString()
                            };

                            if (documentosPrincipal.ContainsKey(documentoTmp.Id))
                            {
                                found = true;
                                continue;
                            }
                            else
                            {
                                mensagemInconsitencia = "Documento " + documentoTmp.Codigo + " existente no item " + item.Codigo + " e não no " + itensInternos[0].Codigo;
                                return false;
                            }
                        }
                        if (!found && documentosPrincipal.Count > 0)
                        {
                            mensagemInconsitencia = "O item " + item.Codigo + " não possui documentos e o " + itensInternos[0].Codigo + " possui";
                            return false;
                        }
                        read.Close();
                    }
                }
                #endregion

                #region Recursos
                command.CommandText =
                "SELECT  " +
                "  public.produto_recurso.id_recurso, " +
                "  public.produto_recurso.prr_hierarquia, " +
                "  public.familia_recurso.far_identificacao || ' ' ||  public.recurso.rec_codigo as codigo "+
                "FROM " +
                "  public.produto " +
                "  INNER JOIN public.produto_recurso ON (public.produto.id_produto = public.produto_recurso.id_produto) " +
                "  AND (public.produto.pro_versao_estrutura_atual = public.produto_recurso.prr_versao_estrutura) " +
                "  INNER JOIN public.recurso ON (public.produto_recurso.id_recurso = public.recurso.id_recurso) "+
                "  INNER JOIN public.familia_recurso ON (public.recurso.id_familia_recurso = public.familia_recurso.id_familia_recurso) "+
                "WHERE " +
                "  public.produto.id_produto = " + this.IdProduto + " ";

                Dictionary<int, FilhoInternoOpAgrupadorClass> recursosPrincipal = new Dictionary<int, FilhoInternoOpAgrupadorClass>();

                read = command.ExecuteReader();
                while (read.Read())
                {
                    recursosPrincipal.Add(
                        Convert.ToInt32(read["id_recurso"]),
                        new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_recurso"]),
                            Quantidade = Convert.ToDouble(read["prr_hierarquia"]),
                            Codigo = read["codigo"].ToString()
                        });
                }
                read.Close();

                foreach (ItemInternoOpAgrupadorClass item in itensInternos)
                {
                    if (item.IdProduto != this.IdProduto)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_recurso.id_recurso, " +
                            "  public.produto_recurso.prr_hierarquia, " +
                            "  public.familia_recurso.far_identificacao || ' ' ||  public.recurso.rec_codigo as codigo " +
                            "FROM " +
                            "  public.produto " +
                            "  INNER JOIN public.produto_recurso ON (public.produto.id_produto = public.produto_recurso.id_produto) " +
                            "  AND (public.produto.pro_versao_estrutura_atual = public.produto_recurso.prr_versao_estrutura) " +
                            "  INNER JOIN public.recurso ON (public.produto_recurso.id_recurso = public.recurso.id_recurso) " +
                            "  INNER JOIN public.familia_recurso ON (public.recurso.id_familia_recurso = public.familia_recurso.id_familia_recurso) " +
                            "WHERE " +
                            "  public.produto.id_produto = " + item.IdProduto + " ";
                        read = command.ExecuteReader();
                        bool found = false;
                        while (read.Read())
                        {
                            FilhoInternoOpAgrupadorClass recursoTmp = new FilhoInternoOpAgrupadorClass
                           {
                               Id = Convert.ToInt32(read["id_recurso"]),
                               Quantidade = Convert.ToDouble(read["prr_hierarquia"]),
                               Codigo = read["codigo"].ToString()
                           };
                            if (recursosPrincipal.ContainsKey(recursoTmp.Id))
                            {
                                if (!recursosPrincipal[recursoTmp.Id].Quantidade.Equals(recursoTmp.Quantidade))
                                {
                                    mensagemInconsitencia = "Hierarquia do recurso " + recursoTmp.Codigo + " inválida no item " + item.Codigo;
                                    return false;
                                }
                                found = true;
                                continue;
                            }
                            else
                            {
                                mensagemInconsitencia = "Recurso " + recursoTmp.Codigo + " existente no item " + item.Codigo + " e não no " + itensInternos[0].Codigo;
                                return false;
                            }
                        }
                        if (!found && recursosPrincipal.Count > 0)
                        {
                            mensagemInconsitencia = "O item " + item.Codigo + " não possui recursos e o " + itensInternos[0].Codigo + " possui";
                            return false;
                        }
                        read.Close();
                    }
                }
                #endregion

                #region Roteiro
                command.CommandText =
                "SELECT  " +
                "  public.produto_posto_trabalho.id_posto_trabalho, " +
                "  public.produto_posto_trabalho.ppt_sequencia, " +
                "  public.posto_trabalho.pos_codigo as codigo "+
                "FROM " +
                "  public.produto " +
                "  INNER JOIN public.produto_posto_trabalho ON (public.produto.id_produto = public.produto_posto_trabalho.id_produto) " +               
                "  INNER JOIN public.posto_trabalho ON (public.produto_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) "+
                "WHERE " +
                "  public.produto.id_produto = " + this.IdProduto + " ";

                Dictionary<int, FilhoInternoOpAgrupadorClass> roteiroPrincipal = new Dictionary<int, FilhoInternoOpAgrupadorClass>();

                read = command.ExecuteReader();
                while (read.Read())
                {
                    roteiroPrincipal.Add(
                        Convert.ToInt32(read["id_posto_trabalho"]),
                        new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_posto_trabalho"]),
                            Quantidade = Convert.ToDouble(read["ppt_sequencia"]),
                            Codigo = read["codigo"].ToString()
                        });
                }
                read.Close();

                foreach (ItemInternoOpAgrupadorClass item in itensInternos)
                {
                    if (item.IdProduto != this.IdProduto)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_posto_trabalho.id_posto_trabalho, " +
                            "  public.produto_posto_trabalho.ppt_sequencia, " +
                            "  public.posto_trabalho.pos_codigo as codigo " +
                            "FROM " +
                            "  public.produto " +
                            "  INNER JOIN public.produto_posto_trabalho ON (public.produto.id_produto = public.produto_posto_trabalho.id_produto) " +
                            "  INNER JOIN public.posto_trabalho ON (public.produto_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                            "WHERE " +
                            "  public.produto.id_produto = " + item.IdProduto + " ";
                        read = command.ExecuteReader();
                        bool found = false;
                        while (read.Read())
                        {
                            FilhoInternoOpAgrupadorClass roteiroTmp = new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_posto_trabalho"]),
                            Quantidade = Convert.ToDouble(read["ppt_sequencia"]),
                            Codigo = read["codigo"].ToString()
                        };

                            if (roteiroPrincipal.ContainsKey(roteiroTmp.Id))
                            {
                                if (!roteiroPrincipal[roteiroTmp.Id].Quantidade.Equals(roteiroTmp.Quantidade))
                                {
                                    mensagemInconsitencia = "Sequencia do posto de trabalho " + roteiroTmp.Codigo + " inválida no item " + item.Codigo;
                                    return false;
                                }
                                found = true;
                                continue;
                                
                            }
                            else
                            {
                                mensagemInconsitencia = "Posto de Trabalho " + roteiroTmp.Codigo + " existente no item " + item.Codigo + " e não no " + itensInternos[0].Codigo;
                                return false;
                            }
                        }
                        if (!found && roteiroPrincipal.Count > 0)
                        {
                            mensagemInconsitencia = "O item " + item.Codigo + " não possui postos de trabalho e o " + itensInternos[0].Codigo + " possui";
                            return false;
                        }

                        read.Close();
                    }
                }
                #endregion

                #region Acabamento
                command.CommandText =
                "SELECT  " +
                "  public.produto_acabamento.id_acabamento, " +
                "  public.acabamento.acb_identificacao as codigo "+
                "FROM " +
                "  public.produto " +
                "  INNER JOIN public.produto_acabamento ON (public.produto.id_produto = public.produto_acabamento.id_produto) " +
                "  AND (public.produto.pro_versao_estrutura_atual = public.produto_acabamento.pac_versao_estrutura) " +
                "  INNER JOIN public.acabamento ON (public.produto_acabamento.id_acabamento = public.acabamento.id_acabamento) "+
                "WHERE " +
                "  public.produto.id_produto = " + this.IdProduto + " ";

                Dictionary<int, FilhoInternoOpAgrupadorClass> acabamentoPrincipal = new Dictionary<int, FilhoInternoOpAgrupadorClass>();

                read = command.ExecuteReader();
                while (read.Read())
                {
                    acabamentoPrincipal.Add(
                        Convert.ToInt32(read["id_acabamento"]),
                        new FilhoInternoOpAgrupadorClass
                        {
                            Id = Convert.ToInt32(read["id_acabamento"]),
                            Quantidade = 1,
                            Codigo = read["codigo"].ToString()
                        });
                }
                read.Close();

                foreach (ItemInternoOpAgrupadorClass item in itensInternos)
                {
                    if (item.IdProduto != this.IdProduto)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_acabamento.id_acabamento, " +
                            "  public.acabamento.acb_identificacao as codigo " +
                            "FROM " +
                            "  public.produto " +
                            "  INNER JOIN public.produto_acabamento ON (public.produto.id_produto = public.produto_acabamento.id_produto) " +
                            "  AND (public.produto.pro_versao_estrutura_atual = public.produto_acabamento.pac_versao_estrutura) " +
                            "  INNER JOIN public.acabamento ON (public.produto_acabamento.id_acabamento = public.acabamento.id_acabamento) " +
                            "WHERE " +
                            "  public.produto.id_produto = " + item.IdProduto + " ";

                        read = command.ExecuteReader();
                        bool found = false;
                        while (read.Read())
                        {
                            FilhoInternoOpAgrupadorClass acabamentoTmp = new FilhoInternoOpAgrupadorClass
                            {
                                Id = Convert.ToInt32(read["id_acabamento"]),
                                Quantidade = 1,
                                Codigo = read["codigo"].ToString()
                            };
                            if (acabamentoPrincipal.ContainsKey(acabamentoTmp.Id))
                            {
                                found = true;
                                continue;
                            }
                            else
                            {
                                mensagemInconsitencia = "Acabamento " + acabamentoTmp.Codigo + " existente no item " + item.Codigo + " e não no " + itensInternos[0].Codigo;
                                return false;
                            }
                        }
                        if (!found && acabamentoPrincipal.Count > 0)
                        {
                            mensagemInconsitencia = "O item " + item.Codigo + " não possui acabamentos e o " + itensInternos[0].Codigo + " possui";
                            return false;
                        }
                        read.Close();
                    }
                }
                #endregion

                mensagemInconsitencia = "";
                return true;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar as estruturas dos itens filhos\r\n" + e.Message, e);
            }

        }
    }

    internal class ItemInternoOpAgrupadorClass
    {
        public string Codigo { get; set; }
        public int IdProduto { get; set; }
        public int IdProdutoK { get; set; }
        public int VersaoAtualEstrutura { get; set; }

    }

    internal class FilhoInternoOpAgrupadorClass
    {
        public string Codigo { get; set; }
        public int Id { get; set; }
        public double Quantidade { get; set; }
    }
}

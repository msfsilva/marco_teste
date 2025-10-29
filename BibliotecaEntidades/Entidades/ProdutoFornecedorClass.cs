using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class ProdutoFornecedorClass:ProdutoFornecedorBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do ProdutoFornecedorClass";
protected new const string ErroDelete = "Erro ao excluir o ProdutoFornecedorClass  ";
protected new const string ErroSave = "Erro ao salvar o ProdutoFornecedorClass.";
protected new const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do ProdutoFornecedorClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoFornecedorClass está sendo utilizada.";
#endregion

        

        public ProdutoFornecedorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        


        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }
       public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
           switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        public String FornecedorNomeFantasia
        {
            get { return this.Fornecedor.NomeFantasia; }
        }

        public String FornecedorRazao
        {
            get { return this.Fornecedor.RazaoSocial; }
        }

       public void setUltimoPreco(double ultimoPreco, double icms, double ipi)
       {
           this.UltimoPreco = ultimoPreco;
           this.Icms = icms;
           this.Ipi = ipi;
       }

       public void setAtivo(bool ativo)
       {
           this.Ativo = ativo;
       }

       public void setUnidadeCompra(UnidadeMedidaClass unidadeCompra, double? unidadeUsoPorUnidadeCompra, double? loteMinimoCompra)
       {
           this.UnidadeMedidaCompra = unidadeCompra;
           if (this.UnidadeMedidaCompra != null)
           {
               this.UnidadesPorUnCompra = unidadeUsoPorUnidadeCompra;
               this.LotePadrao = loteMinimoCompra;
           }
           else
           {
               this.UnidadesPorUnCompra = null;
               this.LotePadrao = null;
           }
       }

       public void LimparID()
       {
           BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
           this.ID = -1;
       }


       public static DateTime? GetDataUltimoRecebimento(ProdutoClass produto, FornecedorClass fornecedor, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
       {
           LoteClass ultimoLote = (LoteClass) new LoteClass(usuario, conn).Search(new List<SearchParameterClass>()
           {
               new SearchParameterClass("Produto", produto),
               new SearchParameterClass("Fornecedor", fornecedor),
               new SearchParameterClass("DataRecebimento", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Desc, TipoOrdenacao.Data)
           }, limit: 1).FirstOrDefault();


           return ultimoLote?.DataRecebimento;
       }

       public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
       {
           //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
           long idProdutoSimulador = Produto.ID + 10000000;
           long idProdutoFornecedorSimulador = ID + 10000000;

           if (Ativo && Produto.Ativo && Produto.TipoAquisicao == TipoAquisicao.Comprado)
           {

               long idUnidadeMedida;
               double conversaoUnidade;
               double loteMinimo;
               double lotePadrao;
               if (UnidadeMedidaCompra != null)
               {
                   idUnidadeMedida = UnidadeMedidaCompra.ID;
                   conversaoUnidade = this.UnidadesPorUnCompra ?? 1;
                   loteMinimo = LoteMinimo ?? 1;
                   lotePadrao = LotePadrao ?? 1;
               }
               else
               {
                   if (Produto.UnidadeMedidaCompra != null)
                   {
                       idUnidadeMedida = Produto.UnidadeMedidaCompra.ID;
                       conversaoUnidade = Produto.UnidadesPorUnCompra;
                       loteMinimo = Produto.LoteMinimo ?? 1;
                       lotePadrao = Produto.LotePadraoCompra ?? 1;
                   }
                   else
                   {
                       idUnidadeMedida = Produto.UnidadeMedida.ID;
                       conversaoUnidade = 1;
                       loteMinimo = 1;
                       lotePadrao = 1;
                   }
               }

               loteMinimo = loteMinimo * conversaoUnidade;
               lotePadrao = lotePadrao * conversaoUnidade;


                ProdutoFornecedorDto dto = new ProdutoFornecedorDto()
               {
                   id = idProdutoFornecedorSimulador,
                   unidadeMedidaId = idUnidadeMedida,
                   produtoId = idProdutoSimulador,
                   aliquotaIcms = Icms,
                   aliquotaIpi = Ipi,
                   conversaoUnidade = conversaoUnidade,
                   dataUltimaCompra = this.DataUltimaCompra,
                   dataUltimoRecebimento = GetDataUltimoRecebimento(Produto,Fornecedor,UsuarioAtual,command.Connection),
                   fornecedorId = Fornecedor.ID,
                   fornecedorPreferencial = Preferencial,
                   loteMinimo = loteMinimo,
                   lotePadrao = lotePadrao,
                   precoUnitario = Math.Round(UltimoPreco / conversaoUnidade, 4, MidpointRounding.AwayFromZero)

               };

                ApiSimuladorCompras.SincronizarProdutoFornecedor(dto.id, false, UsuarioAtual, command);
            }
           else
           {
               ApiSimuladorCompras.SincronizarProdutoFornecedor(idProdutoFornecedorSimulador, true, UsuarioAtual, command);
            }
       }

       protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
       {
           long idProdutoFornecedorSimulador = ID + 10000000;

            ApiSimuladorCompras.SincronizarProdutoFornecedor(idProdutoFornecedorSimulador, true, UsuarioAtual, command);

        }

       public void SincronizarSDC(IWTPostgreNpgsqlConnection connection)
       {
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idProdutoSimulador = Produto.ID + 10000000;
            long idProdutoFornecedorSimulador = ID + 10000000;

            if (Ativo && Produto.Ativo && Produto.TipoAquisicao == TipoAquisicao.Comprado)
            {

                long idUnidadeMedida;
                double conversaoUnidade;
                double loteMinimo;
                double lotePadrao;
                if (UnidadeMedidaCompra != null)
                {
                    idUnidadeMedida = UnidadeMedidaCompra.ID;
                    conversaoUnidade = this.UnidadesPorUnCompra ?? 1;
                    loteMinimo = LoteMinimo ?? 1;
                    lotePadrao = LotePadrao ?? 1;
                }
                else
                {
                    if (Produto.UnidadeMedidaCompra != null)
                    {
                        idUnidadeMedida = Produto.UnidadeMedidaCompra.ID;
                        conversaoUnidade = Produto.UnidadesPorUnCompra;
                        loteMinimo = Produto.LoteMinimo ?? 1;
                        lotePadrao = Produto.LotePadraoCompra ?? 1;
                    }
                    else
                    {
                        idUnidadeMedida = Produto.UnidadeMedida.ID;
                        conversaoUnidade = 1;
                        loteMinimo = 1;
                        lotePadrao = 1;
                    }
                }

                loteMinimo = loteMinimo * conversaoUnidade;
                lotePadrao = lotePadrao * conversaoUnidade;

                ProdutoFornecedorDto dto = new ProdutoFornecedorDto()
                {
                    id = idProdutoFornecedorSimulador,
                    unidadeMedidaId = idUnidadeMedida,
                    produtoId = idProdutoSimulador,
                    aliquotaIcms = Icms,
                    aliquotaIpi = Ipi,
                    conversaoUnidade = conversaoUnidade,
                    dataUltimaCompra = this.DataUltimaCompra,
                    dataUltimoRecebimento = GetDataUltimoRecebimento(Produto, Fornecedor, UsuarioAtual, connection),
                    fornecedorId = Fornecedor.ID,
                    fornecedorPreferencial = Preferencial,
                    loteMinimo = loteMinimo,
                    lotePadrao = lotePadrao,
                    precoUnitario = Math.Round(UltimoPreco / conversaoUnidade, 4, MidpointRounding.AwayFromZero)

                };
                ApiSimuladorCompras.SincronizarProdutoFornecedor(dto.id, false, UsuarioAtual, connection);
            }
            else
            {
                ApiSimuladorCompras.SincronizarProdutoFornecedor(idProdutoFornecedorSimulador, true, UsuarioAtual, connection);
            }
        }
    }
}

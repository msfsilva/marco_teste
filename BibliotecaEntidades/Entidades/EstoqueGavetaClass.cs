using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq; 
using System.Text;
using BarcodeLib;
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaEntidades.Entidades
{
    [Serializable()]
    public class EstoqueGavetaClass : EstoqueGavetaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EstoqueGavetaClass";
        protected new const string ErroDelete = "Erro ao excluir o EstoqueGavetaClass  ";
        protected new const string ErroSave = "Erro ao salvar o EstoqueGavetaClass.";
        protected new const string ErroCollectionDocumentoFiscalDestinoClassEstoqueGaveta = "Erro ao carregar a coleção de DocumentoFiscalDestinoClass.";
        protected new const string ErroCollectionEstoqueGavetaItemClassEstoqueGaveta = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
        protected new const string ErroCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroCollectionOrdemProducaoClassEstoqueGaveta = "Erro ao carregar a coleção de OrdemProducaoClass.";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
        protected new const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroEstoqueObrigatorio = "O campo Estoque é obrigatório";
        protected new const string ErroEstoqueCorredorObrigatorio = "O campo EstoqueCorredor é obrigatório";
        protected new const string ErroEstoquePrateleiraObrigatorio = "O campo EstoquePrateleira é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EstoqueGavetaClass.";
        protected new const string MensagemUtilizadoCollectionDocumentoFiscalDestinoClassEstoqueGaveta = "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes DocumentoFiscalDestinoClass:";
        protected new const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEstoqueGaveta = "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
        protected new const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta = "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
        protected new const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino = "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoClassEstoqueGaveta = "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes OrdemProducaoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EstoqueGavetaClass está sendo utilizada.";

        #endregion

        public EstoqueGavetaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.EstoquePrateleira + " > " + this.Identificacao;
        }


        private byte[] _barcode;
        public byte[] Barcode
        {
            get
            {
                try
                {
                    if (_barcode == null)
                    {

                        using (Barcode barcode = new Barcode())
                        {
                            barcode.Alignment = AlignmentPositions.CENTER;
                            barcode.Height = 280;
                            barcode.Width = 600;
                            barcode.ImageFormat = ImageFormat.Jpeg;

                            using (Bitmap codeBar = new Bitmap(barcode.Encode(TYPE.CODE128, BarcodeText)))
                            {
                                codeBar.SetResolution(300, 300);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    codeBar.Save(ms, ImageFormat.Jpeg);
                                    ms.Seek(0, SeekOrigin.Begin);

                                    using (BinaryReader br = new BinaryReader(ms))
                                    {
                                        _barcode = br.ReadBytes((int) ms.Length);
                                    }
                                }
                            }
                        }
                    }

                    return _barcode;
                }
                catch (ExcecaoTratada)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro inesperado ao gerar o código de barras \r\n" + e.Message, e);
                }
            }

        }

        public string BarcodeText
        {
            get
            {
                if (this.ID == -1)
                {
                    throw new ExcecaoTratada("A gaveta deve ser salva antes da etiqueta ser gerada");
                }

                return "ESTGAV" + this.ID.ToString(CultureInfo.InvariantCulture).PadLeft(10, '0');
            }
        }


        public override bool Ativo
        {
            get { return base.Ativo; }
            set
            {
                if (!value)
                {
                    if (!loading)
                    {
                        foreach (EstoqueGavetaItemClass gavetaItem in CollectionEstoqueGavetaItemClassEstoqueGaveta)
                        {
                            gavetaItem.Ativo = false;
                        }
                    }
                }
                base.Ativo = value;
            }
        }

        public string GetLocalizacaoCompleta()
        {
            return this.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao + " - " + this.EstoquePrateleira.EstoqueCorredor.Identificacao + " - " + this.EstoquePrateleira.Identificacao + " - " + this.Identificacao;
        }

        public string GetLocalizacaoCompletaSemNomeEstoque()
        {
            return this.EstoquePrateleira.EstoqueCorredor.Identificacao + " - " + this.EstoquePrateleira.Identificacao + " - " + this.Identificacao;
        }


        public new bool DisableLoadCollection
        {
            get { return base.DisableLoadCollection; }
            set { base.DisableLoadCollection = value; }
        }
    public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "IdentificacaoExata":
                    whereClause += " AND (esg_identificacao ILIKE :IdentificacaoExata) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("IdentificacaoExata", NpgsqlDbType.Varchar, parametro.Fieldvalue));

                    return true;
                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {

            if (this.Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("IdentificacaoExata", this.Identificacao),
                new SearchParameterClass("EstoquePrateleira",EstoquePrateleira)
            }).Any(a => a.ID != this.ID))
            {
                throw new ExcecaoTratada("Já existe uma gaveta cadastrada com essa identificação nessa prateleira.");
            }



            

            if (!this.Ativo)
            {
                foreach (EstoqueGavetaItemClass item in this.CollectionEstoqueGavetaItemClassEstoqueGaveta)
                {
                    if (item.Ativo && Math.Abs(item.Quantidade) > 0.00001)
                    {
                        throw new ExcecaoTratada("Não é possível desativar a gaveta (" + this + ") pois ela possui itens (" + item.DescricaoItem + ") com saldo em estoque.");
                    }
                    else
                    {
                        item.Ativo = false;
                    }
                }
            }

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public DateTime? BuscaDataUltimaMovimentacaoItem( ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documento, RecursoClass recurso, ProdutoKClass produtoK, EpiClass epi)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                const string consultaBase = "SELECT " +
                                            "  MAX(public.estoque_movimentacao.esm_data) as ultima_utilizacao " +
                                            "FROM " +
                                            "  public.estoque_gaveta_item " +
                                            "  INNER JOIN public.estoque_movimentacao ON (public.estoque_gaveta_item.id_estoque_gaveta_item = public.estoque_movimentacao.id_estoque_gaveta_item) " +
                                            "WHERE " +
                                            "  public.estoque_gaveta_item.id_estoque_gaveta = :id_estoque_gaveta AND  " +
                                            "  public.estoque_gaveta_item.egi_ativo = 1 AND ";


                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer, ID));

                if (produto != null)
                {

                    command.CommandText = consultaBase + "  public.estoque_gaveta_item.id_produto = :id_produto ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer, produto.ID));
                    return command.ExecuteScalar() as DateTime?;
                }

                if (material != null)
                {
                    command.CommandText = consultaBase + "  public.estoque_gaveta_item.id_material = :id_material ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer, material.ID));
                    return command.ExecuteScalar() as DateTime?;
                }

                if (documento != null)
                {
                    command.CommandText = consultaBase + "  public.estoque_gaveta_item.id_documento_copia = :id_documento_copia ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer, documento.ID));
                    return command.ExecuteScalar() as DateTime?;
                }

                if (recurso != null)
                {
                    command.CommandText = consultaBase + "  public.estoque_gaveta_item.id_recurso = :id_recurso ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_recurso", NpgsqlDbType.Integer, recurso.ID));
                    return command.ExecuteScalar() as DateTime?;
                }

                if (produtoK != null)
                {
                    command.CommandText = consultaBase + "  public.estoque_gaveta_item.id_produto_k = :id_produto_k ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer, produtoK.ID));
                    return command.ExecuteScalar() as DateTime?;
                }

                if (epi != null)
                {
                    command.CommandText = consultaBase + "  public.estoque_gaveta_item.id_epi = :id_epi ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer, epi.ID));
                    return command.ExecuteScalar() as DateTime?;
                }

                throw new ExcecaoTratada("Um dos tipos de item deve ser informado");
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Buscar a data de ultima movimentação do item no estoque.\r\n" + e.Message, e);
            }
        }

        public bool Ocupada()
        {
            try
            {
                if (this.ID == -1)
                {
                    return false;
                }

                return new EstoqueGavetaItemClass(UsuarioAtual, SingleConnection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Ativo", true),
                    new SearchParameterClass("EstoqueGaveta", this)
                }, limit: 1).Any();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar se a gaveta está ocupada.\r\n" + e.Message, e);
            }
        }

        protected override void AcoesExtrasAntesDelete(ref IWTPostgreNpgsqlCommand command)
        {
            for (var i = 0; i < CollectionEstoqueGavetaItemClassEstoqueGaveta.Count; i++)
            {
                EstoqueGavetaItemClass item = CollectionEstoqueGavetaItemClassEstoqueGaveta[i];
                if (item.Quantidade > 0)
                {
                    throw new ExcecaoTratada("Não é possível excluir essa gaveta pois ela possui itens com quantidade");
                }

                item.Delete(ref command);
                CollectionEstoqueGavetaItemClassEstoqueGaveta.RemoveAt(0);
                i--;
            }

            base.AcoesExtrasAntesDelete(ref command);
        }

        protected override bool ValidateDelete()
        {
            if (!PodeExcluir())
            {
                throw new ExcecaoTratada("Não é possível excluir essa gaveta pois ela possui itens");
            }

            return base.ValidateDelete();
        }

        public bool PodeExcluir()
        {
            foreach (EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassEstoqueGaveta.Where(a => a.Ativo))
            {
                if (item.Quantidade > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

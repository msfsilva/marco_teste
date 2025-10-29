using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BarcodeLib;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class PostoTrabalhoClass : PostoTrabalhoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do PostoTrabalhoClass";
        protected new const string ErroDelete = "Erro ao excluir o PostoTrabalhoClass  ";
        protected new const string ErroSave = "Erro ao salvar o PostoTrabalhoClass.";
        protected new const string ErroCollectionNotificacaoDesvioClassPostoTrabalho = "Erro ao carregar a coleção de NotificacaoDesvioClass.";
        protected new const string ErroCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoClass.";
        protected new const string ErroCollectionOrdemProducaoRecursoClassPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoRecursoClass.";
        protected new const string ErroCollectionRecursoClassPostoTrabalho = "Erro ao carregar a coleção de RecursoClass.";
        protected new const string ErroCollectionProdutoPostoTrabalhoClassPostoTrabalho = "Erro ao carregar a coleção de ProdutoPostoTrabalhoClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do PostoTrabalhoClass.";
        protected new const string MensagemUtilizadoCollectionNotificacaoDesvioClassPostoTrabalho = "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes NotificacaoDesvioClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassPostoTrabalho = "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoRecursoClassPostoTrabalho = "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoRecursoClass:";
        protected new const string MensagemUtilizadoCollectionRecursoClassPostoTrabalho = "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes RecursoClass:";
        protected new const string MensagemUtilizadoCollectionProdutoPostoTrabalhoClassPostoTrabalho = "A entidade PostoTrabalhoClass está sendo utilizada nos seguintes ProdutoPostoTrabalhoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade PostoTrabalhoClass está sendo utilizada.";

        #endregion


        public PostoTrabalhoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public string TipoAcompanhamento
        {
            get
            {
                switch (Acompanhamento)
                {
                    case PostoTrabalhoAcompanhamento.SemAcompanhamento:
                        return String.Empty;
                        break;
                    case PostoTrabalhoAcompanhamento.UmTempo:
                        return "1 Tempo";
                    case PostoTrabalhoAcompanhamento.UmTempoComQtd:
                        return "1 Tempo com Controle de Qtd";
                        break;
                    case PostoTrabalhoAcompanhamento.DoisTempos:
                        return "2 Tempos";
                        break;
                    case PostoTrabalhoAcompanhamento.TresTempos:
                        return "3 Tempos";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                
            }
         
        }

        public bool Acompanhamento1Tempo
        {
            get
            {
                if (this.Acompanhamento == PostoTrabalhoAcompanhamento.UmTempo)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    this.Acompanhamento = PostoTrabalhoAcompanhamento.UmTempo;
            }
        }

   
        public bool Acompanhamento2Tempos
        {
            get
            {
                if (this.Acompanhamento == PostoTrabalhoAcompanhamento.DoisTempos)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    this.Acompanhamento = PostoTrabalhoAcompanhamento.DoisTempos;
            }
        }

 
        public bool Acompanhamento3Tempos
        {
            get
            {
                if (this.Acompanhamento == PostoTrabalhoAcompanhamento.TresTempos)
                    return true;
                return false;
            }
            set
            {
                if (value)
                    this.Acompanhamento = PostoTrabalhoAcompanhamento.TresTempos;
            }
        }

        public string BarcodeTexto
        {
            get { return "IDPT|" + this.ID; }
        }

        private byte[] _barcode;
        public byte[] Barcode
        {
            get
            {
                if (this._barcode == null)
                {
                    LoadCodigoBarras();
                }
                return this._barcode;
            }
        }

        private void LoadCodigoBarras()
        {

            using (Barcode barcode = new Barcode())
            {
                barcode.Alignment = AlignmentPositions.CENTER;
                barcode.Height = 200;
                barcode.Width = 650;
                barcode.ImageFormat = ImageFormat.Jpeg;

                using (Bitmap bmpBarcode = new Bitmap(barcode.Encode(TYPE.CODE128, BarcodeTexto)))
                {
                    bmpBarcode.SetResolution(300, 300);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmpBarcode.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        bmpBarcode.Save(ms, ImageFormat.Jpeg);
                        

                        ms.Seek(0, SeekOrigin.Begin);

                        using (BinaryReader br = new BinaryReader(ms))
                        {
                            _barcode = br.ReadBytes((int) ms.Length);
                        }
                    }
                }

            }
        }


        public override string ToString()
        {
            return this.Codigo;
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

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "TipoAcompanhamento":
                    orderByClause += " ,posto_trabalho.pos_acompanhamento " + ordenacao.ToString() + " ";
                    return true;
                default:
                    return false;
            }
            
            
        }
    }
}

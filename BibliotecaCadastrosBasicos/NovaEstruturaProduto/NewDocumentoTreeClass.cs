#region Referencias

using System.Drawing;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTTreeComponent;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public class NewDocumentoTreeClass : IWTTreeConteudo
    {
        internal readonly ProdutoDocumentoTipoClass _produtoDocumentoTipo;


        public long idDocumentoTipoFamilia
        {
            get { return this._produtoDocumentoTipo.DocumentoTipoFamilia.ID; }
        }

        public long idDocumentoTipo
        {
            get { return this._produtoDocumentoTipo.DocumentoTipoFamilia.DocumentoTipo.ID; }
        }
        public string codDocumento
        {
            get { return this._produtoDocumentoTipo.DocumentoTipoFamilia.DocumentoTipo.Identificacao; }
        }
        public string tipoDocumento
        {
            get { return this._produtoDocumentoTipo.DocumentoTipoFamilia.FamiliaDocumento.Codigo; }
        }

        public string revisaoDocumento
        {
            get { return this._produtoDocumentoTipo.DocumentoTipoFamilia.DocumentoTipo.RevisaoAtual; }
        }

        readonly Color corLinha = Color.Black;

        public IWTNodeParentInterface Pai { get; private set; }

        public NewDocumentoTreeClass(ProdutoDocumentoTipoClass produtoDocumentoTipo )
        {
            _produtoDocumentoTipo = produtoDocumentoTipo;
        }

        #region IWTTreeConteudo Members

        public override object getEntidadeOrigem()
        {
            return this._produtoDocumentoTipo;
        }

        public override void setSequencia(int sequencia)
        {

        }
        public override int getSequencia()
        {
            return 0;
        }

        public override string getTextoFigura()
        {
            return this.ToString();
        }

      

        public override Color getCorLinha()
        {
            return this.corLinha;
        }

        public override IWTTreeNodeForms getFigura(ref IWTNodeInterface NoAtual)
        {
            return new IWTTreeNodeFomRetangulo(Color.FromArgb(255, 204, 204), Color.Purple, false, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(), this.Pai.getAlturaComponente(), NoAtual,
                                               this);
        }

      

        public override IWTTreeConteudo Clone()
        {
            NewDocumentoTreeClass toRet = new NewDocumentoTreeClass(this._produtoDocumentoTipo);
            return toRet;
        }

        public override void setQuantidade(double quantidade)
        {
            
        }

        public override string getTextoLinha()
        {
            return null;
        }

        public override string ToString()
        {
            return this.tipoDocumento + " " + this.codDocumento + " " + this.revisaoDocumento;
        }

        #endregion
        public override bool getLinhaPontilhada()
        {
            return false;
        }
        public override double getQuantidade()
        {
            return 0;
        }
        public override void MoverFilho(IWTTreeNode origem, IWTTreeConteudo filhoMover, IWTTreeNode destino)
        {
            throw new ExcecaoTratada("Não é possível mover um filho de/para um objeto desse tipo");
        }

        #region IWTTreeConteudo Members


        public override IWTNodeParentInterface getPaiGeral()
        {
            return this.Pai;
        }

        public override void setPaiGeral(IWTNodeParentInterface Pai)
        {
            this.Pai = Pai;
        }

        public override int getId()
        {
            return (int) idDocumentoTipoFamilia;
        }

        #endregion

        public override string getTituloTooltip()
        {
            return "Documento: " + this.ToString();
        }

        public override string getTextoTooltip()
        {
            return "Familia: " + this.tipoDocumento + "\r\n" +
                   "Documento: " + this.codDocumento + "\r\n" +
                   "Revisão: " + this.revisaoDocumento;


        }
    }
}

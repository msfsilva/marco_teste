#region Referencias

using System.Drawing;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTTreeComponent;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public class NewAcabamentoTreeClass : IWTTreeConteudo
    {
        internal readonly ProdutoAcabamentoClass _produtoAcabamento;

        readonly Color corLinha = Color.Black;

        public long idAcabamento
        {
            get { return this._produtoAcabamento.Acabamento.ID; }
        }

        public string Identificacao
        {
            get { return this._produtoAcabamento.Acabamento.Identificacao; }
        }

        public string Descricao
        {
            get { return this._produtoAcabamento.Acabamento.DescricaoTecnica; }
        }


        public IWTNodeParentInterface Pai { get; private set; }

        public NewAcabamentoTreeClass(ProdutoAcabamentoClass produtoAcabamento)
        {
            _produtoAcabamento = produtoAcabamento;
        


        }
        public override bool getLinhaPontilhada()
        {
            return false;
        }

        #region IWTTreeConteudo Members

        public override object getEntidadeOrigem()
        {
            return this._produtoAcabamento;
        }

        public override void MoverFilho(IWTTreeNode origem, IWTTreeConteudo filhoMover, IWTTreeNode destino)
        {
            throw new ExcecaoTratada("Não é possível mover um filho de/para um objeto desse tipo");
        }


        public override void setSequencia(int sequencia)
        {

        }
        public override int getSequencia()
        {
            return 0;
        }

      



        public override Color getCorLinha()
        {
            return this.corLinha;
        }

        public override IWTTreeNodeForms getFigura(ref IWTNodeInterface NoAtual)
        {

            return new IWTTreeNodeFomRetangulo(Color.FromArgb(229, 229, 229), Color.Gray, false, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(), this.Pai.getAlturaComponente(), NoAtual,
                                               this);
        }


        public override string getTextoFigura()
        {
            return this.Identificacao;
        }
     

        public override IWTTreeConteudo Clone()
        {
            NewAcabamentoTreeClass toRet = new NewAcabamentoTreeClass(this._produtoAcabamento);
            return toRet;

        }

        public override void setQuantidade(double quantidade)
        {
            
        }

        public override double getQuantidade()
        {
            return 0;
        }

        public override string getTextoLinha()
        {
            return "";
        }

        
        public override string ToString()
        {
            return this.Identificacao;
        }




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
            return (int) idAcabamento;
        }

        public override string getTituloTooltip()
        {
            return "Acabamento: " + this.Identificacao;
        }

        public override string getTextoTooltip()
        {
            return "Descrição: " + this.Descricao + "\r\n" +
                   "Norma Cliente: " + this._produtoAcabamento.Acabamento.NormaCliente;


        }

        #endregion
    }
}

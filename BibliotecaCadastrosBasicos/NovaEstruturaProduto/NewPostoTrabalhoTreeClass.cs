#region Referencias

using System.Drawing;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTLineComponent;
using IWTTreeComponent;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public class NewPostoTrabalhoTreeClass : IWTTreeConteudo
    {
        private readonly ProdutoPostoTrabalhoClass _posto;
        public NewProdutoTreeClass ProdutoPai { get; private set; }
        readonly Color corLinha;


        private int Largura = 110;
        private int Altura = 110;

        public IWTNodeParentInterface Pai { get; private set; }



        public double TempoSetup
        {
            get { return _posto.TempoSetup; }
            set { _posto.TempoSetup = value; }
        }


        public double TempoProducao
        {
            get { return _posto.TempoProducao; }
            set { _posto.TempoProducao = value; }
        }
        public NewPostoTrabalhoTreeClass(ProdutoPostoTrabalhoClass posto, NewProdutoTreeClass produtoPai)
        {
            _posto = posto;
            ProdutoPai = produtoPai;
            this.corLinha = Color.Black;
        }

        public override string ToString()
        {
            return this._posto.PostoTrabalho.Codigo;
        }


        #region IWTTreeConteudo Members

        public override object getEntidadeOrigem()
        {
            return this._posto;
        }

        public override void setSequencia(int sequencia)
        {
            this._posto.Sequencia = sequencia;
        }
        public override int getSequencia()
        {
            return this._posto.Sequencia;
        }

        public override string getTextoFigura()
        {
            return this._posto.Sequencia + " - " + this._posto.PostoTrabalho.Codigo + "\r\n" + this._posto.PostoTrabalho.OperacaoPosto + "\r\nTS: " + this._posto.TempoSetup.ToString() + "\r\nTO: " + this._posto.TempoProducao.ToString();
        }

        

        public override Color getCorLinha()
        {
            return this.corLinha;
        }

        public override IWTTreeNodeForms getFigura(ref IWTNodeInterface NoAtual)
        {
            return new IWTTreeNodeFomRetangulo(Color.FromArgb(102, 255, 255), Color.LightGreen, true, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(), this.Pai.getAlturaComponente(),
                                               NoAtual, this);
        }

      

        public override IWTTreeConteudo Clone()
        {
            NewPostoTrabalhoTreeClass toRet = new NewPostoTrabalhoTreeClass(this._posto, this.ProdutoPai);
            return toRet;

        }

        public override void setQuantidade(double quantidade)
        {
            
        }

        public override double getQuantidade()
        {
            return 1;
        }

        public override string getTextoLinha()
        {
            return "";
        }


        #endregion

        public override bool getLinhaPontilhada()
        {
            return false;
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
            return (int) _posto.PostoTrabalho.ID;
        }

        #endregion

        public override void MoverFilho(IWTTreeNode origem, IWTTreeConteudo filhoMover, IWTTreeNode destino)
        {
            throw new ExcecaoTratada("Não é possível mover um filho de/para um objeto desse tipo");
        }

        public override string getTituloTooltip()
        {
            return "Posto de Trabalho: " + this.ToString();
        }

        public override string getTextoTooltip()
        {
            return "Nome:" + this._posto.PostoTrabalho.Nome + "\r\n" +
                   "Operação " + this._posto.PostoTrabalho.OperacaoPosto;


        }

        public void AdicionarProximo(IWTLineNode noAtual, PostoTrabalhoClass posto, double tempoProducao, double tempoSetup, IWTTreeNode noProdutoAtual)
        {

            this.ProdutoPai.AdcionarPostoTrabalho(posto, tempoProducao, tempoSetup, noAtual.Sequencia + 1, noProdutoAtual);

          

        }
    }
}

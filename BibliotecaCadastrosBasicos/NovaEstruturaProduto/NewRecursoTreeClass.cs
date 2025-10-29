#region Referencias

using System.Drawing;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTTreeComponent;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public class NewRecursoTreeClass : IWTTreeConteudo
    {
        internal readonly ProdutoRecursoClass _produtoRecurso;


        public long idRecurso
        {
            get { return this._produtoRecurso.Recurso.ID; }
        }

        public string Codigo
        {
            get { return this._produtoRecurso.Recurso.Codigo; }
        }
        public string Revisao
        {
            get { return this._produtoRecurso.Recurso.Revisao; }
        }
        public string Nome
        {
            get { return this._produtoRecurso.Recurso.Nome; }
        }
        public string postoTrabalhoCodigo
        {
            get { return this._produtoRecurso.Recurso.PostoTrabalho.Codigo; }
        }
        public string postoTrabalhoNome
        {
            get { return this._produtoRecurso.Recurso.PostoTrabalho.Nome; }
        }

        public string Familia
        {
            get { return this._produtoRecurso.Recurso.FamiliaRecurso.Identificacao; }
        }


        public bool Secundario
        {
            get { return this._produtoRecurso.Hierarquia_Secundario; }
            set { this._produtoRecurso.Hierarquia = value ? HierarquiaRecursoEstrutura.Secundario : HierarquiaRecursoEstrutura.Primario; }
        }


        public IWTNodeParentInterface Pai { get; private set; }
        readonly Color corLinha = Color.Black;

        public NewRecursoTreeClass(ProdutoRecursoClass produtoRecurso)
        {
            _produtoRecurso = produtoRecurso;

        }

        #region IWTTreeConteudo Members

        public override object getEntidadeOrigem()
        {
            return this._produtoRecurso;
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
            return this.Familia + " " + this.Codigo + " " + this.Revisao;
        }


        public override Color getCorLinha()
        {
            return this.corLinha;
        }

        public override IWTTreeNodeForms getFigura(ref IWTNodeInterface NoAtual)
        {
            return new IWTTreeNodeFomRetangulo(Color.FromArgb(255, 255, 204), Color.Beige, false, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(), this.Pai.getAlturaComponente(), NoAtual,
                                               this);
        }

        

        public override IWTTreeConteudo Clone()
        {
            NewRecursoTreeClass toRet = new NewRecursoTreeClass(this._produtoRecurso);
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
            if (this.Secundario)
            {
                return "  S";
            }
            else
            {
                return "  P";
            }
        }

        #endregion

        public override string ToString()
        {
            return this.Codigo;
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
            return (int) idRecurso;
        }

        #endregion
        public override void MoverFilho(IWTTreeNode origem, IWTTreeConteudo filhoMover, IWTTreeNode destino)
        {
            throw new ExcecaoTratada("Não é possível mover um filho de/para um objeto desse tipo");
        }

        public override bool getLinhaPontilhada()
        {
            return false;
        }

        public override string getTituloTooltip()
        {
            return "Recurso: " + this.ToString();
        }

        public override string getTextoTooltip()
        {
            return "Familia: " + Familia + "\r\n" +
                   "Descrição:" + this.Nome + "\r\n" +
                   "Revisão:" + this.Revisao + "\r\n" +
                   "Posto Trabalho " + this.postoTrabalhoCodigo;
        }

       
    }
}

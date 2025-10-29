#region Referencias

using System;
using System.Drawing;
using System.Globalization;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTTreeComponent;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public class NewMaterialTreeClass : IWTTreeConteudo
    {
        internal readonly ProdutoMaterialClass _produtoMaterial;

        #region Propriedades do Material
        public long idMaterial
        {
            get { return this._produtoMaterial.Material.ID; }
        }

        public string codMaterial
        {
            get { return this._produtoMaterial.Material.Codigo; }
        }

        public string descMaterial
        {
            get { return this._produtoMaterial.Material.Descricao; }
        }

        public string unidadeMedida
        {
            get { return this._produtoMaterial.Material.UnidadeMedida.ToString(); }
        }

        public string acabamentoCodigo
        {
            get { return this._produtoMaterial.Material.Acabamento.ToString(); }
        }

        public string Dimensao
        {
            get { return this._produtoMaterial.Material.MedidaCompleta; }
        }

        public string Familia
        {
            get { return this._produtoMaterial.Material.FamiliaMaterial.ToString(); }
        }

        #endregion


        #region Propriedades do Produto Material

        public double? Quantidade
        {
            get { return this._produtoMaterial.Quantidade; }
            set { this._produtoMaterial.Quantidade = value.HasValue ? value.Value : 0; }
        }


        public bool PlanoCorte
        {
            get { return this._produtoMaterial.PlanoCorte; }
            set { this._produtoMaterial.PlanoCorte = value; }
        }

        public double? PlanoCorteQuantidade
        {
            get { return this._produtoMaterial.PlanoCorteQuantidade; }
            private set { this._produtoMaterial.PlanoCorteQuantidade = value; }
        }

        public string Dimensao1Valor
        {
            get { return this._produtoMaterial.PlanoCorteDimensao1; }
            private set { this._produtoMaterial.PlanoCorteDimensao1 = value; }
        }

        public DimensaoClass Dimensao1
        {
            get { return this._produtoMaterial.Dimensao1; }
            private set { this._produtoMaterial.Dimensao1 = value; }
        }

        public UnidadeMedidaClass Unidade1
        {
            get { return this._produtoMaterial.UnidadeMedidaDimensao1; }
            private set { this._produtoMaterial.UnidadeMedidaDimensao1 = value; }
        }

        public string Dimensao2Valor
        {
            get { return this._produtoMaterial.PlanoCorteDimensao2; }
            private set { this._produtoMaterial.PlanoCorteDimensao2 = value; }
        }

        public DimensaoClass Dimensao2
        {
            get { return this._produtoMaterial.Dimensao2; }
            private set { this._produtoMaterial.Dimensao2 = value; }
        }

        public UnidadeMedidaClass Unidade2
        {
            get { return this._produtoMaterial.UnidadeMedidaDimensao2; }
            private set { this._produtoMaterial.UnidadeMedidaDimensao2 = value; }
        }

        public string Dimensao3Valor
        {
            get { return this._produtoMaterial.PlanoCorteDimensao3; }
            private set { this._produtoMaterial.PlanoCorteDimensao3 = value; }
        }

        public DimensaoClass Dimensao3
        {
            get { return this._produtoMaterial.Dimensao3; }
            private set { this._produtoMaterial.Dimensao3 = value; }
        }

        public UnidadeMedidaClass Unidade3
        {
            get { return this._produtoMaterial.UnidadeMedidaDimensao3; }
            private set { this._produtoMaterial.UnidadeMedidaDimensao3= value; }
        }

        public PostoTrabalhoClass PostoTrabalhoCorte
        {
            get { return this._produtoMaterial.PostoTrabalhoCorte; }
            private set { this._produtoMaterial.PostoTrabalhoCorte = value; }
        }

        public string PlanoCorteInformacoesAdicionais
        {
            get { return this._produtoMaterial.PlanoCorteInformacoesAdicionais; }
            private set { this._produtoMaterial.PlanoCorteInformacoesAdicionais = value; }
        }

        public bool Condicional
        {
            get { return this._produtoMaterial.MaterialCondicional; }
            private set { this._produtoMaterial.MaterialCondicional = value; }
        }

        public string CondicionalRegra
        {
            get { return this._produtoMaterial.MaterialCondicionalRegra; }
            private set { this._produtoMaterial.MaterialCondicionalRegra = value; }
        }


        public bool QuantidadeCondicional
        {
            get { return this._produtoMaterial.QtdCondicional; }
            private set { this._produtoMaterial.QtdCondicional = value; }
        }

        public string QuantidadeCondicionalRegra
        {
            get { return this._produtoMaterial.QtdCondicionalRegra; }
            private set { this._produtoMaterial.QtdCondicionalRegra = value; }
        }

        #endregion


        public IWTNodeParentInterface Pai { get; private set; }
        public Color? Cor { get; private set; }
        readonly Color corLinha = Color.Black;


     


        public NewMaterialTreeClass(ProdutoMaterialClass produtoMaterial)
        {
            _produtoMaterial = produtoMaterial;

            if (string.IsNullOrWhiteSpace(produtoMaterial.Material.FamiliaMaterial.AgrupadorMaterial.Cor))
            {
                this.Cor = Color.FromArgb(200, 255, 200);
            }
            else
            {
                this.Cor = ColorTranslator.FromHtml(produtoMaterial.Material.FamiliaMaterial.AgrupadorMaterial.Cor);
            }
        }

        public void limparPlanoCorte()
        {
            PlanoCorte = false;
            PlanoCorteQuantidade = null;
            PlanoCorteInformacoesAdicionais = null;
            PostoTrabalhoCorte = null;
            Dimensao1 = null;
            Dimensao1Valor = null;
            Dimensao2 = null;
            Dimensao2Valor = null;
            Dimensao3 = null;
            Dimensao3Valor = null;
        }

        public void setPlanoCorte(double planoCorteQuantidade, string planoCorteInformacoesAdicionais, PostoTrabalhoClass postoTrabalhoCorte, DimensaoClass dimensao1, string dimensao1Valor, UnidadeMedidaClass dimensao1Unidade, DimensaoClass dimensao2, string dimensao2Valor, UnidadeMedidaClass dimensao2Unidade, DimensaoClass dimensao3, string dimensao3Valor, UnidadeMedidaClass dimensao3Unidade)
        {
            PlanoCorte = true;
            PlanoCorteQuantidade = planoCorteQuantidade;
            PlanoCorteInformacoesAdicionais = planoCorteInformacoesAdicionais;
            PostoTrabalhoCorte = postoTrabalhoCorte;

            Dimensao1 = dimensao1;
            Dimensao1Valor = dimensao1Valor;
            Unidade1 = dimensao1Unidade;

            Dimensao2 = dimensao2;
            Dimensao2Valor = dimensao2Valor;
            Unidade2 = dimensao2Unidade;

            Dimensao3 = dimensao3;
            Dimensao3Valor = dimensao3Valor;
            Unidade3 = dimensao3Unidade;
        }

        #region IWTTreeConteudo Members
        public override object getEntidadeOrigem()
        {
            return this._produtoMaterial;
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
            return new IWTTreeNodeFomRetangulo(this.Cor.Value, Color.Green, false, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(), this.Pai.getAlturaComponente(), NoAtual, this);
        }



        public override IWTTreeConteudo Clone()
        {
            NewMaterialTreeClass toRet = new NewMaterialTreeClass(this._produtoMaterial);

            return toRet;
        }

        public override void setQuantidade(double quantidade)
        {
            this.Quantidade = quantidade;
        }

        public override double getQuantidade()
        {
            if (this.Quantidade == null)
            {
                return 0;
            }
            else
            {
                return (double)this.Quantidade;
            }
        }

        public override string ToString()
        {
            return this.Familia + " " + this.codMaterial;
        }

        public override int getId()
        {
            return (int)idMaterial;
        }
        #endregion

        #region IWTTreeConteudo Members


        public override string getTextoLinha()
        {
            if (!QuantidadeCondicional)
            {
                return this.Quantidade.Value.ToString("F5", CultureInfo.CurrentCulture).Replace(",00000", "") + " " + this.unidadeMedida;
            }

            return "Cond";
        }


        public override IWTNodeParentInterface getPaiGeral()
        {
            return this.Pai;
        }





        public override void setPaiGeral(IWTNodeParentInterface Pai)
        {
            this.Pai = Pai;
        }

        #endregion

       

        public override void MoverFilho(IWTTreeNode origem, IWTTreeConteudo filhoMover, IWTTreeNode destino)
        {
            throw new ExcecaoTratada("Não é possível mover um filho de/para um objeto desse tipo");
        }

        public override bool getLinhaPontilhada()
        {
            return this.Condicional;
        }

        public override string getTituloTooltip()
        {
            return "Material: " + this.ToString();
        }

        public override string getTextoTooltip()
        {
            string toRet = "Descrição:" + this.descMaterial + "\r\n" + "Unidade de Medida " + this.unidadeMedida + "\r\n" + "Dimensão: " + this.Dimensao;
            if (this.QuantidadeCondicional)
            {
                toRet += "\r\nRegra Quantidade Condicional: " + QuantidadeCondicionalRegra;
            }

            return toRet;
        }

        public void setCondicional(bool condicional, string condicionalRegra)
        {
            this.Condicional = condicional;
            this.CondicionalRegra = condicionalRegra;
        }

        public void setQtdCondicional(bool qtdCondicional, string qtdCondicionalRegra)
        {
            this.QuantidadeCondicional = qtdCondicional;
            this.QuantidadeCondicionalRegra = qtdCondicionalRegra;
        }
    }
}

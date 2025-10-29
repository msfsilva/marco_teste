using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTLineComponent;
using IWTTreeComponent;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{


    public class NewProdutoTreeClass : IWTTreeConteudo
    {
        
        private Color corLinha = Color.Black;
        private IWTNodeParentInterface Pai;

        private ProdutoClass _produto;
        public ProdutoClass Produto
        {
            get
            {
                if (_produto != null)
                {
                    return _produto;
                }
                else
                {
                    if (_produtoPaiFilho != null)
                    {
                        return _produtoPaiFilho.ProdutoFilho;
                    }
                    else
                    {
                        throw new ExcecaoTratada("O produto pai e o produto filho não podem ser vazios ao mesmo tempo em uma entidade NewProdutoTreeClass");
                    }
                } 
            }
        }
        public ProdutoPaiFilhoClass _produtoPaiFilho { get; private set; }




        internal List<NewProdutoTreeClass> Filhos
        {
            get
            {
                return Produto.Filhos.OrderBy(a => a.ProdutoFilho.Codigo).Select(filho => NewEstruturaProdutoClass.CarregarEstrutura(filho)).ToList();
            }
        }

        internal List<NewMaterialTreeClass> Materiais
        {
            get { return Produto.Materiais.OrderBy(a => a.Material.FamiliaMaterial.Codigo).ThenBy(a => a.Material.Codigo).Select(a => new NewMaterialTreeClass(a)).ToList(); }
        }

        internal List<NewDocumentoTreeClass> Documentos
        {
            get
            {
                return
                    Produto.Documentos.
                        OrderBy(a => a.DocumentoTipoFamilia.FamiliaDocumento.Codigo).
                        ThenBy(a => a.DocumentoTipoFamilia.DocumentoTipo.Identificacao).
                        ThenBy(a => a.DocumentoTipoFamilia.DocumentoTipo.RevisaoAtual).
                        Select(a => new NewDocumentoTreeClass(a)).
                        ToList();
            }
        }

        internal List<NewRecursoTreeClass> Recursos
        {
            get { return Produto.Recursos.OrderBy(a => a.Recurso.FamiliaRecurso.ID).ThenBy(a => a.Recurso.Codigo).Select(a => new NewRecursoTreeClass(a)).ToList(); }
        }

        internal NewAcabamentoTreeClass Acabamento
        {
            get { return this.Produto.AcabamentoEstruturaCarregada != null ? new NewAcabamentoTreeClass(this.Produto.AcabamentoEstruturaCarregada) : null; }
        }

        internal List<NewPostoTrabalhoTreeClass> PostosTrabalho
        {
            get { return Produto.CollectionProdutoPostoTrabalhoClassProduto.OrderBy(a => a.Sequencia).Select(a => new NewPostoTrabalhoTreeClass(a, this)).ToList(); }
        }

        private double _qtd = 1;
        private double Quantidade
        {
            get
            {
                if (this._produtoPaiFilho !=null)
                {
                    return this._produtoPaiFilho.QuantidadeFilho;
                }
                else
                {
                    return _qtd;
                }
            }
            set
            {
                if (this._produtoPaiFilho != null)
                {
                    this._produtoPaiFilho.QuantidadeFilho = value;
                }
                else
                {
                    _qtd = value;
                }
            }
        }

        private string _posicaoDesenhoPai = "";
        internal string PosicaoDesenhoPai
        {
            get
            {
                if (this._produtoPaiFilho != null)
                {
                    return this._produtoPaiFilho.PosicaoDesenhoPai;
                }
                else
                {
                    return _posicaoDesenhoPai;
                }
            }
            set
            {
                if (this._produtoPaiFilho != null)
                {
                    this._produtoPaiFilho.PosicaoDesenhoPai = value;
                }
                else
                {
                    _posicaoDesenhoPai = value;
                }
            }
        }

        private string _regraCondicional = "";
        internal string RegraCondicional
        {
            get
            {
                if (this._produtoPaiFilho != null)
                {
                    return this._produtoPaiFilho.FilhoCondicionalRegra;
                }
                else
                {
                    return _regraCondicional;
                }
            }
            set
            {
                if (this._produtoPaiFilho != null)
                {
                    this._produtoPaiFilho.FilhoCondicionalRegra = value;
                }
                else
                {
                    _regraCondicional = value;
                }
            }
        }

        private bool _condicional = false;
        internal bool Condicional
        {
            get
            {
                if (this._produtoPaiFilho != null)
                {
                    return this._produtoPaiFilho.FilhoCondicional;
                }
                else
                {
                    return _condicional;
                }
            }
            set
            {
                if (this._produtoPaiFilho != null)
                {
                    this._produtoPaiFilho.FilhoCondicional = value;
                }
                else
                {
                    _condicional = value;
                }
            }
        }




        private string _regraCondicionalQtd = "";
        internal string QtdCondicionalRegra
        {
            get
            {
                if (this._produtoPaiFilho != null)
                {
                    return this._produtoPaiFilho.QtdCondicionalRegra;
                }
                else
                {
                    return _regraCondicionalQtd;
                }
            }
            set
            {
                if (this._produtoPaiFilho != null)
                {
                    this._produtoPaiFilho.QtdCondicionalRegra = value;
                }
                else
                {
                    _regraCondicionalQtd = value;
                }
            }
        }

        private bool _condicionalQtd = false;
        internal bool QtdCondicional
        {
            get
            {
                if (this._produtoPaiFilho != null)
                {
                    return this._produtoPaiFilho.QtdCondicional;
                }
                else
                {
                    return _condicionalQtd;
                }
            }
            set
            {
                if (this._produtoPaiFilho != null)
                {
                    this._produtoPaiFilho.QtdCondicional = value;
                }
                else
                {
                    _condicionalQtd = value;
                }
            }
        }


        public tipoExibicao TipoExibicao
        {
            get
            {
                if (!confCarregadas)
                {

                    ConfiguracaUsuario.ConfUsuario.refreshConf();

                    #region busca Configurações Display

                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_MODO_PADRAO) != null)
                    {
                        _tipoExibicao = (tipoExibicao)Enum.ToObject(typeof(tipoExibicao), Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_MODO_PADRAO)));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_LARGURA_VERTICAL) != null)
                    {
                        larguraColunaVertical = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_LARGURA_VERTICAL));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_ALTURA_VERTICAL) != null)
                    {
                        alturaColunaVertical = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_ALTURA_VERTICAL));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_LARGURA_HORIZONTAL) != null)
                    {
                        larguraColunaHorizontal = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_LARGURA_HORIZONTAL));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_ALTURA_HORIZONTAL) != null)
                    {
                        alturaColunaHorizontal = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_ALTURA_HORIZONTAL));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_TAMANHO_FONTE) != null)
                    {
                        tamanhoFonte = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_TAMANHO_FONTE));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_NEGRITO) != null)
                    {
                        Negrito = Convert.ToBoolean(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_NEGRITO));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_TAMANHO_FONTE_LIGACAO) != null)
                    {
                        tamanhoFonteLigacao = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_TAMANHO_FONTE_LIGACAO));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_NEGRITO_LIGACAO) != null)
                    {
                        negritoLigacao = Convert.ToBoolean(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_NEGRITO_LIGACAO));
                    }


                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_LARGURA_ARVORE_HORIZONTAL) != null)
                    {
                        larguraColunaArvoreHorizontal = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_LARGURA_ARVORE_HORIZONTAL));
                    }
                    if (ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_ALTURA_ARVORE_HORIZONTAL) != null)
                    {
                        alturaColunaArvoreHorizontal = Convert.ToInt32(ConfiguracaUsuario.ConfUsuario.getConf(Constants.ESTRUTURA_ALTURA_ARVORE_HORIZONTAL));
                    }

                    confCarregadas = true;
                    #endregion
                }

                return _tipoExibicao;
            }
            set
            {
                _tipoExibicao = value;
                if (this._arvoreGerada != null)
                {
                    this._arvoreGerada.changeVerticalMode(value);
                }
            }
        }

        private IWTTree _arvoreGerada;
        private IWTLine _roteiroGerado;
        #region ConfiguracoesTela

        internal static tipoExibicao _tipoExibicao = tipoExibicao.Horizontal;
        internal static int larguraColunaVertical = 30;
        internal static int alturaColunaVertical = 180;
        internal static int larguraColunaHorizontal = 135;
        internal static int alturaColunaHorizontal = 75;
        internal static int larguraColunaArvoreHorizontal = 135;
        internal static int alturaColunaArvoreHorizontal = 75;
        internal static int tamanhoFonte = 10;
        internal static bool Negrito = false;
        internal static int tamanhoFonteLigacao = 8;
        internal static bool negritoLigacao = false;

        private static bool confCarregadas = false;

        #endregion



        public NewProdutoTreeClass(ProdutoClass produto, double quantidade = 1, string posicaoDesenhoPai= "")
        {
            _produto = produto;
            Quantidade = quantidade;
            PosicaoDesenhoPai = posicaoDesenhoPai;
          
        }

        public NewProdutoTreeClass(ProdutoPaiFilhoClass produtoPaiFilho)
        {
            _produtoPaiFilho = produtoPaiFilho;
        }



        #region IWTTreeConteudo

        public override object getEntidadeOrigem()
        {
            return this._produtoPaiFilho != null ? (AbstractEntity) this._produtoPaiFilho : Produto;

        }

        public override void MoverFilho(IWTTreeNode origem, IWTTreeConteudo filhoMover, IWTTreeNode destino)
        {
            NewProdutoTreeClass dest = (NewProdutoTreeClass) destino.Conteudo;
            switch (filhoMover.GetType().FullName)
            {
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewProdutoTreeClass":
                    this.Produto.ExcluirFilho(((NewProdutoTreeClass) filhoMover)._produtoPaiFilho,null);
                    dest.Produto.AdicionarFilho(
                        ((NewProdutoTreeClass)filhoMover).Produto, 
                        ((NewProdutoTreeClass)filhoMover).Quantidade, 
                        ((NewProdutoTreeClass)filhoMover).PosicaoDesenhoPai,
                        ((NewProdutoTreeClass)filhoMover).Condicional,
                        ((NewProdutoTreeClass)filhoMover).RegraCondicional,
                        ((NewProdutoTreeClass)filhoMover).QtdCondicional,
                        ((NewProdutoTreeClass)filhoMover).QtdCondicionalRegra, 
                        null
                        );
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewMaterialTreeClass":
                    ProdutoMaterialClass mat = ((NewMaterialTreeClass) filhoMover)._produtoMaterial;
                    this.Produto.ExcluirMaterial(mat, null);
                    dest.Produto.AdicionarMaterial(
                        mat.Material, mat.Quantidade, mat.PlanoCorte, mat.PlanoCorteQuantidade,
                        mat.PlanoCorteInformacoesAdicionais, mat.PostoTrabalhoCorte,
                        mat.Dimensao1, mat.PlanoCorteDimensao1, mat.UnidadeMedidaDimensao1,
                        mat.Dimensao2, mat.PlanoCorteDimensao2, mat.UnidadeMedidaDimensao2,
                        mat.Dimensao3, mat.PlanoCorteDimensao3, mat.UnidadeMedidaDimensao3,
                        mat.MaterialCondicional,mat.MaterialCondicionalRegra,
                        mat.QtdCondicional, mat.QtdCondicionalRegra, null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewDocumentoTreeClass":
                    ProdutoDocumentoTipoClass doc = ((NewDocumentoTreeClass)filhoMover)._produtoDocumentoTipo;
                    this.Produto.ExcluirDocumento(doc, null);
                    dest.Produto.AdicionarDocumento(doc.DocumentoTipoFamilia, null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewRecursoTreeClass":
                    ProdutoRecursoClass rec = ((NewRecursoTreeClass)filhoMover)._produtoRecurso;
                    this.Produto.ExcluirRecurso(rec, null);
                    dest.Produto.AdicionarRecurso(rec.Recurso, rec.Hierarquia_Secundario, null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewAcabamentoTreeClass":
                    ProdutoAcabamentoClass acab = ((NewAcabamentoTreeClass)filhoMover)._produtoAcabamento;
                    this.Produto.ExcluirAcabamento(acab, null);
                    dest.Produto.AdicionarAcabamento(acab.Acabamento, null);
                    break;
            }

            this._arvoreGerada = null;
            this.LimpaArvoreGeradaAcima(origem);
            dest._arvoreGerada = null;
            dest.LimpaArvoreGeradaAcima(destino);
        }

        public override Color getCorLinha()
        {
            return this.corLinha;
        }

        public override IWTTreeNodeForms getFigura(ref IWTNodeInterface NoAtual)
        {
            switch (Produto.TipoAquisicao)
            {
                case TipoAquisicao.Fabricado:
                    return new IWTTreeNodeFomRetangulo(Color.FromArgb(204, 255, 255), Color.Aqua, true, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(),
                                                       this.Pai.getAlturaComponente(), this.Produto.EmiteOp, this.Produto.EmitePlanoCorte, NoAtual, this);
                    break;
                case TipoAquisicao.Comprado:
                    return new IWTTreeNodeFomRetangulo(Color.FromArgb(0, 204, 255), Color.Aqua, true, this.Pai.getNegrito(), this.Pai.getTamanhoFonte(), this.Pai.getVerticalMode(), this.Pai.getLarguraComponente(),
                                                       this.Pai.getAlturaComponente(), this.Produto.EmiteOp, this.Produto.EmitePlanoCorte, NoAtual, this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override IWTTreeConteudo Clone()
        {
            if (this._produto!=null)
            {
                return new NewProdutoTreeClass(this._produtoPaiFilho);    
            }
            else
            {
                return new NewProdutoTreeClass(this._produto, this.Quantidade, this.PosicaoDesenhoPai);
            }
            
        }

        public override void setQuantidade(double Quantidade)
        {
            this.Quantidade = Quantidade;
        }

        public override double getQuantidade()
        {
            return this.Quantidade;
        }

        public override string getTextoLinha()
        {
            
            if (!QtdCondicional)
            {
                return this.Quantidade.ToString("F2", CultureInfo.CurrentCulture).Replace(",00", "") + " " + this.Produto.UnidadeMedida;
            }
            else
            {
                return "Cond";
            }
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
            return this.Produto.Codigo;
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
            if (Produto != null) return (int) Produto.ID;
            return -1;
        }

        public override string getTituloTooltip()
        {
            return "Item: " + this.Produto.Codigo;
        }

        public override string getTextoTooltip()
        {
            string toRet = "Descrição:" + this.Produto.Descricao + "\r\n" +
                           "Cliente: " + this.Produto.Cliente + "\r\n" +
                           "Aquisição: " + this.Produto.TipoAquisicao.ToString() + "\r\n" +
                           "Politica Estoque: " + this.Produto.PoliticaEstoque + "\r\n" +
                           "Exige Conferência Expedição: " + (this.Produto.EtiquetaInterna ? "Sim" : "Não");

            if (this.QtdCondicional)
            {
                toRet += "\r\nRegra Quantidade Condicional: " + QtdCondicionalRegra;
            }


            return toRet;
        }



        #endregion

        public override bool getLinhaPontilhada()
        {
            return this.Condicional;
        }

        public override string ToString()
        {
            return this.Produto.ToString();
        }



        public IWTTree getArvore()
        {
            try
            {

                if (this._arvoreGerada != null)
                {
                    return _arvoreGerada;
                }

                _arvoreGerada = new IWTTree(this,
                                            TipoExibicao,
                                            larguraColunaVertical, alturaColunaVertical,
                                            larguraColunaHorizontal, alturaColunaHorizontal,
                                            larguraColunaArvoreHorizontal, alturaColunaArvoreHorizontal,
                                            tamanhoFonte, Negrito,
                                            tamanhoFonteLigacao, negritoLigacao);


                _arvoreGerada.Cabeca.startLoading();

                foreach (NewProdutoTreeClass filho in Filhos)
                {
                    _arvoreGerada.Cabeca.adicionarRamo(filho.getArvore(), filho.Quantidade);
                }

                foreach (NewDocumentoTreeClass documento in Documentos)
                {
                    _arvoreGerada.Cabeca.adicionarFilho(documento);
                }


                if (this.Acabamento != null)
                {
                    _arvoreGerada.Cabeca.adicionarFilho(Acabamento);
                }

                foreach (NewMaterialTreeClass material in Materiais)
                {
                    _arvoreGerada.Cabeca.adicionarFilho(material);
                }

           

              


                foreach (NewRecursoTreeClass recurso in Recursos)
                {
                    _arvoreGerada.Cabeca.adicionarFilho(recurso);
                }


                _arvoreGerada.Cabeca.finishedLoading();
                return _arvoreGerada;



            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }

        }

        public IWTLine getRoteiro()
        {
            if (this._roteiroGerado != null)
            {
                return _roteiroGerado;
            }

            _roteiroGerado = new IWTLine(false);

            IWTLineNode noAtual = _roteiroGerado.Inicio;
            foreach (NewPostoTrabalhoTreeClass posto in this.PostosTrabalho)
            {
                noAtual = noAtual.insereNovoProximo(posto);
            }


            return _roteiroGerado;
        }

        public void ChangeVerticalMode(tipoExibicao tipoExibicao)
        {
            this.TipoExibicao = tipoExibicao;
        }

        public void AdicionarFilho(IWTTreeNode noAtual, ProdutoClass produtoAdicionar, double quantidade, string posicaoDesenhoPai, bool condicional, string condicionalRegra, bool qtdCondicional, string qtdCondicionalRegra)
        {
            List<ProdutoClass> listaItensInserir = ListaItensAbaixo(produtoAdicionar);
            foreach (ProdutoClass inserir in listaItensInserir)
            {
                this.VerificaItemAcima(noAtual, inserir);
            }



            Produto.AdicionarFilho(produtoAdicionar, quantidade, posicaoDesenhoPai, condicional, condicionalRegra, qtdCondicional, qtdCondicionalRegra, null);
            setProdutoAlterado(noAtual);
            this.LimpaArvoreGeradaAcima(noAtual);

            

        }

        private List<ProdutoClass> ListaItensAbaixo(ProdutoClass produto)
        {
            List<ProdutoClass> toRet = new List<ProdutoClass>
                                           {
                                               produto
                                           };

            foreach (ProdutoPaiFilhoClass paiFilhoClass in produto.Filhos)
            {
                toRet.AddRange(ListaItensAbaixo(paiFilhoClass.ProdutoFilho));
            }

            return toRet;
        }

        private void VerificaItemAcima(IWTTreeNode noAtual, ProdutoClass produtoAdicionar)
        {
            if (noAtual!=null)
            {
                ProdutoClass pr = ((NewProdutoTreeClass) noAtual.Conteudo).Produto;
                if (pr == produtoAdicionar)
                {
                    throw new ExcecaoTratada("Não é possível incluir o item " + produtoAdicionar + " pois ele já faz parte da estrutura acima dele.");
                }
                if (noAtual.Pai!=null)
                {
                    this.VerificaItemAcima(noAtual.Pai, produtoAdicionar);
                }
            }
        }

        public void AdicionarMaterial(IWTTreeNode noAtual, MaterialClass material, double quantidade, bool planoCorte, double planoCorteQuantidade, string planoCorteInformacoesAdicionais, PostoTrabalhoClass postoTrabalhoCorte, DimensaoClass dimensao1, string dimensao1Valor, UnidadeMedidaClass unidade1, DimensaoClass dimensao2, string dimensao2Valor, UnidadeMedidaClass unidade2, DimensaoClass dimensao3, string dimensao3Valor, UnidadeMedidaClass unidade3, bool materialCondicional, string materialCondicionalRegra, bool qtdCondicional, string qtdCondicionalRegra)
        {

            Produto.AdicionarMaterial(material, quantidade, planoCorte, planoCorteQuantidade, planoCorteInformacoesAdicionais, postoTrabalhoCorte,
                                      dimensao1, dimensao1Valor, unidade1, dimensao2, dimensao2Valor, unidade2, dimensao3, dimensao3Valor, unidade3,
                                      materialCondicional, materialCondicionalRegra, qtdCondicional, qtdCondicionalRegra, null);
            setProdutoAlterado(noAtual);
            this.LimpaArvoreGeradaAcima(noAtual);
            
        }

        public void AdicionarDocumento(IWTTreeNode noAtual, DocumentoTipoFamiliaClass documento)
        {
            Produto.AdicionarDocumento(documento, null);
            setProdutoAlterado(noAtual);
            this.LimpaArvoreGeradaAcima(noAtual);
        }

        public void AdicionarRecurso(IWTTreeNode noAtual, RecursoClass recurso, bool secundario)
        {
            Produto.AdicionarRecurso(recurso, secundario, null);
            setProdutoAlterado(noAtual);
            this.LimpaArvoreGeradaAcima(noAtual);
        }

        public void AdicionarAcabamento(IWTTreeNode noAtual, AcabamentoClass acabamento)
        {
            Produto.AdicionarAcabamento(acabamento, null);
            setProdutoAlterado(noAtual);
            this.LimpaArvoreGeradaAcima(noAtual);

        }


        public void AdcionarPostoTrabalho(PostoTrabalhoClass posto, double tempoProducao, double tempoSetup, int sequencia, IWTTreeNode noAtual)
        {
            Produto.AdcionarPostoTrabalho(posto, tempoProducao, tempoSetup, sequencia, null);
            setProdutoAlterado(noAtual);
            this.LimparRoteiroGerado();
        }


        internal void LimpaArvoreGeradaAcima(IWTTreeNode noAtual)
        {
            this._arvoreGerada = null;
            if (noAtual!=null && noAtual.Pai != null)
            {
                ((NewProdutoTreeClass) noAtual.Pai.Conteudo).LimpaArvoreGeradaAcima(noAtual.Pai);
            }

            this.Produto.setAlterado(true);
            

        }

        public void ExcluirFilho(IWTTreeNode noAtual, IWTTreeConteudo conteudo)
        {
            switch (conteudo.GetType().FullName)
            {
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewProdutoTreeClass":
                    this.Produto.ExcluirFilho((ProdutoPaiFilhoClass)conteudo.getEntidadeOrigem(), null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewMaterialTreeClass":
                    this.Produto.ExcluirMaterial((ProdutoMaterialClass)conteudo.getEntidadeOrigem(), null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewAcabamentoTreeClass":
                    this.Produto.ExcluirAcabamento((ProdutoAcabamentoClass)conteudo.getEntidadeOrigem(), null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewRecursoTreeClass":
                    this.Produto.ExcluirRecurso((ProdutoRecursoClass)conteudo.getEntidadeOrigem(), null);
                    break;
                case "BibliotecaCadastrosBasicos.NovaEstruturaProduto.NewDocumentoTreeClass":
                    this.Produto.ExcluirDocumento((ProdutoDocumentoTipoClass)conteudo.getEntidadeOrigem(), null);
                    break;
                default:
                    throw new Exception("Tipo inválido para exclusão: " + conteudo.GetType().FullName);

            }

            setProdutoAlterado(noAtual);
            this.LimpaArvoreGeradaAcima(noAtual);
        }


        public void ExcluirPostoTrabalho(NewPostoTrabalhoTreeClass postoTrabalhoExcluir, IWTTreeNode noAtual)
        {
            this.Produto.ExcluirPostoTrabalho((ProdutoPostoTrabalhoClass)postoTrabalhoExcluir.getEntidadeOrigem(), null);
             setProdutoAlterado(noAtual);
            LimparRoteiroGerado();

        }

        internal void LimparRoteiroGerado()
        {
            this._roteiroGerado = null;
        }

        internal void setProdutoAlterado(IWTTreeNode noAtual)
        {
            if (noAtual != null)
            {
                if (noAtual.Conteudo is NewProdutoTreeClass)
                {
                    ((NewProdutoTreeClass) noAtual.Conteudo).Produto.setAlterado(true);
                    if (((NewProdutoTreeClass) noAtual.Conteudo)._produtoPaiFilho!=null)
                    {
                        ((NewProdutoTreeClass) noAtual.Conteudo)._produtoPaiFilho.setAlterado(true);
                    }
                }


                if (noAtual.Pai != null)
                {
                    ((NewProdutoTreeClass)noAtual.Pai.Conteudo).setProdutoAlterado(noAtual.Pai);
                }
            }
        }

        public void CopiarRoteiro(ProdutoClass origem, IWTTreeNode noAtual)
        {
            try
            {
                while (this.PostosTrabalho.Count > 0)
                {
                    NewPostoTrabalhoTreeClass postoTrabalho = this.PostosTrabalho[0];
                    this.ExcluirPostoTrabalho(postoTrabalho, noAtual);
                }

                foreach (ProdutoPostoTrabalhoClass produtoPostoTrabalho in origem.CollectionProdutoPostoTrabalhoClassProduto)
                {
                    this.AdcionarPostoTrabalho(
                        produtoPostoTrabalho.PostoTrabalho,
                        produtoPostoTrabalho.TempoProducao,
                        produtoPostoTrabalho.TempoSetup,
                        produtoPostoTrabalho.Sequencia,
                        noAtual
                        );
                    

                }

                this.setProdutoAlterado(noAtual);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao copiar o roteiro.\r\n" + e.Message, e);
            }
        }
    }
}

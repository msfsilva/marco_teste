using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades 
{
    public class CentroCustoLucroClass : CentroCustoLucroBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do CentroCustoLucroClass";
        protected new const string ErroDelete = "Erro ao excluir o CentroCustoLucroClass  ";
        protected new const string ErroSave = "Erro ao salvar o CentroCustoLucroClass.";
        protected new const string ErroCollectionCentroCustoLucroClassCentroCustoLucroPai = "Erro ao carregar a coleção de CentroCustoLucroClass.";
        protected new const string ErroCollectionContaRecorrenteClassCentroCustoLucro = "Erro ao carregar a coleção de ContaRecorrenteClass.";
        protected new const string ErroCollectionFornecedorClassCentroCustoLucro = "Erro ao carregar a coleção de FornecedorClass.";
        protected new const string ErroCollectionOrcamentoItemClassCentroCustoLucro = "Erro ao carregar a coleção de OrcamentoItemClass.";
        protected new const string ErroCollectionPedidoItemClassCentroCustoLucro = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroCollectionContaReceberClassCentroCustoLucro = "Erro ao carregar a coleção de ContaReceberClass.";
        protected new const string ErroCollectionRepresentanteClassCentroCustoLucro = "Erro ao carregar a coleção de RepresentanteClass.";
        protected new const string ErroCollectionClienteClassCentroCustoLucro = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionContaPagarClassCentroCustoLucro = "Erro ao carregar a coleção de ContaPagarClass.";
        protected new const string ErroCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro = "Erro ao carregar a coleção de AgrupadorPostoTrabalhoClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 50 caracteres";
        protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
        protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do CentroCustoLucroClass.";
        protected new const string MensagemUtilizadoCollectionCentroCustoLucroClassCentroCustoLucroPai = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes CentroCustoLucroClass:";
        protected new const string MensagemUtilizadoCollectionContaRecorrenteClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
        protected new const string MensagemUtilizadoCollectionFornecedorClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes FornecedorClass:";
        protected new const string MensagemUtilizadoCollectionOrcamentoItemClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes OrcamentoItemClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string MensagemUtilizadoCollectionContaReceberClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ContaReceberClass:";
        protected new const string MensagemUtilizadoCollectionRepresentanteClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes RepresentanteClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionContaPagarClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ContaPagarClass:";
        protected new const string MensagemUtilizadoCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro = "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes AgrupadorPostoTrabalhoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade CentroCustoLucroClass está sendo utilizada.";

        #endregion


        public CentroCustoLucroClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        public List<CentroCustoLucroClass> FilhosLucro
        {
            get
            {
                return new List<CentroCustoLucroClass>(this.CollectionCentroCustoLucroClassCentroCustoLucroPai.Where(a => a.Natureza == CentroCustoLucroNatureza.Lucro));
            }

        }

        public List<CentroCustoLucroClass> FilhosCusto
        {
            get
            {
                return new List<CentroCustoLucroClass>(this.CollectionCentroCustoLucroClassCentroCustoLucroPai.Where(a => a.Natureza == CentroCustoLucroNatureza.Custo));
            }

        }

        public List<CentroCustoLucroClass> FilhosNeutro
        {
            get
            {
                return new List<CentroCustoLucroClass>(this.CollectionCentroCustoLucroClassCentroCustoLucroPai.Where(a => a.Natureza == CentroCustoLucroNatureza.Neutro));
            }

        }



        public override string ToString()
        {
            return this.Codigo + " - " + this.Identificacao;
        }

        public string NomeCompleto
        {
            get { return this.Codigo + " - " + this.Identificacao; }
        }
        

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":
                case "NomeCompleto":
                    whereClause += " AND ((UPPER(ccl_codigo || ' - ' ||ccl_identificacao ) like :nome_completo) OR (LOWER (ccl_codigo || ' - ' ||ccl_identificacao ) like :nome_completo)) ";
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nome_completo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = "%" + parametro.Fieldvalue + "%";
                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
               
                case "NomeCompleto":
                    orderByClause += " , (ccl_codigo || ' -' ||ccl_identificacao)  ";
                    return true;
                default:
                    return false;
            }
        }
    }

    public class CentroCustoLucroNodeClass : TreeNode, IEquatable<CentroCustoLucroNodeClass>
    {
        public CentroCustoLucroClass CentroCustoLucro { get; set; }
        private CentroCustoLucroNatureza? tipoSelecao;

        public List<CentroCustoLucroNodeClass> Filhos { get; private set; }

        public string Codigo
        {
            get { return this.CentroCustoLucro.Codigo; }
        }

        public string Identificacao
        {
            get { return this.CentroCustoLucro.Identificacao; }
        }

        public CentroCustoLucroNodeClass(int idCentroCustoLucro, CentroCustoLucroNatureza? tipoSelecao, IWTPostgreNpgsqlConnection singleConnection)
        {
            this.tipoSelecao = tipoSelecao;

            CentroCustoLucro = CentroCustoLucroClass.GetEntidade(idCentroCustoLucro, LoginClass.UsuarioLogado.loggedUser, singleConnection);
            base.Text = this.ToString();
            this.inicializarFilhos();
            //base.Nodes = this.Filhos;
        }

        public CentroCustoLucroNodeClass(CentroCustoLucroClass centroCustoLucro, CentroCustoLucroNatureza? tipoSelecao)
        {
            CentroCustoLucro = centroCustoLucro;
            this.tipoSelecao = tipoSelecao;
            base.Text = this.ToString();

            this.inicializarFilhos();
        }

        private void inicializarFilhos()
        {
            if (tipoSelecao.HasValue)
            {
                switch (tipoSelecao)
                {
                    case CentroCustoLucroNatureza.Neutro:
                        this.Filhos = CentroCustoLucro.FilhosNeutro.Where(a=>a.Ativo).ToList().ConvertAll(a => new CentroCustoLucroNodeClass(a, tipoSelecao));
                        break;
                    case CentroCustoLucroNatureza.Custo:
                        this.Filhos = CentroCustoLucro.FilhosCusto.Where(a => a.Ativo).ToList().ConvertAll(a => new CentroCustoLucroNodeClass(a, tipoSelecao));
                        break;
                    case CentroCustoLucroNatureza.Lucro:
                        this.Filhos = CentroCustoLucro.FilhosLucro.Where(a => a.Ativo).ToList().ConvertAll(a => new CentroCustoLucroNodeClass(a, tipoSelecao));
                        break;
                }
            }
            else
            {
                this.Filhos = CentroCustoLucro.CollectionCentroCustoLucroClassCentroCustoLucroPai.ToList().Where(a => a.Ativo).ToList().ConvertAll(a => new CentroCustoLucroNodeClass(a, tipoSelecao));
            }


            foreach (CentroCustoLucroNodeClass filho in this.Filhos)
            {
                base.Nodes.Add(filho);
            }
            
        }

        public override string ToString()
        {
            return CentroCustoLucro.ToString();
        }

        public bool Equals(CentroCustoLucroNodeClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.CentroCustoLucro, CentroCustoLucro);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (CentroCustoLucroNodeClass)) return false;
            return Equals((CentroCustoLucroNodeClass) obj);
        }

        public override int GetHashCode()
        {
            return (CentroCustoLucro != null ? CentroCustoLucro.GetHashCode() : 0);
        }

        public static bool operator ==(CentroCustoLucroNodeClass left, CentroCustoLucroNodeClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CentroCustoLucroNodeClass left, CentroCustoLucroNodeClass right)
        {
            return !Equals(left, right);
        }
    }


    public class CentroCustoLucroNodeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            CentroCustoLucroNodeClass tx = x as CentroCustoLucroNodeClass;
            CentroCustoLucroNodeClass ty = y as CentroCustoLucroNodeClass;

            if (tx != null)
            {
                if (ty != null)
                {
                    string[] codigoTx = tx.Codigo.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] codigoTy = ty.Codigo.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < codigoTx.Length; i++)
                    {
                        int numeroTx, numeroTy;
                        if (int.TryParse(codigoTx[i], out numeroTx))
                        {
                            if (int.TryParse(codigoTy[i], out numeroTy))
                            {
                                if (numeroTx == numeroTy)
                                {
                                    continue;
                                }
                                else
                                {
                                    return numeroTx.CompareTo(numeroTy);
                                }
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            return 1;
                        }

                    }

                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 1;
            }

        }
    }
}

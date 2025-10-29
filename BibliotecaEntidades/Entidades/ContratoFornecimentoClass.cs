using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;


namespace BibliotecaEntidades.Entidades
{
    public class ContratoFornecimentoClass : ContratoFornecimentoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ContratoFornecimentoClass";
        protected new const string ErroDelete = "Erro ao excluir o ContratoFornecimentoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ContratoFornecimentoClass.";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ContratoFornecimentoClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ContratoFornecimentoClass está sendo utilizada.";

        #endregion


        public ContratoFornecimentoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

 

        protected override void InitClass()
        {
            this.AcsUsuario = UsuarioAtual;
        }

        public bool ObjetoMaterial
        {
            get
            {
                if (this.Material != null)
                {
                    return true;
                }
                else
                {
                    if (this.Material == null && this.Produto == null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            set
            {
                if (!value)
                {
                    this.Material = null;
                }

            }
        }


        public bool ObjetoProduto
        {
            get
            {
                if (this.Produto != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (!value)
                {
                    this.Produto = null;
                }
            }
        }


        public string Item
        {
            get
            {
                if (ObjetoMaterial)
                {
                    return this.Material.ToString();
                }
                else
                {
                    return this.Produto.ToString();
                }
            }
            set
            {

            }
        }

        public string SituacaoAtual
        {
            get { return this.Situacao.ToString(); }
            
        }



        public override string ToString()
        {
            return this.ID.ToString();
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaAtivos":
                    if (parametro.Fieldvalue is bool)
                    {
                        if (Convert.ToBoolean(parametro.Fieldvalue))
                        {
                            whereClause += " AND (cfo_situacao = :BuscaAtivos) ";

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("BuscaAtivos",
                                                                                        NpgsqlDbType.Integer));
                            command.Parameters["BuscaAtivos"].Value = 0;
                            }
                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo bool");
                    }
                    break;

                case "BuscaEncerrados":
                    if (parametro.Fieldvalue is bool)
                    {
                        if (Convert.ToBoolean(parametro.Fieldvalue))
                        {
                            whereClause += " AND (cfo_situacao = :BuscaEncerrados) ";

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("BuscaEncerrados",
                                                                                        NpgsqlDbType.Integer));
                            command.Parameters["BuscaEncerrados"].Value = 1;
                        }
                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo bool");
                    }
                    break;

                case "BuscaCancelados":
                    if (parametro.Fieldvalue is bool)
                    {
                        if (Convert.ToBoolean(parametro.Fieldvalue))
                        {
                            whereClause += " AND (cfo_situacao = :BuscaCancelados) ";

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("BuscaCancelados",
                                                                                        NpgsqlDbType.Integer));
                            command.Parameters["BuscaCancelados"].Value = 2;
                            
                        }
                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecido não é do tipo bool");
                    }
                    break;
                default:
                    return false;
            }
        }

        public void encerraContratosVencidos()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText =
                  "UPDATE  " +
                  "  public.contrato_fornecimento " +
                  "SET " +
                  "  cfo_situacao = 1 " +
                  "WHERE " +
                  "  public.contrato_fornecimento.cfo_termino < now() ";
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encerrar contratos vencidos.\r\n" + e.Message, e);
            }
        }


        public void Cancelar()
        {
            if (this.Situacao != 0)
            {
                throw new Exception("Só é possível cancelar um contrato ativo.");
            }

            this.Situacao = StatusContratoFornecimento.Cancelado;
            this.AcsUsuarioCancelamento = this.UsuarioAtual;
            this.DataCancelamento = Configurations.DataIndependenteClass.GetData();
            this.Save();
        }
    }
}

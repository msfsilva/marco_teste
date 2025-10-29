using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text;
using BibliotecaComunicacaoGAD.api;
using BibliotecaComunicacaoGAD.dto;
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;

namespace BibliotecaEntidades.Entidades 
{
    [Serializable()]
    public class ProgramacaoClass : ProgramacaoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ProgramacaoClass";
        protected new const string ErroDelete = "Erro ao excluir o ProgramacaoClass  ";
        protected new const string ErroSave = "Erro ao salvar o ProgramacaoClass.";
        protected new const string ErroCollectionPedidoItemClassProgramacao = "Erro ao carregar a coleção de PedidoItemClass.";
        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroAcsUsuarioCriacaoObrigatorio = "O campo AcsUsuarioCriacao é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ProgramacaoClass.";
        protected new const string MensagemUtilizadoCollectionPedidoItemClassProgramacao = "A entidade ProgramacaoClass está sendo utilizada nos seguintes PedidoItemClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ProgramacaoClass está sendo utilizada.";

        #endregion

        public ProgramacaoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        public override string ToString()
        {
            return this.Nome.ToString();
        }

        public string SituacaoGadTraduzida
        {
            get
            {
                switch (SituacaoGad)
                {
                    case GadIntegracaoProgramacaoSituacao.Pendente:
                        return "Envio Pendente";
                        break;
                    case GadIntegracaoProgramacaoSituacao.Enviada:
                        return "Enviada";
                        break;
                    case GadIntegracaoProgramacaoSituacao.ErroFinal:
                        return "Erro";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
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

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            if (ID == -1)
            {
                DataCriacao = DataIndependenteClass.GetData();
                AcsUsuarioCriacao = UsuarioAtual;
                SituacaoGad = GadIntegracaoProgramacaoSituacao.Pendente;
            }
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }



        protected override void AcoesExtrasAntesDelete(ref IWTPostgreNpgsqlCommand command)
        {
            while (CollectionPedidoItemClassProgramacao.Count >0 )
            {
                PedidoItemClass pedido = CollectionPedidoItemClassProgramacao[0];
                pedido.Programacao = null;
                if (ProgramacaoGadId.HasValue && pedido.SituacaoGad != GadIntegracaoPedidoSituacao.SemGad)
                {
                    pedido.SituacaoGad = GadIntegracaoPedidoSituacao.Liberado;
                }

                pedido.Save(ref command);

                CollectionPedidoItemClassProgramacao.RemoveAt(0);
            }


            if (ProgramacaoGadId.HasValue)
            {
                ProgramacaoControll.excluirProgramacao((int)ProgramacaoGadId.Value);
            }
        }

        public static ProgramacaoClass CriarProgramacao(List<PedidoItemClass> pedidos, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                
                //Define o nome
                DateTime dataAtual = DataIndependenteClass.GetData();
                int semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(dataAtual, IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO), IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA));

                string nome = "PPS_" + dataAtual.ToString("yy") + semanaTmp.ToString().PadLeft(2, '0') ;
                bool nomeUnico = false;
                while (!nomeUnico)
                {
                    ProgramacaoClass prgAntiga = (ProgramacaoClass) new ProgramacaoClass(usuario, conn).Search(new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("Nome", nome),
                            new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Desc, TipoOrdenacao.Numerica)
                        },
                        limit: 1).FirstOrDefault();

                    if (prgAntiga == null)
                    {
                        nomeUnico = true;
                    }
                    else
                    {
                        string nomeAntiga = prgAntiga.Nome;
                        if (nomeAntiga.Count(a => a == '_') == 1)
                        {
                            //Primeiro
                            nome = nome + "_01";
                        }
                        else
                        {
                            string sequencial = nomeAntiga.Substring(nomeAntiga.LastIndexOf("_", StringComparison.Ordinal)+1);
                            int sequencialNumero;
                            if (!int.TryParse(sequencial, out sequencialNumero))
                            {
                                nome = nome + "_01";
                            }
                            else
                            {
                                sequencialNumero++;
                                nome = nome + "_" + sequencialNumero.ToString().PadLeft(2, '0');
                            }
                        }
                    }
                }
                ProgramacaoClass toRet = new ProgramacaoClass(usuario, conn)
                {
                    Nome = nome,
                    DataCriacao = dataAtual,
                    AcsUsuarioCriacao = usuario,
                    SituacaoGad = GadIntegracaoProgramacaoSituacao.Pendente
                };
                

                foreach (PedidoItemClass pedido in pedidos)
                {
                    pedido.Programacao = toRet;
                    toRet.CollectionPedidoItemClassProgramacao.Add(pedido);
                }

                toRet.Save(ref command);
                

                command.Transaction.Commit();

                
                return toRet;

            }
            catch (Exception)
            {
               command?.Transaction?.Rollback();
                throw;
            }

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades 
{
    public class EstadoClass : EstadoBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EstadoClass";
        protected new const string ErroDelete = "Erro ao excluir o EstadoClass  ";
        protected new const string ErroSave = "Erro ao salvar o EstadoClass.";
        protected new const string ErroCollectionFornecedorClassEstado = "Erro ao carregar a coleção de FornecedorClass.";
        protected new const string ErroCollectionModeloFiscalIcmsClassEstadoSt = "Erro ao carregar a coleção de ModeloFiscalIcmsClass.";
        protected new const string ErroCollectionCidadeClassEstado = "Erro ao carregar a coleção de CidadeClass.";
        protected new const string ErroCollectionModeloFiscalIcmsEstadoClassEstado = "Erro ao carregar a coleção de ModeloFiscalIcmsEstadoClass.";
        protected new const string ErroCollectionClienteClassEstadoCob = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionClienteClassEstado = "Erro ao carregar a coleção de ClienteClass.";
        protected new const string ErroCollectionTransporteClassEstado = "Erro ao carregar a coleção de TransporteClass.";
        protected new const string ErroCollectionTransporteClassEstadoVeiculo = "Erro ao carregar a coleção de TransporteClass.";
        protected new const string ErroSiglaObrigatorio = "O campo Sigla é obrigatório";
        protected new const string ErroSiglaComprimento = "O campo Sigla deve ter no máximo 2 caracteres";
        protected new const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EstadoClass.";
        protected new const string MensagemUtilizadoCollectionFornecedorClassEstado = "A entidade EstadoClass está sendo utilizada nos seguintes FornecedorClass:";
        protected new const string MensagemUtilizadoCollectionModeloFiscalIcmsClassEstadoSt = "A entidade EstadoClass está sendo utilizada nos seguintes ModeloFiscalIcmsClass:";
        protected new const string MensagemUtilizadoCollectionCidadeClassEstado = "A entidade EstadoClass está sendo utilizada nos seguintes CidadeClass:";
        protected new const string MensagemUtilizadoCollectionModeloFiscalIcmsEstadoClassEstado = "A entidade EstadoClass está sendo utilizada nos seguintes ModeloFiscalIcmsEstadoClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassEstadoCob = "A entidade EstadoClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionClienteClassEstado = "A entidade EstadoClass está sendo utilizada nos seguintes ClienteClass:";
        protected new const string MensagemUtilizadoCollectionTransporteClassEstado = "A entidade EstadoClass está sendo utilizada nos seguintes TransporteClass:";
        protected new const string MensagemUtilizadoCollectionTransporteClassEstadoVeiculo = "A entidade EstadoClass está sendo utilizada nos seguintes TransporteClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EstadoClass está sendo utilizada.";

        #endregion


        public EstadoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        public override string ToString()
        {
            return this.Sigla;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "IDDiferente":
                    whereClause += " AND (estado.id_estado <> :id_estado_diferente) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado_diferente", NpgsqlDbType.Integer, parametro.Fieldvalue));
                    return true;
                default:
                    return false;
            }
        }

        public static EstadoClass getEstadoPelaSigla(string sigla, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            EstadoClass toRet = (EstadoClass) new EstadoClass(usuario, conn).Search(new List<SearchParameterClass>() {new SearchParameterClass("SiglaExato", sigla)}).FirstOrDefault();
            if (toRet == null)
            {
                throw new ExcecaoTratada("Não foi possível encontrar o estado com a sigla "+sigla);
            }
            return toRet;
        }
    }
}

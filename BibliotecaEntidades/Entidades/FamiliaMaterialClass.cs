using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class FamiliaMaterialClass : FamiliaMaterialBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do FamiliaMaterialClass";
        protected new const string ErroDelete = "Erro ao excluir o FamiliaMaterialClass  ";
        protected new const string ErroSave = "Erro ao salvar o FamiliaMaterialClass.";
        protected new const string ErroCollectionMaterialClassFamiliaMaterial = "Erro ao carregar a coleção de MaterialClass.";
        protected new const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
        protected new const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do FamiliaMaterialClass.";
        protected new const string MensagemUtilizadoCollectionMaterialClassFamiliaMaterial = "A entidade FamiliaMaterialClass está sendo utilizada nos seguintes MaterialClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade FamiliaMaterialClass está sendo utilizada.";

        #endregion
     private CompradorClass _compradorTemp;

        

        public FamiliaMaterialClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        public bool CompradorDef
        {
            get
            {
                if (this.Comprador != null)
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
                    this._compradorTemp = this.Comprador;
                    this.Comprador = null;
                }
                else
                {
                    this.Comprador = _compradorTemp;
                }
            }
        }






        public override string ToString()
        {
            return this.Codigo;
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
    }
}

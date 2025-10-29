using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class EmissorCertificadoClass:EmissorCertificadoBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do EmissorCertificadoClass";
protected new const string ErroDelete = "Erro ao excluir o EmissorCertificadoClass  ";
protected new const string ErroSave = "Erro ao salvar o EmissorCertificadoClass.";
protected new const string ErroCollectionLoteClassEmissorCertificado = "Erro ao carregar a coleção de LoteClass.";
protected new const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected new const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do EmissorCertificadoClass.";
protected new const string MensagemUtilizadoCollectionLoteClassEmissorCertificado =  "A entidade EmissorCertificadoClass está sendo utilizada nos seguintes LoteClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade EmissorCertificadoClass está sendo utilizada.";
#endregion


        public EmissorCertificadoClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

      

        public override string ToString()
        {
            return this.Identificacao;
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

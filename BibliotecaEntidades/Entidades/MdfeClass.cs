using System;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTPostgreNpgsql;

namespace IWTNFCompleto.BibliotecaEntidades.Entidades 
{ 
    [Serializable()]
     public class MdfeClass:MdfeBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do MdfeClass";
protected new const string ErroDelete = "Erro ao excluir o MdfeClass  ";
protected new const string ErroSave = "Erro ao salvar o MdfeClass.";
protected new const string ErroCollectionMdfeLacreClassMdfe = "Erro ao carregar a coleção de MdfeLacreClass.";
protected new const string ErroCollectionMdfeModalRodoviarioClassMdfe = "Erro ao carregar a coleção de MdfeModalRodoviarioClass.";
protected new const string ErroCollectionMdfeMunicipioCarregamentoClassMdfe = "Erro ao carregar a coleção de MdfeMunicipioCarregamentoClass.";
protected new const string ErroCollectionMdfeMunicipioDescarregamentoClassMdfe = "Erro ao carregar a coleção de MdfeMunicipioDescarregamentoClass.";
protected new const string ErroCollectionMdfeNfeClassMdfe = "Erro ao carregar a coleção de MdfeNfeClass.";
protected new const string ErroCollectionMdfePercursoClassMdfe = "Erro ao carregar a coleção de MdfePercursoClass.";
protected new const string ErroIdObrigatorio = "O campo Id é obrigatório";
protected new const string ErroIdComprimento = "O campo Id deve ter no máximo 48 caracteres";
protected new const string ErroVersaoObrigatorio = "O campo Versao é obrigatório";
protected new const string ErroVersaoComprimento = "O campo Versao deve ter no máximo 10 caracteres";
protected new const string ErroVersaoAplicativoObrigatorio = "O campo VersaoAplicativo é obrigatório";
protected new const string ErroVersaoAplicativoComprimento = "O campo VersaoAplicativo deve ter no máximo 20 caracteres";
protected new const string ErroUfCarregamentoObrigatorio = "O campo UfCarregamento é obrigatório";
protected new const string ErroUfCarregamentoComprimento = "O campo UfCarregamento deve ter no máximo 2 caracteres";
protected new const string ErroUfDescarregamentoObrigatorio = "O campo UfDescarregamento é obrigatório";
protected new const string ErroUfDescarregamentoComprimento = "O campo UfDescarregamento deve ter no máximo 2 caracteres";
protected new const string ErroRazaoEmitenteObrigatorio = "O campo RazaoEmitente é obrigatório";
protected new const string ErroRazaoEmitenteComprimento = "O campo RazaoEmitente deve ter no máximo 60 caracteres";
protected new const string ErroLogradouroEmitenteObrigatorio = "O campo LogradouroEmitente é obrigatório";
protected new const string ErroLogradouroEmitenteComprimento = "O campo LogradouroEmitente deve ter no máximo 60 caracteres";
protected new const string ErroNumeroEnderecoEmitenteObrigatorio = "O campo NumeroEnderecoEmitente é obrigatório";
protected new const string ErroNumeroEnderecoEmitenteComprimento = "O campo NumeroEnderecoEmitente deve ter no máximo 60 caracteres";
protected new const string ErroBairroEmitenteObrigatorio = "O campo BairroEmitente é obrigatório";
protected new const string ErroBairroEmitenteComprimento = "O campo BairroEmitente deve ter no máximo 60 caracteres";
protected new const string ErroMunicipioEmitenteObrigatorio = "O campo MunicipioEmitente é obrigatório";
protected new const string ErroMunicipioEmitenteComprimento = "O campo MunicipioEmitente deve ter no máximo 60 caracteres";
protected new const string ErroUfEmitenteObrigatorio = "O campo UfEmitente é obrigatório";
protected new const string ErroUfEmitenteComprimento = "O campo UfEmitente deve ter no máximo 2 caracteres";
protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected new const string ErroValidate = "Erro ao validar os dados do MdfeClass.";
protected new const string MensagemUtilizadoCollectionMdfeLacreClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeLacreClass:";
protected new const string MensagemUtilizadoCollectionMdfeModalRodoviarioClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeModalRodoviarioClass:";
protected new const string MensagemUtilizadoCollectionMdfeMunicipioCarregamentoClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeMunicipioCarregamentoClass:";
protected new const string MensagemUtilizadoCollectionMdfeMunicipioDescarregamentoClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeMunicipioDescarregamentoClass:";
protected new const string MensagemUtilizadoCollectionMdfeNfeClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfeNfeClass:";
protected new const string MensagemUtilizadoCollectionMdfePercursoClassMdfe =  "A entidade MdfeClass está sendo utilizada nos seguintes MdfePercursoClass:";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeClass está sendo utilizada.";
#endregion

    




public MdfeClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        
       public override string ToString()
       {
           throw new NotImplementedException();
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
             //Validação das regras da receita
             /*
             if (!Regex.Match(this.Versao, MDFeConstantes.ER47).Success) { throw new ExcecaoTratada("Versão do layout inválido."); }
             if (!Regex.Match(this.ChaveAcesso, MDFeConstantes.ER43).Success) { throw new ExcecaoTratada("Chave de acesso gerada inválida."); }
             if (!Regex.Match(this.Serie.ToString(), MDFeConstantes.ER30).Success) { throw new ExcecaoTratada("Série do MDF-e inválida."); }
             if (!Regex.Match(this.Numero.ToString(), MDFeConstantes.ER29).Success) { throw new ExcecaoTratada("Número do MDF-e inválido."); }
             if (!Regex.Match(this.Codigo.ToString(), MDFeConstantes.ER38).Success) { throw new ExcecaoTratada("Código de composição de chave de acesso inválido."); }
             if (!Regex.Match(this.DvChaveAcesso.ToString(), MDFeConstantes.ER39).Success) { throw new ExcecaoTratada("Digito verificador de chave de acesso inválido."); }
             if (!Regex.Match(this.VersaoAplicativo, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Versão do aplicativo emissor inválida."); }
             if (!Regex.Match(this.CnpjEmitente, MDFeConstantes.ER6).Success) { throw new ExcecaoTratada("CNPJ do emitente inválido."); }//TODO informar zeros nao significativos
             if (!Regex.Match(this.IeEmitente, MDFeConstantes.ER28).Success) { throw new ExcecaoTratada("IE do emitente inválido."); }
             if (!Regex.Match(this.RazaoEmitente, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Razão do emitente inválida."); }
             if (!Regex.Match(this.NomeFantasiaEmitente, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Nome fantasia do emitente inválido"); }
             if (!Regex.Match(this.LogradouroEmitente, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Logradouro do emitente inválido."); }
             if (!Regex.Match(this.NumeroEnderecoEmitente, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Número do endereço do emitente inválido."); }
             if (!Regex.Match(this.ComplementoEnderecoEmitente, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Complemento do endereço do emitente inválido."); }
             if (!Regex.Match(this.BairroEmitente, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Bairro do emitente inválido."); }
             if (!Regex.Match(this.CodigoIbgeMunicipioEmitente.ToString(), MDFeConstantes.ER1).Success) { throw new ExcecaoTratada("Código do IBGE do município do emitente inválido."); }
             if (!Regex.Match(this.CepEmitente.ToString(), MDFeConstantes.ER38).Success) { throw new ExcecaoTratada("CEP do emitente inválido."); }//TODO informar zeros nao significativos
             if (!Regex.Match(this.TelefoneEmitente.ToString(), MDFeConstantes.ER1).Success) { throw new ExcecaoTratada("Telefone do emitente inválido."); }
             if (!Regex.Match(this.EmailEmitente, MDFeConstantes.ER1).Success) { throw new ExcecaoTratada("E-mail do emitente inválido."); }
             if (!Regex.Match(this.QtdNfe.ToString(), MDFeConstantes.ER42).Success) { throw new ExcecaoTratada("Quantidade de NFe inválida."); }
             if (!Regex.Match(this.ValorTotalMercadoria.ToString(), MDFeConstantes.ER25).Success) { throw new ExcecaoTratada("Valor total da mercadoria inválida."); }
             if (!Regex.Match(this.PesoBrutoCarga.ToString(), MDFeConstantes.ER19).Success) { throw new ExcecaoTratada("Peso bruto da carga inválido."); }
             if (!Regex.Match(this.InfoAddicionalFisco, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Informação adicional do fisco inválida."); }
             if (!Regex.Match(this.InfoAdicionalContribuinte, MDFeConstantes.ER33).Success) { throw new ExcecaoTratada("Informação adicional do contribuinte inválida."); }
             */

             if (this.ModalidadeTransporte == MDFeModalidadeTransporte.Rodoviario)
             {
                 if (this.CollectionMdfeModalRodoviarioClassMdfe.Count != 1)
                 {
                     throw new ExcecaoTratada("Modal rodoviário inválido.");                    
                 }                 
             }
             else
             {
                 throw new ExcecaoTratada("Modal selecionado não implementado.");
             }
             
             
             
             
             
             
             return true;
         }
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
    }
}

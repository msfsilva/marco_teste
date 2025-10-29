using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades 
{ 
    public class OrcamentoVariavelClass:OrcamentoVariavelBaseClass 
    { 
#region Constantes
protected new const string ErroLoad = "Erro ao carregar os dados do OrcamentoVariavelClass";
protected new const string ErroDelete = "Erro ao excluir o OrcamentoVariavelClass  ";
protected new const string ErroSave = "Erro ao salvar o OrcamentoVariavelClass.";
protected new const string ErroPedidoNumeroObrigatorio = "O campo PedidoNumero é obrigatório";
protected new const string ErroPedidoNumeroComprimento = "O campo PedidoNumero deve ter no máximo 255 caracteres";
protected new const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected new const string ErroValidate = "Erro ao validar os dados do OrcamentoVariavelClass.";
protected new const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoVariavelClass está sendo utilizada.";
#endregion

        
        

        public OrcamentoVariavelClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

 

        public override string Codigo
        {
            get { return base.Codigo; }
            set
            {
                if (value != this.Codigo)
                {
                    this._variavel = null;
                }

                base.Codigo = value;

            }
        }

        private VariavelClass _variavel = null;
        public VariavelClass Variavel
        {
            get
            {
                if (this._variavel == null)
                {

                    VariavelClass search = new VariavelClass(this.UsuarioAtual, this.SingleConnection);
                    _variavel = search.Search(new List<SearchParameterClass>()
                                                  {
                                                      new SearchParameterClass("Nome", this.Codigo)
                                                  }).ConvertAll(a => (VariavelClass)a).FirstOrDefault();

                }
                return this._variavel;
            }
        }
        public string VariavelDescricao
        {
            get { return this.Variavel.Descricao; }
        }


        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
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

       public void LimparID()
       {
           BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
           this.ID = -1;
       }
    }
}

using System; 
using System.Collections.Generic; 
using System.Collections.ObjectModel;
using System.Collections.Specialized; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using System.Security.Cryptography;
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("pedido_item_qualidade","peq")]
     public class PedidoItemQualidadeBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PedidoItemQualidadeClass";
protected const string ErroDelete = "Erro ao excluir o PedidoItemQualidadeClass  ";
protected const string ErroSave = "Erro ao salvar o PedidoItemQualidadeClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
protected const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PedidoItemQualidadeClass.";
protected const string ErroArquivoLoad = "O campo Arquivo não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoItemQualidadeClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _valuePedidoItem;
        [Column("id_pedido_item", "pedido_item", "id_pedido_item")]
       public virtual BibliotecaEntidades.Entidades.PedidoItemClass PedidoItem
        { 
           get {                 return this._valuePedidoItem; } 
           set 
           { 
                if (this._valuePedidoItem == value)return;
                 this._valuePedidoItem = value; 
           } 
       } 

       protected string _arquivoOriginal= null;
        private string _arquivoOriginalCommited= null;
        private bool _ArquivoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool ArquivoLoaded 
       { 
            get {                     return _ArquivoLoaded; } 
           set 
           { 
                this._ArquivoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueArquivo;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("peq_arquivo")]
        public virtual byte[] Arquivo
         { 
            get { 
                   if (!this.ArquivoLoaded) 
                   {
                       this.LoadArquivo();
                   }
                   return this._valueArquivo; } 
            set 
            { 
                ArquivoLoaded = true; 
                if (this._valueArquivo == value)return;
                 this._valueArquivo = value; 
            } 
        } 

       protected string _descricaoArquivoOriginal{get;private set;}
       private string _descricaoArquivoOriginalCommited{get; set;}
        private string _valueDescricaoArquivo;
         [Column("peq_descricao_arquivo")]
        public virtual string DescricaoArquivo
         { 
            get { return this._valueDescricaoArquivo; } 
            set 
            { 
                if (this._valueDescricaoArquivo == value)return;
                 this._valueDescricaoArquivo = value; 
            } 
        } 

       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("peq_nome_arquivo")]
        public virtual string NomeArquivo
         { 
            get { return this._valueNomeArquivo; } 
            set 
            { 
                if (this._valueNomeArquivo == value)return;
                 this._valueNomeArquivo = value; 
            } 
        } 

        public PedidoItemQualidadeBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static PedidoItemQualidadeClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PedidoItemQualidadeClass) GetEntity(typeof(PedidoItemQualidadeClass),id,usuarioAtual,connection, operacao);
        }
private void LoadArquivo()
        {
            try
            {
                if (this.ID == -1)
                {

                    ArquivoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT peq_arquivo FROM pedido_item_qualidade WHERE id_pedido_item_qualidade = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueArquivo = (byte[]) tmp;
                }
                if (this._valueArquivo != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _arquivoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                     }
                  } 
                  else 
                  { 
                        _arquivoOriginal = null ;
                  } 
                ArquivoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroArquivoLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NomeArquivo))
                {
                    throw new Exception(ErroNomeArquivoObrigatorio);
                }
                if (NomeArquivo.Length >255)
                {
                    throw new Exception( ErroNomeArquivoComprimento);
                }
                if (Arquivo==null)
                {
                    throw new Exception(ErroArquivoObrigatorio);
                }
                if ( _valuePedidoItem == null)
                {
                    throw new Exception(ErroPedidoItemObrigatorio);
                }

                return this.ValidateDataCustom(ref command);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception(ErroValidate+"\r\n" + e.Message, e);
            }
        } 
         protected virtual bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
       protected override void internalDelete(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                AcoesExtrasAntesDelete(ref command);
                command.CommandText =
                    "DELETE FROM  " +
                    "  public.pedido_item_qualidade  " +
                    "WHERE " +
                    "  id_pedido_item_qualidade = :id";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                command.ExecuteNonQuery();
                AcoesExtrasDepoisDelete(ref command);
            }
            catch (Exception e)
            {
                throw new Exception(ErroDelete+"\r\n" + e.Message, e);
            }
        } 
       protected virtual void AcoesExtrasAntesDelete(ref IWTPostgreNpgsqlCommand command)
        {
        }
       protected virtual void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
        }
        protected override void internalSave(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID != -1)
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.pedido_item_qualidade   " +
                        "SET  " + 
                        "  id_pedido_item = :id_pedido_item, " + 
                        "  peq_arquivo = :peq_arquivo, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  peq_descricao_arquivo = :peq_descricao_arquivo, " + 
                        "  peq_nome_arquivo = :peq_nome_arquivo "+
                        "WHERE  " +
                        "  id_pedido_item_qualidade = :id " +
                        "RETURNING id_pedido_item_qualidade;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pedido_item_qualidade " +
                        "( " +
                        "  id_pedido_item , " + 
                        "  peq_arquivo , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  peq_descricao_arquivo , " + 
                        "  peq_nome_arquivo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_pedido_item , " + 
                        "  :peq_arquivo , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :peq_descricao_arquivo , " + 
                        "  :peq_nome_arquivo  "+
                        ")RETURNING id_pedido_item_qualidade;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItem==null ? (object) DBNull.Value : this.PedidoItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peq_arquivo", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Arquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peq_descricao_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peq_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;

 
                 bool inserting = this.ID == -1; 
                this.ID = Convert.ToInt32(command.ExecuteScalar()); 
                this.InternalSaveCustom(ref command); 
                this.AcoesExtrasAposSalvar(ref command, inserting); 
            } 
            catch (Exception e) 
            { 
                throw new Exception(ErroSave+"\r\n" + e.Message, e); 
            } 
        } 

        protected virtual void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
  public override bool Utilizado(out string mensagemUtilizado)
        {
            try
            {
                mensagemUtilizado = "";
                if (this.ID == -1)
                {
                    return false;
                } 
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(ErroUtilizado+"\r\n" + e.Message, e);
            }
        } 
       public override string ToString()
        {
           throw new NotImplementedException();
        }
        public static PedidoItemQualidadeClass CopiarEntidade(PedidoItemQualidadeClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PedidoItemQualidadeClass toRet = new PedidoItemQualidadeClass(usuario,conn);
 toRet.PedidoItem= entidadeCopiar.PedidoItem;
 toRet.Arquivo= entidadeCopiar.Arquivo;
 toRet.DescricaoArquivo= entidadeCopiar.DescricaoArquivo;
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;

            return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao copiar a entidade+\r\n" + e.Message, e);
            }
        } 
        protected override void  SalvaValoresOriginais()
        {
            try
            {
       _pedidoItemOriginal = PedidoItem;
       _pedidoItemOriginalCommited = _pedidoItemOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _descricaoArquivoOriginal = DescricaoArquivo;
       _descricaoArquivoOriginalCommited = _descricaoArquivoOriginal;
       _nomeArquivoOriginal = NomeArquivo;
       _nomeArquivoOriginalCommited = _nomeArquivoOriginal;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
        } 
        protected override void  SalvaValoresCommited()
        {
            try
            {
       _pedidoItemOriginalCommited = PedidoItem;
       _versionOriginalCommited = Version;
       _descricaoArquivoOriginalCommited = DescricaoArquivo;
       _nomeArquivoOriginalCommited = NomeArquivo;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
        } 
        protected override void CommitChangesEntidade()
        {
            try
            {
               SalvaValoresOriginais();
               if (ArquivoLoaded)
               {
                  if(this._valueArquivo != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _arquivoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                     }
                  } 
                  else 
                  { 
                        _arquivoOriginal = null ;
                  } 
               }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
        } 
        protected override void RollbackChangesEntidade()
        {
            bool disableEventosRemocaoVetoresAntigo = DisableEventosRemocaoVetores ;
            DisableEventosRemocaoVetores = true;
            try
            {
               PedidoItem=_pedidoItemOriginal;
               _pedidoItemOriginalCommited=_pedidoItemOriginal;
               ArquivoLoaded = false;
               this._arquivoOriginal = null;
               this._arquivoOriginalCommited = null;
               this._valueArquivo = null;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               DescricaoArquivo=_descricaoArquivoOriginal;
               _descricaoArquivoOriginalCommited=_descricaoArquivoOriginal;
               NomeArquivo=_nomeArquivoOriginal;
               _nomeArquivoOriginalCommited=_nomeArquivoOriginal;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
            finally
            {
               DisableEventosRemocaoVetores = disableEventosRemocaoVetoresAntigo ;
            }
        } 
        protected override bool DirtyCollections()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
               bool tempRet = false;
               return false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das collections +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override bool DirtyPropriedadesNativas()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
            bool dirty = false;
      if (dirty) return true;
       if (_pedidoItemOriginal!=null)
       {
          dirty = !_pedidoItemOriginal.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
       }
      if (dirty) return true;
               if (ArquivoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpArquivo ;
                      if (this._valueArquivo == null) 
                      { 
                         tmpArquivo = null; 
                      } 
                      else 
                      { 
                         tmpArquivo = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                      } 
                       dirty = _arquivoOriginal != tmpArquivo;
                   }
               }
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _descricaoArquivoOriginal != DescricaoArquivo;
      if (dirty) return true;
       dirty = _nomeArquivoOriginal != NomeArquivo;

               return dirty;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das propriedades nativas +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override bool DirtyCollectionsCommited()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
               bool tempRet = false;
               return false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das collections +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override bool DirtyPropriedadesNativasCommited()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
            bool dirty = false;
      if (dirty) return true;
       if (_pedidoItemOriginalCommited!=null)
       {
          dirty = !_pedidoItemOriginalCommited.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
       }
      if (dirty) return true;
               if (ArquivoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpArquivo ;
                      if (this._valueArquivo == null) 
                      { 
                         tmpArquivo = null; 
                      } 
                      else 
                      { 
                         tmpArquivo = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                      } 
                       dirty = _arquivoOriginalCommited != tmpArquivo;
                   }
               }
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _descricaoArquivoOriginalCommited != DescricaoArquivo;
      if (dirty) return true;
       dirty = _nomeArquivoOriginalCommited != NomeArquivo;

               return dirty;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das propriedades nativas +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override void SaveCollections(ref IWTPostgreNpgsqlCommand command)
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar as collections \r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        public override object GetValorPropriedade(string nomePropriedade)
        {
          switch (nomePropriedade) 
          {
             case "ID":
                return this.ID;
             case "UltimaRevisao":
                return this.UltimaRevisao;
             case "UltimaRevisaoData":
                return this.UltimaRevisaoData;
             case "UltimaRevisaoUsuario":
                return this.UltimaRevisaoUsuario;
             case "PedidoItem":
                return this.PedidoItem;
             case "Arquivo":
                return this.Arquivo;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "DescricaoArquivo":
                return this.DescricaoArquivo;
             case "NomeArquivo":
                return this.NomeArquivo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (PedidoItem!=null)
                PedidoItem.ChangeSingleConnection(newConnection);
        }
        protected override List<AbstractEntity> NewSearch(List<SearchParameterClass> parametros, bool somenteCount,out int qtdRegistros, bool utilizarOr = false, int? offset = null, int? limit = null, bool utilizarBuffer = true, Guid? operacao = null)
        {
            IWTPostgreNpgsqlCommand command = null; 
            bool transacaoInterna = false; 
            try
            {
               List<AbstractEntity> toRet = new List<AbstractEntity>();
               command = this.SingleConnection.CreateCommand();
               if (!command.Connection.IsInTransaction())
               {
                  command.Transaction = command.Connection.BeginTransaction();
                  transacaoInterna = true;
               }
               command.CommandText = "SELECT "  ;
               if (somenteCount)
               {
                  command.CommandText += " COUNT(pedido_item_qualidade.id_pedido_item_qualidade) " ;
               }
               else
               {
               command.CommandText += "pedido_item_qualidade.id_pedido_item_qualidade, " ;
               command.CommandText += "pedido_item_qualidade.id_pedido_item, " ;
               command.CommandText += "pedido_item_qualidade.version, " ;
               command.CommandText += "pedido_item_qualidade.entity_uid, " ;
               command.CommandText += "pedido_item_qualidade.peq_descricao_arquivo, " ;
               command.CommandText += "pedido_item_qualidade.peq_nome_arquivo " ;
               }
               command.CommandText += " FROM  pedido_item_qualidade ";
               string whereClause = "";
               string orderByClause = "";
               command.Parameters.Clear();
               List < SearchParameterClass > parametrosTmp = new List<SearchParameterClass>();
               for (int i = 0; i < parametros.Count; i++)
               {
                   SearchParameterClass parametro = parametros[i];
                   int iUltimo = i;
                   for (int j = i + 1; j < parametros.Count; j++)
                   {
                       if (parametro.FieldName == parametros[j].FieldName)
                       {
                           if (parametro.Operacao == parametros[j].Operacao)
                           {
                               iUltimo = j;
                           }
                       }
                   }
                   parametrosTmp.Add(parametros[iUltimo]);
                   if (iUltimo != i)
                   {
                       parametros.RemoveAt(iUltimo);
                   }
               }
               parametros = parametrosTmp; 
               foreach (SearchParameterClass parametro in parametros) 
               {
                  if (parametro.Operacao == SearchOperacao.SomenteOrdenacao) 
                  {
                     if (OrderByCustom(parametro, ref orderByClause,parametro.Ordenacao, ref command ))
                     {
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData")
                     {
                        orderByClause += " , peq_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(peq_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = pedido_item_qualidade.id_acs_usuario_ultima_revisao ";
                        continue;
                     }
                     if (parametro.FieldName.Contains("_"))
                     {
                        if (parametro.TipoOrdenacao == TipoOrdenacao.String)
                        {
                           orderByClause += " ,  UPPER(" + parametro.FieldName + ") " + parametro.Ordenacao.ToString().ToUpper();
                        }
                        else
                        {
                            orderByClause += " ,  " + parametro.FieldName + " " + parametro.Ordenacao.ToString();
                        }
                        continue;
                     }
                     switch(parametro.FieldName)
                     {
                     case "id_pedido_item_qualidade":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_qualidade.id_pedido_item_qualidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_qualidade.id_pedido_item_qualidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item":
                     case "PedidoItem":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItem ON pedido_item_PedidoItem.id_pedido_item = pedido_item_qualidade.id_pedido_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_PedidoItem.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_PedidoItem.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "peq_arquivo":
                     case "Arquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_qualidade.peq_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_qualidade.peq_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "version":
                     case "Version":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_qualidade.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_qualidade.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_qualidade.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_qualidade.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "peq_descricao_arquivo":
                     case "DescricaoArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_qualidade.peq_descricao_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_qualidade.peq_descricao_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "peq_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_qualidade.peq_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_qualidade.peq_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                        default:
                           throw new Exception("Parâmetro de ordenação não encontrado: " + parametro.FieldName);
                     }
                  }
                  else
                  {
                     if (SearchCustom(parametro, ref whereClause, ref command ))
                     {
                        continue;
                     }
                     if (parametro.FieldName == "BuscaCompleta")
                     {
                        whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(FALSE ";
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(pedido_item_qualidade.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_qualidade.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("peq_descricao_arquivo")) 
                        {
                           whereClause += " OR UPPER(pedido_item_qualidade.peq_descricao_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_qualidade.peq_descricao_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("peq_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(pedido_item_qualidade.peq_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item_qualidade.peq_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_pedido_item_qualidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.id_pedido_item_qualidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.id_pedido_item_qualidade = :pedido_item_qualidade_ID_9562 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_ID_9562", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoItem" || parametro.FieldName == "id_pedido_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.id_pedido_item = :pedido_item_qualidade_PedidoItem_916 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_PedidoItem_916", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Arquivo" || parametro.FieldName == "peq_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.peq_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.peq_arquivo = :pedido_item_qualidade_Arquivo_4319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_Arquivo_4319", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Version" || parametro.FieldName == "version")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.version = :pedido_item_qualidade_Version_2183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_Version_2183", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntityUid" || parametro.FieldName == "entity_uid")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.entity_uid LIKE :pedido_item_qualidade_EntityUid_7313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_EntityUid_7313", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoArquivo" || parametro.FieldName == "peq_descricao_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.peq_descricao_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.peq_descricao_arquivo LIKE :pedido_item_qualidade_DescricaoArquivo_3882 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_DescricaoArquivo_3882", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "peq_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.peq_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.peq_nome_arquivo LIKE :pedido_item_qualidade_NomeArquivo_2120 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_NomeArquivo_2120", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntityUidExato" || parametro.FieldName == "EntityUidExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.entity_uid LIKE :pedido_item_qualidade_EntityUid_496 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_EntityUid_496", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoArquivoExato" || parametro.FieldName == "DescricaoArquivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.peq_descricao_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.peq_descricao_arquivo LIKE :pedido_item_qualidade_DescricaoArquivo_7319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_DescricaoArquivo_7319", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivoExato" || parametro.FieldName == "NomeArquivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item_qualidade.peq_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item_qualidade.peq_nome_arquivo LIKE :pedido_item_qualidade_NomeArquivo_4449 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_qualidade_NomeArquivo_4449", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                  throw new Exception("Parâmetro de busca não encontrado: " + parametro.FieldName);
                  }
               }
               if (whereClause.Length > 0)
               {
                  command.CommandText += " WHERE " + whereClause.Substring(5);
               }
               if (!somenteCount && orderByClause.Length > 0)
               {
                  command.CommandText += " ORDER BY " + orderByClause.Substring(2);
               }
               if (!somenteCount && limit.HasValue)
               {
                  command.CommandText += " LIMIT " + limit.Value + " ";
               }
               if (!somenteCount && offset.HasValue)
               {
                  command.CommandText += " OFFSET " + offset.Value + " ";
               }
               if (somenteCount)
               {
                  object tmp = command.ExecuteScalar();
                  if (tmp != DBNull.Value)
                  {
                     qtdRegistros = Convert.ToInt32(tmp);
                  }
                  else
                  {
                     qtdRegistros = 0;
                  }
                  if (transacaoInterna)
                  {
                     command.Transaction.Commit();
                  }
                  return null;
               }
               qtdRegistros = 0;
               if (PararThread()) 
               { 
                   return toRet; 
               } 
               IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
               while (read.Read())
               {
                  if (PararThread()) 
                  { 
                      break; 
                  } 
                  qtdRegistros++;
                  PedidoItemQualidadeClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PedidoItemQualidadeClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PedidoItemQualidadeClass), Convert.ToInt32(read["id_pedido_item_qualidade"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PedidoItemQualidadeClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_pedido_item_qualidade"]);
                     if (read["id_pedido_item"] != DBNull.Value)
                     {
                        entidade.PedidoItem = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItem = null ;
                     }
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.DescricaoArquivo = (read["peq_descricao_arquivo"] != DBNull.Value ? read["peq_descricao_arquivo"].ToString() : null);
                     entidade.NomeArquivo = (read["peq_nome_arquivo"] != DBNull.Value ? read["peq_nome_arquivo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PedidoItemQualidadeClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
                  }
                  toRet.Add(entidade);

               }
               read.Close();
               if (transacaoInterna)
               {
                  command.Transaction.Commit();
               }
               return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o new search\r\n" + e.Message, e);
            }
        } 
    }
}

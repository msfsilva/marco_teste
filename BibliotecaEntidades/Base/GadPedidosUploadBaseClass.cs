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
     [Table("gad_pedidos_upload","gpu")]
     public class GadPedidosUploadBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do GadPedidosUploadClass";
protected const string ErroDelete = "Erro ao excluir o GadPedidosUploadClass  ";
protected const string ErroSave = "Erro ao salvar o GadPedidosUploadClass.";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do GadPedidosUploadClass.";
protected const string ErroArquivoLoad = "O campo Arquivo não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade GadPedidosUploadClass está sendo utilizada.";
#endregion
       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("gpu_nome_arquivo")]
        public virtual string NomeArquivo
         { 
            get { return this._valueNomeArquivo; } 
            set 
            { 
                if (this._valueNomeArquivo == value)return;
                 this._valueNomeArquivo = value; 
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
         [Column("gpu_arquivo")]
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

       protected int _tentativasOriginal{get;private set;}
       private int _tentativasOriginalCommited{get; set;}
        private int _valueTentativas;
         [Column("gpu_tentativas")]
        public virtual int Tentativas
         { 
            get { return this._valueTentativas; } 
            set 
            { 
                if (this._valueTentativas == value)return;
                 this._valueTentativas = value; 
            } 
        } 

       protected string _erroOriginal{get;private set;}
       private string _erroOriginalCommited{get; set;}
        private string _valueErro;
         [Column("gpu_erro")]
        public virtual string Erro
         { 
            get { return this._valueErro; } 
            set 
            { 
                if (this._valueErro == value)return;
                 this._valueErro = value; 
            } 
        } 

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

        public GadPedidosUploadBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tentativas = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static GadPedidosUploadClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (GadPedidosUploadClass) GetEntity(typeof(GadPedidosUploadClass),id,usuarioAtual,connection, operacao);
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
                command.CommandText = "SELECT gpu_arquivo FROM gad_pedidos_upload WHERE id_gad_pedidos_upload = :id ";
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
                    "  public.gad_pedidos_upload  " +
                    "WHERE " +
                    "  id_gad_pedidos_upload = :id";
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
                        "  public.gad_pedidos_upload   " +
                        "SET  " + 
                        "  gpu_nome_arquivo = :gpu_nome_arquivo, " + 
                        "  gpu_arquivo = :gpu_arquivo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  gpu_tentativas = :gpu_tentativas, " + 
                        "  gpu_erro = :gpu_erro, " + 
                        "  id_pedido_item = :id_pedido_item "+
                        "WHERE  " +
                        "  id_gad_pedidos_upload = :id " +
                        "RETURNING id_gad_pedidos_upload;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.gad_pedidos_upload " +
                        "( " +
                        "  gpu_nome_arquivo , " + 
                        "  gpu_arquivo , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  gpu_tentativas , " + 
                        "  gpu_erro , " + 
                        "  id_pedido_item  "+
                        ")  " +
                        "VALUES ( " +
                        "  :gpu_nome_arquivo , " + 
                        "  :gpu_arquivo , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :gpu_tentativas , " + 
                        "  :gpu_erro , " + 
                        "  :id_pedido_item  "+
                        ")RETURNING id_gad_pedidos_upload;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gpu_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gpu_arquivo", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Arquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gpu_tentativas", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tentativas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gpu_erro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Erro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItem==null ? (object) DBNull.Value : this.PedidoItem.ID;

 
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
        public static GadPedidosUploadClass CopiarEntidade(GadPedidosUploadClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               GadPedidosUploadClass toRet = new GadPedidosUploadClass(usuario,conn);
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;
 toRet.Arquivo= entidadeCopiar.Arquivo;
 toRet.Tentativas= entidadeCopiar.Tentativas;
 toRet.Erro= entidadeCopiar.Erro;
 toRet.PedidoItem= entidadeCopiar.PedidoItem;

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
       _nomeArquivoOriginal = NomeArquivo;
       _nomeArquivoOriginalCommited = _nomeArquivoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tentativasOriginal = Tentativas;
       _tentativasOriginalCommited = _tentativasOriginal;
       _erroOriginal = Erro;
       _erroOriginalCommited = _erroOriginal;
       _pedidoItemOriginal = PedidoItem;
       _pedidoItemOriginalCommited = _pedidoItemOriginal;

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
       _nomeArquivoOriginalCommited = NomeArquivo;
       _versionOriginalCommited = Version;
       _tentativasOriginalCommited = Tentativas;
       _erroOriginalCommited = Erro;
       _pedidoItemOriginalCommited = PedidoItem;

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
               NomeArquivo=_nomeArquivoOriginal;
               _nomeArquivoOriginalCommited=_nomeArquivoOriginal;
               ArquivoLoaded = false;
               this._arquivoOriginal = null;
               this._arquivoOriginalCommited = null;
               this._valueArquivo = null;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Tentativas=_tentativasOriginal;
               _tentativasOriginalCommited=_tentativasOriginal;
               Erro=_erroOriginal;
               _erroOriginalCommited=_erroOriginal;
               PedidoItem=_pedidoItemOriginal;
               _pedidoItemOriginalCommited=_pedidoItemOriginal;

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
       dirty = _nomeArquivoOriginal != NomeArquivo;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tentativasOriginal != Tentativas;
      if (dirty) return true;
       dirty = _erroOriginal != Erro;
      if (dirty) return true;
       if (_pedidoItemOriginal!=null)
       {
          dirty = !_pedidoItemOriginal.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
       }

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
       dirty = _nomeArquivoOriginalCommited != NomeArquivo;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tentativasOriginalCommited != Tentativas;
      if (dirty) return true;
       dirty = _erroOriginalCommited != Erro;
      if (dirty) return true;
       if (_pedidoItemOriginalCommited!=null)
       {
          dirty = !_pedidoItemOriginalCommited.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
       }

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
             case "NomeArquivo":
                return this.NomeArquivo;
             case "Arquivo":
                return this.Arquivo;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Tentativas":
                return this.Tentativas;
             case "Erro":
                return this.Erro;
             case "PedidoItem":
                return this.PedidoItem;
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
                  command.CommandText += " COUNT(gad_pedidos_upload.id_gad_pedidos_upload) " ;
               }
               else
               {
               command.CommandText += "gad_pedidos_upload.id_gad_pedidos_upload, " ;
               command.CommandText += "gad_pedidos_upload.gpu_nome_arquivo, " ;
               command.CommandText += "gad_pedidos_upload.entity_uid, " ;
               command.CommandText += "gad_pedidos_upload.version, " ;
               command.CommandText += "gad_pedidos_upload.gpu_tentativas, " ;
               command.CommandText += "gad_pedidos_upload.gpu_erro, " ;
               command.CommandText += "gad_pedidos_upload.id_pedido_item " ;
               }
               command.CommandText += " FROM  gad_pedidos_upload ";
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
                        orderByClause += " , gpu_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(gpu_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = gad_pedidos_upload.id_acs_usuario_ultima_revisao ";
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
                     case "id_gad_pedidos_upload":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , gad_pedidos_upload.id_gad_pedidos_upload " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(gad_pedidos_upload.id_gad_pedidos_upload) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "gpu_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , gad_pedidos_upload.gpu_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(gad_pedidos_upload.gpu_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "gpu_arquivo":
                     case "Arquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , gad_pedidos_upload.gpu_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(gad_pedidos_upload.gpu_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , gad_pedidos_upload.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(gad_pedidos_upload.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , gad_pedidos_upload.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(gad_pedidos_upload.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "gpu_tentativas":
                     case "Tentativas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , gad_pedidos_upload.gpu_tentativas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(gad_pedidos_upload.gpu_tentativas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "gpu_erro":
                     case "Erro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , gad_pedidos_upload.gpu_erro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(gad_pedidos_upload.gpu_erro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item":
                     case "PedidoItem":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItem ON pedido_item_PedidoItem.id_pedido_item = gad_pedidos_upload.id_pedido_item ";                     switch (parametro.TipoOrdenacao)
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("gpu_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(gad_pedidos_upload.gpu_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(gad_pedidos_upload.gpu_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(gad_pedidos_upload.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(gad_pedidos_upload.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("gpu_erro")) 
                        {
                           whereClause += " OR UPPER(gad_pedidos_upload.gpu_erro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(gad_pedidos_upload.gpu_erro) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_gad_pedidos_upload")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  gad_pedidos_upload.id_gad_pedidos_upload IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.id_gad_pedidos_upload = :gad_pedidos_upload_ID_2779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_ID_2779", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "gpu_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  gad_pedidos_upload.gpu_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.gpu_nome_arquivo LIKE :gad_pedidos_upload_NomeArquivo_4867 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_NomeArquivo_4867", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Arquivo" || parametro.FieldName == "gpu_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  gad_pedidos_upload.gpu_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.gpu_arquivo = :gad_pedidos_upload_Arquivo_5640 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_Arquivo_5640", NpgsqlDbType.Bytea, parametro.Fieldvalue));
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
                         whereClause += "  gad_pedidos_upload.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.entity_uid LIKE :gad_pedidos_upload_EntityUid_3460 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_EntityUid_3460", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  gad_pedidos_upload.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.version = :gad_pedidos_upload_Version_3883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_Version_3883", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tentativas" || parametro.FieldName == "gpu_tentativas")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  gad_pedidos_upload.gpu_tentativas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.gpu_tentativas = :gad_pedidos_upload_Tentativas_5123 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_Tentativas_5123", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Erro" || parametro.FieldName == "gpu_erro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  gad_pedidos_upload.gpu_erro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.gpu_erro LIKE :gad_pedidos_upload_Erro_5883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_Erro_5883", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  gad_pedidos_upload.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.id_pedido_item = :gad_pedidos_upload_PedidoItem_5210 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_PedidoItem_5210", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  gad_pedidos_upload.gpu_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.gpu_nome_arquivo LIKE :gad_pedidos_upload_NomeArquivo_8482 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_NomeArquivo_8482", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  gad_pedidos_upload.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.entity_uid LIKE :gad_pedidos_upload_EntityUid_1829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_EntityUid_1829", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ErroExato" || parametro.FieldName == "ErroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  gad_pedidos_upload.gpu_erro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  gad_pedidos_upload.gpu_erro LIKE :gad_pedidos_upload_Erro_5217 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gad_pedidos_upload_Erro_5217", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  GadPedidosUploadClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (GadPedidosUploadClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(GadPedidosUploadClass), Convert.ToInt32(read["id_gad_pedidos_upload"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new GadPedidosUploadClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_gad_pedidos_upload"]);
                     entidade.NomeArquivo = (read["gpu_nome_arquivo"] != DBNull.Value ? read["gpu_nome_arquivo"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Tentativas = (int)read["gpu_tentativas"];
                     entidade.Erro = (read["gpu_erro"] != DBNull.Value ? read["gpu_erro"].ToString() : null);
                     if (read["id_pedido_item"] != DBNull.Value)
                     {
                        entidade.PedidoItem = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItem = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (GadPedidosUploadClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

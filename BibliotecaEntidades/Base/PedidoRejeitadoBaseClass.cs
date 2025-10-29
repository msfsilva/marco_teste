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
     [Table("pedido_rejeitado","per")]
     public class PedidoRejeitadoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PedidoRejeitadoClass";
protected const string ErroDelete = "Erro ao excluir o PedidoRejeitadoClass  ";
protected const string ErroSave = "Erro ao salvar o PedidoRejeitadoClass.";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected const string ErroMotivoRejeicaoObrigatorio = "O campo MotivoRejeicao é obrigatório";
protected const string ErroMotivoRejeicaoComprimento = "O campo MotivoRejeicao deve ter no máximo 255 caracteres";
protected const string ErroModuloImportadorObrigatorio = "O campo ModuloImportador é obrigatório";
protected const string ErroModuloImportadorComprimento = "O campo ModuloImportador deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PedidoRejeitadoClass.";
protected const string ErroArquivoLoad = "O campo Arquivo não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoRejeitadoClass está sendo utilizada.";
#endregion
       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("per_nome_arquivo")]
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
         [Column("per_arquivo")]
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

       protected string _motivoRejeicaoOriginal{get;private set;}
       private string _motivoRejeicaoOriginalCommited{get; set;}
        private string _valueMotivoRejeicao;
         [Column("per_motivo_rejeicao")]
        public virtual string MotivoRejeicao
         { 
            get { return this._valueMotivoRejeicao; } 
            set 
            { 
                if (this._valueMotivoRejeicao == value)return;
                 this._valueMotivoRejeicao = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("per_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
            } 
        } 

       protected string _moduloImportadorOriginal{get;private set;}
       private string _moduloImportadorOriginalCommited{get; set;}
        private string _valueModuloImportador;
         [Column("per_modulo_importador")]
        public virtual string ModuloImportador
         { 
            get { return this._valueModuloImportador; } 
            set 
            { 
                if (this._valueModuloImportador == value)return;
                 this._valueModuloImportador = value; 
            } 
        } 

       protected DateTime _dataEntradaOriginal{get;private set;}
       private DateTime _dataEntradaOriginalCommited{get; set;}
        private DateTime _valueDataEntrada;
         [Column("per_data_entrada")]
        public virtual DateTime DataEntrada
         { 
            get { return this._valueDataEntrada; } 
            set 
            { 
                if (this._valueDataEntrada == value)return;
                 this._valueDataEntrada = value; 
            } 
        } 

       protected DateTime _dataUltimoProcessamentoOriginal{get;private set;}
       private DateTime _dataUltimoProcessamentoOriginalCommited{get; set;}
        private DateTime _valueDataUltimoProcessamento;
         [Column("per_data_ultimo_processamento")]
        public virtual DateTime DataUltimoProcessamento
         { 
            get { return this._valueDataUltimoProcessamento; } 
            set 
            { 
                if (this._valueDataUltimoProcessamento == value)return;
                 this._valueDataUltimoProcessamento = value; 
            } 
        } 

       protected string _tipoArquivoOriginal{get;private set;}
       private string _tipoArquivoOriginalCommited{get; set;}
        private string _valueTipoArquivo;
         [Column("per_tipo_arquivo")]
        public virtual string TipoArquivo
         { 
            get { return this._valueTipoArquivo; } 
            set 
            { 
                if (this._valueTipoArquivo == value)return;
                 this._valueTipoArquivo = value; 
            } 
        } 

        public PedidoRejeitadoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static PedidoRejeitadoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PedidoRejeitadoClass) GetEntity(typeof(PedidoRejeitadoClass),id,usuarioAtual,connection, operacao);
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
                command.CommandText = "SELECT per_arquivo FROM pedido_rejeitado WHERE id_pedido_rejeitado = :id ";
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
                if (string.IsNullOrEmpty(MotivoRejeicao))
                {
                    throw new Exception(ErroMotivoRejeicaoObrigatorio);
                }
                if (MotivoRejeicao.Length >255)
                {
                    throw new Exception( ErroMotivoRejeicaoComprimento);
                }
                if (string.IsNullOrEmpty(ModuloImportador))
                {
                    throw new Exception(ErroModuloImportadorObrigatorio);
                }
                if (ModuloImportador.Length >255)
                {
                    throw new Exception( ErroModuloImportadorComprimento);
                }
                if (Arquivo==null)
                {
                    throw new Exception(ErroArquivoObrigatorio);
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
                    "  public.pedido_rejeitado  " +
                    "WHERE " +
                    "  id_pedido_rejeitado = :id";
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
                        "  public.pedido_rejeitado   " +
                        "SET  " + 
                        "  per_nome_arquivo = :per_nome_arquivo, " + 
                        "  per_arquivo = :per_arquivo, " + 
                        "  per_motivo_rejeicao = :per_motivo_rejeicao, " + 
                        "  per_observacao = :per_observacao, " + 
                        "  per_modulo_importador = :per_modulo_importador, " + 
                        "  per_data_entrada = :per_data_entrada, " + 
                        "  per_data_ultimo_processamento = :per_data_ultimo_processamento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  per_tipo_arquivo = :per_tipo_arquivo "+
                        "WHERE  " +
                        "  id_pedido_rejeitado = :id " +
                        "RETURNING id_pedido_rejeitado;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pedido_rejeitado " +
                        "( " +
                        "  per_nome_arquivo , " + 
                        "  per_arquivo , " + 
                        "  per_motivo_rejeicao , " + 
                        "  per_observacao , " + 
                        "  per_modulo_importador , " + 
                        "  per_data_entrada , " + 
                        "  per_data_ultimo_processamento , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  per_tipo_arquivo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :per_nome_arquivo , " + 
                        "  :per_arquivo , " + 
                        "  :per_motivo_rejeicao , " + 
                        "  :per_observacao , " + 
                        "  :per_modulo_importador , " + 
                        "  :per_data_entrada , " + 
                        "  :per_data_ultimo_processamento , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :per_tipo_arquivo  "+
                        ")RETURNING id_pedido_rejeitado;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_arquivo", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Arquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_motivo_rejeicao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MotivoRejeicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_modulo_importador", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ModuloImportador ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_data_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_data_ultimo_processamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataUltimoProcessamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_tipo_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoArquivo ?? DBNull.Value;

 
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
        public static PedidoRejeitadoClass CopiarEntidade(PedidoRejeitadoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PedidoRejeitadoClass toRet = new PedidoRejeitadoClass(usuario,conn);
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;
 toRet.Arquivo= entidadeCopiar.Arquivo;
 toRet.MotivoRejeicao= entidadeCopiar.MotivoRejeicao;
 toRet.Observacao= entidadeCopiar.Observacao;
 toRet.ModuloImportador= entidadeCopiar.ModuloImportador;
 toRet.DataEntrada= entidadeCopiar.DataEntrada;
 toRet.DataUltimoProcessamento= entidadeCopiar.DataUltimoProcessamento;
 toRet.TipoArquivo= entidadeCopiar.TipoArquivo;

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
       _motivoRejeicaoOriginal = MotivoRejeicao;
       _motivoRejeicaoOriginalCommited = _motivoRejeicaoOriginal;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _moduloImportadorOriginal = ModuloImportador;
       _moduloImportadorOriginalCommited = _moduloImportadorOriginal;
       _dataEntradaOriginal = DataEntrada;
       _dataEntradaOriginalCommited = _dataEntradaOriginal;
       _dataUltimoProcessamentoOriginal = DataUltimoProcessamento;
       _dataUltimoProcessamentoOriginalCommited = _dataUltimoProcessamentoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tipoArquivoOriginal = TipoArquivo;
       _tipoArquivoOriginalCommited = _tipoArquivoOriginal;

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
       _motivoRejeicaoOriginalCommited = MotivoRejeicao;
       _observacaoOriginalCommited = Observacao;
       _moduloImportadorOriginalCommited = ModuloImportador;
       _dataEntradaOriginalCommited = DataEntrada;
       _dataUltimoProcessamentoOriginalCommited = DataUltimoProcessamento;
       _versionOriginalCommited = Version;
       _tipoArquivoOriginalCommited = TipoArquivo;

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
               MotivoRejeicao=_motivoRejeicaoOriginal;
               _motivoRejeicaoOriginalCommited=_motivoRejeicaoOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               ModuloImportador=_moduloImportadorOriginal;
               _moduloImportadorOriginalCommited=_moduloImportadorOriginal;
               DataEntrada=_dataEntradaOriginal;
               _dataEntradaOriginalCommited=_dataEntradaOriginal;
               DataUltimoProcessamento=_dataUltimoProcessamentoOriginal;
               _dataUltimoProcessamentoOriginalCommited=_dataUltimoProcessamentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               TipoArquivo=_tipoArquivoOriginal;
               _tipoArquivoOriginalCommited=_tipoArquivoOriginal;

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
       dirty = _motivoRejeicaoOriginal != MotivoRejeicao;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
      if (dirty) return true;
       dirty = _moduloImportadorOriginal != ModuloImportador;
      if (dirty) return true;
       dirty = _dataEntradaOriginal != DataEntrada;
      if (dirty) return true;
       dirty = _dataUltimoProcessamentoOriginal != DataUltimoProcessamento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tipoArquivoOriginal != TipoArquivo;

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
       dirty = _motivoRejeicaoOriginalCommited != MotivoRejeicao;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
      if (dirty) return true;
       dirty = _moduloImportadorOriginalCommited != ModuloImportador;
      if (dirty) return true;
       dirty = _dataEntradaOriginalCommited != DataEntrada;
      if (dirty) return true;
       dirty = _dataUltimoProcessamentoOriginalCommited != DataUltimoProcessamento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tipoArquivoOriginalCommited != TipoArquivo;

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
             case "MotivoRejeicao":
                return this.MotivoRejeicao;
             case "Observacao":
                return this.Observacao;
             case "ModuloImportador":
                return this.ModuloImportador;
             case "DataEntrada":
                return this.DataEntrada;
             case "DataUltimoProcessamento":
                return this.DataUltimoProcessamento;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "TipoArquivo":
                return this.TipoArquivo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
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
                  command.CommandText += " COUNT(pedido_rejeitado.id_pedido_rejeitado) " ;
               }
               else
               {
               command.CommandText += "pedido_rejeitado.id_pedido_rejeitado, " ;
               command.CommandText += "pedido_rejeitado.per_nome_arquivo, " ;
               command.CommandText += "pedido_rejeitado.per_motivo_rejeicao, " ;
               command.CommandText += "pedido_rejeitado.per_observacao, " ;
               command.CommandText += "pedido_rejeitado.per_modulo_importador, " ;
               command.CommandText += "pedido_rejeitado.per_data_entrada, " ;
               command.CommandText += "pedido_rejeitado.per_data_ultimo_processamento, " ;
               command.CommandText += "pedido_rejeitado.entity_uid, " ;
               command.CommandText += "pedido_rejeitado.version, " ;
               command.CommandText += "pedido_rejeitado.per_tipo_arquivo " ;
               }
               command.CommandText += " FROM  pedido_rejeitado ";
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
                        orderByClause += " , per_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(per_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = pedido_rejeitado.id_acs_usuario_ultima_revisao ";
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
                     case "id_pedido_rejeitado":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_rejeitado.id_pedido_rejeitado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_rejeitado.id_pedido_rejeitado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_rejeitado.per_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_rejeitado.per_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_arquivo":
                     case "Arquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_rejeitado.per_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_rejeitado.per_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_motivo_rejeicao":
                     case "MotivoRejeicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_rejeitado.per_motivo_rejeicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_rejeitado.per_motivo_rejeicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_rejeitado.per_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_rejeitado.per_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_modulo_importador":
                     case "ModuloImportador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_rejeitado.per_modulo_importador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_rejeitado.per_modulo_importador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_data_entrada":
                     case "DataEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_rejeitado.per_data_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_rejeitado.per_data_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_data_ultimo_processamento":
                     case "DataUltimoProcessamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_rejeitado.per_data_ultimo_processamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_rejeitado.per_data_ultimo_processamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_rejeitado.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_rejeitado.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , pedido_rejeitado.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_rejeitado.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "per_tipo_arquivo":
                     case "TipoArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_rejeitado.per_tipo_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_rejeitado.per_tipo_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("per_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(pedido_rejeitado.per_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_rejeitado.per_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("per_motivo_rejeicao")) 
                        {
                           whereClause += " OR UPPER(pedido_rejeitado.per_motivo_rejeicao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_rejeitado.per_motivo_rejeicao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("per_observacao")) 
                        {
                           whereClause += " OR UPPER(pedido_rejeitado.per_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_rejeitado.per_observacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("per_modulo_importador")) 
                        {
                           whereClause += " OR UPPER(pedido_rejeitado.per_modulo_importador) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_rejeitado.per_modulo_importador) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(pedido_rejeitado.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_rejeitado.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("per_tipo_arquivo")) 
                        {
                           whereClause += " OR UPPER(pedido_rejeitado.per_tipo_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_rejeitado.per_tipo_arquivo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_pedido_rejeitado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.id_pedido_rejeitado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.id_pedido_rejeitado = :pedido_rejeitado_ID_6847 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_ID_6847", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "per_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_nome_arquivo LIKE :pedido_rejeitado_NomeArquivo_1875 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_NomeArquivo_1875", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Arquivo" || parametro.FieldName == "per_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_arquivo = :pedido_rejeitado_Arquivo_7933 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_Arquivo_7933", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoRejeicao" || parametro.FieldName == "per_motivo_rejeicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_motivo_rejeicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_motivo_rejeicao LIKE :pedido_rejeitado_MotivoRejeicao_3416 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_MotivoRejeicao_3416", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "per_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_observacao LIKE :pedido_rejeitado_Observacao_6528 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_Observacao_6528", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModuloImportador" || parametro.FieldName == "per_modulo_importador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_modulo_importador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_modulo_importador LIKE :pedido_rejeitado_ModuloImportador_5232 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_ModuloImportador_5232", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrada" || parametro.FieldName == "per_data_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_data_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_data_entrada = :pedido_rejeitado_DataEntrada_2758 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_DataEntrada_2758", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataUltimoProcessamento" || parametro.FieldName == "per_data_ultimo_processamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_data_ultimo_processamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_data_ultimo_processamento = :pedido_rejeitado_DataUltimoProcessamento_4444 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_DataUltimoProcessamento_4444", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  pedido_rejeitado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.entity_uid LIKE :pedido_rejeitado_EntityUid_9132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_EntityUid_9132", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_rejeitado.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.version = :pedido_rejeitado_Version_2899 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_Version_2899", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoArquivo" || parametro.FieldName == "per_tipo_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_tipo_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_tipo_arquivo LIKE :pedido_rejeitado_TipoArquivo_3794 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_TipoArquivo_3794", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_rejeitado.per_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_nome_arquivo LIKE :pedido_rejeitado_NomeArquivo_3850 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_NomeArquivo_3850", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoRejeicaoExato" || parametro.FieldName == "MotivoRejeicaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_motivo_rejeicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_motivo_rejeicao LIKE :pedido_rejeitado_MotivoRejeicao_4115 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_MotivoRejeicao_4115", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoExato" || parametro.FieldName == "ObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_observacao LIKE :pedido_rejeitado_Observacao_9538 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_Observacao_9538", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModuloImportadorExato" || parametro.FieldName == "ModuloImportadorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_modulo_importador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_modulo_importador LIKE :pedido_rejeitado_ModuloImportador_4724 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_ModuloImportador_4724", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_rejeitado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.entity_uid LIKE :pedido_rejeitado_EntityUid_5494 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_EntityUid_5494", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoArquivoExato" || parametro.FieldName == "TipoArquivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_rejeitado.per_tipo_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_rejeitado.per_tipo_arquivo LIKE :pedido_rejeitado_TipoArquivo_4886 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_rejeitado_TipoArquivo_4886", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PedidoRejeitadoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PedidoRejeitadoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PedidoRejeitadoClass), Convert.ToInt32(read["id_pedido_rejeitado"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PedidoRejeitadoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_pedido_rejeitado"]);
                     entidade.NomeArquivo = (read["per_nome_arquivo"] != DBNull.Value ? read["per_nome_arquivo"].ToString() : null);
                     entidade.MotivoRejeicao = (read["per_motivo_rejeicao"] != DBNull.Value ? read["per_motivo_rejeicao"].ToString() : null);
                     entidade.Observacao = (read["per_observacao"] != DBNull.Value ? read["per_observacao"].ToString() : null);
                     entidade.ModuloImportador = (read["per_modulo_importador"] != DBNull.Value ? read["per_modulo_importador"].ToString() : null);
                     entidade.DataEntrada = (DateTime)read["per_data_entrada"];
                     entidade.DataUltimoProcessamento = (DateTime)read["per_data_ultimo_processamento"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.TipoArquivo = (read["per_tipo_arquivo"] != DBNull.Value ? read["per_tipo_arquivo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PedidoRejeitadoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

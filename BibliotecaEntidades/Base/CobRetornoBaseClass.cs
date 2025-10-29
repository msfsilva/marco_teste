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
     [Table("cob_retorno","ret")]
     public class CobRetornoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CobRetornoClass";
protected const string ErroDelete = "Erro ao excluir o CobRetornoClass  ";
protected const string ErroSave = "Erro ao salvar o CobRetornoClass.";
protected const string ErroCollectionCobBoletoRetornoClassCobRetorno = "Erro ao carregar a coleção de CobBoletoRetornoClass.";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroNomeArquivoComprimento = "O campo NomeArquivo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do CobRetornoClass.";
protected const string MensagemUtilizadoCollectionCobBoletoRetornoClassCobRetorno =  "A entidade CobRetornoClass está sendo utilizada nos seguintes CobBoletoRetornoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CobRetornoClass está sendo utilizada.";
#endregion
       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("ret_nome_arquivo")]
        public virtual string NomeArquivo
         { 
            get { return this._valueNomeArquivo; } 
            set 
            { 
                if (this._valueNomeArquivo == value)return;
                 this._valueNomeArquivo = value; 
            } 
        } 

       protected DateTime _dataImportacaoOriginal{get;private set;}
       private DateTime _dataImportacaoOriginalCommited{get; set;}
        private DateTime _valueDataImportacao;
         [Column("ret_data_importacao")]
        public virtual DateTime DataImportacao
         { 
            get { return this._valueDataImportacao; } 
            set 
            { 
                if (this._valueDataImportacao == value)return;
                 this._valueDataImportacao = value; 
            } 
        } 

       protected DateTime _dataGeracaoRetornoOriginal{get;private set;}
       private DateTime _dataGeracaoRetornoOriginalCommited{get; set;}
        private DateTime _valueDataGeracaoRetorno;
         [Column("ret_data_geracao_retorno")]
        public virtual DateTime DataGeracaoRetorno
         { 
            get { return this._valueDataGeracaoRetorno; } 
            set 
            { 
                if (this._valueDataGeracaoRetorno == value)return;
                 this._valueDataGeracaoRetorno = value; 
            } 
        } 

       protected int? _numeroArqRetornoOriginal{get;private set;}
       private int? _numeroArqRetornoOriginalCommited{get; set;}
        private int? _valueNumeroArqRetorno;
         [Column("ret_numero_arq_retorno")]
        public virtual int? NumeroArqRetorno
         { 
            get { return this._valueNumeroArqRetorno; } 
            set 
            { 
                if (this._valueNumeroArqRetorno == value)return;
                 this._valueNumeroArqRetorno = value; 
            } 
        } 

       protected DateTime? _dataCreditoOriginal{get;private set;}
       private DateTime? _dataCreditoOriginalCommited{get; set;}
        private DateTime? _valueDataCredito;
         [Column("ret_data_credito")]
        public virtual DateTime? DataCredito
         { 
            get { return this._valueDataCredito; } 
            set 
            { 
                if (this._valueDataCredito == value)return;
                 this._valueDataCredito = value; 
            } 
        } 

       private List<long> _collectionCobBoletoRetornoClassCobRetornoOriginal;
       private List<Entidades.CobBoletoRetornoClass > _collectionCobBoletoRetornoClassCobRetornoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoRetornoClassCobRetornoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoRetornoClassCobRetornoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CobBoletoRetornoClass> _valueCollectionCobBoletoRetornoClassCobRetorno { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CobBoletoRetornoClass> CollectionCobBoletoRetornoClassCobRetorno 
       { 
           get { if(!_valueCollectionCobBoletoRetornoClassCobRetornoLoaded && !this.DisableLoadCollection){this.LoadCollectionCobBoletoRetornoClassCobRetorno();}
return this._valueCollectionCobBoletoRetornoClassCobRetorno; } 
           set 
           { 
               this._valueCollectionCobBoletoRetornoClassCobRetorno = value; 
               this._valueCollectionCobBoletoRetornoClassCobRetornoLoaded = true; 
           } 
       } 

        public CobRetornoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataImportacao = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CobRetornoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CobRetornoClass) GetEntity(typeof(CobRetornoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionCobBoletoRetornoClassCobRetornoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCobBoletoRetornoClassCobRetornoChanged = true;
                  _valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCobBoletoRetornoClassCobRetornoChanged = true; 
                  _valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged = true;
                 foreach (Entidades.CobBoletoRetornoClass item in e.OldItems) 
                 { 
                     _collectionCobBoletoRetornoClassCobRetornoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCobBoletoRetornoClassCobRetornoChanged = true; 
                  _valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged = true;
                 foreach (Entidades.CobBoletoRetornoClass item in _valueCollectionCobBoletoRetornoClassCobRetorno) 
                 { 
                     _collectionCobBoletoRetornoClassCobRetornoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCobBoletoRetornoClassCobRetorno()
         {
            try
            {
                 ObservableCollection<Entidades.CobBoletoRetornoClass> oc;
                _valueCollectionCobBoletoRetornoClassCobRetornoChanged = false;
                 _valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged = false;
                _collectionCobBoletoRetornoClassCobRetornoRemovidos = new List<Entidades.CobBoletoRetornoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CobBoletoRetornoClass>();
                }
                else{ 
                   Entidades.CobBoletoRetornoClass search = new Entidades.CobBoletoRetornoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CobBoletoRetornoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CobRetorno", this),                     }                       ).Cast<Entidades.CobBoletoRetornoClass>().ToList());
                 }
                 _valueCollectionCobBoletoRetornoClassCobRetorno = new BindingList<Entidades.CobBoletoRetornoClass>(oc); 
                 _collectionCobBoletoRetornoClassCobRetornoOriginal= (from a in _valueCollectionCobBoletoRetornoClassCobRetorno select a.ID).ToList();
                 _valueCollectionCobBoletoRetornoClassCobRetornoLoaded = true;
                 oc.CollectionChanged += CollectionCobBoletoRetornoClassCobRetornoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCobBoletoRetornoClassCobRetorno+"\r\n" + e.Message, e);
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
                    "  public.cob_retorno  " +
                    "WHERE " +
                    "  id_cob_retorno = :id";
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
                        "  public.cob_retorno   " +
                        "SET  " + 
                        "  ret_nome_arquivo = :ret_nome_arquivo, " + 
                        "  ret_data_importacao = :ret_data_importacao, " + 
                        "  ret_data_geracao_retorno = :ret_data_geracao_retorno, " + 
                        "  ret_numero_arq_retorno = :ret_numero_arq_retorno, " + 
                        "  ret_data_credito = :ret_data_credito, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_cob_retorno = :id " +
                        "RETURNING id_cob_retorno;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cob_retorno " +
                        "( " +
                        "  ret_nome_arquivo , " + 
                        "  ret_data_importacao , " + 
                        "  ret_data_geracao_retorno , " + 
                        "  ret_numero_arq_retorno , " + 
                        "  ret_data_credito , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ret_nome_arquivo , " + 
                        "  :ret_data_importacao , " + 
                        "  :ret_data_geracao_retorno , " + 
                        "  :ret_numero_arq_retorno , " + 
                        "  :ret_data_credito , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_cob_retorno;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ret_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ret_data_importacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImportacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ret_data_geracao_retorno", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataGeracaoRetorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ret_numero_arq_retorno", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroArqRetorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ret_data_credito", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;

 
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
 if (CollectionCobBoletoRetornoClassCobRetorno.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCobBoletoRetornoClassCobRetorno+"\r\n";
                foreach (Entidades.CobBoletoRetornoClass tmp in CollectionCobBoletoRetornoClassCobRetorno)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
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
        public static CobRetornoClass CopiarEntidade(CobRetornoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CobRetornoClass toRet = new CobRetornoClass(usuario,conn);
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;
 toRet.DataImportacao= entidadeCopiar.DataImportacao;
 toRet.DataGeracaoRetorno= entidadeCopiar.DataGeracaoRetorno;
 toRet.NumeroArqRetorno= entidadeCopiar.NumeroArqRetorno;
 toRet.DataCredito= entidadeCopiar.DataCredito;

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
       _dataImportacaoOriginal = DataImportacao;
       _dataImportacaoOriginalCommited = _dataImportacaoOriginal;
       _dataGeracaoRetornoOriginal = DataGeracaoRetorno;
       _dataGeracaoRetornoOriginalCommited = _dataGeracaoRetornoOriginal;
       _numeroArqRetornoOriginal = NumeroArqRetorno;
       _numeroArqRetornoOriginalCommited = _numeroArqRetornoOriginal;
       _dataCreditoOriginal = DataCredito;
       _dataCreditoOriginalCommited = _dataCreditoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;

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
       _dataImportacaoOriginalCommited = DataImportacao;
       _dataGeracaoRetornoOriginalCommited = DataGeracaoRetorno;
       _numeroArqRetornoOriginalCommited = NumeroArqRetorno;
       _dataCreditoOriginalCommited = DataCredito;
       _versionOriginalCommited = Version;

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
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                  if (_collectionCobBoletoRetornoClassCobRetornoRemovidos != null) 
                  {
                     _collectionCobBoletoRetornoClassCobRetornoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCobBoletoRetornoClassCobRetornoRemovidos = new List<Entidades.CobBoletoRetornoClass>();
                  }
                  _collectionCobBoletoRetornoClassCobRetornoOriginal= (from a in _valueCollectionCobBoletoRetornoClassCobRetorno select a.ID).ToList();
                  _valueCollectionCobBoletoRetornoClassCobRetornoChanged = false;
                  _valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged = false;
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
               DataImportacao=_dataImportacaoOriginal;
               _dataImportacaoOriginalCommited=_dataImportacaoOriginal;
               DataGeracaoRetorno=_dataGeracaoRetornoOriginal;
               _dataGeracaoRetornoOriginalCommited=_dataGeracaoRetornoOriginal;
               NumeroArqRetorno=_numeroArqRetornoOriginal;
               _numeroArqRetornoOriginalCommited=_numeroArqRetornoOriginal;
               DataCredito=_dataCreditoOriginal;
               _dataCreditoOriginalCommited=_dataCreditoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                  CollectionCobBoletoRetornoClassCobRetorno.Clear();
                  foreach(int item in _collectionCobBoletoRetornoClassCobRetornoOriginal)
                  {
                    CollectionCobBoletoRetornoClassCobRetorno.Add(Entidades.CobBoletoRetornoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCobBoletoRetornoClassCobRetornoRemovidos.Clear();
               }

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
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                  if (_valueCollectionCobBoletoRetornoClassCobRetornoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                   tempRet = CollectionCobBoletoRetornoClassCobRetorno.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
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
       dirty = _dataImportacaoOriginal != DataImportacao;
      if (dirty) return true;
       dirty = _dataGeracaoRetornoOriginal != DataGeracaoRetorno;
      if (dirty) return true;
       dirty = _numeroArqRetornoOriginal != NumeroArqRetorno;
      if (dirty) return true;
       dirty = _dataCreditoOriginal != DataCredito;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;

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
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                  if (_valueCollectionCobBoletoRetornoClassCobRetornoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                   tempRet = CollectionCobBoletoRetornoClassCobRetorno.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
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
       dirty = _dataImportacaoOriginalCommited != DataImportacao;
      if (dirty) return true;
       dirty = _dataGeracaoRetornoOriginalCommited != DataGeracaoRetorno;
      if (dirty) return true;
       dirty = _numeroArqRetornoOriginalCommited != NumeroArqRetorno;
      if (dirty) return true;
       dirty = _dataCreditoOriginalCommited != DataCredito;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;

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
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                  foreach(CobBoletoRetornoClass item in CollectionCobBoletoRetornoClassCobRetorno)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
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
             case "DataImportacao":
                return this.DataImportacao;
             case "DataGeracaoRetorno":
                return this.DataGeracaoRetorno;
             case "NumeroArqRetorno":
                return this.NumeroArqRetorno;
             case "DataCredito":
                return this.DataCredito;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionCobBoletoRetornoClassCobRetornoLoaded) 
               {
                  foreach(CobBoletoRetornoClass item in CollectionCobBoletoRetornoClassCobRetorno)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
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
                  command.CommandText += " COUNT(cob_retorno.id_cob_retorno) " ;
               }
               else
               {
               command.CommandText += "cob_retorno.id_cob_retorno, " ;
               command.CommandText += "cob_retorno.ret_nome_arquivo, " ;
               command.CommandText += "cob_retorno.ret_data_importacao, " ;
               command.CommandText += "cob_retorno.ret_data_geracao_retorno, " ;
               command.CommandText += "cob_retorno.ret_numero_arq_retorno, " ;
               command.CommandText += "cob_retorno.ret_data_credito, " ;
               command.CommandText += "cob_retorno.entity_uid, " ;
               command.CommandText += "cob_retorno.version " ;
               }
               command.CommandText += " FROM  cob_retorno ";
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
                        orderByClause += " , ret_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ret_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cob_retorno.id_acs_usuario_ultima_revisao ";
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
                     case "id_cob_retorno":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_retorno.id_cob_retorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_retorno.id_cob_retorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ret_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_retorno.ret_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_retorno.ret_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ret_data_importacao":
                     case "DataImportacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_retorno.ret_data_importacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_retorno.ret_data_importacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ret_data_geracao_retorno":
                     case "DataGeracaoRetorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_retorno.ret_data_geracao_retorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_retorno.ret_data_geracao_retorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ret_numero_arq_retorno":
                     case "NumeroArqRetorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_retorno.ret_numero_arq_retorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_retorno.ret_numero_arq_retorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ret_data_credito":
                     case "DataCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_retorno.ret_data_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_retorno.ret_data_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_retorno.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_retorno.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cob_retorno.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_retorno.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ret_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(cob_retorno.ret_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_retorno.ret_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cob_retorno.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_retorno.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cob_retorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_retorno.id_cob_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.id_cob_retorno = :cob_retorno_ID_6399 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_ID_6399", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "ret_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_retorno.ret_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.ret_nome_arquivo LIKE :cob_retorno_NomeArquivo_6348 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_NomeArquivo_6348", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImportacao" || parametro.FieldName == "ret_data_importacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_retorno.ret_data_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.ret_data_importacao = :cob_retorno_DataImportacao_6635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_DataImportacao_6635", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataGeracaoRetorno" || parametro.FieldName == "ret_data_geracao_retorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_retorno.ret_data_geracao_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.ret_data_geracao_retorno = :cob_retorno_DataGeracaoRetorno_1670 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_DataGeracaoRetorno_1670", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroArqRetorno" || parametro.FieldName == "ret_numero_arq_retorno")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_retorno.ret_numero_arq_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.ret_numero_arq_retorno = :cob_retorno_NumeroArqRetorno_7484 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_NumeroArqRetorno_7484", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCredito" || parametro.FieldName == "ret_data_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_retorno.ret_data_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.ret_data_credito = :cob_retorno_DataCredito_8385 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_DataCredito_8385", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  cob_retorno.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.entity_uid LIKE :cob_retorno_EntityUid_9634 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_EntityUid_9634", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cob_retorno.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.version = :cob_retorno_Version_225 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_Version_225", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cob_retorno.ret_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.ret_nome_arquivo LIKE :cob_retorno_NomeArquivo_2282 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_NomeArquivo_2282", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cob_retorno.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_retorno.entity_uid LIKE :cob_retorno_EntityUid_326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_retorno_EntityUid_326", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CobRetornoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CobRetornoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CobRetornoClass), Convert.ToInt32(read["id_cob_retorno"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CobRetornoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cob_retorno"]);
                     entidade.NomeArquivo = (read["ret_nome_arquivo"] != DBNull.Value ? read["ret_nome_arquivo"].ToString() : null);
                     entidade.DataImportacao = (DateTime)read["ret_data_importacao"];
                     entidade.DataGeracaoRetorno = (DateTime)read["ret_data_geracao_retorno"];
                     entidade.NumeroArqRetorno = read["ret_numero_arq_retorno"] as int?;
                     entidade.DataCredito = read["ret_data_credito"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CobRetornoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

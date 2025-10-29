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
     [Table("motivo_alteracao_qtd_op","mao")]
     public class MotivoAlteracaoQtdOpBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MotivoAlteracaoQtdOpClass";
protected const string ErroDelete = "Erro ao excluir o MotivoAlteracaoQtdOpClass  ";
protected const string ErroSave = "Erro ao salvar o MotivoAlteracaoQtdOpClass.";
protected const string ErroCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected const string ErroCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoClass.";
protected const string ErroMotivoObrigatorio = "O campo Motivo é obrigatório";
protected const string ErroMotivoComprimento = "O campo Motivo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do MotivoAlteracaoQtdOpClass.";
protected const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp =  "A entidade MotivoAlteracaoQtdOpClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp =  "A entidade MotivoAlteracaoQtdOpClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MotivoAlteracaoQtdOpClass está sendo utilizada.";
#endregion
       protected string _motivoOriginal{get;private set;}
       private string _motivoOriginalCommited{get; set;}
        private string _valueMotivo;
         [Column("mao_motivo")]
        public virtual string Motivo
         { 
            get { return this._valueMotivo; } 
            set 
            { 
                if (this._valueMotivo == value)return;
                 this._valueMotivo = value; 
            } 
        } 

       protected TipoAlteracaoQuantidadeOP _tipoOriginal{get;private set;}
       private TipoAlteracaoQuantidadeOP _tipoOriginalCommited{get; set;}
        private TipoAlteracaoQuantidadeOP _valueTipo;
         [Column("mao_tipo")]
        public virtual TipoAlteracaoQuantidadeOP Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_AlteracaoParaMenor
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoAlteracaoQuantidadeOP.AlteracaoParaMenor; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoAlteracaoQuantidadeOP.AlteracaoParaMenor; }
         } 

        public bool Tipo_AlteracaoParaMaior
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoAlteracaoQuantidadeOP.AlteracaoParaMaior; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoAlteracaoQuantidadeOP.AlteracaoParaMaior; }
         } 

       private List<long> _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpOriginal;
       private List<Entidades.OrdemProducaoDiferencaClass > _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDiferencaClass> _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDiferencaClass> CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp 
       { 
           get { if(!_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp();}
return this._valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp = value; 
               this._valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpOriginal;
       private List<Entidades.OrdemProducaoPostoTrabalhoClass > _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPostoTrabalhoClass> _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPostoTrabalhoClass> CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp 
       { 
           get { if(!_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp();}
return this._valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp = value; 
               this._valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded = true; 
           } 
       } 

        public MotivoAlteracaoQtdOpBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (TipoAlteracaoQuantidadeOP)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static MotivoAlteracaoQtdOpClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MotivoAlteracaoQtdOpClass) GetEntity(typeof(MotivoAlteracaoQtdOpClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged = true;
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp) 
                 { 
                     _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDiferencaClass> oc;
                _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged = false;
                 _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged = false;
                _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDiferencaClass search = new Entidades.OrdemProducaoDiferencaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MotivoAlteracaoQtdOp", this),                     }                       ).Cast<Entidades.OrdemProducaoDiferencaClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp = new BindingList<Entidades.OrdemProducaoDiferencaClass>(oc); 
                 _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp select a.ID).ToList();
                 _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged = true;
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoClass item in _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass> oc;
                _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged = false;
                 _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged = false;
                _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPostoTrabalhoClass search = new Entidades.OrdemProducaoPostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MotivoAlteracaoQtdOp", this),                     }                       ).Cast<Entidades.OrdemProducaoPostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp = new BindingList<Entidades.OrdemProducaoPostoTrabalhoClass>(oc); 
                 _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp select a.ID).ToList();
                 _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Motivo))
                {
                    throw new Exception(ErroMotivoObrigatorio);
                }
                if (Motivo.Length >255)
                {
                    throw new Exception( ErroMotivoComprimento);
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
                    "  public.motivo_alteracao_qtd_op  " +
                    "WHERE " +
                    "  id_motivo_alteracao_qtd_op = :id";
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
                        "  public.motivo_alteracao_qtd_op   " +
                        "SET  " + 
                        "  mao_motivo = :mao_motivo, " + 
                        "  mao_tipo = :mao_tipo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_motivo_alteracao_qtd_op = :id " +
                        "RETURNING id_motivo_alteracao_qtd_op;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.motivo_alteracao_qtd_op " +
                        "( " +
                        "  mao_motivo , " + 
                        "  mao_tipo , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mao_motivo , " + 
                        "  :mao_tipo , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_motivo_alteracao_qtd_op;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mao_motivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Motivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mao_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
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
 if (CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp+"\r\n";
                foreach (Entidades.OrdemProducaoDiferencaClass tmp in CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp+"\r\n";
                foreach (Entidades.OrdemProducaoPostoTrabalhoClass tmp in CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp)
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
        public static MotivoAlteracaoQtdOpClass CopiarEntidade(MotivoAlteracaoQtdOpClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MotivoAlteracaoQtdOpClass toRet = new MotivoAlteracaoQtdOpClass(usuario,conn);
 toRet.Motivo= entidadeCopiar.Motivo;
 toRet.Tipo= entidadeCopiar.Tipo;

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
       _motivoOriginal = Motivo;
       _motivoOriginalCommited = _motivoOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
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
       _motivoOriginalCommited = Motivo;
       _tipoOriginalCommited = Tipo;
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
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                  if (_collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos != null) 
                  {
                     _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                  }
                  _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp select a.ID).ToList();
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged = false;
                  _valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                  if (_collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos != null) 
                  {
                     _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoClass>();
                  }
                  _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp select a.ID).ToList();
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged = false;
                  _valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged = false;
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
               Motivo=_motivoOriginal;
               _motivoOriginalCommited=_motivoOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                  CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp.Clear();
                  foreach(int item in _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpOriginal)
                  {
                    CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp.Add(Entidades.OrdemProducaoDiferencaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                  CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp.Clear();
                  foreach(int item in _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpOriginal)
                  {
                    CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp.Add(Entidades.OrdemProducaoPostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpRemovidos.Clear();
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
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp.Any(item => item.IsDirty());
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
       dirty = _motivoOriginal != Motivo;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
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
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp.Any(item => item.IsDirtyCommited());
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
       dirty = _motivoOriginalCommited != Motivo;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
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
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoClass item in CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp)
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
             case "Motivo":
                return this.Motivo;
             case "Tipo":
                return this.Tipo;
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
               if (_valueCollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOpLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassMotivoAlteracaoQtdOp)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOpLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoClass item in CollectionOrdemProducaoPostoTrabalhoClassMotivoAlteracaoQtdOp)
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
                  command.CommandText += " COUNT(motivo_alteracao_qtd_op.id_motivo_alteracao_qtd_op) " ;
               }
               else
               {
               command.CommandText += "motivo_alteracao_qtd_op.id_motivo_alteracao_qtd_op, " ;
               command.CommandText += "motivo_alteracao_qtd_op.mao_motivo, " ;
               command.CommandText += "motivo_alteracao_qtd_op.mao_tipo, " ;
               command.CommandText += "motivo_alteracao_qtd_op.entity_uid, " ;
               command.CommandText += "motivo_alteracao_qtd_op.version " ;
               }
               command.CommandText += " FROM  motivo_alteracao_qtd_op ";
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
                        orderByClause += " , mao_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mao_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = motivo_alteracao_qtd_op.id_acs_usuario_ultima_revisao ";
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
                     case "id_motivo_alteracao_qtd_op":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , motivo_alteracao_qtd_op.id_motivo_alteracao_qtd_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op.id_motivo_alteracao_qtd_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mao_motivo":
                     case "Motivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , motivo_alteracao_qtd_op.mao_motivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op.mao_motivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mao_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , motivo_alteracao_qtd_op.mao_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op.mao_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , motivo_alteracao_qtd_op.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , motivo_alteracao_qtd_op.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mao_motivo")) 
                        {
                           whereClause += " OR UPPER(motivo_alteracao_qtd_op.mao_motivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(motivo_alteracao_qtd_op.mao_motivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(motivo_alteracao_qtd_op.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(motivo_alteracao_qtd_op.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_motivo_alteracao_qtd_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  motivo_alteracao_qtd_op.id_motivo_alteracao_qtd_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.id_motivo_alteracao_qtd_op = :motivo_alteracao_qtd_op_ID_76 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_ID_76", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Motivo" || parametro.FieldName == "mao_motivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  motivo_alteracao_qtd_op.mao_motivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.mao_motivo LIKE :motivo_alteracao_qtd_op_Motivo_7571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_Motivo_7571", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "mao_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoAlteracaoQuantidadeOP)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoAlteracaoQuantidadeOP");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  motivo_alteracao_qtd_op.mao_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.mao_tipo = :motivo_alteracao_qtd_op_Tipo_9166 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_Tipo_9166", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  motivo_alteracao_qtd_op.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.entity_uid LIKE :motivo_alteracao_qtd_op_EntityUid_5009 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_EntityUid_5009", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  motivo_alteracao_qtd_op.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.version = :motivo_alteracao_qtd_op_Version_1408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_Version_1408", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoExato" || parametro.FieldName == "MotivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  motivo_alteracao_qtd_op.mao_motivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.mao_motivo LIKE :motivo_alteracao_qtd_op_Motivo_3049 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_Motivo_3049", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  motivo_alteracao_qtd_op.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  motivo_alteracao_qtd_op.entity_uid LIKE :motivo_alteracao_qtd_op_EntityUid_1400 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("motivo_alteracao_qtd_op_EntityUid_1400", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MotivoAlteracaoQtdOpClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MotivoAlteracaoQtdOpClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MotivoAlteracaoQtdOpClass), Convert.ToInt32(read["id_motivo_alteracao_qtd_op"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MotivoAlteracaoQtdOpClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_motivo_alteracao_qtd_op"]);
                     entidade.Motivo = (read["mao_motivo"] != DBNull.Value ? read["mao_motivo"].ToString() : null);
                     entidade.Tipo = (TipoAlteracaoQuantidadeOP) (read["mao_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoAlteracaoQuantidadeOP), read["mao_tipo"]) : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MotivoAlteracaoQtdOpClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

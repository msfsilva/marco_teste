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
     [Table("tipo_kit","tik")]
     public class TipoKitBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do TipoKitClass";
protected const string ErroDelete = "Erro ao excluir o TipoKitClass  ";
protected const string ErroSave = "Erro ao salvar o TipoKitClass.";
protected const string ErroCollectionKitTipoKitClassTipoKit = "Erro ao carregar a coleção de KitTipoKitClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do TipoKitClass.";
protected const string MensagemUtilizadoCollectionKitTipoKitClassTipoKit =  "A entidade TipoKitClass está sendo utilizada nos seguintes KitTipoKitClass:";
protected const string ErroEtiquetaLoad = "O campo Etiqueta não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade TipoKitClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("tik_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected bool _impAcessoriosOriginal{get;private set;}
       private bool _impAcessoriosOriginalCommited{get; set;}
        private bool _valueImpAcessorios;
         [Column("tik_imp_acessorios")]
        public virtual bool ImpAcessorios
         { 
            get { return this._valueImpAcessorios; } 
            set 
            { 
                if (this._valueImpAcessorios == value)return;
                 this._valueImpAcessorios = value; 
            } 
        } 

       protected bool _impSafOriginal{get;private set;}
       private bool _impSafOriginalCommited{get; set;}
        private bool _valueImpSaf;
         [Column("tik_imp_saf")]
        public virtual bool ImpSaf
         { 
            get { return this._valueImpSaf; } 
            set 
            { 
                if (this._valueImpSaf == value)return;
                 this._valueImpSaf = value; 
            } 
        } 

       protected bool _impDimensoesOriginal{get;private set;}
       private bool _impDimensoesOriginalCommited{get; set;}
        private bool _valueImpDimensoes;
         [Column("tik_imp_dimensoes")]
        public virtual bool ImpDimensoes
         { 
            get { return this._valueImpDimensoes; } 
            set 
            { 
                if (this._valueImpDimensoes == value)return;
                 this._valueImpDimensoes = value; 
            } 
        } 

       protected string _etiquetaOriginal= null;
        private string _etiquetaOriginalCommited= null;
        private bool _EtiquetaLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool EtiquetaLoaded 
       { 
            get {                     return _EtiquetaLoaded; } 
           set 
           { 
                this._EtiquetaLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueEtiqueta;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("tik_etiqueta")]
        public virtual byte[] Etiqueta
         { 
            get { 
                   if (!this.EtiquetaLoaded) 
                   {
                       this.LoadEtiqueta();
                   }
                   return this._valueEtiqueta; } 
            set 
            { 
                EtiquetaLoaded = true; 
                if (this._valueEtiqueta == value)return;
                 this._valueEtiqueta = value; 
            } 
        } 

       protected bool _impVariaveisOriginal{get;private set;}
       private bool _impVariaveisOriginalCommited{get; set;}
        private bool _valueImpVariaveis;
         [Column("tik_imp_variaveis")]
        public virtual bool ImpVariaveis
         { 
            get { return this._valueImpVariaveis; } 
            set 
            { 
                if (this._valueImpVariaveis == value)return;
                 this._valueImpVariaveis = value; 
            } 
        } 

       protected bool _impLabelComprimentoOriginal{get;private set;}
       private bool _impLabelComprimentoOriginalCommited{get; set;}
        private bool _valueImpLabelComprimento;
         [Column("tik_imp_label_comprimento")]
        public virtual bool ImpLabelComprimento
         { 
            get { return this._valueImpLabelComprimento; } 
            set 
            { 
                if (this._valueImpLabelComprimento == value)return;
                 this._valueImpLabelComprimento = value; 
            } 
        } 

       protected bool _imprimeVariaveisKitOriginal{get;private set;}
       private bool _imprimeVariaveisKitOriginalCommited{get; set;}
        private bool _valueImprimeVariaveisKit;
         [Column("tik_imprime_variaveis_kit")]
        public virtual bool ImprimeVariaveisKit
         { 
            get { return this._valueImprimeVariaveisKit; } 
            set 
            { 
                if (this._valueImprimeVariaveisKit == value)return;
                 this._valueImprimeVariaveisKit = value; 
            } 
        } 

       protected short _somenteListaOriginal{get;private set;}
       private short _somenteListaOriginalCommited{get; set;}
        private short _valueSomenteLista;
         [Column("tik_somente_lista")]
        public virtual short SomenteLista
         { 
            get { return this._valueSomenteLista; } 
            set 
            { 
                if (this._valueSomenteLista == value)return;
                 this._valueSomenteLista = value; 
            } 
        } 

       private List<long> _collectionKitTipoKitClassTipoKitOriginal;
       private List<Entidades.KitTipoKitClass > _collectionKitTipoKitClassTipoKitRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKitTipoKitClassTipoKitLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKitTipoKitClassTipoKitChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionKitTipoKitClassTipoKitCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.KitTipoKitClass> _valueCollectionKitTipoKitClassTipoKit { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.KitTipoKitClass> CollectionKitTipoKitClassTipoKit 
       { 
           get { if(!_valueCollectionKitTipoKitClassTipoKitLoaded && !this.DisableLoadCollection){this.LoadCollectionKitTipoKitClassTipoKit();}
return this._valueCollectionKitTipoKitClassTipoKit; } 
           set 
           { 
               this._valueCollectionKitTipoKitClassTipoKit = value; 
               this._valueCollectionKitTipoKitClassTipoKitLoaded = true; 
           } 
       } 

        public TipoKitBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ImprimeVariaveisKit = false;
           this.SomenteLista = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static TipoKitClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (TipoKitClass) GetEntity(typeof(TipoKitClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionKitTipoKitClassTipoKitChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionKitTipoKitClassTipoKitChanged = true;
                  _valueCollectionKitTipoKitClassTipoKitCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionKitTipoKitClassTipoKitChanged = true; 
                  _valueCollectionKitTipoKitClassTipoKitCommitedChanged = true;
                 foreach (Entidades.KitTipoKitClass item in e.OldItems) 
                 { 
                     _collectionKitTipoKitClassTipoKitRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionKitTipoKitClassTipoKitChanged = true; 
                  _valueCollectionKitTipoKitClassTipoKitCommitedChanged = true;
                 foreach (Entidades.KitTipoKitClass item in _valueCollectionKitTipoKitClassTipoKit) 
                 { 
                     _collectionKitTipoKitClassTipoKitRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionKitTipoKitClassTipoKit()
         {
            try
            {
                 ObservableCollection<Entidades.KitTipoKitClass> oc;
                _valueCollectionKitTipoKitClassTipoKitChanged = false;
                 _valueCollectionKitTipoKitClassTipoKitCommitedChanged = false;
                _collectionKitTipoKitClassTipoKitRemovidos = new List<Entidades.KitTipoKitClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.KitTipoKitClass>();
                }
                else{ 
                   Entidades.KitTipoKitClass search = new Entidades.KitTipoKitClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.KitTipoKitClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoKit", this)                    }                       ).Cast<Entidades.KitTipoKitClass>().ToList());
                 }
                 _valueCollectionKitTipoKitClassTipoKit = new BindingList<Entidades.KitTipoKitClass>(oc); 
                 _collectionKitTipoKitClassTipoKitOriginal= (from a in _valueCollectionKitTipoKitClassTipoKit select a.ID).ToList();
                 _valueCollectionKitTipoKitClassTipoKitLoaded = true;
                 oc.CollectionChanged += CollectionKitTipoKitClassTipoKitChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionKitTipoKitClassTipoKit+"\r\n" + e.Message, e);
            }
         } 
private void LoadEtiqueta()
        {
            try
            {
                if (this.ID == -1)
                {

                    EtiquetaLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT tik_etiqueta FROM tipo_kit WHERE id_tipo_kit = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueEtiqueta = (byte[]) tmp;
                }
                if (this._valueEtiqueta != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _etiquetaOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueEtiqueta));
                     }
                  } 
                  else 
                  { 
                        _etiquetaOriginal = null ;
                  } 
                EtiquetaLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroEtiquetaLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
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
                    "  public.tipo_kit  " +
                    "WHERE " +
                    "  id_tipo_kit = :id";
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
                        "  public.tipo_kit   " +
                        "SET  " + 
                        "  tik_nome = :tik_nome, " + 
                        "  tik_imp_acessorios = :tik_imp_acessorios, " + 
                        "  tik_imp_saf = :tik_imp_saf, " + 
                        "  tik_imp_dimensoes = :tik_imp_dimensoes, " + 
                        "  tik_etiqueta = :tik_etiqueta, " + 
                        "  tik_imp_variaveis = :tik_imp_variaveis, " + 
                        "  tik_imp_label_comprimento = :tik_imp_label_comprimento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  tik_imprime_variaveis_kit = :tik_imprime_variaveis_kit, " + 
                        "  tik_somente_lista = :tik_somente_lista "+
                        "WHERE  " +
                        "  id_tipo_kit = :id " +
                        "RETURNING id_tipo_kit;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.tipo_kit " +
                        "( " +
                        "  tik_nome , " + 
                        "  tik_imp_acessorios , " + 
                        "  tik_imp_saf , " + 
                        "  tik_imp_dimensoes , " + 
                        "  tik_etiqueta , " + 
                        "  tik_imp_variaveis , " + 
                        "  tik_imp_label_comprimento , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  tik_imprime_variaveis_kit , " + 
                        "  tik_somente_lista  "+
                        ")  " +
                        "VALUES ( " +
                        "  :tik_nome , " + 
                        "  :tik_imp_acessorios , " + 
                        "  :tik_imp_saf , " + 
                        "  :tik_imp_dimensoes , " + 
                        "  :tik_etiqueta , " + 
                        "  :tik_imp_variaveis , " + 
                        "  :tik_imp_label_comprimento , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :tik_imprime_variaveis_kit , " + 
                        "  :tik_somente_lista  "+
                        ")RETURNING id_tipo_kit;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_imp_acessorios", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpAcessorios ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_imp_saf", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpSaf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_imp_dimensoes", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpDimensoes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_etiqueta", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Etiqueta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_imp_variaveis", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpVariaveis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_imp_label_comprimento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpLabelComprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_imprime_variaveis_kit", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimeVariaveisKit ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tik_somente_lista", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SomenteLista ?? DBNull.Value;

 
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
 if (CollectionKitTipoKitClassTipoKit.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionKitTipoKitClassTipoKit+"\r\n";
                foreach (Entidades.KitTipoKitClass tmp in CollectionKitTipoKitClassTipoKit)
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
        public static TipoKitClass CopiarEntidade(TipoKitClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               TipoKitClass toRet = new TipoKitClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.ImpAcessorios= entidadeCopiar.ImpAcessorios;
 toRet.ImpSaf= entidadeCopiar.ImpSaf;
 toRet.ImpDimensoes= entidadeCopiar.ImpDimensoes;
 toRet.Etiqueta= entidadeCopiar.Etiqueta;
 toRet.ImpVariaveis= entidadeCopiar.ImpVariaveis;
 toRet.ImpLabelComprimento= entidadeCopiar.ImpLabelComprimento;
 toRet.ImprimeVariaveisKit= entidadeCopiar.ImprimeVariaveisKit;
 toRet.SomenteLista= entidadeCopiar.SomenteLista;

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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _impAcessoriosOriginal = ImpAcessorios;
       _impAcessoriosOriginalCommited = _impAcessoriosOriginal;
       _impSafOriginal = ImpSaf;
       _impSafOriginalCommited = _impSafOriginal;
       _impDimensoesOriginal = ImpDimensoes;
       _impDimensoesOriginalCommited = _impDimensoesOriginal;
       _impVariaveisOriginal = ImpVariaveis;
       _impVariaveisOriginalCommited = _impVariaveisOriginal;
       _impLabelComprimentoOriginal = ImpLabelComprimento;
       _impLabelComprimentoOriginalCommited = _impLabelComprimentoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _imprimeVariaveisKitOriginal = ImprimeVariaveisKit;
       _imprimeVariaveisKitOriginalCommited = _imprimeVariaveisKitOriginal;
       _somenteListaOriginal = SomenteLista;
       _somenteListaOriginalCommited = _somenteListaOriginal;

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
       _nomeOriginalCommited = Nome;
       _impAcessoriosOriginalCommited = ImpAcessorios;
       _impSafOriginalCommited = ImpSaf;
       _impDimensoesOriginalCommited = ImpDimensoes;
       _impVariaveisOriginalCommited = ImpVariaveis;
       _impLabelComprimentoOriginalCommited = ImpLabelComprimento;
       _versionOriginalCommited = Version;
       _imprimeVariaveisKitOriginalCommited = ImprimeVariaveisKit;
       _somenteListaOriginalCommited = SomenteLista;

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
               if (EtiquetaLoaded)
               {
                  if(this._valueEtiqueta != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _etiquetaOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueEtiqueta));
                     }
                  } 
                  else 
                  { 
                        _etiquetaOriginal = null ;
                  } 
               }
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                  if (_collectionKitTipoKitClassTipoKitRemovidos != null) 
                  {
                     _collectionKitTipoKitClassTipoKitRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionKitTipoKitClassTipoKitRemovidos = new List<Entidades.KitTipoKitClass>();
                  }
                  _collectionKitTipoKitClassTipoKitOriginal= (from a in _valueCollectionKitTipoKitClassTipoKit select a.ID).ToList();
                  _valueCollectionKitTipoKitClassTipoKitChanged = false;
                  _valueCollectionKitTipoKitClassTipoKitCommitedChanged = false;
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
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               ImpAcessorios=_impAcessoriosOriginal;
               _impAcessoriosOriginalCommited=_impAcessoriosOriginal;
               ImpSaf=_impSafOriginal;
               _impSafOriginalCommited=_impSafOriginal;
               ImpDimensoes=_impDimensoesOriginal;
               _impDimensoesOriginalCommited=_impDimensoesOriginal;
               EtiquetaLoaded = false;
               this._etiquetaOriginal = null;
               this._etiquetaOriginalCommited = null;
               this._valueEtiqueta = null;
               ImpVariaveis=_impVariaveisOriginal;
               _impVariaveisOriginalCommited=_impVariaveisOriginal;
               ImpLabelComprimento=_impLabelComprimentoOriginal;
               _impLabelComprimentoOriginalCommited=_impLabelComprimentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ImprimeVariaveisKit=_imprimeVariaveisKitOriginal;
               _imprimeVariaveisKitOriginalCommited=_imprimeVariaveisKitOriginal;
               SomenteLista=_somenteListaOriginal;
               _somenteListaOriginalCommited=_somenteListaOriginal;
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                  CollectionKitTipoKitClassTipoKit.Clear();
                  foreach(int item in _collectionKitTipoKitClassTipoKitOriginal)
                  {
                    CollectionKitTipoKitClassTipoKit.Add(Entidades.KitTipoKitClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionKitTipoKitClassTipoKitRemovidos.Clear();
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
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                  if (_valueCollectionKitTipoKitClassTipoKitChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                   tempRet = CollectionKitTipoKitClassTipoKit.Any(item => item.IsDirty());
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
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _impAcessoriosOriginal != ImpAcessorios;
      if (dirty) return true;
       dirty = _impSafOriginal != ImpSaf;
      if (dirty) return true;
       dirty = _impDimensoesOriginal != ImpDimensoes;
      if (dirty) return true;
               if (EtiquetaLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpEtiqueta ;
                      if (this._valueEtiqueta == null) 
                      { 
                         tmpEtiqueta = null; 
                      } 
                      else 
                      { 
                         tmpEtiqueta = Convert.ToBase64String(sha1.ComputeHash(this._valueEtiqueta));
                      } 
                       dirty = _etiquetaOriginal != tmpEtiqueta;
                   }
               }
      if (dirty) return true;
       dirty = _impVariaveisOriginal != ImpVariaveis;
      if (dirty) return true;
       dirty = _impLabelComprimentoOriginal != ImpLabelComprimento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _imprimeVariaveisKitOriginal != ImprimeVariaveisKit;
      if (dirty) return true;
       dirty = _somenteListaOriginal != SomenteLista;

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
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                  if (_valueCollectionKitTipoKitClassTipoKitCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                   tempRet = CollectionKitTipoKitClassTipoKit.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _impAcessoriosOriginalCommited != ImpAcessorios;
      if (dirty) return true;
       dirty = _impSafOriginalCommited != ImpSaf;
      if (dirty) return true;
       dirty = _impDimensoesOriginalCommited != ImpDimensoes;
      if (dirty) return true;
               if (EtiquetaLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpEtiqueta ;
                      if (this._valueEtiqueta == null) 
                      { 
                         tmpEtiqueta = null; 
                      } 
                      else 
                      { 
                         tmpEtiqueta = Convert.ToBase64String(sha1.ComputeHash(this._valueEtiqueta));
                      } 
                       dirty = _etiquetaOriginalCommited != tmpEtiqueta;
                   }
               }
      if (dirty) return true;
       dirty = _impVariaveisOriginalCommited != ImpVariaveis;
      if (dirty) return true;
       dirty = _impLabelComprimentoOriginalCommited != ImpLabelComprimento;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _imprimeVariaveisKitOriginalCommited != ImprimeVariaveisKit;
      if (dirty) return true;
       dirty = _somenteListaOriginalCommited != SomenteLista;

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
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                  foreach(KitTipoKitClass item in CollectionKitTipoKitClassTipoKit)
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
             case "Nome":
                return this.Nome;
             case "ImpAcessorios":
                return this.ImpAcessorios;
             case "ImpSaf":
                return this.ImpSaf;
             case "ImpDimensoes":
                return this.ImpDimensoes;
             case "Etiqueta":
                return this.Etiqueta;
             case "ImpVariaveis":
                return this.ImpVariaveis;
             case "ImpLabelComprimento":
                return this.ImpLabelComprimento;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ImprimeVariaveisKit":
                return this.ImprimeVariaveisKit;
             case "SomenteLista":
                return this.SomenteLista;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionKitTipoKitClassTipoKitLoaded) 
               {
                  foreach(KitTipoKitClass item in CollectionKitTipoKitClassTipoKit)
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
                  command.CommandText += " COUNT(tipo_kit.id_tipo_kit) " ;
               }
               else
               {
               command.CommandText += "tipo_kit.id_tipo_kit, " ;
               command.CommandText += "tipo_kit.tik_nome, " ;
               command.CommandText += "tipo_kit.tik_imp_acessorios, " ;
               command.CommandText += "tipo_kit.tik_imp_saf, " ;
               command.CommandText += "tipo_kit.tik_imp_dimensoes, " ;
               command.CommandText += "tipo_kit.tik_imp_variaveis, " ;
               command.CommandText += "tipo_kit.tik_imp_label_comprimento, " ;
               command.CommandText += "tipo_kit.entity_uid, " ;
               command.CommandText += "tipo_kit.version, " ;
               command.CommandText += "tipo_kit.tik_imprime_variaveis_kit, " ;
               command.CommandText += "tipo_kit.tik_somente_lista " ;
               }
               command.CommandText += " FROM  tipo_kit ";
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
                        orderByClause += " , tik_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(tik_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = tipo_kit.id_acs_usuario_ultima_revisao ";
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
                     case "id_tipo_kit":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.id_tipo_kit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.id_tipo_kit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_kit.tik_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_kit.tik_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_imp_acessorios":
                     case "ImpAcessorios":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_imp_acessorios " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_imp_acessorios) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_imp_saf":
                     case "ImpSaf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_imp_saf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_imp_saf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_imp_dimensoes":
                     case "ImpDimensoes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_imp_dimensoes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_imp_dimensoes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_etiqueta":
                     case "Etiqueta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_imp_variaveis":
                     case "ImpVariaveis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_imp_variaveis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_imp_variaveis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_imp_label_comprimento":
                     case "ImpLabelComprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_imp_label_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_imp_label_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_kit.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_kit.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , tipo_kit.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_imprime_variaveis_kit":
                     case "ImprimeVariaveisKit":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_imprime_variaveis_kit " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_imprime_variaveis_kit) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tik_somente_lista":
                     case "SomenteLista":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_kit.tik_somente_lista " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_kit.tik_somente_lista) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("tik_nome")) 
                        {
                           whereClause += " OR UPPER(tipo_kit.tik_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_kit.tik_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(tipo_kit.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_kit.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_tipo_kit")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.id_tipo_kit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.id_tipo_kit = :tipo_kit_ID_1635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ID_1635", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "tik_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_nome LIKE :tipo_kit_Nome_5506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_Nome_5506", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpAcessorios" || parametro.FieldName == "tik_imp_acessorios")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_imp_acessorios IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_imp_acessorios = :tipo_kit_ImpAcessorios_1908 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ImpAcessorios_1908", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpSaf" || parametro.FieldName == "tik_imp_saf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_imp_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_imp_saf = :tipo_kit_ImpSaf_4414 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ImpSaf_4414", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpDimensoes" || parametro.FieldName == "tik_imp_dimensoes")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_imp_dimensoes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_imp_dimensoes = :tipo_kit_ImpDimensoes_8533 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ImpDimensoes_8533", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Etiqueta" || parametro.FieldName == "tik_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_etiqueta = :tipo_kit_Etiqueta_242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_Etiqueta_242", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpVariaveis" || parametro.FieldName == "tik_imp_variaveis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_imp_variaveis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_imp_variaveis = :tipo_kit_ImpVariaveis_9788 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ImpVariaveis_9788", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpLabelComprimento" || parametro.FieldName == "tik_imp_label_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_imp_label_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_imp_label_comprimento = :tipo_kit_ImpLabelComprimento_4698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ImpLabelComprimento_4698", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  tipo_kit.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.entity_uid LIKE :tipo_kit_EntityUid_3279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_EntityUid_3279", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  tipo_kit.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.version = :tipo_kit_Version_5735 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_Version_5735", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimeVariaveisKit" || parametro.FieldName == "tik_imprime_variaveis_kit")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_imprime_variaveis_kit IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_imprime_variaveis_kit = :tipo_kit_ImprimeVariaveisKit_361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_ImprimeVariaveisKit_361", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SomenteLista" || parametro.FieldName == "tik_somente_lista")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_somente_lista IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_somente_lista = :tipo_kit_SomenteLista_9612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_SomenteLista_9612", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeExato" || parametro.FieldName == "NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_kit.tik_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.tik_nome LIKE :tipo_kit_Nome_7985 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_Nome_7985", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  tipo_kit.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_kit.entity_uid LIKE :tipo_kit_EntityUid_3687 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_kit_EntityUid_3687", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  TipoKitClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (TipoKitClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(TipoKitClass), Convert.ToInt32(read["id_tipo_kit"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new TipoKitClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_tipo_kit"]);
                     entidade.Nome = (read["tik_nome"] != DBNull.Value ? read["tik_nome"].ToString() : null);
                     entidade.ImpAcessorios = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_acessorios"]));
                     entidade.ImpSaf = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_saf"]));
                     entidade.ImpDimensoes = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_dimensoes"]));
                     entidade.ImpVariaveis = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_variaveis"]));
                     entidade.ImpLabelComprimento = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_label_comprimento"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ImprimeVariaveisKit = Convert.ToBoolean(Convert.ToInt16(read["tik_imprime_variaveis_kit"]));
                     entidade.SomenteLista = (short)read["tik_somente_lista"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (TipoKitClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

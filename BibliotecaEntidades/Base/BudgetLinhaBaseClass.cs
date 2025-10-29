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
     [Table("budget_linha","bli")]
     public class BudgetLinhaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do BudgetLinhaClass";
protected const string ErroDelete = "Erro ao excluir o BudgetLinhaClass  ";
protected const string ErroSave = "Erro ao salvar o BudgetLinhaClass.";
protected const string ErroCollectionBudgetLinhaClassBudgetLinhaPai = "Erro ao carregar a coleção de BudgetLinhaClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroBudgetObrigatorio = "O campo Budget é obrigatório";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do BudgetLinhaClass.";
protected const string MensagemUtilizadoCollectionBudgetLinhaClassBudgetLinhaPai =  "A entidade BudgetLinhaClass está sendo utilizada nos seguintes BudgetLinhaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade BudgetLinhaClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.BudgetClass _budgetOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.BudgetClass _budgetOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.BudgetClass _valueBudget;
        [Column("id_budget", "budget", "id_budget")]
       public virtual BibliotecaEntidades.Entidades.BudgetClass Budget
        { 
           get {                 return this._valueBudget; } 
           set 
           { 
                if (this._valueBudget == value)return;
                 this._valueBudget = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _valueCentroCustoLucro;
        [Column("id_centro_custo_lucro", "centro_custo_lucro", "id_centro_custo_lucro")]
       public virtual BibliotecaEntidades.Entidades.CentroCustoLucroClass CentroCustoLucro
        { 
           get {                 return this._valueCentroCustoLucro; } 
           set 
           { 
                if (this._valueCentroCustoLucro == value)return;
                 this._valueCentroCustoLucro = value; 
           } 
       } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("bli_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.BudgetLinhaClass _budgetLinhaPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.BudgetLinhaClass _budgetLinhaPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.BudgetLinhaClass _valueBudgetLinhaPai;
        [Column("id_budget_linha_pai", "budget_linha", "id_budget_linha")]
       public virtual BibliotecaEntidades.Entidades.BudgetLinhaClass BudgetLinhaPai
        { 
           get {                 return this._valueBudgetLinhaPai; } 
           set 
           { 
                if (this._valueBudgetLinhaPai == value)return;
                 this._valueBudgetLinhaPai = value; 
           } 
       } 

       private List<long> _collectionBudgetLinhaClassBudgetLinhaPaiOriginal;
       private List<Entidades.BudgetLinhaClass > _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.BudgetLinhaClass> _valueCollectionBudgetLinhaClassBudgetLinhaPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.BudgetLinhaClass> CollectionBudgetLinhaClassBudgetLinhaPai 
       { 
           get { if(!_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionBudgetLinhaClassBudgetLinhaPai();}
return this._valueCollectionBudgetLinhaClassBudgetLinhaPai; } 
           set 
           { 
               this._valueCollectionBudgetLinhaClassBudgetLinhaPai = value; 
               this._valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded = true; 
           } 
       } 

        public BudgetLinhaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Valor = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static BudgetLinhaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (BudgetLinhaClass) GetEntity(typeof(BudgetLinhaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionBudgetLinhaClassBudgetLinhaPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged = true;
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged = true; 
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged = true;
                 foreach (Entidades.BudgetLinhaClass item in e.OldItems) 
                 { 
                     _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged = true; 
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged = true;
                 foreach (Entidades.BudgetLinhaClass item in _valueCollectionBudgetLinhaClassBudgetLinhaPai) 
                 { 
                     _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionBudgetLinhaClassBudgetLinhaPai()
         {
            try
            {
                 ObservableCollection<Entidades.BudgetLinhaClass> oc;
                _valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged = false;
                 _valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged = false;
                _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos = new List<Entidades.BudgetLinhaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.BudgetLinhaClass>();
                }
                else{ 
                   Entidades.BudgetLinhaClass search = new Entidades.BudgetLinhaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.BudgetLinhaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("BudgetLinhaPai", this),                     }                       ).Cast<Entidades.BudgetLinhaClass>().ToList());
                 }
                 _valueCollectionBudgetLinhaClassBudgetLinhaPai = new BindingList<Entidades.BudgetLinhaClass>(oc); 
                 _collectionBudgetLinhaClassBudgetLinhaPaiOriginal= (from a in _valueCollectionBudgetLinhaClassBudgetLinhaPai select a.ID).ToList();
                 _valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded = true;
                 oc.CollectionChanged += CollectionBudgetLinhaClassBudgetLinhaPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionBudgetLinhaClassBudgetLinhaPai+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueBudget == null)
                {
                    throw new Exception(ErroBudgetObrigatorio);
                }
                if ( _valueCentroCustoLucro == null)
                {
                    throw new Exception(ErroCentroCustoLucroObrigatorio);
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
                    "  public.budget_linha  " +
                    "WHERE " +
                    "  id_budget_linha = :id";
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
                        "  public.budget_linha   " +
                        "SET  " + 
                        "  id_budget = :id_budget, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  bli_valor = :bli_valor, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_budget_linha_pai = :id_budget_linha_pai "+
                        "WHERE  " +
                        "  id_budget_linha = :id " +
                        "RETURNING id_budget_linha;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.budget_linha " +
                        "( " +
                        "  id_budget , " + 
                        "  id_centro_custo_lucro , " + 
                        "  bli_valor , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_budget_linha_pai  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_budget , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :bli_valor , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_budget_linha_pai  "+
                        ")RETURNING id_budget_linha;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_budget", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Budget==null ? (object) DBNull.Value : this.Budget.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bli_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_budget_linha_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.BudgetLinhaPai==null ? (object) DBNull.Value : this.BudgetLinhaPai.ID;

 
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
 if (CollectionBudgetLinhaClassBudgetLinhaPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionBudgetLinhaClassBudgetLinhaPai+"\r\n";
                foreach (Entidades.BudgetLinhaClass tmp in CollectionBudgetLinhaClassBudgetLinhaPai)
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
        public static BudgetLinhaClass CopiarEntidade(BudgetLinhaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               BudgetLinhaClass toRet = new BudgetLinhaClass(usuario,conn);
 toRet.Budget= entidadeCopiar.Budget;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.BudgetLinhaPai= entidadeCopiar.BudgetLinhaPai;

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
       _budgetOriginal = Budget;
       _budgetOriginalCommited = _budgetOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _budgetLinhaPaiOriginal = BudgetLinhaPai;
       _budgetLinhaPaiOriginalCommited = _budgetLinhaPaiOriginal;

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
       _budgetOriginalCommited = Budget;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _valorOriginalCommited = Valor;
       _versionOriginalCommited = Version;
       _budgetLinhaPaiOriginalCommited = BudgetLinhaPai;

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
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                  if (_collectionBudgetLinhaClassBudgetLinhaPaiRemovidos != null) 
                  {
                     _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos = new List<Entidades.BudgetLinhaClass>();
                  }
                  _collectionBudgetLinhaClassBudgetLinhaPaiOriginal= (from a in _valueCollectionBudgetLinhaClassBudgetLinhaPai select a.ID).ToList();
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged = false;
                  _valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged = false;
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
               Budget=_budgetOriginal;
               _budgetOriginalCommited=_budgetOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               BudgetLinhaPai=_budgetLinhaPaiOriginal;
               _budgetLinhaPaiOriginalCommited=_budgetLinhaPaiOriginal;
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                  CollectionBudgetLinhaClassBudgetLinhaPai.Clear();
                  foreach(int item in _collectionBudgetLinhaClassBudgetLinhaPaiOriginal)
                  {
                    CollectionBudgetLinhaClassBudgetLinhaPai.Add(Entidades.BudgetLinhaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionBudgetLinhaClassBudgetLinhaPaiRemovidos.Clear();
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
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                  if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                   tempRet = CollectionBudgetLinhaClassBudgetLinhaPai.Any(item => item.IsDirty());
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
       if (_budgetOriginal!=null)
       {
          dirty = !_budgetOriginal.Equals(Budget);
       }
       else
       {
            dirty = Budget != null;
       }
      if (dirty) return true;
       if (_centroCustoLucroOriginal!=null)
       {
          dirty = !_centroCustoLucroOriginal.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_budgetLinhaPaiOriginal!=null)
       {
          dirty = !_budgetLinhaPaiOriginal.Equals(BudgetLinhaPai);
       }
       else
       {
            dirty = BudgetLinhaPai != null;
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
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                  if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                   tempRet = CollectionBudgetLinhaClassBudgetLinhaPai.Any(item => item.IsDirtyCommited());
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
       if (_budgetOriginalCommited!=null)
       {
          dirty = !_budgetOriginalCommited.Equals(Budget);
       }
       else
       {
            dirty = Budget != null;
       }
      if (dirty) return true;
       if (_centroCustoLucroOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroOriginalCommited.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_budgetLinhaPaiOriginalCommited!=null)
       {
          dirty = !_budgetLinhaPaiOriginalCommited.Equals(BudgetLinhaPai);
       }
       else
       {
            dirty = BudgetLinhaPai != null;
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
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                  foreach(BudgetLinhaClass item in CollectionBudgetLinhaClassBudgetLinhaPai)
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
             case "Budget":
                return this.Budget;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "Valor":
                return this.Valor;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "BudgetLinhaPai":
                return this.BudgetLinhaPai;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Budget!=null)
                Budget.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (BudgetLinhaPai!=null)
                BudgetLinhaPai.ChangeSingleConnection(newConnection);
               if (_valueCollectionBudgetLinhaClassBudgetLinhaPaiLoaded) 
               {
                  foreach(BudgetLinhaClass item in CollectionBudgetLinhaClassBudgetLinhaPai)
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
                  command.CommandText += " COUNT(budget_linha.id_budget_linha) " ;
               }
               else
               {
               command.CommandText += "budget_linha.id_budget_linha, " ;
               command.CommandText += "budget_linha.id_budget, " ;
               command.CommandText += "budget_linha.id_centro_custo_lucro, " ;
               command.CommandText += "budget_linha.bli_valor, " ;
               command.CommandText += "budget_linha.entity_uid, " ;
               command.CommandText += "budget_linha.version, " ;
               command.CommandText += "budget_linha.id_budget_linha_pai " ;
               }
               command.CommandText += " FROM  budget_linha ";
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
                        orderByClause += " , bli_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(bli_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = budget_linha.id_acs_usuario_ultima_revisao ";
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
                     case "id_budget_linha":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget_linha.id_budget_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget_linha.id_budget_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_budget":
                     case "Budget":
                     command.CommandText += " LEFT JOIN budget as budget_Budget ON budget_Budget.id_budget = budget_linha.id_budget ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , budget_Budget.bud_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(budget_Budget.bud_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = budget_linha.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bli_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , budget_linha.bli_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget_linha.bli_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , budget_linha.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(budget_linha.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , budget_linha.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(budget_linha.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_budget_linha_pai":
                     case "BudgetLinhaPai":
                     orderByClause += " , budget_linha.id_budget_linha_pai " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(budget_linha.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(budget_linha.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_budget_linha")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget_linha.id_budget_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.id_budget_linha = :budget_linha_ID_3238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_ID_3238", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Budget" || parametro.FieldName == "id_budget")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.BudgetClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.BudgetClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget_linha.id_budget IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.id_budget = :budget_linha_Budget_6959 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_Budget_6959", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CentroCustoLucro" || parametro.FieldName == "id_centro_custo_lucro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CentroCustoLucroClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CentroCustoLucroClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget_linha.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.id_centro_custo_lucro = :budget_linha_CentroCustoLucro_7901 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_CentroCustoLucro_7901", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "bli_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget_linha.bli_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.bli_valor = :budget_linha_Valor_8338 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_Valor_8338", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  budget_linha.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.entity_uid LIKE :budget_linha_EntityUid_9445 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_EntityUid_9445", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  budget_linha.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.version = :budget_linha_Version_5717 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_Version_5717", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BudgetLinhaPai" || parametro.FieldName == "id_budget_linha_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.BudgetLinhaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.BudgetLinhaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  budget_linha.id_budget_linha_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.id_budget_linha_pai = :budget_linha_BudgetLinhaPai_518 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_BudgetLinhaPai_518", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  budget_linha.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  budget_linha.entity_uid LIKE :budget_linha_EntityUid_4701 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("budget_linha_EntityUid_4701", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  BudgetLinhaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (BudgetLinhaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(BudgetLinhaClass), Convert.ToInt32(read["id_budget_linha"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new BudgetLinhaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_budget_linha"]);
                     if (read["id_budget"] != DBNull.Value)
                     {
                        entidade.Budget = (BibliotecaEntidades.Entidades.BudgetClass)BibliotecaEntidades.Entidades.BudgetClass.GetEntidade(Convert.ToInt32(read["id_budget"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Budget = null ;
                     }
                     if (read["id_centro_custo_lucro"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucro = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucro = null ;
                     }
                     entidade.Valor = (double)read["bli_valor"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_budget_linha_pai"] != DBNull.Value)
                     {
                        entidade.BudgetLinhaPai = (BibliotecaEntidades.Entidades.BudgetLinhaClass)BibliotecaEntidades.Entidades.BudgetLinhaClass.GetEntidade(Convert.ToInt32(read["id_budget_linha_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.BudgetLinhaPai = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (BudgetLinhaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

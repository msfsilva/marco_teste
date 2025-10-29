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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("agrupador_posto_trabalho","apt")]
     public class AgrupadorPostoTrabalhoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do AgrupadorPostoTrabalhoClass";
protected const string ErroDelete = "Erro ao excluir o AgrupadorPostoTrabalhoClass  ";
protected const string ErroSave = "Erro ao salvar o AgrupadorPostoTrabalhoClass.";
protected const string ErroCollectionPostoTrabalhoClassAgrupadorPostoTrabalho = "Erro ao carregar a coleção de PostoTrabalhoClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 50 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do AgrupadorPostoTrabalhoClass.";
protected const string MensagemUtilizadoCollectionPostoTrabalhoClassAgrupadorPostoTrabalho =  "A entidade AgrupadorPostoTrabalhoClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade AgrupadorPostoTrabalhoClass está sendo utilizada.";
#endregion
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

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("apt_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("apt_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected double _porcentagemCentroCustoOriginal{get;private set;}
       private double _porcentagemCentroCustoOriginalCommited{get; set;}
        private double _valuePorcentagemCentroCusto;
         [Column("apt_porcentagem_centro_custo")]
        public virtual double PorcentagemCentroCusto
         { 
            get { return this._valuePorcentagemCentroCusto; } 
            set 
            { 
                if (this._valuePorcentagemCentroCusto == value)return;
                 this._valuePorcentagemCentroCusto = value; 
            } 
        } 

       protected double _custoHoraAdicionalOriginal{get;private set;}
       private double _custoHoraAdicionalOriginalCommited{get; set;}
        private double _valueCustoHoraAdicional;
         [Column("apt_custo_hora_adicional")]
        public virtual double CustoHoraAdicional
         { 
            get { return this._valueCustoHoraAdicional; } 
            set 
            { 
                if (this._valueCustoHoraAdicional == value)return;
                 this._valueCustoHoraAdicional = value; 
            } 
        } 

       private List<long> _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoOriginal;
       private List<Entidades.PostoTrabalhoClass > _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PostoTrabalhoClass> _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PostoTrabalhoClass> CollectionPostoTrabalhoClassAgrupadorPostoTrabalho 
       { 
           get { if(!_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionPostoTrabalhoClassAgrupadorPostoTrabalho();}
return this._valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho; } 
           set 
           { 
               this._valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho = value; 
               this._valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded = true; 
           } 
       } 

        public AgrupadorPostoTrabalhoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.PorcentagemCentroCusto = 0;
           this.CustoHoraAdicional = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static AgrupadorPostoTrabalhoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (AgrupadorPostoTrabalhoClass) GetEntity(typeof(AgrupadorPostoTrabalhoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged = true;
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged = true; 
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged = true; 
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho) 
                 { 
                     _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPostoTrabalhoClassAgrupadorPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.PostoTrabalhoClass> oc;
                _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged = false;
                 _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged = false;
                _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos = new List<Entidades.PostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PostoTrabalhoClass>();
                }
                else{ 
                   Entidades.PostoTrabalhoClass search = new Entidades.PostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("AgrupadorPostoTrabalho", this),                     }                       ).Cast<Entidades.PostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho = new BindingList<Entidades.PostoTrabalhoClass>(oc); 
                 _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoOriginal= (from a in _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho select a.ID).ToList();
                 _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPostoTrabalhoClassAgrupadorPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Identificacao))
                {
                    throw new Exception(ErroIdentificacaoObrigatorio);
                }
                if (Identificacao.Length >50)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
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
                    "  public.agrupador_posto_trabalho  " +
                    "WHERE " +
                    "  id_agrupador_posto_trabalho = :id";
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
                        "  public.agrupador_posto_trabalho   " +
                        "SET  " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  apt_identificacao = :apt_identificacao, " + 
                        "  apt_descricao = :apt_descricao, " + 
                        "  apt_porcentagem_centro_custo = :apt_porcentagem_centro_custo, " + 
                        "  apt_ultima_revisao = :apt_ultima_revisao, " + 
                        "  apt_ultima_revisao_data = :apt_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  apt_custo_hora_adicional = :apt_custo_hora_adicional "+
                        "WHERE  " +
                        "  id_agrupador_posto_trabalho = :id " +
                        "RETURNING id_agrupador_posto_trabalho;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.agrupador_posto_trabalho " +
                        "( " +
                        "  id_centro_custo_lucro , " + 
                        "  apt_identificacao , " + 
                        "  apt_descricao , " + 
                        "  apt_porcentagem_centro_custo , " + 
                        "  apt_ultima_revisao , " + 
                        "  apt_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  apt_custo_hora_adicional  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_centro_custo_lucro , " + 
                        "  :apt_identificacao , " + 
                        "  :apt_descricao , " + 
                        "  :apt_porcentagem_centro_custo , " + 
                        "  :apt_ultima_revisao , " + 
                        "  :apt_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :apt_custo_hora_adicional  "+
                        ")RETURNING id_agrupador_posto_trabalho;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("apt_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("apt_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("apt_porcentagem_centro_custo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PorcentagemCentroCusto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("apt_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("apt_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("apt_custo_hora_adicional", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CustoHoraAdicional ?? DBNull.Value;

 
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
 if (CollectionPostoTrabalhoClassAgrupadorPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPostoTrabalhoClassAgrupadorPostoTrabalho+"\r\n";
                foreach (Entidades.PostoTrabalhoClass tmp in CollectionPostoTrabalhoClassAgrupadorPostoTrabalho)
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
        public static AgrupadorPostoTrabalhoClass CopiarEntidade(AgrupadorPostoTrabalhoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               AgrupadorPostoTrabalhoClass toRet = new AgrupadorPostoTrabalhoClass(usuario,conn);
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.PorcentagemCentroCusto= entidadeCopiar.PorcentagemCentroCusto;
 toRet.CustoHoraAdicional= entidadeCopiar.CustoHoraAdicional;

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
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _porcentagemCentroCustoOriginal = PorcentagemCentroCusto;
       _porcentagemCentroCustoOriginalCommited = _porcentagemCentroCustoOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _custoHoraAdicionalOriginal = CustoHoraAdicional;
       _custoHoraAdicionalOriginalCommited = _custoHoraAdicionalOriginal;

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
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _porcentagemCentroCustoOriginalCommited = PorcentagemCentroCusto;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _custoHoraAdicionalOriginalCommited = CustoHoraAdicional;

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
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                  if (_collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos != null) 
                  {
                     _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos = new List<Entidades.PostoTrabalhoClass>();
                  }
                  _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoOriginal= (from a in _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalho select a.ID).ToList();
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged = false;
                  _valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged = false;
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
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               PorcentagemCentroCusto=_porcentagemCentroCustoOriginal;
               _porcentagemCentroCustoOriginalCommited=_porcentagemCentroCustoOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CustoHoraAdicional=_custoHoraAdicionalOriginal;
               _custoHoraAdicionalOriginalCommited=_custoHoraAdicionalOriginal;
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                  CollectionPostoTrabalhoClassAgrupadorPostoTrabalho.Clear();
                  foreach(int item in _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoOriginal)
                  {
                    CollectionPostoTrabalhoClassAgrupadorPostoTrabalho.Add(Entidades.PostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPostoTrabalhoClassAgrupadorPostoTrabalhoRemovidos.Clear();
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
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassAgrupadorPostoTrabalho.Any(item => item.IsDirty());
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
       if (_centroCustoLucroOriginal!=null)
       {
          dirty = !_centroCustoLucroOriginal.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _porcentagemCentroCustoOriginal != PorcentagemCentroCusto;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _custoHoraAdicionalOriginal != CustoHoraAdicional;

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
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassAgrupadorPostoTrabalho.Any(item => item.IsDirtyCommited());
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
       if (_centroCustoLucroOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroOriginalCommited.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _porcentagemCentroCustoOriginalCommited != PorcentagemCentroCusto;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _custoHoraAdicionalOriginalCommited != CustoHoraAdicional;

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
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassAgrupadorPostoTrabalho)
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
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "PorcentagemCentroCusto":
                return this.PorcentagemCentroCusto;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "CustoHoraAdicional":
                return this.CustoHoraAdicional;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
               if (_valueCollectionPostoTrabalhoClassAgrupadorPostoTrabalhoLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassAgrupadorPostoTrabalho)
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
                  command.CommandText += " COUNT(agrupador_posto_trabalho.id_agrupador_posto_trabalho) " ;
               }
               else
               {
               command.CommandText += "agrupador_posto_trabalho.id_agrupador_posto_trabalho, " ;
               command.CommandText += "agrupador_posto_trabalho.id_centro_custo_lucro, " ;
               command.CommandText += "agrupador_posto_trabalho.apt_identificacao, " ;
               command.CommandText += "agrupador_posto_trabalho.apt_descricao, " ;
               command.CommandText += "agrupador_posto_trabalho.apt_porcentagem_centro_custo, " ;
               command.CommandText += "agrupador_posto_trabalho.apt_ultima_revisao, " ;
               command.CommandText += "agrupador_posto_trabalho.apt_ultima_revisao_data, " ;
               command.CommandText += "agrupador_posto_trabalho.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "agrupador_posto_trabalho.entity_uid, " ;
               command.CommandText += "agrupador_posto_trabalho.version, " ;
               command.CommandText += "agrupador_posto_trabalho.apt_custo_hora_adicional " ;
               }
               command.CommandText += " FROM  agrupador_posto_trabalho ";
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
                        orderByClause += " , apt_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(apt_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = agrupador_posto_trabalho.id_acs_usuario_ultima_revisao ";
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
                     case "id_agrupador_posto_trabalho":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_posto_trabalho.id_agrupador_posto_trabalho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.id_agrupador_posto_trabalho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = agrupador_posto_trabalho.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     case "apt_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_posto_trabalho.apt_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.apt_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "apt_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_posto_trabalho.apt_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.apt_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "apt_porcentagem_centro_custo":
                     case "PorcentagemCentroCusto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_posto_trabalho.apt_porcentagem_centro_custo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.apt_porcentagem_centro_custo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "apt_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_posto_trabalho.apt_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.apt_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "apt_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_posto_trabalho.apt_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.apt_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , agrupador_posto_trabalho.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_posto_trabalho.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , agrupador_posto_trabalho.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "apt_custo_hora_adicional":
                     case "CustoHoraAdicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_posto_trabalho.apt_custo_hora_adicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_posto_trabalho.apt_custo_hora_adicional) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("apt_identificacao")) 
                        {
                           whereClause += " OR UPPER(agrupador_posto_trabalho.apt_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_posto_trabalho.apt_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("apt_descricao")) 
                        {
                           whereClause += " OR UPPER(agrupador_posto_trabalho.apt_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_posto_trabalho.apt_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("apt_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(agrupador_posto_trabalho.apt_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_posto_trabalho.apt_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(agrupador_posto_trabalho.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_posto_trabalho.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_agrupador_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.id_agrupador_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.id_agrupador_posto_trabalho = :agrupador_posto_trabalho_ID_7697 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_ID_7697", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  agrupador_posto_trabalho.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.id_centro_custo_lucro = :agrupador_posto_trabalho_CentroCustoLucro_9052 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_CentroCustoLucro_9052", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "apt_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_identificacao LIKE :agrupador_posto_trabalho_Identificacao_9376 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_Identificacao_9376", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "apt_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_descricao LIKE :agrupador_posto_trabalho_Descricao_8020 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_Descricao_8020", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PorcentagemCentroCusto" || parametro.FieldName == "apt_porcentagem_centro_custo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_porcentagem_centro_custo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_porcentagem_centro_custo = :agrupador_posto_trabalho_PorcentagemCentroCusto_7247 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_PorcentagemCentroCusto_7247", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "apt_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_ultima_revisao LIKE :agrupador_posto_trabalho_UltimaRevisao_4986 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_UltimaRevisao_4986", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "apt_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_ultima_revisao_data = :agrupador_posto_trabalho_UltimaRevisaoData_9929 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_UltimaRevisaoData_9929", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario" || parametro.FieldName == "id_acs_usuario_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.id_acs_usuario_ultima_revisao = :agrupador_posto_trabalho_UltimaRevisaoUsuario_8908 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_UltimaRevisaoUsuario_8908", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  agrupador_posto_trabalho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.entity_uid LIKE :agrupador_posto_trabalho_EntityUid_2571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_EntityUid_2571", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  agrupador_posto_trabalho.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.version = :agrupador_posto_trabalho_Version_7612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_Version_7612", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CustoHoraAdicional" || parametro.FieldName == "apt_custo_hora_adicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_custo_hora_adicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_custo_hora_adicional = :agrupador_posto_trabalho_CustoHoraAdicional_2187 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_CustoHoraAdicional_2187", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoExato" || parametro.FieldName == "IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_identificacao LIKE :agrupador_posto_trabalho_Identificacao_1400 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_Identificacao_1400", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoExato" || parametro.FieldName == "DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_descricao LIKE :agrupador_posto_trabalho_Descricao_6613 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_Descricao_6613", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoExato" || parametro.FieldName == "UltimaRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.apt_ultima_revisao LIKE :agrupador_posto_trabalho_UltimaRevisao_4326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_UltimaRevisao_4326", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  agrupador_posto_trabalho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_posto_trabalho.entity_uid LIKE :agrupador_posto_trabalho_EntityUid_8238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_posto_trabalho_EntityUid_8238", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  AgrupadorPostoTrabalhoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (AgrupadorPostoTrabalhoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(AgrupadorPostoTrabalhoClass), Convert.ToInt32(read["id_agrupador_posto_trabalho"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new AgrupadorPostoTrabalhoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_agrupador_posto_trabalho"]);
                     if (read["id_centro_custo_lucro"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucro = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucro = null ;
                     }
                     entidade.Identificacao = (read["apt_identificacao"] != DBNull.Value ? read["apt_identificacao"].ToString() : null);
                     entidade.Descricao = (read["apt_descricao"] != DBNull.Value ? read["apt_descricao"].ToString() : null);
                     entidade.PorcentagemCentroCusto = (double)read["apt_porcentagem_centro_custo"];
                     entidade.UltimaRevisao = (read["apt_ultima_revisao"] != DBNull.Value ? read["apt_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["apt_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.CustoHoraAdicional = (double)read["apt_custo_hora_adicional"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (AgrupadorPostoTrabalhoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

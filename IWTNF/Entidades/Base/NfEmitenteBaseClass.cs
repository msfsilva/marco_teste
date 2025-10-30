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
using IWTNF.Entidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNF.Entidades.Base 
{ 
    [Serializable()]
     [Table("nf_emitente","nfe")]
     public class NfEmitenteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfEmitenteClass";
protected const string ErroDelete = "Erro ao excluir o NfEmitenteClass  ";
protected const string ErroSave = "Erro ao salvar o NfEmitenteClass.";
protected const string ErroCollectionNfEmitenteEnderecoClassNfEmitente = "Erro ao carregar a coleção de NfEmitenteEnderecoClass.";
protected const string ErroRazaoObrigatorio = "O campo Razao é obrigatório";
protected const string ErroRazaoComprimento = "O campo Razao deve ter no máximo 60 caracteres";
protected const string ErroIeObrigatorio = "O campo Ie é obrigatório";
protected const string ErroIeComprimento = "O campo Ie deve ter no máximo 14 caracteres";
protected const string ErroCnpjCpfObrigatorio = "O campo CnpjCpf é obrigatório";
protected const string ErroCnpjCpfComprimento = "O campo CnpjCpf deve ter no máximo 14 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfEmitenteClass.";
protected const string MensagemUtilizadoCollectionNfEmitenteEnderecoClassNfEmitente =  "A entidade NfEmitenteClass está sendo utilizada nos seguintes NfEmitenteEnderecoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfEmitenteClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipal;
        [Column("id_nf_principal", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipal
        { 
           get {                 return this._valueNfPrincipal; } 
           set 
           { 
                if (this._valueNfPrincipal == value)return;
                 this._valueNfPrincipal = value; 
           } 
       } 

       protected string _razaoOriginal{get;private set;}
       private string _razaoOriginalCommited{get; set;}
        private string _valueRazao;
         [Column("nfe_razao")]
        public virtual string Razao
         { 
            get { return this._valueRazao; } 
            set 
            { 
                if (this._valueRazao == value)return;
                 this._valueRazao = value; 
            } 
        } 

       protected string _nomeFantasiaOriginal{get;private set;}
       private string _nomeFantasiaOriginalCommited{get; set;}
        private string _valueNomeFantasia;
         [Column("nfe_nome_fantasia")]
        public virtual string NomeFantasia
         { 
            get { return this._valueNomeFantasia; } 
            set 
            { 
                if (this._valueNomeFantasia == value)return;
                 this._valueNomeFantasia = value; 
            } 
        } 

       protected string _ieOriginal{get;private set;}
       private string _ieOriginalCommited{get; set;}
        private string _valueIe;
         [Column("nfe_ie")]
        public virtual string Ie
         { 
            get { return this._valueIe; } 
            set 
            { 
                if (this._valueIe == value)return;
                 this._valueIe = value; 
            } 
        } 

       protected string _ieStOriginal{get;private set;}
       private string _ieStOriginalCommited{get; set;}
        private string _valueIeSt;
         [Column("nfe_ie_st")]
        public virtual string IeSt
         { 
            get { return this._valueIeSt; } 
            set 
            { 
                if (this._valueIeSt == value)return;
                 this._valueIeSt = value; 
            } 
        } 

       protected string _imOriginal{get;private set;}
       private string _imOriginalCommited{get; set;}
        private string _valueIm;
         [Column("nfe_im")]
        public virtual string Im
         { 
            get { return this._valueIm; } 
            set 
            { 
                if (this._valueIm == value)return;
                 this._valueIm = value; 
            } 
        } 

       protected string _cnaeOriginal{get;private set;}
       private string _cnaeOriginalCommited{get; set;}
        private string _valueCnae;
         [Column("nfe_cnae")]
        public virtual string Cnae
         { 
            get { return this._valueCnae; } 
            set 
            { 
                if (this._valueCnae == value)return;
                 this._valueCnae = value; 
            } 
        } 

       protected string _cnpjCpfOriginal{get;private set;}
       private string _cnpjCpfOriginalCommited{get; set;}
        private string _valueCnpjCpf;
         [Column("nfe_cnpj_cpf")]
        public virtual string CnpjCpf
         { 
            get { return this._valueCnpjCpf; } 
            set 
            { 
                if (this._valueCnpjCpf == value)return;
                 this._valueCnpjCpf = value; 
            } 
        } 

       protected int _crtOriginal{get;private set;}
       private int _crtOriginalCommited{get; set;}
        private int _valueCrt;
         [Column("nfe_crt")]
        public virtual int Crt
         { 
            get { return this._valueCrt; } 
            set 
            { 
                if (this._valueCrt == value)return;
                 this._valueCrt = value; 
            } 
        } 

       protected double _aliquotaSimplesServicoOriginal{get;private set;}
       private double _aliquotaSimplesServicoOriginalCommited{get; set;}
        private double _valueAliquotaSimplesServico;
         [Column("nfe_aliquota_simples_servico")]
        public virtual double AliquotaSimplesServico
         { 
            get { return this._valueAliquotaSimplesServico; } 
            set 
            { 
                if (this._valueAliquotaSimplesServico == value)return;
                 this._valueAliquotaSimplesServico = value; 
            } 
        } 

       protected string _identificadoCscOriginal{get;private set;}
       private string _identificadoCscOriginalCommited{get; set;}
        private string _valueIdentificadoCsc;
         [Column("nfe_identificado_csc")]
        public virtual string IdentificadoCsc
         { 
            get { return this._valueIdentificadoCsc; } 
            set 
            { 
                if (this._valueIdentificadoCsc == value)return;
                 this._valueIdentificadoCsc = value; 
            } 
        } 

       protected string _codigoSegurancaCscOriginal{get;private set;}
       private string _codigoSegurancaCscOriginalCommited{get; set;}
        private string _valueCodigoSegurancaCsc;
         [Column("nfe_codigo_seguranca_csc")]
        public virtual string CodigoSegurancaCsc
         { 
            get { return this._valueCodigoSegurancaCsc; } 
            set 
            { 
                if (this._valueCodigoSegurancaCsc == value)return;
                 this._valueCodigoSegurancaCsc = value; 
            } 
        } 

       private List<long> _collectionNfEmitenteEnderecoClassNfEmitenteOriginal;
       private List<Entidades.NfEmitenteEnderecoClass > _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfEmitenteEnderecoClass> _valueCollectionNfEmitenteEnderecoClassNfEmitente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfEmitenteEnderecoClass> CollectionNfEmitenteEnderecoClassNfEmitente 
       { 
           get { if(!_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded && !this.DisableLoadCollection){this.LoadCollectionNfEmitenteEnderecoClassNfEmitente();}
return this._valueCollectionNfEmitenteEnderecoClassNfEmitente; } 
           set 
           { 
               this._valueCollectionNfEmitenteEnderecoClassNfEmitente = value; 
               this._valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded = true; 
           } 
       } 

        public NfEmitenteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Crt = 3;
           this.AliquotaSimplesServico = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfEmitenteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfEmitenteClass) GetEntity(typeof(NfEmitenteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfEmitenteEnderecoClassNfEmitenteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged = true;
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged = true; 
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged = true;
                 foreach (Entidades.NfEmitenteEnderecoClass item in e.OldItems) 
                 { 
                     _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged = true; 
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged = true;
                 foreach (Entidades.NfEmitenteEnderecoClass item in _valueCollectionNfEmitenteEnderecoClassNfEmitente) 
                 { 
                     _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfEmitenteEnderecoClassNfEmitente()
         {
            try
            {
                 ObservableCollection<Entidades.NfEmitenteEnderecoClass> oc;
                _valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged = false;
                 _valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged = false;
                _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos = new List<Entidades.NfEmitenteEnderecoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfEmitenteEnderecoClass>();
                }
                else{ 
                   Entidades.NfEmitenteEnderecoClass search = new Entidades.NfEmitenteEnderecoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfEmitenteEnderecoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfEmitente", this)                    }                       ).Cast<Entidades.NfEmitenteEnderecoClass>().ToList());
                 }
                 _valueCollectionNfEmitenteEnderecoClassNfEmitente = new BindingList<Entidades.NfEmitenteEnderecoClass>(oc); 
                 _collectionNfEmitenteEnderecoClassNfEmitenteOriginal= (from a in _valueCollectionNfEmitenteEnderecoClassNfEmitente select a.ID).ToList();
                 _valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded = true;
                 oc.CollectionChanged += CollectionNfEmitenteEnderecoClassNfEmitenteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfEmitenteEnderecoClassNfEmitente+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Razao))
                {
                    throw new Exception(ErroRazaoObrigatorio);
                }
                if (Razao.Length >60)
                {
                    throw new Exception( ErroRazaoComprimento);
                }
                if (string.IsNullOrEmpty(Ie))
                {
                    throw new Exception(ErroIeObrigatorio);
                }
                if (Ie.Length >14)
                {
                    throw new Exception( ErroIeComprimento);
                }
                if (string.IsNullOrEmpty(CnpjCpf))
                {
                    throw new Exception(ErroCnpjCpfObrigatorio);
                }
                if (CnpjCpf.Length >14)
                {
                    throw new Exception( ErroCnpjCpfComprimento);
                }
                if ( _valueNfPrincipal == null)
                {
                    throw new Exception(ErroNfPrincipalObrigatorio);
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
                    "  public.nf_emitente  " +
                    "WHERE " +
                    "  id_nf_emitente = :id";
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
                        "  public.nf_emitente   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nfe_razao = :nfe_razao, " + 
                        "  nfe_nome_fantasia = :nfe_nome_fantasia, " + 
                        "  nfe_ie = :nfe_ie, " + 
                        "  nfe_ie_st = :nfe_ie_st, " + 
                        "  nfe_im = :nfe_im, " + 
                        "  nfe_cnae = :nfe_cnae, " + 
                        "  nfe_cnpj_cpf = :nfe_cnpj_cpf, " + 
                        "  nfe_crt = :nfe_crt, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfe_aliquota_simples_servico = :nfe_aliquota_simples_servico, " + 
                        "  nfe_identificado_csc = :nfe_identificado_csc, " + 
                        "  nfe_codigo_seguranca_csc = :nfe_codigo_seguranca_csc "+
                        "WHERE  " +
                        "  id_nf_emitente = :id " +
                        "RETURNING id_nf_emitente;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_emitente " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  nfe_razao , " + 
                        "  nfe_nome_fantasia , " + 
                        "  nfe_ie , " + 
                        "  nfe_ie_st , " + 
                        "  nfe_im , " + 
                        "  nfe_cnae , " + 
                        "  nfe_cnpj_cpf , " + 
                        "  nfe_crt , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfe_aliquota_simples_servico , " + 
                        "  nfe_identificado_csc , " + 
                        "  nfe_codigo_seguranca_csc  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :nfe_razao , " + 
                        "  :nfe_nome_fantasia , " + 
                        "  :nfe_ie , " + 
                        "  :nfe_ie_st , " + 
                        "  :nfe_im , " + 
                        "  :nfe_cnae , " + 
                        "  :nfe_cnpj_cpf , " + 
                        "  :nfe_crt , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfe_aliquota_simples_servico , " + 
                        "  :nfe_identificado_csc , " + 
                        "  :nfe_codigo_seguranca_csc  "+
                        ")RETURNING id_nf_emitente;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_razao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Razao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_nome_fantasia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeFantasia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_ie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_ie_st", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IeSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_im", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Im ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_cnae", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnae ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_cnpj_cpf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjCpf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_crt", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Crt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_aliquota_simples_servico", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaSimplesServico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_identificado_csc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdentificadoCsc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_codigo_seguranca_csc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoSegurancaCsc ?? DBNull.Value;

 
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
 if (CollectionNfEmitenteEnderecoClassNfEmitente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfEmitenteEnderecoClassNfEmitente+"\r\n";
                foreach (Entidades.NfEmitenteEnderecoClass tmp in CollectionNfEmitenteEnderecoClassNfEmitente)
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
        public static NfEmitenteClass CopiarEntidade(NfEmitenteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfEmitenteClass toRet = new NfEmitenteClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.Razao= entidadeCopiar.Razao;
 toRet.NomeFantasia= entidadeCopiar.NomeFantasia;
 toRet.Ie= entidadeCopiar.Ie;
 toRet.IeSt= entidadeCopiar.IeSt;
 toRet.Im= entidadeCopiar.Im;
 toRet.Cnae= entidadeCopiar.Cnae;
 toRet.CnpjCpf= entidadeCopiar.CnpjCpf;
 toRet.Crt= entidadeCopiar.Crt;
 toRet.AliquotaSimplesServico= entidadeCopiar.AliquotaSimplesServico;
 toRet.IdentificadoCsc= entidadeCopiar.IdentificadoCsc;
 toRet.CodigoSegurancaCsc= entidadeCopiar.CodigoSegurancaCsc;

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
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _razaoOriginal = Razao;
       _razaoOriginalCommited = _razaoOriginal;
       _nomeFantasiaOriginal = NomeFantasia;
       _nomeFantasiaOriginalCommited = _nomeFantasiaOriginal;
       _ieOriginal = Ie;
       _ieOriginalCommited = _ieOriginal;
       _ieStOriginal = IeSt;
       _ieStOriginalCommited = _ieStOriginal;
       _imOriginal = Im;
       _imOriginalCommited = _imOriginal;
       _cnaeOriginal = Cnae;
       _cnaeOriginalCommited = _cnaeOriginal;
       _cnpjCpfOriginal = CnpjCpf;
       _cnpjCpfOriginalCommited = _cnpjCpfOriginal;
       _crtOriginal = Crt;
       _crtOriginalCommited = _crtOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _aliquotaSimplesServicoOriginal = AliquotaSimplesServico;
       _aliquotaSimplesServicoOriginalCommited = _aliquotaSimplesServicoOriginal;
       _identificadoCscOriginal = IdentificadoCsc;
       _identificadoCscOriginalCommited = _identificadoCscOriginal;
       _codigoSegurancaCscOriginal = CodigoSegurancaCsc;
       _codigoSegurancaCscOriginalCommited = _codigoSegurancaCscOriginal;

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
       _nfPrincipalOriginalCommited = NfPrincipal;
       _razaoOriginalCommited = Razao;
       _nomeFantasiaOriginalCommited = NomeFantasia;
       _ieOriginalCommited = Ie;
       _ieStOriginalCommited = IeSt;
       _imOriginalCommited = Im;
       _cnaeOriginalCommited = Cnae;
       _cnpjCpfOriginalCommited = CnpjCpf;
       _crtOriginalCommited = Crt;
       _versionOriginalCommited = Version;
       _aliquotaSimplesServicoOriginalCommited = AliquotaSimplesServico;
       _identificadoCscOriginalCommited = IdentificadoCsc;
       _codigoSegurancaCscOriginalCommited = CodigoSegurancaCsc;

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
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                  if (_collectionNfEmitenteEnderecoClassNfEmitenteRemovidos != null) 
                  {
                     _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos = new List<Entidades.NfEmitenteEnderecoClass>();
                  }
                  _collectionNfEmitenteEnderecoClassNfEmitenteOriginal= (from a in _valueCollectionNfEmitenteEnderecoClassNfEmitente select a.ID).ToList();
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged = false;
                  _valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged = false;
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
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               Razao=_razaoOriginal;
               _razaoOriginalCommited=_razaoOriginal;
               NomeFantasia=_nomeFantasiaOriginal;
               _nomeFantasiaOriginalCommited=_nomeFantasiaOriginal;
               Ie=_ieOriginal;
               _ieOriginalCommited=_ieOriginal;
               IeSt=_ieStOriginal;
               _ieStOriginalCommited=_ieStOriginal;
               Im=_imOriginal;
               _imOriginalCommited=_imOriginal;
               Cnae=_cnaeOriginal;
               _cnaeOriginalCommited=_cnaeOriginal;
               CnpjCpf=_cnpjCpfOriginal;
               _cnpjCpfOriginalCommited=_cnpjCpfOriginal;
               Crt=_crtOriginal;
               _crtOriginalCommited=_crtOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               AliquotaSimplesServico=_aliquotaSimplesServicoOriginal;
               _aliquotaSimplesServicoOriginalCommited=_aliquotaSimplesServicoOriginal;
               IdentificadoCsc=_identificadoCscOriginal;
               _identificadoCscOriginalCommited=_identificadoCscOriginal;
               CodigoSegurancaCsc=_codigoSegurancaCscOriginal;
               _codigoSegurancaCscOriginalCommited=_codigoSegurancaCscOriginal;
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                  CollectionNfEmitenteEnderecoClassNfEmitente.Clear();
                  foreach(int item in _collectionNfEmitenteEnderecoClassNfEmitenteOriginal)
                  {
                    CollectionNfEmitenteEnderecoClassNfEmitente.Add(Entidades.NfEmitenteEnderecoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfEmitenteEnderecoClassNfEmitenteRemovidos.Clear();
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
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                  if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                   tempRet = CollectionNfEmitenteEnderecoClassNfEmitente.Any(item => item.IsDirty());
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
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _razaoOriginal != Razao;
      if (dirty) return true;
       dirty = _nomeFantasiaOriginal != NomeFantasia;
      if (dirty) return true;
       dirty = _ieOriginal != Ie;
      if (dirty) return true;
       dirty = _ieStOriginal != IeSt;
      if (dirty) return true;
       dirty = _imOriginal != Im;
      if (dirty) return true;
       dirty = _cnaeOriginal != Cnae;
      if (dirty) return true;
       dirty = _cnpjCpfOriginal != CnpjCpf;
      if (dirty) return true;
       dirty = _crtOriginal != Crt;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _aliquotaSimplesServicoOriginal != AliquotaSimplesServico;
      if (dirty) return true;
       dirty = _identificadoCscOriginal != IdentificadoCsc;
      if (dirty) return true;
       dirty = _codigoSegurancaCscOriginal != CodigoSegurancaCsc;

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
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                  if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                   tempRet = CollectionNfEmitenteEnderecoClassNfEmitente.Any(item => item.IsDirtyCommited());
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
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _razaoOriginalCommited != Razao;
      if (dirty) return true;
       dirty = _nomeFantasiaOriginalCommited != NomeFantasia;
      if (dirty) return true;
       dirty = _ieOriginalCommited != Ie;
      if (dirty) return true;
       dirty = _ieStOriginalCommited != IeSt;
      if (dirty) return true;
       dirty = _imOriginalCommited != Im;
      if (dirty) return true;
       dirty = _cnaeOriginalCommited != Cnae;
      if (dirty) return true;
       dirty = _cnpjCpfOriginalCommited != CnpjCpf;
      if (dirty) return true;
       dirty = _crtOriginalCommited != Crt;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _aliquotaSimplesServicoOriginalCommited != AliquotaSimplesServico;
      if (dirty) return true;
       dirty = _identificadoCscOriginalCommited != IdentificadoCsc;
      if (dirty) return true;
       dirty = _codigoSegurancaCscOriginalCommited != CodigoSegurancaCsc;

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
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                  foreach(NfEmitenteEnderecoClass item in CollectionNfEmitenteEnderecoClassNfEmitente)
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
             case "NfPrincipal":
                return this.NfPrincipal;
             case "Razao":
                return this.Razao;
             case "NomeFantasia":
                return this.NomeFantasia;
             case "Ie":
                return this.Ie;
             case "IeSt":
                return this.IeSt;
             case "Im":
                return this.Im;
             case "Cnae":
                return this.Cnae;
             case "CnpjCpf":
                return this.CnpjCpf;
             case "Crt":
                return this.Crt;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "AliquotaSimplesServico":
                return this.AliquotaSimplesServico;
             case "IdentificadoCsc":
                return this.IdentificadoCsc;
             case "CodigoSegurancaCsc":
                return this.CodigoSegurancaCsc;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
               if (_valueCollectionNfEmitenteEnderecoClassNfEmitenteLoaded) 
               {
                  foreach(NfEmitenteEnderecoClass item in CollectionNfEmitenteEnderecoClassNfEmitente)
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
                  command.CommandText += " COUNT(nf_emitente.id_nf_emitente) " ;
               }
               else
               {
               command.CommandText += "nf_emitente.id_nf_principal, " ;
               command.CommandText += "nf_emitente.nfe_razao, " ;
               command.CommandText += "nf_emitente.nfe_nome_fantasia, " ;
               command.CommandText += "nf_emitente.nfe_ie, " ;
               command.CommandText += "nf_emitente.nfe_ie_st, " ;
               command.CommandText += "nf_emitente.nfe_im, " ;
               command.CommandText += "nf_emitente.nfe_cnae, " ;
               command.CommandText += "nf_emitente.nfe_cnpj_cpf, " ;
               command.CommandText += "nf_emitente.nfe_crt, " ;
               command.CommandText += "nf_emitente.entity_uid, " ;
               command.CommandText += "nf_emitente.version, " ;
               command.CommandText += "nf_emitente.id_nf_emitente, " ;
               command.CommandText += "nf_emitente.nfe_aliquota_simples_servico, " ;
               command.CommandText += "nf_emitente.nfe_identificado_csc, " ;
               command.CommandText += "nf_emitente.nfe_codigo_seguranca_csc " ;
               }
               command.CommandText += " FROM  nf_emitente ";
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
                        orderByClause += " , nfe_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfe_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_emitente.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_principal":
                     case "NfPrincipal":
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_emitente.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal_NfPrincipal.nfp_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal_NfPrincipal.nfp_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_razao":
                     case "Razao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_razao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_razao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_nome_fantasia":
                     case "NomeFantasia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_ie":
                     case "Ie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_ie_st":
                     case "IeSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_ie_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_ie_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_im":
                     case "Im":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_im " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_im) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_cnae":
                     case "Cnae":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_cnae " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_cnae) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_cnpj_cpf":
                     case "CnpjCpf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_cnpj_cpf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_cnpj_cpf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_crt":
                     case "Crt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_emitente.nfe_crt " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_emitente.nfe_crt) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_emitente.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_emitente.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_emitente":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_emitente.id_nf_emitente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_emitente.id_nf_emitente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_aliquota_simples_servico":
                     case "AliquotaSimplesServico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_emitente.nfe_aliquota_simples_servico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_emitente.nfe_aliquota_simples_servico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_identificado_csc":
                     case "IdentificadoCsc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_identificado_csc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_identificado_csc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfe_codigo_seguranca_csc":
                     case "CodigoSegurancaCsc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_emitente.nfe_codigo_seguranca_csc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_emitente.nfe_codigo_seguranca_csc) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_razao")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_razao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_razao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_nome_fantasia")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_nome_fantasia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_nome_fantasia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_ie")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_ie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_ie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_ie_st")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_ie_st) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_ie_st) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_im")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_im) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_im) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_cnae")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_cnae) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_cnae) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_cnpj_cpf")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_cnpj_cpf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_cnpj_cpf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_identificado_csc")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_identificado_csc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_identificado_csc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfe_codigo_seguranca_csc")) 
                        {
                           whereClause += " OR UPPER(nf_emitente.nfe_codigo_seguranca_csc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_emitente.nfe_codigo_seguranca_csc) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.id_nf_principal = :nf_emitente_NfPrincipal_454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_NfPrincipal_454", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Razao" || parametro.FieldName == "nfe_razao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_razao LIKE :nf_emitente_Razao_4420 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Razao_4420", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasia" || parametro.FieldName == "nfe_nome_fantasia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_nome_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_nome_fantasia LIKE :nf_emitente_NomeFantasia_3707 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_NomeFantasia_3707", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ie" || parametro.FieldName == "nfe_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_ie LIKE :nf_emitente_Ie_869 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Ie_869", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeSt" || parametro.FieldName == "nfe_ie_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_ie_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_ie_st LIKE :nf_emitente_IeSt_3723 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_IeSt_3723", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Im" || parametro.FieldName == "nfe_im")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_im IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_im LIKE :nf_emitente_Im_9825 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Im_9825", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnae" || parametro.FieldName == "nfe_cnae")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_cnae IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_cnae LIKE :nf_emitente_Cnae_3550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Cnae_3550", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCpf" || parametro.FieldName == "nfe_cnpj_cpf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_cnpj_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_cnpj_cpf LIKE :nf_emitente_CnpjCpf_8938 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_CnpjCpf_8938", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Crt" || parametro.FieldName == "nfe_crt")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_crt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_crt = :nf_emitente_Crt_3622 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Crt_3622", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_emitente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.entity_uid LIKE :nf_emitente_EntityUid_3961 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_EntityUid_3961", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_emitente.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.version = :nf_emitente_Version_8628 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Version_8628", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_emitente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.id_nf_emitente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.id_nf_emitente = :nf_emitente_ID_5501 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_ID_5501", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaSimplesServico" || parametro.FieldName == "nfe_aliquota_simples_servico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_aliquota_simples_servico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_aliquota_simples_servico = :nf_emitente_AliquotaSimplesServico_5553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_AliquotaSimplesServico_5553", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificadoCsc" || parametro.FieldName == "nfe_identificado_csc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_identificado_csc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_identificado_csc LIKE :nf_emitente_IdentificadoCsc_2703 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_IdentificadoCsc_2703", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoSegurancaCsc" || parametro.FieldName == "nfe_codigo_seguranca_csc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_codigo_seguranca_csc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_codigo_seguranca_csc LIKE :nf_emitente_CodigoSegurancaCsc_7812 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_CodigoSegurancaCsc_7812", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoExato" || parametro.FieldName == "RazaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_razao LIKE :nf_emitente_Razao_2046 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Razao_2046", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasiaExato" || parametro.FieldName == "NomeFantasiaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_nome_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_nome_fantasia LIKE :nf_emitente_NomeFantasia_3042 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_NomeFantasia_3042", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeExato" || parametro.FieldName == "IeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_ie LIKE :nf_emitente_Ie_9761 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Ie_9761", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeStExato" || parametro.FieldName == "IeStExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_ie_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_ie_st LIKE :nf_emitente_IeSt_6754 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_IeSt_6754", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImExato" || parametro.FieldName == "ImExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_im IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_im LIKE :nf_emitente_Im_3989 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Im_3989", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnaeExato" || parametro.FieldName == "CnaeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_cnae IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_cnae LIKE :nf_emitente_Cnae_6706 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_Cnae_6706", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCpfExato" || parametro.FieldName == "CnpjCpfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_cnpj_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_cnpj_cpf LIKE :nf_emitente_CnpjCpf_4719 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_CnpjCpf_4719", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_emitente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.entity_uid LIKE :nf_emitente_EntityUid_8992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_EntityUid_8992", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificadoCscExato" || parametro.FieldName == "IdentificadoCscExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_identificado_csc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_identificado_csc LIKE :nf_emitente_IdentificadoCsc_3394 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_IdentificadoCsc_3394", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoSegurancaCscExato" || parametro.FieldName == "CodigoSegurancaCscExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_emitente.nfe_codigo_seguranca_csc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_emitente.nfe_codigo_seguranca_csc LIKE :nf_emitente_CodigoSegurancaCsc_1366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_emitente_CodigoSegurancaCsc_1366", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfEmitenteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfEmitenteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfEmitenteClass), Convert.ToInt32(read["id_nf_emitente"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfEmitenteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.Razao = (read["nfe_razao"] != DBNull.Value ? read["nfe_razao"].ToString() : null);
                     entidade.NomeFantasia = (read["nfe_nome_fantasia"] != DBNull.Value ? read["nfe_nome_fantasia"].ToString() : null);
                     entidade.Ie = (read["nfe_ie"] != DBNull.Value ? read["nfe_ie"].ToString() : null);
                     entidade.IeSt = (read["nfe_ie_st"] != DBNull.Value ? read["nfe_ie_st"].ToString() : null);
                     entidade.Im = (read["nfe_im"] != DBNull.Value ? read["nfe_im"].ToString() : null);
                     entidade.Cnae = (read["nfe_cnae"] != DBNull.Value ? read["nfe_cnae"].ToString() : null);
                     entidade.CnpjCpf = (read["nfe_cnpj_cpf"] != DBNull.Value ? read["nfe_cnpj_cpf"].ToString() : null);
                     entidade.Crt = (int)read["nfe_crt"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_emitente"]);
                     entidade.AliquotaSimplesServico = (double)read["nfe_aliquota_simples_servico"];
                     entidade.IdentificadoCsc = (read["nfe_identificado_csc"] != DBNull.Value ? read["nfe_identificado_csc"].ToString() : null);
                     entidade.CodigoSegurancaCsc = (read["nfe_codigo_seguranca_csc"] != DBNull.Value ? read["nfe_codigo_seguranca_csc"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfEmitenteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

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
     [Table("nf_cliente","nfc")]
     public class NfClienteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfClienteClass";
protected const string ErroDelete = "Erro ao excluir o NfClienteClass  ";
protected const string ErroSave = "Erro ao salvar o NfClienteClass.";
protected const string ErroRazaoObrigatorio = "O campo Razao é obrigatório";
protected const string ErroRazaoComprimento = "O campo Razao deve ter no máximo 60 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfClienteClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfClienteClass está sendo utilizada.";
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
         [Column("nfc_razao")]
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
         [Column("nfc_nome_fantasia")]
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
         [Column("nfc_ie")]
        public virtual string Ie
         { 
            get { return this._valueIe; } 
            set 
            { 
                if (this._valueIe == value)return;
                 this._valueIe = value; 
            } 
        } 

       protected string _cnpjCpfOriginal{get;private set;}
       private string _cnpjCpfOriginalCommited{get; set;}
        private string _valueCnpjCpf;
         [Column("nfc_cnpj_cpf")]
        public virtual string CnpjCpf
         { 
            get { return this._valueCnpjCpf; } 
            set 
            { 
                if (this._valueCnpjCpf == value)return;
                 this._valueCnpjCpf = value; 
            } 
        } 

       protected string _isufOriginal{get;private set;}
       private string _isufOriginalCommited{get; set;}
        private string _valueIsuf;
         [Column("nfc_isuf")]
        public virtual string Isuf
         { 
            get { return this._valueIsuf; } 
            set 
            { 
                if (this._valueIsuf == value)return;
                 this._valueIsuf = value; 
            } 
        } 

       protected string _emailOriginal{get;private set;}
       private string _emailOriginalCommited{get; set;}
        private string _valueEmail;
         [Column("nfc_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       protected string _imOriginal{get;private set;}
       private string _imOriginalCommited{get; set;}
        private string _valueIm;
         [Column("nfc_im")]
        public virtual string Im
         { 
            get { return this._valueIm; } 
            set 
            { 
                if (this._valueIm == value)return;
                 this._valueIm = value; 
            } 
        } 

       protected IWTNFIndicadorIE? _indicadorIeOriginal{get;private set;}
       private IWTNFIndicadorIE? _indicadorIeOriginalCommited{get; set;}
        private IWTNFIndicadorIE? _valueIndicadorIe;
         [Column("nfc_indicador_ie")]
        public virtual IWTNFIndicadorIE? IndicadorIe
         { 
            get { return this._valueIndicadorIe; } 
            set 
            { 
                if (this._valueIndicadorIe == value)return;
                 this._valueIndicadorIe = value; 
            } 
        } 

        public bool IndicadorIe_ContribuinteICMS
         { 
            get { return this._valueIndicadorIe.HasValue && this._valueIndicadorIe.Value == IWTNF.Entidades.Base.IWTNFIndicadorIE.ContribuinteICMS; } 
            set { if (value) this._valueIndicadorIe = IWTNF.Entidades.Base.IWTNFIndicadorIE.ContribuinteICMS; }
         } 

        public bool IndicadorIe_Isento
         { 
            get { return this._valueIndicadorIe.HasValue && this._valueIndicadorIe.Value == IWTNF.Entidades.Base.IWTNFIndicadorIE.Isento; } 
            set { if (value) this._valueIndicadorIe = IWTNF.Entidades.Base.IWTNFIndicadorIE.Isento; }
         } 

        public bool IndicadorIe_NaoContribuinte
         { 
            get { return this._valueIndicadorIe.HasValue && this._valueIndicadorIe.Value == IWTNF.Entidades.Base.IWTNFIndicadorIE.NaoContribuinte; } 
            set { if (value) this._valueIndicadorIe = IWTNF.Entidades.Base.IWTNFIndicadorIE.NaoContribuinte; }
         } 

       protected string _emailXmlOriginal{get;private set;}
       private string _emailXmlOriginalCommited{get; set;}
        private string _valueEmailXml;
         [Column("nfc_email_xml")]
        public virtual string EmailXml
         { 
            get { return this._valueEmailXml; } 
            set 
            { 
                if (this._valueEmailXml == value)return;
                 this._valueEmailXml = value; 
            } 
        } 

       protected string _emailDanfeOriginal{get;private set;}
       private string _emailDanfeOriginalCommited{get; set;}
        private string _valueEmailDanfe;
         [Column("nfc_email_danfe")]
        public virtual string EmailDanfe
         { 
            get { return this._valueEmailDanfe; } 
            set 
            { 
                if (this._valueEmailDanfe == value)return;
                 this._valueEmailDanfe = value; 
            } 
        } 

        public NfClienteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfClienteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfClienteClass) GetEntity(typeof(NfClienteClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_cliente  " +
                    "WHERE " +
                    "  id_nf_cliente = :id";
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
                        "  public.nf_cliente   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nfc_razao = :nfc_razao, " + 
                        "  nfc_nome_fantasia = :nfc_nome_fantasia, " + 
                        "  nfc_ie = :nfc_ie, " + 
                        "  nfc_cnpj_cpf = :nfc_cnpj_cpf, " + 
                        "  nfc_isuf = :nfc_isuf, " + 
                        "  nfc_email = :nfc_email, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfc_im = :nfc_im, " + 
                        "  nfc_indicador_ie = :nfc_indicador_ie, " + 
                        "  nfc_email_xml = :nfc_email_xml, " + 
                        "  nfc_email_danfe = :nfc_email_danfe "+
                        "WHERE  " +
                        "  id_nf_cliente = :id " +
                        "RETURNING id_nf_cliente;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_cliente " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  nfc_razao , " + 
                        "  nfc_nome_fantasia , " + 
                        "  nfc_ie , " + 
                        "  nfc_cnpj_cpf , " + 
                        "  nfc_isuf , " + 
                        "  nfc_email , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfc_im , " + 
                        "  nfc_indicador_ie , " + 
                        "  nfc_email_xml , " + 
                        "  nfc_email_danfe  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :nfc_razao , " + 
                        "  :nfc_nome_fantasia , " + 
                        "  :nfc_ie , " + 
                        "  :nfc_cnpj_cpf , " + 
                        "  :nfc_isuf , " + 
                        "  :nfc_email , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfc_im , " + 
                        "  :nfc_indicador_ie , " + 
                        "  :nfc_email_xml , " + 
                        "  :nfc_email_danfe  "+
                        ")RETURNING id_nf_cliente;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_razao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Razao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_nome_fantasia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeFantasia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_ie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_cnpj_cpf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjCpf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_isuf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Isuf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_im", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Im ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_indicador_ie", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.IndicadorIe.HasValue ? (object)Convert.ToInt16(this.IndicadorIe) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_email_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailXml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_email_danfe", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmailDanfe ?? DBNull.Value;

 
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
        public static NfClienteClass CopiarEntidade(NfClienteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfClienteClass toRet = new NfClienteClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.Razao= entidadeCopiar.Razao;
 toRet.NomeFantasia= entidadeCopiar.NomeFantasia;
 toRet.Ie= entidadeCopiar.Ie;
 toRet.CnpjCpf= entidadeCopiar.CnpjCpf;
 toRet.Isuf= entidadeCopiar.Isuf;
 toRet.Email= entidadeCopiar.Email;
 toRet.Im= entidadeCopiar.Im;
 toRet.IndicadorIe= entidadeCopiar.IndicadorIe;
 toRet.EmailXml= entidadeCopiar.EmailXml;
 toRet.EmailDanfe= entidadeCopiar.EmailDanfe;

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
       _cnpjCpfOriginal = CnpjCpf;
       _cnpjCpfOriginalCommited = _cnpjCpfOriginal;
       _isufOriginal = Isuf;
       _isufOriginalCommited = _isufOriginal;
       _emailOriginal = Email;
       _emailOriginalCommited = _emailOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _imOriginal = Im;
       _imOriginalCommited = _imOriginal;
       _indicadorIeOriginal = IndicadorIe;
       _indicadorIeOriginalCommited = _indicadorIeOriginal;
       _emailXmlOriginal = EmailXml;
       _emailXmlOriginalCommited = _emailXmlOriginal;
       _emailDanfeOriginal = EmailDanfe;
       _emailDanfeOriginalCommited = _emailDanfeOriginal;

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
       _cnpjCpfOriginalCommited = CnpjCpf;
       _isufOriginalCommited = Isuf;
       _emailOriginalCommited = Email;
       _versionOriginalCommited = Version;
       _imOriginalCommited = Im;
       _indicadorIeOriginalCommited = IndicadorIe;
       _emailXmlOriginalCommited = EmailXml;
       _emailDanfeOriginalCommited = EmailDanfe;

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
               CnpjCpf=_cnpjCpfOriginal;
               _cnpjCpfOriginalCommited=_cnpjCpfOriginal;
               Isuf=_isufOriginal;
               _isufOriginalCommited=_isufOriginal;
               Email=_emailOriginal;
               _emailOriginalCommited=_emailOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Im=_imOriginal;
               _imOriginalCommited=_imOriginal;
               IndicadorIe=_indicadorIeOriginal;
               _indicadorIeOriginalCommited=_indicadorIeOriginal;
               EmailXml=_emailXmlOriginal;
               _emailXmlOriginalCommited=_emailXmlOriginal;
               EmailDanfe=_emailDanfeOriginal;
               _emailDanfeOriginalCommited=_emailDanfeOriginal;

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
       dirty = _cnpjCpfOriginal != CnpjCpf;
      if (dirty) return true;
       dirty = _isufOriginal != Isuf;
      if (dirty) return true;
       dirty = _emailOriginal != Email;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _imOriginal != Im;
      if (dirty) return true;
       dirty = _indicadorIeOriginal != IndicadorIe;
      if (dirty) return true;
       dirty = _emailXmlOriginal != EmailXml;
      if (dirty) return true;
       dirty = _emailDanfeOriginal != EmailDanfe;

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
       dirty = _cnpjCpfOriginalCommited != CnpjCpf;
      if (dirty) return true;
       dirty = _isufOriginalCommited != Isuf;
      if (dirty) return true;
       dirty = _emailOriginalCommited != Email;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _imOriginalCommited != Im;
      if (dirty) return true;
       dirty = _indicadorIeOriginalCommited != IndicadorIe;
      if (dirty) return true;
       dirty = _emailXmlOriginalCommited != EmailXml;
      if (dirty) return true;
       dirty = _emailDanfeOriginalCommited != EmailDanfe;

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
             case "NfPrincipal":
                return this.NfPrincipal;
             case "Razao":
                return this.Razao;
             case "NomeFantasia":
                return this.NomeFantasia;
             case "Ie":
                return this.Ie;
             case "CnpjCpf":
                return this.CnpjCpf;
             case "Isuf":
                return this.Isuf;
             case "Email":
                return this.Email;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Im":
                return this.Im;
             case "IndicadorIe":
                return this.IndicadorIe;
             case "EmailXml":
                return this.EmailXml;
             case "EmailDanfe":
                return this.EmailDanfe;
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
                  command.CommandText += " COUNT(nf_cliente.id_nf_cliente) " ;
               }
               else
               {
               command.CommandText += "nf_cliente.id_nf_principal, " ;
               command.CommandText += "nf_cliente.nfc_razao, " ;
               command.CommandText += "nf_cliente.nfc_nome_fantasia, " ;
               command.CommandText += "nf_cliente.nfc_ie, " ;
               command.CommandText += "nf_cliente.nfc_cnpj_cpf, " ;
               command.CommandText += "nf_cliente.nfc_isuf, " ;
               command.CommandText += "nf_cliente.nfc_email, " ;
               command.CommandText += "nf_cliente.entity_uid, " ;
               command.CommandText += "nf_cliente.version, " ;
               command.CommandText += "nf_cliente.id_nf_cliente, " ;
               command.CommandText += "nf_cliente.nfc_im, " ;
               command.CommandText += "nf_cliente.nfc_indicador_ie, " ;
               command.CommandText += "nf_cliente.nfc_email_xml, " ;
               command.CommandText += "nf_cliente.nfc_email_danfe " ;
               }
               command.CommandText += " FROM  nf_cliente ";
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
                        orderByClause += " , nfc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_cliente.id_acs_usuario_ultima_revisao ";
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
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_cliente.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
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
                     case "nfc_razao":
                     case "Razao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_razao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_razao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_nome_fantasia":
                     case "NomeFantasia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_ie":
                     case "Ie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_cnpj_cpf":
                     case "CnpjCpf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_cnpj_cpf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_cnpj_cpf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_isuf":
                     case "Isuf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_isuf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_isuf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_cliente.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_cliente":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_cliente.id_nf_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente.id_nf_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_im":
                     case "Im":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_im " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_im) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_indicador_ie":
                     case "IndicadorIe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_cliente.nfc_indicador_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente.nfc_indicador_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_email_xml":
                     case "EmailXml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_email_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_email_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_email_danfe":
                     case "EmailDanfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente.nfc_email_danfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente.nfc_email_danfe) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_razao")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_razao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_razao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_nome_fantasia")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_nome_fantasia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_nome_fantasia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_ie")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_ie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_ie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_cnpj_cpf")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_cnpj_cpf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_cnpj_cpf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_isuf")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_isuf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_isuf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_email")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_im")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_im) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_im) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_email_xml")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_email_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_email_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfc_email_danfe")) 
                        {
                           whereClause += " OR UPPER(nf_cliente.nfc_email_danfe) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente.nfc_email_danfe) LIKE :buscaCompletaLower ";
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
                         whereClause += "  nf_cliente.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.id_nf_principal = :nf_cliente_NfPrincipal_9720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_NfPrincipal_9720", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Razao" || parametro.FieldName == "nfc_razao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_razao LIKE :nf_cliente_Razao_6788 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Razao_6788", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeFantasia" || parametro.FieldName == "nfc_nome_fantasia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_nome_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_nome_fantasia LIKE :nf_cliente_NomeFantasia_3799 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_NomeFantasia_3799", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ie" || parametro.FieldName == "nfc_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_ie LIKE :nf_cliente_Ie_8265 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Ie_8265", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCpf" || parametro.FieldName == "nfc_cnpj_cpf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_cnpj_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_cnpj_cpf LIKE :nf_cliente_CnpjCpf_2422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_CnpjCpf_2422", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Isuf" || parametro.FieldName == "nfc_isuf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_isuf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_isuf LIKE :nf_cliente_Isuf_3853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Isuf_3853", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "nfc_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_email LIKE :nf_cliente_Email_5992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Email_5992", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_cliente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.entity_uid LIKE :nf_cliente_EntityUid_1446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_EntityUid_1446", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_cliente.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.version = :nf_cliente_Version_2779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Version_2779", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.id_nf_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.id_nf_cliente = :nf_cliente_ID_5279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_ID_5279", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Im" || parametro.FieldName == "nfc_im")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_im IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_im LIKE :nf_cliente_Im_5377 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Im_5377", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndicadorIe" || parametro.FieldName == "nfc_indicador_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFIndicadorIE?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFIndicadorIE?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_indicador_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_indicador_ie = :nf_cliente_IndicadorIe_6378 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_IndicadorIe_6378", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailXml" || parametro.FieldName == "nfc_email_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_email_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_email_xml LIKE :nf_cliente_EmailXml_6446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_EmailXml_6446", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailDanfe" || parametro.FieldName == "nfc_email_danfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_email_danfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_email_danfe LIKE :nf_cliente_EmailDanfe_4227 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_EmailDanfe_4227", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_cliente.nfc_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_razao LIKE :nf_cliente_Razao_1895 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Razao_1895", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_cliente.nfc_nome_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_nome_fantasia LIKE :nf_cliente_NomeFantasia_386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_NomeFantasia_386", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_cliente.nfc_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_ie LIKE :nf_cliente_Ie_6953 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Ie_6953", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_cliente.nfc_cnpj_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_cnpj_cpf LIKE :nf_cliente_CnpjCpf_7267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_CnpjCpf_7267", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IsufExato" || parametro.FieldName == "IsufExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_isuf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_isuf LIKE :nf_cliente_Isuf_4412 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Isuf_4412", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailExato" || parametro.FieldName == "EmailExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_email LIKE :nf_cliente_Email_7054 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Email_7054", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_cliente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.entity_uid LIKE :nf_cliente_EntityUid_5604 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_EntityUid_5604", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_cliente.nfc_im IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_im LIKE :nf_cliente_Im_4482 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_Im_4482", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailXmlExato" || parametro.FieldName == "EmailXmlExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_email_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_email_xml LIKE :nf_cliente_EmailXml_5347 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_EmailXml_5347", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailDanfeExato" || parametro.FieldName == "EmailDanfeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente.nfc_email_danfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente.nfc_email_danfe LIKE :nf_cliente_EmailDanfe_9829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_EmailDanfe_9829", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfClienteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfClienteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfClienteClass), Convert.ToInt32(read["id_nf_cliente"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfClienteClass(UsuarioAtual, SingleConnection);
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
                     entidade.Razao = (read["nfc_razao"] != DBNull.Value ? read["nfc_razao"].ToString() : null);
                     entidade.NomeFantasia = (read["nfc_nome_fantasia"] != DBNull.Value ? read["nfc_nome_fantasia"].ToString() : null);
                     entidade.Ie = (read["nfc_ie"] != DBNull.Value ? read["nfc_ie"].ToString() : null);
                     entidade.CnpjCpf = (read["nfc_cnpj_cpf"] != DBNull.Value ? read["nfc_cnpj_cpf"].ToString() : null);
                     entidade.Isuf = (read["nfc_isuf"] != DBNull.Value ? read["nfc_isuf"].ToString() : null);
                     entidade.Email = (read["nfc_email"] != DBNull.Value ? read["nfc_email"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_cliente"]);
                     entidade.Im = (read["nfc_im"] != DBNull.Value ? read["nfc_im"].ToString() : null);
                     entidade.IndicadorIe = (IWTNFIndicadorIE?) (read["nfc_indicador_ie"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IWTNFIndicadorIE?)), read["nfc_indicador_ie"]) : null);
                     entidade.EmailXml = (read["nfc_email_xml"] != DBNull.Value ? read["nfc_email_xml"].ToString() : null);
                     entidade.EmailDanfe = (read["nfc_email_danfe"] != DBNull.Value ? read["nfc_email_danfe"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfClienteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

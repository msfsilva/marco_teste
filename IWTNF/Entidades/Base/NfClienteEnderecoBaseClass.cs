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
     [Table("nf_cliente_endereco","nce")]
     public class NfClienteEnderecoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfClienteEnderecoClass";
protected const string ErroDelete = "Erro ao excluir o NfClienteEnderecoClass  ";
protected const string ErroSave = "Erro ao salvar o NfClienteEnderecoClass.";
protected const string ErroLogradouroObrigatorio = "O campo Logradouro é obrigatório";
protected const string ErroLogradouroComprimento = "O campo Logradouro deve ter no máximo 60 caracteres";
protected const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 60 caracteres";
protected const string ErroBairroObrigatorio = "O campo Bairro é obrigatório";
protected const string ErroBairroComprimento = "O campo Bairro deve ter no máximo 60 caracteres";
protected const string ErroSiglaUfObrigatorio = "O campo SiglaUf é obrigatório";
protected const string ErroSiglaUfComprimento = "O campo SiglaUf deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfClienteEnderecoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfClienteEnderecoClass está sendo utilizada.";
#endregion
       protected string _logradouroOriginal{get;private set;}
       private string _logradouroOriginalCommited{get; set;}
        private string _valueLogradouro;
         [Column("nce_logradouro")]
        public virtual string Logradouro
         { 
            get { return this._valueLogradouro; } 
            set 
            { 
                if (this._valueLogradouro == value)return;
                 this._valueLogradouro = value; 
            } 
        } 

       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("nce_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected string _complementoOriginal{get;private set;}
       private string _complementoOriginalCommited{get; set;}
        private string _valueComplemento;
         [Column("nce_complemento")]
        public virtual string Complemento
         { 
            get { return this._valueComplemento; } 
            set 
            { 
                if (this._valueComplemento == value)return;
                 this._valueComplemento = value; 
            } 
        } 

       protected string _bairroOriginal{get;private set;}
       private string _bairroOriginalCommited{get; set;}
        private string _valueBairro;
         [Column("nce_bairro")]
        public virtual string Bairro
         { 
            get { return this._valueBairro; } 
            set 
            { 
                if (this._valueBairro == value)return;
                 this._valueBairro = value; 
            } 
        } 

       protected int _codMunicipioOriginal{get;private set;}
       private int _codMunicipioOriginalCommited{get; set;}
        private int _valueCodMunicipio;
         [Column("nce_cod_municipio")]
        public virtual int CodMunicipio
         { 
            get { return this._valueCodMunicipio; } 
            set 
            { 
                if (this._valueCodMunicipio == value)return;
                 this._valueCodMunicipio = value; 
            } 
        } 

       protected string _nomeMunicipioOriginal{get;private set;}
       private string _nomeMunicipioOriginalCommited{get; set;}
        private string _valueNomeMunicipio;
         [Column("nce_nome_municipio")]
        public virtual string NomeMunicipio
         { 
            get { return this._valueNomeMunicipio; } 
            set 
            { 
                if (this._valueNomeMunicipio == value)return;
                 this._valueNomeMunicipio = value; 
            } 
        } 

       protected string _siglaUfOriginal{get;private set;}
       private string _siglaUfOriginalCommited{get; set;}
        private string _valueSiglaUf;
         [Column("nce_sigla_uf")]
        public virtual string SiglaUf
         { 
            get { return this._valueSiglaUf; } 
            set 
            { 
                if (this._valueSiglaUf == value)return;
                 this._valueSiglaUf = value; 
            } 
        } 

       protected string _cepOriginal{get;private set;}
       private string _cepOriginalCommited{get; set;}
        private string _valueCep;
         [Column("nce_cep")]
        public virtual string Cep
         { 
            get { return this._valueCep; } 
            set 
            { 
                if (this._valueCep == value)return;
                 this._valueCep = value; 
            } 
        } 

       protected int _codPaisOriginal{get;private set;}
       private int _codPaisOriginalCommited{get; set;}
        private int _valueCodPais;
         [Column("nce_cod_pais")]
        public virtual int CodPais
         { 
            get { return this._valueCodPais; } 
            set 
            { 
                if (this._valueCodPais == value)return;
                 this._valueCodPais = value; 
            } 
        } 

       protected string _nomePaisOriginal{get;private set;}
       private string _nomePaisOriginalCommited{get; set;}
        private string _valueNomePais;
         [Column("nce_nome_pais")]
        public virtual string NomePais
         { 
            get { return this._valueNomePais; } 
            set 
            { 
                if (this._valueNomePais == value)return;
                 this._valueNomePais = value; 
            } 
        } 

       protected string _telefoneOriginal{get;private set;}
       private string _telefoneOriginalCommited{get; set;}
        private string _valueTelefone;
         [Column("nce_telefone")]
        public virtual string Telefone
         { 
            get { return this._valueTelefone; } 
            set 
            { 
                if (this._valueTelefone == value)return;
                 this._valueTelefone = value; 
            } 
        } 

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

        public NfClienteEnderecoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfClienteEnderecoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfClienteEnderecoClass) GetEntity(typeof(NfClienteEnderecoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Logradouro))
                {
                    throw new Exception(ErroLogradouroObrigatorio);
                }
                if (Logradouro.Length >60)
                {
                    throw new Exception( ErroLogradouroComprimento);
                }
                if (string.IsNullOrEmpty(Numero))
                {
                    throw new Exception(ErroNumeroObrigatorio);
                }
                if (Numero.Length >60)
                {
                    throw new Exception( ErroNumeroComprimento);
                }
                if (string.IsNullOrEmpty(Bairro))
                {
                    throw new Exception(ErroBairroObrigatorio);
                }
                if (Bairro.Length >60)
                {
                    throw new Exception( ErroBairroComprimento);
                }
                if (string.IsNullOrEmpty(SiglaUf))
                {
                    throw new Exception(ErroSiglaUfObrigatorio);
                }
                if (SiglaUf.Length >2)
                {
                    throw new Exception( ErroSiglaUfComprimento);
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
                    "  public.nf_cliente_endereco  " +
                    "WHERE " +
                    "  id_nf_cliente_endereco = :id";
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
                        "  public.nf_cliente_endereco   " +
                        "SET  " + 
                        "  nce_logradouro = :nce_logradouro, " + 
                        "  nce_numero = :nce_numero, " + 
                        "  nce_complemento = :nce_complemento, " + 
                        "  nce_bairro = :nce_bairro, " + 
                        "  nce_cod_municipio = :nce_cod_municipio, " + 
                        "  nce_nome_municipio = :nce_nome_municipio, " + 
                        "  nce_sigla_uf = :nce_sigla_uf, " + 
                        "  nce_cep = :nce_cep, " + 
                        "  nce_cod_pais = :nce_cod_pais, " + 
                        "  nce_nome_pais = :nce_nome_pais, " + 
                        "  nce_telefone = :nce_telefone, " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_nf_cliente_endereco = :id " +
                        "RETURNING id_nf_cliente_endereco;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_cliente_endereco " +
                        "( " +
                        "  nce_logradouro , " + 
                        "  nce_numero , " + 
                        "  nce_complemento , " + 
                        "  nce_bairro , " + 
                        "  nce_cod_municipio , " + 
                        "  nce_nome_municipio , " + 
                        "  nce_sigla_uf , " + 
                        "  nce_cep , " + 
                        "  nce_cod_pais , " + 
                        "  nce_nome_pais , " + 
                        "  nce_telefone , " + 
                        "  id_nf_principal , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :nce_logradouro , " + 
                        "  :nce_numero , " + 
                        "  :nce_complemento , " + 
                        "  :nce_bairro , " + 
                        "  :nce_cod_municipio , " + 
                        "  :nce_nome_municipio , " + 
                        "  :nce_sigla_uf , " + 
                        "  :nce_cep , " + 
                        "  :nce_cod_pais , " + 
                        "  :nce_nome_pais , " + 
                        "  :nce_telefone , " + 
                        "  :id_nf_principal , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_nf_cliente_endereco;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_logradouro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Logradouro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_complemento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Complemento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_bairro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bairro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_cod_municipio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodMunicipio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_nome_municipio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeMunicipio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_sigla_uf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_cep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_cod_pais", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodPais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_nome_pais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomePais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nce_telefone", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Telefone ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
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
        public static NfClienteEnderecoClass CopiarEntidade(NfClienteEnderecoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfClienteEnderecoClass toRet = new NfClienteEnderecoClass(usuario,conn);
 toRet.Logradouro= entidadeCopiar.Logradouro;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Complemento= entidadeCopiar.Complemento;
 toRet.Bairro= entidadeCopiar.Bairro;
 toRet.CodMunicipio= entidadeCopiar.CodMunicipio;
 toRet.NomeMunicipio= entidadeCopiar.NomeMunicipio;
 toRet.SiglaUf= entidadeCopiar.SiglaUf;
 toRet.Cep= entidadeCopiar.Cep;
 toRet.CodPais= entidadeCopiar.CodPais;
 toRet.NomePais= entidadeCopiar.NomePais;
 toRet.Telefone= entidadeCopiar.Telefone;
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;

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
       _logradouroOriginal = Logradouro;
       _logradouroOriginalCommited = _logradouroOriginal;
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _complementoOriginal = Complemento;
       _complementoOriginalCommited = _complementoOriginal;
       _bairroOriginal = Bairro;
       _bairroOriginalCommited = _bairroOriginal;
       _codMunicipioOriginal = CodMunicipio;
       _codMunicipioOriginalCommited = _codMunicipioOriginal;
       _nomeMunicipioOriginal = NomeMunicipio;
       _nomeMunicipioOriginalCommited = _nomeMunicipioOriginal;
       _siglaUfOriginal = SiglaUf;
       _siglaUfOriginalCommited = _siglaUfOriginal;
       _cepOriginal = Cep;
       _cepOriginalCommited = _cepOriginal;
       _codPaisOriginal = CodPais;
       _codPaisOriginalCommited = _codPaisOriginal;
       _nomePaisOriginal = NomePais;
       _nomePaisOriginalCommited = _nomePaisOriginal;
       _telefoneOriginal = Telefone;
       _telefoneOriginalCommited = _telefoneOriginal;
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
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
       _logradouroOriginalCommited = Logradouro;
       _numeroOriginalCommited = Numero;
       _complementoOriginalCommited = Complemento;
       _bairroOriginalCommited = Bairro;
       _codMunicipioOriginalCommited = CodMunicipio;
       _nomeMunicipioOriginalCommited = NomeMunicipio;
       _siglaUfOriginalCommited = SiglaUf;
       _cepOriginalCommited = Cep;
       _codPaisOriginalCommited = CodPais;
       _nomePaisOriginalCommited = NomePais;
       _telefoneOriginalCommited = Telefone;
       _nfPrincipalOriginalCommited = NfPrincipal;
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
               Logradouro=_logradouroOriginal;
               _logradouroOriginalCommited=_logradouroOriginal;
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Complemento=_complementoOriginal;
               _complementoOriginalCommited=_complementoOriginal;
               Bairro=_bairroOriginal;
               _bairroOriginalCommited=_bairroOriginal;
               CodMunicipio=_codMunicipioOriginal;
               _codMunicipioOriginalCommited=_codMunicipioOriginal;
               NomeMunicipio=_nomeMunicipioOriginal;
               _nomeMunicipioOriginalCommited=_nomeMunicipioOriginal;
               SiglaUf=_siglaUfOriginal;
               _siglaUfOriginalCommited=_siglaUfOriginal;
               Cep=_cepOriginal;
               _cepOriginalCommited=_cepOriginal;
               CodPais=_codPaisOriginal;
               _codPaisOriginalCommited=_codPaisOriginal;
               NomePais=_nomePaisOriginal;
               _nomePaisOriginalCommited=_nomePaisOriginal;
               Telefone=_telefoneOriginal;
               _telefoneOriginalCommited=_telefoneOriginal;
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;

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
       dirty = _logradouroOriginal != Logradouro;
      if (dirty) return true;
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _complementoOriginal != Complemento;
      if (dirty) return true;
       dirty = _bairroOriginal != Bairro;
      if (dirty) return true;
       dirty = _codMunicipioOriginal != CodMunicipio;
      if (dirty) return true;
       dirty = _nomeMunicipioOriginal != NomeMunicipio;
      if (dirty) return true;
       dirty = _siglaUfOriginal != SiglaUf;
      if (dirty) return true;
       dirty = _cepOriginal != Cep;
      if (dirty) return true;
       dirty = _codPaisOriginal != CodPais;
      if (dirty) return true;
       dirty = _nomePaisOriginal != NomePais;
      if (dirty) return true;
       dirty = _telefoneOriginal != Telefone;
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
       dirty = _logradouroOriginalCommited != Logradouro;
      if (dirty) return true;
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _complementoOriginalCommited != Complemento;
      if (dirty) return true;
       dirty = _bairroOriginalCommited != Bairro;
      if (dirty) return true;
       dirty = _codMunicipioOriginalCommited != CodMunicipio;
      if (dirty) return true;
       dirty = _nomeMunicipioOriginalCommited != NomeMunicipio;
      if (dirty) return true;
       dirty = _siglaUfOriginalCommited != SiglaUf;
      if (dirty) return true;
       dirty = _cepOriginalCommited != Cep;
      if (dirty) return true;
       dirty = _codPaisOriginalCommited != CodPais;
      if (dirty) return true;
       dirty = _nomePaisOriginalCommited != NomePais;
      if (dirty) return true;
       dirty = _telefoneOriginalCommited != Telefone;
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
             case "Logradouro":
                return this.Logradouro;
             case "Numero":
                return this.Numero;
             case "Complemento":
                return this.Complemento;
             case "Bairro":
                return this.Bairro;
             case "CodMunicipio":
                return this.CodMunicipio;
             case "NomeMunicipio":
                return this.NomeMunicipio;
             case "SiglaUf":
                return this.SiglaUf;
             case "Cep":
                return this.Cep;
             case "CodPais":
                return this.CodPais;
             case "NomePais":
                return this.NomePais;
             case "Telefone":
                return this.Telefone;
             case "NfPrincipal":
                return this.NfPrincipal;
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
                  command.CommandText += " COUNT(nf_cliente_endereco.id_nf_cliente_endereco) " ;
               }
               else
               {
               command.CommandText += "nf_cliente_endereco.nce_logradouro, " ;
               command.CommandText += "nf_cliente_endereco.nce_numero, " ;
               command.CommandText += "nf_cliente_endereco.nce_complemento, " ;
               command.CommandText += "nf_cliente_endereco.nce_bairro, " ;
               command.CommandText += "nf_cliente_endereco.nce_cod_municipio, " ;
               command.CommandText += "nf_cliente_endereco.nce_nome_municipio, " ;
               command.CommandText += "nf_cliente_endereco.nce_sigla_uf, " ;
               command.CommandText += "nf_cliente_endereco.nce_cep, " ;
               command.CommandText += "nf_cliente_endereco.nce_cod_pais, " ;
               command.CommandText += "nf_cliente_endereco.nce_nome_pais, " ;
               command.CommandText += "nf_cliente_endereco.nce_telefone, " ;
               command.CommandText += "nf_cliente_endereco.id_nf_principal, " ;
               command.CommandText += "nf_cliente_endereco.entity_uid, " ;
               command.CommandText += "nf_cliente_endereco.version, " ;
               command.CommandText += "nf_cliente_endereco.id_nf_cliente_endereco " ;
               }
               command.CommandText += " FROM  nf_cliente_endereco ";
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
                        orderByClause += " , nce_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nce_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_cliente_endereco.id_acs_usuario_ultima_revisao ";
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
                     case "nce_logradouro":
                     case "Logradouro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_logradouro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_logradouro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_complemento":
                     case "Complemento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_complemento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_complemento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_bairro":
                     case "Bairro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_bairro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_bairro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_cod_municipio":
                     case "CodMunicipio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_cliente_endereco.nce_cod_municipio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_cod_municipio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_nome_municipio":
                     case "NomeMunicipio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_nome_municipio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_nome_municipio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_sigla_uf":
                     case "SiglaUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_sigla_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_sigla_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_cep":
                     case "Cep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_cep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_cep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_cod_pais":
                     case "CodPais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_cliente_endereco.nce_cod_pais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_cod_pais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_nome_pais":
                     case "NomePais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_nome_pais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_nome_pais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nce_telefone":
                     case "Telefone":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.nce_telefone " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.nce_telefone) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_cliente_endereco.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
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
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_cliente_endereco.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_cliente_endereco.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_cliente_endereco.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente_endereco.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_cliente_endereco":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_cliente_endereco.id_nf_cliente_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_cliente_endereco.id_nf_cliente_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_logradouro")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_logradouro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_logradouro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_numero")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_complemento")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_complemento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_complemento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_bairro")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_bairro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_bairro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_nome_municipio")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_nome_municipio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_nome_municipio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_sigla_uf")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_sigla_uf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_sigla_uf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_cep")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_cep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_cep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_nome_pais")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_nome_pais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_nome_pais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nce_telefone")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.nce_telefone) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.nce_telefone) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_cliente_endereco.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_cliente_endereco.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "Logradouro" || parametro.FieldName == "nce_logradouro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_logradouro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_logradouro LIKE :nf_cliente_endereco_Logradouro_9720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Logradouro_9720", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "nce_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_numero LIKE :nf_cliente_endereco_Numero_6788 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Numero_6788", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Complemento" || parametro.FieldName == "nce_complemento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_complemento LIKE :nf_cliente_endereco_Complemento_3799 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Complemento_3799", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bairro" || parametro.FieldName == "nce_bairro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_bairro LIKE :nf_cliente_endereco_Bairro_8265 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Bairro_8265", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodMunicipio" || parametro.FieldName == "nce_cod_municipio")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_cod_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_cod_municipio = :nf_cliente_endereco_CodMunicipio_2422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_CodMunicipio_2422", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeMunicipio" || parametro.FieldName == "nce_nome_municipio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_municipio LIKE :nf_cliente_endereco_NomeMunicipio_3853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_NomeMunicipio_3853", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUf" || parametro.FieldName == "nce_sigla_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_sigla_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_sigla_uf LIKE :nf_cliente_endereco_SiglaUf_5992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_SiglaUf_5992", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cep" || parametro.FieldName == "nce_cep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_cep LIKE :nf_cliente_endereco_Cep_1446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Cep_1446", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodPais" || parametro.FieldName == "nce_cod_pais")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_cod_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_cod_pais = :nf_cliente_endereco_CodPais_2779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_CodPais_2779", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomePais" || parametro.FieldName == "nce_nome_pais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_pais LIKE :nf_cliente_endereco_NomePais_5279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_NomePais_5279", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Telefone" || parametro.FieldName == "nce_telefone")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_telefone IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_telefone LIKE :nf_cliente_endereco_Telefone_5377 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Telefone_5377", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
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
                         whereClause += "  nf_cliente_endereco.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.id_nf_principal = :nf_cliente_endereco_NfPrincipal_6378 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_NfPrincipal_6378", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  nf_cliente_endereco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.entity_uid LIKE :nf_cliente_endereco_EntityUid_6446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_EntityUid_6446", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_cliente_endereco.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.version = :nf_cliente_endereco_Version_4227 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Version_4227", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_cliente_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.id_nf_cliente_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.id_nf_cliente_endereco = :nf_cliente_endereco_ID_1895 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_ID_1895", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LogradouroExato" || parametro.FieldName == "LogradouroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_logradouro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_logradouro LIKE :nf_cliente_endereco_Logradouro_386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Logradouro_386", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroExato" || parametro.FieldName == "NumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_numero LIKE :nf_cliente_endereco_Numero_6953 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Numero_6953", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComplementoExato" || parametro.FieldName == "ComplementoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_complemento LIKE :nf_cliente_endereco_Complemento_7267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Complemento_7267", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BairroExato" || parametro.FieldName == "BairroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_bairro LIKE :nf_cliente_endereco_Bairro_4412 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Bairro_4412", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeMunicipioExato" || parametro.FieldName == "NomeMunicipioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_municipio LIKE :nf_cliente_endereco_NomeMunicipio_7054 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_NomeMunicipio_7054", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfExato" || parametro.FieldName == "SiglaUfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_sigla_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_sigla_uf LIKE :nf_cliente_endereco_SiglaUf_5604 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_SiglaUf_5604", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CepExato" || parametro.FieldName == "CepExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_cep LIKE :nf_cliente_endereco_Cep_4482 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Cep_4482", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomePaisExato" || parametro.FieldName == "NomePaisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_nome_pais LIKE :nf_cliente_endereco_NomePais_5347 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_NomePais_5347", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TelefoneExato" || parametro.FieldName == "TelefoneExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_cliente_endereco.nce_telefone IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.nce_telefone LIKE :nf_cliente_endereco_Telefone_9829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_Telefone_9829", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_cliente_endereco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_cliente_endereco.entity_uid LIKE :nf_cliente_endereco_EntityUid_342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_cliente_endereco_EntityUid_342", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfClienteEnderecoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfClienteEnderecoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfClienteEnderecoClass), Convert.ToInt32(read["id_nf_cliente_endereco"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfClienteEnderecoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.Logradouro = (read["nce_logradouro"] != DBNull.Value ? read["nce_logradouro"].ToString() : null);
                     entidade.Numero = (read["nce_numero"] != DBNull.Value ? read["nce_numero"].ToString() : null);
                     entidade.Complemento = (read["nce_complemento"] != DBNull.Value ? read["nce_complemento"].ToString() : null);
                     entidade.Bairro = (read["nce_bairro"] != DBNull.Value ? read["nce_bairro"].ToString() : null);
                     entidade.CodMunicipio = (int)read["nce_cod_municipio"];
                     entidade.NomeMunicipio = (read["nce_nome_municipio"] != DBNull.Value ? read["nce_nome_municipio"].ToString() : null);
                     entidade.SiglaUf = (read["nce_sigla_uf"] != DBNull.Value ? read["nce_sigla_uf"].ToString() : null);
                     entidade.Cep = (read["nce_cep"] != DBNull.Value ? read["nce_cep"].ToString() : null);
                     entidade.CodPais = (int)read["nce_cod_pais"];
                     entidade.NomePais = (read["nce_nome_pais"] != DBNull.Value ? read["nce_nome_pais"].ToString() : null);
                     entidade.Telefone = (read["nce_telefone"] != DBNull.Value ? read["nce_telefone"].ToString() : null);
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_cliente_endereco"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfClienteEnderecoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

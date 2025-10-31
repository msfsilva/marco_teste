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
     [Table("nf_transporte","nft")]
     public class NfTransporteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfTransporteClass";
protected const string ErroDelete = "Erro ao excluir o NfTransporteClass  ";
protected const string ErroSave = "Erro ao salvar o NfTransporteClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfTransporteClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfTransporteClass está sendo utilizada.";
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

       protected ModalidadeFrete _modalidadeOriginal{get;private set;}
       private ModalidadeFrete _modalidadeOriginalCommited{get; set;}
        private ModalidadeFrete _valueModalidade;
         [Column("nft_modalidade")]
        public virtual ModalidadeFrete Modalidade
         { 
            get { return this._valueModalidade; } 
            set 
            { 
                if (this._valueModalidade == value)return;
                 this._valueModalidade = value; 
            } 
        } 

        public bool Modalidade_ProprioRemetente
         { 
            get { return this._valueModalidade == IWTNF.Entidades.Base.ModalidadeFrete.ProprioRemetente; } 
            set { if (value) this._valueModalidade = IWTNF.Entidades.Base.ModalidadeFrete.ProprioRemetente; }
         } 

        public bool Modalidade_ProprioDestinatario
         { 
            get { return this._valueModalidade == IWTNF.Entidades.Base.ModalidadeFrete.ProprioDestinatario; } 
            set { if (value) this._valueModalidade = IWTNF.Entidades.Base.ModalidadeFrete.ProprioDestinatario; }
         } 

        public bool Modalidade_Teceiros
         { 
            get { return this._valueModalidade == IWTNF.Entidades.Base.ModalidadeFrete.Teceiros; } 
            set { if (value) this._valueModalidade = IWTNF.Entidades.Base.ModalidadeFrete.Teceiros; }
         } 

        public bool Modalidade_SemFrete
         { 
            get { return this._valueModalidade == IWTNF.Entidades.Base.ModalidadeFrete.SemFrete; } 
            set { if (value) this._valueModalidade = IWTNF.Entidades.Base.ModalidadeFrete.SemFrete; }
         } 

        public bool Modalidade_Emitente
         { 
            get { return this._valueModalidade == IWTNF.Entidades.Base.ModalidadeFrete.Emitente; } 
            set { if (value) this._valueModalidade = IWTNF.Entidades.Base.ModalidadeFrete.Emitente; }
         } 

        public bool Modalidade_Destinatario
         { 
            get { return this._valueModalidade == IWTNF.Entidades.Base.ModalidadeFrete.Destinatario; } 
            set { if (value) this._valueModalidade = IWTNF.Entidades.Base.ModalidadeFrete.Destinatario; }
         } 

       protected string _razaoOriginal{get;private set;}
       private string _razaoOriginalCommited{get; set;}
        private string _valueRazao;
         [Column("nft_razao")]
        public virtual string Razao
         { 
            get { return this._valueRazao; } 
            set 
            { 
                if (this._valueRazao == value)return;
                 this._valueRazao = value; 
            } 
        } 

       protected string _ieOriginal{get;private set;}
       private string _ieOriginalCommited{get; set;}
        private string _valueIe;
         [Column("nft_ie")]
        public virtual string Ie
         { 
            get { return this._valueIe; } 
            set 
            { 
                if (this._valueIe == value)return;
                 this._valueIe = value; 
            } 
        } 

       protected string _enderecoOriginal{get;private set;}
       private string _enderecoOriginalCommited{get; set;}
        private string _valueEndereco;
         [Column("nft_endereco")]
        public virtual string Endereco
         { 
            get { return this._valueEndereco; } 
            set 
            { 
                if (this._valueEndereco == value)return;
                 this._valueEndereco = value; 
            } 
        } 

       protected string _siglaUfOriginal{get;private set;}
       private string _siglaUfOriginalCommited{get; set;}
        private string _valueSiglaUf;
         [Column("nft_sigla_uf")]
        public virtual string SiglaUf
         { 
            get { return this._valueSiglaUf; } 
            set 
            { 
                if (this._valueSiglaUf == value)return;
                 this._valueSiglaUf = value; 
            } 
        } 

       protected string _municipioOriginal{get;private set;}
       private string _municipioOriginalCommited{get; set;}
        private string _valueMunicipio;
         [Column("nft_municipio")]
        public virtual string Municipio
         { 
            get { return this._valueMunicipio; } 
            set 
            { 
                if (this._valueMunicipio == value)return;
                 this._valueMunicipio = value; 
            } 
        } 

       protected string _cpfCnpjOriginal{get;private set;}
       private string _cpfCnpjOriginalCommited{get; set;}
        private string _valueCpfCnpj;
         [Column("nft_cpf_cnpj")]
        public virtual string CpfCnpj
         { 
            get { return this._valueCpfCnpj; } 
            set 
            { 
                if (this._valueCpfCnpj == value)return;
                 this._valueCpfCnpj = value; 
            } 
        } 

       protected int? _volumesOriginal{get;private set;}
       private int? _volumesOriginalCommited{get; set;}
        private int? _valueVolumes;
         [Column("nft_volumes")]
        public virtual int? Volumes
         { 
            get { return this._valueVolumes; } 
            set 
            { 
                if (this._valueVolumes == value)return;
                 this._valueVolumes = value; 
            } 
        } 

       protected double? _pesoLiquidoOriginal{get;private set;}
       private double? _pesoLiquidoOriginalCommited{get; set;}
        private double? _valuePesoLiquido;
         [Column("nft_peso_liquido")]
        public virtual double? PesoLiquido
         { 
            get { return this._valuePesoLiquido; } 
            set 
            { 
                if (this._valuePesoLiquido == value)return;
                 this._valuePesoLiquido = value; 
            } 
        } 

       protected double? _pesoBrutoOriginal{get;private set;}
       private double? _pesoBrutoOriginalCommited{get; set;}
        private double? _valuePesoBruto;
         [Column("nft_peso_bruto")]
        public virtual double? PesoBruto
         { 
            get { return this._valuePesoBruto; } 
            set 
            { 
                if (this._valuePesoBruto == value)return;
                 this._valuePesoBruto = value; 
            } 
        } 

       protected string _placaOriginal{get;private set;}
       private string _placaOriginalCommited{get; set;}
        private string _valuePlaca;
         [Column("nft_placa")]
        public virtual string Placa
         { 
            get { return this._valuePlaca; } 
            set 
            { 
                if (this._valuePlaca == value)return;
                 this._valuePlaca = value; 
            } 
        } 

       protected string _registroAnttOriginal{get;private set;}
       private string _registroAnttOriginalCommited{get; set;}
        private string _valueRegistroAntt;
         [Column("nft_registro_antt")]
        public virtual string RegistroAntt
         { 
            get { return this._valueRegistroAntt; } 
            set 
            { 
                if (this._valueRegistroAntt == value)return;
                 this._valueRegistroAntt = value; 
            } 
        } 

       protected string _siglaUfVeiculoOriginal{get;private set;}
       private string _siglaUfVeiculoOriginalCommited{get; set;}
        private string _valueSiglaUfVeiculo;
         [Column("nft_sigla_uf_veiculo")]
        public virtual string SiglaUfVeiculo
         { 
            get { return this._valueSiglaUfVeiculo; } 
            set 
            { 
                if (this._valueSiglaUfVeiculo == value)return;
                 this._valueSiglaUfVeiculo = value; 
            } 
        } 

       protected string _volumeEspecieOriginal{get;private set;}
       private string _volumeEspecieOriginalCommited{get; set;}
        private string _valueVolumeEspecie;
         [Column("nft_volume_especie")]
        public virtual string VolumeEspecie
         { 
            get { return this._valueVolumeEspecie; } 
            set 
            { 
                if (this._valueVolumeEspecie == value)return;
                 this._valueVolumeEspecie = value; 
            } 
        } 

       protected string _volumeMarcaOriginal{get;private set;}
       private string _volumeMarcaOriginalCommited{get; set;}
        private string _valueVolumeMarca;
         [Column("nft_volume_marca")]
        public virtual string VolumeMarca
         { 
            get { return this._valueVolumeMarca; } 
            set 
            { 
                if (this._valueVolumeMarca == value)return;
                 this._valueVolumeMarca = value; 
            } 
        } 

        public NfTransporteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfTransporteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfTransporteClass) GetEntity(typeof(NfTransporteClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
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
                    "  public.nf_transporte  " +
                    "WHERE " +
                    "  id_nf_transporte = :id";
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
                        "  public.nf_transporte   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nft_modalidade = :nft_modalidade, " + 
                        "  nft_razao = :nft_razao, " + 
                        "  nft_ie = :nft_ie, " + 
                        "  nft_endereco = :nft_endereco, " + 
                        "  nft_sigla_uf = :nft_sigla_uf, " + 
                        "  nft_municipio = :nft_municipio, " + 
                        "  nft_cpf_cnpj = :nft_cpf_cnpj, " + 
                        "  nft_volumes = :nft_volumes, " + 
                        "  nft_peso_liquido = :nft_peso_liquido, " + 
                        "  nft_peso_bruto = :nft_peso_bruto, " + 
                        "  nft_placa = :nft_placa, " + 
                        "  nft_registro_antt = :nft_registro_antt, " + 
                        "  nft_sigla_uf_veiculo = :nft_sigla_uf_veiculo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nft_volume_especie = :nft_volume_especie, " + 
                        "  nft_volume_marca = :nft_volume_marca "+
                        "WHERE  " +
                        "  id_nf_transporte = :id " +
                        "RETURNING id_nf_transporte;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_transporte " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  nft_modalidade , " + 
                        "  nft_razao , " + 
                        "  nft_ie , " + 
                        "  nft_endereco , " + 
                        "  nft_sigla_uf , " + 
                        "  nft_municipio , " + 
                        "  nft_cpf_cnpj , " + 
                        "  nft_volumes , " + 
                        "  nft_peso_liquido , " + 
                        "  nft_peso_bruto , " + 
                        "  nft_placa , " + 
                        "  nft_registro_antt , " + 
                        "  nft_sigla_uf_veiculo , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nft_volume_especie , " + 
                        "  nft_volume_marca  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :nft_modalidade , " + 
                        "  :nft_razao , " + 
                        "  :nft_ie , " + 
                        "  :nft_endereco , " + 
                        "  :nft_sigla_uf , " + 
                        "  :nft_municipio , " + 
                        "  :nft_cpf_cnpj , " + 
                        "  :nft_volumes , " + 
                        "  :nft_peso_liquido , " + 
                        "  :nft_peso_bruto , " + 
                        "  :nft_placa , " + 
                        "  :nft_registro_antt , " + 
                        "  :nft_sigla_uf_veiculo , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nft_volume_especie , " + 
                        "  :nft_volume_marca  "+
                        ")RETURNING id_nf_transporte;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_modalidade", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Modalidade);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_razao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Razao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_ie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Endereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_sigla_uf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_municipio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Municipio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_cpf_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CpfCnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Volumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_peso_liquido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoLiquido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_peso_bruto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoBruto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_placa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Placa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_registro_antt", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegistroAntt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_sigla_uf_veiculo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUfVeiculo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_volume_especie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VolumeEspecie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nft_volume_marca", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VolumeMarca ?? DBNull.Value;

 
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
        public static NfTransporteClass CopiarEntidade(NfTransporteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfTransporteClass toRet = new NfTransporteClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.Modalidade= entidadeCopiar.Modalidade;
 toRet.Razao= entidadeCopiar.Razao;
 toRet.Ie= entidadeCopiar.Ie;
 toRet.Endereco= entidadeCopiar.Endereco;
 toRet.SiglaUf= entidadeCopiar.SiglaUf;
 toRet.Municipio= entidadeCopiar.Municipio;
 toRet.CpfCnpj= entidadeCopiar.CpfCnpj;
 toRet.Volumes= entidadeCopiar.Volumes;
 toRet.PesoLiquido= entidadeCopiar.PesoLiquido;
 toRet.PesoBruto= entidadeCopiar.PesoBruto;
 toRet.Placa= entidadeCopiar.Placa;
 toRet.RegistroAntt= entidadeCopiar.RegistroAntt;
 toRet.SiglaUfVeiculo= entidadeCopiar.SiglaUfVeiculo;
 toRet.VolumeEspecie= entidadeCopiar.VolumeEspecie;
 toRet.VolumeMarca= entidadeCopiar.VolumeMarca;

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
       _modalidadeOriginal = Modalidade;
       _modalidadeOriginalCommited = _modalidadeOriginal;
       _razaoOriginal = Razao;
       _razaoOriginalCommited = _razaoOriginal;
       _ieOriginal = Ie;
       _ieOriginalCommited = _ieOriginal;
       _enderecoOriginal = Endereco;
       _enderecoOriginalCommited = _enderecoOriginal;
       _siglaUfOriginal = SiglaUf;
       _siglaUfOriginalCommited = _siglaUfOriginal;
       _municipioOriginal = Municipio;
       _municipioOriginalCommited = _municipioOriginal;
       _cpfCnpjOriginal = CpfCnpj;
       _cpfCnpjOriginalCommited = _cpfCnpjOriginal;
       _volumesOriginal = Volumes;
       _volumesOriginalCommited = _volumesOriginal;
       _pesoLiquidoOriginal = PesoLiquido;
       _pesoLiquidoOriginalCommited = _pesoLiquidoOriginal;
       _pesoBrutoOriginal = PesoBruto;
       _pesoBrutoOriginalCommited = _pesoBrutoOriginal;
       _placaOriginal = Placa;
       _placaOriginalCommited = _placaOriginal;
       _registroAnttOriginal = RegistroAntt;
       _registroAnttOriginalCommited = _registroAnttOriginal;
       _siglaUfVeiculoOriginal = SiglaUfVeiculo;
       _siglaUfVeiculoOriginalCommited = _siglaUfVeiculoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _volumeEspecieOriginal = VolumeEspecie;
       _volumeEspecieOriginalCommited = _volumeEspecieOriginal;
       _volumeMarcaOriginal = VolumeMarca;
       _volumeMarcaOriginalCommited = _volumeMarcaOriginal;

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
       _modalidadeOriginalCommited = Modalidade;
       _razaoOriginalCommited = Razao;
       _ieOriginalCommited = Ie;
       _enderecoOriginalCommited = Endereco;
       _siglaUfOriginalCommited = SiglaUf;
       _municipioOriginalCommited = Municipio;
       _cpfCnpjOriginalCommited = CpfCnpj;
       _volumesOriginalCommited = Volumes;
       _pesoLiquidoOriginalCommited = PesoLiquido;
       _pesoBrutoOriginalCommited = PesoBruto;
       _placaOriginalCommited = Placa;
       _registroAnttOriginalCommited = RegistroAntt;
       _siglaUfVeiculoOriginalCommited = SiglaUfVeiculo;
       _versionOriginalCommited = Version;
       _volumeEspecieOriginalCommited = VolumeEspecie;
       _volumeMarcaOriginalCommited = VolumeMarca;

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
               Modalidade=_modalidadeOriginal;
               _modalidadeOriginalCommited=_modalidadeOriginal;
               Razao=_razaoOriginal;
               _razaoOriginalCommited=_razaoOriginal;
               Ie=_ieOriginal;
               _ieOriginalCommited=_ieOriginal;
               Endereco=_enderecoOriginal;
               _enderecoOriginalCommited=_enderecoOriginal;
               SiglaUf=_siglaUfOriginal;
               _siglaUfOriginalCommited=_siglaUfOriginal;
               Municipio=_municipioOriginal;
               _municipioOriginalCommited=_municipioOriginal;
               CpfCnpj=_cpfCnpjOriginal;
               _cpfCnpjOriginalCommited=_cpfCnpjOriginal;
               Volumes=_volumesOriginal;
               _volumesOriginalCommited=_volumesOriginal;
               PesoLiquido=_pesoLiquidoOriginal;
               _pesoLiquidoOriginalCommited=_pesoLiquidoOriginal;
               PesoBruto=_pesoBrutoOriginal;
               _pesoBrutoOriginalCommited=_pesoBrutoOriginal;
               Placa=_placaOriginal;
               _placaOriginalCommited=_placaOriginal;
               RegistroAntt=_registroAnttOriginal;
               _registroAnttOriginalCommited=_registroAnttOriginal;
               SiglaUfVeiculo=_siglaUfVeiculoOriginal;
               _siglaUfVeiculoOriginalCommited=_siglaUfVeiculoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               VolumeEspecie=_volumeEspecieOriginal;
               _volumeEspecieOriginalCommited=_volumeEspecieOriginal;
               VolumeMarca=_volumeMarcaOriginal;
               _volumeMarcaOriginalCommited=_volumeMarcaOriginal;

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
       dirty = _modalidadeOriginal != Modalidade;
      if (dirty) return true;
       dirty = _razaoOriginal != Razao;
      if (dirty) return true;
       dirty = _ieOriginal != Ie;
      if (dirty) return true;
       dirty = _enderecoOriginal != Endereco;
      if (dirty) return true;
       dirty = _siglaUfOriginal != SiglaUf;
      if (dirty) return true;
       dirty = _municipioOriginal != Municipio;
      if (dirty) return true;
       dirty = _cpfCnpjOriginal != CpfCnpj;
      if (dirty) return true;
       dirty = _volumesOriginal != Volumes;
      if (dirty) return true;
       dirty = _pesoLiquidoOriginal != PesoLiquido;
      if (dirty) return true;
       dirty = _pesoBrutoOriginal != PesoBruto;
      if (dirty) return true;
       dirty = _placaOriginal != Placa;
      if (dirty) return true;
       dirty = _registroAnttOriginal != RegistroAntt;
      if (dirty) return true;
       dirty = _siglaUfVeiculoOriginal != SiglaUfVeiculo;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _volumeEspecieOriginal != VolumeEspecie;
      if (dirty) return true;
       dirty = _volumeMarcaOriginal != VolumeMarca;

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
       dirty = _modalidadeOriginalCommited != Modalidade;
      if (dirty) return true;
       dirty = _razaoOriginalCommited != Razao;
      if (dirty) return true;
       dirty = _ieOriginalCommited != Ie;
      if (dirty) return true;
       dirty = _enderecoOriginalCommited != Endereco;
      if (dirty) return true;
       dirty = _siglaUfOriginalCommited != SiglaUf;
      if (dirty) return true;
       dirty = _municipioOriginalCommited != Municipio;
      if (dirty) return true;
       dirty = _cpfCnpjOriginalCommited != CpfCnpj;
      if (dirty) return true;
       dirty = _volumesOriginalCommited != Volumes;
      if (dirty) return true;
       dirty = _pesoLiquidoOriginalCommited != PesoLiquido;
      if (dirty) return true;
       dirty = _pesoBrutoOriginalCommited != PesoBruto;
      if (dirty) return true;
       dirty = _placaOriginalCommited != Placa;
      if (dirty) return true;
       dirty = _registroAnttOriginalCommited != RegistroAntt;
      if (dirty) return true;
       dirty = _siglaUfVeiculoOriginalCommited != SiglaUfVeiculo;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _volumeEspecieOriginalCommited != VolumeEspecie;
      if (dirty) return true;
       dirty = _volumeMarcaOriginalCommited != VolumeMarca;

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
             case "Modalidade":
                return this.Modalidade;
             case "Razao":
                return this.Razao;
             case "Ie":
                return this.Ie;
             case "Endereco":
                return this.Endereco;
             case "SiglaUf":
                return this.SiglaUf;
             case "Municipio":
                return this.Municipio;
             case "CpfCnpj":
                return this.CpfCnpj;
             case "Volumes":
                return this.Volumes;
             case "PesoLiquido":
                return this.PesoLiquido;
             case "PesoBruto":
                return this.PesoBruto;
             case "Placa":
                return this.Placa;
             case "RegistroAntt":
                return this.RegistroAntt;
             case "SiglaUfVeiculo":
                return this.SiglaUfVeiculo;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "VolumeEspecie":
                return this.VolumeEspecie;
             case "VolumeMarca":
                return this.VolumeMarca;
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
                  command.CommandText += " COUNT(nf_transporte.id_nf_transporte) " ;
               }
               else
               {
               command.CommandText += "nf_transporte.id_nf_principal, " ;
               command.CommandText += "nf_transporte.nft_modalidade, " ;
               command.CommandText += "nf_transporte.nft_razao, " ;
               command.CommandText += "nf_transporte.nft_ie, " ;
               command.CommandText += "nf_transporte.nft_endereco, " ;
               command.CommandText += "nf_transporte.nft_sigla_uf, " ;
               command.CommandText += "nf_transporte.nft_municipio, " ;
               command.CommandText += "nf_transporte.nft_cpf_cnpj, " ;
               command.CommandText += "nf_transporte.nft_volumes, " ;
               command.CommandText += "nf_transporte.nft_peso_liquido, " ;
               command.CommandText += "nf_transporte.nft_peso_bruto, " ;
               command.CommandText += "nf_transporte.nft_placa, " ;
               command.CommandText += "nf_transporte.nft_registro_antt, " ;
               command.CommandText += "nf_transporte.nft_sigla_uf_veiculo, " ;
               command.CommandText += "nf_transporte.entity_uid, " ;
               command.CommandText += "nf_transporte.version, " ;
               command.CommandText += "nf_transporte.nft_volume_especie, " ;
               command.CommandText += "nf_transporte.nft_volume_marca, " ;
               command.CommandText += "nf_transporte.id_nf_transporte " ;
               }
               command.CommandText += " FROM  nf_transporte ";
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
                        orderByClause += " , nft_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nft_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_transporte.id_acs_usuario_ultima_revisao ";
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
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_transporte.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
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
                     case "nft_modalidade":
                     case "Modalidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_transporte.nft_modalidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_transporte.nft_modalidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_razao":
                     case "Razao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_razao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_razao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_ie":
                     case "Ie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_endereco":
                     case "Endereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_sigla_uf":
                     case "SiglaUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_sigla_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_sigla_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_municipio":
                     case "Municipio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_municipio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_municipio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_cpf_cnpj":
                     case "CpfCnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_cpf_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_cpf_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_volumes":
                     case "Volumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_transporte.nft_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_transporte.nft_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_peso_liquido":
                     case "PesoLiquido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_transporte.nft_peso_liquido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_transporte.nft_peso_liquido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_peso_bruto":
                     case "PesoBruto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_transporte.nft_peso_bruto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_transporte.nft_peso_bruto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_placa":
                     case "Placa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_placa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_placa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_registro_antt":
                     case "RegistroAntt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_registro_antt " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_registro_antt) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_sigla_uf_veiculo":
                     case "SiglaUfVeiculo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_sigla_uf_veiculo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_sigla_uf_veiculo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_transporte.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_transporte.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_volume_especie":
                     case "VolumeEspecie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_volume_especie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_volume_especie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nft_volume_marca":
                     case "VolumeMarca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_transporte.nft_volume_marca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_transporte.nft_volume_marca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_transporte":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_transporte.id_nf_transporte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_transporte.id_nf_transporte) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_razao")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_razao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_razao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_ie")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_ie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_ie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_endereco")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_sigla_uf")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_sigla_uf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_sigla_uf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_municipio")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_municipio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_municipio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_cpf_cnpj")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_cpf_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_cpf_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_placa")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_placa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_placa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_registro_antt")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_registro_antt) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_registro_antt) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_sigla_uf_veiculo")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_sigla_uf_veiculo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_sigla_uf_veiculo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_volume_especie")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_volume_especie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_volume_especie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nft_volume_marca")) 
                        {
                           whereClause += " OR UPPER(nf_transporte.nft_volume_marca) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_transporte.nft_volume_marca) LIKE :buscaCompletaLower ";
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
                         whereClause += "  nf_transporte.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.id_nf_principal = :nf_transporte_NfPrincipal_9443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_NfPrincipal_9443", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Modalidade" || parametro.FieldName == "nft_modalidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeFrete)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeFrete");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_modalidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_modalidade = :nf_transporte_Modalidade_11 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Modalidade_11", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Razao" || parametro.FieldName == "nft_razao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_razao LIKE :nf_transporte_Razao_4916 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Razao_4916", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ie" || parametro.FieldName == "nft_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_ie LIKE :nf_transporte_Ie_968 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Ie_968", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Endereco" || parametro.FieldName == "nft_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_endereco LIKE :nf_transporte_Endereco_7333 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Endereco_7333", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUf" || parametro.FieldName == "nft_sigla_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf LIKE :nf_transporte_SiglaUf_4006 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_SiglaUf_4006", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Municipio" || parametro.FieldName == "nft_municipio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_municipio LIKE :nf_transporte_Municipio_2763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Municipio_2763", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfCnpj" || parametro.FieldName == "nft_cpf_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_cpf_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_cpf_cnpj LIKE :nf_transporte_CpfCnpj_4129 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_CpfCnpj_4129", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Volumes" || parametro.FieldName == "nft_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_volumes = :nf_transporte_Volumes_5237 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Volumes_5237", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoLiquido" || parametro.FieldName == "nft_peso_liquido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_peso_liquido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_peso_liquido = :nf_transporte_PesoLiquido_693 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_PesoLiquido_693", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoBruto" || parametro.FieldName == "nft_peso_bruto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_peso_bruto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_peso_bruto = :nf_transporte_PesoBruto_1634 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_PesoBruto_1634", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Placa" || parametro.FieldName == "nft_placa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_placa LIKE :nf_transporte_Placa_9019 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Placa_9019", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegistroAntt" || parametro.FieldName == "nft_registro_antt")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_registro_antt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_registro_antt LIKE :nf_transporte_RegistroAntt_681 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_RegistroAntt_681", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfVeiculo" || parametro.FieldName == "nft_sigla_uf_veiculo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf_veiculo LIKE :nf_transporte_SiglaUfVeiculo_3801 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_SiglaUfVeiculo_3801", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_transporte.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.entity_uid LIKE :nf_transporte_EntityUid_4580 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_EntityUid_4580", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_transporte.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.version = :nf_transporte_Version_173 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Version_173", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeEspecie" || parametro.FieldName == "nft_volume_especie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_volume_especie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_volume_especie LIKE :nf_transporte_VolumeEspecie_4999 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_VolumeEspecie_4999", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeMarca" || parametro.FieldName == "nft_volume_marca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_volume_marca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_volume_marca LIKE :nf_transporte_VolumeMarca_4073 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_VolumeMarca_4073", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_transporte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.id_nf_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.id_nf_transporte = :nf_transporte_ID_4636 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_ID_4636", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_transporte.nft_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_razao LIKE :nf_transporte_Razao_8775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Razao_8775", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_transporte.nft_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_ie LIKE :nf_transporte_Ie_4718 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Ie_4718", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoExato" || parametro.FieldName == "EnderecoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_endereco LIKE :nf_transporte_Endereco_2343 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Endereco_2343", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_transporte.nft_sigla_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf LIKE :nf_transporte_SiglaUf_3964 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_SiglaUf_3964", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MunicipioExato" || parametro.FieldName == "MunicipioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_municipio LIKE :nf_transporte_Municipio_3552 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Municipio_3552", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfCnpjExato" || parametro.FieldName == "CpfCnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_cpf_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_cpf_cnpj LIKE :nf_transporte_CpfCnpj_5050 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_CpfCnpj_5050", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlacaExato" || parametro.FieldName == "PlacaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_placa LIKE :nf_transporte_Placa_6005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_Placa_6005", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegistroAnttExato" || parametro.FieldName == "RegistroAnttExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_registro_antt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_registro_antt LIKE :nf_transporte_RegistroAntt_8843 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_RegistroAntt_8843", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfVeiculoExato" || parametro.FieldName == "SiglaUfVeiculoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_sigla_uf_veiculo LIKE :nf_transporte_SiglaUfVeiculo_1771 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_SiglaUfVeiculo_1771", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_transporte.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.entity_uid LIKE :nf_transporte_EntityUid_3319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_EntityUid_3319", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeEspecieExato" || parametro.FieldName == "VolumeEspecieExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_volume_especie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_volume_especie LIKE :nf_transporte_VolumeEspecie_8346 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_VolumeEspecie_8346", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeMarcaExato" || parametro.FieldName == "VolumeMarcaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_transporte.nft_volume_marca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_transporte.nft_volume_marca LIKE :nf_transporte_VolumeMarca_4275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_transporte_VolumeMarca_4275", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfTransporteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfTransporteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfTransporteClass), Convert.ToInt32(read["id_nf_transporte"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfTransporteClass(UsuarioAtual, SingleConnection);
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
                     entidade.Modalidade = (ModalidadeFrete) (read["nft_modalidade"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeFrete), read["nft_modalidade"]) : null);
                     entidade.Razao = (read["nft_razao"] != DBNull.Value ? read["nft_razao"].ToString() : null);
                     entidade.Ie = (read["nft_ie"] != DBNull.Value ? read["nft_ie"].ToString() : null);
                     entidade.Endereco = (read["nft_endereco"] != DBNull.Value ? read["nft_endereco"].ToString() : null);
                     entidade.SiglaUf = (read["nft_sigla_uf"] != DBNull.Value ? read["nft_sigla_uf"].ToString() : null);
                     entidade.Municipio = (read["nft_municipio"] != DBNull.Value ? read["nft_municipio"].ToString() : null);
                     entidade.CpfCnpj = (read["nft_cpf_cnpj"] != DBNull.Value ? read["nft_cpf_cnpj"].ToString() : null);
                     entidade.Volumes = read["nft_volumes"] as int?;
                     entidade.PesoLiquido = read["nft_peso_liquido"] as double?;
                     entidade.PesoBruto = read["nft_peso_bruto"] as double?;
                     entidade.Placa = (read["nft_placa"] != DBNull.Value ? read["nft_placa"].ToString() : null);
                     entidade.RegistroAntt = (read["nft_registro_antt"] != DBNull.Value ? read["nft_registro_antt"].ToString() : null);
                     entidade.SiglaUfVeiculo = (read["nft_sigla_uf_veiculo"] != DBNull.Value ? read["nft_sigla_uf_veiculo"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.VolumeEspecie = (read["nft_volume_especie"] != DBNull.Value ? read["nft_volume_especie"].ToString() : null);
                     entidade.VolumeMarca = (read["nft_volume_marca"] != DBNull.Value ? read["nft_volume_marca"].ToString() : null);
                     entidade.ID = Convert.ToInt64(read["id_nf_transporte"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfTransporteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

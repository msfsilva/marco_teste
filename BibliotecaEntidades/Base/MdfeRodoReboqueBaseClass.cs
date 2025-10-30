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
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNFCompleto.BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("mdfe_rodo_reboque","mrb")]
     public class MdfeRodoReboqueBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeRodoReboqueClass";
protected const string ErroDelete = "Erro ao excluir o MdfeRodoReboqueClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeRodoReboqueClass.";
protected const string ErroPlacaObrigatorio = "O campo Placa é obrigatório";
protected const string ErroPlacaComprimento = "O campo Placa deve ter no máximo 7 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMdfeModalRodoviarioObrigatorio = "O campo MdfeModalRodoviario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MdfeRodoReboqueClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeRodoReboqueClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass _mdfeModalRodoviarioOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass _mdfeModalRodoviarioOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass _valueMdfeModalRodoviario;
        [Column("id_mdfe_modal_rodoviario", "mdfe_modal_rodoviario", "id_mdfe_modal_rodoviario")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass MdfeModalRodoviario
        { 
           get {                 return this._valueMdfeModalRodoviario; } 
           set 
           { 
                if (this._valueMdfeModalRodoviario == value)return;
                 this._valueMdfeModalRodoviario = value; 
           } 
       } 

       protected string _codigoInternoVeiculoOriginal{get;private set;}
       private string _codigoInternoVeiculoOriginalCommited{get; set;}
        private string _valueCodigoInternoVeiculo;
         [Column("mrb_codigo_interno_veiculo")]
        public virtual string CodigoInternoVeiculo
         { 
            get { return this._valueCodigoInternoVeiculo; } 
            set 
            { 
                if (this._valueCodigoInternoVeiculo == value)return;
                 this._valueCodigoInternoVeiculo = value; 
            } 
        } 

       protected string _placaOriginal{get;private set;}
       private string _placaOriginalCommited{get; set;}
        private string _valuePlaca;
         [Column("mrb_placa")]
        public virtual string Placa
         { 
            get { return this._valuePlaca; } 
            set 
            { 
                if (this._valuePlaca == value)return;
                 this._valuePlaca = value; 
            } 
        } 

       protected double _taraKgOriginal{get;private set;}
       private double _taraKgOriginalCommited{get; set;}
        private double _valueTaraKg;
         [Column("mrb_tara_kg")]
        public virtual double TaraKg
         { 
            get { return this._valueTaraKg; } 
            set 
            { 
                if (this._valueTaraKg == value)return;
                 this._valueTaraKg = value; 
            } 
        } 

       protected double _capacidadeKgOriginal{get;private set;}
       private double _capacidadeKgOriginalCommited{get; set;}
        private double _valueCapacidadeKg;
         [Column("mrb_capacidade_kg")]
        public virtual double CapacidadeKg
         { 
            get { return this._valueCapacidadeKg; } 
            set 
            { 
                if (this._valueCapacidadeKg == value)return;
                 this._valueCapacidadeKg = value; 
            } 
        } 

       protected double? _capacidadeM3Original{get;private set;}
       private double? _capacidadeM3OriginalCommited{get; set;}
        private double? _valueCapacidadeM3;
         [Column("mrb_capacidade_m3")]
        public virtual double? CapacidadeM3
         { 
            get { return this._valueCapacidadeM3; } 
            set 
            { 
                if (this._valueCapacidadeM3 == value)return;
                 this._valueCapacidadeM3 = value; 
            } 
        } 

       protected int? _rntrcProprietarioOriginal{get;private set;}
       private int? _rntrcProprietarioOriginalCommited{get; set;}
        private int? _valueRntrcProprietario;
         [Column("mrb_rntrc_proprietario")]
        public virtual int? RntrcProprietario
         { 
            get { return this._valueRntrcProprietario; } 
            set 
            { 
                if (this._valueRntrcProprietario == value)return;
                 this._valueRntrcProprietario = value; 
            } 
        } 

       protected string _cpfProprietarioOriginal{get;private set;}
       private string _cpfProprietarioOriginalCommited{get; set;}
        private string _valueCpfProprietario;
         [Column("mrb_cpf_proprietario")]
        public virtual string CpfProprietario
         { 
            get { return this._valueCpfProprietario; } 
            set 
            { 
                if (this._valueCpfProprietario == value)return;
                 this._valueCpfProprietario = value; 
            } 
        } 

       protected string _cnpjProprietarioOriginal{get;private set;}
       private string _cnpjProprietarioOriginalCommited{get; set;}
        private string _valueCnpjProprietario;
         [Column("mrb_cnpj_proprietario")]
        public virtual string CnpjProprietario
         { 
            get { return this._valueCnpjProprietario; } 
            set 
            { 
                if (this._valueCnpjProprietario == value)return;
                 this._valueCnpjProprietario = value; 
            } 
        } 

       protected string _nomeRazaoProprietarioOriginal{get;private set;}
       private string _nomeRazaoProprietarioOriginalCommited{get; set;}
        private string _valueNomeRazaoProprietario;
         [Column("mrb_nome_razao_proprietario")]
        public virtual string NomeRazaoProprietario
         { 
            get { return this._valueNomeRazaoProprietario; } 
            set 
            { 
                if (this._valueNomeRazaoProprietario == value)return;
                 this._valueNomeRazaoProprietario = value; 
            } 
        } 

       protected string _ieProprietarioOriginal{get;private set;}
       private string _ieProprietarioOriginalCommited{get; set;}
        private string _valueIeProprietario;
         [Column("mrb_ie_proprietario")]
        public virtual string IeProprietario
         { 
            get { return this._valueIeProprietario; } 
            set 
            { 
                if (this._valueIeProprietario == value)return;
                 this._valueIeProprietario = value; 
            } 
        } 

       protected string _ufProprietarioOriginal{get;private set;}
       private string _ufProprietarioOriginalCommited{get; set;}
        private string _valueUfProprietario;
         [Column("mrb_uf_proprietario")]
        public virtual string UfProprietario
         { 
            get { return this._valueUfProprietario; } 
            set 
            { 
                if (this._valueUfProprietario == value)return;
                 this._valueUfProprietario = value; 
            } 
        } 

       protected int? _tipoProprietarioOriginal{get;private set;}
       private int? _tipoProprietarioOriginalCommited{get; set;}
        private int? _valueTipoProprietario;
         [Column("mrb_tipo_proprietario")]
        public virtual int? TipoProprietario
         { 
            get { return this._valueTipoProprietario; } 
            set 
            { 
                if (this._valueTipoProprietario == value)return;
                 this._valueTipoProprietario = value; 
            } 
        } 

       protected int? _tipoCarroceriaOriginal{get;private set;}
       private int? _tipoCarroceriaOriginalCommited{get; set;}
        private int? _valueTipoCarroceria;
         [Column("mrb_tipo_carroceria")]
        public virtual int? TipoCarroceria
         { 
            get { return this._valueTipoCarroceria; } 
            set 
            { 
                if (this._valueTipoCarroceria == value)return;
                 this._valueTipoCarroceria = value; 
            } 
        } 

       protected string _ufLicenciamentoOriginal{get;private set;}
       private string _ufLicenciamentoOriginalCommited{get; set;}
        private string _valueUfLicenciamento;
         [Column("mrb_uf_licenciamento")]
        public virtual string UfLicenciamento
         { 
            get { return this._valueUfLicenciamento; } 
            set 
            { 
                if (this._valueUfLicenciamento == value)return;
                 this._valueUfLicenciamento = value; 
            } 
        } 

       protected string _renavamOriginal{get;private set;}
       private string _renavamOriginalCommited{get; set;}
        private string _valueRenavam;
         [Column("mrb_renavam")]
        public virtual string Renavam
         { 
            get { return this._valueRenavam; } 
            set 
            { 
                if (this._valueRenavam == value)return;
                 this._valueRenavam = value; 
            } 
        } 

        public MdfeRodoReboqueBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MdfeRodoReboqueClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeRodoReboqueClass) GetEntity(typeof(MdfeRodoReboqueClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Placa))
                {
                    throw new Exception(ErroPlacaObrigatorio);
                }
                if (Placa.Length >7)
                {
                    throw new Exception( ErroPlacaComprimento);
                }
                if ( _valueMdfeModalRodoviario == null)
                {
                    throw new Exception(ErroMdfeModalRodoviarioObrigatorio);
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
                    "  public.mdfe_rodo_reboque  " +
                    "WHERE " +
                    "  id_mdfe_rodo_reboque = :id";
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
                        "  public.mdfe_rodo_reboque   " +
                        "SET  " + 
                        "  id_mdfe_modal_rodoviario = :id_mdfe_modal_rodoviario, " + 
                        "  mrb_codigo_interno_veiculo = :mrb_codigo_interno_veiculo, " + 
                        "  mrb_placa = :mrb_placa, " + 
                        "  mrb_tara_kg = :mrb_tara_kg, " + 
                        "  mrb_capacidade_kg = :mrb_capacidade_kg, " + 
                        "  mrb_capacidade_m3 = :mrb_capacidade_m3, " + 
                        "  mrb_rntrc_proprietario = :mrb_rntrc_proprietario, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  mrb_cpf_proprietario = :mrb_cpf_proprietario, " + 
                        "  mrb_cnpj_proprietario = :mrb_cnpj_proprietario, " + 
                        "  mrb_nome_razao_proprietario = :mrb_nome_razao_proprietario, " + 
                        "  mrb_ie_proprietario = :mrb_ie_proprietario, " + 
                        "  mrb_uf_proprietario = :mrb_uf_proprietario, " + 
                        "  mrb_tipo_proprietario = :mrb_tipo_proprietario, " + 
                        "  mrb_tipo_carroceria = :mrb_tipo_carroceria, " + 
                        "  mrb_uf_licenciamento = :mrb_uf_licenciamento, " + 
                        "  mrb_renavam = :mrb_renavam "+
                        "WHERE  " +
                        "  id_mdfe_rodo_reboque = :id " +
                        "RETURNING id_mdfe_rodo_reboque;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_rodo_reboque " +
                        "( " +
                        "  id_mdfe_modal_rodoviario , " + 
                        "  mrb_codigo_interno_veiculo , " + 
                        "  mrb_placa , " + 
                        "  mrb_tara_kg , " + 
                        "  mrb_capacidade_kg , " + 
                        "  mrb_capacidade_m3 , " + 
                        "  mrb_rntrc_proprietario , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  mrb_cpf_proprietario , " + 
                        "  mrb_cnpj_proprietario , " + 
                        "  mrb_nome_razao_proprietario , " + 
                        "  mrb_ie_proprietario , " + 
                        "  mrb_uf_proprietario , " + 
                        "  mrb_tipo_proprietario , " + 
                        "  mrb_tipo_carroceria , " + 
                        "  mrb_uf_licenciamento , " + 
                        "  mrb_renavam  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_mdfe_modal_rodoviario , " + 
                        "  :mrb_codigo_interno_veiculo , " + 
                        "  :mrb_placa , " + 
                        "  :mrb_tara_kg , " + 
                        "  :mrb_capacidade_kg , " + 
                        "  :mrb_capacidade_m3 , " + 
                        "  :mrb_rntrc_proprietario , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :mrb_cpf_proprietario , " + 
                        "  :mrb_cnpj_proprietario , " + 
                        "  :mrb_nome_razao_proprietario , " + 
                        "  :mrb_ie_proprietario , " + 
                        "  :mrb_uf_proprietario , " + 
                        "  :mrb_tipo_proprietario , " + 
                        "  :mrb_tipo_carroceria , " + 
                        "  :mrb_uf_licenciamento , " + 
                        "  :mrb_renavam  "+
                        ")RETURNING id_mdfe_rodo_reboque;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_mdfe_modal_rodoviario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MdfeModalRodoviario==null ? (object) DBNull.Value : this.MdfeModalRodoviario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_codigo_interno_veiculo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoInternoVeiculo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_placa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Placa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_tara_kg", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TaraKg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_capacidade_kg", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CapacidadeKg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_capacidade_m3", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CapacidadeM3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_rntrc_proprietario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RntrcProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_cpf_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CpfProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_cnpj_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_nome_razao_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeRazaoProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_ie_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IeProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_uf_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_tipo_proprietario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_tipo_carroceria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoCarroceria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_uf_licenciamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfLicenciamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrb_renavam", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Renavam ?? DBNull.Value;

 
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
        public static MdfeRodoReboqueClass CopiarEntidade(MdfeRodoReboqueClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeRodoReboqueClass toRet = new MdfeRodoReboqueClass(usuario,conn);
 toRet.MdfeModalRodoviario= entidadeCopiar.MdfeModalRodoviario;
 toRet.CodigoInternoVeiculo= entidadeCopiar.CodigoInternoVeiculo;
 toRet.Placa= entidadeCopiar.Placa;
 toRet.TaraKg= entidadeCopiar.TaraKg;
 toRet.CapacidadeKg= entidadeCopiar.CapacidadeKg;
 toRet.CapacidadeM3= entidadeCopiar.CapacidadeM3;
 toRet.RntrcProprietario= entidadeCopiar.RntrcProprietario;
 toRet.CpfProprietario= entidadeCopiar.CpfProprietario;
 toRet.CnpjProprietario= entidadeCopiar.CnpjProprietario;
 toRet.NomeRazaoProprietario= entidadeCopiar.NomeRazaoProprietario;
 toRet.IeProprietario= entidadeCopiar.IeProprietario;
 toRet.UfProprietario= entidadeCopiar.UfProprietario;
 toRet.TipoProprietario= entidadeCopiar.TipoProprietario;
 toRet.TipoCarroceria= entidadeCopiar.TipoCarroceria;
 toRet.UfLicenciamento= entidadeCopiar.UfLicenciamento;
 toRet.Renavam= entidadeCopiar.Renavam;

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
       _mdfeModalRodoviarioOriginal = MdfeModalRodoviario;
       _mdfeModalRodoviarioOriginalCommited = _mdfeModalRodoviarioOriginal;
       _codigoInternoVeiculoOriginal = CodigoInternoVeiculo;
       _codigoInternoVeiculoOriginalCommited = _codigoInternoVeiculoOriginal;
       _placaOriginal = Placa;
       _placaOriginalCommited = _placaOriginal;
       _taraKgOriginal = TaraKg;
       _taraKgOriginalCommited = _taraKgOriginal;
       _capacidadeKgOriginal = CapacidadeKg;
       _capacidadeKgOriginalCommited = _capacidadeKgOriginal;
       _capacidadeM3Original = CapacidadeM3;
       _capacidadeM3OriginalCommited = _capacidadeM3Original;
       _rntrcProprietarioOriginal = RntrcProprietario;
       _rntrcProprietarioOriginalCommited = _rntrcProprietarioOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cpfProprietarioOriginal = CpfProprietario;
       _cpfProprietarioOriginalCommited = _cpfProprietarioOriginal;
       _cnpjProprietarioOriginal = CnpjProprietario;
       _cnpjProprietarioOriginalCommited = _cnpjProprietarioOriginal;
       _nomeRazaoProprietarioOriginal = NomeRazaoProprietario;
       _nomeRazaoProprietarioOriginalCommited = _nomeRazaoProprietarioOriginal;
       _ieProprietarioOriginal = IeProprietario;
       _ieProprietarioOriginalCommited = _ieProprietarioOriginal;
       _ufProprietarioOriginal = UfProprietario;
       _ufProprietarioOriginalCommited = _ufProprietarioOriginal;
       _tipoProprietarioOriginal = TipoProprietario;
       _tipoProprietarioOriginalCommited = _tipoProprietarioOriginal;
       _tipoCarroceriaOriginal = TipoCarroceria;
       _tipoCarroceriaOriginalCommited = _tipoCarroceriaOriginal;
       _ufLicenciamentoOriginal = UfLicenciamento;
       _ufLicenciamentoOriginalCommited = _ufLicenciamentoOriginal;
       _renavamOriginal = Renavam;
       _renavamOriginalCommited = _renavamOriginal;

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
       _mdfeModalRodoviarioOriginalCommited = MdfeModalRodoviario;
       _codigoInternoVeiculoOriginalCommited = CodigoInternoVeiculo;
       _placaOriginalCommited = Placa;
       _taraKgOriginalCommited = TaraKg;
       _capacidadeKgOriginalCommited = CapacidadeKg;
       _capacidadeM3OriginalCommited = CapacidadeM3;
       _rntrcProprietarioOriginalCommited = RntrcProprietario;
       _versionOriginalCommited = Version;
       _cpfProprietarioOriginalCommited = CpfProprietario;
       _cnpjProprietarioOriginalCommited = CnpjProprietario;
       _nomeRazaoProprietarioOriginalCommited = NomeRazaoProprietario;
       _ieProprietarioOriginalCommited = IeProprietario;
       _ufProprietarioOriginalCommited = UfProprietario;
       _tipoProprietarioOriginalCommited = TipoProprietario;
       _tipoCarroceriaOriginalCommited = TipoCarroceria;
       _ufLicenciamentoOriginalCommited = UfLicenciamento;
       _renavamOriginalCommited = Renavam;

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
               MdfeModalRodoviario=_mdfeModalRodoviarioOriginal;
               _mdfeModalRodoviarioOriginalCommited=_mdfeModalRodoviarioOriginal;
               CodigoInternoVeiculo=_codigoInternoVeiculoOriginal;
               _codigoInternoVeiculoOriginalCommited=_codigoInternoVeiculoOriginal;
               Placa=_placaOriginal;
               _placaOriginalCommited=_placaOriginal;
               TaraKg=_taraKgOriginal;
               _taraKgOriginalCommited=_taraKgOriginal;
               CapacidadeKg=_capacidadeKgOriginal;
               _capacidadeKgOriginalCommited=_capacidadeKgOriginal;
               CapacidadeM3=_capacidadeM3Original;
               _capacidadeM3OriginalCommited=_capacidadeM3Original;
               RntrcProprietario=_rntrcProprietarioOriginal;
               _rntrcProprietarioOriginalCommited=_rntrcProprietarioOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CpfProprietario=_cpfProprietarioOriginal;
               _cpfProprietarioOriginalCommited=_cpfProprietarioOriginal;
               CnpjProprietario=_cnpjProprietarioOriginal;
               _cnpjProprietarioOriginalCommited=_cnpjProprietarioOriginal;
               NomeRazaoProprietario=_nomeRazaoProprietarioOriginal;
               _nomeRazaoProprietarioOriginalCommited=_nomeRazaoProprietarioOriginal;
               IeProprietario=_ieProprietarioOriginal;
               _ieProprietarioOriginalCommited=_ieProprietarioOriginal;
               UfProprietario=_ufProprietarioOriginal;
               _ufProprietarioOriginalCommited=_ufProprietarioOriginal;
               TipoProprietario=_tipoProprietarioOriginal;
               _tipoProprietarioOriginalCommited=_tipoProprietarioOriginal;
               TipoCarroceria=_tipoCarroceriaOriginal;
               _tipoCarroceriaOriginalCommited=_tipoCarroceriaOriginal;
               UfLicenciamento=_ufLicenciamentoOriginal;
               _ufLicenciamentoOriginalCommited=_ufLicenciamentoOriginal;
               Renavam=_renavamOriginal;
               _renavamOriginalCommited=_renavamOriginal;

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
       if (_mdfeModalRodoviarioOriginal!=null)
       {
          dirty = !_mdfeModalRodoviarioOriginal.Equals(MdfeModalRodoviario);
       }
       else
       {
            dirty = MdfeModalRodoviario != null;
       }
      if (dirty) return true;
       dirty = _codigoInternoVeiculoOriginal != CodigoInternoVeiculo;
      if (dirty) return true;
       dirty = _placaOriginal != Placa;
      if (dirty) return true;
       dirty = _taraKgOriginal != TaraKg;
      if (dirty) return true;
       dirty = _capacidadeKgOriginal != CapacidadeKg;
      if (dirty) return true;
       dirty = _capacidadeM3Original != CapacidadeM3;
      if (dirty) return true;
       dirty = _rntrcProprietarioOriginal != RntrcProprietario;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cpfProprietarioOriginal != CpfProprietario;
      if (dirty) return true;
       dirty = _cnpjProprietarioOriginal != CnpjProprietario;
      if (dirty) return true;
       dirty = _nomeRazaoProprietarioOriginal != NomeRazaoProprietario;
      if (dirty) return true;
       dirty = _ieProprietarioOriginal != IeProprietario;
      if (dirty) return true;
       dirty = _ufProprietarioOriginal != UfProprietario;
      if (dirty) return true;
       dirty = _tipoProprietarioOriginal != TipoProprietario;
      if (dirty) return true;
       dirty = _tipoCarroceriaOriginal != TipoCarroceria;
      if (dirty) return true;
       dirty = _ufLicenciamentoOriginal != UfLicenciamento;
      if (dirty) return true;
       dirty = _renavamOriginal != Renavam;

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
       if (_mdfeModalRodoviarioOriginalCommited!=null)
       {
          dirty = !_mdfeModalRodoviarioOriginalCommited.Equals(MdfeModalRodoviario);
       }
       else
       {
            dirty = MdfeModalRodoviario != null;
       }
      if (dirty) return true;
       dirty = _codigoInternoVeiculoOriginalCommited != CodigoInternoVeiculo;
      if (dirty) return true;
       dirty = _placaOriginalCommited != Placa;
      if (dirty) return true;
       dirty = _taraKgOriginalCommited != TaraKg;
      if (dirty) return true;
       dirty = _capacidadeKgOriginalCommited != CapacidadeKg;
      if (dirty) return true;
       dirty = _capacidadeM3OriginalCommited != CapacidadeM3;
      if (dirty) return true;
       dirty = _rntrcProprietarioOriginalCommited != RntrcProprietario;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cpfProprietarioOriginalCommited != CpfProprietario;
      if (dirty) return true;
       dirty = _cnpjProprietarioOriginalCommited != CnpjProprietario;
      if (dirty) return true;
       dirty = _nomeRazaoProprietarioOriginalCommited != NomeRazaoProprietario;
      if (dirty) return true;
       dirty = _ieProprietarioOriginalCommited != IeProprietario;
      if (dirty) return true;
       dirty = _ufProprietarioOriginalCommited != UfProprietario;
      if (dirty) return true;
       dirty = _tipoProprietarioOriginalCommited != TipoProprietario;
      if (dirty) return true;
       dirty = _tipoCarroceriaOriginalCommited != TipoCarroceria;
      if (dirty) return true;
       dirty = _ufLicenciamentoOriginalCommited != UfLicenciamento;
      if (dirty) return true;
       dirty = _renavamOriginalCommited != Renavam;

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
             case "MdfeModalRodoviario":
                return this.MdfeModalRodoviario;
             case "CodigoInternoVeiculo":
                return this.CodigoInternoVeiculo;
             case "Placa":
                return this.Placa;
             case "TaraKg":
                return this.TaraKg;
             case "CapacidadeKg":
                return this.CapacidadeKg;
             case "CapacidadeM3":
                return this.CapacidadeM3;
             case "RntrcProprietario":
                return this.RntrcProprietario;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "CpfProprietario":
                return this.CpfProprietario;
             case "CnpjProprietario":
                return this.CnpjProprietario;
             case "NomeRazaoProprietario":
                return this.NomeRazaoProprietario;
             case "IeProprietario":
                return this.IeProprietario;
             case "UfProprietario":
                return this.UfProprietario;
             case "TipoProprietario":
                return this.TipoProprietario;
             case "TipoCarroceria":
                return this.TipoCarroceria;
             case "UfLicenciamento":
                return this.UfLicenciamento;
             case "Renavam":
                return this.Renavam;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (MdfeModalRodoviario!=null)
                MdfeModalRodoviario.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(mdfe_rodo_reboque.id_mdfe_rodo_reboque) " ;
               }
               else
               {
               command.CommandText += "mdfe_rodo_reboque.id_mdfe_rodo_reboque, " ;
               command.CommandText += "mdfe_rodo_reboque.id_mdfe_modal_rodoviario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_codigo_interno_veiculo, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_placa, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_tara_kg, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_capacidade_kg, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_capacidade_m3, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_rntrc_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.version, " ;
               command.CommandText += "mdfe_rodo_reboque.entity_uid, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_cpf_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_cnpj_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_nome_razao_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_ie_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_uf_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_tipo_proprietario, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_tipo_carroceria, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_uf_licenciamento, " ;
               command.CommandText += "mdfe_rodo_reboque.mrb_renavam " ;
               }
               command.CommandText += " FROM  mdfe_rodo_reboque ";
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
                        orderByClause += " , mrb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mrb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_rodo_reboque.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_rodo_reboque":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.id_mdfe_rodo_reboque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.id_mdfe_rodo_reboque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_mdfe_modal_rodoviario":
                     case "MdfeModalRodoviario":
                     orderByClause += " , mdfe_rodo_reboque.id_mdfe_modal_rodoviario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mrb_codigo_interno_veiculo":
                     case "CodigoInternoVeiculo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_codigo_interno_veiculo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_codigo_interno_veiculo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_placa":
                     case "Placa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_placa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_placa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_tara_kg":
                     case "TaraKg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.mrb_tara_kg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_tara_kg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_capacidade_kg":
                     case "CapacidadeKg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.mrb_capacidade_kg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_capacidade_kg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_capacidade_m3":
                     case "CapacidadeM3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.mrb_capacidade_m3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_capacidade_m3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_rntrc_proprietario":
                     case "RntrcProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.mrb_rntrc_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_rntrc_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_rodo_reboque.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_cpf_proprietario":
                     case "CpfProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_cpf_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_cpf_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_cnpj_proprietario":
                     case "CnpjProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_cnpj_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_cnpj_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_nome_razao_proprietario":
                     case "NomeRazaoProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_nome_razao_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_nome_razao_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_ie_proprietario":
                     case "IeProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_ie_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_ie_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_uf_proprietario":
                     case "UfProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_uf_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_uf_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_tipo_proprietario":
                     case "TipoProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.mrb_tipo_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_tipo_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_tipo_carroceria":
                     case "TipoCarroceria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_rodo_reboque.mrb_tipo_carroceria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_tipo_carroceria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_uf_licenciamento":
                     case "UfLicenciamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_uf_licenciamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_uf_licenciamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrb_renavam":
                     case "Renavam":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_rodo_reboque.mrb_renavam " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_rodo_reboque.mrb_renavam) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_codigo_interno_veiculo")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_codigo_interno_veiculo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_codigo_interno_veiculo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_placa")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_placa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_placa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_cpf_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_cpf_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_cpf_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_cnpj_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_cnpj_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_cnpj_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_nome_razao_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_nome_razao_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_nome_razao_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_ie_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_ie_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_ie_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_uf_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_uf_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_uf_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_uf_licenciamento")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_uf_licenciamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_uf_licenciamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrb_renavam")) 
                        {
                           whereClause += " OR UPPER(mdfe_rodo_reboque.mrb_renavam) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_rodo_reboque.mrb_renavam) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_rodo_reboque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.id_mdfe_rodo_reboque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.id_mdfe_rodo_reboque = :mdfe_rodo_reboque_ID_5359 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_ID_5359", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MdfeModalRodoviario" || parametro.FieldName == "id_mdfe_modal_rodoviario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.id_mdfe_modal_rodoviario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.id_mdfe_modal_rodoviario = :mdfe_rodo_reboque_MdfeModalRodoviario_1776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_MdfeModalRodoviario_1776", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoInternoVeiculo" || parametro.FieldName == "mrb_codigo_interno_veiculo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_codigo_interno_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_codigo_interno_veiculo LIKE :mdfe_rodo_reboque_CodigoInternoVeiculo_2457 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CodigoInternoVeiculo_2457", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Placa" || parametro.FieldName == "mrb_placa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_placa LIKE :mdfe_rodo_reboque_Placa_7689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_Placa_7689", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TaraKg" || parametro.FieldName == "mrb_tara_kg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_tara_kg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_tara_kg = :mdfe_rodo_reboque_TaraKg_6231 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_TaraKg_6231", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CapacidadeKg" || parametro.FieldName == "mrb_capacidade_kg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_capacidade_kg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_capacidade_kg = :mdfe_rodo_reboque_CapacidadeKg_6132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CapacidadeKg_6132", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CapacidadeM3" || parametro.FieldName == "mrb_capacidade_m3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_capacidade_m3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_capacidade_m3 = :mdfe_rodo_reboque_CapacidadeM3_5879 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CapacidadeM3_5879", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RntrcProprietario" || parametro.FieldName == "mrb_rntrc_proprietario")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_rntrc_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_rntrc_proprietario = :mdfe_rodo_reboque_RntrcProprietario_2638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_RntrcProprietario_2638", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_rodo_reboque.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.version = :mdfe_rodo_reboque_Version_5483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_Version_5483", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_rodo_reboque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.entity_uid LIKE :mdfe_rodo_reboque_EntityUid_2642 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_EntityUid_2642", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfProprietario" || parametro.FieldName == "mrb_cpf_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cpf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cpf_proprietario LIKE :mdfe_rodo_reboque_CpfProprietario_8674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CpfProprietario_8674", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjProprietario" || parametro.FieldName == "mrb_cnpj_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cnpj_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cnpj_proprietario LIKE :mdfe_rodo_reboque_CnpjProprietario_6367 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CnpjProprietario_6367", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeRazaoProprietario" || parametro.FieldName == "mrb_nome_razao_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_nome_razao_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_nome_razao_proprietario LIKE :mdfe_rodo_reboque_NomeRazaoProprietario_3014 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_NomeRazaoProprietario_3014", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeProprietario" || parametro.FieldName == "mrb_ie_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_ie_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_ie_proprietario LIKE :mdfe_rodo_reboque_IeProprietario_6971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_IeProprietario_6971", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfProprietario" || parametro.FieldName == "mrb_uf_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_proprietario LIKE :mdfe_rodo_reboque_UfProprietario_4144 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_UfProprietario_4144", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoProprietario" || parametro.FieldName == "mrb_tipo_proprietario")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_tipo_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_tipo_proprietario = :mdfe_rodo_reboque_TipoProprietario_5120 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_TipoProprietario_5120", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoCarroceria" || parametro.FieldName == "mrb_tipo_carroceria")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_tipo_carroceria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_tipo_carroceria = :mdfe_rodo_reboque_TipoCarroceria_1589 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_TipoCarroceria_1589", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfLicenciamento" || parametro.FieldName == "mrb_uf_licenciamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_licenciamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_licenciamento LIKE :mdfe_rodo_reboque_UfLicenciamento_4595 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_UfLicenciamento_4595", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Renavam" || parametro.FieldName == "mrb_renavam")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_renavam IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_renavam LIKE :mdfe_rodo_reboque_Renavam_9614 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_Renavam_9614", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoInternoVeiculoExato" || parametro.FieldName == "CodigoInternoVeiculoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_codigo_interno_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_codigo_interno_veiculo LIKE :mdfe_rodo_reboque_CodigoInternoVeiculo_6805 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CodigoInternoVeiculo_6805", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_rodo_reboque.mrb_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_placa LIKE :mdfe_rodo_reboque_Placa_1851 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_Placa_1851", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_rodo_reboque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.entity_uid LIKE :mdfe_rodo_reboque_EntityUid_3682 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_EntityUid_3682", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfProprietarioExato" || parametro.FieldName == "CpfProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cpf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cpf_proprietario LIKE :mdfe_rodo_reboque_CpfProprietario_2231 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CpfProprietario_2231", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjProprietarioExato" || parametro.FieldName == "CnpjProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cnpj_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_cnpj_proprietario LIKE :mdfe_rodo_reboque_CnpjProprietario_6473 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_CnpjProprietario_6473", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeRazaoProprietarioExato" || parametro.FieldName == "NomeRazaoProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_nome_razao_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_nome_razao_proprietario LIKE :mdfe_rodo_reboque_NomeRazaoProprietario_8816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_NomeRazaoProprietario_8816", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeProprietarioExato" || parametro.FieldName == "IeProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_ie_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_ie_proprietario LIKE :mdfe_rodo_reboque_IeProprietario_1193 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_IeProprietario_1193", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfProprietarioExato" || parametro.FieldName == "UfProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_proprietario LIKE :mdfe_rodo_reboque_UfProprietario_2560 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_UfProprietario_2560", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfLicenciamentoExato" || parametro.FieldName == "UfLicenciamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_licenciamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_uf_licenciamento LIKE :mdfe_rodo_reboque_UfLicenciamento_2210 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_UfLicenciamento_2210", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RenavamExato" || parametro.FieldName == "RenavamExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_renavam IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_rodo_reboque.mrb_renavam LIKE :mdfe_rodo_reboque_Renavam_1786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_rodo_reboque_Renavam_1786", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeRodoReboqueClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeRodoReboqueClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeRodoReboqueClass), Convert.ToInt32(read["id_mdfe_rodo_reboque"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeRodoReboqueClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_rodo_reboque"]);
                     if (read["id_mdfe_modal_rodoviario"] != DBNull.Value)
                     {
                        entidade.MdfeModalRodoviario = (IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass)IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeModalRodoviarioClass.GetEntidade(Convert.ToInt32(read["id_mdfe_modal_rodoviario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MdfeModalRodoviario = null ;
                     }
                     entidade.CodigoInternoVeiculo = (read["mrb_codigo_interno_veiculo"] != DBNull.Value ? read["mrb_codigo_interno_veiculo"].ToString() : null);
                     entidade.Placa = (read["mrb_placa"] != DBNull.Value ? read["mrb_placa"].ToString() : null);
                     entidade.TaraKg = (double)read["mrb_tara_kg"];
                     entidade.CapacidadeKg = (double)read["mrb_capacidade_kg"];
                     entidade.CapacidadeM3 = read["mrb_capacidade_m3"] as double?;
                     entidade.RntrcProprietario = read["mrb_rntrc_proprietario"] as int?;
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.CpfProprietario = (read["mrb_cpf_proprietario"] != DBNull.Value ? read["mrb_cpf_proprietario"].ToString() : null);
                     entidade.CnpjProprietario = (read["mrb_cnpj_proprietario"] != DBNull.Value ? read["mrb_cnpj_proprietario"].ToString() : null);
                     entidade.NomeRazaoProprietario = (read["mrb_nome_razao_proprietario"] != DBNull.Value ? read["mrb_nome_razao_proprietario"].ToString() : null);
                     entidade.IeProprietario = (read["mrb_ie_proprietario"] != DBNull.Value ? read["mrb_ie_proprietario"].ToString() : null);
                     entidade.UfProprietario = (read["mrb_uf_proprietario"] != DBNull.Value ? read["mrb_uf_proprietario"].ToString() : null);
                     entidade.TipoProprietario = read["mrb_tipo_proprietario"] as int?;
                     entidade.TipoCarroceria = read["mrb_tipo_carroceria"] as int?;
                     entidade.UfLicenciamento = (read["mrb_uf_licenciamento"] != DBNull.Value ? read["mrb_uf_licenciamento"].ToString() : null);
                     entidade.Renavam = (read["mrb_renavam"] != DBNull.Value ? read["mrb_renavam"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeRodoReboqueClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

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
     [Table("nfe_completo_inutilizacao","nci")]
     public class NfeCompletoInutilizacaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeCompletoInutilizacaoClass";
protected const string ErroDelete = "Erro ao excluir o NfeCompletoInutilizacaoClass  ";
protected const string ErroSave = "Erro ao salvar o NfeCompletoInutilizacaoClass.";
protected const string ErroCnpjObrigatorio = "O campo Cnpj é obrigatório";
protected const string ErroCnpjComprimento = "O campo Cnpj deve ter no máximo 50 caracteres";
protected const string ErroUfObrigatorio = "O campo Uf é obrigatório";
protected const string ErroUfComprimento = "O campo Uf deve ter no máximo 50 caracteres";
protected const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
protected const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
protected const string ErroUsuarioObrigatorio = "O campo Usuario é obrigatório";
protected const string ErroUsuarioComprimento = "O campo Usuario deve ter no máximo 255 caracteres";
protected const string ErroXmlObrigatorio = "O campo Xml é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloObrigatorio = "O campo Modelo é obrigatório";
protected const string ErroModeloComprimento = "O campo Modelo deve ter no máximo 10 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NfeCompletoInutilizacaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoInutilizacaoClass está sendo utilizada.";
#endregion
       protected string _cnpjOriginal{get;private set;}
       private string _cnpjOriginalCommited{get; set;}
        private string _valueCnpj;
         [Column("nci_cnpj")]
        public virtual string Cnpj
         { 
            get { return this._valueCnpj; } 
            set 
            { 
                if (this._valueCnpj == value)return;
                 this._valueCnpj = value; 
            } 
        } 

       protected string _ufOriginal{get;private set;}
       private string _ufOriginalCommited{get; set;}
        private string _valueUf;
         [Column("nci_uf")]
        public virtual string Uf
         { 
            get { return this._valueUf; } 
            set 
            { 
                if (this._valueUf == value)return;
                 this._valueUf = value; 
            } 
        } 

       protected int _serieOriginal{get;private set;}
       private int _serieOriginalCommited{get; set;}
        private int _valueSerie;
         [Column("nci_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected int _inicioOriginal{get;private set;}
       private int _inicioOriginalCommited{get; set;}
        private int _valueInicio;
         [Column("nci_inicio")]
        public virtual int Inicio
         { 
            get { return this._valueInicio; } 
            set 
            { 
                if (this._valueInicio == value)return;
                 this._valueInicio = value; 
            } 
        } 

       protected int _fimOriginal{get;private set;}
       private int _fimOriginalCommited{get; set;}
        private int _valueFim;
         [Column("nci_fim")]
        public virtual int Fim
         { 
            get { return this._valueFim; } 
            set 
            { 
                if (this._valueFim == value)return;
                 this._valueFim = value; 
            } 
        } 

       protected string _justificativaOriginal{get;private set;}
       private string _justificativaOriginalCommited{get; set;}
        private string _valueJustificativa;
         [Column("nci_justificativa")]
        public virtual string Justificativa
         { 
            get { return this._valueJustificativa; } 
            set 
            { 
                if (this._valueJustificativa == value)return;
                 this._valueJustificativa = value; 
            } 
        } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("nci_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _usuarioOriginal{get;private set;}
       private string _usuarioOriginalCommited{get; set;}
        private string _valueUsuario;
         [Column("nci_usuario")]
        public virtual string Usuario
         { 
            get { return this._valueUsuario; } 
            set 
            { 
                if (this._valueUsuario == value)return;
                 this._valueUsuario = value; 
            } 
        } 

       protected string _xmlOriginal{get;private set;}
       private string _xmlOriginalCommited{get; set;}
        private string _valueXml;
         [Column("nci_xml")]
        public virtual string Xml
         { 
            get { return this._valueXml; } 
            set 
            { 
                if (this._valueXml == value)return;
                 this._valueXml = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("nci_homologacao")]
        public virtual bool Homologacao
         { 
            get { return this._valueHomologacao; } 
            set 
            { 
                if (this._valueHomologacao == value)return;
                 this._valueHomologacao = value; 
            } 
        } 

       protected string _modeloOriginal{get;private set;}
       private string _modeloOriginalCommited{get; set;}
        private string _valueModelo;
         [Column("nci_modelo")]
        public virtual string Modelo
         { 
            get { return this._valueModelo; } 
            set 
            { 
                if (this._valueModelo == value)return;
                 this._valueModelo = value; 
            } 
        } 

        public NfeCompletoInutilizacaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Homologacao = false;
           this.Modelo = "55";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfeCompletoInutilizacaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeCompletoInutilizacaoClass) GetEntity(typeof(NfeCompletoInutilizacaoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Cnpj))
                {
                    throw new Exception(ErroCnpjObrigatorio);
                }
                if (Cnpj.Length >50)
                {
                    throw new Exception( ErroCnpjComprimento);
                }
                if (string.IsNullOrEmpty(Uf))
                {
                    throw new Exception(ErroUfObrigatorio);
                }
                if (Uf.Length >50)
                {
                    throw new Exception( ErroUfComprimento);
                }
                if (string.IsNullOrEmpty(Justificativa))
                {
                    throw new Exception(ErroJustificativaObrigatorio);
                }
                if (Justificativa.Length >255)
                {
                    throw new Exception( ErroJustificativaComprimento);
                }
                if (string.IsNullOrEmpty(Usuario))
                {
                    throw new Exception(ErroUsuarioObrigatorio);
                }
                if (Usuario.Length >255)
                {
                    throw new Exception( ErroUsuarioComprimento);
                }
                if (string.IsNullOrEmpty(Xml))
                {
                    throw new Exception(ErroXmlObrigatorio);
                }
                if (string.IsNullOrEmpty(Modelo))
                {
                    throw new Exception(ErroModeloObrigatorio);
                }
                if (Modelo.Length >10)
                {
                    throw new Exception( ErroModeloComprimento);
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
                    "  public.nfe_completo_inutilizacao  " +
                    "WHERE " +
                    "  id_nfe_completo_inutilizacao = :id";
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
                        "  public.nfe_completo_inutilizacao   " +
                        "SET  " + 
                        "  nci_cnpj = :nci_cnpj, " + 
                        "  nci_uf = :nci_uf, " + 
                        "  nci_serie = :nci_serie, " + 
                        "  nci_inicio = :nci_inicio, " + 
                        "  nci_fim = :nci_fim, " + 
                        "  nci_justificativa = :nci_justificativa, " + 
                        "  nci_data = :nci_data, " + 
                        "  nci_usuario = :nci_usuario, " + 
                        "  nci_xml = :nci_xml, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nci_homologacao = :nci_homologacao, " + 
                        "  nci_modelo = :nci_modelo "+
                        "WHERE  " +
                        "  id_nfe_completo_inutilizacao = :id " +
                        "RETURNING id_nfe_completo_inutilizacao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_completo_inutilizacao " +
                        "( " +
                        "  nci_cnpj , " + 
                        "  nci_uf , " + 
                        "  nci_serie , " + 
                        "  nci_inicio , " + 
                        "  nci_fim , " + 
                        "  nci_justificativa , " + 
                        "  nci_data , " + 
                        "  nci_usuario , " + 
                        "  nci_xml , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nci_homologacao , " + 
                        "  nci_modelo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :nci_cnpj , " + 
                        "  :nci_uf , " + 
                        "  :nci_serie , " + 
                        "  :nci_inicio , " + 
                        "  :nci_fim , " + 
                        "  :nci_justificativa , " + 
                        "  :nci_data , " + 
                        "  :nci_usuario , " + 
                        "  :nci_xml , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nci_homologacao , " + 
                        "  :nci_modelo  "+
                        ")RETURNING id_nfe_completo_inutilizacao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_uf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Uf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_inicio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Inicio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_fim", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fim ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Justificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Usuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Xml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Modelo ?? DBNull.Value;

 
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
        public static NfeCompletoInutilizacaoClass CopiarEntidade(NfeCompletoInutilizacaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeCompletoInutilizacaoClass toRet = new NfeCompletoInutilizacaoClass(usuario,conn);
 toRet.Cnpj= entidadeCopiar.Cnpj;
 toRet.Uf= entidadeCopiar.Uf;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.Inicio= entidadeCopiar.Inicio;
 toRet.Fim= entidadeCopiar.Fim;
 toRet.Justificativa= entidadeCopiar.Justificativa;
 toRet.Data= entidadeCopiar.Data;
 toRet.Usuario= entidadeCopiar.Usuario;
 toRet.Xml= entidadeCopiar.Xml;
 toRet.Homologacao= entidadeCopiar.Homologacao;
 toRet.Modelo= entidadeCopiar.Modelo;

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
       _cnpjOriginal = Cnpj;
       _cnpjOriginalCommited = _cnpjOriginal;
       _ufOriginal = Uf;
       _ufOriginalCommited = _ufOriginal;
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _inicioOriginal = Inicio;
       _inicioOriginalCommited = _inicioOriginal;
       _fimOriginal = Fim;
       _fimOriginalCommited = _fimOriginal;
       _justificativaOriginal = Justificativa;
       _justificativaOriginalCommited = _justificativaOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _usuarioOriginal = Usuario;
       _usuarioOriginalCommited = _usuarioOriginal;
       _xmlOriginal = Xml;
       _xmlOriginalCommited = _xmlOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
       _modeloOriginal = Modelo;
       _modeloOriginalCommited = _modeloOriginal;

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
       _cnpjOriginalCommited = Cnpj;
       _ufOriginalCommited = Uf;
       _serieOriginalCommited = Serie;
       _inicioOriginalCommited = Inicio;
       _fimOriginalCommited = Fim;
       _justificativaOriginalCommited = Justificativa;
       _dataOriginalCommited = Data;
       _usuarioOriginalCommited = Usuario;
       _xmlOriginalCommited = Xml;
       _versionOriginalCommited = Version;
       _homologacaoOriginalCommited = Homologacao;
       _modeloOriginalCommited = Modelo;

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
               Cnpj=_cnpjOriginal;
               _cnpjOriginalCommited=_cnpjOriginal;
               Uf=_ufOriginal;
               _ufOriginalCommited=_ufOriginal;
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               Inicio=_inicioOriginal;
               _inicioOriginalCommited=_inicioOriginal;
               Fim=_fimOriginal;
               _fimOriginalCommited=_fimOriginal;
               Justificativa=_justificativaOriginal;
               _justificativaOriginalCommited=_justificativaOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Usuario=_usuarioOriginal;
               _usuarioOriginalCommited=_usuarioOriginal;
               Xml=_xmlOriginal;
               _xmlOriginalCommited=_xmlOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Modelo=_modeloOriginal;
               _modeloOriginalCommited=_modeloOriginal;

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
       dirty = _cnpjOriginal != Cnpj;
      if (dirty) return true;
       dirty = _ufOriginal != Uf;
      if (dirty) return true;
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
       dirty = _inicioOriginal != Inicio;
      if (dirty) return true;
       dirty = _fimOriginal != Fim;
      if (dirty) return true;
       dirty = _justificativaOriginal != Justificativa;
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _usuarioOriginal != Usuario;
      if (dirty) return true;
       dirty = _xmlOriginal != Xml;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
      if (dirty) return true;
       dirty = _modeloOriginal != Modelo;

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
       dirty = _cnpjOriginalCommited != Cnpj;
      if (dirty) return true;
       dirty = _ufOriginalCommited != Uf;
      if (dirty) return true;
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
       dirty = _inicioOriginalCommited != Inicio;
      if (dirty) return true;
       dirty = _fimOriginalCommited != Fim;
      if (dirty) return true;
       dirty = _justificativaOriginalCommited != Justificativa;
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _usuarioOriginalCommited != Usuario;
      if (dirty) return true;
       dirty = _xmlOriginalCommited != Xml;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
      if (dirty) return true;
       dirty = _modeloOriginalCommited != Modelo;

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
             case "Cnpj":
                return this.Cnpj;
             case "Uf":
                return this.Uf;
             case "Serie":
                return this.Serie;
             case "Inicio":
                return this.Inicio;
             case "Fim":
                return this.Fim;
             case "Justificativa":
                return this.Justificativa;
             case "Data":
                return this.Data;
             case "Usuario":
                return this.Usuario;
             case "Xml":
                return this.Xml;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Homologacao":
                return this.Homologacao;
             case "Modelo":
                return this.Modelo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
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
                  command.CommandText += " COUNT(nfe_completo_inutilizacao.id_nfe_completo_inutilizacao) " ;
               }
               else
               {
               command.CommandText += "nfe_completo_inutilizacao.id_nfe_completo_inutilizacao, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_cnpj, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_uf, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_serie, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_inicio, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_fim, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_justificativa, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_data, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_usuario, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_xml, " ;
               command.CommandText += "nfe_completo_inutilizacao.entity_uid, " ;
               command.CommandText += "nfe_completo_inutilizacao.version, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_homologacao, " ;
               command.CommandText += "nfe_completo_inutilizacao.nci_modelo " ;
               }
               command.CommandText += " FROM  nfe_completo_inutilizacao ";
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
                        orderByClause += " , nci_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nci_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_completo_inutilizacao.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_completo_inutilizacao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_inutilizacao.id_nfe_completo_inutilizacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.id_nfe_completo_inutilizacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_cnpj":
                     case "Cnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.nci_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_uf":
                     case "Uf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.nci_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_inutilizacao.nci_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_inicio":
                     case "Inicio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_inutilizacao.nci_inicio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_inicio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_fim":
                     case "Fim":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_inutilizacao.nci_fim " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_fim) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_justificativa":
                     case "Justificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.nci_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_inutilizacao.nci_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_usuario":
                     case "Usuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.nci_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_xml":
                     case "Xml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.nci_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_completo_inutilizacao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_inutilizacao.nci_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nci_modelo":
                     case "Modelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_inutilizacao.nci_modelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_inutilizacao.nci_modelo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nci_cnpj")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.nci_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.nci_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nci_uf")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.nci_uf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.nci_uf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nci_justificativa")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.nci_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.nci_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nci_usuario")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.nci_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.nci_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nci_xml")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.nci_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.nci_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nci_modelo")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_inutilizacao.nci_modelo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_inutilizacao.nci_modelo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_completo_inutilizacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.id_nfe_completo_inutilizacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.id_nfe_completo_inutilizacao = :nfe_completo_inutilizacao_ID_2502 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_ID_2502", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnpj" || parametro.FieldName == "nci_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_cnpj LIKE :nfe_completo_inutilizacao_Cnpj_1136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Cnpj_1136", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Uf" || parametro.FieldName == "nci_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_uf LIKE :nfe_completo_inutilizacao_Uf_6975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Uf_6975", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "nci_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_serie = :nfe_completo_inutilizacao_Serie_1934 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Serie_1934", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Inicio" || parametro.FieldName == "nci_inicio")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_inicio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_inicio = :nfe_completo_inutilizacao_Inicio_9341 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Inicio_9341", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fim" || parametro.FieldName == "nci_fim")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_fim IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_fim = :nfe_completo_inutilizacao_Fim_2341 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Fim_2341", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Justificativa" || parametro.FieldName == "nci_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_justificativa LIKE :nfe_completo_inutilizacao_Justificativa_7194 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Justificativa_7194", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "nci_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_data = :nfe_completo_inutilizacao_Data_8432 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Data_8432", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Usuario" || parametro.FieldName == "nci_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_usuario LIKE :nfe_completo_inutilizacao_Usuario_1069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Usuario_1069", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Xml" || parametro.FieldName == "nci_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_xml LIKE :nfe_completo_inutilizacao_Xml_1146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Xml_1146", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_inutilizacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.entity_uid LIKE :nfe_completo_inutilizacao_EntityUid_3029 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_EntityUid_3029", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_inutilizacao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.version = :nfe_completo_inutilizacao_Version_2025 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Version_2025", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "nci_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_homologacao = :nfe_completo_inutilizacao_Homologacao_7845 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Homologacao_7845", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Modelo" || parametro.FieldName == "nci_modelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_modelo LIKE :nfe_completo_inutilizacao_Modelo_6649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Modelo_6649", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjExato" || parametro.FieldName == "CnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_cnpj LIKE :nfe_completo_inutilizacao_Cnpj_2048 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Cnpj_2048", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfExato" || parametro.FieldName == "UfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_uf LIKE :nfe_completo_inutilizacao_Uf_3472 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Uf_3472", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaExato" || parametro.FieldName == "JustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_justificativa LIKE :nfe_completo_inutilizacao_Justificativa_7623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Justificativa_7623", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioExato" || parametro.FieldName == "UsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_usuario LIKE :nfe_completo_inutilizacao_Usuario_7392 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Usuario_7392", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XmlExato" || parametro.FieldName == "XmlExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_xml LIKE :nfe_completo_inutilizacao_Xml_2737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Xml_2737", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_inutilizacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.entity_uid LIKE :nfe_completo_inutilizacao_EntityUid_8789 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_EntityUid_8789", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloExato" || parametro.FieldName == "ModeloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_inutilizacao.nci_modelo LIKE :nfe_completo_inutilizacao_Modelo_8924 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_inutilizacao_Modelo_8924", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeCompletoInutilizacaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeCompletoInutilizacaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeCompletoInutilizacaoClass), Convert.ToInt32(read["id_nfe_completo_inutilizacao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeCompletoInutilizacaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_completo_inutilizacao"]);
                     entidade.Cnpj = (read["nci_cnpj"] != DBNull.Value ? read["nci_cnpj"].ToString() : null);
                     entidade.Uf = (read["nci_uf"] != DBNull.Value ? read["nci_uf"].ToString() : null);
                     entidade.Serie = (int)read["nci_serie"];
                     entidade.Inicio = (int)read["nci_inicio"];
                     entidade.Fim = (int)read["nci_fim"];
                     entidade.Justificativa = (read["nci_justificativa"] != DBNull.Value ? read["nci_justificativa"].ToString() : null);
                     entidade.Data = (DateTime)read["nci_data"];
                     entidade.Usuario = (read["nci_usuario"] != DBNull.Value ? read["nci_usuario"].ToString() : null);
                     entidade.Xml = (read["nci_xml"] != DBNull.Value ? read["nci_xml"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["nci_homologacao"]));
                     entidade.Modelo = (read["nci_modelo"] != DBNull.Value ? read["nci_modelo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeCompletoInutilizacaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

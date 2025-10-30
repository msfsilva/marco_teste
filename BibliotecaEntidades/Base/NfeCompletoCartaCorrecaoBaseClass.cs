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
     [Table("nfe_completo_carta_correcao","ncc")]
     public class NfeCompletoCartaCorrecaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeCompletoCartaCorrecaoClass";
protected const string ErroDelete = "Erro ao excluir o NfeCompletoCartaCorrecaoClass  ";
protected const string ErroSave = "Erro ao salvar o NfeCompletoCartaCorrecaoClass.";
protected const string ErroTextoObrigatorio = "O campo Texto é obrigatório";
protected const string ErroTextoComprimento = "O campo Texto deve ter no máximo 1000 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfeCompletoNotaObrigatorio = "O campo NfeCompletoNota é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfeCompletoCartaCorrecaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoCartaCorrecaoClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass _nfeCompletoNotaOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass _nfeCompletoNotaOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass _valueNfeCompletoNota;
        [Column("id_nfe_completo_nota", "nfe_completo_nota", "id_nfe_completo_nota")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass NfeCompletoNota
        { 
           get {                 return this._valueNfeCompletoNota; } 
           set 
           { 
                if (this._valueNfeCompletoNota == value)return;
                 this._valueNfeCompletoNota = value; 
           } 
       } 

       protected int _numeroLoteOriginal{get;private set;}
       private int _numeroLoteOriginalCommited{get; set;}
        private int _valueNumeroLote;
         [Column("ncc_numero_lote")]
        public virtual int NumeroLote
         { 
            get { return this._valueNumeroLote; } 
            set 
            { 
                if (this._valueNumeroLote == value)return;
                 this._valueNumeroLote = value; 
            } 
        } 

       protected DateTime _dataHoraOriginal{get;private set;}
       private DateTime _dataHoraOriginalCommited{get; set;}
        private DateTime _valueDataHora;
         [Column("ncc_data_hora")]
        public virtual DateTime DataHora
         { 
            get { return this._valueDataHora; } 
            set 
            { 
                if (this._valueDataHora == value)return;
                 this._valueDataHora = value; 
            } 
        } 

       protected int _sequencialOriginal{get;private set;}
       private int _sequencialOriginalCommited{get; set;}
        private int _valueSequencial;
         [Column("ncc_sequencial")]
        public virtual int Sequencial
         { 
            get { return this._valueSequencial; } 
            set 
            { 
                if (this._valueSequencial == value)return;
                 this._valueSequencial = value; 
            } 
        } 

       protected string _textoOriginal{get;private set;}
       private string _textoOriginalCommited{get; set;}
        private string _valueTexto;
         [Column("ncc_texto")]
        public virtual string Texto
         { 
            get { return this._valueTexto; } 
            set 
            { 
                if (this._valueTexto == value)return;
                 this._valueTexto = value; 
            } 
        } 

       protected string _xmlOriginal{get;private set;}
       private string _xmlOriginalCommited{get; set;}
        private string _valueXml;
         [Column("ncc_xml")]
        public virtual string Xml
         { 
            get { return this._valueXml; } 
            set 
            { 
                if (this._valueXml == value)return;
                 this._valueXml = value; 
            } 
        } 

       protected int? _retornoOriginal{get;private set;}
       private int? _retornoOriginalCommited{get; set;}
        private int? _valueRetorno;
         [Column("ncc_retorno")]
        public virtual int? Retorno
         { 
            get { return this._valueRetorno; } 
            set 
            { 
                if (this._valueRetorno == value)return;
                 this._valueRetorno = value; 
            } 
        } 

       protected string _retornoDetalhadoOriginal{get;private set;}
       private string _retornoDetalhadoOriginalCommited{get; set;}
        private string _valueRetornoDetalhado;
         [Column("ncc_retorno_detalhado")]
        public virtual string RetornoDetalhado
         { 
            get { return this._valueRetornoDetalhado; } 
            set 
            { 
                if (this._valueRetornoDetalhado == value)return;
                 this._valueRetornoDetalhado = value; 
            } 
        } 

        public NfeCompletoCartaCorrecaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfeCompletoCartaCorrecaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeCompletoCartaCorrecaoClass) GetEntity(typeof(NfeCompletoCartaCorrecaoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Texto))
                {
                    throw new Exception(ErroTextoObrigatorio);
                }
                if (Texto.Length >1000)
                {
                    throw new Exception( ErroTextoComprimento);
                }
                if ( _valueNfeCompletoNota == null)
                {
                    throw new Exception(ErroNfeCompletoNotaObrigatorio);
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
                    "  public.nfe_completo_carta_correcao  " +
                    "WHERE " +
                    "  id_nfe_completo_carta_correcao = :id";
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
                        "  public.nfe_completo_carta_correcao   " +
                        "SET  " + 
                        "  id_nfe_completo_nota = :id_nfe_completo_nota, " + 
                        "  ncc_numero_lote = :ncc_numero_lote, " + 
                        "  ncc_data_hora = :ncc_data_hora, " + 
                        "  ncc_sequencial = :ncc_sequencial, " + 
                        "  ncc_texto = :ncc_texto, " + 
                        "  ncc_xml = :ncc_xml, " + 
                        "  ncc_retorno = :ncc_retorno, " + 
                        "  ncc_retorno_detalhado = :ncc_retorno_detalhado, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_nfe_completo_carta_correcao = :id " +
                        "RETURNING id_nfe_completo_carta_correcao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_completo_carta_correcao " +
                        "( " +
                        "  id_nfe_completo_nota , " + 
                        "  ncc_numero_lote , " + 
                        "  ncc_data_hora , " + 
                        "  ncc_sequencial , " + 
                        "  ncc_texto , " + 
                        "  ncc_xml , " + 
                        "  ncc_retorno , " + 
                        "  ncc_retorno_detalhado , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nfe_completo_nota , " + 
                        "  :ncc_numero_lote , " + 
                        "  :ncc_data_hora , " + 
                        "  :ncc_sequencial , " + 
                        "  :ncc_texto , " + 
                        "  :ncc_xml , " + 
                        "  :ncc_retorno , " + 
                        "  :ncc_retorno_detalhado , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_nfe_completo_carta_correcao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_nota", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfeCompletoNota==null ? (object) DBNull.Value : this.NfeCompletoNota.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_numero_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroLote ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_data_hora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_sequencial", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Sequencial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_texto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Texto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_xml", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Xml ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_retorno", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Retorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_retorno_detalhado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RetornoDetalhado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;

 
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
        public static NfeCompletoCartaCorrecaoClass CopiarEntidade(NfeCompletoCartaCorrecaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeCompletoCartaCorrecaoClass toRet = new NfeCompletoCartaCorrecaoClass(usuario,conn);
 toRet.NfeCompletoNota= entidadeCopiar.NfeCompletoNota;
 toRet.NumeroLote= entidadeCopiar.NumeroLote;
 toRet.DataHora= entidadeCopiar.DataHora;
 toRet.Sequencial= entidadeCopiar.Sequencial;
 toRet.Texto= entidadeCopiar.Texto;
 toRet.Xml= entidadeCopiar.Xml;
 toRet.Retorno= entidadeCopiar.Retorno;
 toRet.RetornoDetalhado= entidadeCopiar.RetornoDetalhado;

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
       _nfeCompletoNotaOriginal = NfeCompletoNota;
       _nfeCompletoNotaOriginalCommited = _nfeCompletoNotaOriginal;
       _numeroLoteOriginal = NumeroLote;
       _numeroLoteOriginalCommited = _numeroLoteOriginal;
       _dataHoraOriginal = DataHora;
       _dataHoraOriginalCommited = _dataHoraOriginal;
       _sequencialOriginal = Sequencial;
       _sequencialOriginalCommited = _sequencialOriginal;
       _textoOriginal = Texto;
       _textoOriginalCommited = _textoOriginal;
       _xmlOriginal = Xml;
       _xmlOriginalCommited = _xmlOriginal;
       _retornoOriginal = Retorno;
       _retornoOriginalCommited = _retornoOriginal;
       _retornoDetalhadoOriginal = RetornoDetalhado;
       _retornoDetalhadoOriginalCommited = _retornoDetalhadoOriginal;
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
       _nfeCompletoNotaOriginalCommited = NfeCompletoNota;
       _numeroLoteOriginalCommited = NumeroLote;
       _dataHoraOriginalCommited = DataHora;
       _sequencialOriginalCommited = Sequencial;
       _textoOriginalCommited = Texto;
       _xmlOriginalCommited = Xml;
       _retornoOriginalCommited = Retorno;
       _retornoDetalhadoOriginalCommited = RetornoDetalhado;
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
               NfeCompletoNota=_nfeCompletoNotaOriginal;
               _nfeCompletoNotaOriginalCommited=_nfeCompletoNotaOriginal;
               NumeroLote=_numeroLoteOriginal;
               _numeroLoteOriginalCommited=_numeroLoteOriginal;
               DataHora=_dataHoraOriginal;
               _dataHoraOriginalCommited=_dataHoraOriginal;
               Sequencial=_sequencialOriginal;
               _sequencialOriginalCommited=_sequencialOriginal;
               Texto=_textoOriginal;
               _textoOriginalCommited=_textoOriginal;
               Xml=_xmlOriginal;
               _xmlOriginalCommited=_xmlOriginal;
               Retorno=_retornoOriginal;
               _retornoOriginalCommited=_retornoOriginal;
               RetornoDetalhado=_retornoDetalhadoOriginal;
               _retornoDetalhadoOriginalCommited=_retornoDetalhadoOriginal;
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
       if (_nfeCompletoNotaOriginal!=null)
       {
          dirty = !_nfeCompletoNotaOriginal.Equals(NfeCompletoNota);
       }
       else
       {
            dirty = NfeCompletoNota != null;
       }
      if (dirty) return true;
       dirty = _numeroLoteOriginal != NumeroLote;
      if (dirty) return true;
       dirty = _dataHoraOriginal != DataHora;
      if (dirty) return true;
       dirty = _sequencialOriginal != Sequencial;
      if (dirty) return true;
       dirty = _textoOriginal != Texto;
      if (dirty) return true;
       dirty = _xmlOriginal != Xml;
      if (dirty) return true;
       dirty = _retornoOriginal != Retorno;
      if (dirty) return true;
       dirty = _retornoDetalhadoOriginal != RetornoDetalhado;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;

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
       if (_nfeCompletoNotaOriginalCommited!=null)
       {
          dirty = !_nfeCompletoNotaOriginalCommited.Equals(NfeCompletoNota);
       }
       else
       {
            dirty = NfeCompletoNota != null;
       }
      if (dirty) return true;
       dirty = _numeroLoteOriginalCommited != NumeroLote;
      if (dirty) return true;
       dirty = _dataHoraOriginalCommited != DataHora;
      if (dirty) return true;
       dirty = _sequencialOriginalCommited != Sequencial;
      if (dirty) return true;
       dirty = _textoOriginalCommited != Texto;
      if (dirty) return true;
       dirty = _xmlOriginalCommited != Xml;
      if (dirty) return true;
       dirty = _retornoOriginalCommited != Retorno;
      if (dirty) return true;
       dirty = _retornoDetalhadoOriginalCommited != RetornoDetalhado;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;

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
             case "NfeCompletoNota":
                return this.NfeCompletoNota;
             case "NumeroLote":
                return this.NumeroLote;
             case "DataHora":
                return this.DataHora;
             case "Sequencial":
                return this.Sequencial;
             case "Texto":
                return this.Texto;
             case "Xml":
                return this.Xml;
             case "Retorno":
                return this.Retorno;
             case "RetornoDetalhado":
                return this.RetornoDetalhado;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfeCompletoNota!=null)
                NfeCompletoNota.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nfe_completo_carta_correcao.id_nfe_completo_carta_correcao) " ;
               }
               else
               {
               command.CommandText += "nfe_completo_carta_correcao.id_nfe_completo_carta_correcao, " ;
               command.CommandText += "nfe_completo_carta_correcao.id_nfe_completo_nota, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_numero_lote, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_data_hora, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_sequencial, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_texto, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_xml, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_retorno, " ;
               command.CommandText += "nfe_completo_carta_correcao.ncc_retorno_detalhado, " ;
               command.CommandText += "nfe_completo_carta_correcao.version, " ;
               command.CommandText += "nfe_completo_carta_correcao.entity_uid " ;
               }
               command.CommandText += " FROM  nfe_completo_carta_correcao ";
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
                        orderByClause += " , ncc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ncc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_completo_carta_correcao.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_completo_carta_correcao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_carta_correcao.id_nfe_completo_carta_correcao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.id_nfe_completo_carta_correcao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nfe_completo_nota":
                     case "NfeCompletoNota":
                     command.CommandText += " LEFT JOIN nfe_completo_nota as nfe_completo_nota_NfeCompletoNota ON nfe_completo_nota_NfeCompletoNota.id_nfe_completo_nota = nfe_completo_carta_correcao.id_nfe_completo_nota ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_nota_NfeCompletoNota.nfn_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_nota_NfeCompletoNota.nfn_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_numero_lote":
                     case "NumeroLote":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_numero_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_numero_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_data_hora":
                     case "DataHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_data_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_data_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_sequencial":
                     case "Sequencial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_sequencial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_sequencial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_texto":
                     case "Texto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_texto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_texto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_xml":
                     case "Xml":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_xml " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_xml) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_retorno":
                     case "Retorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_retorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_retorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ncc_retorno_detalhado":
                     case "RetornoDetalhado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_carta_correcao.ncc_retorno_detalhado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.ncc_retorno_detalhado) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_completo_carta_correcao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_carta_correcao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_carta_correcao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncc_texto")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_carta_correcao.ncc_texto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_carta_correcao.ncc_texto) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncc_xml")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_carta_correcao.ncc_xml) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_carta_correcao.ncc_xml) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ncc_retorno_detalhado")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_carta_correcao.ncc_retorno_detalhado) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_carta_correcao.ncc_retorno_detalhado) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_carta_correcao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_carta_correcao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_completo_carta_correcao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.id_nfe_completo_carta_correcao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.id_nfe_completo_carta_correcao = :nfe_completo_carta_correcao_ID_6090 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_ID_6090", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfeCompletoNota" || parametro.FieldName == "id_nfe_completo_nota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.id_nfe_completo_nota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.id_nfe_completo_nota = :nfe_completo_carta_correcao_NfeCompletoNota_8081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_NfeCompletoNota_8081", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroLote" || parametro.FieldName == "ncc_numero_lote")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_numero_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_numero_lote = :nfe_completo_carta_correcao_NumeroLote_8813 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_NumeroLote_8813", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHora" || parametro.FieldName == "ncc_data_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_data_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_data_hora = :nfe_completo_carta_correcao_DataHora_6084 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_DataHora_6084", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Sequencial" || parametro.FieldName == "ncc_sequencial")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_sequencial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_sequencial = :nfe_completo_carta_correcao_Sequencial_1580 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Sequencial_1580", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Texto" || parametro.FieldName == "ncc_texto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_texto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_texto LIKE :nfe_completo_carta_correcao_Texto_2165 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Texto_2165", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Xml" || parametro.FieldName == "ncc_xml")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_xml LIKE :nfe_completo_carta_correcao_Xml_8883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Xml_8883", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Retorno" || parametro.FieldName == "ncc_retorno")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_retorno = :nfe_completo_carta_correcao_Retorno_8701 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Retorno_8701", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RetornoDetalhado" || parametro.FieldName == "ncc_retorno_detalhado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_retorno_detalhado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_retorno_detalhado LIKE :nfe_completo_carta_correcao_RetornoDetalhado_864 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_RetornoDetalhado_864", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_carta_correcao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.version = :nfe_completo_carta_correcao_Version_146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Version_146", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nfe_completo_carta_correcao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.entity_uid LIKE :nfe_completo_carta_correcao_EntityUid_906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_EntityUid_906", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TextoExato" || parametro.FieldName == "TextoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_texto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_texto LIKE :nfe_completo_carta_correcao_Texto_6939 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Texto_6939", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_carta_correcao.ncc_xml IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_xml LIKE :nfe_completo_carta_correcao_Xml_7837 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_Xml_7837", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RetornoDetalhadoExato" || parametro.FieldName == "RetornoDetalhadoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_retorno_detalhado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.ncc_retorno_detalhado LIKE :nfe_completo_carta_correcao_RetornoDetalhado_9889 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_RetornoDetalhado_9889", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_carta_correcao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_carta_correcao.entity_uid LIKE :nfe_completo_carta_correcao_EntityUid_4043 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_carta_correcao_EntityUid_4043", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeCompletoCartaCorrecaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeCompletoCartaCorrecaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeCompletoCartaCorrecaoClass), Convert.ToInt32(read["id_nfe_completo_carta_correcao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeCompletoCartaCorrecaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_completo_carta_correcao"]);
                     if (read["id_nfe_completo_nota"] != DBNull.Value)
                     {
                        entidade.NfeCompletoNota = (IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass)IWTNFCompleto.BibliotecaEntidades.Entidades.NfeCompletoNotaClass.GetEntidade(Convert.ToInt32(read["id_nfe_completo_nota"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfeCompletoNota = null ;
                     }
                     entidade.NumeroLote = (int)read["ncc_numero_lote"];
                     entidade.DataHora = (DateTime)read["ncc_data_hora"];
                     entidade.Sequencial = (int)read["ncc_sequencial"];
                     entidade.Texto = (read["ncc_texto"] != DBNull.Value ? read["ncc_texto"].ToString() : null);
                     entidade.Xml = (read["ncc_xml"] != DBNull.Value ? read["ncc_xml"].ToString() : null);
                     entidade.Retorno = read["ncc_retorno"] as int?;
                     entidade.RetornoDetalhado = (read["ncc_retorno_detalhado"] != DBNull.Value ? read["ncc_retorno_detalhado"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeCompletoCartaCorrecaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

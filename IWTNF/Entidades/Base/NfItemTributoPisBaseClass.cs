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
     [Table("nf_item_tributo_pis","ntp")]
     public class NfItemTributoPisBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfItemTributoPisClass";
protected const string ErroDelete = "Erro ao excluir o NfItemTributoPisClass  ";
protected const string ErroSave = "Erro ao salvar o NfItemTributoPisClass.";
protected const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected const string ErroCstComprimento = "O campo Cst deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfItemTributoPisClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemTributoPisClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfItemClass _valueNfItem;
        [Column("id_nf_item", "nf_item", "id_nf_item")]
       public virtual IWTNF.Entidades.Entidades.NfItemClass NfItem
        { 
           get {                 return this._valueNfItem; } 
           set 
           { 
                if (this._valueNfItem == value)return;
                 this._valueNfItem = value; 
           } 
       } 

       protected string _cstOriginal{get;private set;}
       private string _cstOriginalCommited{get; set;}
        private string _valueCst;
         [Column("ntp_cst")]
        public virtual string Cst
         { 
            get { return this._valueCst; } 
            set 
            { 
                if (this._valueCst == value)return;
                 this._valueCst = value; 
            } 
        } 

       protected double _aliquotaOriginal{get;private set;}
       private double _aliquotaOriginalCommited{get; set;}
        private double _valueAliquota;
         [Column("ntp_aliquota")]
        public virtual double Aliquota
         { 
            get { return this._valueAliquota; } 
            set 
            { 
                if (this._valueAliquota == value)return;
                 this._valueAliquota = value; 
            } 
        } 

       protected ModalidadeTributacao _modalidadeTributacaoOriginal{get;private set;}
       private ModalidadeTributacao _modalidadeTributacaoOriginalCommited{get; set;}
        private ModalidadeTributacao _valueModalidadeTributacao;
         [Column("ntp_modalidade_tributacao")]
        public virtual ModalidadeTributacao ModalidadeTributacao
         { 
            get { return this._valueModalidadeTributacao; } 
            set 
            { 
                if (this._valueModalidadeTributacao == value)return;
                 this._valueModalidadeTributacao = value; 
            } 
        } 

        public bool ModalidadeTributacao_Valor
         { 
            get { return this._valueModalidadeTributacao == IWTNF.Entidades.Base.ModalidadeTributacao.Valor; } 
            set { if (value) this._valueModalidadeTributacao = IWTNF.Entidades.Base.ModalidadeTributacao.Valor; }
         } 

        public bool ModalidadeTributacao_Quantidade
         { 
            get { return this._valueModalidadeTributacao == IWTNF.Entidades.Base.ModalidadeTributacao.Quantidade; } 
            set { if (value) this._valueModalidadeTributacao = IWTNF.Entidades.Base.ModalidadeTributacao.Quantidade; }
         } 

        public bool ModalidadeTributacao_NaoTributado
         { 
            get { return this._valueModalidadeTributacao == IWTNF.Entidades.Base.ModalidadeTributacao.NaoTributado; } 
            set { if (value) this._valueModalidadeTributacao = IWTNF.Entidades.Base.ModalidadeTributacao.NaoTributado; }
         } 

       protected double _valorBcOriginal{get;private set;}
       private double _valorBcOriginalCommited{get; set;}
        private double _valueValorBc;
         [Column("ntp_valor_bc")]
        public virtual double ValorBc
         { 
            get { return this._valueValorBc; } 
            set 
            { 
                if (this._valueValorBc == value)return;
                 this._valueValorBc = value; 
            } 
        } 

       protected double _quantidadeVendidaOriginal{get;private set;}
       private double _quantidadeVendidaOriginalCommited{get; set;}
        private double _valueQuantidadeVendida;
         [Column("ntp_quantidade_vendida")]
        public virtual double QuantidadeVendida
         { 
            get { return this._valueQuantidadeVendida; } 
            set 
            { 
                if (this._valueQuantidadeVendida == value)return;
                 this._valueQuantidadeVendida = value; 
            } 
        } 

       protected double _valorPisOriginal{get;private set;}
       private double _valorPisOriginalCommited{get; set;}
        private double _valueValorPis;
         [Column("ntp_valor_pis")]
        public virtual double ValorPis
         { 
            get { return this._valueValorPis; } 
            set 
            { 
                if (this._valueValorPis == value)return;
                 this._valueValorPis = value; 
            } 
        } 

       protected short _impostoRetidoOriginal{get;private set;}
       private short _impostoRetidoOriginalCommited{get; set;}
        private short _valueImpostoRetido;
         [Column("ntp_imposto_retido")]
        public virtual short ImpostoRetido
         { 
            get { return this._valueImpostoRetido; } 
            set 
            { 
                if (this._valueImpostoRetido == value)return;
                 this._valueImpostoRetido = value; 
            } 
        } 

        public NfItemTributoPisBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfItemTributoPisClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfItemTributoPisClass) GetEntity(typeof(NfItemTributoPisClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Cst))
                {
                    throw new Exception(ErroCstObrigatorio);
                }
                if (Cst.Length >2)
                {
                    throw new Exception( ErroCstComprimento);
                }
                if ( _valueNfItem == null)
                {
                    throw new Exception(ErroNfItemObrigatorio);
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
                    "  public.nf_item_tributo_pis  " +
                    "WHERE " +
                    "  id_nf_item_tributo_pis = :id";
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
                        "  public.nf_item_tributo_pis   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  ntp_cst = :ntp_cst, " + 
                        "  ntp_aliquota = :ntp_aliquota, " + 
                        "  ntp_modalidade_tributacao = :ntp_modalidade_tributacao, " + 
                        "  ntp_valor_bc = :ntp_valor_bc, " + 
                        "  ntp_quantidade_vendida = :ntp_quantidade_vendida, " + 
                        "  ntp_valor_pis = :ntp_valor_pis, " + 
                        "  ntp_imposto_retido = :ntp_imposto_retido, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_nf_item_tributo_pis = :id " +
                        "RETURNING id_nf_item_tributo_pis;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_item_tributo_pis " +
                        "( " +
                        "  id_nf_item , " + 
                        "  ntp_cst , " + 
                        "  ntp_aliquota , " + 
                        "  ntp_modalidade_tributacao , " + 
                        "  ntp_valor_bc , " + 
                        "  ntp_quantidade_vendida , " + 
                        "  ntp_valor_pis , " + 
                        "  ntp_imposto_retido , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :ntp_cst , " + 
                        "  :ntp_aliquota , " + 
                        "  :ntp_modalidade_tributacao , " + 
                        "  :ntp_valor_bc , " + 
                        "  :ntp_quantidade_vendida , " + 
                        "  :ntp_valor_pis , " + 
                        "  :ntp_imposto_retido , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_nf_item_tributo_pis;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_modalidade_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeTributacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_valor_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_quantidade_vendida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeVendida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_valor_pis", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorPis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntp_imposto_retido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImpostoRetido ?? DBNull.Value;
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
        public static NfItemTributoPisClass CopiarEntidade(NfItemTributoPisClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfItemTributoPisClass toRet = new NfItemTributoPisClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.Cst= entidadeCopiar.Cst;
 toRet.Aliquota= entidadeCopiar.Aliquota;
 toRet.ModalidadeTributacao= entidadeCopiar.ModalidadeTributacao;
 toRet.ValorBc= entidadeCopiar.ValorBc;
 toRet.QuantidadeVendida= entidadeCopiar.QuantidadeVendida;
 toRet.ValorPis= entidadeCopiar.ValorPis;
 toRet.ImpostoRetido= entidadeCopiar.ImpostoRetido;

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
       _nfItemOriginal = NfItem;
       _nfItemOriginalCommited = _nfItemOriginal;
       _cstOriginal = Cst;
       _cstOriginalCommited = _cstOriginal;
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
       _modalidadeTributacaoOriginal = ModalidadeTributacao;
       _modalidadeTributacaoOriginalCommited = _modalidadeTributacaoOriginal;
       _valorBcOriginal = ValorBc;
       _valorBcOriginalCommited = _valorBcOriginal;
       _quantidadeVendidaOriginal = QuantidadeVendida;
       _quantidadeVendidaOriginalCommited = _quantidadeVendidaOriginal;
       _valorPisOriginal = ValorPis;
       _valorPisOriginalCommited = _valorPisOriginal;
       _impostoRetidoOriginal = ImpostoRetido;
       _impostoRetidoOriginalCommited = _impostoRetidoOriginal;
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
       _nfItemOriginalCommited = NfItem;
       _cstOriginalCommited = Cst;
       _aliquotaOriginalCommited = Aliquota;
       _modalidadeTributacaoOriginalCommited = ModalidadeTributacao;
       _valorBcOriginalCommited = ValorBc;
       _quantidadeVendidaOriginalCommited = QuantidadeVendida;
       _valorPisOriginalCommited = ValorPis;
       _impostoRetidoOriginalCommited = ImpostoRetido;
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
               NfItem=_nfItemOriginal;
               _nfItemOriginalCommited=_nfItemOriginal;
               Cst=_cstOriginal;
               _cstOriginalCommited=_cstOriginal;
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
               ModalidadeTributacao=_modalidadeTributacaoOriginal;
               _modalidadeTributacaoOriginalCommited=_modalidadeTributacaoOriginal;
               ValorBc=_valorBcOriginal;
               _valorBcOriginalCommited=_valorBcOriginal;
               QuantidadeVendida=_quantidadeVendidaOriginal;
               _quantidadeVendidaOriginalCommited=_quantidadeVendidaOriginal;
               ValorPis=_valorPisOriginal;
               _valorPisOriginalCommited=_valorPisOriginal;
               ImpostoRetido=_impostoRetidoOriginal;
               _impostoRetidoOriginalCommited=_impostoRetidoOriginal;
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
       if (_nfItemOriginal!=null)
       {
          dirty = !_nfItemOriginal.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _cstOriginal != Cst;
      if (dirty) return true;
       dirty = _aliquotaOriginal != Aliquota;
      if (dirty) return true;
       dirty = _modalidadeTributacaoOriginal != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _valorBcOriginal != ValorBc;
      if (dirty) return true;
       dirty = _quantidadeVendidaOriginal != QuantidadeVendida;
      if (dirty) return true;
       dirty = _valorPisOriginal != ValorPis;
      if (dirty) return true;
       dirty = _impostoRetidoOriginal != ImpostoRetido;
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
       if (_nfItemOriginalCommited!=null)
       {
          dirty = !_nfItemOriginalCommited.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _cstOriginalCommited != Cst;
      if (dirty) return true;
       dirty = _aliquotaOriginalCommited != Aliquota;
      if (dirty) return true;
       dirty = _modalidadeTributacaoOriginalCommited != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _valorBcOriginalCommited != ValorBc;
      if (dirty) return true;
       dirty = _quantidadeVendidaOriginalCommited != QuantidadeVendida;
      if (dirty) return true;
       dirty = _valorPisOriginalCommited != ValorPis;
      if (dirty) return true;
       dirty = _impostoRetidoOriginalCommited != ImpostoRetido;
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
             case "NfItem":
                return this.NfItem;
             case "Cst":
                return this.Cst;
             case "Aliquota":
                return this.Aliquota;
             case "ModalidadeTributacao":
                return this.ModalidadeTributacao;
             case "ValorBc":
                return this.ValorBc;
             case "QuantidadeVendida":
                return this.QuantidadeVendida;
             case "ValorPis":
                return this.ValorPis;
             case "ImpostoRetido":
                return this.ImpostoRetido;
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
             if (NfItem!=null)
                NfItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nf_item_tributo_pis.id_nf_item_tributo_pis) " ;
               }
               else
               {
               command.CommandText += "nf_item_tributo_pis.id_nf_item, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_cst, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_aliquota, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_modalidade_tributacao, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_valor_bc, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_quantidade_vendida, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_valor_pis, " ;
               command.CommandText += "nf_item_tributo_pis.ntp_imposto_retido, " ;
               command.CommandText += "nf_item_tributo_pis.entity_uid, " ;
               command.CommandText += "nf_item_tributo_pis.version, " ;
               command.CommandText += "nf_item_tributo_pis.id_nf_item_tributo_pis " ;
               }
               command.CommandText += " FROM  nf_item_tributo_pis ";
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
                        orderByClause += " , ntp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ntp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_item_tributo_pis.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_item_tributo_pis.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "ntp_cst":
                     case "Cst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_pis.ntp_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntp_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.ntp_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntp_modalidade_tributacao":
                     case "ModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.ntp_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntp_valor_bc":
                     case "ValorBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.ntp_valor_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_valor_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntp_quantidade_vendida":
                     case "QuantidadeVendida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.ntp_quantidade_vendida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_quantidade_vendida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntp_valor_pis":
                     case "ValorPis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.ntp_valor_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_valor_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntp_imposto_retido":
                     case "ImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.ntp_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.ntp_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_pis.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_pis.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_item_tributo_pis.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item_tributo_pis":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_pis.id_nf_item_tributo_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_pis.id_nf_item_tributo_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntp_cst")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_pis.ntp_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_pis.ntp_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_pis.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_pis.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "NfItem" || parametro.FieldName == "id_nf_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.id_nf_item = :nf_item_tributo_pis_NfItem_9235 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_NfItem_9235", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cst" || parametro.FieldName == "ntp_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_cst LIKE :nf_item_tributo_pis_Cst_9342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_Cst_9342", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "ntp_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_aliquota = :nf_item_tributo_pis_Aliquota_7504 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_Aliquota_7504", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeTributacao" || parametro.FieldName == "ntp_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeTributacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeTributacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_modalidade_tributacao = :nf_item_tributo_pis_ModalidadeTributacao_5862 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_ModalidadeTributacao_5862", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBc" || parametro.FieldName == "ntp_valor_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_valor_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_valor_bc = :nf_item_tributo_pis_ValorBc_8500 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_ValorBc_8500", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeVendida" || parametro.FieldName == "ntp_quantidade_vendida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_quantidade_vendida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_quantidade_vendida = :nf_item_tributo_pis_QuantidadeVendida_1987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_QuantidadeVendida_1987", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorPis" || parametro.FieldName == "ntp_valor_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_valor_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_valor_pis = :nf_item_tributo_pis_ValorPis_9312 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_ValorPis_9312", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImpostoRetido" || parametro.FieldName == "ntp_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_imposto_retido = :nf_item_tributo_pis_ImpostoRetido_6484 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_ImpostoRetido_6484", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  nf_item_tributo_pis.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.entity_uid LIKE :nf_item_tributo_pis_EntityUid_1003 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_EntityUid_1003", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_item_tributo_pis.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.version = :nf_item_tributo_pis_Version_1753 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_Version_1753", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_item_tributo_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.id_nf_item_tributo_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.id_nf_item_tributo_pis = :nf_item_tributo_pis_ID_4966 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_ID_4966", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstExato" || parametro.FieldName == "CstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.ntp_cst LIKE :nf_item_tributo_pis_Cst_3299 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_Cst_3299", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_item_tributo_pis.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_pis.entity_uid LIKE :nf_item_tributo_pis_EntityUid_1383 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_pis_EntityUid_1383", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfItemTributoPisClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfItemTributoPisClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfItemTributoPisClass), Convert.ToInt32(read["id_nf_item_tributo_pis"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfItemTributoPisClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.Cst = (read["ntp_cst"] != DBNull.Value ? read["ntp_cst"].ToString() : null);
                     entidade.Aliquota = (double)read["ntp_aliquota"];
                     entidade.ModalidadeTributacao = (ModalidadeTributacao) (read["ntp_modalidade_tributacao"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeTributacao), read["ntp_modalidade_tributacao"]) : null);
                     entidade.ValorBc = (double)read["ntp_valor_bc"];
                     entidade.QuantidadeVendida = (double)read["ntp_quantidade_vendida"];
                     entidade.ValorPis = (double)read["ntp_valor_pis"];
                     entidade.ImpostoRetido = (short)read["ntp_imposto_retido"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_item_tributo_pis"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfItemTributoPisClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

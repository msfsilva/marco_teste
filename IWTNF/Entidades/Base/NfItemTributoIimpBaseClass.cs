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
     [Table("nf_item_tributo_iimp","ntm")]
     public class NfItemTributoIimpBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfItemTributoIimpClass";
protected const string ErroDelete = "Erro ao excluir o NfItemTributoIimpClass  ";
protected const string ErroSave = "Erro ao salvar o NfItemTributoIimpClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfItemTributoIimpClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemTributoIimpClass está sendo utilizada.";
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

       protected double _aliquotaOriginal{get;private set;}
       private double _aliquotaOriginalCommited{get; set;}
        private double _valueAliquota;
         [Column("ntm_aliquota")]
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
         [Column("ntm_modalidade_tributacao")]
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
         [Column("ntm_valor_bc")]
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
         [Column("ntm_quantidade_vendida")]
        public virtual double QuantidadeVendida
         { 
            get { return this._valueQuantidadeVendida; } 
            set 
            { 
                if (this._valueQuantidadeVendida == value)return;
                 this._valueQuantidadeVendida = value; 
            } 
        } 

       protected double _valorIimpOriginal{get;private set;}
       private double _valorIimpOriginalCommited{get; set;}
        private double _valueValorIimp;
         [Column("ntm_valor_iimp")]
        public virtual double ValorIimp
         { 
            get { return this._valueValorIimp; } 
            set 
            { 
                if (this._valueValorIimp == value)return;
                 this._valueValorIimp = value; 
            } 
        } 

       protected double _valorDespesasAduaneirasOriginal{get;private set;}
       private double _valorDespesasAduaneirasOriginalCommited{get; set;}
        private double _valueValorDespesasAduaneiras;
         [Column("ntm_valor_despesas_aduaneiras")]
        public virtual double ValorDespesasAduaneiras
         { 
            get { return this._valueValorDespesasAduaneiras; } 
            set 
            { 
                if (this._valueValorDespesasAduaneiras == value)return;
                 this._valueValorDespesasAduaneiras = value; 
            } 
        } 

       protected double _valorIofOriginal{get;private set;}
       private double _valorIofOriginalCommited{get; set;}
        private double _valueValorIof;
         [Column("ntm_valor_iof")]
        public virtual double ValorIof
         { 
            get { return this._valueValorIof; } 
            set 
            { 
                if (this._valueValorIof == value)return;
                 this._valueValorIof = value; 
            } 
        } 

        public NfItemTributoIimpBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfItemTributoIimpClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfItemTributoIimpClass) GetEntity(typeof(NfItemTributoIimpClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
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
                    "  public.nf_item_tributo_iimp  " +
                    "WHERE " +
                    "  id_nf_item_tributo_iimp = :id";
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
                        "  public.nf_item_tributo_iimp   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  ntm_aliquota = :ntm_aliquota, " + 
                        "  ntm_modalidade_tributacao = :ntm_modalidade_tributacao, " + 
                        "  ntm_valor_bc = :ntm_valor_bc, " + 
                        "  ntm_quantidade_vendida = :ntm_quantidade_vendida, " + 
                        "  ntm_valor_iimp = :ntm_valor_iimp, " + 
                        "  ntm_valor_despesas_aduaneiras = :ntm_valor_despesas_aduaneiras, " + 
                        "  ntm_valor_iof = :ntm_valor_iof, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_nf_item_tributo_iimp = :id " +
                        "RETURNING id_nf_item_tributo_iimp;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_item_tributo_iimp " +
                        "( " +
                        "  id_nf_item , " + 
                        "  ntm_aliquota , " + 
                        "  ntm_modalidade_tributacao , " + 
                        "  ntm_valor_bc , " + 
                        "  ntm_quantidade_vendida , " + 
                        "  ntm_valor_iimp , " + 
                        "  ntm_valor_despesas_aduaneiras , " + 
                        "  ntm_valor_iof , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :ntm_aliquota , " + 
                        "  :ntm_modalidade_tributacao , " + 
                        "  :ntm_valor_bc , " + 
                        "  :ntm_quantidade_vendida , " + 
                        "  :ntm_valor_iimp , " + 
                        "  :ntm_valor_despesas_aduaneiras , " + 
                        "  :ntm_valor_iof , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_nf_item_tributo_iimp;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_modalidade_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeTributacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_valor_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_quantidade_vendida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeVendida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_valor_iimp", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIimp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_valor_despesas_aduaneiras", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorDespesasAduaneiras ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntm_valor_iof", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIof ?? DBNull.Value;
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
        public static NfItemTributoIimpClass CopiarEntidade(NfItemTributoIimpClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfItemTributoIimpClass toRet = new NfItemTributoIimpClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.Aliquota= entidadeCopiar.Aliquota;
 toRet.ModalidadeTributacao= entidadeCopiar.ModalidadeTributacao;
 toRet.ValorBc= entidadeCopiar.ValorBc;
 toRet.QuantidadeVendida= entidadeCopiar.QuantidadeVendida;
 toRet.ValorIimp= entidadeCopiar.ValorIimp;
 toRet.ValorDespesasAduaneiras= entidadeCopiar.ValorDespesasAduaneiras;
 toRet.ValorIof= entidadeCopiar.ValorIof;

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
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
       _modalidadeTributacaoOriginal = ModalidadeTributacao;
       _modalidadeTributacaoOriginalCommited = _modalidadeTributacaoOriginal;
       _valorBcOriginal = ValorBc;
       _valorBcOriginalCommited = _valorBcOriginal;
       _quantidadeVendidaOriginal = QuantidadeVendida;
       _quantidadeVendidaOriginalCommited = _quantidadeVendidaOriginal;
       _valorIimpOriginal = ValorIimp;
       _valorIimpOriginalCommited = _valorIimpOriginal;
       _valorDespesasAduaneirasOriginal = ValorDespesasAduaneiras;
       _valorDespesasAduaneirasOriginalCommited = _valorDespesasAduaneirasOriginal;
       _valorIofOriginal = ValorIof;
       _valorIofOriginalCommited = _valorIofOriginal;
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
       _aliquotaOriginalCommited = Aliquota;
       _modalidadeTributacaoOriginalCommited = ModalidadeTributacao;
       _valorBcOriginalCommited = ValorBc;
       _quantidadeVendidaOriginalCommited = QuantidadeVendida;
       _valorIimpOriginalCommited = ValorIimp;
       _valorDespesasAduaneirasOriginalCommited = ValorDespesasAduaneiras;
       _valorIofOriginalCommited = ValorIof;
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
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
               ModalidadeTributacao=_modalidadeTributacaoOriginal;
               _modalidadeTributacaoOriginalCommited=_modalidadeTributacaoOriginal;
               ValorBc=_valorBcOriginal;
               _valorBcOriginalCommited=_valorBcOriginal;
               QuantidadeVendida=_quantidadeVendidaOriginal;
               _quantidadeVendidaOriginalCommited=_quantidadeVendidaOriginal;
               ValorIimp=_valorIimpOriginal;
               _valorIimpOriginalCommited=_valorIimpOriginal;
               ValorDespesasAduaneiras=_valorDespesasAduaneirasOriginal;
               _valorDespesasAduaneirasOriginalCommited=_valorDespesasAduaneirasOriginal;
               ValorIof=_valorIofOriginal;
               _valorIofOriginalCommited=_valorIofOriginal;
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
       dirty = _aliquotaOriginal != Aliquota;
      if (dirty) return true;
       dirty = _modalidadeTributacaoOriginal != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _valorBcOriginal != ValorBc;
      if (dirty) return true;
       dirty = _quantidadeVendidaOriginal != QuantidadeVendida;
      if (dirty) return true;
       dirty = _valorIimpOriginal != ValorIimp;
      if (dirty) return true;
       dirty = _valorDespesasAduaneirasOriginal != ValorDespesasAduaneiras;
      if (dirty) return true;
       dirty = _valorIofOriginal != ValorIof;
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
       dirty = _aliquotaOriginalCommited != Aliquota;
      if (dirty) return true;
       dirty = _modalidadeTributacaoOriginalCommited != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _valorBcOriginalCommited != ValorBc;
      if (dirty) return true;
       dirty = _quantidadeVendidaOriginalCommited != QuantidadeVendida;
      if (dirty) return true;
       dirty = _valorIimpOriginalCommited != ValorIimp;
      if (dirty) return true;
       dirty = _valorDespesasAduaneirasOriginalCommited != ValorDespesasAduaneiras;
      if (dirty) return true;
       dirty = _valorIofOriginalCommited != ValorIof;
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
             case "Aliquota":
                return this.Aliquota;
             case "ModalidadeTributacao":
                return this.ModalidadeTributacao;
             case "ValorBc":
                return this.ValorBc;
             case "QuantidadeVendida":
                return this.QuantidadeVendida;
             case "ValorIimp":
                return this.ValorIimp;
             case "ValorDespesasAduaneiras":
                return this.ValorDespesasAduaneiras;
             case "ValorIof":
                return this.ValorIof;
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
                  command.CommandText += " COUNT(nf_item_tributo_iimp.id_nf_item_tributo_iimp) " ;
               }
               else
               {
               command.CommandText += "nf_item_tributo_iimp.id_nf_item, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_aliquota, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_modalidade_tributacao, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_valor_bc, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_quantidade_vendida, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_valor_iimp, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_valor_despesas_aduaneiras, " ;
               command.CommandText += "nf_item_tributo_iimp.ntm_valor_iof, " ;
               command.CommandText += "nf_item_tributo_iimp.entity_uid, " ;
               command.CommandText += "nf_item_tributo_iimp.version, " ;
               command.CommandText += "nf_item_tributo_iimp.id_nf_item_tributo_iimp " ;
               }
               command.CommandText += " FROM  nf_item_tributo_iimp ";
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
                        orderByClause += " , ntm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ntm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_item_tributo_iimp.id_acs_usuario_ultima_revisao ";
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
                     orderByClause += " , nf_item_tributo_iimp.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "ntm_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntm_modalidade_tributacao":
                     case "ModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntm_valor_bc":
                     case "ValorBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_valor_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_valor_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntm_quantidade_vendida":
                     case "QuantidadeVendida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_quantidade_vendida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_quantidade_vendida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntm_valor_iimp":
                     case "ValorIimp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_valor_iimp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_valor_iimp) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntm_valor_despesas_aduaneiras":
                     case "ValorDespesasAduaneiras":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_valor_despesas_aduaneiras " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_valor_despesas_aduaneiras) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntm_valor_iof":
                     case "ValorIof":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.ntm_valor_iof " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.ntm_valor_iof) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_iimp.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_item_tributo_iimp.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item_tributo_iimp":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_iimp.id_nf_item_tributo_iimp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_iimp.id_nf_item_tributo_iimp) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_iimp.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_iimp.entity_uid) LIKE :buscaCompletaLower ";
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
                         whereClause += "  nf_item_tributo_iimp.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.id_nf_item = :nf_item_tributo_iimp_NfItem_7284 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_NfItem_7284", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "ntm_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_aliquota = :nf_item_tributo_iimp_Aliquota_8382 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_Aliquota_8382", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeTributacao" || parametro.FieldName == "ntm_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeTributacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeTributacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_modalidade_tributacao = :nf_item_tributo_iimp_ModalidadeTributacao_819 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_ModalidadeTributacao_819", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBc" || parametro.FieldName == "ntm_valor_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_bc = :nf_item_tributo_iimp_ValorBc_9694 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_ValorBc_9694", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeVendida" || parametro.FieldName == "ntm_quantidade_vendida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_quantidade_vendida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_quantidade_vendida = :nf_item_tributo_iimp_QuantidadeVendida_8539 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_QuantidadeVendida_8539", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIimp" || parametro.FieldName == "ntm_valor_iimp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_iimp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_iimp = :nf_item_tributo_iimp_ValorIimp_1079 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_ValorIimp_1079", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorDespesasAduaneiras" || parametro.FieldName == "ntm_valor_despesas_aduaneiras")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_despesas_aduaneiras IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_despesas_aduaneiras = :nf_item_tributo_iimp_ValorDespesasAduaneiras_416 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_ValorDespesasAduaneiras_416", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIof" || parametro.FieldName == "ntm_valor_iof")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_iof IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.ntm_valor_iof = :nf_item_tributo_iimp_ValorIof_963 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_ValorIof_963", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_item_tributo_iimp.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.entity_uid LIKE :nf_item_tributo_iimp_EntityUid_2650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_EntityUid_2650", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_item_tributo_iimp.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.version = :nf_item_tributo_iimp_Version_7439 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_Version_7439", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_item_tributo_iimp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_iimp.id_nf_item_tributo_iimp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.id_nf_item_tributo_iimp = :nf_item_tributo_iimp_ID_6580 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_ID_6580", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_item_tributo_iimp.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_iimp.entity_uid LIKE :nf_item_tributo_iimp_EntityUid_1278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_iimp_EntityUid_1278", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfItemTributoIimpClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfItemTributoIimpClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfItemTributoIimpClass), Convert.ToInt32(read["id_nf_item_tributo_iimp"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfItemTributoIimpClass(UsuarioAtual, SingleConnection);
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
                     entidade.Aliquota = (double)read["ntm_aliquota"];
                     entidade.ModalidadeTributacao = (ModalidadeTributacao) (read["ntm_modalidade_tributacao"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeTributacao), read["ntm_modalidade_tributacao"]) : null);
                     entidade.ValorBc = (double)read["ntm_valor_bc"];
                     entidade.QuantidadeVendida = (double)read["ntm_quantidade_vendida"];
                     entidade.ValorIimp = (double)read["ntm_valor_iimp"];
                     entidade.ValorDespesasAduaneiras = (double)read["ntm_valor_despesas_aduaneiras"];
                     entidade.ValorIof = (double)read["ntm_valor_iof"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_item_tributo_iimp"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfItemTributoIimpClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

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
     [Table("nf_produto_ipi","npi")]
     public class NfProdutoIpiBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoIpiClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoIpiClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoIpiClass.";
protected const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected const string ErroCstComprimento = "O campo Cst deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoIpiClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoIpiClass está sendo utilizada.";
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

       protected string _classeEnquadramentoCigarrosBebidasOriginal{get;private set;}
       private string _classeEnquadramentoCigarrosBebidasOriginalCommited{get; set;}
        private string _valueClasseEnquadramentoCigarrosBebidas;
         [Column("npi_classe_enquadramento_cigarros_bebidas")]
        public virtual string ClasseEnquadramentoCigarrosBebidas
         { 
            get { return this._valueClasseEnquadramentoCigarrosBebidas; } 
            set 
            { 
                if (this._valueClasseEnquadramentoCigarrosBebidas == value)return;
                 this._valueClasseEnquadramentoCigarrosBebidas = value; 
            } 
        } 

       protected string _cnpjProdutorOriginal{get;private set;}
       private string _cnpjProdutorOriginalCommited{get; set;}
        private string _valueCnpjProdutor;
         [Column("npi_cnpj_produtor")]
        public virtual string CnpjProdutor
         { 
            get { return this._valueCnpjProdutor; } 
            set 
            { 
                if (this._valueCnpjProdutor == value)return;
                 this._valueCnpjProdutor = value; 
            } 
        } 

       protected string _classeEnquadramentoOriginal{get;private set;}
       private string _classeEnquadramentoOriginalCommited{get; set;}
        private string _valueClasseEnquadramento;
         [Column("npi_classe_enquadramento")]
        public virtual string ClasseEnquadramento
         { 
            get { return this._valueClasseEnquadramento; } 
            set 
            { 
                if (this._valueClasseEnquadramento == value)return;
                 this._valueClasseEnquadramento = value; 
            } 
        } 

       protected string _cstOriginal{get;private set;}
       private string _cstOriginalCommited{get; set;}
        private string _valueCst;
         [Column("npi_cst")]
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
         [Column("npi_aliquota")]
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
         [Column("npi_modalidade_tributacao")]
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

       protected double _quantidadeVendidaOriginal{get;private set;}
       private double _quantidadeVendidaOriginalCommited{get; set;}
        private double _valueQuantidadeVendida;
         [Column("npi_quantidade_vendida")]
        public virtual double QuantidadeVendida
         { 
            get { return this._valueQuantidadeVendida; } 
            set 
            { 
                if (this._valueQuantidadeVendida == value)return;
                 this._valueQuantidadeVendida = value; 
            } 
        } 

       protected bool _compoeTotalOriginal{get;private set;}
       private bool _compoeTotalOriginalCommited{get; set;}
        private bool _valueCompoeTotal;
         [Column("npi_compoe_total")]
        public virtual bool CompoeTotal
         { 
            get { return this._valueCompoeTotal; } 
            set 
            { 
                if (this._valueCompoeTotal == value)return;
                 this._valueCompoeTotal = value; 
            } 
        } 

        public NfProdutoIpiBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.CompoeTotal = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfProdutoIpiClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoIpiClass) GetEntity(typeof(NfProdutoIpiClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_produto_ipi  " +
                    "WHERE " +
                    "  id_nf_produto_ipi = :id";
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
                        "  public.nf_produto_ipi   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  npi_classe_enquadramento_cigarros_bebidas = :npi_classe_enquadramento_cigarros_bebidas, " + 
                        "  npi_cnpj_produtor = :npi_cnpj_produtor, " + 
                        "  npi_classe_enquadramento = :npi_classe_enquadramento, " + 
                        "  npi_cst = :npi_cst, " + 
                        "  npi_aliquota = :npi_aliquota, " + 
                        "  npi_modalidade_tributacao = :npi_modalidade_tributacao, " + 
                        "  npi_quantidade_vendida = :npi_quantidade_vendida, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  npi_compoe_total = :npi_compoe_total "+
                        "WHERE  " +
                        "  id_nf_produto_ipi = :id " +
                        "RETURNING id_nf_produto_ipi;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_ipi " +
                        "( " +
                        "  id_nf_item , " + 
                        "  npi_classe_enquadramento_cigarros_bebidas , " + 
                        "  npi_cnpj_produtor , " + 
                        "  npi_classe_enquadramento , " + 
                        "  npi_cst , " + 
                        "  npi_aliquota , " + 
                        "  npi_modalidade_tributacao , " + 
                        "  npi_quantidade_vendida , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  npi_compoe_total  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npi_classe_enquadramento_cigarros_bebidas , " + 
                        "  :npi_cnpj_produtor , " + 
                        "  :npi_classe_enquadramento , " + 
                        "  :npi_cst , " + 
                        "  :npi_aliquota , " + 
                        "  :npi_modalidade_tributacao , " + 
                        "  :npi_quantidade_vendida , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :npi_compoe_total  "+
                        ")RETURNING id_nf_produto_ipi;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_classe_enquadramento_cigarros_bebidas", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ClasseEnquadramentoCigarrosBebidas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_cnpj_produtor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjProdutor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_classe_enquadramento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ClasseEnquadramento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_modalidade_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeTributacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_quantidade_vendida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeVendida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npi_compoe_total", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompoeTotal ?? DBNull.Value;

 
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
        public static NfProdutoIpiClass CopiarEntidade(NfProdutoIpiClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoIpiClass toRet = new NfProdutoIpiClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.ClasseEnquadramentoCigarrosBebidas= entidadeCopiar.ClasseEnquadramentoCigarrosBebidas;
 toRet.CnpjProdutor= entidadeCopiar.CnpjProdutor;
 toRet.ClasseEnquadramento= entidadeCopiar.ClasseEnquadramento;
 toRet.Cst= entidadeCopiar.Cst;
 toRet.Aliquota= entidadeCopiar.Aliquota;
 toRet.ModalidadeTributacao= entidadeCopiar.ModalidadeTributacao;
 toRet.QuantidadeVendida= entidadeCopiar.QuantidadeVendida;
 toRet.CompoeTotal= entidadeCopiar.CompoeTotal;

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
       _classeEnquadramentoCigarrosBebidasOriginal = ClasseEnquadramentoCigarrosBebidas;
       _classeEnquadramentoCigarrosBebidasOriginalCommited = _classeEnquadramentoCigarrosBebidasOriginal;
       _cnpjProdutorOriginal = CnpjProdutor;
       _cnpjProdutorOriginalCommited = _cnpjProdutorOriginal;
       _classeEnquadramentoOriginal = ClasseEnquadramento;
       _classeEnquadramentoOriginalCommited = _classeEnquadramentoOriginal;
       _cstOriginal = Cst;
       _cstOriginalCommited = _cstOriginal;
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
       _modalidadeTributacaoOriginal = ModalidadeTributacao;
       _modalidadeTributacaoOriginalCommited = _modalidadeTributacaoOriginal;
       _quantidadeVendidaOriginal = QuantidadeVendida;
       _quantidadeVendidaOriginalCommited = _quantidadeVendidaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _compoeTotalOriginal = CompoeTotal;
       _compoeTotalOriginalCommited = _compoeTotalOriginal;

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
       _classeEnquadramentoCigarrosBebidasOriginalCommited = ClasseEnquadramentoCigarrosBebidas;
       _cnpjProdutorOriginalCommited = CnpjProdutor;
       _classeEnquadramentoOriginalCommited = ClasseEnquadramento;
       _cstOriginalCommited = Cst;
       _aliquotaOriginalCommited = Aliquota;
       _modalidadeTributacaoOriginalCommited = ModalidadeTributacao;
       _quantidadeVendidaOriginalCommited = QuantidadeVendida;
       _versionOriginalCommited = Version;
       _compoeTotalOriginalCommited = CompoeTotal;

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
               ClasseEnquadramentoCigarrosBebidas=_classeEnquadramentoCigarrosBebidasOriginal;
               _classeEnquadramentoCigarrosBebidasOriginalCommited=_classeEnquadramentoCigarrosBebidasOriginal;
               CnpjProdutor=_cnpjProdutorOriginal;
               _cnpjProdutorOriginalCommited=_cnpjProdutorOriginal;
               ClasseEnquadramento=_classeEnquadramentoOriginal;
               _classeEnquadramentoOriginalCommited=_classeEnquadramentoOriginal;
               Cst=_cstOriginal;
               _cstOriginalCommited=_cstOriginal;
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
               ModalidadeTributacao=_modalidadeTributacaoOriginal;
               _modalidadeTributacaoOriginalCommited=_modalidadeTributacaoOriginal;
               QuantidadeVendida=_quantidadeVendidaOriginal;
               _quantidadeVendidaOriginalCommited=_quantidadeVendidaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CompoeTotal=_compoeTotalOriginal;
               _compoeTotalOriginalCommited=_compoeTotalOriginal;

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
       dirty = _classeEnquadramentoCigarrosBebidasOriginal != ClasseEnquadramentoCigarrosBebidas;
      if (dirty) return true;
       dirty = _cnpjProdutorOriginal != CnpjProdutor;
      if (dirty) return true;
       dirty = _classeEnquadramentoOriginal != ClasseEnquadramento;
      if (dirty) return true;
       dirty = _cstOriginal != Cst;
      if (dirty) return true;
       dirty = _aliquotaOriginal != Aliquota;
      if (dirty) return true;
       dirty = _modalidadeTributacaoOriginal != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _quantidadeVendidaOriginal != QuantidadeVendida;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _compoeTotalOriginal != CompoeTotal;

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
       dirty = _classeEnquadramentoCigarrosBebidasOriginalCommited != ClasseEnquadramentoCigarrosBebidas;
      if (dirty) return true;
       dirty = _cnpjProdutorOriginalCommited != CnpjProdutor;
      if (dirty) return true;
       dirty = _classeEnquadramentoOriginalCommited != ClasseEnquadramento;
      if (dirty) return true;
       dirty = _cstOriginalCommited != Cst;
      if (dirty) return true;
       dirty = _aliquotaOriginalCommited != Aliquota;
      if (dirty) return true;
       dirty = _modalidadeTributacaoOriginalCommited != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _quantidadeVendidaOriginalCommited != QuantidadeVendida;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _compoeTotalOriginalCommited != CompoeTotal;

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
             case "ClasseEnquadramentoCigarrosBebidas":
                return this.ClasseEnquadramentoCigarrosBebidas;
             case "CnpjProdutor":
                return this.CnpjProdutor;
             case "ClasseEnquadramento":
                return this.ClasseEnquadramento;
             case "Cst":
                return this.Cst;
             case "Aliquota":
                return this.Aliquota;
             case "ModalidadeTributacao":
                return this.ModalidadeTributacao;
             case "QuantidadeVendida":
                return this.QuantidadeVendida;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "CompoeTotal":
                return this.CompoeTotal;
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
                  command.CommandText += " COUNT(nf_produto_ipi.id_nf_produto_ipi) " ;
               }
               else
               {
               command.CommandText += "nf_produto_ipi.id_nf_item, " ;
               command.CommandText += "nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas, " ;
               command.CommandText += "nf_produto_ipi.npi_cnpj_produtor, " ;
               command.CommandText += "nf_produto_ipi.npi_classe_enquadramento, " ;
               command.CommandText += "nf_produto_ipi.npi_cst, " ;
               command.CommandText += "nf_produto_ipi.npi_aliquota, " ;
               command.CommandText += "nf_produto_ipi.npi_modalidade_tributacao, " ;
               command.CommandText += "nf_produto_ipi.npi_quantidade_vendida, " ;
               command.CommandText += "nf_produto_ipi.entity_uid, " ;
               command.CommandText += "nf_produto_ipi.version, " ;
               command.CommandText += "nf_produto_ipi.id_nf_produto_ipi, " ;
               command.CommandText += "nf_produto_ipi.npi_compoe_total " ;
               }
               command.CommandText += " FROM  nf_produto_ipi ";
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
                        orderByClause += " , npi_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npi_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_ipi.id_acs_usuario_ultima_revisao ";
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
                     orderByClause += " , nf_produto_ipi.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npi_classe_enquadramento_cigarros_bebidas":
                     case "ClasseEnquadramentoCigarrosBebidas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_cnpj_produtor":
                     case "CnpjProdutor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ipi.npi_cnpj_produtor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_cnpj_produtor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_classe_enquadramento":
                     case "ClasseEnquadramento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ipi.npi_classe_enquadramento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_classe_enquadramento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_cst":
                     case "Cst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ipi.npi_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ipi.npi_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_modalidade_tributacao":
                     case "ModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ipi.npi_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_quantidade_vendida":
                     case "QuantidadeVendida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ipi.npi_quantidade_vendida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_quantidade_vendida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_ipi.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_ipi.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_ipi.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ipi.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_produto_ipi":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ipi.id_nf_produto_ipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ipi.id_nf_produto_ipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npi_compoe_total":
                     case "CompoeTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_ipi.npi_compoe_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_ipi.npi_compoe_total) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npi_classe_enquadramento_cigarros_bebidas")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npi_cnpj_produtor")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ipi.npi_cnpj_produtor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ipi.npi_cnpj_produtor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npi_classe_enquadramento")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ipi.npi_classe_enquadramento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ipi.npi_classe_enquadramento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npi_cst")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ipi.npi_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ipi.npi_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_ipi.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_ipi.entity_uid) LIKE :buscaCompletaLower ";
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
                         whereClause += "  nf_produto_ipi.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.id_nf_item = :nf_produto_ipi_NfItem_2581 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_NfItem_2581", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClasseEnquadramentoCigarrosBebidas" || parametro.FieldName == "npi_classe_enquadramento_cigarros_bebidas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas LIKE :nf_produto_ipi_ClasseEnquadramentoCigarrosBebidas_1513 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_ClasseEnquadramentoCigarrosBebidas_1513", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjProdutor" || parametro.FieldName == "npi_cnpj_produtor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_cnpj_produtor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_cnpj_produtor LIKE :nf_produto_ipi_CnpjProdutor_8646 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_CnpjProdutor_8646", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClasseEnquadramento" || parametro.FieldName == "npi_classe_enquadramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento LIKE :nf_produto_ipi_ClasseEnquadramento_8082 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_ClasseEnquadramento_8082", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cst" || parametro.FieldName == "npi_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_cst LIKE :nf_produto_ipi_Cst_1152 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_Cst_1152", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "npi_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_aliquota = :nf_produto_ipi_Aliquota_9314 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_Aliquota_9314", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeTributacao" || parametro.FieldName == "npi_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeTributacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeTributacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_modalidade_tributacao = :nf_produto_ipi_ModalidadeTributacao_3833 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_ModalidadeTributacao_3833", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeVendida" || parametro.FieldName == "npi_quantidade_vendida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_quantidade_vendida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_quantidade_vendida = :nf_produto_ipi_QuantidadeVendida_7360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_QuantidadeVendida_7360", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_ipi.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.entity_uid LIKE :nf_produto_ipi_EntityUid_2205 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_EntityUid_2205", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_ipi.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.version = :nf_produto_ipi_Version_7716 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_Version_7716", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_ipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.id_nf_produto_ipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.id_nf_produto_ipi = :nf_produto_ipi_ID_2282 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_ID_2282", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompoeTotal" || parametro.FieldName == "npi_compoe_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_compoe_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_compoe_total = :nf_produto_ipi_CompoeTotal_9073 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_CompoeTotal_9073", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClasseEnquadramentoCigarrosBebidasExato" || parametro.FieldName == "ClasseEnquadramentoCigarrosBebidasExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento_cigarros_bebidas LIKE :nf_produto_ipi_ClasseEnquadramentoCigarrosBebidas_2809 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_ClasseEnquadramentoCigarrosBebidas_2809", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjProdutorExato" || parametro.FieldName == "CnpjProdutorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_cnpj_produtor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_cnpj_produtor LIKE :nf_produto_ipi_CnpjProdutor_3980 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_CnpjProdutor_3980", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClasseEnquadramentoExato" || parametro.FieldName == "ClasseEnquadramentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_classe_enquadramento LIKE :nf_produto_ipi_ClasseEnquadramento_7672 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_ClasseEnquadramento_7672", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_ipi.npi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.npi_cst LIKE :nf_produto_ipi_Cst_4650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_Cst_4650", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_ipi.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_ipi.entity_uid LIKE :nf_produto_ipi_EntityUid_4837 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ipi_EntityUid_4837", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoIpiClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoIpiClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoIpiClass), Convert.ToInt32(read["id_nf_produto_ipi"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoIpiClass(UsuarioAtual, SingleConnection);
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
                     entidade.ClasseEnquadramentoCigarrosBebidas = (read["npi_classe_enquadramento_cigarros_bebidas"] != DBNull.Value ? read["npi_classe_enquadramento_cigarros_bebidas"].ToString() : null);
                     entidade.CnpjProdutor = (read["npi_cnpj_produtor"] != DBNull.Value ? read["npi_cnpj_produtor"].ToString() : null);
                     entidade.ClasseEnquadramento = (read["npi_classe_enquadramento"] != DBNull.Value ? read["npi_classe_enquadramento"].ToString() : null);
                     entidade.Cst = (read["npi_cst"] != DBNull.Value ? read["npi_cst"].ToString() : null);
                     entidade.Aliquota = (double)read["npi_aliquota"];
                     entidade.ModalidadeTributacao = (ModalidadeTributacao) (read["npi_modalidade_tributacao"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeTributacao), read["npi_modalidade_tributacao"]) : null);
                     entidade.QuantidadeVendida = (double)read["npi_quantidade_vendida"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_ipi"]);
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["npi_compoe_total"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoIpiClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

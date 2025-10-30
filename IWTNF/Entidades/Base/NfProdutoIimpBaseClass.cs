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
     [Table("nf_produto_iimp","npm")]
     public class NfProdutoIimpBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoIimpClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoIimpClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoIimpClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoIimpClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoIimpClass está sendo utilizada.";
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

       protected ModalidadeTributacao _modalidadeTributacaoOriginal{get;private set;}
       private ModalidadeTributacao _modalidadeTributacaoOriginalCommited{get; set;}
        private ModalidadeTributacao _valueModalidadeTributacao;
         [Column("npm_modalidade_tributacao")]
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

       protected double _aliquotaOriginal{get;private set;}
       private double _aliquotaOriginalCommited{get; set;}
        private double _valueAliquota;
         [Column("npm_aliquota")]
        public virtual double Aliquota
         { 
            get { return this._valueAliquota; } 
            set 
            { 
                if (this._valueAliquota == value)return;
                 this._valueAliquota = value; 
            } 
        } 

       protected double _valorDespesasAduaneirasOriginal{get;private set;}
       private double _valorDespesasAduaneirasOriginalCommited{get; set;}
        private double _valueValorDespesasAduaneiras;
         [Column("npm_valor_despesas_aduaneiras")]
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
         [Column("npm_valor_iof")]
        public virtual double ValorIof
         { 
            get { return this._valueValorIof; } 
            set 
            { 
                if (this._valueValorIof == value)return;
                 this._valueValorIof = value; 
            } 
        } 

        public NfProdutoIimpBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfProdutoIimpClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoIimpClass) GetEntity(typeof(NfProdutoIimpClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_produto_iimp  " +
                    "WHERE " +
                    "  id_nf_produto_iimp = :id";
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
                        "  public.nf_produto_iimp   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  npm_modalidade_tributacao = :npm_modalidade_tributacao, " + 
                        "  npm_aliquota = :npm_aliquota, " + 
                        "  npm_valor_despesas_aduaneiras = :npm_valor_despesas_aduaneiras, " + 
                        "  npm_valor_iof = :npm_valor_iof, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_nf_produto_iimp = :id " +
                        "RETURNING id_nf_produto_iimp;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_iimp " +
                        "( " +
                        "  id_nf_item , " + 
                        "  npm_modalidade_tributacao , " + 
                        "  npm_aliquota , " + 
                        "  npm_valor_despesas_aduaneiras , " + 
                        "  npm_valor_iof , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npm_modalidade_tributacao , " + 
                        "  :npm_aliquota , " + 
                        "  :npm_valor_despesas_aduaneiras , " + 
                        "  :npm_valor_iof , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_nf_produto_iimp;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npm_modalidade_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeTributacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npm_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npm_valor_despesas_aduaneiras", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorDespesasAduaneiras ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npm_valor_iof", NpgsqlDbType.Double));
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
        public static NfProdutoIimpClass CopiarEntidade(NfProdutoIimpClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoIimpClass toRet = new NfProdutoIimpClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.ModalidadeTributacao= entidadeCopiar.ModalidadeTributacao;
 toRet.Aliquota= entidadeCopiar.Aliquota;
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
       _modalidadeTributacaoOriginal = ModalidadeTributacao;
       _modalidadeTributacaoOriginalCommited = _modalidadeTributacaoOriginal;
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
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
       _modalidadeTributacaoOriginalCommited = ModalidadeTributacao;
       _aliquotaOriginalCommited = Aliquota;
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
               ModalidadeTributacao=_modalidadeTributacaoOriginal;
               _modalidadeTributacaoOriginalCommited=_modalidadeTributacaoOriginal;
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
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
       dirty = _modalidadeTributacaoOriginal != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _aliquotaOriginal != Aliquota;
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
       dirty = _modalidadeTributacaoOriginalCommited != ModalidadeTributacao;
      if (dirty) return true;
       dirty = _aliquotaOriginalCommited != Aliquota;
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
             case "ModalidadeTributacao":
                return this.ModalidadeTributacao;
             case "Aliquota":
                return this.Aliquota;
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
                  command.CommandText += " COUNT(nf_produto_iimp.id_nf_produto_iimp) " ;
               }
               else
               {
               command.CommandText += "nf_produto_iimp.id_nf_item, " ;
               command.CommandText += "nf_produto_iimp.npm_modalidade_tributacao, " ;
               command.CommandText += "nf_produto_iimp.npm_aliquota, " ;
               command.CommandText += "nf_produto_iimp.npm_valor_despesas_aduaneiras, " ;
               command.CommandText += "nf_produto_iimp.npm_valor_iof, " ;
               command.CommandText += "nf_produto_iimp.entity_uid, " ;
               command.CommandText += "nf_produto_iimp.version, " ;
               command.CommandText += "nf_produto_iimp.id_nf_produto_iimp " ;
               }
               command.CommandText += " FROM  nf_produto_iimp ";
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
                        orderByClause += " , npm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_iimp.id_acs_usuario_ultima_revisao ";
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
                     orderByClause += " , nf_produto_iimp.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npm_modalidade_tributacao":
                     case "ModalidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_iimp.npm_modalidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_iimp.npm_modalidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npm_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_iimp.npm_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_iimp.npm_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npm_valor_despesas_aduaneiras":
                     case "ValorDespesasAduaneiras":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_iimp.npm_valor_despesas_aduaneiras " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_iimp.npm_valor_despesas_aduaneiras) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npm_valor_iof":
                     case "ValorIof":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_iimp.npm_valor_iof " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_iimp.npm_valor_iof) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_iimp.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_iimp.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_iimp.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_iimp.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_produto_iimp":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_iimp.id_nf_produto_iimp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_iimp.id_nf_produto_iimp) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(nf_produto_iimp.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_iimp.entity_uid) LIKE :buscaCompletaLower ";
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
                         whereClause += "  nf_produto_iimp.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.id_nf_item = :nf_produto_iimp_NfItem_9548 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_NfItem_9548", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeTributacao" || parametro.FieldName == "npm_modalidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeTributacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeTributacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_iimp.npm_modalidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.npm_modalidade_tributacao = :nf_produto_iimp_ModalidadeTributacao_4739 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_ModalidadeTributacao_4739", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "npm_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_iimp.npm_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.npm_aliquota = :nf_produto_iimp_Aliquota_4912 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_Aliquota_4912", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorDespesasAduaneiras" || parametro.FieldName == "npm_valor_despesas_aduaneiras")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_iimp.npm_valor_despesas_aduaneiras IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.npm_valor_despesas_aduaneiras = :nf_produto_iimp_ValorDespesasAduaneiras_1279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_ValorDespesasAduaneiras_1279", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIof" || parametro.FieldName == "npm_valor_iof")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_iimp.npm_valor_iof IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.npm_valor_iof = :nf_produto_iimp_ValorIof_6794 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_ValorIof_6794", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_iimp.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.entity_uid LIKE :nf_produto_iimp_EntityUid_6942 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_EntityUid_6942", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_iimp.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.version = :nf_produto_iimp_Version_3762 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_Version_3762", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_iimp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_iimp.id_nf_produto_iimp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.id_nf_produto_iimp = :nf_produto_iimp_ID_256 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_ID_256", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_iimp.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_iimp.entity_uid LIKE :nf_produto_iimp_EntityUid_7558 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_iimp_EntityUid_7558", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoIimpClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoIimpClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoIimpClass), Convert.ToInt32(read["id_nf_produto_iimp"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoIimpClass(UsuarioAtual, SingleConnection);
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
                     entidade.ModalidadeTributacao = (ModalidadeTributacao) (read["npm_modalidade_tributacao"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeTributacao), read["npm_modalidade_tributacao"]) : null);
                     entidade.Aliquota = (double)read["npm_aliquota"];
                     entidade.ValorDespesasAduaneiras = (double)read["npm_valor_despesas_aduaneiras"];
                     entidade.ValorIof = (double)read["npm_valor_iof"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_iimp"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoIimpClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

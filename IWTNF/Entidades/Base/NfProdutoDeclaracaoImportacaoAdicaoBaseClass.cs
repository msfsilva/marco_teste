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
     [Table("nf_produto_declaracao_importacao_adicao","npa")]
     public class NfProdutoDeclaracaoImportacaoAdicaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoDeclaracaoImportacaoAdicaoClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoDeclaracaoImportacaoAdicaoClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoDeclaracaoImportacaoAdicaoClass.";
protected const string ErroCodigoFabricanteObrigatorio = "O campo CodigoFabricante é obrigatório";
protected const string ErroCodigoFabricanteComprimento = "O campo CodigoFabricante deve ter no máximo 60 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfProdutoDeclaracaoImportacaoObrigatorio = "O campo NfProdutoDeclaracaoImportacao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoDeclaracaoImportacaoAdicaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoDeclaracaoImportacaoAdicaoClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass _nfProdutoDeclaracaoImportacaoOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass _nfProdutoDeclaracaoImportacaoOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass _valueNfProdutoDeclaracaoImportacao;
        [Column("id_nf_produto_declaracao_importacao", "nf_produto_declaracao_importacao", "id_nf_produto_declaracao_importacao")]
       public virtual IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass NfProdutoDeclaracaoImportacao
        { 
           get {                 return this._valueNfProdutoDeclaracaoImportacao; } 
           set 
           { 
                if (this._valueNfProdutoDeclaracaoImportacao == value)return;
                 this._valueNfProdutoDeclaracaoImportacao = value; 
           } 
       } 

       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("npa_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected int _numeroSequencialItemOriginal{get;private set;}
       private int _numeroSequencialItemOriginalCommited{get; set;}
        private int _valueNumeroSequencialItem;
         [Column("npa_numero_sequencial_item")]
        public virtual int NumeroSequencialItem
         { 
            get { return this._valueNumeroSequencialItem; } 
            set 
            { 
                if (this._valueNumeroSequencialItem == value)return;
                 this._valueNumeroSequencialItem = value; 
            } 
        } 

       protected string _codigoFabricanteOriginal{get;private set;}
       private string _codigoFabricanteOriginalCommited{get; set;}
        private string _valueCodigoFabricante;
         [Column("npa_codigo_fabricante")]
        public virtual string CodigoFabricante
         { 
            get { return this._valueCodigoFabricante; } 
            set 
            { 
                if (this._valueCodigoFabricante == value)return;
                 this._valueCodigoFabricante = value; 
            } 
        } 

       protected double? _valorDescontoItemDiOriginal{get;private set;}
       private double? _valorDescontoItemDiOriginalCommited{get; set;}
        private double? _valueValorDescontoItemDi;
         [Column("npa_valor_desconto_item_di")]
        public virtual double? ValorDescontoItemDi
         { 
            get { return this._valueValorDescontoItemDi; } 
            set 
            { 
                if (this._valueValorDescontoItemDi == value)return;
                 this._valueValorDescontoItemDi = value; 
            } 
        } 

        public NfProdutoDeclaracaoImportacaoAdicaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NfProdutoDeclaracaoImportacaoAdicaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoDeclaracaoImportacaoAdicaoClass) GetEntity(typeof(NfProdutoDeclaracaoImportacaoAdicaoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoFabricante))
                {
                    throw new Exception(ErroCodigoFabricanteObrigatorio);
                }
                if (CodigoFabricante.Length >60)
                {
                    throw new Exception( ErroCodigoFabricanteComprimento);
                }
                if ( _valueNfProdutoDeclaracaoImportacao == null)
                {
                    throw new Exception(ErroNfProdutoDeclaracaoImportacaoObrigatorio);
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
                    "  public.nf_produto_declaracao_importacao_adicao  " +
                    "WHERE " +
                    "  id_nf_produto_declaracao_importacao_adicao = :id";
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
                        "  public.nf_produto_declaracao_importacao_adicao   " +
                        "SET  " + 
                        "  id_nf_produto_declaracao_importacao = :id_nf_produto_declaracao_importacao, " + 
                        "  npa_numero = :npa_numero, " + 
                        "  npa_numero_sequencial_item = :npa_numero_sequencial_item, " + 
                        "  npa_codigo_fabricante = :npa_codigo_fabricante, " + 
                        "  npa_valor_desconto_item_di = :npa_valor_desconto_item_di, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_nf_produto_declaracao_importacao_adicao = :id " +
                        "RETURNING id_nf_produto_declaracao_importacao_adicao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_declaracao_importacao_adicao " +
                        "( " +
                        "  id_nf_produto_declaracao_importacao , " + 
                        "  npa_numero , " + 
                        "  npa_numero_sequencial_item , " + 
                        "  npa_codigo_fabricante , " + 
                        "  npa_valor_desconto_item_di , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_produto_declaracao_importacao , " + 
                        "  :npa_numero , " + 
                        "  :npa_numero_sequencial_item , " + 
                        "  :npa_codigo_fabricante , " + 
                        "  :npa_valor_desconto_item_di , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_nf_produto_declaracao_importacao_adicao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_produto_declaracao_importacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfProdutoDeclaracaoImportacao==null ? (object) DBNull.Value : this.NfProdutoDeclaracaoImportacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npa_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npa_numero_sequencial_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroSequencialItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npa_codigo_fabricante", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoFabricante ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npa_valor_desconto_item_di", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorDescontoItemDi ?? DBNull.Value;
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
        public static NfProdutoDeclaracaoImportacaoAdicaoClass CopiarEntidade(NfProdutoDeclaracaoImportacaoAdicaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoDeclaracaoImportacaoAdicaoClass toRet = new NfProdutoDeclaracaoImportacaoAdicaoClass(usuario,conn);
 toRet.NfProdutoDeclaracaoImportacao= entidadeCopiar.NfProdutoDeclaracaoImportacao;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.NumeroSequencialItem= entidadeCopiar.NumeroSequencialItem;
 toRet.CodigoFabricante= entidadeCopiar.CodigoFabricante;
 toRet.ValorDescontoItemDi= entidadeCopiar.ValorDescontoItemDi;

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
       _nfProdutoDeclaracaoImportacaoOriginal = NfProdutoDeclaracaoImportacao;
       _nfProdutoDeclaracaoImportacaoOriginalCommited = _nfProdutoDeclaracaoImportacaoOriginal;
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _numeroSequencialItemOriginal = NumeroSequencialItem;
       _numeroSequencialItemOriginalCommited = _numeroSequencialItemOriginal;
       _codigoFabricanteOriginal = CodigoFabricante;
       _codigoFabricanteOriginalCommited = _codigoFabricanteOriginal;
       _valorDescontoItemDiOriginal = ValorDescontoItemDi;
       _valorDescontoItemDiOriginalCommited = _valorDescontoItemDiOriginal;
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
       _nfProdutoDeclaracaoImportacaoOriginalCommited = NfProdutoDeclaracaoImportacao;
       _numeroOriginalCommited = Numero;
       _numeroSequencialItemOriginalCommited = NumeroSequencialItem;
       _codigoFabricanteOriginalCommited = CodigoFabricante;
       _valorDescontoItemDiOriginalCommited = ValorDescontoItemDi;
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
               NfProdutoDeclaracaoImportacao=_nfProdutoDeclaracaoImportacaoOriginal;
               _nfProdutoDeclaracaoImportacaoOriginalCommited=_nfProdutoDeclaracaoImportacaoOriginal;
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               NumeroSequencialItem=_numeroSequencialItemOriginal;
               _numeroSequencialItemOriginalCommited=_numeroSequencialItemOriginal;
               CodigoFabricante=_codigoFabricanteOriginal;
               _codigoFabricanteOriginalCommited=_codigoFabricanteOriginal;
               ValorDescontoItemDi=_valorDescontoItemDiOriginal;
               _valorDescontoItemDiOriginalCommited=_valorDescontoItemDiOriginal;
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
       if (_nfProdutoDeclaracaoImportacaoOriginal!=null)
       {
          dirty = !_nfProdutoDeclaracaoImportacaoOriginal.Equals(NfProdutoDeclaracaoImportacao);
       }
       else
       {
            dirty = NfProdutoDeclaracaoImportacao != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _numeroSequencialItemOriginal != NumeroSequencialItem;
      if (dirty) return true;
       dirty = _codigoFabricanteOriginal != CodigoFabricante;
      if (dirty) return true;
       dirty = _valorDescontoItemDiOriginal != ValorDescontoItemDi;
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
       if (_nfProdutoDeclaracaoImportacaoOriginalCommited!=null)
       {
          dirty = !_nfProdutoDeclaracaoImportacaoOriginalCommited.Equals(NfProdutoDeclaracaoImportacao);
       }
       else
       {
            dirty = NfProdutoDeclaracaoImportacao != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _numeroSequencialItemOriginalCommited != NumeroSequencialItem;
      if (dirty) return true;
       dirty = _codigoFabricanteOriginalCommited != CodigoFabricante;
      if (dirty) return true;
       dirty = _valorDescontoItemDiOriginalCommited != ValorDescontoItemDi;
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
             case "NfProdutoDeclaracaoImportacao":
                return this.NfProdutoDeclaracaoImportacao;
             case "Numero":
                return this.Numero;
             case "NumeroSequencialItem":
                return this.NumeroSequencialItem;
             case "CodigoFabricante":
                return this.CodigoFabricante;
             case "ValorDescontoItemDi":
                return this.ValorDescontoItemDi;
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
             if (NfProdutoDeclaracaoImportacao!=null)
                NfProdutoDeclaracaoImportacao.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao_adicao) " ;
               }
               else
               {
               command.CommandText += "nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao_adicao, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.npa_numero, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.npa_numero_sequencial_item, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.npa_valor_desconto_item_di, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.entity_uid, " ;
               command.CommandText += "nf_produto_declaracao_importacao_adicao.version " ;
               }
               command.CommandText += " FROM  nf_produto_declaracao_importacao_adicao ";
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
                        orderByClause += " , npa_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npa_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_declaracao_importacao_adicao.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_produto_declaracao_importacao_adicao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao_adicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao_adicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_produto_declaracao_importacao":
                     case "NfProdutoDeclaracaoImportacao":
                     orderByClause += " , nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npa_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.npa_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.npa_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npa_numero_sequencial_item":
                     case "NumeroSequencialItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.npa_numero_sequencial_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.npa_numero_sequencial_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npa_codigo_fabricante":
                     case "CodigoFabricante":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npa_valor_desconto_item_di":
                     case "ValorDescontoItemDi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.npa_valor_desconto_item_di " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.npa_valor_desconto_item_di) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_declaracao_importacao_adicao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao_adicao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npa_codigo_fabricante")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao_adicao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao_adicao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_declaracao_importacao_adicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao_adicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao_adicao = :nf_produto_declaracao_importacao_adicao_ID_9687 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_ID_9687", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfProdutoDeclaracaoImportacao" || parametro.FieldName == "id_nf_produto_declaracao_importacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.id_nf_produto_declaracao_importacao = :nf_produto_declaracao_importacao_adicao_NfProdutoDeclaracaoImportacao_2255 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_NfProdutoDeclaracaoImportacao_2255", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "npa_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_numero = :nf_produto_declaracao_importacao_adicao_Numero_4641 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_Numero_4641", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroSequencialItem" || parametro.FieldName == "npa_numero_sequencial_item")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_numero_sequencial_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_numero_sequencial_item = :nf_produto_declaracao_importacao_adicao_NumeroSequencialItem_4208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_NumeroSequencialItem_4208", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoFabricante" || parametro.FieldName == "npa_codigo_fabricante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante LIKE :nf_produto_declaracao_importacao_adicao_CodigoFabricante_1058 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_CodigoFabricante_1058", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorDescontoItemDi" || parametro.FieldName == "npa_valor_desconto_item_di")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_valor_desconto_item_di IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_valor_desconto_item_di = :nf_produto_declaracao_importacao_adicao_ValorDescontoItemDi_415 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_ValorDescontoItemDi_415", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_declaracao_importacao_adicao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.entity_uid LIKE :nf_produto_declaracao_importacao_adicao_EntityUid_3929 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_EntityUid_3929", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_declaracao_importacao_adicao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.version = :nf_produto_declaracao_importacao_adicao_Version_6700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_Version_6700", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoFabricanteExato" || parametro.FieldName == "CodigoFabricanteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.npa_codigo_fabricante LIKE :nf_produto_declaracao_importacao_adicao_CodigoFabricante_8774 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_CodigoFabricante_8774", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_declaracao_importacao_adicao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao_adicao.entity_uid LIKE :nf_produto_declaracao_importacao_adicao_EntityUid_5782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_adicao_EntityUid_5782", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoDeclaracaoImportacaoAdicaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoDeclaracaoImportacaoAdicaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoDeclaracaoImportacaoAdicaoClass), Convert.ToInt32(read["id_nf_produto_declaracao_importacao_adicao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoDeclaracaoImportacaoAdicaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_declaracao_importacao_adicao"]);
                     if (read["id_nf_produto_declaracao_importacao"] != DBNull.Value)
                     {
                        entidade.NfProdutoDeclaracaoImportacao = (IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass)IWTNF.Entidades.Entidades.NfProdutoDeclaracaoImportacaoClass.GetEntidade(Convert.ToInt32(read["id_nf_produto_declaracao_importacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfProdutoDeclaracaoImportacao = null ;
                     }
                     entidade.Numero = (int)read["npa_numero"];
                     entidade.NumeroSequencialItem = (int)read["npa_numero_sequencial_item"];
                     entidade.CodigoFabricante = (read["npa_codigo_fabricante"] != DBNull.Value ? read["npa_codigo_fabricante"].ToString() : null);
                     entidade.ValorDescontoItemDi = read["npa_valor_desconto_item_di"] as double?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoDeclaracaoImportacaoAdicaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

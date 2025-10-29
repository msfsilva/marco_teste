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
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("lancamento","lan")]
     public class LancamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LancamentoClass";
protected const string ErroDelete = "Erro ao excluir o LancamentoClass  ";
protected const string ErroSave = "Erro ao salvar o LancamentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do LancamentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LancamentoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ContaReceberClass _contaReceberOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaReceberClass _contaReceberOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaReceberClass _valueContaReceber;
        [Column("id_conta_receber", "conta_receber", "id_conta_receber")]
       public virtual BibliotecaEntidades.Entidades.ContaReceberClass ContaReceber
        { 
           get {                 return this._valueContaReceber; } 
           set 
           { 
                if (this._valueContaReceber == value)return;
                 this._valueContaReceber = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ContaPagarClass _contaPagarOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaPagarClass _contaPagarOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaPagarClass _valueContaPagar;
        [Column("id_conta_pagar", "conta_pagar", "id_conta_pagar")]
       public virtual BibliotecaEntidades.Entidades.ContaPagarClass ContaPagar
        { 
           get {                 return this._valueContaPagar; } 
           set 
           { 
                if (this._valueContaPagar == value)return;
                 this._valueContaPagar = value; 
           } 
       } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("lan_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("lan_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _tipoOriginal{get;private set;}
       private string _tipoOriginalCommited{get; set;}
        private string _valueTipo;
         [Column("lan_tipo")]
        public virtual string Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

       protected string _efetivacaoOriginal{get;private set;}
       private string _efetivacaoOriginalCommited{get; set;}
        private string _valueEfetivacao;
         [Column("lan_efetivacao")]
        public virtual string Efetivacao
         { 
            get { return this._valueEfetivacao; } 
            set 
            { 
                if (this._valueEfetivacao == value)return;
                 this._valueEfetivacao = value; 
            } 
        } 

       protected string _naturezaOriginal{get;private set;}
       private string _naturezaOriginalCommited{get; set;}
        private string _valueNatureza;
         [Column("lan_natureza")]
        public virtual string Natureza
         { 
            get { return this._valueNatureza; } 
            set 
            { 
                if (this._valueNatureza == value)return;
                 this._valueNatureza = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _valueCentroCustoLucro;
        [Column("id_centro_custo_lucro", "centro_custo_lucro", "id_centro_custo_lucro")]
       public virtual BibliotecaEntidades.Entidades.CentroCustoLucroClass CentroCustoLucro
        { 
           get {                 return this._valueCentroCustoLucro; } 
           set 
           { 
                if (this._valueCentroCustoLucro == value)return;
                 this._valueCentroCustoLucro = value; 
           } 
       } 

        public LancamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Valor = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static LancamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LancamentoClass) GetEntity(typeof(LancamentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueCentroCustoLucro == null)
                {
                    throw new Exception(ErroCentroCustoLucroObrigatorio);
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
                    "  public.lancamento  " +
                    "WHERE " +
                    "  id_lancamento = :id";
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
                        "  public.lancamento   " +
                        "SET  " + 
                        "  id_conta_receber = :id_conta_receber, " + 
                        "  id_conta_pagar = :id_conta_pagar, " + 
                        "  lan_valor = :lan_valor, " + 
                        "  lan_data = :lan_data, " + 
                        "  lan_tipo = CAST (:lan_tipo AS lancamento_tipo) , " + 
                        "  lan_efetivacao = CAST (:lan_efetivacao AS lancamento_efetivacao) , " + 
                        "  lan_natureza = CAST (:lan_natureza AS lancemanto_natureza) , " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro "+
                        "WHERE  " +
                        "  id_lancamento = :id " +
                        "RETURNING id_lancamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.lancamento " +
                        "( " +
                        "  id_conta_receber , " + 
                        "  id_conta_pagar , " + 
                        "  lan_valor , " + 
                        "  lan_data , " + 
                        "  lan_tipo , " + 
                        "  lan_efetivacao , " + 
                        "  lan_natureza , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  id_centro_custo_lucro  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_conta_receber , " + 
                        "  :id_conta_pagar , " + 
                        "  :lan_valor , " + 
                        "  :lan_data , " + 
                        " CAST (:lan_tipo AS lancamento_tipo) , " + 
                        " CAST (:lan_efetivacao AS lancamento_efetivacao) , " + 
                        " CAST (:lan_natureza AS lancemanto_natureza) , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :id_centro_custo_lucro  "+
                        ")RETURNING id_lancamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_receber", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaReceber==null ? (object) DBNull.Value : this.ContaReceber.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_pagar", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaPagar==null ? (object) DBNull.Value : this.ContaPagar.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lan_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lan_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lan_tipo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tipo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lan_efetivacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Efetivacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lan_natureza", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Natureza ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;

 
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
        public static LancamentoClass CopiarEntidade(LancamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LancamentoClass toRet = new LancamentoClass(usuario,conn);
 toRet.ContaReceber= entidadeCopiar.ContaReceber;
 toRet.ContaPagar= entidadeCopiar.ContaPagar;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.Data= entidadeCopiar.Data;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.Efetivacao= entidadeCopiar.Efetivacao;
 toRet.Natureza= entidadeCopiar.Natureza;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;

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
       _contaReceberOriginal = ContaReceber;
       _contaReceberOriginalCommited = _contaReceberOriginal;
       _contaPagarOriginal = ContaPagar;
       _contaPagarOriginalCommited = _contaPagarOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _efetivacaoOriginal = Efetivacao;
       _efetivacaoOriginalCommited = _efetivacaoOriginal;
       _naturezaOriginal = Natureza;
       _naturezaOriginalCommited = _naturezaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;

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
       _contaReceberOriginalCommited = ContaReceber;
       _contaPagarOriginalCommited = ContaPagar;
       _valorOriginalCommited = Valor;
       _dataOriginalCommited = Data;
       _tipoOriginalCommited = Tipo;
       _efetivacaoOriginalCommited = Efetivacao;
       _naturezaOriginalCommited = Natureza;
       _versionOriginalCommited = Version;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;

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
               ContaReceber=_contaReceberOriginal;
               _contaReceberOriginalCommited=_contaReceberOriginal;
               ContaPagar=_contaPagarOriginal;
               _contaPagarOriginalCommited=_contaPagarOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               Efetivacao=_efetivacaoOriginal;
               _efetivacaoOriginalCommited=_efetivacaoOriginal;
               Natureza=_naturezaOriginal;
               _naturezaOriginalCommited=_naturezaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;

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
       if (_contaReceberOriginal!=null)
       {
          dirty = !_contaReceberOriginal.Equals(ContaReceber);
       }
       else
       {
            dirty = ContaReceber != null;
       }
      if (dirty) return true;
       if (_contaPagarOriginal!=null)
       {
          dirty = !_contaPagarOriginal.Equals(ContaPagar);
       }
       else
       {
            dirty = ContaPagar != null;
       }
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _efetivacaoOriginal != Efetivacao;
      if (dirty) return true;
       dirty = _naturezaOriginal != Natureza;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       if (_centroCustoLucroOriginal!=null)
       {
          dirty = !_centroCustoLucroOriginal.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }

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
       if (_contaReceberOriginalCommited!=null)
       {
          dirty = !_contaReceberOriginalCommited.Equals(ContaReceber);
       }
       else
       {
            dirty = ContaReceber != null;
       }
      if (dirty) return true;
       if (_contaPagarOriginalCommited!=null)
       {
          dirty = !_contaPagarOriginalCommited.Equals(ContaPagar);
       }
       else
       {
            dirty = ContaPagar != null;
       }
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _efetivacaoOriginalCommited != Efetivacao;
      if (dirty) return true;
       dirty = _naturezaOriginalCommited != Natureza;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       if (_centroCustoLucroOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroOriginalCommited.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }

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
             case "ContaReceber":
                return this.ContaReceber;
             case "ContaPagar":
                return this.ContaPagar;
             case "Valor":
                return this.Valor;
             case "Data":
                return this.Data;
             case "Tipo":
                return this.Tipo;
             case "Efetivacao":
                return this.Efetivacao;
             case "Natureza":
                return this.Natureza;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (ContaReceber!=null)
                ContaReceber.ChangeSingleConnection(newConnection);
             if (ContaPagar!=null)
                ContaPagar.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(lancamento.id_lancamento) " ;
               }
               else
               {
               command.CommandText += "lancamento.id_lancamento, " ;
               command.CommandText += "lancamento.id_conta_receber, " ;
               command.CommandText += "lancamento.id_conta_pagar, " ;
               command.CommandText += "lancamento.lan_valor, " ;
               command.CommandText += "lancamento.lan_data, " ;
               command.CommandText += "lancamento.lan_tipo, " ;
               command.CommandText += "lancamento.lan_efetivacao, " ;
               command.CommandText += "lancamento.lan_natureza, " ;
               command.CommandText += "lancamento.version, " ;
               command.CommandText += "lancamento.entity_uid, " ;
               command.CommandText += "lancamento.id_centro_custo_lucro " ;
               }
               command.CommandText += " FROM  lancamento ";
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
                        orderByClause += " , lan_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(lan_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = lancamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_lancamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lancamento.id_lancamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.id_lancamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_receber":
                     case "ContaReceber":
                     command.CommandText += " LEFT JOIN conta_receber as conta_receber_ContaReceber ON conta_receber_ContaReceber.id_conta_receber = lancamento.id_conta_receber ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_receber_ContaReceber.cor_historico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_receber_ContaReceber.cor_historico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_pagar":
                     case "ContaPagar":
                     command.CommandText += " LEFT JOIN conta_pagar as conta_pagar_ContaPagar ON conta_pagar_ContaPagar.id_conta_pagar = lancamento.id_conta_pagar ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_pagar_ContaPagar.cop_historico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_pagar_ContaPagar.cop_historico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lan_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lancamento.lan_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.lan_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lan_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lancamento.lan_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.lan_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lan_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lancamento.lan_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.lan_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lan_efetivacao":
                     case "Efetivacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lancamento.lan_efetivacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.lan_efetivacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lan_natureza":
                     case "Natureza":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lancamento.lan_natureza " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.lan_natureza) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , lancamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lancamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lancamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lancamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = lancamento.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(lancamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lancamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_lancamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.id_lancamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.id_lancamento = :lancamento_ID_8318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_ID_8318", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaReceber" || parametro.FieldName == "id_conta_receber")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaReceberClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaReceberClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.id_conta_receber IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.id_conta_receber = :lancamento_ContaReceber_2775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_ContaReceber_2775", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaPagar" || parametro.FieldName == "id_conta_pagar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaPagarClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaPagarClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.id_conta_pagar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.id_conta_pagar = :lancamento_ContaPagar_4164 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_ContaPagar_4164", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "lan_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.lan_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.lan_valor = :lancamento_Valor_3779 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_Valor_3779", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "lan_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.lan_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.lan_data = :lancamento_Data_6080 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_Data_6080", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "lan_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.lan_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.lan_tipo = :lancamento_Tipo_5855 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_Tipo_5855", NpgsqlDbType.Enum,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Efetivacao" || parametro.FieldName == "lan_efetivacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.lan_efetivacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.lan_efetivacao = :lancamento_Efetivacao_6469 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_Efetivacao_6469", NpgsqlDbType.Enum,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Natureza" || parametro.FieldName == "lan_natureza")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.lan_natureza IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.lan_natureza = :lancamento_Natureza_1003 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_Natureza_1003", NpgsqlDbType.Enum,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  lancamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.version = :lancamento_Version_6629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_Version_6629", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  lancamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.entity_uid LIKE :lancamento_EntityUid_5141 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_EntityUid_5141", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CentroCustoLucro" || parametro.FieldName == "id_centro_custo_lucro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CentroCustoLucroClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CentroCustoLucroClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lancamento.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.id_centro_custo_lucro = :lancamento_CentroCustoLucro_1481 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_CentroCustoLucro_1481", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  lancamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lancamento.entity_uid LIKE :lancamento_EntityUid_9158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lancamento_EntityUid_9158", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LancamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LancamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LancamentoClass), Convert.ToInt32(read["id_lancamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LancamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_lancamento"]);
                     if (read["id_conta_receber"] != DBNull.Value)
                     {
                        entidade.ContaReceber = (BibliotecaEntidades.Entidades.ContaReceberClass)BibliotecaEntidades.Entidades.ContaReceberClass.GetEntidade(Convert.ToInt32(read["id_conta_receber"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaReceber = null ;
                     }
                     if (read["id_conta_pagar"] != DBNull.Value)
                     {
                        entidade.ContaPagar = (BibliotecaEntidades.Entidades.ContaPagarClass)BibliotecaEntidades.Entidades.ContaPagarClass.GetEntidade(Convert.ToInt32(read["id_conta_pagar"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaPagar = null ;
                     }
                     entidade.Valor = (double)read["lan_valor"];
                     entidade.Data = (DateTime)read["lan_data"];
                     entidade.Tipo = (read["lan_tipo"] != DBNull.Value ? read["lan_tipo"].ToString() : null);
                     entidade.Efetivacao = (read["lan_efetivacao"] != DBNull.Value ? read["lan_efetivacao"].ToString() : null);
                     entidade.Natureza = (read["lan_natureza"] != DBNull.Value ? read["lan_natureza"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     if (read["id_centro_custo_lucro"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucro = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucro = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LancamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

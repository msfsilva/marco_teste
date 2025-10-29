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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("ordem_producao_envio_terceiros_recebimento","otr")]
     public class OrdemProducaoEnvioTerceirosRecebimentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoEnvioTerceirosRecebimentoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoEnvioTerceirosRecebimentoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoEnvioTerceirosRecebimentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoEnvioTerceirosObrigatorio = "O campo OrdemProducaoEnvioTerceiros é obrigatório";
protected const string ErroNotaFiscalEntradaLinhaObrigatorio = "O campo NotaFiscalEntradaLinha é obrigatório";
protected const string ErroAcsUsuarioRecebimentoObrigatorio = "O campo AcsUsuarioRecebimento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoEnvioTerceirosRecebimentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoEnvioTerceirosRecebimentoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass _ordemProducaoEnvioTerceirosOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass _ordemProducaoEnvioTerceirosOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass _valueOrdemProducaoEnvioTerceiros;
        [Column("id_ordem_producao_envio_terceiros", "ordem_producao_envio_terceiros", "id_ordem_producao_envio_terceiros")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass OrdemProducaoEnvioTerceiros
        { 
           get {                 return this._valueOrdemProducaoEnvioTerceiros; } 
           set 
           { 
                if (this._valueOrdemProducaoEnvioTerceiros == value)return;
                 this._valueOrdemProducaoEnvioTerceiros = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass _notaFiscalEntradaLinhaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass _notaFiscalEntradaLinhaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass _valueNotaFiscalEntradaLinha;
        [Column("id_nota_fiscal_entrada_linha", "nota_fiscal_entrada_linha", "id_nota_fiscal_entrada_linha")]
       public virtual BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass NotaFiscalEntradaLinha
        { 
           get {                 return this._valueNotaFiscalEntradaLinha; } 
           set 
           { 
                if (this._valueNotaFiscalEntradaLinha == value)return;
                 this._valueNotaFiscalEntradaLinha = value; 
           } 
       } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("otr_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected DateTime _dataRecebimentoOriginal{get;private set;}
       private DateTime _dataRecebimentoOriginalCommited{get; set;}
        private DateTime _valueDataRecebimento;
         [Column("otr_data_recebimento")]
        public virtual DateTime DataRecebimento
         { 
            get { return this._valueDataRecebimento; } 
            set 
            { 
                if (this._valueDataRecebimento == value)return;
                 this._valueDataRecebimento = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioRecebimentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioRecebimentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioRecebimento;
        [Column("id_acs_usuario_recebimento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioRecebimento
        { 
           get {                 return this._valueAcsUsuarioRecebimento; } 
           set 
           { 
                if (this._valueAcsUsuarioRecebimento == value)return;
                 this._valueAcsUsuarioRecebimento = value; 
           } 
       } 

        public OrdemProducaoEnvioTerceirosRecebimentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoEnvioTerceirosRecebimentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoEnvioTerceirosRecebimentoClass) GetEntity(typeof(OrdemProducaoEnvioTerceirosRecebimentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrdemProducaoEnvioTerceiros == null)
                {
                    throw new Exception(ErroOrdemProducaoEnvioTerceirosObrigatorio);
                }
                if ( _valueNotaFiscalEntradaLinha == null)
                {
                    throw new Exception(ErroNotaFiscalEntradaLinhaObrigatorio);
                }
                if ( _valueAcsUsuarioRecebimento == null)
                {
                    throw new Exception(ErroAcsUsuarioRecebimentoObrigatorio);
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
                    "  public.ordem_producao_envio_terceiros_recebimento  " +
                    "WHERE " +
                    "  id_ordem_producao_envio_terceiros_recebimento = :id";
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
                        "  public.ordem_producao_envio_terceiros_recebimento   " +
                        "SET  " + 
                        "  id_ordem_producao_envio_terceiros = :id_ordem_producao_envio_terceiros, " + 
                        "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha, " + 
                        "  otr_quantidade = :otr_quantidade, " + 
                        "  otr_data_recebimento = :otr_data_recebimento, " + 
                        "  id_acs_usuario_recebimento = :id_acs_usuario_recebimento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_envio_terceiros_recebimento = :id " +
                        "RETURNING id_ordem_producao_envio_terceiros_recebimento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_envio_terceiros_recebimento " +
                        "( " +
                        "  id_ordem_producao_envio_terceiros , " + 
                        "  id_nota_fiscal_entrada_linha , " + 
                        "  otr_quantidade , " + 
                        "  otr_data_recebimento , " + 
                        "  id_acs_usuario_recebimento , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao_envio_terceiros , " + 
                        "  :id_nota_fiscal_entrada_linha , " + 
                        "  :otr_quantidade , " + 
                        "  :otr_data_recebimento , " + 
                        "  :id_acs_usuario_recebimento , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_envio_terceiros_recebimento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_envio_terceiros", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoEnvioTerceiros==null ? (object) DBNull.Value : this.OrdemProducaoEnvioTerceiros.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NotaFiscalEntradaLinha==null ? (object) DBNull.Value : this.NotaFiscalEntradaLinha.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("otr_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("otr_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_recebimento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioRecebimento==null ? (object) DBNull.Value : this.AcsUsuarioRecebimento.ID;
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
        public static OrdemProducaoEnvioTerceirosRecebimentoClass CopiarEntidade(OrdemProducaoEnvioTerceirosRecebimentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoEnvioTerceirosRecebimentoClass toRet = new OrdemProducaoEnvioTerceirosRecebimentoClass(usuario,conn);
 toRet.OrdemProducaoEnvioTerceiros= entidadeCopiar.OrdemProducaoEnvioTerceiros;
 toRet.NotaFiscalEntradaLinha= entidadeCopiar.NotaFiscalEntradaLinha;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.DataRecebimento= entidadeCopiar.DataRecebimento;
 toRet.AcsUsuarioRecebimento= entidadeCopiar.AcsUsuarioRecebimento;

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
       _ordemProducaoEnvioTerceirosOriginal = OrdemProducaoEnvioTerceiros;
       _ordemProducaoEnvioTerceirosOriginalCommited = _ordemProducaoEnvioTerceirosOriginal;
       _notaFiscalEntradaLinhaOriginal = NotaFiscalEntradaLinha;
       _notaFiscalEntradaLinhaOriginalCommited = _notaFiscalEntradaLinhaOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _dataRecebimentoOriginal = DataRecebimento;
       _dataRecebimentoOriginalCommited = _dataRecebimentoOriginal;
       _acsUsuarioRecebimentoOriginal = AcsUsuarioRecebimento;
       _acsUsuarioRecebimentoOriginalCommited = _acsUsuarioRecebimentoOriginal;
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
       _ordemProducaoEnvioTerceirosOriginalCommited = OrdemProducaoEnvioTerceiros;
       _notaFiscalEntradaLinhaOriginalCommited = NotaFiscalEntradaLinha;
       _quantidadeOriginalCommited = Quantidade;
       _dataRecebimentoOriginalCommited = DataRecebimento;
       _acsUsuarioRecebimentoOriginalCommited = AcsUsuarioRecebimento;
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
               OrdemProducaoEnvioTerceiros=_ordemProducaoEnvioTerceirosOriginal;
               _ordemProducaoEnvioTerceirosOriginalCommited=_ordemProducaoEnvioTerceirosOriginal;
               NotaFiscalEntradaLinha=_notaFiscalEntradaLinhaOriginal;
               _notaFiscalEntradaLinhaOriginalCommited=_notaFiscalEntradaLinhaOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               DataRecebimento=_dataRecebimentoOriginal;
               _dataRecebimentoOriginalCommited=_dataRecebimentoOriginal;
               AcsUsuarioRecebimento=_acsUsuarioRecebimentoOriginal;
               _acsUsuarioRecebimentoOriginalCommited=_acsUsuarioRecebimentoOriginal;
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
       if (_ordemProducaoEnvioTerceirosOriginal!=null)
       {
          dirty = !_ordemProducaoEnvioTerceirosOriginal.Equals(OrdemProducaoEnvioTerceiros);
       }
       else
       {
            dirty = OrdemProducaoEnvioTerceiros != null;
       }
      if (dirty) return true;
       if (_notaFiscalEntradaLinhaOriginal!=null)
       {
          dirty = !_notaFiscalEntradaLinhaOriginal.Equals(NotaFiscalEntradaLinha);
       }
       else
       {
            dirty = NotaFiscalEntradaLinha != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginal != DataRecebimento;
      if (dirty) return true;
       if (_acsUsuarioRecebimentoOriginal!=null)
       {
          dirty = !_acsUsuarioRecebimentoOriginal.Equals(AcsUsuarioRecebimento);
       }
       else
       {
            dirty = AcsUsuarioRecebimento != null;
       }
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
       if (_ordemProducaoEnvioTerceirosOriginalCommited!=null)
       {
          dirty = !_ordemProducaoEnvioTerceirosOriginalCommited.Equals(OrdemProducaoEnvioTerceiros);
       }
       else
       {
            dirty = OrdemProducaoEnvioTerceiros != null;
       }
      if (dirty) return true;
       if (_notaFiscalEntradaLinhaOriginalCommited!=null)
       {
          dirty = !_notaFiscalEntradaLinhaOriginalCommited.Equals(NotaFiscalEntradaLinha);
       }
       else
       {
            dirty = NotaFiscalEntradaLinha != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginalCommited != DataRecebimento;
      if (dirty) return true;
       if (_acsUsuarioRecebimentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioRecebimentoOriginalCommited.Equals(AcsUsuarioRecebimento);
       }
       else
       {
            dirty = AcsUsuarioRecebimento != null;
       }
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
             case "OrdemProducaoEnvioTerceiros":
                return this.OrdemProducaoEnvioTerceiros;
             case "NotaFiscalEntradaLinha":
                return this.NotaFiscalEntradaLinha;
             case "Quantidade":
                return this.Quantidade;
             case "DataRecebimento":
                return this.DataRecebimento;
             case "AcsUsuarioRecebimento":
                return this.AcsUsuarioRecebimento;
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
             if (OrdemProducaoEnvioTerceiros!=null)
                OrdemProducaoEnvioTerceiros.ChangeSingleConnection(newConnection);
             if (NotaFiscalEntradaLinha!=null)
                NotaFiscalEntradaLinha.ChangeSingleConnection(newConnection);
             if (AcsUsuarioRecebimento!=null)
                AcsUsuarioRecebimento.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros_recebimento) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros_recebimento, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.id_nota_fiscal_entrada_linha, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.otr_quantidade, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.otr_data_recebimento, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.id_acs_usuario_recebimento, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.entity_uid, " ;
               command.CommandText += "ordem_producao_envio_terceiros_recebimento.version " ;
               }
               command.CommandText += " FROM  ordem_producao_envio_terceiros_recebimento ";
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
                        orderByClause += " , otr_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(otr_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_envio_terceiros_recebimento.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_envio_terceiros_recebimento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_envio_terceiros":
                     case "OrdemProducaoEnvioTerceiros":
                     orderByClause += " , ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_nota_fiscal_entrada_linha":
                     case "NotaFiscalEntradaLinha":
                     command.CommandText += " LEFT JOIN nota_fiscal_entrada_linha as nota_fiscal_entrada_linha_NotaFiscalEntradaLinha ON nota_fiscal_entrada_linha_NotaFiscalEntradaLinha.id_nota_fiscal_entrada_linha = ordem_producao_envio_terceiros_recebimento.id_nota_fiscal_entrada_linha ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha_NotaFiscalEntradaLinha.id_nota_fiscal_entrada_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha_NotaFiscalEntradaLinha.id_nota_fiscal_entrada_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "otr_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros_recebimento.otr_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_recebimento.otr_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "otr_data_recebimento":
                     case "DataRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros_recebimento.otr_data_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_recebimento.otr_data_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_recebimento":
                     case "AcsUsuarioRecebimento":
                     orderByClause += " , ordem_producao_envio_terceiros_recebimento.id_acs_usuario_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_envio_terceiros_recebimento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_recebimento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_envio_terceiros_recebimento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_recebimento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(ordem_producao_envio_terceiros_recebimento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_envio_terceiros_recebimento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_envio_terceiros_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros_recebimento = :ordem_producao_envio_terceiros_recebimento_ID_64 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_ID_64", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoEnvioTerceiros" || parametro.FieldName == "id_ordem_producao_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_ordem_producao_envio_terceiros = :ordem_producao_envio_terceiros_recebimento_OrdemProducaoEnvioTerceiros_5827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_OrdemProducaoEnvioTerceiros_5827", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscalEntradaLinha" || parametro.FieldName == "id_nota_fiscal_entrada_linha")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_nota_fiscal_entrada_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_nota_fiscal_entrada_linha = :ordem_producao_envio_terceiros_recebimento_NotaFiscalEntradaLinha_9254 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_NotaFiscalEntradaLinha_9254", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "otr_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.otr_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.otr_quantidade = :ordem_producao_envio_terceiros_recebimento_Quantidade_4693 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_Quantidade_4693", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRecebimento" || parametro.FieldName == "otr_data_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.otr_data_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.otr_data_recebimento = :ordem_producao_envio_terceiros_recebimento_DataRecebimento_3097 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_DataRecebimento_3097", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioRecebimento" || parametro.FieldName == "id_acs_usuario_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_acs_usuario_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.id_acs_usuario_recebimento = :ordem_producao_envio_terceiros_recebimento_AcsUsuarioRecebimento_6473 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_AcsUsuarioRecebimento_6473", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.entity_uid LIKE :ordem_producao_envio_terceiros_recebimento_EntityUid_6520 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_EntityUid_6520", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.version = :ordem_producao_envio_terceiros_recebimento_Version_9159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_Version_9159", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_recebimento.entity_uid LIKE :ordem_producao_envio_terceiros_recebimento_EntityUid_296 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_recebimento_EntityUid_296", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoEnvioTerceirosRecebimentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoEnvioTerceirosRecebimentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoEnvioTerceirosRecebimentoClass), Convert.ToInt32(read["id_ordem_producao_envio_terceiros_recebimento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoEnvioTerceirosRecebimentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_envio_terceiros_recebimento"]);
                     if (read["id_ordem_producao_envio_terceiros"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoEnvioTerceiros = (BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass)BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_envio_terceiros"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoEnvioTerceiros = null ;
                     }
                     if (read["id_nota_fiscal_entrada_linha"] != DBNull.Value)
                     {
                        entidade.NotaFiscalEntradaLinha = (BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass)BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass.GetEntidade(Convert.ToInt32(read["id_nota_fiscal_entrada_linha"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NotaFiscalEntradaLinha = null ;
                     }
                     entidade.Quantidade = (double)read["otr_quantidade"];
                     entidade.DataRecebimento = (DateTime)read["otr_data_recebimento"];
                     if (read["id_acs_usuario_recebimento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioRecebimento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_recebimento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioRecebimento = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoEnvioTerceirosRecebimentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

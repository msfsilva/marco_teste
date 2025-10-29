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
     [Table("order_item_etiqueta_conferencia_volumes","ocv")]
     public class OrderItemEtiquetaConferenciaVolumesBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaConferenciaVolumesClass";
protected const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaConferenciaVolumesClass  ";
protected const string ErroSave = "Erro ao salvar o OrderItemEtiquetaConferenciaVolumesClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCubagemObrigatorio = "O campo Cubagem é obrigatório";
protected const string ErroCubagemComprimento = "O campo Cubagem deve ter no máximo 255 caracteres";
protected const string ErroOrderItemEtiquetaConferenciaObrigatorio = "O campo OrderItemEtiquetaConferencia é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaConferenciaVolumesClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemEtiquetaConferenciaVolumesClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _orderItemEtiquetaConferenciaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _orderItemEtiquetaConferenciaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _valueOrderItemEtiquetaConferencia;
        [Column("id_order_item_etiqueta_conferencia", "order_item_etiqueta_conferencia", "id_order_item_etiqueta_conferencia")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass OrderItemEtiquetaConferencia
        { 
           get {                 return this._valueOrderItemEtiquetaConferencia; } 
           set 
           { 
                if (this._valueOrderItemEtiquetaConferencia == value)return;
                 this._valueOrderItemEtiquetaConferencia = value; 
           } 
       } 

       protected int _numeroVolumeOriginal{get;private set;}
       private int _numeroVolumeOriginalCommited{get; set;}
        private int _valueNumeroVolume;
         [Column("ocv_numero_volume")]
        public virtual int NumeroVolume
         { 
            get { return this._valueNumeroVolume; } 
            set 
            { 
                if (this._valueNumeroVolume == value)return;
                 this._valueNumeroVolume = value; 
            } 
        } 

       protected int _totalVolumesOriginal{get;private set;}
       private int _totalVolumesOriginalCommited{get; set;}
        private int _valueTotalVolumes;
         [Column("ocv_total_volumes")]
        public virtual int TotalVolumes
         { 
            get { return this._valueTotalVolumes; } 
            set 
            { 
                if (this._valueTotalVolumes == value)return;
                 this._valueTotalVolumes = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("ocv_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _pesoOriginal{get;private set;}
       private double _pesoOriginalCommited{get; set;}
        private double _valuePeso;
         [Column("ocv_peso")]
        public virtual double Peso
         { 
            get { return this._valuePeso; } 
            set 
            { 
                if (this._valuePeso == value)return;
                 this._valuePeso = value; 
            } 
        } 

       protected string _cubagemOriginal{get;private set;}
       private string _cubagemOriginalCommited{get; set;}
        private string _valueCubagem;
         [Column("ocv_cubagem")]
        public virtual string Cubagem
         { 
            get { return this._valueCubagem; } 
            set 
            { 
                if (this._valueCubagem == value)return;
                 this._valueCubagem = value; 
            } 
        } 

        public OrderItemEtiquetaConferenciaVolumesBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Peso = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrderItemEtiquetaConferenciaVolumesClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrderItemEtiquetaConferenciaVolumesClass) GetEntity(typeof(OrderItemEtiquetaConferenciaVolumesClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Cubagem))
                {
                    throw new Exception(ErroCubagemObrigatorio);
                }
                if (Cubagem.Length >255)
                {
                    throw new Exception( ErroCubagemComprimento);
                }
                if ( _valueOrderItemEtiquetaConferencia == null)
                {
                    throw new Exception(ErroOrderItemEtiquetaConferenciaObrigatorio);
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
                    "  public.order_item_etiqueta_conferencia_volumes  " +
                    "WHERE " +
                    "  id_order_item_etiqueta_conferencia_volumes = :id";
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
                        "  public.order_item_etiqueta_conferencia_volumes   " +
                        "SET  " + 
                        "  id_order_item_etiqueta_conferencia = :id_order_item_etiqueta_conferencia, " + 
                        "  ocv_numero_volume = :ocv_numero_volume, " + 
                        "  ocv_total_volumes = :ocv_total_volumes, " + 
                        "  ocv_quantidade = :ocv_quantidade, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ocv_peso = :ocv_peso, " + 
                        "  ocv_cubagem = :ocv_cubagem "+
                        "WHERE  " +
                        "  id_order_item_etiqueta_conferencia_volumes = :id " +
                        "RETURNING id_order_item_etiqueta_conferencia_volumes;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.order_item_etiqueta_conferencia_volumes " +
                        "( " +
                        "  id_order_item_etiqueta_conferencia , " + 
                        "  ocv_numero_volume , " + 
                        "  ocv_total_volumes , " + 
                        "  ocv_quantidade , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ocv_peso , " + 
                        "  ocv_cubagem  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_order_item_etiqueta_conferencia , " + 
                        "  :ocv_numero_volume , " + 
                        "  :ocv_total_volumes , " + 
                        "  :ocv_quantidade , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ocv_peso , " + 
                        "  :ocv_cubagem  "+
                        ")RETURNING id_order_item_etiqueta_conferencia_volumes;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiquetaConferencia==null ? (object) DBNull.Value : this.OrderItemEtiquetaConferencia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ocv_numero_volume", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroVolume ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ocv_total_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TotalVolumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ocv_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ocv_peso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Peso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ocv_cubagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cubagem ?? DBNull.Value;

 
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
        public static OrderItemEtiquetaConferenciaVolumesClass CopiarEntidade(OrderItemEtiquetaConferenciaVolumesClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrderItemEtiquetaConferenciaVolumesClass toRet = new OrderItemEtiquetaConferenciaVolumesClass(usuario,conn);
 toRet.OrderItemEtiquetaConferencia= entidadeCopiar.OrderItemEtiquetaConferencia;
 toRet.NumeroVolume= entidadeCopiar.NumeroVolume;
 toRet.TotalVolumes= entidadeCopiar.TotalVolumes;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Peso= entidadeCopiar.Peso;
 toRet.Cubagem= entidadeCopiar.Cubagem;

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
       _orderItemEtiquetaConferenciaOriginal = OrderItemEtiquetaConferencia;
       _orderItemEtiquetaConferenciaOriginalCommited = _orderItemEtiquetaConferenciaOriginal;
       _numeroVolumeOriginal = NumeroVolume;
       _numeroVolumeOriginalCommited = _numeroVolumeOriginal;
       _totalVolumesOriginal = TotalVolumes;
       _totalVolumesOriginalCommited = _totalVolumesOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _pesoOriginal = Peso;
       _pesoOriginalCommited = _pesoOriginal;
       _cubagemOriginal = Cubagem;
       _cubagemOriginalCommited = _cubagemOriginal;

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
       _orderItemEtiquetaConferenciaOriginalCommited = OrderItemEtiquetaConferencia;
       _numeroVolumeOriginalCommited = NumeroVolume;
       _totalVolumesOriginalCommited = TotalVolumes;
       _quantidadeOriginalCommited = Quantidade;
       _versionOriginalCommited = Version;
       _pesoOriginalCommited = Peso;
       _cubagemOriginalCommited = Cubagem;

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
               OrderItemEtiquetaConferencia=_orderItemEtiquetaConferenciaOriginal;
               _orderItemEtiquetaConferenciaOriginalCommited=_orderItemEtiquetaConferenciaOriginal;
               NumeroVolume=_numeroVolumeOriginal;
               _numeroVolumeOriginalCommited=_numeroVolumeOriginal;
               TotalVolumes=_totalVolumesOriginal;
               _totalVolumesOriginalCommited=_totalVolumesOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Peso=_pesoOriginal;
               _pesoOriginalCommited=_pesoOriginal;
               Cubagem=_cubagemOriginal;
               _cubagemOriginalCommited=_cubagemOriginal;

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
       if (_orderItemEtiquetaConferenciaOriginal!=null)
       {
          dirty = !_orderItemEtiquetaConferenciaOriginal.Equals(OrderItemEtiquetaConferencia);
       }
       else
       {
            dirty = OrderItemEtiquetaConferencia != null;
       }
      if (dirty) return true;
       dirty = _numeroVolumeOriginal != NumeroVolume;
      if (dirty) return true;
       dirty = _totalVolumesOriginal != TotalVolumes;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _pesoOriginal != Peso;
      if (dirty) return true;
       dirty = _cubagemOriginal != Cubagem;

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
       if (_orderItemEtiquetaConferenciaOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaConferenciaOriginalCommited.Equals(OrderItemEtiquetaConferencia);
       }
       else
       {
            dirty = OrderItemEtiquetaConferencia != null;
       }
      if (dirty) return true;
       dirty = _numeroVolumeOriginalCommited != NumeroVolume;
      if (dirty) return true;
       dirty = _totalVolumesOriginalCommited != TotalVolumes;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _pesoOriginalCommited != Peso;
      if (dirty) return true;
       dirty = _cubagemOriginalCommited != Cubagem;

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
             case "OrderItemEtiquetaConferencia":
                return this.OrderItemEtiquetaConferencia;
             case "NumeroVolume":
                return this.NumeroVolume;
             case "TotalVolumes":
                return this.TotalVolumes;
             case "Quantidade":
                return this.Quantidade;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Peso":
                return this.Peso;
             case "Cubagem":
                return this.Cubagem;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (OrderItemEtiquetaConferencia!=null)
                OrderItemEtiquetaConferencia.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes) " ;
               }
               else
               {
               command.CommandText += "order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.ocv_numero_volume, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.ocv_total_volumes, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.ocv_quantidade, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.entity_uid, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.version, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.ocv_peso, " ;
               command.CommandText += "order_item_etiqueta_conferencia_volumes.ocv_cubagem " ;
               }
               command.CommandText += " FROM  order_item_etiqueta_conferencia_volumes ";
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
                        orderByClause += " , ocv_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ocv_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = order_item_etiqueta_conferencia_volumes.id_acs_usuario_ultima_revisao ";
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
                     case "id_order_item_etiqueta_conferencia_volumes":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta_conferencia":
                     case "OrderItemEtiquetaConferencia":
                     command.CommandText += " LEFT JOIN order_item_etiqueta_conferencia as order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia ON order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia.id_order_item_etiqueta_conferencia = order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia.id_order_item_etiqueta_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_OrderItemEtiquetaConferencia.id_order_item_etiqueta_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ocv_numero_volume":
                     case "NumeroVolume":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.ocv_numero_volume " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.ocv_numero_volume) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ocv_total_volumes":
                     case "TotalVolumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.ocv_total_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.ocv_total_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ocv_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.ocv_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.ocv_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ocv_peso":
                     case "Peso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.ocv_peso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.ocv_peso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ocv_cubagem":
                     case "Cubagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia_volumes.ocv_cubagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_volumes.ocv_cubagem) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia_volumes.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia_volumes.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ocv_cubagem")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia_volumes.ocv_cubagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia_volumes.ocv_cubagem) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_order_item_etiqueta_conferencia_volumes")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia_volumes = :order_item_etiqueta_conferencia_volumes_ID_7239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_ID_7239", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiquetaConferencia" || parametro.FieldName == "id_order_item_etiqueta_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.id_order_item_etiqueta_conferencia = :order_item_etiqueta_conferencia_volumes_OrderItemEtiquetaConferencia_9720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_OrderItemEtiquetaConferencia_9720", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroVolume" || parametro.FieldName == "ocv_numero_volume")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_numero_volume IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_numero_volume = :order_item_etiqueta_conferencia_volumes_NumeroVolume_2931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_NumeroVolume_2931", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TotalVolumes" || parametro.FieldName == "ocv_total_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_total_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_total_volumes = :order_item_etiqueta_conferencia_volumes_TotalVolumes_2995 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_TotalVolumes_2995", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "ocv_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_quantidade = :order_item_etiqueta_conferencia_volumes_Quantidade_7572 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_Quantidade_7572", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  order_item_etiqueta_conferencia_volumes.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.entity_uid LIKE :order_item_etiqueta_conferencia_volumes_EntityUid_6121 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_EntityUid_6121", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item_etiqueta_conferencia_volumes.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.version = :order_item_etiqueta_conferencia_volumes_Version_9898 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_Version_9898", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Peso" || parametro.FieldName == "ocv_peso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_peso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_peso = :order_item_etiqueta_conferencia_volumes_Peso_9698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_Peso_9698", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cubagem" || parametro.FieldName == "ocv_cubagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_cubagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_cubagem LIKE :order_item_etiqueta_conferencia_volumes_Cubagem_9884 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_Cubagem_9884", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item_etiqueta_conferencia_volumes.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.entity_uid LIKE :order_item_etiqueta_conferencia_volumes_EntityUid_8278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_EntityUid_8278", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CubagemExato" || parametro.FieldName == "CubagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_cubagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia_volumes.ocv_cubagem LIKE :order_item_etiqueta_conferencia_volumes_Cubagem_9188 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_volumes_Cubagem_9188", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrderItemEtiquetaConferenciaVolumesClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrderItemEtiquetaConferenciaVolumesClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrderItemEtiquetaConferenciaVolumesClass), Convert.ToInt32(read["id_order_item_etiqueta_conferencia_volumes"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrderItemEtiquetaConferenciaVolumesClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_order_item_etiqueta_conferencia_volumes"]);
                     if (read["id_order_item_etiqueta_conferencia"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiquetaConferencia = (BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta_conferencia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiquetaConferencia = null ;
                     }
                     entidade.NumeroVolume = (int)read["ocv_numero_volume"];
                     entidade.TotalVolumes = (int)read["ocv_total_volumes"];
                     entidade.Quantidade = (double)read["ocv_quantidade"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Peso = (double)read["ocv_peso"];
                     entidade.Cubagem = (read["ocv_cubagem"] != DBNull.Value ? read["ocv_cubagem"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrderItemEtiquetaConferenciaVolumesClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

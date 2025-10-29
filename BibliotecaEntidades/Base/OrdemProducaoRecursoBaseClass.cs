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
     [Table("ordem_producao_recurso","opr")]
     public class OrdemProducaoRecursoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoRecursoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoRecursoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoRecursoClass.";
protected const string ErroRecursoCodigoObrigatorio = "O campo RecursoCodigo é obrigatório";
protected const string ErroRecursoCodigoComprimento = "O campo RecursoCodigo deve ter no máximo 255 caracteres";
protected const string ErroRecursoNomeObrigatorio = "O campo RecursoNome é obrigatório";
protected const string ErroRecursoNomeComprimento = "O campo RecursoNome deve ter no máximo 255 caracteres";
protected const string ErroPostoTrabalhoCodigoObrigatorio = "O campo PostoTrabalhoCodigo é obrigatório";
protected const string ErroPostoTrabalhoCodigoComprimento = "O campo PostoTrabalhoCodigo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected const string ErroRecursoObrigatorio = "O campo Recurso é obrigatório";
protected const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoRecursoClass.";
protected const string ErroFormularioPreenchidoLoad = "O campo FormularioPreenchido não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoRecursoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _valueOrdemProducao;
        [Column("id_ordem_producao", "ordem_producao", "id_ordem_producao")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoClass OrdemProducao
        { 
           get {                 return this._valueOrdemProducao; } 
           set 
           { 
                if (this._valueOrdemProducao == value)return;
                 this._valueOrdemProducao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.RecursoClass _recursoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.RecursoClass _recursoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.RecursoClass _valueRecurso;
        [Column("id_recurso", "recurso", "id_recurso")]
       public virtual BibliotecaEntidades.Entidades.RecursoClass Recurso
        { 
           get {                 return this._valueRecurso; } 
           set 
           { 
                if (this._valueRecurso == value)return;
                 this._valueRecurso = value; 
           } 
       } 

       protected string _recursoCodigoOriginal{get;private set;}
       private string _recursoCodigoOriginalCommited{get; set;}
        private string _valueRecursoCodigo;
         [Column("opr_recurso_codigo")]
        public virtual string RecursoCodigo
         { 
            get { return this._valueRecursoCodigo; } 
            set 
            { 
                if (this._valueRecursoCodigo == value)return;
                 this._valueRecursoCodigo = value; 
            } 
        } 

       protected string _recursoNomeOriginal{get;private set;}
       private string _recursoNomeOriginalCommited{get; set;}
        private string _valueRecursoNome;
         [Column("opr_recurso_nome")]
        public virtual string RecursoNome
         { 
            get { return this._valueRecursoNome; } 
            set 
            { 
                if (this._valueRecursoNome == value)return;
                 this._valueRecursoNome = value; 
            } 
        } 

       protected string _postoTrabalhoCodigoOriginal{get;private set;}
       private string _postoTrabalhoCodigoOriginalCommited{get; set;}
        private string _valuePostoTrabalhoCodigo;
         [Column("opr_posto_trabalho_codigo")]
        public virtual string PostoTrabalhoCodigo
         { 
            get { return this._valuePostoTrabalhoCodigo; } 
            set 
            { 
                if (this._valuePostoTrabalhoCodigo == value)return;
                 this._valuePostoTrabalhoCodigo = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _valuePostoTrabalho;
        [Column("id_posto_trabalho", "posto_trabalho", "id_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.PostoTrabalhoClass PostoTrabalho
        { 
           get {                 return this._valuePostoTrabalho; } 
           set 
           { 
                if (this._valuePostoTrabalho == value)return;
                 this._valuePostoTrabalho = value; 
           } 
       } 

       protected string _recursoRevisaoOriginal{get;private set;}
       private string _recursoRevisaoOriginalCommited{get; set;}
        private string _valueRecursoRevisao;
         [Column("opr_recurso_revisao")]
        public virtual string RecursoRevisao
         { 
            get { return this._valueRecursoRevisao; } 
            set 
            { 
                if (this._valueRecursoRevisao == value)return;
                 this._valueRecursoRevisao = value; 
            } 
        } 

       protected string _recursoFamiliaOriginal{get;private set;}
       private string _recursoFamiliaOriginalCommited{get; set;}
        private string _valueRecursoFamilia;
         [Column("opr_recurso_familia")]
        public virtual string RecursoFamilia
         { 
            get { return this._valueRecursoFamilia; } 
            set 
            { 
                if (this._valueRecursoFamilia == value)return;
                 this._valueRecursoFamilia = value; 
            } 
        } 

       protected string _recursoLoc1Original{get;private set;}
       private string _recursoLoc1OriginalCommited{get; set;}
        private string _valueRecursoLoc1;
         [Column("opr_recurso_loc1")]
        public virtual string RecursoLoc1
         { 
            get { return this._valueRecursoLoc1; } 
            set 
            { 
                if (this._valueRecursoLoc1 == value)return;
                 this._valueRecursoLoc1 = value; 
            } 
        } 

       protected string _recursoLoc2Original{get;private set;}
       private string _recursoLoc2OriginalCommited{get; set;}
        private string _valueRecursoLoc2;
         [Column("opr_recurso_loc2")]
        public virtual string RecursoLoc2
         { 
            get { return this._valueRecursoLoc2; } 
            set 
            { 
                if (this._valueRecursoLoc2 == value)return;
                 this._valueRecursoLoc2 = value; 
            } 
        } 

       protected string _recursoLoc3Original{get;private set;}
       private string _recursoLoc3OriginalCommited{get; set;}
        private string _valueRecursoLoc3;
         [Column("opr_recurso_loc3")]
        public virtual string RecursoLoc3
         { 
            get { return this._valueRecursoLoc3; } 
            set 
            { 
                if (this._valueRecursoLoc3 == value)return;
                 this._valueRecursoLoc3 = value; 
            } 
        } 

       protected int _recursoHierarquiaOriginal{get;private set;}
       private int _recursoHierarquiaOriginalCommited{get; set;}
        private int _valueRecursoHierarquia;
         [Column("opr_recurso_hierarquia")]
        public virtual int RecursoHierarquia
         { 
            get { return this._valueRecursoHierarquia; } 
            set 
            { 
                if (this._valueRecursoHierarquia == value)return;
                 this._valueRecursoHierarquia = value; 
            } 
        } 

       protected string _recursoLoc4Original{get;private set;}
       private string _recursoLoc4OriginalCommited{get; set;}
        private string _valueRecursoLoc4;
         [Column("opr_recurso_loc4")]
        public virtual string RecursoLoc4
         { 
            get { return this._valueRecursoLoc4; } 
            set 
            { 
                if (this._valueRecursoLoc4 == value)return;
                 this._valueRecursoLoc4 = value; 
            } 
        } 

       protected TipoRecurso _recursoTipoOriginal{get;private set;}
       private TipoRecurso _recursoTipoOriginalCommited{get; set;}
        private TipoRecurso _valueRecursoTipo;
         [Column("opr_recurso_tipo")]
        public virtual TipoRecurso RecursoTipo
         { 
            get { return this._valueRecursoTipo; } 
            set 
            { 
                if (this._valueRecursoTipo == value)return;
                 this._valueRecursoTipo = value; 
            } 
        } 

        public bool RecursoTipo_Normal
         { 
            get { return this._valueRecursoTipo == BibliotecaEntidades.Base.TipoRecurso.Normal; } 
            set { if (value) this._valueRecursoTipo = BibliotecaEntidades.Base.TipoRecurso.Normal; }
         } 

        public bool RecursoTipo_Formulario
         { 
            get { return this._valueRecursoTipo == BibliotecaEntidades.Base.TipoRecurso.Formulario; } 
            set { if (value) this._valueRecursoTipo = BibliotecaEntidades.Base.TipoRecurso.Formulario; }
         } 

        public bool RecursoTipo_CNC
         { 
            get { return this._valueRecursoTipo == BibliotecaEntidades.Base.TipoRecurso.CNC; } 
            set { if (value) this._valueRecursoTipo = BibliotecaEntidades.Base.TipoRecurso.CNC; }
         } 

       protected string _recursoDiretorioOrigemOriginal{get;private set;}
       private string _recursoDiretorioOrigemOriginalCommited{get; set;}
        private string _valueRecursoDiretorioOrigem;
         [Column("opr_recurso_diretorio_origem")]
        public virtual string RecursoDiretorioOrigem
         { 
            get { return this._valueRecursoDiretorioOrigem; } 
            set 
            { 
                if (this._valueRecursoDiretorioOrigem == value)return;
                 this._valueRecursoDiretorioOrigem = value; 
            } 
        } 

       protected string _recursoDiretorioDestinoOriginal{get;private set;}
       private string _recursoDiretorioDestinoOriginalCommited{get; set;}
        private string _valueRecursoDiretorioDestino;
         [Column("opr_recurso_diretorio_destino")]
        public virtual string RecursoDiretorioDestino
         { 
            get { return this._valueRecursoDiretorioDestino; } 
            set 
            { 
                if (this._valueRecursoDiretorioDestino == value)return;
                 this._valueRecursoDiretorioDestino = value; 
            } 
        } 

       protected string _formularioPreenchidoOriginal= null;
        private string _formularioPreenchidoOriginalCommited= null;
        private bool _FormularioPreenchidoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool FormularioPreenchidoLoaded 
       { 
            get {                     return _FormularioPreenchidoLoaded; } 
           set 
           { 
                this._FormularioPreenchidoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueFormularioPreenchido;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("opr_formulario_preenchido")]
        public virtual byte[] FormularioPreenchido
         { 
            get { 
                   if (!this.FormularioPreenchidoLoaded) 
                   {
                       this.LoadFormularioPreenchido();
                   }
                   return this._valueFormularioPreenchido; } 
            set 
            { 
                FormularioPreenchidoLoaded = true; 
                if (this._valueFormularioPreenchido == value)return;
                 this._valueFormularioPreenchido = value; 
            } 
        } 

        public OrdemProducaoRecursoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.RecursoHierarquia = 0;
           this.RecursoTipo = (TipoRecurso)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoRecursoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoRecursoClass) GetEntity(typeof(OrdemProducaoRecursoClass),id,usuarioAtual,connection, operacao);
        }
private void LoadFormularioPreenchido()
        {
            try
            {
                if (this.ID == -1)
                {

                    FormularioPreenchidoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT opr_formulario_preenchido FROM ordem_producao_recurso WHERE id_ordem_producao_recurso = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueFormularioPreenchido = (byte[]) tmp;
                }
                if (this._valueFormularioPreenchido != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _formularioPreenchidoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueFormularioPreenchido));
                     }
                  } 
                  else 
                  { 
                        _formularioPreenchidoOriginal = null ;
                  } 
                FormularioPreenchidoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroFormularioPreenchidoLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(RecursoCodigo))
                {
                    throw new Exception(ErroRecursoCodigoObrigatorio);
                }
                if (RecursoCodigo.Length >255)
                {
                    throw new Exception( ErroRecursoCodigoComprimento);
                }
                if (string.IsNullOrEmpty(RecursoNome))
                {
                    throw new Exception(ErroRecursoNomeObrigatorio);
                }
                if (RecursoNome.Length >255)
                {
                    throw new Exception( ErroRecursoNomeComprimento);
                }
                if (string.IsNullOrEmpty(PostoTrabalhoCodigo))
                {
                    throw new Exception(ErroPostoTrabalhoCodigoObrigatorio);
                }
                if (PostoTrabalhoCodigo.Length >255)
                {
                    throw new Exception( ErroPostoTrabalhoCodigoComprimento);
                }
                if ( _valueOrdemProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoObrigatorio);
                }
                if ( _valueRecurso == null)
                {
                    throw new Exception(ErroRecursoObrigatorio);
                }
                if ( _valuePostoTrabalho == null)
                {
                    throw new Exception(ErroPostoTrabalhoObrigatorio);
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
                    "  public.ordem_producao_recurso  " +
                    "WHERE " +
                    "  id_ordem_producao_recurso = :id";
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
                        "  public.ordem_producao_recurso   " +
                        "SET  " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  id_recurso = :id_recurso, " + 
                        "  opr_recurso_codigo = :opr_recurso_codigo, " + 
                        "  opr_recurso_nome = :opr_recurso_nome, " + 
                        "  opr_posto_trabalho_codigo = :opr_posto_trabalho_codigo, " + 
                        "  id_posto_trabalho = :id_posto_trabalho, " + 
                        "  opr_recurso_revisao = :opr_recurso_revisao, " + 
                        "  opr_recurso_familia = :opr_recurso_familia, " + 
                        "  opr_recurso_loc1 = :opr_recurso_loc1, " + 
                        "  opr_recurso_loc2 = :opr_recurso_loc2, " + 
                        "  opr_recurso_loc3 = :opr_recurso_loc3, " + 
                        "  opr_recurso_hierarquia = :opr_recurso_hierarquia, " + 
                        "  opr_recurso_loc4 = :opr_recurso_loc4, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  opr_recurso_tipo = :opr_recurso_tipo, " + 
                        "  opr_recurso_diretorio_origem = :opr_recurso_diretorio_origem, " + 
                        "  opr_recurso_diretorio_destino = :opr_recurso_diretorio_destino, " + 
                        "  opr_formulario_preenchido = :opr_formulario_preenchido "+
                        "WHERE  " +
                        "  id_ordem_producao_recurso = :id " +
                        "RETURNING id_ordem_producao_recurso;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_recurso " +
                        "( " +
                        "  id_ordem_producao , " + 
                        "  id_recurso , " + 
                        "  opr_recurso_codigo , " + 
                        "  opr_recurso_nome , " + 
                        "  opr_posto_trabalho_codigo , " + 
                        "  id_posto_trabalho , " + 
                        "  opr_recurso_revisao , " + 
                        "  opr_recurso_familia , " + 
                        "  opr_recurso_loc1 , " + 
                        "  opr_recurso_loc2 , " + 
                        "  opr_recurso_loc3 , " + 
                        "  opr_recurso_hierarquia , " + 
                        "  opr_recurso_loc4 , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  opr_recurso_tipo , " + 
                        "  opr_recurso_diretorio_origem , " + 
                        "  opr_recurso_diretorio_destino , " + 
                        "  opr_formulario_preenchido  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao , " + 
                        "  :id_recurso , " + 
                        "  :opr_recurso_codigo , " + 
                        "  :opr_recurso_nome , " + 
                        "  :opr_posto_trabalho_codigo , " + 
                        "  :id_posto_trabalho , " + 
                        "  :opr_recurso_revisao , " + 
                        "  :opr_recurso_familia , " + 
                        "  :opr_recurso_loc1 , " + 
                        "  :opr_recurso_loc2 , " + 
                        "  :opr_recurso_loc3 , " + 
                        "  :opr_recurso_hierarquia , " + 
                        "  :opr_recurso_loc4 , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :opr_recurso_tipo , " + 
                        "  :opr_recurso_diretorio_origem , " + 
                        "  :opr_recurso_diretorio_destino , " + 
                        "  :opr_formulario_preenchido  "+
                        ")RETURNING id_ordem_producao_recurso;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_recurso", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Recurso==null ? (object) DBNull.Value : this.Recurso.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_posto_trabalho_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoTrabalhoCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalho==null ? (object) DBNull.Value : this.PostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_familia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoFamilia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoLoc1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoLoc2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoLoc3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_hierarquia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoHierarquia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc4", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoLoc4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.RecursoTipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_diretorio_origem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoDiretorioOrigem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_diretorio_destino", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecursoDiretorioDestino ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_formulario_preenchido", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FormularioPreenchido ?? DBNull.Value;

 
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
        public static OrdemProducaoRecursoClass CopiarEntidade(OrdemProducaoRecursoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoRecursoClass toRet = new OrdemProducaoRecursoClass(usuario,conn);
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.Recurso= entidadeCopiar.Recurso;
 toRet.RecursoCodigo= entidadeCopiar.RecursoCodigo;
 toRet.RecursoNome= entidadeCopiar.RecursoNome;
 toRet.PostoTrabalhoCodigo= entidadeCopiar.PostoTrabalhoCodigo;
 toRet.PostoTrabalho= entidadeCopiar.PostoTrabalho;
 toRet.RecursoRevisao= entidadeCopiar.RecursoRevisao;
 toRet.RecursoFamilia= entidadeCopiar.RecursoFamilia;
 toRet.RecursoLoc1= entidadeCopiar.RecursoLoc1;
 toRet.RecursoLoc2= entidadeCopiar.RecursoLoc2;
 toRet.RecursoLoc3= entidadeCopiar.RecursoLoc3;
 toRet.RecursoHierarquia= entidadeCopiar.RecursoHierarquia;
 toRet.RecursoLoc4= entidadeCopiar.RecursoLoc4;
 toRet.RecursoTipo= entidadeCopiar.RecursoTipo;
 toRet.RecursoDiretorioOrigem= entidadeCopiar.RecursoDiretorioOrigem;
 toRet.RecursoDiretorioDestino= entidadeCopiar.RecursoDiretorioDestino;
 toRet.FormularioPreenchido= entidadeCopiar.FormularioPreenchido;

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
       _ordemProducaoOriginal = OrdemProducao;
       _ordemProducaoOriginalCommited = _ordemProducaoOriginal;
       _recursoOriginal = Recurso;
       _recursoOriginalCommited = _recursoOriginal;
       _recursoCodigoOriginal = RecursoCodigo;
       _recursoCodigoOriginalCommited = _recursoCodigoOriginal;
       _recursoNomeOriginal = RecursoNome;
       _recursoNomeOriginalCommited = _recursoNomeOriginal;
       _postoTrabalhoCodigoOriginal = PostoTrabalhoCodigo;
       _postoTrabalhoCodigoOriginalCommited = _postoTrabalhoCodigoOriginal;
       _postoTrabalhoOriginal = PostoTrabalho;
       _postoTrabalhoOriginalCommited = _postoTrabalhoOriginal;
       _recursoRevisaoOriginal = RecursoRevisao;
       _recursoRevisaoOriginalCommited = _recursoRevisaoOriginal;
       _recursoFamiliaOriginal = RecursoFamilia;
       _recursoFamiliaOriginalCommited = _recursoFamiliaOriginal;
       _recursoLoc1Original = RecursoLoc1;
       _recursoLoc1OriginalCommited = _recursoLoc1Original;
       _recursoLoc2Original = RecursoLoc2;
       _recursoLoc2OriginalCommited = _recursoLoc2Original;
       _recursoLoc3Original = RecursoLoc3;
       _recursoLoc3OriginalCommited = _recursoLoc3Original;
       _recursoHierarquiaOriginal = RecursoHierarquia;
       _recursoHierarquiaOriginalCommited = _recursoHierarquiaOriginal;
       _recursoLoc4Original = RecursoLoc4;
       _recursoLoc4OriginalCommited = _recursoLoc4Original;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _recursoTipoOriginal = RecursoTipo;
       _recursoTipoOriginalCommited = _recursoTipoOriginal;
       _recursoDiretorioOrigemOriginal = RecursoDiretorioOrigem;
       _recursoDiretorioOrigemOriginalCommited = _recursoDiretorioOrigemOriginal;
       _recursoDiretorioDestinoOriginal = RecursoDiretorioDestino;
       _recursoDiretorioDestinoOriginalCommited = _recursoDiretorioDestinoOriginal;

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
       _ordemProducaoOriginalCommited = OrdemProducao;
       _recursoOriginalCommited = Recurso;
       _recursoCodigoOriginalCommited = RecursoCodigo;
       _recursoNomeOriginalCommited = RecursoNome;
       _postoTrabalhoCodigoOriginalCommited = PostoTrabalhoCodigo;
       _postoTrabalhoOriginalCommited = PostoTrabalho;
       _recursoRevisaoOriginalCommited = RecursoRevisao;
       _recursoFamiliaOriginalCommited = RecursoFamilia;
       _recursoLoc1OriginalCommited = RecursoLoc1;
       _recursoLoc2OriginalCommited = RecursoLoc2;
       _recursoLoc3OriginalCommited = RecursoLoc3;
       _recursoHierarquiaOriginalCommited = RecursoHierarquia;
       _recursoLoc4OriginalCommited = RecursoLoc4;
       _versionOriginalCommited = Version;
       _recursoTipoOriginalCommited = RecursoTipo;
       _recursoDiretorioOrigemOriginalCommited = RecursoDiretorioOrigem;
       _recursoDiretorioDestinoOriginalCommited = RecursoDiretorioDestino;

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
               if (FormularioPreenchidoLoaded)
               {
                  if(this._valueFormularioPreenchido != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _formularioPreenchidoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueFormularioPreenchido));
                     }
                  } 
                  else 
                  { 
                        _formularioPreenchidoOriginal = null ;
                  } 
               }

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
               OrdemProducao=_ordemProducaoOriginal;
               _ordemProducaoOriginalCommited=_ordemProducaoOriginal;
               Recurso=_recursoOriginal;
               _recursoOriginalCommited=_recursoOriginal;
               RecursoCodigo=_recursoCodigoOriginal;
               _recursoCodigoOriginalCommited=_recursoCodigoOriginal;
               RecursoNome=_recursoNomeOriginal;
               _recursoNomeOriginalCommited=_recursoNomeOriginal;
               PostoTrabalhoCodigo=_postoTrabalhoCodigoOriginal;
               _postoTrabalhoCodigoOriginalCommited=_postoTrabalhoCodigoOriginal;
               PostoTrabalho=_postoTrabalhoOriginal;
               _postoTrabalhoOriginalCommited=_postoTrabalhoOriginal;
               RecursoRevisao=_recursoRevisaoOriginal;
               _recursoRevisaoOriginalCommited=_recursoRevisaoOriginal;
               RecursoFamilia=_recursoFamiliaOriginal;
               _recursoFamiliaOriginalCommited=_recursoFamiliaOriginal;
               RecursoLoc1=_recursoLoc1Original;
               _recursoLoc1OriginalCommited=_recursoLoc1Original;
               RecursoLoc2=_recursoLoc2Original;
               _recursoLoc2OriginalCommited=_recursoLoc2Original;
               RecursoLoc3=_recursoLoc3Original;
               _recursoLoc3OriginalCommited=_recursoLoc3Original;
               RecursoHierarquia=_recursoHierarquiaOriginal;
               _recursoHierarquiaOriginalCommited=_recursoHierarquiaOriginal;
               RecursoLoc4=_recursoLoc4Original;
               _recursoLoc4OriginalCommited=_recursoLoc4Original;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               RecursoTipo=_recursoTipoOriginal;
               _recursoTipoOriginalCommited=_recursoTipoOriginal;
               RecursoDiretorioOrigem=_recursoDiretorioOrigemOriginal;
               _recursoDiretorioOrigemOriginalCommited=_recursoDiretorioOrigemOriginal;
               RecursoDiretorioDestino=_recursoDiretorioDestinoOriginal;
               _recursoDiretorioDestinoOriginalCommited=_recursoDiretorioDestinoOriginal;
               FormularioPreenchidoLoaded = false;
               this._formularioPreenchidoOriginal = null;
               this._formularioPreenchidoOriginalCommited = null;
               this._valueFormularioPreenchido = null;

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
       if (_ordemProducaoOriginal!=null)
       {
          dirty = !_ordemProducaoOriginal.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       if (_recursoOriginal!=null)
       {
          dirty = !_recursoOriginal.Equals(Recurso);
       }
       else
       {
            dirty = Recurso != null;
       }
      if (dirty) return true;
       dirty = _recursoCodigoOriginal != RecursoCodigo;
      if (dirty) return true;
       dirty = _recursoNomeOriginal != RecursoNome;
      if (dirty) return true;
       dirty = _postoTrabalhoCodigoOriginal != PostoTrabalhoCodigo;
      if (dirty) return true;
       if (_postoTrabalhoOriginal!=null)
       {
          dirty = !_postoTrabalhoOriginal.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _recursoRevisaoOriginal != RecursoRevisao;
      if (dirty) return true;
       dirty = _recursoFamiliaOriginal != RecursoFamilia;
      if (dirty) return true;
       dirty = _recursoLoc1Original != RecursoLoc1;
      if (dirty) return true;
       dirty = _recursoLoc2Original != RecursoLoc2;
      if (dirty) return true;
       dirty = _recursoLoc3Original != RecursoLoc3;
      if (dirty) return true;
       dirty = _recursoHierarquiaOriginal != RecursoHierarquia;
      if (dirty) return true;
       dirty = _recursoLoc4Original != RecursoLoc4;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _recursoTipoOriginal != RecursoTipo;
      if (dirty) return true;
       dirty = _recursoDiretorioOrigemOriginal != RecursoDiretorioOrigem;
      if (dirty) return true;
       dirty = _recursoDiretorioDestinoOriginal != RecursoDiretorioDestino;
      if (dirty) return true;
               if (FormularioPreenchidoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpFormularioPreenchido ;
                      if (this._valueFormularioPreenchido == null) 
                      { 
                         tmpFormularioPreenchido = null; 
                      } 
                      else 
                      { 
                         tmpFormularioPreenchido = Convert.ToBase64String(sha1.ComputeHash(this._valueFormularioPreenchido));
                      } 
                       dirty = _formularioPreenchidoOriginal != tmpFormularioPreenchido;
                   }
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
       if (_ordemProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoOriginalCommited.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       if (_recursoOriginalCommited!=null)
       {
          dirty = !_recursoOriginalCommited.Equals(Recurso);
       }
       else
       {
            dirty = Recurso != null;
       }
      if (dirty) return true;
       dirty = _recursoCodigoOriginalCommited != RecursoCodigo;
      if (dirty) return true;
       dirty = _recursoNomeOriginalCommited != RecursoNome;
      if (dirty) return true;
       dirty = _postoTrabalhoCodigoOriginalCommited != PostoTrabalhoCodigo;
      if (dirty) return true;
       if (_postoTrabalhoOriginalCommited!=null)
       {
          dirty = !_postoTrabalhoOriginalCommited.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _recursoRevisaoOriginalCommited != RecursoRevisao;
      if (dirty) return true;
       dirty = _recursoFamiliaOriginalCommited != RecursoFamilia;
      if (dirty) return true;
       dirty = _recursoLoc1OriginalCommited != RecursoLoc1;
      if (dirty) return true;
       dirty = _recursoLoc2OriginalCommited != RecursoLoc2;
      if (dirty) return true;
       dirty = _recursoLoc3OriginalCommited != RecursoLoc3;
      if (dirty) return true;
       dirty = _recursoHierarquiaOriginalCommited != RecursoHierarquia;
      if (dirty) return true;
       dirty = _recursoLoc4OriginalCommited != RecursoLoc4;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _recursoTipoOriginalCommited != RecursoTipo;
      if (dirty) return true;
       dirty = _recursoDiretorioOrigemOriginalCommited != RecursoDiretorioOrigem;
      if (dirty) return true;
       dirty = _recursoDiretorioDestinoOriginalCommited != RecursoDiretorioDestino;
      if (dirty) return true;
               if (FormularioPreenchidoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpFormularioPreenchido ;
                      if (this._valueFormularioPreenchido == null) 
                      { 
                         tmpFormularioPreenchido = null; 
                      } 
                      else 
                      { 
                         tmpFormularioPreenchido = Convert.ToBase64String(sha1.ComputeHash(this._valueFormularioPreenchido));
                      } 
                       dirty = _formularioPreenchidoOriginalCommited != tmpFormularioPreenchido;
                   }
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
             case "OrdemProducao":
                return this.OrdemProducao;
             case "Recurso":
                return this.Recurso;
             case "RecursoCodigo":
                return this.RecursoCodigo;
             case "RecursoNome":
                return this.RecursoNome;
             case "PostoTrabalhoCodigo":
                return this.PostoTrabalhoCodigo;
             case "PostoTrabalho":
                return this.PostoTrabalho;
             case "RecursoRevisao":
                return this.RecursoRevisao;
             case "RecursoFamilia":
                return this.RecursoFamilia;
             case "RecursoLoc1":
                return this.RecursoLoc1;
             case "RecursoLoc2":
                return this.RecursoLoc2;
             case "RecursoLoc3":
                return this.RecursoLoc3;
             case "RecursoHierarquia":
                return this.RecursoHierarquia;
             case "RecursoLoc4":
                return this.RecursoLoc4;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "RecursoTipo":
                return this.RecursoTipo;
             case "RecursoDiretorioOrigem":
                return this.RecursoDiretorioOrigem;
             case "RecursoDiretorioDestino":
                return this.RecursoDiretorioDestino;
             case "FormularioPreenchido":
                return this.FormularioPreenchido;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (OrdemProducao!=null)
                OrdemProducao.ChangeSingleConnection(newConnection);
             if (Recurso!=null)
                Recurso.ChangeSingleConnection(newConnection);
             if (PostoTrabalho!=null)
                PostoTrabalho.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_recurso.id_ordem_producao_recurso) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_recurso.id_ordem_producao_recurso, " ;
               command.CommandText += "ordem_producao_recurso.id_ordem_producao, " ;
               command.CommandText += "ordem_producao_recurso.id_recurso, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_codigo, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_nome, " ;
               command.CommandText += "ordem_producao_recurso.opr_posto_trabalho_codigo, " ;
               command.CommandText += "ordem_producao_recurso.id_posto_trabalho, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_revisao, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_familia, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_loc1, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_loc2, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_loc3, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_hierarquia, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_loc4, " ;
               command.CommandText += "ordem_producao_recurso.entity_uid, " ;
               command.CommandText += "ordem_producao_recurso.version, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_tipo, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_diretorio_origem, " ;
               command.CommandText += "ordem_producao_recurso.opr_recurso_diretorio_destino " ;
               }
               command.CommandText += " FROM  ordem_producao_recurso ";
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
                        orderByClause += " , opr_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opr_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_recurso.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_recurso":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_recurso.id_ordem_producao_recurso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_recurso.id_ordem_producao_recurso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = ordem_producao_recurso.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_OrdemProducao.id_ordem_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_OrdemProducao.id_ordem_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_recurso":
                     case "Recurso":
                     command.CommandText += " LEFT JOIN recurso as recurso_Recurso ON recurso_Recurso.id_recurso = ordem_producao_recurso.id_recurso ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , recurso_Recurso.rec_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(recurso_Recurso.rec_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_codigo":
                     case "RecursoCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_nome":
                     case "RecursoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_posto_trabalho_codigo":
                     case "PostoTrabalhoCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_posto_trabalho_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_posto_trabalho_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho":
                     case "PostoTrabalho":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalho ON posto_trabalho_PostoTrabalho.id_posto_trabalho = ordem_producao_recurso.id_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho_PostoTrabalho.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho_PostoTrabalho.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_revisao":
                     case "RecursoRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_familia":
                     case "RecursoFamilia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_familia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_familia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_loc1":
                     case "RecursoLoc1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_loc1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_loc1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_loc2":
                     case "RecursoLoc2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_loc2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_loc2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_loc3":
                     case "RecursoLoc3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_loc3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_loc3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_hierarquia":
                     case "RecursoHierarquia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_hierarquia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_hierarquia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_loc4":
                     case "RecursoLoc4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_loc4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_loc4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_recurso.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_recurso.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_tipo":
                     case "RecursoTipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_diretorio_origem":
                     case "RecursoDiretorioOrigem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_diretorio_origem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_diretorio_origem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_recurso_diretorio_destino":
                     case "RecursoDiretorioDestino":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_recurso.opr_recurso_diretorio_destino " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_recurso_diretorio_destino) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opr_formulario_preenchido":
                     case "FormularioPreenchido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_recurso.opr_formulario_preenchido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_recurso.opr_formulario_preenchido) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_nome")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_posto_trabalho_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_posto_trabalho_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_posto_trabalho_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_revisao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_familia")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_familia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_familia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_loc1")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_loc1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_loc1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_loc2")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_loc2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_loc2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_loc3")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_loc3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_loc3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_loc4")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_loc4) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_loc4) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_diretorio_origem")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_diretorio_origem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_diretorio_origem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opr_recurso_diretorio_destino")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_recurso.opr_recurso_diretorio_destino) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_recurso.opr_recurso_diretorio_destino) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_recurso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.id_ordem_producao_recurso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.id_ordem_producao_recurso = :ordem_producao_recurso_ID_9104 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_ID_9104", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducao" || parametro.FieldName == "id_ordem_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.id_ordem_producao = :ordem_producao_recurso_OrdemProducao_1584 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_OrdemProducao_1584", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Recurso" || parametro.FieldName == "id_recurso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.RecursoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.RecursoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.id_recurso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.id_recurso = :ordem_producao_recurso_Recurso_7872 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_Recurso_7872", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoCodigo" || parametro.FieldName == "opr_recurso_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_codigo LIKE :ordem_producao_recurso_RecursoCodigo_7156 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoCodigo_7156", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoNome" || parametro.FieldName == "opr_recurso_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_nome LIKE :ordem_producao_recurso_RecursoNome_7638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoNome_7638", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCodigo" || parametro.FieldName == "opr_posto_trabalho_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_posto_trabalho_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_posto_trabalho_codigo LIKE :ordem_producao_recurso_PostoTrabalhoCodigo_5018 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_PostoTrabalhoCodigo_5018", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalho" || parametro.FieldName == "id_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.id_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.id_posto_trabalho = :ordem_producao_recurso_PostoTrabalho_2089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_PostoTrabalho_2089", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoRevisao" || parametro.FieldName == "opr_recurso_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_revisao LIKE :ordem_producao_recurso_RecursoRevisao_1285 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoRevisao_1285", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoFamilia" || parametro.FieldName == "opr_recurso_familia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_familia LIKE :ordem_producao_recurso_RecursoFamilia_4633 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoFamilia_4633", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc1" || parametro.FieldName == "opr_recurso_loc1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc1 LIKE :ordem_producao_recurso_RecursoLoc1_5114 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc1_5114", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc2" || parametro.FieldName == "opr_recurso_loc2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc2 LIKE :ordem_producao_recurso_RecursoLoc2_2578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc2_2578", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc3" || parametro.FieldName == "opr_recurso_loc3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc3 LIKE :ordem_producao_recurso_RecursoLoc3_4502 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc3_4502", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoHierarquia" || parametro.FieldName == "opr_recurso_hierarquia")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_hierarquia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_hierarquia = :ordem_producao_recurso_RecursoHierarquia_8158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoHierarquia_8158", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc4" || parametro.FieldName == "opr_recurso_loc4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc4 LIKE :ordem_producao_recurso_RecursoLoc4_283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc4_283", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_recurso.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.entity_uid LIKE :ordem_producao_recurso_EntityUid_3612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_EntityUid_3612", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_recurso.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.version = :ordem_producao_recurso_Version_5615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_Version_5615", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoTipo" || parametro.FieldName == "opr_recurso_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoRecurso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoRecurso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_tipo = :ordem_producao_recurso_RecursoTipo_8353 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoTipo_8353", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoDiretorioOrigem" || parametro.FieldName == "opr_recurso_diretorio_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_origem LIKE :ordem_producao_recurso_RecursoDiretorioOrigem_754 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoDiretorioOrigem_754", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoDiretorioDestino" || parametro.FieldName == "opr_recurso_diretorio_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_destino LIKE :ordem_producao_recurso_RecursoDiretorioDestino_6053 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoDiretorioDestino_6053", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormularioPreenchido" || parametro.FieldName == "opr_formulario_preenchido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_formulario_preenchido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_formulario_preenchido = :ordem_producao_recurso_FormularioPreenchido_4032 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_FormularioPreenchido_4032", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoCodigoExato" || parametro.FieldName == "RecursoCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_codigo LIKE :ordem_producao_recurso_RecursoCodigo_3927 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoCodigo_3927", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoNomeExato" || parametro.FieldName == "RecursoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_nome LIKE :ordem_producao_recurso_RecursoNome_9490 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoNome_9490", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCodigoExato" || parametro.FieldName == "PostoTrabalhoCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_posto_trabalho_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_posto_trabalho_codigo LIKE :ordem_producao_recurso_PostoTrabalhoCodigo_2916 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_PostoTrabalhoCodigo_2916", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoRevisaoExato" || parametro.FieldName == "RecursoRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_revisao LIKE :ordem_producao_recurso_RecursoRevisao_23 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoRevisao_23", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoFamiliaExato" || parametro.FieldName == "RecursoFamiliaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_familia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_familia LIKE :ordem_producao_recurso_RecursoFamilia_8818 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoFamilia_8818", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc1Exato" || parametro.FieldName == "RecursoLoc1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc1 LIKE :ordem_producao_recurso_RecursoLoc1_2752 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc1_2752", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc2Exato" || parametro.FieldName == "RecursoLoc2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc2 LIKE :ordem_producao_recurso_RecursoLoc2_7526 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc2_7526", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc3Exato" || parametro.FieldName == "RecursoLoc3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc3 LIKE :ordem_producao_recurso_RecursoLoc3_6342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc3_6342", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoLoc4Exato" || parametro.FieldName == "RecursoLoc4Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_loc4 LIKE :ordem_producao_recurso_RecursoLoc4_5326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoLoc4_5326", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_recurso.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.entity_uid LIKE :ordem_producao_recurso_EntityUid_3763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_EntityUid_3763", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoDiretorioOrigemExato" || parametro.FieldName == "RecursoDiretorioOrigemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_origem LIKE :ordem_producao_recurso_RecursoDiretorioOrigem_8313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoDiretorioOrigem_8313", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecursoDiretorioDestinoExato" || parametro.FieldName == "RecursoDiretorioDestinoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_recurso.opr_recurso_diretorio_destino LIKE :ordem_producao_recurso_RecursoDiretorioDestino_379 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_recurso_RecursoDiretorioDestino_379", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoRecursoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoRecursoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoRecursoClass), Convert.ToInt32(read["id_ordem_producao_recurso"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoRecursoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_recurso"]);
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     if (read["id_recurso"] != DBNull.Value)
                     {
                        entidade.Recurso = (BibliotecaEntidades.Entidades.RecursoClass)BibliotecaEntidades.Entidades.RecursoClass.GetEntidade(Convert.ToInt32(read["id_recurso"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Recurso = null ;
                     }
                     entidade.RecursoCodigo = (read["opr_recurso_codigo"] != DBNull.Value ? read["opr_recurso_codigo"].ToString() : null);
                     entidade.RecursoNome = (read["opr_recurso_nome"] != DBNull.Value ? read["opr_recurso_nome"].ToString() : null);
                     entidade.PostoTrabalhoCodigo = (read["opr_posto_trabalho_codigo"] != DBNull.Value ? read["opr_posto_trabalho_codigo"].ToString() : null);
                     if (read["id_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.PostoTrabalho = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalho = null ;
                     }
                     entidade.RecursoRevisao = (read["opr_recurso_revisao"] != DBNull.Value ? read["opr_recurso_revisao"].ToString() : null);
                     entidade.RecursoFamilia = (read["opr_recurso_familia"] != DBNull.Value ? read["opr_recurso_familia"].ToString() : null);
                     entidade.RecursoLoc1 = (read["opr_recurso_loc1"] != DBNull.Value ? read["opr_recurso_loc1"].ToString() : null);
                     entidade.RecursoLoc2 = (read["opr_recurso_loc2"] != DBNull.Value ? read["opr_recurso_loc2"].ToString() : null);
                     entidade.RecursoLoc3 = (read["opr_recurso_loc3"] != DBNull.Value ? read["opr_recurso_loc3"].ToString() : null);
                     entidade.RecursoHierarquia = (int)read["opr_recurso_hierarquia"];
                     entidade.RecursoLoc4 = (read["opr_recurso_loc4"] != DBNull.Value ? read["opr_recurso_loc4"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.RecursoTipo = (TipoRecurso) (read["opr_recurso_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoRecurso), read["opr_recurso_tipo"]) : null);
                     entidade.RecursoDiretorioOrigem = (read["opr_recurso_diretorio_origem"] != DBNull.Value ? read["opr_recurso_diretorio_origem"].ToString() : null);
                     entidade.RecursoDiretorioDestino = (read["opr_recurso_diretorio_destino"] != DBNull.Value ? read["opr_recurso_diretorio_destino"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoRecursoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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

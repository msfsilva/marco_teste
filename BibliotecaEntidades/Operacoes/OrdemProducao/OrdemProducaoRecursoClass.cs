using System;
using System.IO;
using BibliotecaEntidades.Base;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoRecursoClass
    {
        public long? idOrdemProducaoRecurso { get; private set; }
        public long idRecurso { get; private set; }
        public string postoTrabalhoCodigo { get; private set; }
        
        public long idPostoTrabalho { get; private set; }

        public string recursoCodigo { get; private set; }
        public string recursoDescricao { get; private set; }
        public string recursoLoc1 { get; private set; }
        public string recursoLoc2 { get; private set; }
        public string recursoLoc3 { get; private set; }
        public string recursoLoc4 { get; private set; }
        public string recursoRev { get; private set; }
        public string recursoFamilia { get; private set; }

        public TipoRecurso recursoTipo { get; private set; }
        public string recursoCaminhoArquivo { get; private set; }
        public string recursoCaminhoDestino { get; private set; }

        public byte[] formularioPreenchido { get; internal set; }
    

        

        public HierarquiaRecursoEstrutura Hierarquia { get; private set; }

        private IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;

        public bool toDelete { get; private set; }


        public OrdemProducaoRecursoClass(long? idOrdemProducaoRecurso, long idRecurso, string postoTrabalhoCodigo,
                                         string recursoCodigo, string recursoDescricao, string recursoRev,string recursoFamilia,
                                         string recursoLoc1, string recursoLoc2, string recursoLoc3, string recursoLoc4,
                                         TipoRecurso recursoTipo, string recursoCaminhoArquivo, string recursoCaminhoDestino,
                                         byte[] formularioPreenchido, 
                                         HierarquiaRecursoEstrutura Hierarquia,
                                         long idPostoTrabalho, OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoRecurso = idOrdemProducaoRecurso;
            this.idRecurso = idRecurso;
            this.postoTrabalhoCodigo = postoTrabalhoCodigo;
          
            this.idPostoTrabalho = idPostoTrabalho;

            this.recursoCodigo = recursoCodigo;
            this.recursoDescricao = recursoDescricao;
            this.recursoRev = recursoRev;
            this.recursoFamilia = recursoFamilia;
            this.recursoLoc1 = recursoLoc1;
            this.recursoLoc2 = recursoLoc2;
            this.recursoLoc3 = recursoLoc3;
            this.recursoLoc4 = recursoLoc4;
            this.Hierarquia = Hierarquia;

            this.recursoCaminhoArquivo = recursoCaminhoArquivo;
            this.recursoCaminhoDestino = recursoCaminhoDestino;
            this.recursoTipo = recursoTipo;

            this.formularioPreenchido = formularioPreenchido;

            this.conn = conn;
            this.Parent = Parent;

            this.toDelete = false;
        }

        public void Delete()
        {
            this.toDelete = true;
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (idOrdemProducaoRecurso != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_recurso  " +
                            "WHERE  " +
                            "  id_ordem_producao_recurso = :id_ordem_producao_recurso " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_recurso", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoRecurso;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {

                    bool Novo = false;
                    if (this.idOrdemProducaoRecurso == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_recurso " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  id_recurso, " +
                            "  opr_recurso_codigo, " +
                            "  opr_recurso_nome, " +
                            "  opr_posto_trabalho_codigo, " +
                            "  id_posto_trabalho, " +
                            "  opr_recurso_revisao, " +
                            "  opr_recurso_familia, " +
                            "  opr_recurso_loc1, " +
                            "  opr_recurso_loc2, " +
                            "  opr_recurso_loc3, " +
                            "  opr_recurso_loc4, " +
                            "  opr_recurso_hierarquia, " +
                            "  opr_recurso_tipo,  " +
                            "  opr_recurso_diretorio_origem, " +
                            "  opr_recurso_diretorio_destino, " +
                            "  opr_formulario_preenchido " +
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :id_recurso, " +
                            "  :opr_recurso_codigo, " +
                            "  :opr_recurso_nome, " +
                            "  :opr_posto_trabalho_codigo, " +
                            "  :id_posto_trabalho, " +
                            "  :opr_recurso_revisao, " +
                            "  :opr_recurso_familia, " +
                            "  :opr_recurso_loc1, " +
                            "  :opr_recurso_loc2, " +
                            "  :opr_recurso_loc3, " +
                            "  :opr_recurso_loc4, " +
                            "  :opr_recurso_hierarquia, " +
                            "  :opr_recurso_tipo,  " +
                            "  :opr_recurso_diretorio_origem, " +
                            "  :opr_recurso_diretorio_destino, " +
                            "  :opr_formulario_preenchido " +
                            ") RETURNING id_ordem_producao_recurso;";

                        Novo = true;
                    }
                    else
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
                            "  opr_recurso_loc4 = :opr_recurso_loc4, " +
                            "  opr_recurso_hierarquia = :opr_recurso_hierarquia, " +
                            "  opr_recurso_tipo = :opr_recurso_tipo,  " +
                            "  opr_recurso_diretorio_origem = :opr_recurso_diretorio_origem, " +
                            "  opr_recurso_diretorio_destino = :opr_recurso_diretorio_destino, " +
                            "  opr_formulario_preenchido = :opr_formulario_preenchido " +
                            "WHERE  " +
                            "  id_ordem_producao_recurso = :id_ordem_producao_recurso " +
                            "RETURNING  id_ordem_producao_recurso;";
                        Novo = false;
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_recurso", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoRecurso;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_recurso", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idRecurso;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoCodigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_nome", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoDescricao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_posto_trabalho_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.postoTrabalhoCodigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idPostoTrabalho;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_revisao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoRev;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_familia", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoFamilia;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc1", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoLoc1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc2", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoLoc2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc3", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoLoc3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_loc4", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoLoc4;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_hierarquia", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Hierarquia;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_tipo", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoTipo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_diretorio_origem", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoCaminhoArquivo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_recurso_diretorio_destino", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.recursoCaminhoDestino;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opr_formulario_preenchido", NpgsqlDbType.Bytea));
                    command.Parameters[command.Parameters.Count - 1].Value = this.formularioPreenchido;

                    
                    this.idOrdemProducaoRecurso = Convert.ToInt32(command.ExecuteScalar());

                    if (Novo && this.recursoTipo == TipoRecurso.CNC)
                    {
                        try
                        {
                            if (File.Exists(this.recursoCaminhoArquivo) && Directory.Exists(this.recursoCaminhoDestino))
                            {
                                FileInfo f = new FileInfo(this.recursoCaminhoArquivo);
                                f.CopyTo(this.recursoCaminhoDestino + "\\" + f.Name, true);
                            }
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Erro ao copiar o recurso do tipo CNC: " + this.recursoCodigo + ".\r\n" + e.Message, e);
                        }

                        Novo = false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Recurso.\r\n" + e.Message);
            }
        }

        public override string ToString()
        {
            return this.recursoFamilia + " - " + this.recursoCodigo;
        }
    }
}
using System;
using BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoMaterialClass
    {
        public int? idOrdemProducaoMaterial { get; private set; }
        public MaterialClass Material{ get; private set; }
        public string Descricao { get; private set; }
        public string unidadeMedida { get; private set; }
        public double Espessura { get; private set; }

        public double Largura { get; private set; }
        public double Comprimento { get; private set; }
        public string tipoAcabamento { get; private set; }
        public string Codigo { get; private set; }

        public double Quantidade { get; internal set; }


        public string Familia { get; private set; }

        

        private IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;

        public bool toDelete { get; private set; }

        public OrdemProducaoMaterialClass(int? idOrdemProducaoMaterial, MaterialClass material, string Descricao, string unidadeMedida, double Espessura, double Largura, double Comprimento, string tipoAcabamento, string Codigo, double Quantidade,string Familia,  OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoMaterial = idOrdemProducaoMaterial;
            Material = material;
            this.Descricao = Descricao;
            this.unidadeMedida = unidadeMedida;
            this.Espessura = Espessura;

            this.Largura = Largura;
            this.Comprimento = Comprimento;
            this.tipoAcabamento = tipoAcabamento;
            this.Codigo = Codigo;

            this.Quantidade = Quantidade;

            this.Familia = Familia;

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
                    if (idOrdemProducaoMaterial != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_material  " +
                            "WHERE  " +
                            "  id_ordem_producao_material = :id_ordem_producao_material " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_material", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoMaterial;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoMaterial == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_material " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  id_material, " +
                            "  opm_quantidade, " +
                            "  opm_material_descricao, " +
                            "  opm_material_unidade_medida, " +
                            "  opm_material_medida, " +
                            "  opm_material_medida_largura, " +
                            "  opm_material_medida_comprimento, " +
                            "  opm_material_tipo_acabamento, " +
                            "  opm_material_codigo " +
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :id_material, " +
                            "  :opm_quantidade, " +
                            "  :opm_material_descricao, " +
                            "  :opm_material_unidade_medida, " +
                            "  :opm_material_medida, " +
                            "  :opm_material_medida_largura, " +
                            "  :opm_material_medida_comprimento, " +
                            "  :opm_material_tipo_acabamento, " +
                            "  :opm_material_codigo " +
                            ") RETURNING id_ordem_producao_material;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_material   " +
                            "SET  " +
                            "  id_ordem_producao = :id_ordem_producao, " +
                            "  id_material = :id_material, " +
                            "  opm_quantidade = :opm_quantidade, " +
                            "  opm_material_descricao = :opm_material_descricao, " +
                            "  opm_material_unidade_medida = :opm_material_unidade_medida, " +
                            "  opm_material_medida = :opm_material_medida, " +
                            "  opm_material_medida_largura = :opm_material_medida_largura, " +
                            "  opm_material_medida_comprimento = :opm_material_medida_comprimento, " +
                            "  opm_material_tipo_acabamento = :opm_material_tipo_acabamento, " +
                            "  opm_material_codigo = :opm_material_codigo " +
                            "WHERE  " +
                            "  id_ordem_producao_material = :id_ordem_producao_material " +
                            "RETURNING  id_ordem_producao_material;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_material", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoMaterial;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Material.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_descricao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Descricao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_unidade_medida", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.unidadeMedida;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_medida", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Espessura;


                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_medida_largura", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Largura;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_medida_comprimento", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Comprimento;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_tipo_acabamento", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.tipoAcabamento;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Codigo;

                    
                     

                    

                    this.idOrdemProducaoMaterial = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Material.\r\n" + e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class MaterialFornecedorClass : MaterialFornecedorBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do MaterialFornecedorClass";
        protected new const string ErroDelete = "Erro ao excluir o MaterialFornecedorClass  ";
        protected new const string ErroSave = "Erro ao salvar o MaterialFornecedorClass.";
        protected new const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do MaterialFornecedorClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade MaterialFornecedorClass está sendo utilizada.";

        #endregion

        

        public MaterialFornecedorClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        public string FornecedorNomeFantasia
        {
            get { return this.Fornecedor.NomeFantasia; }
        }

        public string FornecedorRazao
        {
            get { return this.Fornecedor.RazaoSocial; }
        }


        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        public void LimparID()
        {
            BufferAbstractEntity.invalidarEntidade(this.GetType(), this.ID);
            this.ID = -1;
        }

        public void setUltimoPreco(double ultimoPreco, double icms, double ipi)
        {
            this.UltimoPreco = ultimoPreco;
            this.Icms = icms;
            this.Ipi = ipi;
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.Ativo)
            {
                List<MaterialFornecedorClass> materiaisFornecedor = this.Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Material", this.Material),
                    new SearchParameterClass("Fornecedor", this.Fornecedor)
                }).ConvertAll(a => (MaterialFornecedorClass) a).Where(a => a.Ativo && a.ID != this.ID).ToList();

                if (materiaisFornecedor.Count > 0)
                {
                    throw new ExcecaoTratada("Esse fornecedor já está cadastrado para o material " + this.Material.IdentificacaoCompleta);
                }
            }

            return true;
        }


       public static DateTime? GetDataUltimoRecebimento(MaterialClass material, FornecedorClass fornecedor, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
       {
           LoteClass ultimoLote = (LoteClass)new LoteClass(usuario, conn).Search(new List<SearchParameterClass>()
           {
               new SearchParameterClass("Material", material),
               new SearchParameterClass("Fornecedor", fornecedor),
               new SearchParameterClass("DataRecebimento", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Desc, TipoOrdenacao.Data)
           }, limit: 1).FirstOrDefault();


           return ultimoLote?.DataRecebimento;
       }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idMaterialSimulador = Material.ID + 20000000;
            long idMaterialFornecedorSimulador = ID + 20000000;

            if (Ativo && Material.Ativo)
            {

                long idUnidadeMedida;
                double conversaoUnidade;
                double loteMinimo;
                double lotePadrao;
                if (UnidadeMedidaCompra != null)
                {
                    idUnidadeMedida = UnidadeMedidaCompra.ID;
                    conversaoUnidade = this.UnidadesPorUnCompra ?? 1;
                    loteMinimo = LoteMinimo ?? 1;
                    lotePadrao = LotePadrao ?? 1;
                }
                else
                {
                    if (Material.UnidadeMedidaCompra != null)
                    {
                        idUnidadeMedida = Material.UnidadeMedidaCompra.ID;
                        conversaoUnidade = Material.UnidadesPorUnCompra;
                        loteMinimo = Material.LoteMinimo;
                        lotePadrao = Material.LotePadrao;
                    }
                    else
                    {
                        idUnidadeMedida = Material.UnidadeMedida.ID;
                        conversaoUnidade = 1;
                        loteMinimo = 1;
                        lotePadrao = 1;
                    }
                }

                loteMinimo = loteMinimo * conversaoUnidade;
                lotePadrao = lotePadrao * conversaoUnidade;


                ProdutoFornecedorDto dto = new ProdutoFornecedorDto()
                {
                    id = idMaterialFornecedorSimulador,
                    unidadeMedidaId = idUnidadeMedida,
                    produtoId = idMaterialSimulador,
                    aliquotaIcms = Icms,
                    aliquotaIpi = Ipi,
                    conversaoUnidade = conversaoUnidade,
                    dataUltimaCompra = this.DataUltimaCompra,
                    dataUltimoRecebimento = GetDataUltimoRecebimento(Material, Fornecedor, UsuarioAtual, command.Connection),
                    fornecedorId = Fornecedor.ID,
                    fornecedorPreferencial = Preferencial,
                    loteMinimo = loteMinimo,
                    lotePadrao = lotePadrao,
                    precoUnitario = Math.Round(UltimoPreco / conversaoUnidade, 4, MidpointRounding.AwayFromZero)

                };

                ApiSimuladorCompras.SincronizarMaterialFornecedor(dto.id, false, UsuarioAtual, command);
            }
            else
            {
                
                ApiSimuladorCompras.SincronizarMaterialFornecedor(idMaterialFornecedorSimulador, true, UsuarioAtual, command);
            }
        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
            long idMaterialFornecedorSimulador = ID + 20000000;
            ApiSimuladorCompras.SincronizarMaterialFornecedor(idMaterialFornecedorSimulador, true, UsuarioAtual, command);
        }

        public void SincronizarSDC(IWTPostgreNpgsqlConnection conn)
        {
            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            long idMaterialSimulador = Material.ID + 20000000;
            long idMaterialFornecedorSimulador = ID + 20000000;

            if (Ativo && Material.Ativo)
            {

                long idUnidadeMedida;
                double conversaoUnidade;
                double loteMinimo;
                double lotePadrao;
                if (UnidadeMedidaCompra != null)
                {
                    idUnidadeMedida = UnidadeMedidaCompra.ID;
                    conversaoUnidade = this.UnidadesPorUnCompra ?? 1;
                    loteMinimo = LoteMinimo ?? 1;
                    lotePadrao = LotePadrao ?? 1;
                }
                else
                {
                    if (Material.UnidadeMedidaCompra != null)
                    {
                        idUnidadeMedida = Material.UnidadeMedidaCompra.ID;
                        conversaoUnidade = Material.UnidadesPorUnCompra;
                        loteMinimo = Material.LoteMinimo;
                        lotePadrao = Material.LotePadrao;
                    }
                    else
                    {
                        idUnidadeMedida = Material.UnidadeMedida.ID;
                        conversaoUnidade = 1;
                        loteMinimo = 1;
                        lotePadrao = 1;
                    }
                }

                loteMinimo = loteMinimo * conversaoUnidade;
                lotePadrao = lotePadrao * conversaoUnidade;

                ProdutoFornecedorDto dto = new ProdutoFornecedorDto()
                {
                    id = idMaterialFornecedorSimulador,
                    unidadeMedidaId = idUnidadeMedida,
                    produtoId = idMaterialSimulador,
                    aliquotaIcms = Icms,
                    aliquotaIpi = Ipi,
                    conversaoUnidade = conversaoUnidade,
                    dataUltimaCompra = this.DataUltimaCompra,
                    dataUltimoRecebimento = GetDataUltimoRecebimento(Material, Fornecedor, UsuarioAtual, conn),
                    fornecedorId = Fornecedor.ID,
                    fornecedorPreferencial = Preferencial,
                    loteMinimo = loteMinimo,
                    lotePadrao = lotePadrao,
                    precoUnitario = Math.Round(UltimoPreco / conversaoUnidade, 4, MidpointRounding.AwayFromZero)

                };


                ApiSimuladorCompras.SincronizarMaterialFornecedor(dto.id, false, UsuarioAtual, conn);
            }
            else
            {
                ApiSimuladorCompras.SincronizarMaterialFornecedor(idMaterialFornecedorSimulador, true, UsuarioAtual, conn);
            }
        }
    }
}

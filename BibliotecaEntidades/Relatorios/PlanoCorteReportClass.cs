using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Relatorios
{
    public class PlanoCorteReportClass
    {
        public long Numero { get; private set; }
        public string Usuario { get; private set; }
        public DateTime Data { get; private set; }

        public string Material { get; private set; }
        public long MaterialID { get; private set; }
        public string Dimensao1 { get; private set; }
        public string Dimensao1Valor { get; private set; }
        public string Dimensao2 { get; private set; }
        public string Dimensao2Valor { get; private set; }
        public string Dimensao3 { get; private set; }
        public string Dimensao3Valor { get; private set; }
        public double Quantidade { get; private set; }
        public string InfoAdicionais { get; private set; }
        public long PostoTrabalhoCorteID { get; private set; }
        public string PostoTrabalhoCorteNome { get; private set; }
        public string PostoTrabalhoCorteDescricao { get; private set; }

        public string EntidadeGeradora { get; private set; }
        public double EntidadeGeradoraQuantidade { get; private set; }
        public int EntidadeGeradoraSemanaEntrega { get; private set; }
        public string EntidadeGeradoraDataEntrega { get; private set; }
        public string EntidadeGeradoraCodigoItem { get; private set; }
        public string EntidadeGeradoraDescricaoItem { get; private set; }

        public string CanceladoString{ get; private set; }
        public string CanceladoPCString { get; private set; }

        public byte[] LogoCliente { get; private set; }

        public List<PlanoCorteLocalMaterialReportClass> LocaisEstoque = new List<PlanoCorteLocalMaterialReportClass>();

        public bool temEstoque { get { return LocaisEstoque.Count > 0; } }


        public static List<PlanoCorteReportClass> ImprimirPlanoCorte(PlanoCorteClass planoCorte, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<PlanoCorteReportClass> toRet = new List<PlanoCorteReportClass>();
                byte[] logoClienteTmp = null;

                #region Logo

                byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

                if (tmp != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    tmp = ms.ToArray();
                    logoClienteTmp = tmp;
                }

                #endregion

                foreach (PlanoCorteItemClass item in planoCorte.CollectionPlanoCorteItemClassPlanoCorte)
                {
                    foreach (PlanoCorteItemOpClass itemOp in item.CollectionPlanoCorteItemOpClassPlanoCorteItem)
                    {

                        //Busca a menor data de entrega
                        DateTime? dataEntregaTmp =
                            itemOp.OrdemProducao.CollectionOrdemProducaoPedidoClassOrdemProducao.Where(a => a.OrderItemEtiqueta != null).Min(
                                a => a.OrderItemEtiqueta.ItemOriginalPedido ? a.OrderItemEtiqueta.PedidoItem.DataEntrega : a.OrderItemEtiqueta.DataEntrega);
                        string dataEntrega = "";
                        if (dataEntregaTmp.HasValue)
                        {
                            dataEntrega = dataEntregaTmp.Value.ToString("dd/MM/yyyy");
                        }


                        toRet.Add(new PlanoCorteReportClass()
                                      {
                                          Data = planoCorte.Data,
                                          Dimensao1 = item.Dimensao1 + ": " + item.Dimensao1Valor + " " + (item.UnidadeMedida1 != null ? item.UnidadeMedida1.Abreviada : ""),
                                          Dimensao1Valor = item.Dimensao1Valor,
                                          Dimensao2 = item.Dimensao2 + ": " + item.Dimensao2Valor + " " + (item.UnidadeMedida2 != null ? item.UnidadeMedida2.Abreviada : ""),
                                          Dimensao2Valor = item.Dimensao2Valor,
                                          Dimensao3 = item.Dimensao3 + ": " + item.Dimensao3Valor + " " + (item.UnidadeMedida3 != null ? item.UnidadeMedida3.Abreviada : ""),
                                          Dimensao3Valor = item.Dimensao3Valor,
                                          EntidadeGeradora = "OP: " + itemOp.OrdemProducao.ID,
                                          EntidadeGeradoraQuantidade = itemOp.Quantidade,
                                          InfoAdicionais = item.InformacoesAdicionais,
                                          MaterialID = item.Material.ID,
                                          Material = item.Material.ToString(),
                                          Numero = planoCorte.ID,
                                          PostoTrabalhoCorteDescricao = item.PostoDescricao,
                                          PostoTrabalhoCorteNome = item.PostoNome,
                                          PostoTrabalhoCorteID = item.PostoTrabalhoCorte.ID,
                                          Quantidade = item.Quantidade,
                                          Usuario = planoCorte.AcsUsuario.ToString(),
                                          LogoCliente = logoClienteTmp,
                                          EntidadeGeradoraCodigoItem = itemOp.OrdemProducao.ProdutoCodigo,
                                          EntidadeGeradoraDescricaoItem = itemOp.OrdemProducao.ProdutoDescricao,
                                          EntidadeGeradoraSemanaEntrega = (itemOp.OrdemProducao.CollectionOrdemProducaoPedidoClassOrdemProducao.Min(a => a.SemanaEntrega) ?? 0),
                                          EntidadeGeradoraDataEntrega = dataEntrega,
                                          CanceladoString = item.Cancelado ? "Item cancelado por " + item.AcsUsuarioCancelamento.Login + " em " + item.CancelamentoData.Value.ToString("dd/MM/yyyy HH:mm:ss") + " - " + item.CancelamentoJustificativa : "",
                                          CanceladoPCString = planoCorte.Cancelado ? "PC cancelado por " + planoCorte.AcsUsuarioCancelamento.Login + " em " + planoCorte.CancelamentoData.Value.ToString("dd/MM/yyyy HH:mm:ss") + " - " + planoCorte.CancelamentoJustificativa : ""
                                      }
                            );
                    }

                    foreach (PlanoCorteItemPedidoClass itemPedido in item.CollectionPlanoCorteItemPedidoClassPlanoCorteItem)
                    {
                        //Busca a menor data de entrega
                        DateTime? dataEntregaTmp = itemPedido.OrderItemEtiqueta!=null && itemPedido.OrderItemEtiqueta.ItemOriginalPedido ? itemPedido.OrderItemEtiqueta.PedidoItem.DataEntrega : itemPedido.OrderItemEtiqueta.DataEntrega;
                        string dataEntrega = "";
                        if (dataEntregaTmp.HasValue)
                        {
                            dataEntrega = dataEntregaTmp.Value.ToString("dd/MM/yyyy");
                        }

                        toRet.Add(new PlanoCorteReportClass()
                                      {
                                          Data = planoCorte.Data,
                                          Dimensao1 = item.Dimensao1 + ": " + item.Dimensao1Valor + " " + (item.UnidadeMedida1 != null ? item.UnidadeMedida1.Abreviada : ""),
                                          Dimensao1Valor = item.Dimensao1Valor,
                                          Dimensao2 = item.Dimensao2 + ": " + item.Dimensao2Valor + " " + (item.UnidadeMedida2 != null ? item.UnidadeMedida2.Abreviada : ""),
                                          Dimensao2Valor = item.Dimensao2Valor,
                                          Dimensao3 = item.Dimensao3 + ": " + item.Dimensao3Valor + " " + (item.UnidadeMedida3 != null ? item.UnidadeMedida3.Abreviada : ""),
                                          Dimensao3Valor = item.Dimensao3Valor,
                                          EntidadeGeradora = "Pedido: " + itemPedido.PedidoNumero + "/" + itemPedido.PedidoPosicao + " - " + itemPedido.PedidoCliente,
                                          EntidadeGeradoraQuantidade = itemPedido.Quantidade,
                                          InfoAdicionais = item.InformacoesAdicionais,
                                          MaterialID = item.Material.ID,
                                          Material = item.Material.ToString(),
                                          Numero = planoCorte.ID,
                                          PostoTrabalhoCorteDescricao = item.PostoDescricao,
                                          PostoTrabalhoCorteNome = item.PostoNome,
                                          PostoTrabalhoCorteID = item.PostoTrabalhoCorte.ID,
                                          Quantidade = item.Quantidade,
                                          Usuario = planoCorte.AcsUsuario.ToString(),
                                          LogoCliente = logoClienteTmp,
                                          EntidadeGeradoraCodigoItem = itemPedido.OrderItemEtiqueta.CodigoItem,
                                          EntidadeGeradoraDescricaoItem = itemPedido.OrderItemEtiqueta.Descricao,
                                          EntidadeGeradoraSemanaEntrega = (itemPedido.OrderItemEtiqueta.Pps ?? 0),
                                          EntidadeGeradoraDataEntrega = dataEntrega,
                                          CanceladoString = item.Cancelado ? "Item cancelado por " + item.AcsUsuarioCancelamento.Login + " em " + item.CancelamentoData.Value.ToString("dd/MM/yyyy HH:mm:ss") + " - " + item.CancelamentoJustificativa : "",
                                          CanceladoPCString = planoCorte.Cancelado ? "PC cancelado por " + planoCorte.AcsUsuarioCancelamento.Login + " em " + planoCorte.CancelamentoData.Value.ToString("dd/MM/yyyy HH:mm:ss") + " - " + planoCorte.CancelamentoJustificativa : ""
                                      }
                            );
                    }

                }

                Dictionary<PlanoCorteReportKey, PlanoCorteReportClass> toRetFinal = new Dictionary<PlanoCorteReportKey, PlanoCorteReportClass>();

                foreach (PlanoCorteReportClass itemPlanoCorte in toRet)
                {
                    PlanoCorteReportKey key = new PlanoCorteReportKey()
                    {
                        Data = itemPlanoCorte.Data,
                        Dimensao1 = itemPlanoCorte.Dimensao1,
                        Dimensao1Valor = itemPlanoCorte.Dimensao1Valor,
                        Dimensao2 = itemPlanoCorte.Dimensao2,
                        Dimensao2Valor = itemPlanoCorte.Dimensao2Valor,
                        Dimensao3 = itemPlanoCorte.Dimensao3,
                        Dimensao3Valor = itemPlanoCorte.Dimensao3Valor,
                        EntidadeGeradora = itemPlanoCorte.EntidadeGeradora,
                        InfoAdicionais = itemPlanoCorte.InfoAdicionais,
                        MaterialID = itemPlanoCorte.MaterialID,
                        Material = itemPlanoCorte.Material,
                        Numero = itemPlanoCorte.Numero,
                        PostoTrabalhoCorteDescricao = itemPlanoCorte.PostoTrabalhoCorteDescricao,
                        PostoTrabalhoCorteNome = itemPlanoCorte.PostoTrabalhoCorteNome,
                        PostoTrabalhoCorteID = itemPlanoCorte.PostoTrabalhoCorteID,
                        Usuario = itemPlanoCorte.Usuario,
                        EntidadeGeradoraCodigoItem = itemPlanoCorte.EntidadeGeradoraCodigoItem,
                        EntidadeGeradoraDescricaoItem = itemPlanoCorte.EntidadeGeradoraDescricaoItem,
                        EntidadeGeradoraSemanaEntrega = itemPlanoCorte.EntidadeGeradoraSemanaEntrega,
                        EntidadeGeradoraDataEntrega = itemPlanoCorte.EntidadeGeradoraDataEntrega,
                        CanceladoString = itemPlanoCorte.CanceladoString,
                        CanceladoPCString = itemPlanoCorte.CanceladoPCString,
                    };

                    if (!toRetFinal.ContainsKey(key))
                    {
                        toRetFinal.Add(key,new PlanoCorteReportClass()
                        {
                            Data = key.Data,
                            Dimensao1 = key.Dimensao1,
                            Dimensao1Valor = key.Dimensao1Valor,
                            Dimensao2 = key.Dimensao2,
                            Dimensao2Valor = key.Dimensao2Valor,
                            Dimensao3 = key.Dimensao3,
                            Dimensao3Valor = key.Dimensao3Valor,
                            EntidadeGeradora = key.EntidadeGeradora,
                            InfoAdicionais = key.InfoAdicionais,
                            MaterialID = key.MaterialID,
                            Material = key.Material,
                            Numero = key.Numero,
                            PostoTrabalhoCorteDescricao = key.PostoTrabalhoCorteDescricao,
                            PostoTrabalhoCorteNome = key.PostoTrabalhoCorteNome,
                            PostoTrabalhoCorteID = key.PostoTrabalhoCorteID,
                            Usuario = key.Usuario,
                            EntidadeGeradoraCodigoItem = key.EntidadeGeradoraCodigoItem,
                            EntidadeGeradoraDescricaoItem = key.EntidadeGeradoraDescricaoItem,
                            EntidadeGeradoraSemanaEntrega = key.EntidadeGeradoraSemanaEntrega,
                            EntidadeGeradoraDataEntrega = key.EntidadeGeradoraDataEntrega,
                            CanceladoString = key.CanceladoString,
                            CanceladoPCString = key.CanceladoPCString,
                            LogoCliente = itemPlanoCorte.LogoCliente,
                            Quantidade = 0,
                            EntidadeGeradoraQuantidade = 0
                        });
                    }

                    toRetFinal[key].Quantidade = Math.Round(toRetFinal[key].Quantidade + itemPlanoCorte.Quantidade, 5);
                    toRetFinal[key].EntidadeGeradoraQuantidade = Math.Round(toRetFinal[key].EntidadeGeradoraQuantidade + itemPlanoCorte.EntidadeGeradoraQuantidade, 5);
                }

                toRet = toRetFinal.Values.ToList();

                foreach (PlanoCorteReportClass itemReport in toRet)
                {
                    itemReport.EntidadeGeradoraQuantidade = Math.Ceiling(itemReport.EntidadeGeradoraQuantidade);

                    if (itemReport.EntidadeGeradoraQuantidade > 0)
                    {
                        //Carrega Materiais

                        MaterialClass material = MaterialClass.GetEntidade(itemReport.MaterialID, LoginClass.UsuarioLogado.loggedUser, conn);

                        List<EstoqueGavetaItemClass> locais = EstoqueMovimentacao.BuscaTodasGavetasItemMaterial(material);
                        foreach (EstoqueGavetaItemClass gaveta in locais)
                        {
                            if (gaveta.Quantidade > 0)
                            {
                                itemReport.LocaisEstoque.Add(new PlanoCorteLocalMaterialReportClass()
                                {
                                    LocalEstoque = gaveta.IdentificacaoCompleta,
                                    QtdEstoque = gaveta.Quantidade,
                                    Unidade = material.UnidadeMedida.Abreviada,
                                    MaterialID = material.ID,
                                    NumeroPc = itemReport.Numero,
                                    
                                });
                            }
                        }
                        itemReport.LocaisEstoque = itemReport.LocaisEstoque.OrderBy(a => a.LocalEstoque).ToList();
                    }
                }

                toRet = toRet.Where(a => a.EntidadeGeradoraQuantidade > 0).ToList();

                toRet.Sort(new PlanoCorteReportClassComparer());



                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao prepara o plano de corte para impressão.\r\n" + e.Message, e);
            }
        }

        private class PlanoCorteReportKey
        {
            public long Numero { get; set; }
            public string Usuario { get; set; }
            public DateTime Data { get; set; }

            public string Material { get; set; }
            public long MaterialID { get; set; }
            public string Dimensao1 { get; set; }
            public string Dimensao1Valor { get; set; }
            public string Dimensao2 { get; set; }
            public string Dimensao2Valor { get; set; }
            public string Dimensao3 { get; set; }
            public string Dimensao3Valor { get; set; }
            public string InfoAdicionais { get; set; }
            public long PostoTrabalhoCorteID { get; set; }
            public string PostoTrabalhoCorteNome { get; set; }
            public string PostoTrabalhoCorteDescricao { get; set; }

            public string EntidadeGeradora { get; set; }
            public int EntidadeGeradoraSemanaEntrega { get; set; }
            public string EntidadeGeradoraDataEntrega { get; set; }
            public string EntidadeGeradoraCodigoItem { get; set; }
            public string EntidadeGeradoraDescricaoItem { get; set; }

            public string CanceladoString { get; set; }
            public string CanceladoPCString { get; set; }

            protected bool Equals(PlanoCorteReportKey other)
            {
                return Numero == other.Numero && string.Equals(Usuario, other.Usuario) && Data.Equals(other.Data) && string.Equals(Material, other.Material) && MaterialID == other.MaterialID && string.Equals(Dimensao1, other.Dimensao1) && string.Equals(Dimensao1Valor, other.Dimensao1Valor) && string.Equals(Dimensao2, other.Dimensao2) && string.Equals(Dimensao2Valor, other.Dimensao2Valor) && string.Equals(Dimensao3, other.Dimensao3) && string.Equals(Dimensao3Valor, other.Dimensao3Valor) && string.Equals(InfoAdicionais, other.InfoAdicionais) && PostoTrabalhoCorteID == other.PostoTrabalhoCorteID && string.Equals(PostoTrabalhoCorteNome, other.PostoTrabalhoCorteNome) && string.Equals(PostoTrabalhoCorteDescricao, other.PostoTrabalhoCorteDescricao) && string.Equals(EntidadeGeradora, other.EntidadeGeradora) && EntidadeGeradoraSemanaEntrega == other.EntidadeGeradoraSemanaEntrega && string.Equals(EntidadeGeradoraDataEntrega, other.EntidadeGeradoraDataEntrega) && string.Equals(EntidadeGeradoraCodigoItem, other.EntidadeGeradoraCodigoItem) && string.Equals(EntidadeGeradoraDescricaoItem, other.EntidadeGeradoraDescricaoItem) && string.Equals(CanceladoString, other.CanceladoString) && string.Equals(CanceladoPCString, other.CanceladoPCString);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((PlanoCorteReportKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = Numero.GetHashCode();
                    hashCode = (hashCode * 397) ^ (Usuario != null ? Usuario.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ Data.GetHashCode();
                    hashCode = (hashCode * 397) ^ (Material != null ? Material.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ MaterialID.GetHashCode();
                    hashCode = (hashCode * 397) ^ (Dimensao1 != null ? Dimensao1.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Dimensao1Valor != null ? Dimensao1Valor.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Dimensao2 != null ? Dimensao2.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Dimensao2Valor != null ? Dimensao2Valor.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Dimensao3 != null ? Dimensao3.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (Dimensao3Valor != null ? Dimensao3Valor.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (InfoAdicionais != null ? InfoAdicionais.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ PostoTrabalhoCorteID.GetHashCode();
                    hashCode = (hashCode * 397) ^ (PostoTrabalhoCorteNome != null ? PostoTrabalhoCorteNome.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (PostoTrabalhoCorteDescricao != null ? PostoTrabalhoCorteDescricao.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (EntidadeGeradora != null ? EntidadeGeradora.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ EntidadeGeradoraSemanaEntrega;
                    hashCode = (hashCode * 397) ^ (EntidadeGeradoraDataEntrega != null ? EntidadeGeradoraDataEntrega.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (EntidadeGeradoraCodigoItem != null ? EntidadeGeradoraCodigoItem.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (EntidadeGeradoraDescricaoItem != null ? EntidadeGeradoraDescricaoItem.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (CanceladoString != null ? CanceladoString.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (CanceladoPCString != null ? CanceladoPCString.GetHashCode() : 0);
                    return hashCode;
                }
            }

            private sealed class PlanoCorteReportKeyEqualityComparer : IEqualityComparer<PlanoCorteReportKey>
            {
                public bool Equals(PlanoCorteReportKey x, PlanoCorteReportKey y)
                {
                    if (ReferenceEquals(x, y)) return true;
                    if (ReferenceEquals(x, null)) return false;
                    if (ReferenceEquals(y, null)) return false;
                    if (x.GetType() != y.GetType()) return false;
                    return x.Numero == y.Numero && string.Equals(x.Usuario, y.Usuario) && x.Data.Equals(y.Data) && string.Equals(x.Material, y.Material) && x.MaterialID == y.MaterialID && string.Equals(x.Dimensao1, y.Dimensao1) && string.Equals(x.Dimensao1Valor, y.Dimensao1Valor) && string.Equals(x.Dimensao2, y.Dimensao2) && string.Equals(x.Dimensao2Valor, y.Dimensao2Valor) && string.Equals(x.Dimensao3, y.Dimensao3) && string.Equals(x.Dimensao3Valor, y.Dimensao3Valor) && string.Equals(x.InfoAdicionais, y.InfoAdicionais) && x.PostoTrabalhoCorteID == y.PostoTrabalhoCorteID && string.Equals(x.PostoTrabalhoCorteNome, y.PostoTrabalhoCorteNome) && string.Equals(x.PostoTrabalhoCorteDescricao, y.PostoTrabalhoCorteDescricao) && string.Equals(x.EntidadeGeradora, y.EntidadeGeradora) && x.EntidadeGeradoraSemanaEntrega == y.EntidadeGeradoraSemanaEntrega && string.Equals(x.EntidadeGeradoraDataEntrega, y.EntidadeGeradoraDataEntrega) && string.Equals(x.EntidadeGeradoraCodigoItem, y.EntidadeGeradoraCodigoItem) && string.Equals(x.EntidadeGeradoraDescricaoItem, y.EntidadeGeradoraDescricaoItem) && string.Equals(x.CanceladoString, y.CanceladoString) && string.Equals(x.CanceladoPCString, y.CanceladoPCString);
                }

                public int GetHashCode(PlanoCorteReportKey obj)
                {
                    unchecked
                    {
                        var hashCode = obj.Numero.GetHashCode();
                        hashCode = (hashCode * 397) ^ (obj.Usuario != null ? obj.Usuario.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ obj.Data.GetHashCode();
                        hashCode = (hashCode * 397) ^ (obj.Material != null ? obj.Material.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ obj.MaterialID.GetHashCode();
                        hashCode = (hashCode * 397) ^ (obj.Dimensao1 != null ? obj.Dimensao1.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.Dimensao1Valor != null ? obj.Dimensao1Valor.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.Dimensao2 != null ? obj.Dimensao2.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.Dimensao2Valor != null ? obj.Dimensao2Valor.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.Dimensao3 != null ? obj.Dimensao3.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.Dimensao3Valor != null ? obj.Dimensao3Valor.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.InfoAdicionais != null ? obj.InfoAdicionais.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ obj.PostoTrabalhoCorteID.GetHashCode();
                        hashCode = (hashCode * 397) ^ (obj.PostoTrabalhoCorteNome != null ? obj.PostoTrabalhoCorteNome.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.PostoTrabalhoCorteDescricao != null ? obj.PostoTrabalhoCorteDescricao.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.EntidadeGeradora != null ? obj.EntidadeGeradora.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ obj.EntidadeGeradoraSemanaEntrega;
                        hashCode = (hashCode * 397) ^ (obj.EntidadeGeradoraDataEntrega != null ? obj.EntidadeGeradoraDataEntrega.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.EntidadeGeradoraCodigoItem != null ? obj.EntidadeGeradoraCodigoItem.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.EntidadeGeradoraDescricaoItem != null ? obj.EntidadeGeradoraDescricaoItem.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.CanceladoString != null ? obj.CanceladoString.GetHashCode() : 0);
                        hashCode = (hashCode * 397) ^ (obj.CanceladoPCString != null ? obj.CanceladoPCString.GetHashCode() : 0);
                        return hashCode;
                    }
                }
            }

            public static IEqualityComparer<PlanoCorteReportKey> PlanoCorteReportKeyComparer { get; } = new PlanoCorteReportKeyEqualityComparer();
        }

    }

    public class PlanoCorteReportClassComparer : IComparer<PlanoCorteReportClass>
    {
        public int Compare(PlanoCorteReportClass x, PlanoCorteReportClass y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                return 1;
            }

            if (y == null)
            {
                return -1;
            }


            if (x.PostoTrabalhoCorteNome.Equals(y.PostoTrabalhoCorteNome))
            {
                if (x.Material.Equals(y.Material))
                {
                    if (x.Dimensao1Valor == null && y.Dimensao1Valor != null)
                    {
                        return -1;
                    }

                    if (x.Dimensao1Valor != null && x.Dimensao1Valor.Equals(y.Dimensao1Valor))
                    {
                        if (x.Dimensao2Valor == null && y.Dimensao2Valor != null)
                        {
                            return -1;
                        }
                        if (x.Dimensao2Valor != null && x.Dimensao2Valor.Equals(y.Dimensao2Valor))
                        {
                            if (x.Dimensao3Valor == null && y.Dimensao3Valor != null)
                            {
                                return -1;
                            }
                            if (x.Dimensao3Valor != null && x.Dimensao3Valor.Equals(y.Dimensao3Valor))
                            {
                                if (x.InfoAdicionais.Equals(y.InfoAdicionais))
                                {
                                    return x.EntidadeGeradora.CompareTo(y.EntidadeGeradora);
                                }
                                return x.InfoAdicionais.CompareTo(y.InfoAdicionais);
                            }

                            if (x.Dimensao3Valor == null)
                            {
                                return 1;
                            }

                            //Valida ordenação dimensão 3
                            int tmpXDimensao3;
                            int tmpYDimensao3;
                            if (int.TryParse(x.Dimensao3Valor, out tmpXDimensao3))
                            {
                                if (int.TryParse(y.Dimensao3Valor, out tmpYDimensao3))
                                {
                                    return tmpXDimensao3.CompareTo(tmpYDimensao3)*-1;
                                }
                                else
                                {
                                    return -1;
                                }
                            }

                            if (int.TryParse(y.Dimensao3Valor, out tmpYDimensao3))
                            {
                                return 1;
                            }
                        }

                        if (x.Dimensao2Valor == null)
                        {
                            return 1;
                        }

                        //Valida ordenação dimensão 2
                        int tmpXDimensao2;
                        int tmpYDimensao2;
                        if (int.TryParse(x.Dimensao2Valor, out tmpXDimensao2))
                        {
                            if (int.TryParse(y.Dimensao2Valor, out tmpYDimensao2))
                            {
                                return tmpXDimensao2.CompareTo(tmpYDimensao2)*-1;
                            }
                            else
                            {
                                return -1;
                            }
                        }

                        if (int.TryParse(y.Dimensao2Valor, out tmpYDimensao2))
                        {
                            return 1;
                        }
                    }
                        
                    if (x.Dimensao1Valor==null)
                    {
                        return 1;
                    }

                    //Valida ordenação dimensão 1
                    int tmpXDimensao1;
                    int tmpYDimensao1;
                    if (int.TryParse(x.Dimensao1Valor,out tmpXDimensao1))
                    {
                        if (int.TryParse(y.Dimensao1Valor,out tmpYDimensao1))
                        {
                            return tmpXDimensao1.CompareTo(tmpYDimensao1)*-1;
                        }
                        else
                        {
                            return -1;
                        }
                    }

                    if (int.TryParse(y.Dimensao1Valor, out tmpYDimensao1))
                    {
                        return 1;
                    }
                }
                return x.Material.CompareTo(y.Material);
            }
            return x.PostoTrabalhoCorteNome.CompareTo(y.PostoTrabalhoCorteNome);
        }
    }
}

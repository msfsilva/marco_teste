#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using IWTNFCompleto.BibliotecaDatasets;

#endregion

namespace BibliotecaCompras
{
    public class ImportNFEntrada
    {
        readonly string diretorio;
        readonly string diretorioSaida;
        public string erros { get; private set; }

        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass _usuario;
        public ImportNFEntrada(string diretorio, string diretorioSaida, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.diretorio = diretorio;
            this.diretorioSaida = diretorioSaida;
            this.conn = conn;
            this._usuario = usuario;
        }

        public void Importar()
        {
            IWTPostgreNpgsqlCommand command = null;
            List<NFEntradaClass> NFs = new List<NFEntradaClass>();
            try
            {

                try
                {
                    if (!Directory.Exists(this.diretorioSaida + "\\erro\\"))
                    {
                        Directory.CreateDirectory(this.diretorioSaida + "\\erro\\");
                    }
                }
                catch { }

                this.erros = "";
                if (string.IsNullOrWhiteSpace(this.diretorio))
                {
                    return;
                }


                string[] arquivos = Directory.GetFiles(this.diretorio, "*.XML");
                foreach (string arquivo in arquivos)
                {
                    FileInfo f = new FileInfo(arquivo);
                    try
                    {
                        NFs.Add(this.readXML(arquivo));
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            FileInfo arqu = new FileInfo(arquivo);
                            string nomeArquivoSaida = this.diretorioSaida + "\\erro\\" + arqu.Name;
                            if (File.Exists(nomeArquivoSaida))
                            {
                                File.Delete(nomeArquivoSaida);
                            }
                            File.Move(arquivo, nomeArquivoSaida);
                        }
                        catch { }

                        erros += f.Name + ": " + e.Message + Environment.NewLine;
                    }
                }


                command = this.conn.CreateCommand();




                for (int i = 0; i < NFs.Count; i++)
                {
                    NFEntradaClass nf = NFs[i];
                    try
                    {
                        command.Transaction = this.conn.BeginTransaction();

                        nf.Salvar(null, ref command);

                        FileInfo arqu = new FileInfo(nf.nomeArquivo);
                        string nomeArquivoSaida = this.diretorioSaida + "\\" + arqu.Name;
                        if (File.Exists(nomeArquivoSaida))
                        {
                            File.Delete(nomeArquivoSaida);
                        }
                        File.Move(nf.nomeArquivo, nomeArquivoSaida);

                        command.Transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        try
                        {
                            FileInfo arqu = new FileInfo(nf.nomeArquivo);
                            string nomeArquivoSaida = this.diretorioSaida + "\\erro\\" + arqu.Name;
                            if (File.Exists(nomeArquivoSaida))
                            {
                                File.Delete(nomeArquivoSaida);
                            }
                            File.Move(nf.nomeArquivo, nomeArquivoSaida);
                        }
                        catch { }

                        erros += nf.nomeArquivo + " - " + e.Message + "\r\n";

                        if (command != null && command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }
                        continue;
                    }
                }




            }
            catch (Exception e)
            {
                throw new Exception("Erro ao importar as notas fiscais de entrada.\r\n" + e.Message, e);
            }

        }

        private NFEntradaClass readXML(string arquivo)
        {


            NFEntradaClass toRet = readXMLV4(arquivo);
            if (toRet != null)
            {
                return toRet;
            }

            toRet = readXMLV310(arquivo);
            if (toRet != null)
            {
                return toRet;
            }
            
            toRet = readXMLV2(arquivo);

            if (toRet != null)
            {
                return toRet;
            }

            throw new ExcecaoTratada("A nota fiscal não está em um layout reconhecido.");

        }

        private NFEntradaClass readXMLV2(string arquivo)
        {
             TextReader reader = null;
            try
            {
                NFEntradaClass toRet = new NFEntradaClass(null, this._usuario, this.conn);



                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFe nf = null;
                try
                {
                    reader = new StreamReader(arquivo);
                    XmlSerializer serializer = new XmlSerializer(typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNfeProc));
                    IWTNFCompleto.BibliotecaDatasets.v2_0.TNfeProc xml = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNfeProc)serializer.Deserialize(reader);
                    nf = xml.NFe;
                }
                catch
                {
                    try
                    {
                        reader.Close();
                        reader = new StreamReader(arquivo);
                        XmlSerializer serializer = new XmlSerializer(typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFe));
                        nf = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFe)serializer.Deserialize(reader);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                }
                
                toRet.Numero = nf.infNFe.ide.nNF;
                toRet.Serie = nf.infNFe.ide.serie;
                toRet.dataNf = Convert.ToDateTime(nf.infNFe.ide.dEmi);
                toRet.nomeArquivo = arquivo;

                toRet.razaoFornecedorNota = nf.infNFe.emit.xNome;
                toRet.CNPJFornecedorNota = nf.infNFe.emit.Item;

                toRet.valorTotal = double.Parse(nf.infNFe.total.ICMSTot.vNF, CultureInfo.InvariantCulture);


                



                for (int i = 0; i < nf.infNFe.det.Length; i++)
                {
                    IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDet item = nf.infNFe.det[i];
                    double pIcms = 0;
                    double pIpi = 0;
                    for (int j = 0; j < item.imposto.Items.Length; j++)
                    {
                        if (item.imposto.Items[j].GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMS))
                        {

                            IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMS icms = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMS)item.imposto.Items[j];

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS00))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS00 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS00)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;

                            }
                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS10))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS10 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS10)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS20))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS20 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS20)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS30))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS30 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS30)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS40))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS40 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS40)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS51))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS51 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS51)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS60))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS60 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS60)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS70))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS70 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS70)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS90))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS90 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMS90)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);

                                //Busca diferimento pra colocar a aliquota ja desconsiderando o icms parcial
                                double vIcms = double.Parse(tmp.vICMS, CultureInfo.InvariantCulture);
                                double valorBC = double.Parse(tmp.vBC, CultureInfo.InvariantCulture);
                                pIcms = Math.Round(vIcms/valorBC, 2, MidpointRounding.ToEven)*100;


                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSPart))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSPart tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSPart)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN101))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN101 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN101)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN102))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN102 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN102)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN201))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN201 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN201)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN202))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN202 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN202)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN500))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN500 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN500)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN900))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN900 tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSSN900)icms.Item;
                                pIcms = double.Parse(tmp.pICMS, CultureInfo.InvariantCulture);
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSST))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSST tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoICMSICMSST)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                        }
                        else
                        {
                            if (item.imposto.Items[j].GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPI))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPI ipi = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPI)item.imposto.Items[j];

                                if (ipi.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPIIPINT))
                                {
                                    IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPIIPINT tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPIIPINT)ipi.Item;
                                    pIpi = 0;
                                    continue;
                                }

                                if (ipi.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPIIPITrib))
                                {
                                    IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPIIPITrib tmp = (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeDetImpostoIPIIPITrib)ipi.Item;

                                    for (int k = 0; k < tmp.ItemsElementName.Length; k++)
                                    {
                                        if (tmp.ItemsElementName[k] == IWTNFCompleto.BibliotecaDatasets.v2_0.ItemsChoiceType.pIPI)
                                        {
                                            pIpi = double.Parse(tmp.Items[k], CultureInfo.InvariantCulture);
                                            break;
                                        }
                                    }

                                    continue;
                                }
                            }
                        }


                    }


                    double qtd = double.Parse(nf.infNFe.det[i].prod.qCom, CultureInfo.InvariantCulture);
                    double valorUnitario = double.Parse(nf.infNFe.det[i].prod.vUnCom, CultureInfo.InvariantCulture);
                    double valorTotal = double.Parse(nf.infNFe.det[i].prod.vProd, CultureInfo.InvariantCulture);

                    try
                    {
                        if (nf.infNFe.det[i].prod.vDesc != null)
                        {
                            double valorDesconto = double.Parse(nf.infNFe.det[i].prod.vDesc, CultureInfo.InvariantCulture);

                            if (valorDesconto > 0)
                            {
                                valorTotal = valorTotal - valorDesconto;
                                valorUnitario = valorTotal / qtd;
                            }
                        }
                    }
                    catch
                    {
                    }

                    string pedidoCliente = null;
                    int? posicaoPedidoCliente = null;

                    pedidoCliente = nf.infNFe.det[i].prod.xPed;
                    string tmpPosicaoPedido = nf.infNFe.det[i].prod.nItemPed;
                    if (!string.IsNullOrWhiteSpace(tmpPosicaoPedido))
                    {
                        int tmpInt;
                        if (int.TryParse(tmpPosicaoPedido, NumberStyles.Any, CultureInfo.InvariantCulture, out tmpInt))
                        {
                            posicaoPedidoCliente = tmpInt;
                        }
                        else
                        {
                            posicaoPedidoCliente = null;
                        }
                    }
                    

                    toRet.addicionarLinha(
                        i + 1,
                        nf.infNFe.det[i].prod.cProd,
                        nf.infNFe.det[i].prod.xProd,
                        nf.infNFe.det[i].prod.NCM,
                        nf.infNFe.det[i].prod.uCom ?? nf.infNFe.det[i].prod.uTrib,
                        qtd,
                        valorUnitario,
                        valorTotal,
                        pIcms,
                        pIpi,
                        false,
                        pedidoCliente,
                        posicaoPedidoCliente);

                }

                if (nf.infNFe.cobr!=null && nf.infNFe.cobr.dup != null)
                {
                    AgrupadorContaClass agrupador = new AgrupadorContaClass(_usuario,conn)
                    {
                        Data = Configurations.DataIndependenteClass.GetData()
                    };

                    foreach (IWTNFCompleto.BibliotecaDatasets.v2_0.TNFeInfNFeCobrDup dup in nf.infNFe.cobr.dup)
                    {
                        toRet.ContasPagar.Add(
                            new ContaPagarClass(_usuario, conn)
                            {
                                NotaFiscalEntrada = null,
                                Fornecedor = null,
                                CentroCustoLucro = null,
                                ContaBancaria = null,
                                NumDocumento = "NFe " + toRet.Numero,
                                DataVencimento = Convert.ToDateTime(dup.dVenc),
                                Valor = double.Parse(dup.vDup, CultureInfo.InvariantCulture),
                                Historico = "Duplicata " + dup.nDup,
                                AgrupadorConta = agrupador
                            }
                            );

                        agrupador.CollectionContaPagarClassAgrupadorConta.Add(toRet.ContasPagar.Last());
                    }
                }
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao importar o arquivo (" + arquivo + "): " + e.Message, e);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        private NFEntradaClass readXMLV310(string arquivo)
        {
            TextReader reader = null;
            try
            {
                NFEntradaClass toRet = new NFEntradaClass(null, this._usuario, this.conn);



                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFe nf = null;
                try
                {
                    reader = new StreamReader(arquivo);
                    XmlSerializer serializer = new XmlSerializer(typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNfeProc));
                    IWTNFCompleto.BibliotecaDatasets.v3_10.TNfeProc xml = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNfeProc)serializer.Deserialize(reader);
                    nf = xml.NFe;
                }
                catch
                {
                    try
                    {
                        reader.Close();
                        reader = new StreamReader(arquivo);
                        XmlSerializer serializer = new XmlSerializer(typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFe));
                        nf = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFe)serializer.Deserialize(reader);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                }


                //Verificação se a versão é 3.10
                if (nf.infNFe.versao != "3.10")
                {
                    return null;
                }

                toRet.Numero = nf.infNFe.ide.nNF;
                toRet.Serie = nf.infNFe.ide.serie;
                toRet.dataNf = Convert.ToDateTime(nf.infNFe.ide.dhEmi);
                toRet.nomeArquivo = arquivo;

                toRet.razaoFornecedorNota = nf.infNFe.emit.xNome;
                toRet.CNPJFornecedorNota = nf.infNFe.emit.Item;

                toRet.valorTotal = double.Parse(nf.infNFe.total.ICMSTot.vNF, CultureInfo.InvariantCulture);






                for (int i = 0; i < nf.infNFe.det.Length; i++)
                {
                    IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDet item = nf.infNFe.det[i];
                    double pIcms = 0;
                    double pIpi = 0;
                    for (int j = 0; j < item.imposto.Items.Length; j++)
                    {
                        if (item.imposto.Items[j].GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMS))
                        {

                            IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMS icms = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMS)item.imposto.Items[j];

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS00))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS00 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS00)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;

                            }
                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS10))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS10 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS10)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS20))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS20 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS20)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS30))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS30 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS30)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS40))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS40 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS40)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS51))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS51 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS51)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS60))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS60 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS60)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS70))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS70 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS70)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS90))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS90 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMS90)icms.Item;

                                //Busca diferimento pra colocar a aliquota ja desconsiderando o icms parcial
                                double vIcms = 0;
                                if (tmp.vICMS != null)
                                {
                                    vIcms = double.Parse(tmp.vICMS, CultureInfo.InvariantCulture);
                                }

                                double valorBC = 0;
                                if (tmp.vBC != null)
                                {
                                    valorBC = double.Parse(tmp.vBC, CultureInfo.InvariantCulture);
                                }

                                if (Math.Abs(valorBC) < Double.Epsilon)
                                {
                                    pIcms = 0;
                                }
                                else
                                {
                                    pIcms = Math.Round(vIcms / valorBC, 2, MidpointRounding.ToEven) * 100;
                                }
                                


                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSPart))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSPart tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSPart)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN101))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN101 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN101)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN102))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN102 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN102)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN201))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN201 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN201)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN202))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN202 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN202)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN500))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN500 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN500)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN900))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN900 tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSSN900)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSST))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSST tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeDetImpostoICMSICMSST)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                        }
                        else
                        {
                            if (item.imposto.Items[j].GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TIpi))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v3_10.TIpi ipi = (IWTNFCompleto.BibliotecaDatasets.v3_10.TIpi)item.imposto.Items[j];

                                if (ipi.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TIpiIPINT))
                                {
                                    IWTNFCompleto.BibliotecaDatasets.v3_10.TIpiIPINT tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TIpiIPINT)ipi.Item;
                                    pIpi = 0;
                                    continue;
                                }

                                if (ipi.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v3_10.TIpiIPITrib))
                                {
                                    IWTNFCompleto.BibliotecaDatasets.v3_10.TIpiIPITrib tmp = (IWTNFCompleto.BibliotecaDatasets.v3_10.TIpiIPITrib)ipi.Item;

                                    for (int k = 0; k < tmp.ItemsElementName.Length; k++)
                                    {
                                        if (tmp.ItemsElementName[k] == IWTNFCompleto.BibliotecaDatasets.v3_10.ItemsChoiceType.pIPI)
                                        {
                                            pIpi = double.Parse(tmp.Items[k], CultureInfo.InvariantCulture);
                                            break;
                                        }
                                    }

                                    continue;
                                }
                            }
                        }


                    }


                    double qtd = double.Parse(nf.infNFe.det[i].prod.qCom, CultureInfo.InvariantCulture);
                    double valorUnitario = double.Parse(nf.infNFe.det[i].prod.vUnCom, CultureInfo.InvariantCulture);
                    double valorTotal = double.Parse(nf.infNFe.det[i].prod.vProd, CultureInfo.InvariantCulture);

                    try
                    {
                        if (nf.infNFe.det[i].prod.vDesc != null)
                        {
                            double valorDesconto = double.Parse(nf.infNFe.det[i].prod.vDesc, CultureInfo.InvariantCulture);

                            if (valorDesconto > 0)
                            {
                                valorTotal = valorTotal - valorDesconto;
                                valorUnitario = valorTotal / qtd;
                            }
                        }
                    }
                    catch
                    {
                    }

                    string pedidoCliente = null;
                    int? posicaoPedidoCliente = null;

                    pedidoCliente = nf.infNFe.det[i].prod.xPed;
                    string tmpPosicaoPedido = nf.infNFe.det[i].prod.nItemPed;
                    if (!string.IsNullOrWhiteSpace(tmpPosicaoPedido))
                    {
                        int tmpInt;
                        if (int.TryParse(tmpPosicaoPedido, NumberStyles.Any, CultureInfo.InvariantCulture, out tmpInt))
                        {
                            posicaoPedidoCliente = tmpInt;
                        }
                        else
                        {
                            posicaoPedidoCliente = null;
                        }
                    }

                    toRet.addicionarLinha(
                        i + 1,
                        nf.infNFe.det[i].prod.cProd,
                        nf.infNFe.det[i].prod.xProd,
                        nf.infNFe.det[i].prod.NCM,
                        nf.infNFe.det[i].prod.uCom ?? nf.infNFe.det[i].prod.uTrib,
                        qtd,
                        valorUnitario,
                        valorTotal,
                        pIcms,
                        pIpi,
                        false,
                        pedidoCliente,
                        posicaoPedidoCliente);

                }

                if (nf.infNFe.cobr != null && nf.infNFe.cobr.dup != null)
                {
                    AgrupadorContaClass agrupador = new AgrupadorContaClass(_usuario, conn)
                    {
                        Data = Configurations.DataIndependenteClass.GetData()
                    };

                    foreach (IWTNFCompleto.BibliotecaDatasets.v3_10.TNFeInfNFeCobrDup dup in nf.infNFe.cobr.dup)
                    {
                        toRet.ContasPagar.Add(
                            new ContaPagarClass(_usuario, conn)
                            {
                                NotaFiscalEntrada = null,
                                Fornecedor = null,
                                CentroCustoLucro = null,
                                ContaBancaria = null,
                                NumDocumento = "NFe " + toRet.Numero,
                                DataVencimento = Convert.ToDateTime(dup.dVenc),
                                Valor = double.Parse(dup.vDup, CultureInfo.InvariantCulture),
                                Historico = "Duplicata " + dup.nDup,
                                AgrupadorConta = agrupador
                            }
                            );

                        agrupador.CollectionContaPagarClassAgrupadorConta.Add(toRet.ContasPagar.Last());

                    }
                }
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao importar o arquivo (" + arquivo + "): " + e.Message, e);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        private NFEntradaClass readXMLV4(string arquivo)
        {
            TextReader reader = null;
            try
            {
                NFEntradaClass toRet = new NFEntradaClass(null, this._usuario, this.conn);



                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe nf = null;
                try
                {
                    reader = new StreamReader(arquivo);
                    XmlSerializer serializer = new XmlSerializer(typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNfeProc));
                    IWTNFCompleto.BibliotecaDatasets.v4_0.TNfeProc xml = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNfeProc)serializer.Deserialize(reader);
                    nf = xml.NFe;
                }
                catch
                {
                    try
                    {
                        reader.Close();
                        reader = new StreamReader(arquivo);
                        XmlSerializer serializer = new XmlSerializer(typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe));
                        nf = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe)serializer.Deserialize(reader);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                }


                //Verificação se a versão é 4.00
                if (nf.infNFe.versao != "4.00")
                {
                    return null;
                }

                toRet.Numero = nf.infNFe.ide.nNF;
                toRet.Serie = nf.infNFe.ide.serie;
                toRet.dataNf = Convert.ToDateTime(nf.infNFe.ide.dhEmi);
                toRet.nomeArquivo = arquivo;

                toRet.razaoFornecedorNota = nf.infNFe.emit.xNome;
                toRet.CNPJFornecedorNota = nf.infNFe.emit.Item;

                toRet.valorTotal = double.Parse(nf.infNFe.total.ICMSTot.vNF, CultureInfo.InvariantCulture);

                toRet.ChaveNota = nf.infNFe.Id.Replace("NFe", "");



                for (int i = 0; i < nf.infNFe.det.Length; i++)
                {
                    IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet item = nf.infNFe.det[i];
                    double pIcms = 0;
                    double pIpi = 0;
                    for (int j = 0; j < item.imposto.Items.Length; j++)
                    {
                        if (item.imposto.Items[j].GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS))
                        {

                            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS icms = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS)item.imposto.Items[j];

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;

                            }
                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS60))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS60 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS60)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90)icms.Item;

                                //Busca diferimento pra colocar a aliquota ja desconsiderando o icms parcial
                                double vIcms = 0;
                                if (tmp.vICMS != null)
                                {
                                    vIcms = double.Parse(tmp.vICMS, CultureInfo.InvariantCulture);
                                }

                                double valorBC = 0;
                                if (tmp.vBC != null)
                                {
                                    valorBC = double.Parse(tmp.vBC, CultureInfo.InvariantCulture);
                                }

                                if (Math.Abs(valorBC) < Double.Epsilon)
                                {
                                    pIcms = 0;
                                }
                                else
                                {
                                    pIcms = Math.Round((vIcms / valorBC) * 100, 2, MidpointRounding.ToEven);
                                }



                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN101))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN101 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN101)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN102))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN102 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN102)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN500))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN500 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN500)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900 tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900)icms.Item;
                                pIcms = tmp.pICMS != null ? double.Parse(tmp.pICMS, CultureInfo.InvariantCulture) : 0;
                                continue;
                            }

                            if (icms.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSST))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSST tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSST)icms.Item;
                                pIcms = 0;
                                continue;
                            }

                        }
                        else
                        {
                            if (item.imposto.Items[j].GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi))
                            {
                                IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi ipi = (IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi)item.imposto.Items[j];

                                if (ipi.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPINT))
                                {
                                    IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPINT tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPINT)ipi.Item;
                                    pIpi = 0;
                                    continue;
                                }

                                if (ipi.Item.GetType() == typeof(IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib))
                                {
                                    IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib tmp = (IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib)ipi.Item;

                                    for (int k = 0; k < tmp.ItemsElementName.Length; k++)
                                    {
                                        if (tmp.ItemsElementName[k] == IWTNFCompleto.BibliotecaDatasets.v4_0.ItemsChoiceType.pIPI)
                                        {
                                            pIpi = double.Parse(tmp.Items[k], CultureInfo.InvariantCulture);
                                            break;
                                        }
                                    }

                                    continue;
                                }
                            }
                        }
                    }


                    double qtd = double.Parse(nf.infNFe.det[i].prod.qCom, CultureInfo.InvariantCulture);
                    double valorUnitario = double.Parse(nf.infNFe.det[i].prod.vUnCom, CultureInfo.InvariantCulture);
                    double valorTotal = double.Parse(nf.infNFe.det[i].prod.vProd, CultureInfo.InvariantCulture);

                    try
                    {
                        if (nf.infNFe.det[i].prod.vDesc != null)
                        {
                            double valorDesconto = double.Parse(nf.infNFe.det[i].prod.vDesc, CultureInfo.InvariantCulture);

                            if (valorDesconto > 0)
                            {
                                valorTotal = valorTotal - valorDesconto;
                                valorUnitario = valorTotal / qtd;
                            }
                        }
                    }
                    catch
                    {
                    }

                    string pedidoCliente = null;
                    int? posicaoPedidoCliente = null;

                    pedidoCliente = nf.infNFe.det[i].prod.xPed;
                    string tmpPosicaoPedido = nf.infNFe.det[i].prod.nItemPed;
                    if (!string.IsNullOrWhiteSpace(tmpPosicaoPedido))
                    {
                        int tmpInt;
                        if (int.TryParse(tmpPosicaoPedido, NumberStyles.Any, CultureInfo.InvariantCulture, out tmpInt))
                        {
                            posicaoPedidoCliente = tmpInt;
                        }
                        else
                        {
                            posicaoPedidoCliente = null;
                        }
                    }

                    toRet.addicionarLinha(
                        i + 1,
                        nf.infNFe.det[i].prod.cProd,
                        nf.infNFe.det[i].prod.xProd,
                        nf.infNFe.det[i].prod.NCM,
                        nf.infNFe.det[i].prod.uCom ?? nf.infNFe.det[i].prod.uTrib,
                        qtd,
                        valorUnitario,
                        valorTotal,
                        pIcms,
                        pIpi,
                        false,
                        pedidoCliente,
                        posicaoPedidoCliente);

                }

                if (nf.infNFe.cobr != null && nf.infNFe.cobr.dup != null)
                {
                    AgrupadorContaClass agrupador = new AgrupadorContaClass(_usuario, conn)
                    {
                        Data = Configurations.DataIndependenteClass.GetData()
                    };

                    foreach (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeCobrDup dup in nf.infNFe.cobr.dup)
                    {
                        toRet.ContasPagar.Add(
                            new ContaPagarClass(_usuario, conn)
                            {
                                NotaFiscalEntrada = null,
                                Fornecedor = null,
                                CentroCustoLucro = null,
                                ContaBancaria = null,
                                NumDocumento = "NFe " + toRet.Numero,
                                DataVencimento = Convert.ToDateTime(dup.dVenc),
                                Valor = double.Parse(dup.vDup, CultureInfo.InvariantCulture),
                                Historico = "Parcela " + dup.nDup,
                                AgrupadorConta = agrupador
                            }
                        );

                        agrupador.CollectionContaPagarClassAgrupadorConta.Add(toRet.ContasPagar.Last());
                    }
                }
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao importar o arquivo (" + arquivo + "): " + e.Message, e);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}

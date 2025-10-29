#region Referencias

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BibliotecaGerenciamentoLog;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using Ionic.Zip;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public abstract class ProcessamentoBase
    {
        public ClienteConfiguracao configuracao { get; set; }
        public IProcessaArquivoPedido processaPedido { get; set; }
        protected AcsUsuarioClass _acsUsuario { get; set; }
        protected IWTPostgreNpgsqlConnection connection { get; set; }
        protected InterfaceModulosCliente easi { get; set; }

        public ProcessamentoBase(  AcsUsuarioClass usr, IWTPostgreNpgsqlConnection con)
        {
            this._acsUsuario = usr;
            this.connection = con;
            easi = new InterfaceModulosCliente(this.connection, this._acsUsuario);
        }

        public virtual void start()
        {
            try
            {
                //Verifica se o diretorio de entrada existe
                if (!Directory.Exists(this.configuracao.getDirEntrada()))
                {
                    throw new Exception("O diretório de entrada de pedidos não existe. Diretório cadastrado: " + this.configuracao.getDirEntrada());
                }

                //Verifica se o diretório de saida existe. Se nao existe, será criado automaticamente
                string dirSaida = this.configuracao.getDirSaida() +"\\"+ Configurations.DataIndependenteClass.GetData().ToString("yyyyMMdd") + "\\";
                if (!Directory.Exists(dirSaida))
                {
                    try
                    {
                        Directory.CreateDirectory(dirSaida);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Falha ao tentar criar o diretório de pedidos processados. Diretório: " + dirSaida + ". " + e.Message);
                    }
                }

                //Obtem os pedidos rejeitados para tentar reprocessa-los                

                List<PedidoEasiRejeitado> pedidosRejeitados = easi.getPedidosPendentes(configuracao.nomeModulo, configuracao.getNomePadraoPedido());
                foreach (PedidoEasiRejeitado pedido in pedidosRejeitados)
                {
                    StreamReader memoryReader = null;
                    try
                    {
                        memoryReader = new StreamReader(new MemoryStream(pedido.Arquivo));
                        processaPedido.run(memoryReader, configuracao, pedido.nomeArquivo);

                        //Exclui o pedido dos rejeitados
                        easi.excluirPedidoRejeitado(pedido.idPedidoRejeitado);
                    }
                    catch (EasiException eEasi)
                    {
                        //Exceção lançada pelo processamento do pedido
                        GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), eEasi.Message, this.connection);

                        //Atualiza o pedido rejeitado
                        try
                        {
                            pedido.motivoRejeicao = eEasi.motivo;
                            pedido.Obs = eEasi.Message;
                            easi.atualizaPedidoRejeitado(pedido);
                        }
                        catch (Exception e)
                        {
                            GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), e.Message, this.connection);
                        }
                    }
                    catch (Exception e)
                    {
                        //Exceção lançada na abertura do Stream ou na exclusao do pedido rejeitado
                        GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), e.Message, this.connection);
                    }
                    finally
                    {
                        if (memoryReader != null)
                            memoryReader.Close();;
                    }
                }                
                
                //Processamento dos arquivos Milkruns
                
                //Busca por arquivos ZIP
                string[] files;
                try
                {
                    files = Directory.GetFiles(this.configuracao.getDirEntrada(), "*.ZIP");
                    foreach (string f in files)
                    {
                        ZipFile zipFile = new ZipFile(f);
                        zipFile.ExtractAll(this.configuracao.getDirEntrada(), ExtractExistingFileAction.OverwriteSilently); //Extrai os arquivo no diretorio de entrada para posterior processamento
                        zipFile.Dispose();
                        File.Delete(f);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Falha ao processar arquivos ZIP do diretorio de entrada. " + e.Message);
                }

            

                //Obtem os arquivos milkrun para processamento dos pedidos 
                string teste = this.configuracao.getDirEntrada();
                teste = configuracao.getNomePadraoPedido();
                files = Directory.GetFiles(this.configuracao.getDirEntrada(), configuracao.getNomePadraoPedido());
                foreach (string f in files)
                {
                    bool moverArquivo = true;
                    StreamReader fileReader = null;
                    try
                    {
                        fileReader = new StreamReader(f, Encoding.GetEncoding(1252));
                        processaPedido.run(fileReader, configuracao, f);
                    }
                    catch (EasiException eEasi) //Exceção lançada pelo processamento dos pedidos
                    {
                        GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), eEasi.motivo + " " +eEasi.Message, this.connection);
                        try
                        {
                            //Monta o pedido Rejeitado
                            PedidoEasiRejeitado pedRejeitado = new PedidoEasiRejeitado();

                            //Voltar o ponteiro do stream para o unicio
                            if (fileReader != null && fileReader.BaseStream.CanRead)
                            {
                                fileReader.DiscardBufferedData();
                                fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                                fileReader.BaseStream.Position = 0;
                            }
                            else
                            {
                                fileReader = new StreamReader(f, Encoding.GetEncoding(1252));
                            }

                            pedRejeitado.Arquivo = Encoding.GetEncoding(1252).GetBytes(fileReader.ReadToEnd());
                            pedRejeitado.moduloImportador = configuracao.nomeModulo;
                            pedRejeitado.motivoRejeicao = eEasi.motivo;
                            pedRejeitado.Obs = eEasi.Message;
                            pedRejeitado.tipoArquivo = this.configuracao.getNomePadraoPedido();

                            //Obtem o nome do arquivo
                            FileInfo info = new FileInfo(f);
                            pedRejeitado.nomeArquivo = info.Name;

                            easi.inserirPedidoRejeitado(pedRejeitado);
                        }
                        catch (Exception e)
                        {
                            //Falha ao montar ou inserir o pedido rejeitado. Não mover o arquivo do diretório de entrada
                            moverArquivo = false;
                            GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), "Falha ao armazenar o arquivo nos pedidos rejeitados. O arquivo " + f + " não foi movido do diretório de entrada." + e.Message, this.connection);
                        }                          
                    }
                    catch (Exception e) //Exceção lançada na abertura do arquivo
                    {
                        //Nao é possivel lançar o pedido rejeitado. Não mover o arquivo do diretório de entrada                        
                        moverArquivo = false;
                        GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), "Falha ao abrir o arquivode pedido. O arquivo " + f + " não foi movido do diretório de entrada." + e.Message, this.connection);
                    }
                    finally
                    {
                        if (fileReader != null)
                            fileReader.Close();
                    }

                    //Mover o arquivo para o diretorio de saida
                    try
                    {
                        if (moverArquivo) //Se false, o arquivo nao pode ser movido por ter ocorrido falha no armazenamento do pedido rejeitado
                        {
                            FileInfo info = new FileInfo(f);
                            string fileName = info.Name;                           

                            //Verifica se o arquivo já existe no diretorio de saida, caso exista, deve-se renomea-lo
                            int indice = 0;
                            while (File.Exists(dirSaida + fileName))
                            {
                                indice++;
                                fileName = info.Name.Substring(0, info.Name.Length - info.Extension.Length) + "(" + indice + ")" + info.Extension;
                            }
                            info.MoveTo(dirSaida + fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.getDescricaoModulo(), "Falha ao mover arquivo para o diretorio de pedidos processados. Arquivo: " + f + ". " + ex.Message, this.connection);
                    }
                }
            }
            catch (Exception exGeral)
            {
                GerenciamentoLog.InserirLog(TipoLog.Erro, this._acsUsuario.Login, configuracao.nomeModulo, exGeral.Message, this.connection);
            }
        }

    }
}

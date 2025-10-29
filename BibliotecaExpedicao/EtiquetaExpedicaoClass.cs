#region Referencias

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;

#endregion

namespace BibliotecaExpedicao
{
    public enum TipoEtiquetaExpedicao{Grande,Media,Pequena}
    public class EtiquetaExpedicaoClass
    {
        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        private string pedidoNumero;
        private int pedidoPosicao;

        public string PedidoNumero
        {
            get { return this.pedidoNumero+"/"+this.pedidoPosicao; }
           
        }


        private string itemCodigo;

        public string ItemCodigo
        {
            get { return itemCodigo; }
            set { itemCodigo = value; }
        }


        private string itemDescricao;

        public string ItemDescricao
        {
            get { return itemDescricao; }
            set { itemDescricao = value; }
        }


        private double itemQuantidade;

        public double ItemQuantidade
        {
            get { return itemQuantidade; }
            set { itemQuantidade = value; }
        }

        public string ItemQuantidadeString
        {
            get
            {
                return this.ItemQuantidade.ToString("F2", CultureInfo.CurrentCulture);
            }

        }


        private string pedidoProjeto;

        public string PedidoProjeto
        {
            get { return pedidoProjeto; }
            set { pedidoProjeto = value; }
        }


        private string pedidoArmazenagem;

        public string PedidoArmazenagem
        {
            get { return pedidoArmazenagem; }
            set { pedidoArmazenagem = value; }
        }


        private int volume;

        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }


        private int volumeTotal;

        public int VolumeTotal
        {
            get { return volumeTotal; }
            set { volumeTotal = value; }
        }


        private double pesoTotal;

        public double PesoTotal
        {
            get { return pesoTotal; }
            set { pesoTotal = value; }
        }

        public string PesoTotalString
        {
            get
            {
                return this.PesoTotal.ToString("F2", CultureInfo.CurrentCulture);
            }

        }


        private string cubagem;

        public string Cubagem
        {
            get { return cubagem; }
            set { cubagem = value; }
        }


        private string fornecedor;

        public string Fornecedor
        {
            get { return fornecedor; }
            set { fornecedor = value; }
        }


        private byte[] fornecedorLogo;

        public byte[] FornecedorLogo
        {
            get { return fornecedorLogo; }
            set
            {
                if (value != null)
                {
                    byte[] tmp = new byte[value.Length];

                    for (int i = 0; i < value.Length; i++)
                    {
                        tmp[i] = value[i];
                    }

                    MemoryStream ms = new MemoryStream(tmp);
                    MemoryStream mOut = new MemoryStream();

                    Image imagem = Image.FromStream(ms);
                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 90, 90, false);
                    if (this.TipoEtiqueta == TipoEtiquetaExpedicao.Grande)
                    {
                        imagem.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    imagem.Save(mOut, ImageFormat.Bmp);
                    this.fornecedorLogo = mOut.ToArray();


                    /*string caminhoImagem = @"C:\\Teste.bmp";
                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);
                    imagem.Save(caminhoImagem);
                    FileStream fs = new FileStream(caminhoImagem, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    Bitmap codeBar = new Bitmap(caminhoImagem);
                    codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    codeBar.Save(caminhoImagem);

                    fs = new FileStream(caminhoImagem, FileMode.Open);
                    br = new BinaryReader(fs);
                    array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    this.fornecedorLogo = array;
                    */
                    /*
                     
                        FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] array = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();

                        Bitmap codeBar = new Bitmap(@tempDir + "\\code.bmp");
                        codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        codeBar.Save(@tempDir + "\\code.bmp");

                        fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                        br = new BinaryReader(fs);
                        array = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                       
                     
                     */





                }
            }
        }

        private string pedidoBarcodeString = null;

        public string PedidoBarcodeString
        {
            get
            {

                if (this.pedidoBarcodeString == null)
                {
                    this.loadBarcode();
                }
                return pedidoBarcodeString;
            }
        }


        private byte[] pedidoBarcode = null;

        public byte[] PedidoBarcode
        {
            get
            {
                if (this.pedidoBarcode == null)
                {
                    this.loadBarcode();
                }

                return this.pedidoBarcode;

            }
        }

        private string usuarioImpressao;

        public string UsuarioImpressao
        {
            get { return usuarioImpressao; }
            set { usuarioImpressao = value; }
        }


        private bool reimpressao;

        public bool Reimpressao
        {
            get { return reimpressao; }
            set { reimpressao = value; }
        }

        private string pallet;

        public string Pallet
        {
            get { return pallet; }
            set { pallet = value; }
        }

        private string sequencial;
        private long IdOrderItemEtiqueta;

        public string Sequencial
        {
            get { return sequencial; }
            set { sequencial = value; }
        }

        private long IdOrderItemEtiquetaConferenciaVolume;

        public string EnderecoEntrega { get; set; }


        public TipoEtiquetaExpedicao TipoEtiqueta { get; private set; }

        public EtiquetaExpedicaoClass(
            string Cliente, string Cubagem, string Fornecedor, byte[] FornecedorLogo, string ItemCodigo, string ItemDescricao,
            double ItemQuantidade, string PedidoArmazenagem, string pedidoNumero, int pedidoPosicao, string PedidoProjeto, double PesoTotal,
            int Volume, int VolumeTotal, string UsuarioImpressao, string Pallet, bool Reimpressao, TipoEtiquetaExpedicao tipoEtiqueta, long idOrderItemEtiqueta,
           string enderecoEntrega, long idOrderItemEtiquetaConferenciaVolume)
        {

            this.initClass(
                Cliente, Cubagem, Fornecedor, FornecedorLogo, ItemCodigo, ItemDescricao,
                ItemQuantidade, PedidoArmazenagem, pedidoNumero, pedidoPosicao, PedidoProjeto, PesoTotal,
                Volume, VolumeTotal, UsuarioImpressao, Pallet, Reimpressao, false,tipoEtiqueta, idOrderItemEtiqueta,
                enderecoEntrega,
                idOrderItemEtiquetaConferenciaVolume
                );
        }

        private EtiquetaExpedicaoClass(
            string Cliente, string Cubagem, string Fornecedor, byte[] FornecedorLogo, string ItemCodigo, string ItemDescricao,
            double ItemQuantidade, string PedidoArmazenagem, string pedidoNumero, int pedidoPosicao, string PedidoProjeto, double PesoTotal,
            int Volume, int VolumeTotal, string UsuarioImpressao, string Pallet, bool Reimpressao, bool Copia, TipoEtiquetaExpedicao tipoEtiqueta, long idOrderItemEtiqueta,string enderecoEntrega,
            long idOrderItemEtiquetaConferenciaVolume)
        {
            IdOrderItemEtiqueta = idOrderItemEtiqueta;
            this.initClass(
                Cliente, Cubagem, Fornecedor, FornecedorLogo, ItemCodigo, ItemDescricao,
                ItemQuantidade, PedidoArmazenagem, pedidoNumero, pedidoPosicao, PedidoProjeto, PesoTotal,
                Volume, VolumeTotal, UsuarioImpressao, Pallet, Reimpressao, Copia, tipoEtiqueta, idOrderItemEtiqueta, enderecoEntrega,
                idOrderItemEtiquetaConferenciaVolume);
        }


        private void initClass(string Cliente, string Cubagem, string Fornecedor, byte[] FornecedorLogo, string ItemCodigo, string ItemDescricao, double ItemQuantidade, string PedidoArmazenagem, string pedidoNumero, int pedidoPosicao, string PedidoProjeto, double PesoTotal, int Volume, int VolumeTotal, string UsuarioImpressao, string Pallet, bool Reimpressao, bool Copia, TipoEtiquetaExpedicao tipoEtiqueta, long idOrderItemEtiqueta, string enderecoEntrega, long idOrderItemEtiquetaConferenciaVolume)
        {
            this.TipoEtiqueta = tipoEtiqueta;

            this.Cliente = Cliente;
            this.Cubagem = Cubagem;
            this.Fornecedor = Fornecedor;
            this.ItemCodigo = ItemCodigo;
            this.ItemDescricao = ItemDescricao;
            this.ItemQuantidade = ItemQuantidade;
            this.PedidoArmazenagem = PedidoArmazenagem;
            this.pedidoNumero = pedidoNumero;
            this.pedidoPosicao = pedidoPosicao;
            this.PedidoProjeto = PedidoProjeto;
            this.PesoTotal = PesoTotal;
            this.Volume = Volume;
            this.VolumeTotal = VolumeTotal;
            this.UsuarioImpressao = UsuarioImpressao;
            this.Reimpressao = Reimpressao;
            this.Pallet = Pallet;
            this.IdOrderItemEtiqueta = idOrderItemEtiqueta;
            this.IdOrderItemEtiquetaConferenciaVolume = idOrderItemEtiquetaConferenciaVolume;
            this.EnderecoEntrega = enderecoEntrega;

            if (Copia)
            {
                this.fornecedorLogo = FornecedorLogo;
            }
            else
            {
                this.FornecedorLogo = FornecedorLogo;
            }
        }

        private void loadBarcode()
        {
            try
            {

                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                //this.pedidoBarcodeString = "K" + this.pedidoNumero.Replace(' ', ';') +
                //                           this.pedidoPosicao.PadLeft(3, '0') + this.Volume.ToString().PadLeft(2, '0') +
                //                           this.VolumeTotal.ToString().PadLeft(2, '0');

                //this.pedidoBarcodeString = "EX_" + this.IdOrderItemEtiqueta + "_" + this.Volume.ToString().PadLeft(2, '0') + "_" + this.VolumeTotal.ToString().PadLeft(2, '0');
                this.pedidoBarcodeString = "EXCV_" + this.IdOrderItemEtiquetaConferenciaVolume;

                process.StartInfo.Arguments = this.pedidoBarcodeString + " " + tempDir + "\\code.bmp";
                process.Start();
                process.WaitForExit();

                FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Byte[] array = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                if (this.TipoEtiqueta == TipoEtiquetaExpedicao.Grande)
                {
                    Bitmap codeBar = new Bitmap(@tempDir + "\\code.bmp");
                    codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    codeBar.Save(@tempDir + "\\code.bmp");
                }

                fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                br = new BinaryReader(fs);
                array = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                this.pedidoBarcode = array;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o código de barras.\r\n" + e.Message, e);
            }
        }


        public EtiquetaExpedicaoClass Clone()
        {
            return new EtiquetaExpedicaoClass(
                this.cliente,
                this.cubagem,
                this.fornecedor,
                this.fornecedorLogo,
                this.itemCodigo,
                this.itemDescricao,
                this.itemQuantidade,
                this.pedidoArmazenagem,
                this.pedidoNumero,
                this.pedidoPosicao,
                this.pedidoProjeto,
                this.pesoTotal,
                this.volume,
                this.volumeTotal,
                this.usuarioImpressao,
                this.pallet,
                this.reimpressao,
                true,
                this.TipoEtiqueta,
                IdOrderItemEtiqueta,
                EnderecoEntrega,
                this.IdOrderItemEtiquetaConferenciaVolume);
        }

    }
}

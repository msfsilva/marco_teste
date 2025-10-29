using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class FomularioRetiradaManualEstoqueClass : FomularioRetiradaManualEstoqueBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do FomularioRetiradaManualEstoqueClass";
        protected new const string ErroDelete = "Erro ao excluir o FomularioRetiradaManualEstoqueClass  ";
        protected new const string ErroSave = "Erro ao salvar o FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroEstoqueGavetaObrigatorio = "O campo EstoqueGaveta é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do FomularioRetiradaManualEstoqueClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade FomularioRetiradaManualEstoqueClass está sendo utilizada.";

        #endregion

        [UnCloneable(UnCloneableAttributeType.RetPadrao)]
        public bool Retirado
        {
            get { return this.DataRetirada.HasValue; }
        }

        public FomularioRetiradaManualEstoqueClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        protected override void InitClass()
        {
            base.InitClass();

            if (this.ID != -1) return;

            this.AcsUsuarioAbertura = UsuarioAtual;
            this.DataAbertura = Configurations.DataIndependenteClass.GetData();
        }

    

        #region Barcode

        private string _codigoBarrasString
        {
            get { return "FME" + this.ID.ToString(); }
        }

        private byte[] _codigoBarras;
        public byte[] CodigoBarras
        {
            get
            {
                if (this._codigoBarras == null)
                {
                    this.loadCodigoBarras();
                }
                return this._codigoBarras;
            }

        }

        private void loadCodigoBarras()
        {
            try
            {
                if (this.ID == -1)
                {
                    return;
                }

                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                process.StartInfo.Arguments =_codigoBarrasString + " " + tempDir + "\\code.bmp";

                process.Start();
                process.WaitForExit();

                FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                this._codigoBarras = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o código de barras.\r\n" + e.Message, e);
            }
        }

        public static FomularioRetiradaManualEstoqueClass GetByBarcode(string barcode, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                if (!barcode.StartsWith("FME"))
                {
                    throw new ExcecaoTratada("Código de barras inválido");
                }

                int id = int.Parse(barcode.Substring(3));
                return GetEntidade(id, usuario, conn);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar o formulário pelo código de barras\r\n" + e.Message, e);
            }


        }

        #endregion


        public void SetRetirado()
        {
            try
            {
                if (this.Retirado)
                {
                    throw new Exception("O produto/material desse formulário já foi retirado do estoque.");
                }

                this.DataRetirada = Configurations.DataIndependenteClass.GetData();
                this.AcsUsuarioRetirada = UsuarioAtual;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir o formulário como retirado.\r\n" + e.Message, e);
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {

            if (this.Produto == null && this.Epi == null && this.Material == null)
            {
                throw new ExcecaoTratada("Não é possível salvar um formulário sem nenhum conteúdo.");
            }

            if (string.IsNullOrWhiteSpace(Observacao) || Observacao.Length < 5)
            {
                throw new ExcecaoTratada("O campo de observação deve ter ao menos 5 caracteres");
            }

            if (Math.Abs(Quantidade) < 0.00001)
            {
                throw new ExcecaoTratada("A quantidade movimentada não pode ser zero");
            }

            return true;
        }

        
        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
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

      
    }
}

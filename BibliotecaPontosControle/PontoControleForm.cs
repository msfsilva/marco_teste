#region Referencias

using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.OrdemProducao;

using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaPontosControle
{
    public partial class PontoControleForm : IWTBaseForm
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        PontoControleClass pontoControle;
        OrdemProducaoClass ultimaOrdemProducao = null;
        readonly AcsUsuarioClass Usuario;
        IOrdemProducaoFactory iOrdemProducaoFactory;
        private IObservacaoCustomizada _observacaoCustomizada;

        public PontoControleForm(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario, IOrdemProducaoFactory iOrdemProducaoFactory, IObservacaoCustomizada observacaoCustomizada)
        {
            _observacaoCustomizada = observacaoCustomizada;
            try
            {
                InitializeComponent();
                this.conn = conn;
                this.Usuario = Usuario;
                this.iOrdemProducaoFactory = iOrdemProducaoFactory;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

#if DEBUG
            this.txtPostoTrabalho.DebugMode = true;
            this.txtOrdemProducao.DebugMode = true;

#endif
        }

        //modos
        //0: Inicial
        //1: Usuário Selecionado - Selecionando Posto
        //2: Posto Selecionado - Selecionando OP
        //3: OP Selecionado - Exige Qtd
        //4: OP Selecionado - Não Exige Qtd
        private void setScreenMode(int mode)
        {
            switch (mode)
            {
                //0: Inicial
                case 0:
                    this.txtUsuario.Enabled = true;
                    this.txtPostoTrabalho.Enabled = false;
                    this.txtOrdemProducao.Enabled = false;
                    this.nudQuantidade.Enabled = false;
                    this.rdbNormal.Enabled = true;
                    this.rdbSuspender.Enabled = true;
                    this.rdbTrocarOperador.Enabled = true;

                    this.rdbNormal.Checked = true;
                    this.txtUsuario.Clear();
                    this.txtPostoTrabalho.Clear();
                    this.txtOrdemProducao.Clear();
                    this.lblPosto.Text = "";
                    this.lblOp.Text = "";
                                                
                    this.txtUsuario.Focus();
                    break;
                //1: Usuário Selecionado - Selecionando Posto
                case 1:
                    this.txtUsuario.Enabled = false;
                    this.txtPostoTrabalho.Enabled = true;
                    this.txtOrdemProducao.Enabled = false;
                    this.grbHistoricoOP.Enabled = false;
                    this.nudQuantidade.Enabled = false;
                    this.rdbNormal.Enabled = true;
                    this.rdbSuspender.Enabled = true;
                    this.rdbTrocarOperador.Enabled = true;

                  
                    this.lblUsuario.Text = this.pontoControle.usuario.Login;
                  

                    this.txtPostoTrabalho.Clear();
                    this.txtOrdemProducao.Clear();

                    this.lblPosto.Text = "";
                    this.lblOp.Text = "";
                    this.txtPostoTrabalho.Focus();
                    break;
                //2: Posto Selecionado - Selecionando OP
                case 2:
                    this.txtUsuario.Enabled = false;
                    this.txtPostoTrabalho.Enabled = false;
                    this.txtOrdemProducao.Enabled = true;
                    this.grbHistoricoOP.Enabled = false;
                    this.nudQuantidade.Enabled = false;
                    this.rdbNormal.Enabled = true;
                    this.rdbSuspender.Enabled = true;
                    this.rdbTrocarOperador.Enabled = true;

                    this.lblPosto.Text = this.pontoControle.PostoTrabalhoSelecionado;
                    this.lblOp.Text = "";
                    

                    this.txtOrdemProducao.Clear();

                    this.txtOrdemProducao.Focus();

                    break;
                //3: OP Selecionado - Exige Qtd
                case 3:
                    this.txtUsuario.Enabled = false;
                    this.txtPostoTrabalho.Enabled = false;
                    this.txtOrdemProducao.Enabled = false;
                    this.nudQuantidade.Enabled = true;
                    this.rdbNormal.Enabled = false;
                    this.rdbSuspender.Enabled = false;
                    this.rdbTrocarOperador.Enabled = false;
                    this.grbHistoricoOP.Enabled = true;
                    this.lblOp.Text = this.ultimaOrdemProducao.idOrdemProducao.ToString();
                   
                    this.nudQuantidade.Focus();

                    break;
                //4: OP Selecionado - Não Exige Qtd
                case 4:
                    this.txtUsuario.Enabled = false;
                    this.txtPostoTrabalho.Enabled = false;
                    this.txtOrdemProducao.Enabled = false;
                    this.grbHistoricoOP.Enabled = true;
                    this.nudQuantidade.Enabled = false;

                    this.rdbNormal.Enabled = true;
                    this.rdbSuspender.Enabled = true;
                    this.rdbTrocarOperador.Enabled = true;
                    this.lblOp.Text = this.ultimaOrdemProducao.idOrdemProducao.ToString();

                    this.btnSalvar.Focus();
                    break;
                default:
                    throw new Exception("Modo inválido: " + mode);
            }
        }

        private void Limpar(bool  force)
        {
            try
            {
                this.lblTextoTempo.Text = "";
                if (force)
                {
                    this.pontoControle = new PontoControleClass(this.conn, _observacaoCustomizada);
                    this.ultimaOrdemProducao = null;
                    this.lblTextoTempo.Text = "";
                    this.lblPosto.Text = "";
                    this.lblOp.Text = "";
                    this.grbHistoricoOP.Text = "Histórico OP";
                    this.lstHistoricoOp.DataSource = new List<string>();
                    if (this.Usuario == null)
                    {
                        this.setScreenMode(0);
                    }
                    else
                    {
                        this.pontoControle.setUsuario(this.Usuario);
                        this.setScreenMode(1);
                    }
                    return;
                }

                if (this.ultimaOrdemProducao != null)
                {
                    this.lstHistoricoOp.DataSource = this.ultimaOrdemProducao.getHistoricoPostos();
                }

                if (this.pontoControle != null)
                {
                    if (this.pontoControle.conferenciaSequencial)
                    {
                        this.setScreenMode(2);
                    }
                    else
                    {
                        this.pontoControle = new PontoControleClass(this.conn, _observacaoCustomizada);
                        this.ultimaOrdemProducao = null;
                        this.lblTextoTempo.Text = "";
                        if (this.Usuario == null)
                        {
                            this.setScreenMode(0);
                        }
                        else
                        {
                            this.pontoControle.setUsuario(this.Usuario);
                            this.setScreenMode(1);
                        }
                    }
                }
                else
                {
                    this.pontoControle = new PontoControleClass(this.conn, _observacaoCustomizada);
                    this.ultimaOrdemProducao = null;
                    this.lblTextoTempo.Text = "";
                    if (this.Usuario == null)
                    {
                        this.setScreenMode(0);
                    }
                    else
                    {
                        this.pontoControle.setUsuario(this.Usuario);
                        this.setScreenMode(1);
                    }
                }

                this.rdbNormal.Checked = true;
                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao limpar a tela.\r\n" + e.Message);
            }
        }

        private void Salvar()
        {
            try
            {
                if (ultimaOrdemProducao == null)
                {
                    throw new Exception("É necessário selecionar uma OP antes de salvar.");
                }

                double? qtd = null;
                if (nudQuantidade.Enabled)
                {
                    qtd = (double?)nudQuantidade.Value;
                }

                if (this.rdbSuspender.Checked)
                {
                    pontoControle.Suspender(this.ultimaOrdemProducao, (double)qtd);
                }

                if (this.rdbTrocarOperador.Checked)
                {
                    pontoControle.trocarOperador(this.ultimaOrdemProducao, (double)qtd);
                }

                if (this.rdbNormal.Checked)
                {
                    pontoControle.marcarTempoPosto(this.ultimaOrdemProducao, qtd);
                }

                MessageBoxEx.Show(this, "Controle salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information,2000);
                this.Limpar(false);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message);
            }
        }

        private void opSelected(string valor)
        {
            try
            {
                bool exigeRastreamentoMateriais;
                bool somenteAbrirProducao = false;
                

                string barcode = valor.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');
                if (barcode.Length == 0)
                {
                    throw new Exception("Código de barras de OP inválido");
                }

                string[] tmp = barcode.Split(new char[] { '|' });
                if (tmp.Length == 2 && tmp[0] == "OP")
                {
                    this.ultimaOrdemProducao = this.iOrdemProducaoFactory.getInstanceOp( 
                        Convert.ToInt32(tmp[1]),
                        null,
                        this.pontoControle.usuario,
                        this.conn
                        );
                }
                else
                {
                    throw new Exception("Código de barras de OP inválido");
                }

                if (rdbNormal.Checked)
                {
                    string textoTempo;
                    double qtdRecebida;
                    List<string> historicoPostos;
                    int exigeQtd = pontoControle.exigeQuantidade(ultimaOrdemProducao, out textoTempo, out qtdRecebida, out exigeRastreamentoMateriais,out somenteAbrirProducao,out historicoPostos);
                    this.lstHistoricoOp.DataSource = historicoPostos;
                    this.grbHistoricoOP.Text = "Histórico OP " + this.ultimaOrdemProducao.idOrdemProducao;

                    if (exigeRastreamentoMateriais)
                    {
                        //CHAMADA TELA DE LEITURA DE MATERIAIS
                        PontoControleLoteMateriaForm form = new PontoControleLoteMateriaForm(this.Usuario, this.conn);
                        
                        form.ShowDialog();
                        this.pontoControle.lotesMP = form.Lotes;

                    }

                    if (somenteAbrirProducao)
                    {
                        this.pontoControle.abrirProducao(ultimaOrdemProducao, this.Usuario);
                        MessageBoxEx.Show(this, "Controle salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, 2000);
                        this.Limpar(false);
                    }
                    else
                    {
                        this.lblTextoTempo.Text = textoTempo;
                        if (exigeQtd == 0)
                        {
                            this.setScreenMode(4);
                            this.Salvar();
                        }

                        if (exigeQtd == 1)
                        {
                            this.lblQuantidade.Text = "Quantidade Recebida";
                            this.nudQuantidade.Value = (decimal)qtdRecebida;
                            this.setScreenMode(3);
                        }

                        if (exigeQtd == 2)
                        {
                            this.lblQuantidade.Text = "Quantidade de Saída";
                            this.nudQuantidade.Value = (decimal)qtdRecebida;
                            this.setScreenMode(3);
                        }
                    }
                }

                if (rdbSuspender.Checked || rdbTrocarOperador.Checked)
                {
                    string textoTempo;
                    double qtdRecebida;
                    List<string> historicoPostos;
                    int exigeQtd = pontoControle.exigeQuantidade(ultimaOrdemProducao, out textoTempo, out qtdRecebida, out exigeRastreamentoMateriais, out somenteAbrirProducao, out historicoPostos);
                    this.lstHistoricoOp.DataSource = historicoPostos;
                    this.grbHistoricoOP.Text = "Histórico OP " + this.ultimaOrdemProducao.idOrdemProducao;

                    if (exigeRastreamentoMateriais)
                    {
                        //CHAMADA TELA DE LEITURA DE MATERIAIS
                        PontoControleLoteMateriaForm form = new PontoControleLoteMateriaForm(this.Usuario, this.conn);

                        form.ShowDialog();
                        this.pontoControle.lotesMP = form.Lotes;
                    }

                    if (somenteAbrirProducao)
                    {
                        this.pontoControle.abrirProducao(ultimaOrdemProducao, this.Usuario);
                        MessageBoxEx.Show(this, "Controle salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, 2000);
                        this.Limpar(false);
                    }
                    else
                    {

                        this.lblQuantidade.Text = "Quantidade Produzida";
                        this.nudQuantidade.Value = (decimal)qtdRecebida;
                        this.setScreenMode(3);
                    }
                }

                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\certo.wav");
                simpleSound.Play();

            }
            catch (Exception e)
            {
                this.setScreenMode(2);

                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\errado.wav");
                simpleSound.Play();

                throw new Exception("Erro ao selecionar a OP.\r\n" + e.Message);
            }
        }

        private void postoSelected(string valor)
        {
            try
            {
           
                string barcode = valor.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');
                if (barcode.Length == 0)
                {
                    throw new Exception("Código de barras de posto de trabalho inválido");
                }

                string[] tmp = barcode.Split(new char[] { '|' });
                if (tmp.Length == 2 && tmp[0] == "IDPT")
                {
                    this.pontoControle.setPostoTrabalho(Convert.ToInt32(tmp[1]));
                }
                else
                {
                    throw new Exception("Código de barras de posto de trabalho inválido");
                }

                this.setScreenMode(2);

                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\certo.wav");
                simpleSound.Play();
            }
            catch (Exception e)
            {
                this.setScreenMode(1);

                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\errado.wav");
                simpleSound.Play();

                throw new Exception("Erro ao selecionar o Posto.\r\n" + e.Message);
            }
        }

        private void usuarioSelected(string valor)
        {
            try
            {
                
                string barcode = valor.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');
                if (barcode.Length==0)
                {
                    throw new Exception("Código de barras de usuário inválido");
                }

                string[] tmp = barcode.Split(new char[] { '|' });
                if (tmp.Length == 2 && tmp[0] == "IDUP")
                {
                    this.pontoControle.setUsuario(Convert.ToInt32(tmp[1]));
                }
                else
                {
                    throw new Exception("Código de barras de usuário inválido");
                }

                this.setScreenMode(1);

                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\certo.wav");
                simpleSound.Play();
            }
            catch (Exception e)
            {
                this.setScreenMode(0);

                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\errado.wav");
                simpleSound.Play();

                throw new Exception("Erro ao selecionar o Usuário.\r\n" + e.Message);
            }
        }

        #region Eventos

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Limpar(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void timerRelogio_Tick(object sender, EventArgs e)
        {
            lblRelogio.Text = Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy - HH:mm:ss");
        }


      
        private void PontoControleForm_Load(object sender, EventArgs e)
        {
            try
            {
                pontoControle = new PontoControleClass(this.conn, _observacaoCustomizada);
                if (this.Usuario == null)
                {
                    this.setScreenMode(0);
                }
                else
                {
                    this.pontoControle.setUsuario(this.Usuario);
                    this.setScreenMode(1);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion

        private void txtUsuario_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                usuarioSelected(valor);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtPostoTrabalho_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                postoSelected(valor);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtOrdemProducao_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                opSelected(valor);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}

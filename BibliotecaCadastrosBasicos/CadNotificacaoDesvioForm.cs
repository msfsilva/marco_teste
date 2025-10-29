using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadNotificacaoDesvioForm : IWTForm
    {
        byte[] _novoDocumentoScaneado = null;
        string _novoDocumentoScaneadoNome = null;

        byte[] _novoDocumentoNf = null;
        string _novoDocumentoNfNome = null;

        byte[] _novoDocumentoPlano = null;
        string _novoDocumentoPlanoNome = null;

        public CadNotificacaoDesvioForm(NotificacaoDesvioClass notificacaoDesvio, CadNotificacaoDesvioListForm listForm)
            : base(notificacaoDesvio, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.ensPedido.forceDisable();

            this.ensCliente.FormSelecao = new CadClienteListForm(TipoModulo.Tipo);

            this.loadComboPostosTrabalho();
            this.loadComboTipoDefeito();
            this.loadComboTipoND();


        }




       public CadNotificacaoDesvioForm(NotificacaoDesvioClass notificacaoDesvio)
           : base(notificacaoDesvio, typeof(NotificacaoDesvioClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            this.ensPedido.forceDisable();

            this.loadComboPostosTrabalho();
            this.loadComboTipoDefeito();
            this.loadComboTipoND();

        }

        private void loadComboPedidos()
        {
            
            try
            {
                
                if (this.ensCliente.EntidadeSelecionada == null)
                {
                    this.ensPedido.forceDisable();
                    return;
                }


                this.ensPedido.FormSelecao = new CadPedidoItemListForm(TipoModulo.Tipo, cliente:(ClienteClass) this.ensCliente.EntidadeSelecionada, somentePais: true);
                string idCliente = this.ensCliente.EntidadeSelecionada.ID.ToString();

                this.ensPedido.removeForceDisable();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Pedido.\r\n" + e.Message);
            }
             
        }

        private void loadComboTipoND()
        {
            try
            {
                TipoNotificacaoDesvioClass tipoNotificacao = new TipoNotificacaoDesvioClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<TipoNotificacaoDesvioClass> tipoNotificacaoList =
                    tipoNotificacao.Search(new List<SearchParameterClass>() { new SearchParameterClass("tnd_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (TipoNotificacaoDesvioClass)a);


                this.cmbTipoND.DataSource = tipoNotificacaoList;
                this.cmbTipoND.DisplayMember = "Identificacao";
                this.cmbTipoND.ValueMember = "ID";
                this.cmbTipoND.autoSize = true;
                this.cmbTipoND.Table = tipoNotificacaoList;
                this.cmbTipoND.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbTipoND.HeadersToDisplay = new[] { "Identificação", "Descrição" };
                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Tipo da ND.\r\n" + e.Message);
            }
        }

        private void loadComboTipoDefeito()
        {

            try
            {
                TipoDefeitoClass tipoDefeito = new TipoDefeitoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<TipoDefeitoClass> tipoDefeitoList =
                    tipoDefeito.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("tde_identificacao", null,
                                                                          SearchOperacao.SomenteOrdenacao,
                                                                          SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).ConvertAll(
                                                 a => (TipoDefeitoClass)a);


                this.cmbTipoDefeito.DataSource = tipoDefeitoList;
                this.cmbTipoDefeito.DisplayMember = "Identificacao";
                this.cmbTipoDefeito.ValueMember = "ID";
                this.cmbTipoDefeito.autoSize = true;
                this.cmbTipoDefeito.Table = tipoDefeitoList;
                this.cmbTipoDefeito.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbTipoDefeito.HeadersToDisplay = new[] { "Identificação", "Descrição" };



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Tipo do Defeito.\r\n" + e.Message);
            }
        }

        private void loadComboPostosTrabalho()
        {
            try
            {
                PostoTrabalhoClass postoTrabalho = new PostoTrabalhoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<PostoTrabalhoClass> postoTrabalhoList =
                    postoTrabalho.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("pos_codigo", null,
                                                                          SearchOperacao.SomenteOrdenacao,
                                                                          SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).ConvertAll(
                                                 a => (PostoTrabalhoClass)a);


                this.cmbPosto.DataSource = postoTrabalhoList;
                this.cmbPosto.DisplayMember = "Codigo";
                this.cmbPosto.ValueMember = "ID";
                this.cmbPosto.autoSize = true;
                this.cmbPosto.Table = postoTrabalhoList;
                this.cmbPosto.ColumnsToDisplay = new[] { "Codigo", "Nome", "Operacao" };
                this.cmbPosto.HeadersToDisplay = new[] { "Código", "Nome", "Operação" };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Posto.\r\n" + e.Message);
            }
        }

       protected override void OnShown(EventArgs e)
       {
           base.OnShown(e);

           if (((NotificacaoDesvioClass) this.Entity).Cliente != null)
           {
               this.ensCliente.EntidadeSelecionada = ((NotificacaoDesvioClass) this.Entity).Cliente;
           }

           this.loadComboPedidos();
           this._novoDocumentoScaneado = ((NotificacaoDesvioClass)this.Entity).Documento;
           this._novoDocumentoScaneadoNome = ((NotificacaoDesvioClass)this.Entity).DocumentoNome;
           if (((NotificacaoDesvioClass)this.Entity).PedidoItem != null)
           {
               this.ensPedido.EntidadeSelecionada = ((NotificacaoDesvioClass) this.Entity).PedidoItem;
           }
           else
           {
               this.ensPedido.EntidadeSelecionada = null;
           }

       }
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
           try
           {
                string nomeDoc;
                byte[] doc;
                this.SelecioneDocumento(out nomeDoc, out doc);

                this._novoDocumentoScaneadoNome = nomeDoc;
                this._novoDocumentoScaneado = doc;


                ((NotificacaoDesvioClass)this.Entity).Documento = this._novoDocumentoScaneado;
                ((NotificacaoDesvioClass)this.Entity).DocumentoNome = this._novoDocumentoScaneadoNome;

                this.lnkDocumento.Text = "Baixar: " + _novoDocumentoScaneadoNome;
                this.lnkDocumento.Visible = true;
           }
           catch (ExcecaoTratada a)
           {
               MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
           catch (Exception a)
           {
               MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
             
        }
        


        private void SelecioneDocumento(out string nomeDocumento, out byte[] doc)
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                nomeDocumento = null;
                doc = null;

                if (this.ofdDocumento.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(this.ofdDocumento.FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    if (fs.Length > 10485760)
                    {
                        throw new Exception("O arquivo deve possuir menos de 10Mb"); 
                    }

                    doc = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    nomeDocumento = new FileInfo(this.ofdDocumento.FileName).Name;
                }

              
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o documento escaneado.\r\n" + e.Message, e);
            }
            finally
            {
                if (br != null)
                {
                    br.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }

            }


        }

        private void DownloadDocumento(string nomeDocumento, byte[] doc)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {

                if (string.IsNullOrEmpty(nomeDocumento))
                {
                    return;
                }

                string tempDir = Environment.GetEnvironmentVariable("temp");
                if (tempDir != null)
                {
                    string nome = nomeDocumento;
                    byte[] documento = doc;

                    
                    fs = new FileStream(tempDir + "\\" + nome, FileMode.Create);
                    bw = new BinaryWriter(fs);
                    bw.Write(documento);

                    Process.Start(tempDir + "\\" + nome);

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o documento escaneado\r\n" + e.Message, e);
            }
            finally
            {
                if (bw != null)
                {
                    bw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }

            }
        }

        private void cbxPosto_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbPosto.Enabled = this.cbxPosto.Checked;
        }

        private void cbxDataNf_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDataNf.Enabled = this.cbxDataNf.Checked;
        }

        private void cbxValorNf_CheckedChanged(object sender, EventArgs e)
        {
            this.nudValorNf.Enabled = this.cbxValorNf.Checked;
        }

    

   

        private void lnkDocumento_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.DownloadDocumento(
                    this._novoDocumentoScaneadoNome ?? ((NotificacaoDesvioClass)this.Entity).DocumentoNome,
                    this._novoDocumentoScaneado ?? ((NotificacaoDesvioClass)this.Entity).Documento
                );
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void ensCliente_EntityChange(object sender, EventArgs e)
        {
            this.loadComboPedidos();
        }

        private void lnkNfDevolucao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.DownloadDocumento(
                    this._novoDocumentoNfNome ?? ((NotificacaoDesvioClass)this.Entity).NfDevolucaoDocumentoNome,
                    this._novoDocumentoNf ?? ((NotificacaoDesvioClass)this.Entity).NfDevolucaoDocumento
                );
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkPlanoAcao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.DownloadDocumento(
                    this._novoDocumentoPlanoNome ?? ((NotificacaoDesvioClass)this.Entity).PlanoAcaoDocumentoNome,
                    this._novoDocumentoPlano ?? ((NotificacaoDesvioClass)this.Entity).PlanoAcaoDocumento
                );
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionarNfDevolucao_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeDoc;
                byte[] doc;
                this.SelecioneDocumento(out nomeDoc, out doc);

                this._novoDocumentoNfNome = nomeDoc;
                this._novoDocumentoNf = doc;


                ((NotificacaoDesvioClass)this.Entity).NfDevolucaoDocumento = this._novoDocumentoNf;
                ((NotificacaoDesvioClass)this.Entity).NfDevolucaoDocumentoNome = this._novoDocumentoNfNome;

                this.lnkNfDevolucao.Text = "Baixar: " + _novoDocumentoNfNome;
                this.lnkNfDevolucao.Visible = true;
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionarPlanoAcao_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeDoc;
                byte[] doc;
                this.SelecioneDocumento(out nomeDoc, out doc);

                this._novoDocumentoPlanoNome = nomeDoc;
                this._novoDocumentoPlano = doc;


                ((NotificacaoDesvioClass)this.Entity).PlanoAcaoDocumento = this._novoDocumentoPlano;
                ((NotificacaoDesvioClass)this.Entity).PlanoAcaoDocumentoNome = this._novoDocumentoPlanoNome;

                this.lnkPlanoAcao.Text = "Baixar: " + _novoDocumentoPlanoNome;
                this.lnkPlanoAcao.Visible = true;
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

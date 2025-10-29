#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using BibliotecaTributos;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public partial class ConfiguradorStatusForm : IWTBaseForm
    {
        internal List<IWTPostgreNpgsqlConnection> conn { get; private set; }

        
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        readonly int qtdThreads;

        public string Error { get; private set; }
        public string Avisos { get; private set; }

        internal List<ConfiguradorPedido> pedidosConfigurar;
        private IConfiguradorEASIFactory configuradorEasiFactory;

        public ConfiguradorStatusForm(List<IWTPostgreNpgsqlConnection> conn , string tipoCalculoSemana, string diaCalculoSemana, int qtdThreads, List<ConfiguradorPedido> pedidosConfigurar, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            InitializeComponent();
            this.conn = conn;
            
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.pedidosConfigurar = pedidosConfigurar;
            this.qtdThreads = qtdThreads;
            this.configuradorEasiFactory = configuradorEasiFactory;

        }

        public void startManager()
        {
            ConfiguradorRunnerManagerClass run = new ConfiguradorRunnerManagerClass(this.conn,
                      this.tipoCalculoSemana, this.diaCalculoSemana, this.qtdThreads, this.pedidosConfigurar, this.configuradorEasiFactory);

            run.ProgressChanged += new ProgressChangedEventHandler(run_ProgressChanged);
            run.RunWorkerCompleted += new RunWorkerCompletedEventHandler(run_RunWorkerCompleted);

            run.RunWorkerAsync();
        }

        void run_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.progressBar1.Value = this.progressBar1.Maximum;
            RetornoConfigurador ret = (RetornoConfigurador) e.Result;
            this.Error = ret.Erro;
            this.Avisos = ret.Aviso;
            this.Close();
        }

        void run_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            lblPorcentagem.Text = e.ProgressPercentage + "%";
        }

        private void ConfiguradorStatusForm_Shown(object sender, EventArgs e)
        {
            this.startManager();
        }
    }
}

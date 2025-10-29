using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAgrupadorMateriaisListForm : IWTListForm
    {
         private TipoForm Tipo;

        public CadAgrupadorMateriaisListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }
    }
}

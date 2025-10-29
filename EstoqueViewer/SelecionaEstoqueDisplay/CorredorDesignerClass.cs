#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace EstoqueViewer
{
    class CorredorDesignerClass:IComparable<CorredorDesignerClass>
    {
        int idCorredor;
        readonly string Identificacao;
        string Descricao;
        internal EstoqueDesignerClass Estoque { get; private set; }

        internal Dictionary<int, PrateleiraDesignerClass> Prateleiras;

        internal Size Tamanho { get; private set; }
        internal Point Posicao;


        public CorredorDesignerClass(int idCorredor, string Identificacao, string Descricao, EstoqueDesignerClass Estoque)
        {
            this.idCorredor = idCorredor;
            this.Identificacao = Identificacao;
            this.Descricao = Descricao;

            this.Estoque = Estoque;
            this.Prateleiras = new Dictionary<int, PrateleiraDesignerClass>();
        }


        public void addPrateleira(int idPrateleira, string Identificacao,string Descricao, CorredorDesignerClass Corredor)
        {
            try
            {
                if (!this.Prateleiras.ContainsKey(idPrateleira))
                {
                    this.Prateleiras.Add(idPrateleira, new PrateleiraDesignerClass(idPrateleira, Identificacao, Descricao, this));
                }
                else
                {
                    throw new Exception("Prateleira Já existente");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a Prateleira.\r\n" + e.Message);
            }
        }


        internal Size defineTamanho()
        {
            this.Posicao = new Point();
            int maiorAltura = 0;
            int somaLarguras = 0;

            int maiorQtdLinhas = 1;

            List<PrateleiraDesignerClass> prateleiraTmp = new List<PrateleiraDesignerClass>(this.Prateleiras.Values);
            prateleiraTmp.Sort();

            foreach (PrateleiraDesignerClass prat in this.Prateleiras.Values)
            {
                prat.defineTamanho(false, null);
                if (prat.Tamanho.Height > maiorAltura)
                {
                    maiorAltura = prat.Tamanho.Height;
                    maiorQtdLinhas = prat.qtdLinhasAtual; 
                }

                

            }

            foreach (PrateleiraDesignerClass prat in this.Prateleiras.Values)
            {
                prat.setAltura(maiorAltura);
                prat.defineTamanho(true, maiorQtdLinhas);

                somaLarguras += prat.Tamanho.Width + this.Estoque.espacoBorda;
            }

            this.Tamanho = new Size(somaLarguras + this.Estoque.espacoBorda , maiorAltura + this.Estoque.espacoBorda * 2);
            return this.Tamanho;
        }

        internal void Desenhar(ref Graphics g)
        {
            Color Cor = this.Estoque.corCorredor;
            int x = this.Posicao.X;
            int y = this.Posicao.Y;
            bool Round = true;
            bool Negrito = false;


            GraphicsPath gp;



            int tamanhoSombra = this.Estoque.tamanhoSombra;
            Brush brush = new SolidBrush(Cor);
            SizeF shadowSize = new SizeF(this.Tamanho.Width + tamanhoSombra, this.Tamanho.Height + tamanhoSombra);
            PointF shadowLocation = new PointF(x + tamanhoSombra, y + tamanhoSombra);
            SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, Color.Gray));

            Rectangle rec = new Rectangle(x, y, this.Tamanho.Width, this.Tamanho.Height);



            if (Round)
            {

                float width = this.Tamanho.Width;
                float height = this.Tamanho.Height;
                float radius = 10;


                //Sombra


                gp = new GraphicsPath();
                //gp.AddLine(x + tamanhoSombra + radius, y + tamanhoSombra, x + tamanhoSombra + width - (radius * 2), y + 3); // Line
                gp.AddArc(x + tamanhoSombra + width - (radius * 2), y + tamanhoSombra, radius * 2, radius * 2, 270, 90); // Corner
                //gp.AddLine(x + tamanhoSombra + width, y + 3 + radius, x + tamanhoSombra + width, y + 3 + height - (radius * 2)); // Line
                gp.AddArc(x + tamanhoSombra + width - (radius * 2), y + tamanhoSombra + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
                //gp.AddLine(x + tamanhoSombra + width - (radius * 2), y + tamanhoSombra + height, x + tamanhoSombra + radius, y + 3 + height); // Line
                gp.AddArc(x + tamanhoSombra, y + tamanhoSombra + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
                //gp.AddLine(x + tamanhoSombra, y + tamanhoSombra + height - (radius * 2), x + tamanhoSombra, y + tamanhoSombra + radius); // Line
                gp.AddArc(x + tamanhoSombra, y + tamanhoSombra, radius * 2, radius * 2, 180, 90); // Corner
                gp.CloseFigure();
                g.FillPath(shadowBrush, gp);






                //Desenho
                gp = new GraphicsPath();
                //gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
                //gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
                gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
                //gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
                //gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
                gp.CloseFigure();
                g.FillPath(brush, gp);

                g.DrawPath(new Pen(Color.Black), gp);

            }
            else
            {



                // Create a rectangleF. 
                RectangleF rectFToFill =
                    new RectangleF(shadowLocation, shadowSize);

                // Create a custom brush using a semi-transparent color, and 
                // then fill in the rectangle.
                g.FillRectangles(shadowBrush, new RectangleF[] { rectFToFill });

                g.FillRectangle(brush, rec);
                g.DrawRectangle(new Pen(Color.Black), rec);

            }




            StringFormat format = new StringFormat();


            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;

            Font font = null;

            if (Negrito)
            {
                font = new Font(new FontFamily("Arial"), this.Estoque.tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                font = new Font(new FontFamily("Arial"), this.Estoque.tamanhoFonte, FontStyle.Regular);
            }





            /*if (verticalMode)
            {
                IWTFunctions.IWTFunctions.DrawVerticalString(g, this.Texto, 270, rec, font, format);
                //format = new StringFormat(StringFormatFlags.DirectionVertical);
                //g.DrawString(this.Texto, font, Brushes.Black, rec, format);
            }
            else
            {
             */
            g.DrawString(
                this.ToString(),
                font,
                Brushes.Black,
                this.Posicao.X + (this.Estoque.espacoBorda),
                this.Posicao.Y ,
                format);
            g.Transform.Reset();
            //}


            foreach (PrateleiraDesignerClass prat in this.Prateleiras.Values)
            {
                prat.Desenhar(ref g);
            }

        }

        #region IComparable<CorredorDesignerClass> Members

        public int CompareTo(CorredorDesignerClass other)
        {
            return this.Identificacao.CompareTo(other.Identificacao);
        }

        #endregion

        public override string ToString()
        {
            return "Corredor: " + this.Identificacao;
        }
    }
}

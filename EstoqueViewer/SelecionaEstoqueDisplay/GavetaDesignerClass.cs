#region Referencias

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace EstoqueViewer
{
    class GavetaDesignerClass:IComparable<GavetaDesignerClass>
    {
        int idGaveta;
        readonly PrateleiraDesignerClass Prateleira;
        readonly string Identificacao;
        string Descricao;

        internal Size Tamanho { get; private set; }
        internal Point Posicao;

        //Dictionary<int, GavetaDesignerClass> Gavetas;
        public GavetaDesignerClass(int idGaveta, string Identificacao, string Descricao, PrateleiraDesignerClass Prateleira)
        {
            this.idGaveta = idGaveta;
            this.Prateleira = Prateleira;
            this.Identificacao = Identificacao;
            this.Descricao = Descricao;

            this.defineTamanho();
        }

        internal Size defineTamanho()
        {
            this.Posicao = new Point();
            this.Tamanho = this.Prateleira.Corredor.Estoque.tamanhoGaveta;
            return this.Tamanho;
        }

        internal void Desenhar(ref Graphics g)
        {
            Color Cor = this.Prateleira.Corredor.Estoque.corGaveta;
            int x = this.Posicao.X;
            int y = this.Posicao.Y;
            bool Round = true;
            bool Negrito = false;
            
            
            GraphicsPath gp;



            int tamanhoSombra = this.Prateleira.Corredor.Estoque.tamanhoSombra;
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


            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            Font font = null;

            if (Negrito)
            {
                font = new Font(new FontFamily("Arial"), this.Prateleira.Corredor.Estoque.tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                font = new Font(new FontFamily("Arial"), this.Prateleira.Corredor.Estoque.tamanhoFonte, FontStyle.Regular);
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
                g.DrawString(this.ToString(), font, Brushes.Black, rec, format);
                g.Transform.Reset();
            //}
           

        }

        public override string ToString()
        {
            return this.Identificacao;
        }

        #region IComparable<GavetaDesignerClass> Members

        public int CompareTo(GavetaDesignerClass other)
        {
            return this.Identificacao.CompareTo(other.Identificacao);
        }

        #endregion
    }
}

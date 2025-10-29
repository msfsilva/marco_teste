#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace EstoqueViewer
{
    internal class PrateleiraDesignerClass:IComparable<PrateleiraDesignerClass>
    {
        readonly int idPrateleira;
        readonly string Identificacao;
        string Descricao;
        internal CorredorDesignerClass Corredor { get; private set; }

        internal Size Tamanho { get; private set; }
        internal int qtdLinhasAtual { get; private set; }
        internal int qtdColunasAtual { get; private set; }
        internal Point Posicao;

        internal Dictionary<int, GavetaDesignerClass> Gavetas;
        internal PrateleiraDesignerClass(int idPrateleira, string Identificacao, string Descricao, CorredorDesignerClass Corredor)
        {
            this.idPrateleira = idPrateleira;
            this.Identificacao = Identificacao;
            this.Descricao = Descricao;

            this.Corredor = Corredor;
            this.Gavetas = new Dictionary<int, GavetaDesignerClass>();
        }


        internal void addGaveta(int idGaveta, string Identificacao, string Descricao, GavetaDesignerClass Gaveta)
        {
            try
            {
                if (!this.Gavetas.ContainsKey(idGaveta))
                {
                    this.Gavetas.Add(idPrateleira, new GavetaDesignerClass(idGaveta, Identificacao, Descricao, this));
                }
                else
                {
                    throw new Exception("Gaveta Já existente");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a Gaveta.\r\n" + e.Message);
            }
        }

        internal Size defineTamanho(bool forcarLinhas, int? qtdLinhasForcada)
        {
            this.Posicao = new Point();
            int difLinhaColuna = 9999999;

            if (!forcarLinhas)
            {
                qtdLinhasAtual = this.Corredor.Estoque.numeroMaximoLinhasGaveta;
                qtdColunasAtual = 999;


                for (int qtdLinhas = this.Corredor.Estoque.numeroMaximoLinhasGaveta; qtdLinhas > 0; qtdLinhas--)
                {
                    double tmp = Convert.ToDouble(this.Gavetas.Count) / Convert.ToDouble(qtdLinhas);
                    int qtdColunas = Convert.ToInt32(Math.Ceiling(tmp));

                    int difLinhaColunaTmp = Math.Abs(qtdLinhas - qtdColunas);

                    if (difLinhaColunaTmp < difLinhaColuna)
                    {
                        qtdLinhasAtual = qtdLinhas;
                        qtdColunasAtual = qtdColunas;
                        difLinhaColuna = difLinhaColunaTmp;
                    }
                    else
                    {
                        if (difLinhaColunaTmp == difLinhaColuna && qtdLinhas < qtdLinhasAtual)
                        {
                            qtdLinhasAtual = qtdLinhas;
                            qtdColunasAtual = qtdColunas;
                            difLinhaColuna = difLinhaColunaTmp;
                        }
                    }

                }
            }
            else
            {
                qtdLinhasAtual = qtdLinhasForcada.Value;
                qtdColunasAtual = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.Gavetas.Count) / Convert.ToDouble(qtdLinhasAtual)));
            }

            int largura = (this.qtdColunasAtual * this.Corredor.Estoque.tamanhoGaveta.Width) + ((this.qtdColunasAtual + 1) * this.Corredor.Estoque.espacamentoGaveta);
            int altura = (this.qtdLinhasAtual * this.Corredor.Estoque.tamanhoGaveta.Height) + ((this.qtdLinhasAtual + 1) * this.Corredor.Estoque.espacamentoGaveta) + this.Corredor.Estoque.espacoBorda * 2;
            this.Tamanho = new Size(largura, altura);

            return this.Tamanho;
        }

        internal void setAltura(int Altura)
        {
            this.Tamanho = new Size(this.Tamanho.Width, Altura);
        }

        internal void posicionaGavetas()
        {
            try
            {
                List<GavetaDesignerClass> gavetasTmp = new List<GavetaDesignerClass>(this.Gavetas.Values);
                gavetasTmp.Sort();

                int i = 0;

                int xAtual = this.Posicao.X + this.Corredor.Estoque.espacamentoGaveta;
                int yAtual = this.Posicao.Y + this.Corredor.Estoque.espacoBorda + this.Corredor.Estoque.espacamentoGaveta;

                int ultimaLargura = 0;
                int ultimaAltura = 0;

                for (int linha = 0; linha < qtdLinhasAtual; linha++)
                {
                    for (int coluna = 0; coluna < qtdColunasAtual; coluna++)
                    {
                        if (i < gavetasTmp.Count)
                        {
                            gavetasTmp[i].Posicao.X = xAtual;
                            gavetasTmp[i].Posicao.Y = yAtual;

                            ultimaAltura = gavetasTmp[i].Tamanho.Height;
                            ultimaLargura = gavetasTmp[i].Tamanho.Width;

                            i++;

                        }

                        xAtual += ultimaLargura + this.Corredor.Estoque.espacamentoGaveta;


                        
                    }
                    yAtual += ultimaAltura + this.Corredor.Estoque.espacamentoGaveta;
                    xAtual = this.Posicao.X + this.Corredor.Estoque.espacamentoGaveta;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao posicionar as gavetas.\r\n" + e.Message, e);
            }
        }


        internal void Desenhar(ref Graphics g)
        {
            Color Cor = this.Corredor.Estoque.corPrateleira;
            int x = this.Posicao.X;
            int y = this.Posicao.Y;
            bool Round = true;
            bool Negrito = false;



            GraphicsPath gp;



            int tamanhoSombra = this.Corredor.Estoque.tamanhoSombra;
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
                font = new Font(new FontFamily("Arial"), this.Corredor.Estoque.tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                font = new Font(new FontFamily("Arial"), this.Corredor.Estoque.tamanhoFonte, FontStyle.Regular);
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
                this.Posicao.X + this.Corredor.Estoque.espacoBorda ,
                this.Posicao.Y ,
                format);
            g.Transform.Reset();
            //}


            foreach (GavetaDesignerClass gav in this.Gavetas.Values)
            {
                gav.Desenhar(ref g);
            }

        }

        #region IComparable<PrateleiraDesignerClass> Members

        public int CompareTo(PrateleiraDesignerClass other)
        {
            return this.Identificacao.CompareTo(other.Identificacao);
        }

        #endregion

        public override string ToString()
        {
            return "Prateleira: " + this.Identificacao;
        }
    }
}

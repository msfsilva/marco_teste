#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace EstoqueViewer
{
    public class EstoqueDesignerClass
    {
        readonly int idEstoque;
        readonly string Identificacao;
        readonly IWTPostgreNpgsqlConnection conn;

        #region Parametros Configuração
        internal Size tamanhoGaveta { get; private set; }
        internal int espacamentoGaveta { get; private set; }
        internal int numeroMaximoLinhasGaveta { get; private set; }
        internal int espacoBorda { get; private set; }
        internal Color corEstoque { get; private set; }
        internal Color corCorredor { get; private set; }
        internal Color corPrateleira { get; private set; }
        internal Color corGaveta { get; private set; }
        internal int tamanhoFonte { get; private set; }
        internal int tamanhoSombra { get; private set; }

        #endregion


        internal Size Tamanho { get; private set; }

        Dictionary<int, CorredorDesignerClass> Corredores;

        public EstoqueDesignerClass(int idEstoque, string Identificacao, IWTPostgreNpgsqlConnection conn)
        {
            this.idEstoque = idEstoque;
            this.Identificacao = Identificacao;
            this.conn = conn;

            this.initConstants();
            this.loadEstoque();
        }


        private void initConstants()
        {
            tamanhoGaveta = new Size(90, 40);
            espacamentoGaveta = 5;
            numeroMaximoLinhasGaveta = 10;
            espacoBorda = 15;

            corEstoque = Color.White;
            corCorredor = Color.LightBlue;
            corPrateleira = Color.LightGray;
            corGaveta = Color.LightYellow;

            tamanhoFonte = 9;
            tamanhoSombra = 5;

        }

        private void loadEstoque()
        {
            try
            {
                this.Corredores = new Dictionary<int, CorredorDesignerClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.estoque_corredor.id_estoque_corredor, " +
                    "  public.estoque_corredor.esc_identificacao, " +
                    "  public.estoque_corredor.esc_descricao, " +
                    "  public.estoque_prateleira.id_estoque_prateleira, " +
                    "  public.estoque_prateleira.esp_identificacao, " +
                    "  public.estoque_prateleira.esp_descricao, " +
                    "  public.estoque_gaveta.id_estoque_gaveta, " +
                    "  public.estoque_gaveta.esg_identificacao, " +
                    "  public.estoque_gaveta.esg_descricao " +
                    "FROM " +
                    "  public.estoque_corredor " +
                    "  INNER JOIN public.estoque_prateleira ON (public.estoque_corredor.id_estoque_corredor = public.estoque_prateleira.id_estoque_corredor) " +
                    "  INNER JOIN public.estoque_gaveta ON (public.estoque_prateleira.id_estoque_prateleira = public.estoque_gaveta.id_estoque_prateleira) " +
                    "WHERE " +
                    "  public.estoque_corredor.id_estoque = " + this.idEstoque + " " +
                    "ORDER BY " +
                    "  public.estoque_corredor.esc_identificacao, " +
                    "  public.estoque_prateleira.esp_identificacao, " +
                    "  public.estoque_gaveta.esg_identificacao ";

                NpgsqlDataReader read = command.ExecuteReader();

                read.Read();



                do
                {
                    int idCorredor = Convert.ToInt32(read["id_estoque_corredor"]);
                    int idPrateleira = Convert.ToInt32(read["id_estoque_prateleira"]);
                    int idGaveta = Convert.ToInt32(read["id_estoque_gaveta"]);

                    if (!this.Corredores.ContainsKey(idCorredor))
                    {
                        this.Corredores.Add(idCorredor, new CorredorDesignerClass(
                            idCorredor,
                            read["esc_identificacao"].ToString(),
                            read["esc_descricao"].ToString(),
                            this));
                    }

                    if (!this.Corredores[idCorredor].Prateleiras.ContainsKey(idPrateleira))
                    {
                        this.Corredores[idCorredor].Prateleiras.Add(idPrateleira, new PrateleiraDesignerClass(
                            idPrateleira,
                            read["esp_identificacao"].ToString(),
                            read["esp_descricao"].ToString(),
                            this.Corredores[idCorredor]));
                    }

                    if (!this.Corredores[idCorredor].Prateleiras[idPrateleira].Gavetas.ContainsKey(idGaveta))
                    {
                        this.Corredores[idCorredor].Prateleiras[idPrateleira].Gavetas.Add(idGaveta, new GavetaDesignerClass(
                            idGaveta,
                            read["esg_identificacao"].ToString(),
                            read["esg_descricao"].ToString(),
                            this.Corredores[idCorredor].Prateleiras[idPrateleira]));
                    }

                } while (read.Read());

                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o estoque.\r\n" + e.Message);
            }
        }

        private void defineTamanhoTela()
        {
            try
            {
                int maiorLargura = 0;
                int somaAlturas = espacoBorda ;

                foreach (CorredorDesignerClass corredor in this.Corredores.Values)
                {
                    corredor.defineTamanho();
                    if (corredor.Tamanho.Width > maiorLargura)
                    {
                        maiorLargura = corredor.Tamanho.Width + (espacoBorda * 2);
                    }

                    somaAlturas += corredor.Tamanho.Height +this.espacoBorda;

                }

                this.Tamanho = new Size(maiorLargura, somaAlturas);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir os tamanhos dos objetos.\r\n" + e.Message, e);
            }
        }

        private void definirPosicoes()
        {
            try
            {
                List<CorredorDesignerClass> corredoresTmp = new List<CorredorDesignerClass>(this.Corredores.Values);
                corredoresTmp.Sort();

                int yAtual = this.espacoBorda;
                int xAtual = this.espacoBorda;

                foreach (CorredorDesignerClass corredor in corredoresTmp)
                {
                    corredor.Posicao.X = xAtual = this.espacoBorda;
                    corredor.Posicao.Y = yAtual;

                    yAtual += this.espacoBorda;
                    xAtual += this.espacoBorda;
                    foreach (PrateleiraDesignerClass prateleira in corredor.Prateleiras.Values)
                    {
                        prateleira.Posicao.X = xAtual;
                        prateleira.Posicao.Y = yAtual;

                        prateleira.posicionaGavetas();

                        xAtual += prateleira.Tamanho.Width + this.espacoBorda;

                    }

                    yAtual += corredor.Tamanho.Height;
                }



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir as posições dos objetos.\r\n" + e.Message, e);
            }
        }

        public Size Desenhar(ref Graphics g)
        {
            this.defineTamanhoTela();
            this.definirPosicoes();

            Color Cor = this.corEstoque;
            int x = 0;
            int y = 0;
            bool Round = true;
            bool Negrito = false;


            GraphicsPath gp;




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
                font = new Font(new FontFamily("Arial"), this.tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                font = new Font(new FontFamily("Arial"), this.tamanhoFonte, FontStyle.Regular);
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
            g.DrawString(this.ToString(), font, Brushes.Black, this.espacoBorda,0, format);
            g.Transform.Reset();
            //}


            foreach (CorredorDesignerClass corr in this.Corredores.Values)
            {
                corr.Desenhar(ref g);
            }

            return this.Tamanho;

        }

        public override string ToString()
        {
            return "Almoxarifado: " + this.Identificacao;
        }
    }
}

  





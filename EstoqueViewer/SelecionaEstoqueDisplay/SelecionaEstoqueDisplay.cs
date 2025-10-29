#region Referencias

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace EstoqueViewer
{
    public partial class SelecionaEstoqueDisplay : ScrollableControl
    {

        private readonly Image _Backgroud = null;
        public EstoqueDesignerClass Estoque { get; set; }
        public SelecionaEstoqueDisplay()
        {
            InitializeComponent();
            this.AutoScroll = true;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        public SelecionaEstoqueDisplay(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.AutoScroll = true;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            if (pe.ClipRectangle.Width == 0)
            {
                return;
            }

            base.OnPaint(pe);


            // Create the drawing area in memory.
            // Double buffering is used to prevent flicker.
            Bitmap bufl = new Bitmap(pe.ClipRectangle.Width, pe.ClipRectangle.Height);
            Graphics gfx = Graphics.FromImage(bufl);

            if (this._Backgroud != null)
            {
                SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(225, Color.White.R, Color.White.G, Color.White.B));

                float larguraImagem = this._Backgroud.Width;
                float alturaImagem = this._Backgroud.Height;

                float razaoAltura = this.Size.Height / alturaImagem;
                float razaoLargura = this.Size.Width / larguraImagem;

                float menorRazao = razaoAltura;
                if (razaoLargura < menorRazao)
                {
                    menorRazao = razaoLargura;
                }

                larguraImagem = larguraImagem * menorRazao;
                alturaImagem = alturaImagem * menorRazao;

                float x = (this.Size.Width - larguraImagem) / 2;
                float y = (this.Size.Height - alturaImagem) / 2;



                gfx.DrawImage(this._Backgroud, new RectangleF(new PointF(x, y), new SizeF(larguraImagem, alturaImagem)));
                gfx.FillRectangle(semiTransBrush, new RectangleF(new PointF(x, y), new SizeF(larguraImagem, alturaImagem)));
            }

            Point pt = AutoScrollPosition;
            gfx.TranslateTransform(pt.X, pt.Y);

            if (this.Estoque != null)
            {
                AutoScrollMinSize = this.Estoque.Desenhar(ref gfx);
            }
            


            // Render the finished image on the form.  
            pe.Graphics.DrawImageUnscaled(bufl, 0, 0);
            gfx.Dispose();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Invalidate();
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            this.Invalidate();
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            this.Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Invalidate();
        }
    }
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace UIAssignment.Resources
{
    /*internal*/ public class Cool_button : Button
    {
        private int borderSize = 0;
        private int borderRadius = 40;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Color borderColor = Color.PaleVioletRed;
        [Category("AdvanceButton menu")]
        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        
        [Category("AdvanceButton menu")]
        public int BorderRadius { get => borderRadius; set { if (value <= this.Height) borderRadius = value; else borderRadius = this.Height; this.Invalidate(); } }
        [Category("AdvanceButton menu")]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        [Category("AdvanceButton menu")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value;}
        }

        [Category("AdvanceButton menu")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        public Cool_button()
        {
            this.FlatStyle= FlatStyle.Flat;
            this.FlatAppearance.BorderSize=0;
            this.Size = new Size(150, 40);
            this.BackColor= Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }


        private GraphicsPath GetFigurePath(RectangleF rect,float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height-radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode= SmoothingMode.AntiAlias;

            RectangleF rectSurfce=new RectangleF(0,0,this.Width,this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface= GetFigurePath(rectSurfce,borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder,borderRadius-1F))
                using(Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurfce);
                if(borderSize>=1) { 
                    using(Pen penBorder = new Pen(borderColor,borderSize))
                    {
                        penBorder.Alignment= PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sendr, EventArgs e)
        {
            if(this.DesignMode)
            {
                this.Invalidate();
            }
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                BorderRadius = this.Height;
        }

        private void InitializeComponent()
        {
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(0, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 23);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.Text = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);

        }
    }
}

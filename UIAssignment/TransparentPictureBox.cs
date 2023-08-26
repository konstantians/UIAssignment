using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAssignment
{
    internal class TransparentPictureBox : PictureBox
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)(Opacity * 255), BackColor)), ClientRectangle);
            base.OnPaint(e);
        }

        private double opacity = 1.0;
        public double Opacity
        {
            get { return opacity; }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    opacity = value;
                    Invalidate(); // Redraw the control
                }
            }
        }
    }
}

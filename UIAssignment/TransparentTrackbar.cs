using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAssignment
{

    public class TransparentTrackBar : Control
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private int _value = 0;

        public int Minimum
        {
            get => _minimum;
            set { _minimum = value; Invalidate(); }
        }

        public int Maximum
        {
            get => _maximum;
            set { _maximum = value; Invalidate(); }
        }

        public int Value
        {
            get => _value;
            set { _value = Math.Min(Math.Max(value, Minimum), Maximum); Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.Transparent);

            int trackWidth = Width - Height;
            int thumbPosition = (Value - Minimum) * trackWidth / (Maximum - Minimum);

            Rectangle trackRect = new Rectangle(Height / 2, Height / 3, trackWidth, Height / 3);
            Rectangle thumbRect = new Rectangle(thumbPosition, 0, Height, Height);

            using (SolidBrush trackBrush = new SolidBrush(Color.Gray))
            using (SolidBrush thumbBrush = new SolidBrush(Color.Blue))
            {
                e.Graphics.FillRectangle(trackBrush, trackRect);
                e.Graphics.FillRectangle(thumbBrush, thumbRect);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                int trackWidth = Width - Height;
                int newValue = ((e.X - Height / 2) * (Maximum - Minimum)) / trackWidth + Minimum;
                Value = newValue;
            }
        }
    }

}

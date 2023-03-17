using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal class Ellipse : Shape
    {
        public override void Draw(Graphics g, Pen p, int formWidth, int formHeight)
        {
            g.FillEllipse(new SolidBrush(Color), new System.Drawing.Rectangle(X, Y, Width, Height));
            Move();

            base.Draw(g, p, formWidth, formHeight);
        }
    }
}

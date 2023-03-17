using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal class Rectangle : Shape
    {
        public override void Draw(Graphics g, Pen p, int formWidth, int formHeight)
        {
            g.DrawRectangle(p, X, Y, Width, Height);
            g.FillRectangle(
                new SolidBrush(this.Color),
                new System.Drawing.Rectangle(X, Y, Width, Height));

            base.Draw(g, p, formWidth, formHeight);
        }
      
    }
}

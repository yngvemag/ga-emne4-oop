using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DrawWithWinForm.Shapes
{
    internal class Rectangle : Shape
    {
        public override double GetArea() => Width * Height;     

        public override double GetCircumference() => (2 * Width) + (2 * Height);

        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            g.DrawRectangle(new Pen(base.Color), X, Y, Width , Height );
            g.FillRectangle(
                new SolidBrush(this.FillColor),
                new System.Drawing.Rectangle(X, Y, Width , Height));

            base.Move();
            base.BounceOnEdges(formWidth, formHeight);
        }
      
    }
}

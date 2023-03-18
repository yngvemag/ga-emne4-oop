using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal class Ellipse : Shape
    {
        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            g.FillEllipse(new SolidBrush(FillColor), 
                new System.Drawing.Rectangle(X, Y, Width, Height));
            
            base.Move();
            base.BounceEdges(formWidth, formHeight);

        }
    }
}

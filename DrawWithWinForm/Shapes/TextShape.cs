using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal class TextShape : Shape
    {
        public string Text { get; set; } = string.Empty;

        public override void Draw(Graphics g, Pen p, int formWidth, int formHeight)
        {
            g.DrawString(Text, new Font("Arial", Height), new SolidBrush(Color), new Point(X, Y));

            Move();
            CheckEdges(formWidth, formHeight);
        }
    }
}

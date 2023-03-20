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

        public override double GetArea() => 0;
        public override double GetCircumference() => 0;

        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            g.DrawString(Text, new Font("Arial", Height), 
                new SolidBrush(Color), new Point(X, Y));

            Move();
            BounceOnEdges(formWidth, formHeight);
        }

        public override void DrawAreaString(Graphics g, int formWidth, int formHeight)
        {
            return;
        }

        public override void DrawCirmuferenceString(Graphics g, int formWidth, int formHeight)
        {
            return;
        }


    }
}

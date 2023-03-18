using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal class Circle : Shape
    {
        public double Radius 
        {
            get => Diameter / 2;            
        }
        public int Diameter
        {
            get => Width;
            set 
            {
                Width = value;
                Height = value;
            }
        }

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
        public override double GetCircumference() => Math.PI * Diameter;

        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            g.FillEllipse(new SolidBrush(FillColor), 
                new System.Drawing.Rectangle(X, Y, Diameter, Diameter));
            base.Move();
            base.BounceEdges(formWidth, formHeight);

        }
    }
}

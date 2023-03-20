using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal class Triangle : Shape
    {
        private Point _pointA, _pointB, _pointC;
        private Point[]? _points;
        
        protected void UpdatePoints()
        {
            // calculate points
            _pointA = new Point(this.X, this.Y);
            _pointB = new Point(this.X + Width, this.Y);
            _pointC = new Point(this.X + (Width / 2), this.Y + this.Height);
            _points = new Point[] { _pointA, _pointB, _pointC };
        }      

        public override double GetArea() => (Width * Height) / 2;

        public override double GetCircumference() 
        {
            var a = Width;
            var b = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow((Width / 2), 2));
            return a + 2 * b;
        }

        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            UpdatePoints();
            Pen p = new(this.Color);
            if (_points != null)
            {
                for( var i = 0; i < _points.Length; i++ )
                    g.DrawLine(p, _points[i], _points[(i + 1)%_points.Length]);
                g.FillPolygon(new SolidBrush(this.FillColor), _points);
            }
                
            base.Move();
            base.BounceOnEdges(formWidth, formHeight);
        }

    }
}

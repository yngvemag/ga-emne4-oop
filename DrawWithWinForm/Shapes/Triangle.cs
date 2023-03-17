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
        private Point[] _points;
        
        protected void UpdatePoints()
        {
            // calculate points
            _pointA = new Point(this.X, this.Y);
            _pointB = new Point(this.X + Width, this.Y);
            _pointC = new Point(this.X + (Width / 2), this.Height + this.Y);
            _points = new Point[] { _pointA, _pointB, _pointC };
        }

        public override void Draw(Graphics g, Pen p, int formWidth, int formHeight)
        {
            UpdatePoints();
            
            g.DrawLine(p, _pointA, _pointB);
            g.DrawLine(p, _pointB, _pointC);
            g.DrawLine(p, _pointC, _pointA);

            g.FillPolygon(new SolidBrush(this.Color), _points);

            base.Draw(g, p, formWidth, formHeight);
        }
    }
}

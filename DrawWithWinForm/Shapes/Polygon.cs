using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DrawWithWinForm.Shapes
{
    internal class Polygon : VectorLine
    {
        protected Point[]? _points;

        public Polygon(double length, int count)
            : base(length, count)
        {
            _points = new Point[_vectorCount];
        }

        protected void InitPoints()
        {
            int x = X;
            int y = Y;

            if (_points != null)
            {
                for (var i = 0; i < _vectorCount; i++)
                {
                    _points[i] = new Point(x, y);

                    // next x and y
                    x += (int)_vectors[i].XLength;
                    y += (int)_vectors[i].YLength;
                }
            }
        }

        public bool IsDrawingNumbers { get; set; }
        public bool isDrawingVectors { get; set; }
        protected void DrawPolygon(Graphics g, int formWidth, int formHeight)
        {
            Pen p = new Pen(Color);
            if (_points != null)
            {
                for (int i = 0; i < _vectorCount; ++i)
                {
                    int a = i;
                    int b = (i + 1 == _vectorCount) ? 0 : i + 1;
                    g.DrawLine(p, _points[i], _points[b]);
                }

                g.FillPolygon(new SolidBrush(this.FillColor), _points);
            }
        }
        protected void DrawNumberString(Graphics g, int formWidth, int formHeight)
        {
            if (_points != null)
            {
                int x = (int)_points.Average(x => x.X) - 10;
                int y = (int)_points.Average(x => x.Y) - 10;

                g.DrawString($"{_vectorCount}", new Font("Arial", 8), new SolidBrush(Color.White), new Point(x, y));
            }
        }
        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            InitPoints();
            DrawPolygon(g, formWidth, formHeight);            
            
            if (isDrawingVectors)
                DrawVectors(g, formWidth, formHeight); 
            if (IsDrawingNumbers)
                DrawNumberString(g, formWidth, formHeight); 

            RotateVectors();
            Move();

            BounceEdges(formWidth, formHeight);
        }

        public override double GetArea() => ((int)_vektorLength * 2) ^ 2;

        public override double GetCircumference() => _vectors.Sum(v => v.Length);

    }
}

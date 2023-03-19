using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawWithWinForm.Libs;

namespace DrawWithWinForm.Shapes
{
    internal class VectorLine : Shape
    {
        protected Libs.Vector[] _vectors;
        protected int _vectorCount = 0;
        protected double _vektorLength = 0;

        public VectorLine(double length, int count) 
            : this(length, count, 0.0)
        {           
        }
              
        public VectorLine(double length, int count, double initialAngelInDegree)
        {

            Width = (int)length;
            Height = (int)length;
            _vectors = new Vector[count];

            _vectorCount = count;
            _vektorLength = length;
            InitialDirectionInDegree = initialAngelInDegree;
            InitVectors();            
        }

        protected virtual void InitVectors()
        {
            double angle = InitialDirectionInDegree;
            double angleIncrese = 360 / _vectorCount;
            for (var i = 0; i < _vectorCount; i++)
            {
                _vectors[i] = new Vector(_vektorLength, angle);
                angle += angleIncrese;
            }
        }
        public double InitialDirectionInDegree { get; set; }

        public int RotateSpeed { get; set; }
        protected virtual void RotateVectors()
        {
            InitialDirectionInDegree += RotateSpeed;
            InitVectors();
        }
        protected virtual void DrawVectors(Graphics g, int formWidth, int formHeight)
        {   
            if (_vectors != null)
            {
                int x = (int)_vectors.Average(x => x.XLength) - 10 + X;
                int y = (int)_vectors.Average(x => x.YLength) - 10 + Y;
                Point pStart = new(x, y);
                Pen p = new(Color);
                foreach (var vector in _vectors)
                {                    
                    Point pStop = new Point(x + (int)vector.XLength, y + (int)vector.YLength);
                    g.DrawLine(p, pStart, pStop);
                }
            }
        }

        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            DrawVectors(g, formWidth, formHeight);
            RotateVectors();
            Move();
            BounceEdges(formWidth, formHeight);
        }
        public override double GetArea() => 0;
        public override double GetCircumference() => 0;
       
    }
}

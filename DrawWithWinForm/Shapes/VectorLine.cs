using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DrawWithWinForm.Libs;

namespace DrawWithWinForm.Shapes
{
    internal class VectorLine : Shape
    {
        protected Libs.Vector[] _vectors;
        protected Point[] _vectorStopPoints;
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
            _vectors = new Libs.Vector[count];
            _vectorStopPoints = new Point[count];

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
                _vectors[i] = new Libs.Vector(_vektorLength, angle);
                _vectorStopPoints[i] = new Point(X + (int)_vectors[i].XLength, Y + (int)_vectors[i].YLength);
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
                //int x = (int)_vectors.Average(x => x.XLength) - 10 + X;
                //int y = (int)_vectors.Average(x => x.YLength) - 10 + Y;
                Point pStart = new(X, Y);
                Pen p = new(Color);
                foreach (var pStop in _vectorStopPoints)             
                    g.DrawLine(p, pStart, pStop);
            }
        }

        public override void Draw(Graphics g, int formWidth, int formHeight)
        {
            DrawVectors(g, formWidth, formHeight);
            RotateVectors();
            Move();
            BounceOnEdges(formWidth, formHeight);
        }
        public override double GetArea() => 0;
        public override double GetCircumference() => 0;
       
    }
}

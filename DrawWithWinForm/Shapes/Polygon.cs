﻿using Accessibility;
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
        protected Point[]? _vectorPointsAdded;

        public Polygon(double length, int count)
            : base(length, count)
        {
            _vectorPointsAdded = new Point[_vectorCount];
        }

        protected void InitPoints()
        {
            int x = X;
            int y = Y;

            if (_vectorPointsAdded != null)
            {
                for (var i = 0; i < _vectorCount; i++)
                {
                    _vectorPointsAdded[i] = new Point(x, y);

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
            if (_vectorStopPoints != null)
            {
                for (int i = 0; i < _vectorCount; ++i)
                    g.DrawLine(p, _vectorStopPoints[i], _vectorStopPoints[(i+1)%_vectorCount]);

                g.FillPolygon(new SolidBrush(this.FillColor), _vectorStopPoints);
            }
        }
        protected void DrawNumberString(Graphics g, int formWidth, int formHeight)
        {
            if (_vectorPointsAdded != null)
            {
                //int x = (int)_vectorPointsAdded.Average(x => x.X) - 10;
                //int y = (int)_vectorPointsAdded.Average(x => x.Y) - 10;

                int size = 8;
                g.DrawString($"{_vectorCount}", new Font("Arial", size), new SolidBrush(Color.White), new Point(X-size/2, Y-size/2));
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

            BounceOnEdges(formWidth, formHeight);
        }

        public override double GetArea()
        {
            // areal  = 1/4 * n * s^2 * cot(PI/n) => 0.25 * n * s^2 * (1/tan(PI/n))  

            // get length of one side
            double innerAngleRad = (2*Math.PI) / _vectorCount;
            double outerAngleRad = (Math.PI - innerAngleRad) / 2;

            double sideLength = (Math.Sin(innerAngleRad) * _vektorLength) / Math.Sin(outerAngleRad);

            double areal = 0.25 * _vectorCount * Math.Pow(sideLength, 2) * (1/Math.Tan(Math.PI / _vectorCount));
            return areal;
            //double areal = ((sideLength / 2) * _vektorLength) / 2;
            //return areal * _vectorCount;
        }

        public override double GetCircumference() => _vectors.Sum(v => v.Length);

    }
}

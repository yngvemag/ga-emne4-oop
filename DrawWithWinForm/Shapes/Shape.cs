using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DrawWithWinForm.Shapes
{
    internal abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        public Color Color { get; set; }

        public Color FillColor { get; set; }

        public bool IsCollion { get; set; }

        public Point CenterPos 
        {
            get 
            {
                var x = X + (Width / 2);
                var y = Y + (Height / 2);
                return new Point(x, y);
            }  
        }

        public static double Distance(Shape a, Shape b)
        {
            int xdiff = b.CenterPos.X - a.CenterPos.X;
            int ydiff = b.CenterPos.Y - a.CenterPos.Y;

            return Math.Sqrt(xdiff ^ 2 + ydiff ^ 2);
        }

        public static void CollisionTest(Shape a, Shape b)
        {
            if (a.X == b.X && a.Y == b.Y)
                return;

            var xDist = Math.Abs(a.CenterPos.X - b.CenterPos.X);
            var yDist = Math.Abs(b.CenterPos.Y - a.CenterPos.Y);

            if (xDist <= ( a.Width/2 + b.Width/2) &&
                yDist <= (a.Height/2 +b.Height/2))
            {   
                a.IsCollion = true;
                b.IsCollion = true;
            }
        }

        public abstract void Draw(Graphics g, int formWidth, int formHeight);
        public abstract double GetArea();
        public abstract double GetCircumference();

        

        public virtual void DrawAreaString(Graphics g, int formWidth, int formHeight)
        {
            g.DrawString(
               $"A: {GetArea():0.00}",
               new Font("Arial", 10),
               new SolidBrush(Color.White),
               new Point(X, Y - 20));
        }

        public virtual void DrawCirmuferenceString(Graphics g, int formWidth, int formHeight)
        {
            g.DrawString(
                    $"O: {GetCircumference():0.00}",
                    new Font("Arial", 10),
                    new SolidBrush(Color.White),
                    new Point(X, Y - 40));
        }

        protected virtual void Move()
        {
            X += XSpeed;
            Y += YSpeed;
        }

        protected virtual void BounceEdges(int formWidth, int formHeight)
        {
            if (X + Width > formWidth || X < 0)
                XSpeed *= -1;
            if (Y + Height >= formHeight || Y < 0)
                YSpeed *= -1;
        }
       
    }
}

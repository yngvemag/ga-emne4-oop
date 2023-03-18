using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Shapes
{
    internal abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        public Color Color { get; set; }

        public Color FillColor { get; set; }


        public abstract void Draw(Graphics g, int formWidth, int formHeight);

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

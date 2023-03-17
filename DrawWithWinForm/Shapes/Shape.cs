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


        public virtual void Draw(Graphics g, Pen p, int formWidth, int formHeight)
        {
            Move();
            CheckEdges(formWidth, formHeight);
        }
        protected void Move()
        {
            X += XSpeed;
            Y += YSpeed;
        }

        protected void CheckEdges(int formWidth, int formHeight)
        {
            if (X + Width > formWidth || X < 0)
                XSpeed *= -1;
            if (Y + Height >= formHeight || Y < 0)
                YSpeed *= -1;
        }
       
    }
}

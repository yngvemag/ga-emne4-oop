using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Libs
{
    internal class Vector
    {
        protected double _xLength = 0;
        protected double _yLength = 0;
        protected double _radians = 0;

        public Vector(double length, double directionInDegree)
        {
            while (directionInDegree < 0)
                directionInDegree += 360;

            if (directionInDegree > 360)
                directionInDegree %= 360;           

            Length = length;
            DirectionInDegree = directionInDegree;

            // set radians
            _radians = (DirectionInDegree * 2* Math.PI) / 360;
            CalculateXYLength();
        }

        public double Length { get; }
        public double DirectionInDegree { get;}

        public double XLength { get => _xLength; }
        public double YLength { get => _yLength; }

        protected void CalculateXYLength()
        {
            if (DirectionInDegree == 90)
            {
                this._xLength = 0;
                this._yLength = Length;
            }
            if (DirectionInDegree == 270)
            {
                this._xLength = 0;
                this._yLength = Length * -1;
            }
            else if (DirectionInDegree == 0 || DirectionInDegree == 360)
            {
                this._xLength = Length;
                this._yLength = 0;
            }
            else if (DirectionInDegree == 180)
            {
                this._xLength = Length * -1;
                this._yLength = 0;
            }
            else if( DirectionInDegree < 90)
            {
                _xLength = Math.Cos(_radians) * Length;
                _yLength = Math.Sin(_radians) * Length;
            }
                
            else if (DirectionInDegree > 90 && DirectionInDegree < 180)
            {
                var r = Math.PI - _radians;
                _xLength = (Math.Cos(r)*Length) * -1;
                _yLength = (Math.Sin(r)*Length);
            }
                
            else if (DirectionInDegree > 180 && DirectionInDegree < 270)
            {
                var r = Math.PI + _radians;
                _xLength = ( Math.Cos(r) * Length) * -1;
                _yLength = (Math.Sin(r) *Length) * -1;
            }
            else if (DirectionInDegree > 270 && DirectionInDegree < 360)
            {
                var r = (2*Math.PI) - _radians;
                _xLength = (Math.Cos(r) * Length);
                _yLength = (Math.Sin(r) * Length) * -1;
            }
        }
    }
    
}

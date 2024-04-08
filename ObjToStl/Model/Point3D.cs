using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry

{
    internal class Point3D
    {
        private double _X;
        private double _Y;
        private double _Z;

        public Point3D()
        {
            _X = 0.0;
            _Y = 0.0;
            _Z = 0.0;
        }
        public Point3D(double x, double y, double z)
        {
            _X = x;
            _Y = y;
            _Z = z;
        }
        public double X => _X;

        public double Y => _Y;

        public double Z => _Z;

        public int CompareTo(Point3D other)
        {
            if (_X != other._X)
                return _X.CompareTo(other._X);
            if (_Y != other._Y)
                return _Y.CompareTo(other._Y);
            return _Z.CompareTo(other._Z);
        }
    }
}

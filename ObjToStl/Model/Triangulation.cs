using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalGeometry
{
    internal class Triangulation
    {
        private List<Triangle> _Triangles = new List<Triangle>();
        private List<Point3D> _UniquePoints = new List<Point3D>();
        private List<Point3D> _UniqueNormals = new List<Point3D>();

        public Triangulation()
        {
        }

        public List<Triangle> Triangles => _Triangles;

        public List<Point3D> UniquePoints => _UniquePoints;

        public List<Point3D> UniqueNormals => _UniqueNormals;
    }
}

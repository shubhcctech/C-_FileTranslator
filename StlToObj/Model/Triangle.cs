using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    internal class Triangle
    {
        private int _V1;
        private int _V2;
        private int _V3;
        private int _NormalIndex;

        public Triangle(int v1, int v2, int v3)
        {
            _V1 = v1;
            _V2 = v2;
            _V3 = v3;
        }

        public int V1 { get { return _V1; } }

        public int V2 { get { return _V2; } }

        public int V3 { get { return _V3; } }

        public void SetNormalIndex(int index)
        {
            _NormalIndex = index;
        }

        public int NormalIndex
        {
            get { return _NormalIndex; }

        }

    }
}


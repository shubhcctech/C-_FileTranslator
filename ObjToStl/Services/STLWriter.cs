using ComputationalGeometry;
using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWriter
{
    internal class STLWriter
    {
        public void WriteSTL(string filePath, Triangulation triangulation)
        {
            try
            {
                using (StreamWriter outFile = new StreamWriter(filePath))
                {
                    List<Point3D> points = triangulation.UniquePoints;
                    List<Triangle> triangles = triangulation.Triangles;
                    List<Point3D> normals = triangulation.UniqueNormals;

                    outFile.WriteLine("solid");

                    foreach (Triangle triangle in triangles)
                    {
                        outFile.WriteLine($"facet normal {normals[triangle.NormalIndex].X} {normals[triangle.NormalIndex].Y} {normals[triangle.NormalIndex].Z}");
                        outFile.WriteLine("outer loop");
                        outFile.WriteLine($"  vertex {points[triangle.V1].X} {points[triangle.V1].Y} {points[triangle.V1].Z}");
                        outFile.WriteLine($"  vertex {points[triangle.V2].X} {points[triangle.V2].Y} {points[triangle.V2].Z}");
                        outFile.WriteLine($"  vertex {points[triangle.V3].X} {points[triangle.V3].Y} {points[triangle.V3].Z}");
                        outFile.WriteLine("endloop");
                        outFile.WriteLine("endfacet");
                    }

                    outFile.WriteLine("endsolid");
                    Console.WriteLine("Data writing from .obj to .stl file successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to STL file: " + ex.Message);
            }
        }
    }
}

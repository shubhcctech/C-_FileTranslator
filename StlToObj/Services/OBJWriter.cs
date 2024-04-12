using ComputationalGeometry;
using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilerWriter
{
    internal class OBJWriter

    {
        public void WriteOBJ(string filePath, Triangulation triangulation)
        {
            try
            {
                using (StreamWriter outFile = new StreamWriter(filePath))
                {
                    // Write vertices to the OBJ file
                    List<Point3D> points = triangulation.UniquePoints;
                    foreach (Point3D point in points)
                    {
                        outFile.WriteLine($"v {point.X} {point.Y} {point.Z}");
                    }

                    outFile.WriteLine(); // Separate vertices and faces in the OBJ file

                    // Write normals to the OBJ file
                    List<Point3D> normals = triangulation.UniqueNormals;
                    foreach (Point3D normal in normals)
                    {
                        outFile.WriteLine($"vn {normal.X} {normal.Y} {normal.Z}");
                    }

                    outFile.WriteLine();

                    // Write faces to the OBJ file
                    List<Triangle> triangles = triangulation.Triangles;
                    foreach (Triangle triangle in triangles)
                    {
                        // In OBJ format, vertex indices are 1-based, so add 1 to each index
                        outFile.WriteLine($"f {triangle.V1 + 1}//{triangle.NormalIndex + 1} {triangle.V2 + 1}//{triangle.NormalIndex + 1} {triangle.V3 + 1}//{triangle.NormalIndex + 1}");
                    }

                    // Close the OBJ file
                    outFile.Close();
                    Console.WriteLine("Data writing from .stl to .obj file successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while writing to OBJ file: " + ex.Message);
            }
        }
    }
}

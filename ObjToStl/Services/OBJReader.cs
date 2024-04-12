using ComputationalGeometry;
using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    internal class OBJReader
    {
        public void ReadOBJ(string filePath, Triangulation triangulation)
        {
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.StartsWith("v "))
                        {
                            string[] tokens = line.Split(' ');
                            double x = double.Parse(tokens[1]);
                            double y = double.Parse(tokens[2]);
                            double z = double.Parse(tokens[3]);
                            Point3D point = new Point3D(x, y, z);
                            triangulation.UniquePoints.Add(point);
                        }
                        else if (line.StartsWith("vn "))
                        {
                            string[] tokens = line.Split(' ');
                            double x = double.Parse(tokens[1]);
                            double y = double.Parse(tokens[2]);
                            double z = double.Parse(tokens[3]);
                            Point3D point = new Point3D(x, y, z);
                            triangulation.UniqueNormals.Add(point);
                        }
                        else if (line.StartsWith("f "))
                        {
                            string[] tokens = line.Split(' ');
                            int v1 = int.Parse(tokens[1].Split('/')[0]) - 1;
                            int v2 = int.Parse(tokens[2].Split('/')[0]) - 1;
                            int v3 = int.Parse(tokens[3].Split('/')[0]) - 1;
                            int normalIndex = int.Parse(tokens[1].Split('/')[2]) - 1;
                            Triangle triangle = new Triangle(v1, v2, v3);
                            triangle.SetNormalIndex(normalIndex);
                            triangulation.Triangles.Add(triangle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading OBJ file: " + ex.Message);
            }
        }

    }
}

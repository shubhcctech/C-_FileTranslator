using ComputationalGeometry;
using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    internal class STLReader
    {
        public void ReadSTL(string filePath, Triangulation triangulation)
        {
            try
            {
                using (StreamReader inputFile = new StreamReader(filePath))
                {
                    // Map to store unique points and their corresponding indices
                    Dictionary<Point3D, int> mappedCoordinates = new Dictionary<Point3D, int>();
                    Dictionary<Point3D, int> mappedNormals = new Dictionary<Point3D, int>();
                    int count = 1;
                    int normalIndex = 0;
                    int index1 = 0;
                    int index2 = 0;
                    int index3 = 0;
                    string line;

                    while ((line = inputFile.ReadLine()) != null)
                    {
                        if (line.Contains("facet normal"))
                        {
                            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            double x = double.Parse(tokens[2]);
                            double y = double.Parse(tokens[3]);
                            double z = double.Parse(tokens[4]);
                            Point3D point = new Point3D(x, y, z);

                            // Check if the point is already mapped
                            if (!mappedNormals.ContainsKey(point))
                            {
                                mappedNormals[point] = triangulation.UniqueNormals.Count;
                                triangulation.UniqueNormals.Add(point);
                            }

                            normalIndex = mappedNormals[point];
                        }
                        // Check if the line contains "vertex"
                        else if (line.Contains("vertex"))
                        {
                            // Extract x, y, z coordinates from the line
                            string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            double x = double.Parse(tokens[1]);
                            double y = double.Parse(tokens[2]);
                            double z = double.Parse(tokens[3]);
                            Point3D point = new Point3D(x, y, z);

                            // Check if the point is already mapped
                            if (!mappedCoordinates.ContainsKey(point))
                            {
                                mappedCoordinates[point] = triangulation.UniquePoints.Count;
                                triangulation.UniquePoints.Add(point);
                            }

                            // Assign indices based on the mapping
                            if (count == 1)
                            {
                                index1 = mappedCoordinates[point];
                                count++;
                            }
                            else if (count == 2)
                            {
                                index2 = mappedCoordinates[point];
                                count++;
                            }
                            else if (count == 3)
                            {
                                index3 = mappedCoordinates[point];
                                count++;
                            }

                            // When three vertices are processed, create a triangle and reset count
                            if (count == 4)
                            {
                                Triangle triangle = new Triangle(index1, index2, index3);
                                triangle.SetNormalIndex(normalIndex);
                                triangulation.Triangles.Add(triangle);
                                count = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading STL file: " + ex.Message);
            }
        }
    }
}

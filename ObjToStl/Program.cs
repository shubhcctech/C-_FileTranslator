using ComputationalGeometry;
using FileWriter;
using System.Xml;
using FileReader;

namespace ObjToStl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "D:\\Shubham_Workspace\\C#\\Assignments\\FileTranslator\\ObjToStl\\Resources\\";
                string outputPath = "D:\\Shubham_Workspace\\C#\\Assignments\\FileTranslator\\ObjToStl\\OutputFiles\\";

                Console.WriteLine("Enter the relative path to the input OBJ file:");
                string inputRelativePath = Console.ReadLine();
                string inputFilePath = System.IO.Path.Combine(filePath, inputRelativePath);

                Console.WriteLine("Enter the relative path to the output STL file:");
                string outputRelativePath = Console.ReadLine();
                string outputFilePath = System.IO.Path.Combine(outputPath, outputRelativePath);

                Triangulation triangulation = new Triangulation();
               
                OBJReader objReader = new OBJReader();
                objReader.ReadOBJ(inputFilePath, triangulation);

                STLWriter stlWriter = new STLWriter();
                stlWriter.WriteSTL(outputFilePath, triangulation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

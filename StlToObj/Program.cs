using Geometry;
using ComputationalGeometry;
using FileReader;
using FilerWriter;

namespace STLTOOBJ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string baseDirectory = "D:\\Shubham_Workspace\\C#\\Assignments\\FileTranslator\\STLTOOBJ\\Resources\\";
                string baseDirectory1 = "D:\\Shubham_Workspace\\C#\\Assignments\\FileTranslator\\STLTOOBJ\\OutputFiles\\";

                Console.WriteLine("Enter the relative path to the input STL file:");
                string inputRelativePath = Console.ReadLine();
                string inputFilePath = System.IO.Path.Combine(baseDirectory, inputRelativePath);

                Console.WriteLine("Enter the relative path to the output OBJ file:");
                string outputRelativePath = Console.ReadLine();
                string outputFilePath = System.IO.Path.Combine(baseDirectory1, outputRelativePath);

                Triangulation triangulation = new Triangulation();
                STLReader stlReader = new STLReader();
                stlReader.ReadSTL(inputFilePath, triangulation);

                OBJWriter objWriter = new OBJWriter();
                objWriter.WriteOBJ(outputFilePath, triangulation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

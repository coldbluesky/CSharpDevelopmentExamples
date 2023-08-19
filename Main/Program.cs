
using FileOperations;

namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string path = @"C:\Users\Administrator\Desktop\book\config.ini";
            Console.WriteLine(BasicFileOperations.INIRead("server", "RemotelP", path));
            //BasicFileOperations.CreateXml(@"C:\Users\Administrator\Desktop");
            BasicFileOperations.AddElementUnderRoot(@"C:\Users\Administrator\Desktop\default.xml");
        }
    }
}
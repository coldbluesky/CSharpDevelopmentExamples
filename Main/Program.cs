
using FileOperations;

namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string path = @"C:\Users\Administrator\Desktop\book";
            Console.WriteLine(BasicFileOperations.INIRead("server", "RemotelP", path));
            //BasicFileOperations.CreateXml(@"C:\Users\Administrator\Desktop");
            var a =   BasicFileOperations.GetFileIcons(path);
        }
    }
}
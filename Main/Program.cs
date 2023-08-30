
using FileOperations;
using FileOperations.Enum;

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
            Console.WriteLine(BasicFileOperations.FileCommuniteUnite(@"C:\Users\Administrator\Desktop\book\新建文件夹", @"C:\Users\Administrator\Desktop\book\新建文件夹\new.pdf"));

        }
    }
}
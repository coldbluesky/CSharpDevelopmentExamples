
using FileOperations;

namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string path = @"C:\Users\Administrator\Desktop\book";
            Console.WriteLine(BasicFileOperations.GetLastWriteTime(@"C:\Users\Administrator\Desktop\book\C 开发实例大全(基础卷) .epub"));
            BasicFileOperations.GetAllFiles(@"C:\Users\Administrator\Desktop\book\",ref list);

        }
    }
}

using FileOperations;

namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string path = @"C:\Users\Administrator\Desktop\周报地址.txt";
            BasicFileOperations.CopyFile(path, @"C:\Users\Administrator\Desktop\book\周报地址.txt",100);

        }
    }
}
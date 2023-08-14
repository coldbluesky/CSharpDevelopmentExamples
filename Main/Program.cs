
using FileOperations;

namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BasicFileOperations.GetLastWriteTime(@"C:\Users\Administrator\Desktop\book\C 开发实例大全(基础卷) .epub"));
        }
    }
}
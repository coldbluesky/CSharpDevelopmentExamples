
using FileOperations;
using FileOperations.Enum;
using EfficientOffice.ByEPPlus;
namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Administrator\Desktop\book\s.ini";
            BasicFileOperations.INIWrite("zhangsan","age","18",path); 

        }
    }
}
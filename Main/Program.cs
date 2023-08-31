
using FileOperations;
using FileOperations.Enum;
using EfficientOffice.ByEPPlus;
namespace CSharpDevelopmentExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Administrator\Desktop\book";
            //EExcel.CreateEmpty(path);
            EExcel.ClearPassword(Path.Combine(path,"empty.xlsx"),"234");

        }
    }
}
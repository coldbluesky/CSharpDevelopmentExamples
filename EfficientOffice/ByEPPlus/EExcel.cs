using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace EfficientOffice.ByEPPlus
{
    /// <summary>
    /// 用EPPlus实现的excel操作,不支持xls格式
    /// 6.2官方文档地址:https://epplussoftware.com/docs/6.2/api/index.html
    /// </summary>
    public static class EExcel
    {
        public static ExcelPackage EInstance()
        {
            SetLicenseContext();
            return new ExcelPackage();
        }
        public static ExcelPackage EInstance(string path)
        {
            SetLicenseContext();
            return new ExcelPackage(path);
        }
        public static ExcelPackage EInstance(string path, string pwd)
        {
            SetLicenseContext();
            return new ExcelPackage(path, pwd);
        }
        public static void SetLicenseContext()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public static void CreateEmpty(string path)
        {
            using (var package = EInstance())
            {
                var sheet = package.Workbook.Worksheets.Add("sheet1");
                package.SaveAs(Path.Combine(path, "empty.xlsx"));
            }
        }
        /// <summary>
        /// 第一次设置密码
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Pwd"></param>
        public static void SetPassword(string path, string pwd)
        {
            using (var package = EInstance(path))
            {
                package.Save(pwd);
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newPwd"></param>
        /// <param name="oldPwd"></param>
        public static void SetPassword(string path, string newPwd, string oldPwd)
        {
            using (var package = EInstance(path,oldPwd))
            {
                package.Save(newPwd);
            }
        }

        public static void ClearPassword(string path, string pwd)
        {
            using (var package = EInstance(path, pwd))
            {
                package.Encryption.Password = null;
                package.Save();
            }
        }

        public static void AddBatchWorksheets(string path, int sheetNum)
        {
            using (var package = EInstance(path))
            {
                for (int i = 0; i < sheetNum; i++)
                {
                    try
                    {
                        package.Workbook.Worksheets.Add($"sheet{i + 1}");

                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
                package.Save();
            }
        }
        public static void DeleteWorksheet(string path, string sheetName)
        {
            using (var package = EInstance(path))
            {
                package.Workbook.Worksheets.Delete(sheetName);
                package.Save();

            }
        }

       
    }

}
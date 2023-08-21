using FileOperations.Enum;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Reflection.Metadata;
using System;
using System.Linq;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace FileOperations
{
    /// <summary>
    /// 文件基本操作
    /// </summary>
    public static class BasicFileOperations
    {
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="path"></param>
        /// <param name="eFileSize"></param>
        /// <returns></returns>
        #region 获取文件属性


        public static string GetFileSize(string path, EFileSize eFileSize = EFileSize.Kb)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            double size = Convert.ToDouble(fs.Length);
            switch (eFileSize)
            {
                case EFileSize.Byte:
                    return size.ToString();
                case EFileSize.Kb:
                    size = size / 1024;
                    break;
                case EFileSize.Mb:
                    size = size / 1024 / 1024;
                    break;
                case EFileSize.Gb:
                    size = size / 1024 / 1024 / 1024;
                    break;
                default:
                    break;
            }
            if (size < 0.001)
            {
                return "请调整文件大小单位！";
            }

            return size.ToString("0.000") + eFileSize.ToString();
        }

        public static string GetFileExtensionName(string path)
        {
            //FileInfo fileInfo = new FileInfo(path);
            //return fileInfo.Extension;
            return Path.GetExtension(path);
        }

        public static string GetCreateTime(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.CreationTime.ToString();
        }

        public static string GetLastWriteTime(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.LastWriteTime.ToString();
        }

        public static string GetInvalidFileNameChar()
        {
            string result = new(Path.GetInvalidFileNameChars());
            return result;
        }
        [DllImport("Kernel32.dll")]
        public static extern Int16 GetShortPathName(string longN, StringBuilder shortN, Int16 buffer);

        public static string GetShortName(string path)
        {
            StringBuilder shortName = new StringBuilder(256);
            GetShortPathName(path, shortName, 256);
            return shortName.ToString();
        }

        //public static bool IsAvailable()
        //{
        //    isf
        //}
        #endregion

        #region 操作文件


        public static void CreateFile(string path)
        {
            File.Create(path);
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public static void Temp()
        {

            FileInfo fileInfo = new FileInfo(Path.GetTempFileName());
            fileInfo.AppendText();

        }
        /// <summary>
        /// 根据当前时间创建文件夹
        /// </summary>
        public static void CreateFileByDateTime(string createPath)
        {
            File.Create(createPath + @"/" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt");
        }

        public static bool IsFileExist(string path)
        {
            return File.Exists(path);
        }
        /// <summary>
        /// 递归获取文件下的所有文件以及子文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="result"></param>
        public static void GetAllFiles(string path, ref List<string> result)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var fileSystemInfos = directoryInfo.GetFileSystemInfos();
            foreach (var item in fileSystemInfos)
            {
                if (item.Attributes == FileAttributes.Directory)
                {
                    GetAllFiles(item.FullName, ref result);
                }
                else
                {
                    result.Add(item.Name);

                }
            }
        }
        public static FileInfo? GetAllFile(string path, string fileName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var fileSystemInfos = directoryInfo.GetFileSystemInfos();
            foreach (var item in fileSystemInfos)
            {
                if (item.Name.Contains(fileName))
                {
                    return item as FileInfo;
                }
                if (item.Attributes == FileAttributes.Directory)
                {
                    GetAllFile(item.FullName, fileName);
                }

            }
            return null;

        }

        public static Dictionary<string, string>? SearchFile(string path, string fileName)
        {

            var result = GetAllFile(path, fileName);
            if (result == null) return null;
            Dictionary<string, string>? dictionary = new Dictionary<string, string>();

            dictionary["name"] = result.Name;
            dictionary["fullPath"] = result.FullName;
            dictionary["createTiem"] = result.CreationTime.ToString();
            return dictionary;

        }

        public static void Modifyfileattribute(string path, FileAttributes fa)
        {
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Attributes = fa;
        }

        public static void RenameFile(string path, string newName)
        {
            FileSystem.RenameFile(path, newName);
        }
        public static void RenameDirectory(string path, string newName)
        {
            FileSystem.RenameDirectory(path, newName);
        }

        public static void CopyFile(string fromFile, string toFile, int secSize)
        {
            using (File.Create(toFile)) { }

            FileStream toFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);
            FileStream fromFileOpen = new FileStream(fromFile, FileMode.Open, FileAccess.Read);
            int fileSize;
            if (fromFileOpen.Length > secSize)
            {
                byte[] buffer = new byte[secSize];
                int copied = 0;
                while (copied <= (int)fromFileOpen.Length - secSize)
                {
                    //读取进buffer的长度
                    fileSize = fromFileOpen.Read(buffer, 0, secSize);
                    fromFileOpen.Flush();
                    toFileOpen.Write(buffer, 0, secSize);
                    fromFileOpen.Flush();
                    toFileOpen.Position = fromFileOpen.Position;
                    //记录已经复制的长度
                    copied += fileSize;
                }
                int left = (int)fromFileOpen.Length - copied;
                fromFileOpen.Read(buffer, 0, left);
                fromFileOpen.Flush();
                toFileOpen.Write(buffer, 0, left);
                fromFileOpen.Flush();

            }
            else
            {
                byte[] buffer = new byte[fromFileOpen.Length];

                fromFileOpen.Read(buffer, 0, (int)fromFileOpen.Length);
                fromFileOpen.Flush();
                toFileOpen.Write(buffer, 0, (int)fromFileOpen.Length);
                fromFileOpen.Flush();
            }

            toFileOpen.Close();
            toFileOpen.Dispose();
            fromFileOpen.Close();
            fromFileOpen.Dispose();

        }


        public static void CopyFiles(IEnumerable<string> fromFiles, string toFiles)
        {
            foreach (var fromFile in fromFiles)
            {
                CopyFile(fromFile, toFiles, 256);
            }
        }
        #endregion
        /*GetPrivateProfileString
            lpAppName           表示INI文件内部根节点的值
            lpKeyName           表示根节点下子标记的值
            IpDefault           表示当标记值未设定或不存在时的默认值
            lpReturnedString    表示返回读取节点的值
            nSize               表示读取的节点内容的最大容量
            lpFileName          表示文件的全路径
        */
        /*WritePrivateProfileString
            mpAppName   表示INI文件内部根节点的值
            mpKeyName   表示将要修改的标记名称
            mpDefault   表示想要修改的内容
            mpFileName  表示INI文件的全路径
        */
        #region 操作ini文件
        //引入外部dll，定义的方法名必须跟dll里的一致否则报错;
        //方法的参数个数必须一致，否则无效;
        //参数名字可以不一致
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string IAppName, string lpKeyName, string IpDefault,
            StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(string mpAppName, string mpKeyName, string mpDefault, string mpFileName);

        public static string INIRead(string section, string key, string path)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", stringBuilder, 255, path);
            return stringBuilder.ToString();
        }
        public static void INIWrite(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        #endregion

        #region 操作XML文件
        public static DataSet? LoadXml(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(path);
            return ds;
        }
        public static void CreateXml(string path)
        {
            string defaultName = "default.xml";
            //创建xml文件如果不添加顶级节点，就会报错
            XDocument xDocument = new XDocument(new XDeclaration("1", "utf-8", "yes"), new XElement("root"));
            xDocument.Save(path + @"\" + defaultName);
        }
        public static void AddElementUnderRoot(string path)
        {
            XElement xe = XElement.Load(path);
            XElement p = new XElement("people", new XAttribute("ID", "2"));
            xe.Add(p);
            xe.Save(path);
            
        }

        public static void AddElementByAttribute(string path)
        {
            XElement xe = XElement.Load(path);
           
            XElement x = xe.Elements("people").Where(a => a.Attribute("ID").Value == "1").FirstOrDefault();
            x.Add(new XElement("name",new XAttribute("ID",3),"zhangsan"));
            xe.Save(path);
        }
        #endregion

        #region 其他
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr handle,int ucmd);
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr handle,StringBuilder text, int MaxCount);
        //public static void GetWindowText()
        //{
        //    StringBuilder stringBuilder = new StringBuilder(2560);
        //    IntPtr currentHandle = GetWindow(this.Handle,GW_HWNDNEXT);
        //    int v = GetWindowText(currentHandle, stringBuilder,2560);
        //    return stringBuilder.ToString();
        //}
        #endregion
    }
}
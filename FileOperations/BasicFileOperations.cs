using FileOperations.Enum;
using System;

namespace FileOperations
{
    /// <summary>
    /// 文件基本操作
    /// </summary>
    public static  class BasicFileOperations
    {
        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="path"></param>
        /// <param name="eFileSize"></param>
        /// <returns></returns>
      
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
           
            return size.ToString("0.000")+ eFileSize.ToString();
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
            string result = new(Path.GetInvalidFileNameChars()) ;
            return result;
        }
    }
}
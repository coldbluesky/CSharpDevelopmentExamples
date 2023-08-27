using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations.Model
{
    public class IconInfoModel
    {
        /// <summary>
        /// 文件夹或者文件的绝对路径
        /// </summary>
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public DateTime LastWriteTime { get; set; }
        public IntPtr HIcon { get; set; }
        public IntPtr IIcon { get; set; }

    }
}

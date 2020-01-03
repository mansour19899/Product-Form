using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Form
{
    class ManageFileFolder
    {
        public ManageFileFolder()
        {

        }
        public string copy(string path)
        {
            string sourcePath = path;
            string sourceFile = sourcePath;
            string targetPath = @"D:\Product-image";
            DateTime date = DateTime.Now;
            string id = date.Year.ToString()+date.Month.ToString()+date.Day.ToString()+date.Hour.ToString()+date.Minute.ToString()+date.Second.ToString();
            var newName = id+"."+sourcePath.Split('.').LastOrDefault();


            string destFile = System.IO.Path.Combine(targetPath, newName);
            System.IO.File.Copy(sourceFile, destFile, true);
            return destFile;
        }
    }
}

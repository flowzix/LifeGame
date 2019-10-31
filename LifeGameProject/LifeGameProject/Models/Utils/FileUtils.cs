using Microsoft.Win32;
using System.IO;

namespace LifeGameProject.Models
{
    public class FileUtils
    {
        public static string OpenFileDialogForStringOutput()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                return File.ReadAllText(ofd.FileName);
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public class clsImageManager
    {
        private static string folderPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Images");
        static clsImageManager()
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }
        public static string SelectImage(PictureBox pb)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb.ImageLocation = ofd.FileName;
                return ofd.FileName;
            }
            return null;
        }
        public static string SaveImage(string sourcePath)
        {
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
                return "";

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
            string destPath = Path.Combine(folderPath, fileName);

            File.Copy(sourcePath, destPath, true);

            return destPath;
        }
        public static void DeleteImage(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                File.Delete(path);
        }
        public static string UpdateImage(string oldPath, string newPath)
        {
            DeleteImage(oldPath);
            return SaveImage(newPath);
        }
    }
}

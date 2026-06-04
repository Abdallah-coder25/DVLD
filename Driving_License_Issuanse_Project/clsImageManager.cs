using System;
using System.Collections.Generic;
using System.Drawing;
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
           // OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Images|*.jpg;*.jpeg;*.png";

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    pb.ImageLocation = ofd.FileName;
            //    return ofd.FileName;
            //}
            //return null;
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Images|*.jpg;*.jpeg;*.png";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // تحميل الصورة في الذاكرة بدون ربط الملف
                        using (Image img = Image.FromFile(ofd.FileName))
                        {
                            pb.Image = new Bitmap(img);
                        }

                        return ofd.FileName; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
        public static string SaveImage(string sourcePath)
        {
            //if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            //    return "";

            //string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
            //string destPath = Path.Combine(folderPath, fileName);
            //try
            //{
            //    File.Copy(sourcePath, destPath, true);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error saving image: " + ex.Message);
            //    return "";
            //}
            //return destPath;
            try
            {
                if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
                    return null;

                string fileName = Guid.NewGuid() + Path.GetExtension(sourcePath);
                string destPath = Path.Combine(folderPath, fileName);

                File.Copy(sourcePath, destPath, true);

                return destPath;
            }
            catch
            {
                return null;
            }
        }
        public static bool DeleteImage(string path)
        {
            //if (!string.IsNullOrEmpty(path) && File.Exists(path))
            //       File.Delete(path);
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                    return false;

                if (!path.StartsWith(folderPath))
                    return false;

                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
        public static string UpdateImage(string oldPath, string newSourcePath)
        {
            //DeleteImage(oldPath);
            //return SaveImage(newPath);
            try
            {
                string newPath = SaveImage(newSourcePath);

                if (!string.IsNullOrEmpty(newPath))
                {
                    DeleteImage(oldPath);
                    return newPath;
                }
            }
            catch 
            {
             //
            }

            return oldPath;
        }
       
    }
}

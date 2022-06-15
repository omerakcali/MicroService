using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MicroService{
    public class ImageSaver{
        
        public static void UploadImage(Bitmap bmp, string type){
            var newB = new Bitmap(150, 150, PixelFormat.Format24bppRgb);
            using (Graphics gr = Graphics.FromImage(newB)){
                gr.DrawImage(bmp, new Rectangle(0, 0, newB.Width, newB.Height));
            }

            bmp = newB;
            string dir = Environment.CurrentDirectory;

            string filename = ConvertToUnixTimestamp(DateTime.Now) + ".png";
            var path = Path.Combine(dir, "Dataset", type);
            System.IO.Directory.CreateDirectory(path);
            bmp.Save(path + @"\" + filename);
        }

        public static double ConvertToUnixTimestamp(DateTime date){
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
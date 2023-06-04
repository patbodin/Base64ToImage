using Base64ToImage.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Base64ToImage.Model
{
    class ImageElement
    {
        public Image img { get; set; }
        public string StrBase64Input { get; set; }
        public string StrOutputPath { get; set; }
        public string ImgExtension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ImageElement()
        {

        }

        public bool IsBase64String()
        {
            string str = StrBase64Input.Trim();
            return (str.Length % 4 == 0) && Regex.IsMatch(str, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }

        public Image Base64ToImage()
        {
            byte[] bytes = Convert.FromBase64String(StrBase64Input);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                img = Image.FromStream(ms);
            }

            ImgExtension = ImageService.ImageType(img);
            Width = img.Width;
            Height = img.Height;

            return img;
        }

        

    }
}

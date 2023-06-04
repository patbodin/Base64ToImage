using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64ToImage.Service
{
    public static class ImageService
    {
        public static string ImageType(this Image image)
        {
            if (image.RawFormat.Equals(ImageFormat.Bmp))
            {
                return "Bmp";
            }
            else if (image.RawFormat.Equals(ImageFormat.MemoryBmp))
            {
                return "BMP";
            }
            else if (image.RawFormat.Equals(ImageFormat.Emf))
            {
                return "Emf";
            }
            else if (image.RawFormat.Equals(ImageFormat.Wmf))
            {
                return "Wmf";
            }
            else if (image.RawFormat.Equals(ImageFormat.Gif))
            {
                return "Gif";
            }
            else if (image.RawFormat.Equals(ImageFormat.Jpeg))
            {
                return "Jpeg";
            }
            else if (image.RawFormat.Equals(ImageFormat.Png))
            {
                return "Png";
            }
            else if (image.RawFormat.Equals(ImageFormat.Tiff))
            {
                return "Tiff";
            }
            else if (image.RawFormat.Equals(ImageFormat.Exif))
            {
                return "Exif";
            }
            else if (image.RawFormat.Equals(ImageFormat.Icon))
            {
                return "Ico";
            }

            return "";
        }

        public static ImageFormat ImageType(this string image)
        {
            if (image.Trim().ToLower() == "bmp")
            {
                //return "Bmp";
                return ImageFormat.Bmp;
            }
            else if (image.Trim().ToLower() == "emf")
            {
                return ImageFormat.Emf;
            }
            else if (image.Trim().ToLower() == "wmf")
            {
                return ImageFormat.Wmf;
            }
            else if (image.Trim().ToLower() == "gif")
            {
                return ImageFormat.Gif;
            }
            else if (image.Trim().ToLower() == "jpeg" || image.Trim().ToLower() == "jpg")
            {
                return ImageFormat.Jpeg;
            }
            else if (image.Trim().ToLower() == "png")
            {
                return ImageFormat.Png;
            }
            else if (image.Trim().ToLower() == "tiff" || image.Trim().ToLower() == "tif")
            {
                return ImageFormat.Tiff;
            }
            else if (image.Trim().ToLower() == "exif")
            {
                return ImageFormat.Exif;
            }
            else if (image.Trim().ToLower() == "ico")
            {
                return ImageFormat.Icon;
            }

            return null;
        }
    }
}

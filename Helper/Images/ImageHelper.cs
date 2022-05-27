using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;

namespace Helper.Images
{
    public class ImageHelper
    {
        public static List<byte[]> GetImageFromRequest(IFormFileCollection imagesFromRequest)
        {
            var images = new List<byte[]>();

            foreach (var image in imagesFromRequest)
            {
                var fileInfo = new FileInfo(image.FileName);
                using var stream = image.OpenReadStream();

                using var ms = ConvertToPng(stream, fileInfo);
                images.Add(ms.ToArray());
            }

            return images;
        }

        public static MemoryStream ConvertToPng(Stream stream, FileInfo fileInfo)
        {
            var ms = new MemoryStream();
            if (GetTypeImage(fileInfo.Extension) is TypeImage.Png)
            {
                stream.CopyTo(ms);
                return ms;
            }
                
            using var bitmap = new Bitmap(Image.FromStream(stream));
            bitmap.Save(ms, ImageFormat.Png);

            return ms;
        }

        private static TypeImage GetTypeImage(string extension)
            => extension switch
            {
                ".jpeg" => TypeImage.Jpeg,
                ".jpg" => TypeImage.Jpg,
                ".png" => TypeImage.Png,
                _ => TypeImage.Undefined
            };

        private enum TypeImage
        {
            Jpeg,
            Jpg,
            Png,
            Undefined
        }
    }
}

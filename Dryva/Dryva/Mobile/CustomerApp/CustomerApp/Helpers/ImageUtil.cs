using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace CustomerApp.Helpers
{
    public class ImageUtil
    {
        public static byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static Stream GetBytesAsStream(byte[] bytes)
        {
            if (bytes == null)
                return null;

            return new MemoryStream(bytes);
        }

        public static ImageSource GetImageSource(Stream stream)
        {
            ImageSource imgsource = null;
            if (stream != null)
            {
                imgsource = ImageSource.FromStream(() => stream);
            }
            return imgsource;
        }

        public static ImageSource GetImageSource(byte[] bytes)
        {
            ImageSource imgSource = null;
            try
            {
                var stream = GetBytesAsStream(bytes);                
                imgSource = GetImageSource(stream);
            }
            catch
            {
            }
            return imgSource;
        }
    }
}

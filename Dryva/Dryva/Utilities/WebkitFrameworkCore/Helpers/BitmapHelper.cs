using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebkitFrameworkCore.Helpers
{
    public enum CropHorizontalAlignment
    {
        Left,
        Center,
        Right
    }

    public enum CropVerticalAlignment
    {
        Top,
        Middle,
        Bottom
    }

    /// <summary>
    /// Represents a bitmap helper class.
    /// </summary>
    public static class BitmapHelper
    {
        /// <summary>
        /// Converts a bitmap to a bitonal image.
        /// </summary>
        /// <param name="original">The original bitmap.</param>
        /// <param name="threshold">The threshold.</param>
        /// <returns>Bitmap.</returns>
        public static Bitmap ConvertToBitonal(this Bitmap original, int threshold)
        {
            Bitmap source;

            // If original bitmap is not already in 32 BPP, ARGB format, then convert
            if (original.PixelFormat != PixelFormat.Format32bppArgb)
            {
                source = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
                source.SetResolution(original.HorizontalResolution, original.VerticalResolution);

                using (var g = Graphics.FromImage(source))
                {
                    g.DrawImageUnscaled(original, 0, 0);
                }
            }
            else
            {
                source = original;
            }

            // Lock source bitmap in memory
            var sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // Copy image data to binary array
            var imageSize = sourceData.Stride * sourceData.Height;
            var sourceBuffer = new byte[imageSize];
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize);

            // Unlock source bitmap
            source.UnlockBits(sourceData);

            // Create destination bitmap
            var destination = new Bitmap(source.Width, source.Height, PixelFormat.Format1bppIndexed);
            destination.SetResolution(original.HorizontalResolution, original.VerticalResolution);

            // Lock destination bitmap in memory
            var destinationData = destination.LockBits(new Rectangle(0, 0, destination.Width, destination.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);

            // Create destination buffer
            imageSize = destinationData.Stride * destinationData.Height;
            var destinationBuffer = new byte[imageSize];

            var sourceIndex = 0;
            var destinationIndex = 0;
            var pixelTotal = 0;
            byte destinationValue = 0;
            var pixelValue = 128;
            var height = source.Height;
            var width = source.Width;

            // Iterate lines
            for (var y = 0; y < height; y++)
            {
                sourceIndex = y * sourceData.Stride;
                destinationIndex = y * destinationData.Stride;
                destinationValue = 0;
                pixelValue = 128;

                // Iterate pixels
                for (var x = 0; x < width; x++)
                {
                    // Compute pixel brightness (i.e. total of Red, Green, and Blue values) - Thanks murx
                    //                           B                             G                              R
                    pixelTotal = sourceBuffer[sourceIndex] + sourceBuffer[sourceIndex + 1] + sourceBuffer[sourceIndex + 2];
                    if (pixelTotal > threshold)
                    {
                        destinationValue += (byte)pixelValue;
                    }
                    if (pixelValue == 1)
                    {
                        destinationBuffer[destinationIndex] = destinationValue;
                        destinationIndex++;
                        destinationValue = 0;
                        pixelValue = 128;
                    }
                    else
                    {
                        pixelValue >>= 1;
                    }
                    sourceIndex += 4;
                }

                if (pixelValue != 128)
                {
                    destinationBuffer[destinationIndex] = destinationValue;
                }
            }

            // Copy binary image data to destination bitmap
            Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, imageSize);

            // Unlock destination bitmap
            destination.UnlockBits(destinationData);

            // Dispose of source if not originally supplied bitmap
            if (source != original)
            {
                source.Dispose();
            }

            // Return
            return destination;
        }

        /// <summary>
        /// Gets the thumbnail image.
        /// </summary>
        /// <param name="stream">The input stream (From HttpPostedFileBase).</param>
        /// <param name="width">The width of the thumbnail image.</param>
        /// <param name="height">The height of the thumbnail image.</param>
        /// <returns>Image.</returns>
        public static Image GetThumbnailImage(this Stream stream, int width, int height)
        {
            return GetThumbnailImage(Image.FromStream(stream), width, height);
        }

        /// <summary>
        /// Gets the thumbnail image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="width">The width of the thumbnail image.</param>
        /// <param name="height">The height of the thumbnail image.</param>
        /// <returns>Image.</returns>
        public static Image GetThumbnailImage(this Image image, int width, int height)
        {
            Image thumbnail = image.GetThumbnailImage(width, height, () => { return true; }, new IntPtr());
            return thumbnail;
        }

        public static Bitmap CropBitmap(Bitmap bitmap, int width, int height,
            CropHorizontalAlignment horizontalAlignment, CropVerticalAlignment verticalAlignment)
        {
            var imageBounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            int srcX, srcY, destX, destY;

            if (bitmap.Width > width)
            {
                switch (horizontalAlignment)
                {
                    case CropHorizontalAlignment.Right:
                        srcX = bitmap.Width - width;
                        destX = 0;
                        break;

                    case CropHorizontalAlignment.Center:
                        srcX = (bitmap.Width - width) / 2;
                        destX = 0;
                        break;

                    case CropHorizontalAlignment.Left:
                    default:
                        srcX = destX = 0;
                        break;
                }
            }
            else
            {
                switch (horizontalAlignment)
                {
                    case CropHorizontalAlignment.Right:
                        srcX = 0;
                        destX = width - bitmap.Width;
                        break;

                    case CropHorizontalAlignment.Center:
                        srcX = 0;
                        destX = (width - bitmap.Width) / 2;
                        break;

                    case CropHorizontalAlignment.Left:
                    default:
                        srcX = destX = 0;
                        break;
                }
            }

            if (bitmap.Height > height)
            {
                switch (verticalAlignment)
                {
                    case CropVerticalAlignment.Bottom:
                        srcY = bitmap.Height - height;
                        destY = 0;
                        break;

                    case CropVerticalAlignment.Middle:
                        srcY = (bitmap.Height - height) / 2;
                        destY = 0;
                        break;

                    case CropVerticalAlignment.Top:
                    default:
                        srcY = destY = 0;
                        break;
                }
            }
            else
            {
                switch (verticalAlignment)
                {
                    case CropVerticalAlignment.Bottom:
                        srcY = 0;
                        destY = height - bitmap.Height;
                        break;

                    case CropVerticalAlignment.Middle:
                        srcY = 0;
                        destY = (height - bitmap.Height) / 2;
                        break;

                    case CropVerticalAlignment.Top:
                    default:
                        srcY = destY = 0;
                        break;
                }
            }

            var croppedBitmap = new Bitmap(width, height, bitmap.PixelFormat);
            var graphics = Graphics.FromImage(croppedBitmap);

            graphics.DrawImage(bitmap, new Rectangle(destX, destY, width, height),
                srcX, srcY, width, height, GraphicsUnit.Pixel);

            graphics.Dispose();
            bitmap.Dispose();

            return croppedBitmap;
        }

        public static byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            using (var stream = new MemoryStream(imageData))
            {
                // Load the bitmap 
                Image originalImage = Image.FromStream(stream);
                //
                float targetHeight = 0;
                float targetWidth = 0;
                //
                var _height = originalImage.Height;
                var _width = originalImage.Width;
                //
                if (_height > _width) // Height (71 for Avatar) is Master
                {
                    targetHeight = height;
                    float ratio = _height / height;
                    targetWidth = _width / ratio;
                }
                else // Width (61 for Avatar) is Master
                {
                    targetWidth = width;
                    float ratio = _width / width;
                    targetHeight = _height / ratio;
                }
                //
                Bitmap resizedImage = CropBitmap(new Bitmap(originalImage, (int)targetWidth, (int)targetHeight),
                    (int)width, (int)height, CropHorizontalAlignment.Center, CropVerticalAlignment.Middle);
                //Bitmap resizedImage = new Bitmap(originalImage, (int)targetWidth, (int)targetHeight);
                // 
                using (MemoryStream ms = new MemoryStream())
                {
                    var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoderParameters = new EncoderParameters(1);
                    var encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 30L);

                    encoderParameters.Param[0] = encoderParameter;
                    resizedImage.Save(ms, jpegEncoder, encoderParameters);
                    //resizedImage.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static void SaveToFile(byte[] imageData, string path)
        {
            using (var stream = new MemoryStream(imageData))
            {
                var image = Image.FromStream(stream);
                image.Save(path);
            }
        }

        /// <summary>
        /// Converts an image to base64 string.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>System.String.</returns>
        public static string ConvertToBase64Image(Image image, string mimeType)
        {
            using (var ms = new MemoryStream())
            {
                var format = FileTypeHelper.GetImageFormat(mimeType);
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// Converts an image to base64 string.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>System.String.</returns>
        public static string ConvertToBase64Image(Bitmap image, string mimeType)
        {
            return ConvertToBase64Image((Image)image, mimeType);
        }


        /// <summary>
        /// Returns a stringify web image.
        /// </summary>
        /// <param name="image">The image to stringify.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>System.String.</returns>
        public static string ToWebImage(this Image image, string mimeType)
        {
            var imageData = ConvertToBase64Image(image, mimeType);
            return string.Format("data:{0};base64,{1}", mimeType, imageData);
        }

        public static string ToWebImage(this byte[] imageData, string mimeType)
        {
            using (var stream = new MemoryStream(imageData))
            {
                var image = Image.FromStream(stream);
                string webImage = ToWebImage(image, mimeType);

                image.Dispose();
                return webImage;
            }
        }
        /// <summary>
        /// Returns a stringify web image.
        /// </summary>
        /// <param name="image">The image to stringify.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>System.String.</returns>
        public static string ToWebImage(this Bitmap image, string mimeType)
        {
            return ToWebImage((Image)image, mimeType);
        }

        /// <summary>
        /// Returns the image data from a stringify web image.
        /// </summary>
        /// <param name="base64Image">The stringify web image.</param>
        /// <returns>System.Byte[]</returns>
        public static byte[] ToBinaryImage(this string base64Image)
        {
            if (string.IsNullOrEmpty(base64Image))
                return null;

            var index = base64Image.IndexOf(',');
            var imageData = base64Image.Substring(index + 1);
            return Convert.FromBase64String(imageData);
        }

        /// <summary>
        /// Returns a binary web image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToBinaryWebImage(Image image, string mimeType)
        {
            var imageData = ConvertToBase64Image(image, mimeType);
            var sImg = string.Format("data:{0};base64,{1}", mimeType, imageData);
            return Encoding.Default.GetBytes(sImg);
        }

        /// <summary>
        /// Returns a binary web image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] ToBinaryWebImage(Bitmap image, string mimeType)
        {
            return ToBinaryWebImage((Image)image, mimeType);
        }

        public static string ToJpegWebImage(this byte[] imageData)
        {
            if (imageData == null)
                return null;
            return imageData.ToWebImage("image/jpg");
        }

        /// <summary>
        /// Estimates the size of the thumbnail.
        /// </summary>
        /// <param name="image">The image to estimate.</param>
        /// <param name="width">The thumbnail width.</param>
        /// <param name="height">The thumbnail height.</param>
        /// <returns>Size.</returns>
        public static Size EstimateThumbnailSize(Image image, int width, int height)
        {
            if (width > height)
            {
                var heightRatio = (float)height / image.Height;
                return new Size
                {
                    Width = (int)(image.Width * heightRatio),
                    Height = (int)(image.Height * heightRatio)
                };
            }
            else
            {
                var widthRatio = (float)width / image.Width;
                return new Size
                {
                    Width = (int)(image.Width * widthRatio),
                    Height = (int)(image.Height * widthRatio)
                };
            }
        }

        public static Image GetImage(this byte[] imageData)
        {
            if (imageData == null)
                return null;

            using (var stream = new MemoryStream(imageData))
            {
                var image = Image.FromStream(stream);
                return (Image)image.Clone();
            }
        }

    }
}

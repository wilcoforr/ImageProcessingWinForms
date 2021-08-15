using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using ImageProcessing.Extensions;
using ImageProcessing.CustomException;

namespace ImageProcessing
{
    /// <summary>
    /// Specifies what type of image processing algorithm should be applied to the 
    /// image
    /// </summary>
    public enum ImageProcessingType
    {
        ColorChannelFilterRed,
        ColorChannelFilterGreen,
        ColorChannelFilterBlue,
        Grayscale,
        Brightness,
        Contrast,
        Inverted,
        Gamma,
        DetectTolerance
    }

    /// <summary>
    /// ImageProcessor is where most of the algorithms are implemented.
    /// 
    /// ToDo: Perhaps they could be their own files, or grouped to make sense better.
    /// </summary>
    public static class ImageProcessor
    {
        #region Constants, Properties, Enums
        //since we are dealing only with 8bit BMPs - set the min and max
        public const int MAX_PIXEL_VALUE = Byte.MaxValue; //255

        public const int MIN_PIXEL_VALUE = Byte.MinValue; //0

        private const int BYTES_PER_PIXEL = 3; //for PixelFormat.Format24bppRgb

        //Some math helpers
        public static int Square(int i) => i * i;
        public static float Square(float f) => f * f;
        public static double Square(double d) => d * d;
        #endregion



        #region Process Bitmap algorithm

        /// <summary>
        /// Get a bitmap and get it ready for processing each pixel as 24 bit (3 bytes) RGB
        /// The processing is marked as `unsafe` because we are using a byte pointer to
        /// get the bitmap's pixel data. This is for superior performance than 
        /// Bitmap.GetPixel() and Bitmap.SetPixel()
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="imageProcessingType"></param>
        /// <param name="dynamicParams"></param>
        public static unsafe Bitmap ProcessBitmapFactory(Bitmap bitmap, 
            ImageProcessingType imageProcessingType, params object[] dynamicParams)
        {
            var rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //stride also called scan line
            //https://en.wikipedia.org/wiki/Pixel#/media/File:Pixel_geometry_01_Pengo.jpg
            int stride = bitmapData.Stride;

            byte* scan0 = (byte*)bitmapData.Scan0.ToPointer();

            for (int y = 0; y < bitmapData.Height; y++)
            {
                byte* row = scan0 + (y * stride);

                for (int x = 0; x < bitmapData.Width; x++)
                {
                    ProcessRow(row, x, imageProcessingType, dynamicParams);
                }
            }

            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }



        /// <summary>
        /// Process each row
        /// The main "guts" of the image processing is determied in the switch case,
        /// based on what ImageProcessingType should be applied.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="x"></param>
        /// <param name="imageProcessingType"></param>
        /// <param name="dynamicParams"></param>
        private static unsafe void ProcessRow(byte* row, int x, 
            ImageProcessingType imageProcessingType, params object[] dynamicParams)
        {
            try
            {
                int index = x * BYTES_PER_PIXEL;

                var color = new SimpleColor
                {
                    Red = row[index + 2],
                    Green = row[index + 1],
                    Blue = row[index]
                };

                switch (imageProcessingType)
                {
                    //color is passed as ref so that it can get set and not returned.
                    //ie instead of code like:
                    //  color = GetRedChannelColor(color);
                    //its
                    //  SetRedChannelColor(ref color);
                    //not intended to be a "performance" increase

                    //simple (no param) image processing algorithms
                    case ImageProcessingType.ColorChannelFilterRed:
                        SetRedChannelColor(ref color);
                        break;
                    case ImageProcessingType.ColorChannelFilterGreen:
                        SetGreenChannelColor(ref color);
                        break;
                    case ImageProcessingType.ColorChannelFilterBlue:
                        SetBlueChannelColor(ref color);
                        break;
                    case ImageProcessingType.Grayscale:
                        SetGrayscaleColor(ref color);
                        break;
                    case ImageProcessingType.Inverted:
                        SetInvertedColor(ref color);
                        break;


                    //dynamic params image processing algorithms
                    case ImageProcessingType.Brightness:
                        int brightness = Convert.ToInt32(dynamicParams[0]);
                        SetBrightnessColor(ref color, brightness);
                        break;
                    case ImageProcessingType.Contrast:
                        double contrast = Convert.ToDouble(dynamicParams[0]);
                        SetContrastColor(ref color, contrast);
                        break;
                    case ImageProcessingType.Gamma:
                        byte[] redGammaBytes = (byte[])dynamicParams[0];
                        byte[] greenGammaBytes = (byte[])dynamicParams[1];
                        byte[] blueGammaBytes = (byte[])dynamicParams[2];

                        SetGammaColor(ref color, redGammaBytes, greenGammaBytes, blueGammaBytes);
                        break;
                    case ImageProcessingType.DetectTolerance:
                        int toleranceSquared = Square(Convert.ToInt32(dynamicParams[3]));
                        byte searchedR = Convert.ToByte(dynamicParams[0]);
                        byte searchedG = Convert.ToByte(dynamicParams[1]);
                        byte searchedB = Convert.ToByte(dynamicParams[2]);

                        SetDetectColorTolerance(ref color, searchedR, searchedG, searchedB, toleranceSquared);
                        break;


                    //should never hit this...
                    default:
                        throw new ImageProcessingException($"Invalid, not implemented, or not found {nameof(ImageProcessingType)}");
                }

                SetRowBytes(row, index, color);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Set the data back to the row (byte*) mem location
        /// a "row" the pixel's [B][G][R] values
        /// https://en.wikipedia.org/wiki/Pixel#/media/File:Pixel_geometry_01_Pengo.jpg
        /// with 24bit Bitmaps, the first byte of the pixel is the blue channel,
        /// followed by green, then red. 
        /// this is opposed to the commonly expected Red-Green-Blue order. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="index"></param>
        /// <param name="color"></param>
        private static unsafe void SetRowBytes(byte* row, int index, SimpleColor color)
        {
            row[index + 2] = color.Red;
            row[index + 1] = color.Green;
            row[index] = color.Blue;
        }

        #endregion




        
        #region Image Processing Algorithms


        /// <summary>
        /// Remove Green and Blue pixel info
        /// </summary>
        /// <param name="color"></param>
        private static void SetRedChannelColor(ref SimpleColor color)
        {
            color.Green = MIN_PIXEL_VALUE;
            color.Blue = MIN_PIXEL_VALUE;
        }

        /// <summary>
        /// Remove Red and Blue pixel info
        /// </summary>
        /// <param name="color"></param>
        private static void SetGreenChannelColor(ref SimpleColor color)
        {
            color.Red = MIN_PIXEL_VALUE;
            color.Blue = MIN_PIXEL_VALUE;
        }

        /// <summary>
        /// Remove Red and Green pixel info
        /// </summary>
        /// <param name="color"></param>
        private static void SetBlueChannelColor(ref SimpleColor color)
        {
            color.Red = MIN_PIXEL_VALUE;
            color.Green = MIN_PIXEL_VALUE;
        }


        /// <summary>
        /// Set the brightness of a pixel
        /// </summary>
        /// <param name="color"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        private static void SetBrightnessColor(ref SimpleColor color, int brightness)
        {
            if (!brightness.IsBetween(-MAX_PIXEL_VALUE, MAX_PIXEL_VALUE))
            {
                throw new ArgumentOutOfRangeException(nameof(brightness));
            }

            color.Red = (color.Red + brightness).GetWithinByteRange();
            color.Green = (color.Green + brightness).GetWithinByteRange();
            color.Blue = (color.Blue + brightness).GetWithinByteRange();
        }



        /// <summary>
        /// A basic way to grayscale is to average the three RGB components
        /// aka: (R + G + B) / 3 ==> grayscale value, then make a new color with the
        /// R G B being the result (grayscale)
        /// However, Since our eyes see colors (wavelengths) in different intensity, the
        /// suggested HDTV standard is 0.2126 R + 0.7152 G + 0.0722 B for a 
        /// grayscale value
        /// 
        /// See luma coding in videos systems: https://en.wikipedia.org/wiki/Grayscale
        /// </summary>
        private static void SetGrayscaleColor(ref SimpleColor color)
        {
            byte grayRGB = Convert.ToByte(0.2126 * color.Red
                                + 0.7152 * color.Green
                                + 0.0722 * color.Blue);

            color.Red = grayRGB;
            color.Green = grayRGB;
            color.Blue = grayRGB;
        }


        /// <summary>
        /// Set the contrast of the image
        /// 
        /// https://en.wikipedia.org/wiki/Contrast_(vision)
        /// </summary>
        private static void SetContrastColor(ref SimpleColor color, double contrast)
        {
            color.Red = CalculateContrast(color.Red, contrast);
            color.Green = CalculateContrast(color.Green, contrast);
            color.Blue = CalculateContrast(color.Blue, contrast);
        }

        /// <summary>
        /// Calculate the contrast
        /// </summary>
        /// <param name="pixel"></param>
        /// <param name="contrast"></param>
        /// <returns></returns>
        private static byte CalculateContrast(byte pixel, double contrast)
        {
            double contrastPixel = pixel / (double)MAX_PIXEL_VALUE;
            contrastPixel -= 0.5;
            contrastPixel *= contrast;
            contrastPixel += 0.5;
            contrastPixel *= 255;

            return contrastPixel.GetWithinByteRange();
        }

        /// <summary>
        /// An inverted color value is simply the max value (255) minus the pixel's 
        /// RGB values.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private static void SetInvertedColor(ref SimpleColor color)
        {
            color.Red = (byte)(MAX_PIXEL_VALUE - color.Red);
            color.Green = (byte)(MAX_PIXEL_VALUE - color.Green);
            color.Blue = (byte)(MAX_PIXEL_VALUE - color.Blue);
        }

        /// <summary>
        /// Varying the amount of gamma filtering changes not only the brightness, but 
        /// also the ratios of red to green to blue. We produce a new color array and
        /// take the colors from that as the respective components in the image. 
        /// The input values range between 0.2 to 5.
        /// 
        /// https://en.wikipedia.org/wiki/Gamma_correction
        /// </summary>
        private static void SetGammaColor(ref SimpleColor color, byte[] redGammaBytes, byte[] greenGammaBytes, byte[] blueGammaBytes)
        {
            color.Red = redGammaBytes[color.Red];
            color.Green = greenGammaBytes[color.Green];
            color.Blue = blueGammaBytes[color.Blue];
        }


        /// <summary>
        /// Algorithm enhanced/adopted from: 
        /// https://www.codeproject.com/Articles/617613/Fast-Pixel-Operations-in-NET-With-and-Without-unsa
        /// Matching pixels within the tolerance will be white
        /// Non matching pixels will be black
        /// </summary>
        private static void SetDetectColorTolerance(ref SimpleColor color, byte searchedR, byte searchedG, byte searchedB, int toleranceSquared)
        {
            //the difference between the pixels values from the searched value
            int diffR = color.Red - searchedR;
            int diffG = color.Green - searchedG;
            int diffB = color.Blue - searchedB;


            int distance = Square(diffR) + Square(diffG) + Square(diffB);

            //set all three colors to either 0 or 255 (ie min or max pixel value)
            color.Red =
                color.Green =
                    color.Blue = (distance > toleranceSquared) ? (byte)MIN_PIXEL_VALUE : (byte)MAX_PIXEL_VALUE;
        }



        #endregion Image Processing Algorithms




    }
}

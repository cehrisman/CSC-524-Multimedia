using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace ImageProcess
{
    public class ProcessImage 
    {

       
        //
        //basic processing functions-------------------------------------------
        //

        /// <summary>
        /// This class function fills the base image with white.
        /// </summary>
        /// <param name="image">image to edit</param>
        public static void FillWhite(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    image[c, r] = Color.White;
                }
            }

        }

        /// <summary>
        /// This class function fills the base image with black.
        /// </summary>
        /// <param name="image">image to edit</param>
        public static void FillBlack(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    image[c, r] = Color.Black;
                }
            }

        }

        /// <summary>
        /// Example filter that computes a negative image.
        /// </summary>
        /// <param name="image"></param>
        public static void OnFilterNegative(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    Color temp = image[c, r];
                    temp = Color.FromArgb(255 - temp.R,
                                          255 - temp.G,
                                          255 - temp.B);
                    image[c, r] = temp;
                }
            }
        }

        /// <summary>
        /// This class function fills the base image with green.
        /// </summary>
        /// <param name="image"></param>
        public static void FillGreen(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    image[c, r] = Color.Green;
                }
            }
        }

        /// <summary>
        /// This class function dims the picture.
        /// </summary>
        /// <param name="image"></param>
        public static void OnFilterDim(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    Color temp = image[c, r];
                    temp = ColorHelpers.ColorMultiply(0.33, temp);
                    image[c, r] = temp;
                }

            }
        }

        /// <summary>
        /// This class function tints the picture.
        /// </summary>
        /// <param name="image"></param>
        public static void OnFilterTint(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    Color temp = image[c, r];
                    temp = Color.FromArgb(
                            ColorHelpers.ClampColorElem(0.33 * temp.R),
                            ColorHelpers.ClampColorElem(temp.G),
                            ColorHelpers.ClampColorElem(0.66 * temp.B));
                    image[c, r] = temp;
                }
            }
        }

        public static void FillColor(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < height; r++)
            {
                // Looping over the columns of the array
                for (int c = 0; c < width; c++)
                {
                    image[c, r] = Color.MidnightBlue;
                }
            }
        }

        public static void HorizontalGradient(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;

            for (int r = 0; r < image.Height; r++)
            {
                for (int c = 0; c < image.Width; c++)
                {
                    for (int p = 0; p < 3; p++)
                    {
                        image[c, r, p] = (byte)((double)c / (double)image.Width * 255.0);
                    }
                }
            }
        }

        public static void VerticalGradient(RasterImage image)
        {
            double height = image.Height;
            double width = image.Width;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    image[c, r, 0] = 0;
                    image[c, r, 1] = 0;
                    image[c, r, 2] = (byte)((height - (double)r) / height * 255.0);
                }
            }
        }

        public static void DigaonalGradient(RasterImage image)
        {
            double height = image.Height;
            double width = image.Width;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    image[c, r, 0] = (byte)(((double)r + (width -(double)c)) / (height + width)  * 255.0);
                    image[c, r, 1] = (byte)(((height - (double)r) + (double)c) / (height + width) * 255.0);
                    image[c, r, 2] = 0; 
                }
            }
        }

        public static void CornersDigaonalGradient(RasterImage image)
        {
            double height = image.Height;
            double width = image.Width;
            double y1 = 0;
            double x1 = 0;
            double y2 = 0;
            double x2 = 0;
            double x = 0;
            double y = 0;
            double x1tox2 = 0;
            double dot = 0;
            double t = 0;
            double dprime = 0;
            double ratio = 0;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    y1 = r - height;
                    x1 = c;

                    y2 = 0 - height;
                    x2 = width;

                    x1tox2 = x2 * x2 + y2 * y2;
                    dot = (x1 * x2) + (y2 * y1);

                    t = dot / x1tox2;
                    x = x2 * t;
                    y = y2 + height * t;
                    dprime = x * x + y * y;
                    ratio = dprime / x1tox2;

                    image[c, r, 0] = (byte)((((double)r + (width - (double)c)) / (height + width) * ratio) * 255.0);
                    image[c, r, 1] = (byte)((((height - (double)r) + (double)c) / (height + width) * (1 - ratio)) * 255.0);
                    image[c, r, 2] = 0;
                }
            }
        }

        public static void HorizontalLine(RasterImage image)
        {
            int r = 50;

            for (int c = 0; c < image.Width; c++)
            {
                image[c, 100] = Color.Yellow;
                image[c, 200] = Color.Yellow;
            }
        }
        public static void VerticalLine(RasterImage image)
        {
            

            for (int r = 0; r < image.Height; r++)
            {
                image[100, r] = Color.Yellow;
                image[101, r] = Color.Yellow;
                image[400, r] = Color.Yellow;
                image[401, r] = Color.Yellow;
            }
        }

        public static void DiagonalLine(RasterImage image)
        {

            double r = 100;
            int temp;
            for (int c = 100; c < 400; c++)
            {
                
                temp = (int)Math.Ceiling(r);
                image[c, temp] = Color.Yellow;
                r = r + 0.33; 
            }
        }

        public static void Monochrome(RasterImage image)
        {

            for (int r = 0; r < image.Height; r++)
            {
                for (int c = 0; c < image.Width; c++)
                {
                    image[c, r, 0] = 0;
                    image[c, r, 1] = 0;
                    //image[c, r, 2] = (byte)((height - (double)r) / height * 255.0);
                }
            }
        }
    }
}

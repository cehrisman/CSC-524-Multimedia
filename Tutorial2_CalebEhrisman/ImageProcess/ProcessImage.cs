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
            double y1;
            double x1;
            double y2;
            double x2;
            double x;
            double y;
            double x1tox2;
            double dot;
            double t;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    //Vector 1 (0, height) -> (c, r)
                    y1 = r - height;
                    x1 = c;

                    //vector 2 (0, height) -> (width, 0)
                    y2 = 0 - height;
                    x2 = width;

                    // Magnitude of diagonal
                    x1tox2 = x2 * x2 + y2 * y2;

                    // Dot product of the two vectors
                    dot = (x1 * x2) + (y2 * y1);

                    // Dot product of v2 and itself. 
                    x1tox2 = (x2 * x2) + (y2 * y2);
                     
                    // dividing num and denom of Orthogonal Project Equation to get final scaler
                    t = dot / x1tox2;

                    // Multiply scaler to vector 2 to get new point values
                    x = x2 * t;
                    y = height + y2 * t;

                   // Replace r->y and c->x from the orginal gradient equations
                    image[c, r, 0] = (byte)((((double)y + (width - (double)x)) / (height + width)) * 255.0);
                    image[c, r, 1] = (byte)((((height - (double)y) + (double)x) / (height + width)) * 255.0);
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
            double mono;
            for (int r = 0; r < image.Height; r++)
            {
                for (int c = 0; c < image.Width; c++)
                {
                    mono = 0.2125 * image[c, r, 0] + 0.7154 * image[c, r, 1] + 0.0721 * image[c, r, 2];
                    image[c, r, 0] = (byte)mono;
                    image[c, r, 1] = (byte)mono;
                    image[c, r, 2] = (byte)mono;
                }
            }
        }
    }
}

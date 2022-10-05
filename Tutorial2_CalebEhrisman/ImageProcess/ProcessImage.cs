using System;
using System.Collections.Generic;
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
        /// <summary>
        /// This class function fills the base image with Midnight Blue.
        /// </summary>
        /// <param name="image"></param>
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
        /// <summary>
        /// This class function fills the base image a gray gradient.
        /// </summary>
        /// <param name="image"></param>
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
        /// <summary>
        /// This class function fills the base image with black/blue gradient.
        /// </summary>
        /// <param name="image"></param>
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
        /// <summary>
        /// This class function fills the base image with red/green diagonal gradient
        /// <param name="image"></param>
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
        /// <summary>
        /// This class function fills the base image with diagonal gradient with color values projected on the diagonal.
        /// </summary>
        /// <param name="image"></param>
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
                     
                    // dividing num and denom of Orthogonal Project Equation
                    t = dot / x1tox2;

                    // Multiply scaler to vector 2 to get new points
                    x = x2 * t;
                    y = height + y2 * t;
                   
                    image[c, r, 0] = (byte)((((double)y + (width - (double)x)) / (height + width)) * 255.0);
                    image[c, r, 1] = (byte)(((height - (double)y) + (double)x) / (height + width) * 255.0);
                    image[c, r, 2] = 0;
                }
            }
        }
        /// <summary>
        /// This class function draws a horizontal yellow line.
        /// </summary>
        /// <param name="image"></param>
        public static void HorizontalLine(RasterImage image)
        {
            int r = 50;

            for (int c = 0; c < image.Width; c++)
            {
                image[c, 100] = Color.Yellow;
                image[c, 200] = Color.Yellow;
            }
        }
        /// <summary>
        /// This class function draws a vertical yellow line.
        /// </summary>
        /// <param name="image"></param>
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
        /// <summary>
        /// This class function draws a diagonal yellow line with antialising.
        /// </summary>
        /// <param name="image"></param>
        public static void DiagonalLine(RasterImage image)
        {

            double r = 100;
            Bitmap bmp = image.toBitmap;
            byte red;
            byte g;
            byte b;
            int temp;
            double amount = 0.25;
            Color p;
            for (int c = 100; c < 400; c++)
            {
                temp = (int)Math.Ceiling(r);
                bmp.SetPixel(c, temp, Color.Yellow);
                r = r + 0.33;
                    
                // Checks all nearby pixels and then blends based on amount of yellow present
                for (int i = c - 1; i <= c + 1; i++)
                    for (int j = (int)r; j <= r + 1; j++)
                    {
                        p = bmp.GetPixel(i, j);
                        red = (byte)(Color.Yellow.R * amount + p.R * (1 - amount));
                        g = (byte)(Color.Yellow.G * amount + p.G * (1 - amount));
                        b = (byte)(Color.Yellow.B * amount + p.B * (1 - amount));
                        bmp.SetPixel(i, j, Color.FromArgb(red, g, b));
                        //image[i, j] = Color.Yellow;

                    }
                
            }
            image = new RasterImage(bmp);
        }

        /// <summary>
        /// This class function converts image to monochrome.
        /// </summary>
        /// <param name="image"></param>
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
        /// <summary>
        /// This class function applies the Median 3x3 filter.
        /// </summary>
        /// <param name="image"></param>

        public static void Median(RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;
            List<byte> redTermsList = new List<byte>();
            List<byte> greenTermsList = new List<byte>();
            List<byte> blueTermsList = new List<byte>();
            Bitmap bmp_img = image.toBitmap;
            byte[,] imgr = new byte[width, height];
            byte[,] imgg = new byte[width, height];
            byte[,] imgb = new byte[width, height];

            //Convert to Grayscale 
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color c = bmp_img.GetPixel(i, j);
                    imgr[i, j] = c.R;
                    imgg[i, j] = c.G;
                    imgb[i, j] = c.B;
                }
            }

            //applying Median Filtering 
            for (int i = 0; i <= width - 3; i++)
                for (int j = 0; j <= height - 3; j++)
                {
                    for (int x = i; x <= i + 2; x++)
                        for (int y = j; y <= j + 2; y++)
                        {
                            redTermsList.Add(imgr[x, y]);
                            greenTermsList.Add(imgg[x, y]);
                            blueTermsList.Add(imgb[x, y]);
                        }
                    byte[] redTerms = redTermsList.ToArray();
                    byte[] greenTerms = greenTermsList.ToArray();
                    byte[] blueTerms = blueTermsList.ToArray();
                    redTermsList.Clear();
                    greenTermsList.Clear();
                    blueTermsList.Clear();

                    Array.Sort<byte>(redTerms);
                    Array.Sort<byte>(greenTerms);
                    Array.Sort<byte>(blueTerms);
                    Array.Reverse(redTerms);
                    Array.Reverse(greenTerms);
                    Array.Reverse(blueTerms);

                    byte redColor = redTerms[4];
                    byte greenColor = greenTerms[4];
                    byte blueColor = blueTerms[4];
                    bmp_img.SetPixel(i + 1, j + 1, Color.FromArgb(redColor, greenColor, blueColor));
                }
            image = new RasterImage(bmp_img);
        }

        public static Color MedianPar(int i, int j, RasterImage image)
        {
            int height = image.Height;
            int width = image.Width;
            List<byte> redTermsList = new List<byte>();
            List<byte> greenTermsList = new List<byte>();
            List<byte> blueTermsList = new List<byte>();
            Bitmap bmp_img = image.toBitmap;
            //byte[,] imgr = new byte[width, height];
            //byte[,] imgg = new byte[width, height];
            //byte[,] imgb = new byte[width, height];

            ////Convert to Grayscale 
            //for (int i = 0; i < width; i++)
            //{
            //    for (int j = 0; j < height; j++)
            //    {
            //        Color c = bmp_img.GetPixel(i, j);
            //        imgr[i, j] = c.R;
            //        imgg[i, j] = c.G;
            //        imgb[i, j] = c.B;
            //    }
            //}

            // //applying Median Filtering 
            //for (int i = 0; i <= width - 3; i++)
            //  for (int j = 0; j <= height - 3; j++)
            if (i > width - 3 || j > height - 3)
                return Color.Black;

            for (int x = i; x <= i + 2; x++)
                for (int y = j; y <= j + 2; y++)
                {
                    redTermsList.Add(image[x, y,RasterImage.R]);
                    greenTermsList.Add(image[x, y, RasterImage.G]);
                    blueTermsList.Add(image[x, y, RasterImage.B]);
                }
            byte[] redTerms = redTermsList.ToArray();
            byte[] greenTerms = greenTermsList.ToArray();
            byte[] blueTerms = blueTermsList.ToArray();
            redTermsList.Clear();
            greenTermsList.Clear();
            blueTermsList.Clear();

            Array.Sort<byte>(redTerms);
            Array.Sort<byte>(greenTerms);
            Array.Sort<byte>(blueTerms);
            Array.Reverse(redTerms);
            Array.Reverse(greenTerms);
            Array.Reverse(blueTerms);

            byte redColor = redTerms[4];
            byte greenColor = greenTerms[4];
            byte blueColor = blueTerms[4];
            //bmp_img.SetPixel(i + 1, j + 1, Color.FromArgb(redColor, greenColor, blueColor));
            //  }
            //image = new RasterImage(bmp_img);
            return Color.FromArgb(redColor, greenColor, blueColor);
        }
    }
}

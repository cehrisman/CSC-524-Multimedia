using System.Drawing;


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

       
    }
}

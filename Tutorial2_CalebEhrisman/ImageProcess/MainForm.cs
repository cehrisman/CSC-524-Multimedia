using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class MainForm : Form
    {
        public enum MODE
        {
            None, Draw, Move, Threshold, WarpBilinear, WarpNearest
        }

        protected MODE mouseMode = MODE.None;
        RasterImage initImage;
        RasterImage postImage;
 
        int offset = 0;
        public MainForm()
        {
            InitializeComponent();
            SetMenuOptionEnable();
            offset = menuStrip1.Height;
            DoubleBuffered = true;
        }

        #region Drawing

        //main Paint function
        protected override void OnPaint(PaintEventArgs e)
        {
            if (initImage == null)
                return;

            Graphics g = e.Graphics;

            //color the background
            Brush b = new SolidBrush(Color.DarkGray);
            g.FillRectangle(b, e.ClipRectangle);

            if (postImage == null)
            {
                //draw only the original
                g.DrawImage(initImage.toBitmap, 0, offset);
            }
            else
            {
                //draw BOTH the original and post processed image

                g.DrawImage(initImage.toBitmap, 0, offset, initImage.Width, initImage.Height);
                g.DrawImage(postImage.toBitmap, initImage.Width + 2, offset, postImage.Width, postImage.Height);

                //
                // Draw a bar between the two images
                //
                Pen black = new Pen(Color.Black);
                black.Width = 3;

                g.DrawLine(black, new PointF(initImage.Width, offset), new PointF(initImage.Width, initImage.Height + offset));
            }
        }

        //redraw on resize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        #endregion

        #region File menu
        private void newMenu_Click(object sender, EventArgs e)
        {
            initImage = new RasterImage(100, 300);
            ProcessImage.FillBlack(initImage);
            SetMenuOptionEnable();
            Invalidate();
        }

        private void openTestMenu_Click(object sender, EventArgs e)
        {
            initImage = new RasterImage(new Bitmap(Properties.Resources.Stickman));
            SetMenuOptionEnable();
            Invalidate();
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                initImage = new RasterImage(new Bitmap(openFileDialog.FileName));
                postImage = null;
                SetMenuOptionEnable();
                Invalidate();
            }
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                OnSave(saveFileDialog.FileName, saveFileDialog.FilterIndex, postImage.toBitmap);
            }
        }

        /// <summary>
        /// function to save a image. Supports, jpeg, gif, png, and bmp
        /// </summary>
        /// <param name="path">location to save</param>
        /// <param name="index">index (format type) from file dialog</param>
        /// <param name="image">image to save</param>
        /// <returns></returns>
        public bool OnSave(string path, int index, Bitmap image)
        {
            try
            {
                switch (index)
                {
                    case 1:
                        image.Save(path, ImageFormat.Jpeg);
                        break;
                    case 2:
                        image.Save(path, ImageFormat.Gif);
                        break;
                    case 3:
                        image.Save(path, ImageFormat.Png);
                        break;
                    case 4:
                        image.Save(path, ImageFormat.Bmp);
                        break;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }

            return true;
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            if(initImage != null)
                initImage.Close();
            if (postImage != null)
                postImage.Close();
            SetMenuOptionEnable();
            Invalidate();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        private void SetMenuOptionEnable()
        {
            if (initImage == null)
            {
                bool on = false;
                fillWhiteMenu.Enabled = on;
                copyMenu.Enabled = on;
                negativeMenu.Enabled = on;
                thresholdMenu.Enabled = on;
                warpNearestMenu.Enabled = on;
                warpBilenearMenu.Enabled = on;
                drawMenu.Enabled = on;
            }
            else {
                bool on = true;
                fillWhiteMenu.Enabled = on;
                copyMenu.Enabled = on;
                negativeMenu.Enabled = on;
                thresholdMenu.Enabled = on;
                warpNearestMenu.Enabled = on;
                warpBilenearMenu.Enabled = on;
                drawMenu.Enabled = on;

            }

           
        }


        #endregion

        #region Generate menu
        private void copyMenu_Click(object sender, EventArgs e)
        {
            postImage = new RasterImage(initImage);
            Invalidate();
        }

        private void thresholdMenu_Click(object sender, EventArgs e)
        {
            mouseMode = MODE.Threshold;
            drawMenu.Checked = false;
        }

        private void warpNearestMenu_Click(object sender, EventArgs e)
        {
            mouseMode = MODE.WarpNearest;
            drawMenu.Checked = false;

            //make post image if needed, and clear
            if (postImage == null)
                postImage = new RasterImage(initImage.Width, initImage.Height);
            ProcessImage.FillWhite(postImage);
            Invalidate();
        }

        private void warpBilenearMenu_Click(object sender, EventArgs e)
        {
            mouseMode = MODE.WarpBilinear;
            drawMenu.Checked = false;

            //make post image if needed, and clear
            if (postImage == null)
                postImage = new RasterImage(initImage.Width, initImage.Height);
            ProcessImage.FillWhite(postImage);
            Invalidate();
        }

        #endregion

        #region Process menu

        private void fillWhiteMenu_Click(object sender, EventArgs e)
        {
            ProcessImage.FillWhite(initImage);
            Invalidate();
        }

        private void negativeMenu_Click(object sender, EventArgs e)
        {
            ProcessImage.OnFilterNegative(initImage);
            Invalidate();
        }

        private void drawMenu_Click(object sender, EventArgs e)
        {
            drawMenu.Checked = !drawMenu.Checked;
            if (drawMenu.Checked)
                mouseMode = MODE.Draw;
            else
                mouseMode = MODE.None;
            SetMenuOptionEnable();
            Invalidate();
        }


        #endregion

        #region Mouse

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e); 

            if (initImage == null)
                return;

            int width = initImage.Width;
            int height = initImage.Height;
            int x = e.X;
            int y = e.Y - offset; //Remove menu strip height from click point

            
            switch(mouseMode)
            {
                case MODE.None:
                    break;
                case MODE.Draw:
                    if (x < width && y < height)
                        initImage[x, y] = Color.Red;
                        mouseMode = MODE.Move;
                    break;
                case MODE.Move:
                    mouseMode = MODE.Draw; //if this happens, there was a glitch, restart
                    break;
                case MODE.Threshold:
                    if (postImage == null)
                        postImage = new RasterImage(initImage.Width, initImage.Height);
                    GenerateImage.FilterThreshold(initImage, postImage, x, y);
                    break;
                case MODE.WarpNearest:
                    GenerateImage.FilterWarp(initImage, postImage, x, y, true);
                    break;
                case MODE.WarpBilinear:
                    GenerateImage.FilterWarp(initImage, postImage, x, y);
                    break;
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            switch (mouseMode)
            {
                case MODE.Move:
                    mouseMode = MODE.Draw; //allow a restart
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (initImage == null)
                return;

            int width = initImage.Width;
            int height = initImage.Height;
            int x = e.X;
            int y = e.Y - offset; //Remove menu strip height from click point

            switch (mouseMode)
            {
                case MODE.None:
                    break;
                case MODE.Move:
                    if (x < width && y < height)
                    { 
                        initImage[x, y] = Color.Red;
                        Invalidate();
                    }
                    break;
                case MODE.Threshold:
                    break;
                case MODE.WarpNearest:
                    break;
                case MODE.WarpBilinear:
                    break;
            }
           
        }



        #endregion

        private void dimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.OnFilterDim(initImage);
            Invalidate();
        }

        private void tintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.OnFilterTint(initImage);
            Invalidate();
        }

        private void lowpassFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //make post image if needed
            if (postImage == null)
                postImage = new RasterImage(initImage.Width, initImage.Height);

            GenerateImage.OnFilterLowpass(initImage, postImage);
            Invalidate();
        }

        private void fillGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.FillGreen(initImage);
            Invalidate();
        }

        private void fillColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.FillColor(initImage);
            Invalidate();
        }

        private void horizontalGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.HorizontalGradient(initImage);
            Invalidate();
        }

        private void verticalBlueGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.VerticalGradient(initImage);
            Invalidate();
        }

        private void diagonalGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.DigaonalGradient(initImage);
            Invalidate();
        }

        private void cornersDiagonalGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.CornersDigaonalGradient(initImage);
            Invalidate();
        }

        private void horiztonalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.HorizontalLine(initImage);
            Invalidate();
        }

        private void verticalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.VerticalLine(initImage);
            Invalidate();
        }

        private void diagonalLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessImage.DiagonalLine(initImage);
            Invalidate();
        }
    }
}

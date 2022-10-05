namespace ImageProcess
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillWhiteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.drawMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.thresholdMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.warpNearestMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.warpBilenearMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lowpassFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeSquareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeAffineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalBlueGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cornersDiagonalGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horiztonalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monochromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.arrowWarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.processMenu,
            this.tasksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1014, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenu,
            this.openTestMenu,
            this.openMenu,
            this.saveMenu,
            this.closeMenu,
            this.exitMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newMenu
            // 
            this.newMenu.Name = "newMenu";
            this.newMenu.Size = new System.Drawing.Size(126, 22);
            this.newMenu.Text = "&New";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // openTestMenu
            // 
            this.openTestMenu.Name = "openTestMenu";
            this.openTestMenu.Size = new System.Drawing.Size(126, 22);
            this.openTestMenu.Text = "Open &Test";
            this.openTestMenu.Click += new System.EventHandler(this.openTestMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(126, 22);
            this.openMenu.Text = "&Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(126, 22);
            this.saveMenu.Text = "&Save";
            this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
            // 
            // closeMenu
            // 
            this.closeMenu.Name = "closeMenu";
            this.closeMenu.Size = new System.Drawing.Size(126, 22);
            this.closeMenu.Text = "&Close";
            this.closeMenu.Click += new System.EventHandler(this.closeMenu_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(126, 22);
            this.exitMenu.Text = "&Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillWhiteMenu,
            this.negativeMenu,
            this.toolStripSeparator1,
            this.drawMenu,
            this.dimToolStripMenuItem,
            this.tintToolStripMenuItem,
            this.fillGreenToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generateToolStripMenuItem.Text = "&Process";
            // 
            // fillWhiteMenu
            // 
            this.fillWhiteMenu.Name = "fillWhiteMenu";
            this.fillWhiteMenu.Size = new System.Drawing.Size(123, 22);
            this.fillWhiteMenu.Text = "&Fill White";
            this.fillWhiteMenu.Click += new System.EventHandler(this.fillWhiteMenu_Click);
            // 
            // negativeMenu
            // 
            this.negativeMenu.Name = "negativeMenu";
            this.negativeMenu.Size = new System.Drawing.Size(123, 22);
            this.negativeMenu.Text = "&Negative";
            this.negativeMenu.Click += new System.EventHandler(this.negativeMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // drawMenu
            // 
            this.drawMenu.Name = "drawMenu";
            this.drawMenu.Size = new System.Drawing.Size(123, 22);
            this.drawMenu.Text = "&Draw";
            this.drawMenu.Click += new System.EventHandler(this.drawMenu_Click);
            // 
            // dimToolStripMenuItem
            // 
            this.dimToolStripMenuItem.Name = "dimToolStripMenuItem";
            this.dimToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.dimToolStripMenuItem.Text = "Dim";
            this.dimToolStripMenuItem.Click += new System.EventHandler(this.dimToolStripMenuItem_Click);
            // 
            // tintToolStripMenuItem
            // 
            this.tintToolStripMenuItem.Name = "tintToolStripMenuItem";
            this.tintToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.tintToolStripMenuItem.Text = "Tint";
            this.tintToolStripMenuItem.Click += new System.EventHandler(this.tintToolStripMenuItem_Click);
            // 
            // fillGreenToolStripMenuItem
            // 
            this.fillGreenToolStripMenuItem.Name = "fillGreenToolStripMenuItem";
            this.fillGreenToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.fillGreenToolStripMenuItem.Text = "Fill Green";
            this.fillGreenToolStripMenuItem.Click += new System.EventHandler(this.fillGreenToolStripMenuItem_Click);
            // 
            // processMenu
            // 
            this.processMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenu,
            this.toolStripSeparator2,
            this.thresholdMenu,
            this.warpNearestMenu,
            this.warpBilenearMenu,
            this.lowpassFilterToolStripMenuItem,
            this.makeSquareToolStripMenuItem,
            this.makeAffineToolStripMenuItem,
            this.arrowWarpToolStripMenuItem,
            this.skewToolStripMenuItem});
            this.processMenu.Name = "processMenu";
            this.processMenu.Size = new System.Drawing.Size(66, 20);
            this.processMenu.Text = "&Generate";
            this.processMenu.Click += new System.EventHandler(this.processMenu_Click);
            // 
            // copyMenu
            // 
            this.copyMenu.Name = "copyMenu";
            this.copyMenu.Size = new System.Drawing.Size(180, 22);
            this.copyMenu.Text = "&Copy";
            this.copyMenu.Click += new System.EventHandler(this.copyMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // thresholdMenu
            // 
            this.thresholdMenu.Name = "thresholdMenu";
            this.thresholdMenu.Size = new System.Drawing.Size(180, 22);
            this.thresholdMenu.Text = "&Threshold";
            this.thresholdMenu.Click += new System.EventHandler(this.thresholdMenu_Click);
            // 
            // warpNearestMenu
            // 
            this.warpNearestMenu.Name = "warpNearestMenu";
            this.warpNearestMenu.Size = new System.Drawing.Size(180, 22);
            this.warpNearestMenu.Text = "&Warp Nearest";
            this.warpNearestMenu.Click += new System.EventHandler(this.warpNearestMenu_Click);
            // 
            // warpBilenearMenu
            // 
            this.warpBilenearMenu.Name = "warpBilenearMenu";
            this.warpBilenearMenu.Size = new System.Drawing.Size(180, 22);
            this.warpBilenearMenu.Text = "Warp &Bilenear";
            this.warpBilenearMenu.Click += new System.EventHandler(this.warpBilenearMenu_Click);
            // 
            // lowpassFilterToolStripMenuItem
            // 
            this.lowpassFilterToolStripMenuItem.Name = "lowpassFilterToolStripMenuItem";
            this.lowpassFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lowpassFilterToolStripMenuItem.Text = "Lowpass Filter";
            this.lowpassFilterToolStripMenuItem.Click += new System.EventHandler(this.lowpassFilterToolStripMenuItem_Click);
            // 
            // makeSquareToolStripMenuItem
            // 
            this.makeSquareToolStripMenuItem.Name = "makeSquareToolStripMenuItem";
            this.makeSquareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.makeSquareToolStripMenuItem.Text = "Make Square";
            this.makeSquareToolStripMenuItem.Click += new System.EventHandler(this.makeSquareToolStripMenuItem_Click);
            // 
            // makeAffineToolStripMenuItem
            // 
            this.makeAffineToolStripMenuItem.Name = "makeAffineToolStripMenuItem";
            this.makeAffineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.makeAffineToolStripMenuItem.Text = "Make Affine";
            this.makeAffineToolStripMenuItem.Click += new System.EventHandler(this.makeAffineToolStripMenuItem_Click);
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillColorToolStripMenuItem,
            this.horizontalGradientToolStripMenuItem,
            this.verticalBlueGradientToolStripMenuItem,
            this.diagonalGradientToolStripMenuItem,
            this.cornersDiagonalGradientToolStripMenuItem,
            this.horiztonalLineToolStripMenuItem,
            this.verticalLineToolStripMenuItem,
            this.diagonalLineToolStripMenuItem,
            this.monochromeToolStripMenuItem,
            this.medianToolStripMenuItem});
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            this.fillColorToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.fillColorToolStripMenuItem.Text = "Fill Color";
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click);
            // 
            // horizontalGradientToolStripMenuItem
            // 
            this.horizontalGradientToolStripMenuItem.Name = "horizontalGradientToolStripMenuItem";
            this.horizontalGradientToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.horizontalGradientToolStripMenuItem.Text = "Horizontal Gradient";
            this.horizontalGradientToolStripMenuItem.Click += new System.EventHandler(this.horizontalGradientToolStripMenuItem_Click);
            // 
            // verticalBlueGradientToolStripMenuItem
            // 
            this.verticalBlueGradientToolStripMenuItem.Name = "verticalBlueGradientToolStripMenuItem";
            this.verticalBlueGradientToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.verticalBlueGradientToolStripMenuItem.Text = "Vertical Blue Gradient";
            this.verticalBlueGradientToolStripMenuItem.Click += new System.EventHandler(this.verticalBlueGradientToolStripMenuItem_Click);
            // 
            // diagonalGradientToolStripMenuItem
            // 
            this.diagonalGradientToolStripMenuItem.Name = "diagonalGradientToolStripMenuItem";
            this.diagonalGradientToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.diagonalGradientToolStripMenuItem.Text = "Diagonal Gradient";
            this.diagonalGradientToolStripMenuItem.Click += new System.EventHandler(this.diagonalGradientToolStripMenuItem_Click);
            // 
            // cornersDiagonalGradientToolStripMenuItem
            // 
            this.cornersDiagonalGradientToolStripMenuItem.Name = "cornersDiagonalGradientToolStripMenuItem";
            this.cornersDiagonalGradientToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.cornersDiagonalGradientToolStripMenuItem.Text = "Corners Diagonal Gradient";
            this.cornersDiagonalGradientToolStripMenuItem.Click += new System.EventHandler(this.cornersDiagonalGradientToolStripMenuItem_Click);
            // 
            // horiztonalLineToolStripMenuItem
            // 
            this.horiztonalLineToolStripMenuItem.Name = "horiztonalLineToolStripMenuItem";
            this.horiztonalLineToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.horiztonalLineToolStripMenuItem.Text = "Horiztonal Line";
            this.horiztonalLineToolStripMenuItem.Click += new System.EventHandler(this.horiztonalLineToolStripMenuItem_Click);
            // 
            // verticalLineToolStripMenuItem
            // 
            this.verticalLineToolStripMenuItem.Name = "verticalLineToolStripMenuItem";
            this.verticalLineToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.verticalLineToolStripMenuItem.Text = "Vertical Line";
            this.verticalLineToolStripMenuItem.Click += new System.EventHandler(this.verticalLineToolStripMenuItem_Click);
            // 
            // diagonalLineToolStripMenuItem
            // 
            this.diagonalLineToolStripMenuItem.Name = "diagonalLineToolStripMenuItem";
            this.diagonalLineToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.diagonalLineToolStripMenuItem.Text = "Diagonal Line";
            this.diagonalLineToolStripMenuItem.Click += new System.EventHandler(this.diagonalLineToolStripMenuItem_Click);
            // 
            // monochromeToolStripMenuItem
            // 
            this.monochromeToolStripMenuItem.Name = "monochromeToolStripMenuItem";
            this.monochromeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.monochromeToolStripMenuItem.Text = "Monochrome";
            this.monochromeToolStripMenuItem.Click += new System.EventHandler(this.monochromeToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|BMP File" +
    "s (*.bmp)|*p.bmp|All files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|BMP File" +
    "s (*.bmp)|*.bmp";
            // 
            // arrowWarpToolStripMenuItem
            // 
            this.arrowWarpToolStripMenuItem.Name = "arrowWarpToolStripMenuItem";
            this.arrowWarpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arrowWarpToolStripMenuItem.Text = "Make Arrow";
            this.arrowWarpToolStripMenuItem.Click += new System.EventHandler(this.arrowWarpToolStripMenuItem_Click);
            // 
            // skewToolStripMenuItem
            // 
            this.skewToolStripMenuItem.Name = "skewToolStripMenuItem";
            this.skewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skewToolStripMenuItem.Text = "Skew";
            this.skewToolStripMenuItem.Click += new System.EventHandler(this.skewToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 406);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Image Process: Ehrisman Caleb";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
        private System.Windows.Forms.ToolStripMenuItem openTestMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem closeMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillWhiteMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem processMenu;
        private System.Windows.Forms.ToolStripMenuItem thresholdMenu;
        private System.Windows.Forms.ToolStripMenuItem warpNearestMenu;
        private System.Windows.Forms.ToolStripMenuItem warpBilenearMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem copyMenu;
        private System.Windows.Forms.ToolStripMenuItem negativeMenu;
        private System.Windows.Forms.ToolStripMenuItem drawMenu;
        private System.Windows.Forms.ToolStripMenuItem dimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowpassFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalBlueGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cornersDiagonalGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horiztonalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monochromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeSquareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeAffineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowWarpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skewToolStripMenuItem;
    }
}


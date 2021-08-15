namespace ImageProcessing
{
    partial class ImageProcessingForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectToleranceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateCounterClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb_keepUsingOriginalImage = new System.Windows.Forms.CheckBox();
            this.groupBox_imageHistory = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_imageHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.selectImageToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectImageToolStripMenuItem.Text = "&Open Image";
            this.selectImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem1.Text = "&Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorFilterToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.invertColorsToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.setGammaToolStripMenuItem,
            this.detectToleranceToolStripMenuItem,
            this.rotateFlipToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "&Image";
            // 
            // colorFilterToolStripMenuItem
            // 
            this.colorFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem});
            this.colorFilterToolStripMenuItem.Name = "colorFilterToolStripMenuItem";
            this.colorFilterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.colorFilterToolStripMenuItem.Text = "Color &Filter";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.redToolStripMenuItem.Text = "&Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.greenToolStripMenuItem.Text = "&Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.blueToolStripMenuItem.Text = "&Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.grayscaleToolStripMenuItem.Text = "&Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // invertColorsToolStripMenuItem
            // 
            this.invertColorsToolStripMenuItem.Name = "invertColorsToolStripMenuItem";
            this.invertColorsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.invertColorsToolStripMenuItem.Text = "&Invert Colors";
            this.invertColorsToolStripMenuItem.Click += new System.EventHandler(this.invertColorsToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.contrastToolStripMenuItem.Text = "&Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.brightnessToolStripMenuItem.Text = "&Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.brightnessToolStripMenuItem_Click);
            // 
            // setGammaToolStripMenuItem
            // 
            this.setGammaToolStripMenuItem.Name = "setGammaToolStripMenuItem";
            this.setGammaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.setGammaToolStripMenuItem.Text = "&Gamma";
            this.setGammaToolStripMenuItem.Click += new System.EventHandler(this.setGammaToolStripMenuItem_Click);
            // 
            // detectToleranceToolStripMenuItem
            // 
            this.detectToleranceToolStripMenuItem.Name = "detectToleranceToolStripMenuItem";
            this.detectToleranceToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.detectToleranceToolStripMenuItem.Text = "Detect &Tolerance";
            this.detectToleranceToolStripMenuItem.Click += new System.EventHandler(this.detectToleranceToolStripMenuItem_Click);
            // 
            // rotateFlipToolStripMenuItem
            // 
            this.rotateFlipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipHorizontallyToolStripMenuItem,
            this.flipVerticallyToolStripMenuItem,
            this.rotateClockwiseToolStripMenuItem,
            this.rotateCounterClockwiseToolStripMenuItem});
            this.rotateFlipToolStripMenuItem.Name = "rotateFlipToolStripMenuItem";
            this.rotateFlipToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.rotateFlipToolStripMenuItem.Text = "&Rotate/Flip";
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            this.flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            this.flipHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.flipHorizontallyToolStripMenuItem.Text = "Flip Horizontally";
            this.flipHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.flipHorizontallyToolStripMenuItem_Click);
            // 
            // flipVerticallyToolStripMenuItem
            // 
            this.flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            this.flipVerticallyToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.flipVerticallyToolStripMenuItem.Text = "Flip Vertically";
            this.flipVerticallyToolStripMenuItem.Click += new System.EventHandler(this.flipVerticallyToolStripMenuItem_Click);
            // 
            // rotateClockwiseToolStripMenuItem
            // 
            this.rotateClockwiseToolStripMenuItem.Name = "rotateClockwiseToolStripMenuItem";
            this.rotateClockwiseToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.rotateClockwiseToolStripMenuItem.Text = "Rotate Clockwise";
            this.rotateClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateClockwiseToolStripMenuItem_Click);
            // 
            // rotateCounterClockwiseToolStripMenuItem
            // 
            this.rotateCounterClockwiseToolStripMenuItem.Name = "rotateCounterClockwiseToolStripMenuItem";
            this.rotateCounterClockwiseToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.rotateCounterClockwiseToolStripMenuItem.Text = "Rotate Counter Clockwise";
            this.rotateCounterClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotateCounterClockwiseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Image";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(6, 259);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(74, 54);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(6, 199);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(74, 54);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(6, 139);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(74, 54);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(6, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(74, 54);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 527);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cb_keepUsingOriginalImage
            // 
            this.cb_keepUsingOriginalImage.AutoSize = true;
            this.cb_keepUsingOriginalImage.Checked = true;
            this.cb_keepUsingOriginalImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_keepUsingOriginalImage.Location = new System.Drawing.Point(65, 35);
            this.cb_keepUsingOriginalImage.Name = "cb_keepUsingOriginalImage";
            this.cb_keepUsingOriginalImage.Size = new System.Drawing.Size(202, 17);
            this.cb_keepUsingOriginalImage.TabIndex = 9;
            this.cb_keepUsingOriginalImage.Text = "Keep using Original Image to Process";
            this.cb_keepUsingOriginalImage.UseVisualStyleBackColor = true;
            // 
            // groupBox_imageHistory
            // 
            this.groupBox_imageHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_imageHistory.Controls.Add(this.pictureBox2);
            this.groupBox_imageHistory.Controls.Add(this.pictureBox3);
            this.groupBox_imageHistory.Controls.Add(this.pictureBox4);
            this.groupBox_imageHistory.Controls.Add(this.pictureBox5);
            this.groupBox_imageHistory.Controls.Add(this.pictureBox6);
            this.groupBox_imageHistory.Location = new System.Drawing.Point(678, 62);
            this.groupBox_imageHistory.Name = "groupBox_imageHistory";
            this.groupBox_imageHistory.Size = new System.Drawing.Size(90, 328);
            this.groupBox_imageHistory.TabIndex = 10;
            this.groupBox_imageHistory.TabStop = false;
            this.groupBox_imageHistory.Text = "Image History";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 601);
            this.Controls.Add(this.groupBox_imageHistory);
            this.Controls.Add(this.cb_keepUsingOriginalImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Image Processing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_imageHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertColorsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGammaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectToleranceToolStripMenuItem;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateFlipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateCounterClockwiseToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_keepUsingOriginalImage;
        private System.Windows.Forms.GroupBox groupBox_imageHistory;
    }
}


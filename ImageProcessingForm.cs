using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageProcessing.CustomForms;
using ImageProcessing.DataStructures;
using ImageProcessing.Extensions;

namespace ImageProcessing
{

    public partial class ImageProcessingForm : Form
    {
        /// <summary>
        /// Bitmap to process
        /// </summary>
        private Bitmap bitmapToProcess;

        /// <summary>
        /// Backup of the original Bitmap in case user wants to undo/reset
        /// </summary>
        private readonly Bitmap backupOfOriginalImageBitmap;


        /// <summary>
        /// History of the past 5 images that were processed.
        /// </summary>
        private readonly HistoryBuffer<Bitmap> historyOfImages = new HistoryBuffer<Bitmap>();

        /// <summary>
        /// Picture boxes controls list used for the History of Images
        /// </summary>
        private readonly List<PictureBox> historyPreviewPictureBoxes = new List<PictureBox>();


        /// <summary>
        /// Simple image processing app
        /// </summary>
        public ImageProcessingForm()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile(@"ExampleImages\Globe_and_high_court_fix.jpg");

            bitmapToProcess = new Bitmap(pictureBox1.Image);
            backupOfOriginalImageBitmap = new Bitmap(bitmapToProcess);

            //add the history pictureboxes to a list. this is used in updating the
            //history boxes with past images
            historyPreviewPictureBoxes.AddRange(
                new List<PictureBox>
                    {
                        pictureBox2,
                        pictureBox3,
                        pictureBox4,
                        pictureBox5,
                        pictureBox6
                    }
                );

            AddMenuItemClickHandlers();
        }

        /// <summary>
        /// Adds an event handler to the Image Processing menu items
        /// </summary>
        private void AddMenuItemClickHandlers()
        {
            //get all the relevant tool strip menu item controls
            List<ToolStripMenuItem> imageToolStripMenuItems = new List<ToolStripMenuItem>
            {
                redToolStripMenuItem,
                greenToolStripMenuItem,
                blueToolStripMenuItem,
                grayscaleToolStripMenuItem,
                invertColorsToolStripMenuItem,
                brightnessToolStripMenuItem,
                contrastToolStripMenuItem,
                setGammaToolStripMenuItem,
                detectToleranceToolStripMenuItem,
                rotateClockwiseToolStripMenuItem,
                rotateCounterClockwiseToolStripMenuItem,
                flipHorizontallyToolStripMenuItem,
                flipVerticallyToolStripMenuItem
            };

            foreach (var toolStripMenuItem in imageToolStripMenuItems)
            {
                toolStripMenuItem.Click += (s, e) =>
                {
                    historyOfImages.Add(new Bitmap(bitmapToProcess));

                    UpdateHistoryImages();

                    if (cb_keepUsingOriginalImage.Checked)
                    {
                        bitmapToProcess = new Bitmap(backupOfOriginalImageBitmap);
                    }
                };
            }
        }


        /// <summary>
        /// Updates the History of Images HistoryBuffer (Queue) picturebox previews.
        /// </summary>
        private void UpdateHistoryImages()
        {
            for (int i = 0; i < historyOfImages.Count; i++)
            {
                historyPreviewPictureBoxes[i].Image = historyOfImages.ElementAt(i);
            }
        }







        #region menu clicks
        //MAIN (FILE) MENU
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = backupOfOriginalImageBitmap;
        }

        /// <summary>
        /// Choose an image
        /// </summary>
        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|All files (*.*)|*.*",
                Multiselect = false
            };

            //get image and save it to the picture box
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = ofd.OpenFile())
                {
                    pictureBox1.Image = new Bitmap(stream);
                    bitmapToProcess = new Bitmap(stream);
                }
            }
        }

        /// <summary>
        /// Save an image
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|All files (*.*)|*.*",
                Title = "Save an Image File"
            };

            sfd.ShowDialog();

            if (String.IsNullOrEmpty(sfd.FileName))
            {
                //show error? this should never happen though - i believe the SaveFileDialog
                //prevents the OK button from closing the dialog if no file name is there
                return;
            }

            using (Stream stream = sfd.OpenFile())
            {
                string extension = Path.GetExtension(sfd.FileName);

                switch (extension?.ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                        pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        pictureBox1.Image.Save(stream, ImageFormat.Png);
                        break;
                    case ".gif":
                        pictureBox1.Image.Save(stream, ImageFormat.Gif);
                        break;
                    case ".bmp":
                        pictureBox1.Image.Save(stream, ImageFormat.Bmp);
                        break;
                    default:
                        MessageBox.Show($"Error, '{extension}' is not a valid file extension/type.");
                        break;
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //END MAIN MENU



        //IMAGE MENU
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.ColorChannelFilterRed);
        }
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.ColorChannelFilterGreen);
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.ColorChannelFilterBlue);
        }
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.Grayscale);
        }

        private void invertColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.Inverted );
        }


        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrackBarInputForm trackBarInputForm = new TrackBarInputForm();

            trackBarInputForm.label1.Text = "Set the Contrast";

            trackBarInputForm.SetTrackBarAndNumericUpDownMinMax(-100, 100);

            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                double result = (double)trackBarInputForm.CurrentTrackBarValue;

                pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.Contrast,  result);
            }
        }


        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrackBarInputForm trackBarInputForm = new TrackBarInputForm();

            trackBarInputForm.label1.Text = "Set the Brightness";

            trackBarInputForm.SetTrackBarAndNumericUpDownMinMax(- ImageProcessor.MAX_PIXEL_VALUE, ImageProcessor.MAX_PIXEL_VALUE);



            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                 int result = trackBarInputForm.CurrentTrackBarValue;
                pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.Brightness, result);
            }
        }

        private void setGammaToolStripMenuItem_Click(object sender, EventArgs ea)
        {
            double redGamma = 1D;
            double greenGamma = 1D;
            double blueGamma = 1D;

            TrackBarInputForm trackBarInputForm = new TrackBarInputForm();

            trackBarInputForm.label1.Text = "Set the Red Gamma.\r\nRange is 0.2 to 5";

            trackBarInputForm.SetTrackBarAndNumericUpDownMinMax(20, 500);

            trackBarInputForm.trackBar1.ValueChanged += (s, e) =>
                trackBarInputForm.label2.Text = ((double)trackBarInputForm.CurrentTrackBarValue / 100).ToString();


            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                redGamma = (double)trackBarInputForm.trackBar1.Value / 100;
            }
            else
            {
                MessageBox.Show("Canceled setting Gamma. Cancelling image proccessing.", "Canceled setting Gamma", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            trackBarInputForm.label1.Text = "Set the Green Gamma.\r\nRange is 0.2 to 5";

            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                greenGamma = (double)trackBarInputForm.trackBar1.Value / 100;
            }
            else
            {
                MessageBox.Show("Canceled setting Gamma. Cancelling image proccessing.", "Canceled setting Gamma", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            trackBarInputForm.label1.Text = "Set the Blue Gamma.\r\nRange is 0.2 to 5";

            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                blueGamma = (double)trackBarInputForm.trackBar1.Value / 100;
            }
            else
            {
                MessageBox.Show("Canceled setting Gamma. Cancelling image proccessing.", "Canceled setting Gamma", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            byte[] redGammaBytes = CreateGammaBytes(redGamma);
            byte[] greenGammaBytes = CreateGammaBytes(greenGamma);
            byte[] blueGammaBytes = CreateGammaBytes(blueGamma);


            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory
                                        (
                                            bitmapToProcess, 
                                            ImageProcessingType.Gamma, 
                                            redGammaBytes, 
                                            greenGammaBytes, 
                                            blueGammaBytes
                                        );

        }

        /// <summary>
        /// Helper for creating the Gamma byte arrays for the GetGammaColor() method
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private byte[] CreateGammaBytes(double color)
        {
            byte[] gammaBytes = new byte[256];

            for (int i = 0; i < gammaBytes.Length; i++)
            {
                int temp = (int)(Byte.MaxValue * Math.Pow(i / (double)Byte.MaxValue, 1.0 / color) + 0.5);
                gammaBytes[i] = (byte)Math.Min(Byte.MaxValue, temp);
            }

            return gammaBytes;
        }


        private void detectToleranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte searchedR;
            byte searchedG;
            byte searchedB;
            int tolerance;

            TrackBarInputForm trackBarInputForm = new TrackBarInputForm();

            trackBarInputForm.SetTrackBarAndNumericUpDownMinMax(ImageProcessor.MIN_PIXEL_VALUE, ImageProcessor.MAX_PIXEL_VALUE);

            trackBarInputForm.label1.Text = "Set the Red pixel value to search for.";
            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                searchedR = trackBarInputForm.trackBar1.Value.GetWithinByteRange();
            }
            else
            {
                MessageBox.Show("Canceled setting Detect Tolerance.", "Canceled setting Detect Tolerance", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            trackBarInputForm.label1.Text = "Set the Green pixel value to search for.";
            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                searchedG = trackBarInputForm.trackBar1.Value.GetWithinByteRange();
            }
            else
            {
                MessageBox.Show("Canceled setting Detect Tolerance.", "Canceled setting Detect Tolerance", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }


            trackBarInputForm.label1.Text = "Set the Blue pixel value to search for.";
            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                searchedB = trackBarInputForm.trackBar1.Value.GetWithinByteRange();
            }
            else
            {
                MessageBox.Show("Canceled setting Detect Tolerance.", "Canceled setting Detect Tolerance", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }


            trackBarInputForm.label1.Text = "Set the tolerance.";
            if (trackBarInputForm.ShowDialog() == DialogResult.OK)
            {
                tolerance = trackBarInputForm.trackBar1.Value.GetWithinByteRange();
            }
            else
            {
                MessageBox.Show("Canceled setting Detect Tolerance.", "Canceled setting Detect Tolerance", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            pictureBox1.Image = ImageProcessor.ProcessBitmapFactory(bitmapToProcess, ImageProcessingType.DetectTolerance, searchedR, searchedG, searchedB, tolerance);
        }

        //TODO: implement these algorithms manually 
        //TODO: instead of using the provided C# Bitmap API to rotate/flip
        private void flipHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new Bitmap(bitmapToProcess);

            temp.RotateFlip(RotateFlipType.RotateNoneFlipX);

            pictureBox1.Image = temp;
        }
        private void flipVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new Bitmap(bitmapToProcess);

            temp.RotateFlip(RotateFlipType.RotateNoneFlipY);

            pictureBox1.Image = temp;
        }
        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new Bitmap(bitmapToProcess);

            temp.RotateFlip(RotateFlipType.Rotate90FlipNone);

            pictureBox1.Image = temp;
        }
        private void rotateCounterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = new Bitmap(bitmapToProcess);

            temp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            pictureBox1.Image = temp;
        }


        //END IMAGE MENU

        //HELP MENU
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutText = new StringBuilder();

            aboutText.AppendLine("Image Processor program by Wilcoforr.");
            aboutText.AppendLine(" Mainly created to learn about image processing algorithms, thus this is a primitive WinForms app.");

            MessageBox.Show(aboutText.ToString(), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //END HELP MENU

        #endregion //menu clicks




    }
}

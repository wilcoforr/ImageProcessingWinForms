using System;
using System.Windows.Forms;

namespace ImageProcessing.CustomForms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TrackBarInputForm : Form
    {

        /// <summary>
        /// Just a shorter way to get to the trackbar's current Value
        /// </summary>
        public int CurrentTrackBarValue
        {
            get { return trackBar1.Value; }
            set { trackBar1.Value = value; }
        }


        public TrackBarInputForm()
        {
            InitializeComponent();

            btn_ok.DialogResult = DialogResult.OK;
            btn_cancel.DialogResult = DialogResult.Cancel;

            label2.Text = CurrentTrackBarValue.ToString();

            trackBar1.ValueChanged += (s, e) =>
            {
                label2.Text = CurrentTrackBarValue.ToString();
                numericUpDown1.Value = CurrentTrackBarValue;
            };

            numericUpDown1.ValueChanged += (s ,e ) =>
            {
                label2.Text = numericUpDown1.Value.ToString();
                trackBar1.Value = Convert.ToInt32(numericUpDown1.Value);
            };
        }

        public void SetTrackBarAndNumericUpDownMinMax(int min, int max)
        {
            trackBar1.Minimum = min;
            trackBar1.Maximum = max;

            numericUpDown1.Minimum = min;
            numericUpDown1.Maximum = max;
        }


    }
}

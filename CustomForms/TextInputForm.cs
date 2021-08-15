using System.Windows.Forms;

namespace ImageProcessing.CustomForms
{
    public partial class TextInputForm : Form
    {
        public TextInputForm()
        {
            InitializeComponent();
            btn_ok.DialogResult = DialogResult.OK;
            btn_cancel.DialogResult = DialogResult.Cancel;
        }
    }
}

using System;
using System.Windows.Forms;

namespace IrisoftWinViewForm
{
    public partial class CalcCoefficientForm : Form
    {
        public CalcCoefficientForm()
        {
            InitializeComponent();
        }

        private void bCalc_Click(object sender, EventArgs e)
        {
            StringsDataModel model = new StringsDataModel(_textBoxLeft.Text, _textBoxRight.Text);
            var result = new StringsDataController(model).GetAnswer();
            _labelResult.Text = result.ToString("R");
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

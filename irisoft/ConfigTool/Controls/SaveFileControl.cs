using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Configuration.Helpers;

namespace Configuration.Controls
{
    public partial class SaveFileControl : UserControl
    {
        private Assistant _assistant;

        public SaveFileControl()
        {
            InitializeComponent();
        }

        private void rtfRight_VScroll(object sender, EventArgs e)
        {
        }

        private void rtbLeft_VScroll(object sender, EventArgs e)
        {
        }

        private void bDifference_Click(object sender, EventArgs e)
        {
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            _assistant.SaveFile();
        }

        public void SetAssistant(Assistant assistant)
        {
            _assistant = assistant;
        }
    }
}
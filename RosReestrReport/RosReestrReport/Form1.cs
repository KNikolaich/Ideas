using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace RosReestrReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                // webBrowser1.Url = new Uri(ofd.FileName);
                // webBrowser1.ScriptErrorsSuppressed = true;
                // MessageBox.Show("Подождите...");
                DisplayXml(ofd.FileName);

            }
        }

        private void DisplayXml(string xmlString)
        {
            // Load the xslt used by IE to render the xml
            XslCompiledTransform xTrans = new XslCompiledTransform();
            xTrans.Load("https://portal.rosreestr.ru/xsl/EGRP/Reestr_Extract_Big/ROOM/07/Common.xsl");

            // Read the xml string.
            StringReader sr = new StringReader(xmlString);
            XmlReader xReader = XmlReader.Create(sr);

            // Transform the XML data
            MemoryStream ms = new MemoryStream();
            xTrans.Transform(xReader, null, ms);

            ms.Position = 0;

            // Set to the document stream
            webBrowser1.DocumentStream = ms;
        }
    }
}

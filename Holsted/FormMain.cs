using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Holsted
{
    public partial class FormMain : Form
    {
        private string fileName;
        public FormMain()
        {
            InitializeComponent();
        }

        private void bt_calculate_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadToEnd();

            IMetric metric = null;
            if (rb_holsted.Checked)
                metric = new Holsted();
            if (rb_mayers.Checked)
                metric = new Mayers();
            if (rb_borderValue.Checked)
                metric = new BorderValue();
            rtb_main.Text = metric.Calculate(str);
            sr.Close();
        }

        private void bt_chooseFile_Click(object sender, EventArgs e)
        {
            if ((open_file.ShowDialog() == DialogResult.OK) && (open_file.FileName.Length > 0))
            {
                fileName = open_file.FileName;
                tb_fileName.Text = fileName;
            }
        }
    }
}

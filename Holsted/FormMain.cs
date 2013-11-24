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
            string stri = sr.ReadToEnd();
            //stri += '\0';
            Holsted holsted = new Holsted(stri);
            string str = holsted.Calculate();
            sr.Close();
        }

        private void bt_chooseFile_Click(object sender, EventArgs e)
        {
            if ((open_file.ShowDialog() == DialogResult.OK) && (open_file.FileName.Length > 0))
                fileName = open_file.FileName;
        }
    }
}

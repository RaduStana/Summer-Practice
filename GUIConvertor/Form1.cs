using GUIConvertor.Logic;
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

namespace GUIConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static String path,fileName;
        private void BUTTOON_CALP_FILE_Click(object sender, EventArgs e)
        {
            XTSFHELPER.CreateCalpFile(path,fileName);
        }

        private void BUTTON_XTSF_FILE_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                path = dialog.FileName;
                fileName = dialog.SafeFileName;
                fileName = fileName.Substring(0,fileName.IndexOf("."));
            }
        }
    }
}

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
        static String path;
        private void BUTTOON_CALP_FILE_Click(object sender, EventArgs e)
        {
            ScriptGenerator.CreateCalpFile(path);
        }

        private void BUTTON_XTSF_FILE_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                path = dialog.FileName;
            }
        }
    }
}

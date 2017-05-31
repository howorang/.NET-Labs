using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageBrowser
{
    public partial class MainForm : Form
    {
        private Image currentImage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fullPath = openFileDialog.FileName;
            currentImage = Image.FromFile(fullPath);
            pictureBox.Image = currentImage;
            currentFileLabel.Text = fullPath;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}

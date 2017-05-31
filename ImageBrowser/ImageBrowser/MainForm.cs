using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace ImageBrowser
{
    public partial class MainForm : Form
    {
        private Bitmap currentImage;

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
            currentImage = (Bitmap) Image.FromFile(fullPath);
            pictureBox.Image = currentImage;
            currentFileLabel.Text = fullPath;

            sepiaToolStripMenuItem.Enabled = true;
            grayscaleToolStripMenuItem.Enabled = true;
            blurToolStripMenuItem.Enabled = true;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
         
        }

        private async void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AForge.Imaging.Filters.GaussianBlur blur = new GaussianBlur();
            Bitmap newImageBitmap = await filterBitmap(blur);
            currentImage = newImageBitmap;
            pictureBox.Image = currentImage;
        }

        private async void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AForge.Imaging.Filters.Sepia sepia = new Sepia();
            Bitmap newImageBitmap = await filterBitmap(sepia);
            currentImage = newImageBitmap;
            pictureBox.Image = currentImage;
        }

        private async void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AForge.Imaging.Filters.Grayscale grayscale = new Grayscale(0.2, 0.7, 0.07);
            Bitmap newImageBitmap = await filterBitmap(grayscale);
            currentImage = newImageBitmap;
            pictureBox.Image = currentImage;
        }

        private async Task<Bitmap> filterBitmap(AForge.Imaging.Filters.IFilter filter)
        {
            Bitmap newImageBitmap = filter.Apply(currentImage);
            return await Task.Run(() => filter.Apply(currentImage));
        }
    }
}

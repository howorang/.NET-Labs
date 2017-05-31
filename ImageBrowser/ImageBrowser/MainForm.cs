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
        private Pen currentPen = new Pen(Color.Black, (float)BrushThickness.Medium);
        private Point lastPenPosition;
        private bool drawingMode = false;

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            colorButton.BackColor = colorDialog.Color;
            currentPen.Color = colorDialog.Color;
        }

        private void toolStripComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            string selectedItem = (string) toolStripComboBox1.SelectedItem;

            switch (selectedItem)
            {
                case "Slim":
                    currentPen.Width = (float) BrushThickness.Slim;
                    break;
                case "Medium":
                    currentPen.Width = (float) BrushThickness.Medium;
                    break;
                case "Thick":
                    currentPen.Width = (float) BrushThickness.Thick;
                    break;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawingMode = true;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            drawingMode = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingMode)
            {
                pictureBox.CreateGraphics().DrawEllipse(currentPen,e.Location.X, e.Location.Y, 1,1);
            }
        }
    }
}

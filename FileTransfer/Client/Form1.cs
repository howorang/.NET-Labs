using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedCode;

namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient tcpclnt;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            chosenFileLabel.Text = openFileDialog1.FileName;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ipAddr = ipTextBox.Text;
                int port = int.Parse(portTextBox.Text);
                tcpclnt = new TcpClient();
                tcpclnt.Connect(ipAddr, port);
                isConnected.Text = "POLACZONO";
            }
            catch (Exception exception)
            {
                isConnected.Text = "BRAK POLACZENIA";
                MessageBox.Show(exception.Message, "Błąd" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string fullPath = openFileDialog1.FileName;
            Task.Run(() => sendFile(fullPath));
        }

        private void sendFile(string fullPath)
        {
            byte[] bytes = File.ReadAllBytes(fullPath);
            string fileName = openFileDialog1.SafeFileName;
            int size = bytes.Length;

            FileTransfer newFileTransfer = new FileTransfer(fileName, size, bytes);

            Stream tcpStream = tcpclnt.GetStream();
            IFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(tcpStream, newFileTransfer);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tcpclnt.Close();
            isConnected.Text = "ROZLACZONO";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCode
{
    [Serializable]
    public class FileTransfer
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public byte[] Content { get; set; }

        public FileTransfer()
        {
        }

        public FileTransfer(string name, int size, byte[] content)
        {
            Name = name;
            Size = size;
            Content = content;
        }
    }
}

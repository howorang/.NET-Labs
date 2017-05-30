using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCode;

namespace Server
{
    class FileManager
    {
        private static readonly object lockObject = new object();

        public static void save(FileTransfer fileTransfer)
        {
            string path = System.Environment.CurrentDirectory + @"\";
            string fileName = fileTransfer.Name;
            string filePath = path + fileName;
            lock (lockObject)
            {
                int i = 0;
                while (true)
                {
                    if (File.Exists(filePath))
                    {
                        filePath = path + fileName + ++i;
                        continue;
                    }
                    break;
                }
                
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    stream.Write(fileTransfer.Content, 0, fileTransfer.Size);
                }
            }
        }

    }
}

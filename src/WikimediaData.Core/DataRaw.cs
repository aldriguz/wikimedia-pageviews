using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Library.Compression;

namespace WikimediaData.Core
{
    public class DataRaw
    {
        private readonly string TempFolderPath = "C:\\TempWiki\\";

        // 1. Download files



        // 2. Decompress files
        public void DecompressData(string folderPath)
        {
            DirectoryInfo directorySelected = new DirectoryInfo(folderPath);

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                GZip.Decompress(fileToDecompress);
            }
        }
    }
}

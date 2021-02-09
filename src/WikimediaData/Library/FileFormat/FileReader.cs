using System;
using System.IO;
using WikimediaData.Entities;
using WikimediaData.Interfaces;

namespace WikimediaData.Library.FileFormat
{
    public class FileReader : IDataReader, IDisposable
    {
        private PageViewCollection fileData;
        private string targetFileNoExt;

        public FileReader(string targetFileNoExt)
        {
            this.targetFileNoExt = targetFileNoExt;
        }

        #region read data
        public PageViewCollection GetDataToCollection()
        {
            this.fileData = new PageViewCollection();
            Console.WriteLine(string.Concat("Reading file ", targetFileNoExt, "..."));

            using (FileStream fs = File.Open(targetFileNoExt, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //TODO: can optimize memory usage, by injecting the logix line by line
                    fileData.AddPageView(GetEntry(line));
                }
            }

            return fileData;
        }

        private PageViewEntry GetEntry(string line)
        {
            PageViewEntry entry = new PageViewEntry();
            //domainCode pageTitle viewCount responseSize
            string[] data = line.Split(' ');

            entry.DomainCode = data[0];
            entry.PageTitle = data[1];
            entry.ViewCount = Convert.ToUInt32(data[2]);
            //entry.ResponseSize = Convert.ToUInt16(data[3]);

            return entry;
        }
        #endregion

        public void Dispose()
        {
            this.fileData.Dispose();
        }
    }
}

using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using WikimediaData.Entities;
using WikimediaData.Interfaces;

namespace WikimediaData.Library.FileFormat
{
    public class FileProvider : IDataProvider
    {
        private string TargetPath;
        private string SourceUrl;

        public void VerifyDataTempLocation(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Ooops! Folder name is needed to process the data");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }
        public void CleaningData()
        {
            throw new NotImplementedException();
        }
        public void DownloadData()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(new Uri(this.SourceUrl), this.TargetPath);
            }
        }
        public void SetConfigurationByPeriod(DateTime period)
        {
            string year = period.Year.ToString();
            string month = period.ToString("MM");
            string formatedDate = period.ToString("yyyyMMdd");

            this.SourceUrl = String.Format(Config.PageViewBaseUrlTemplate, year, year, month, formatedDate, Config.LastDayHourReport);
            this.TargetPath = String.Format(Config.FileNameTemplate, formatedDate, Config.LastDayHourReport);
        }
        
        #region async 
        public void DownloadDataAsync()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += OnDownloadProgressChanged;
                wc.DownloadFileCompleted += OnDownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(this.SourceUrl), this.TargetPath); //here private 
            }
        }
        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(+e.ProgressPercentage + "%");
        }
        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine("Oops! An error occurred when download the file");
            }

            Console.WriteLine("Download complete, press any key to continue...");
        }
        #endregion

        #region read data
        public PageViewCollection GetDataToCollection(DateTime period)
        {
            PageViewCollection fileData = new PageViewCollection();
            string fullFilePath = String.Format(Config.TempFolderPath, period.Ticks.ToString(), "\\");

            using (FileStream fs = File.Open(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
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
            entry.ResponseSize = Convert.ToUInt32(data[3]);

            return entry;
        }

        #endregion

        #region other methods
        public string GetDataPath(DateTime period)
        {
            return string.Concat(Config.TempFolderPath, period.Ticks.ToString());
        }
        #endregion
    }
}

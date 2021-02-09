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
        private string TargetFile;
        private string TargetFileNoExt; //file with no extension
        private string SourceUrl;
        private string TargetDirectory;

        public void VerifyDataTempLocation()
        {
            if (string.IsNullOrEmpty(TargetDirectory))
                throw new ArgumentNullException("Ooops! Folder name is needed to process the data");

            if (!Directory.Exists(TargetDirectory))
            {
                Directory.CreateDirectory(TargetDirectory);
            }

        }
        public void CleaningData()
        {
            throw new NotImplementedException();
        }
        public void DownloadData()
        {
            Console.WriteLine(string.Concat("Downloading file ", this.TargetFile, "..."));

            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(new Uri(this.SourceUrl), this.TargetFile);
            }
        }
        public void SetConfigurationByPeriod(DateTime period, string folderName)
        {            
            string year = period.Year.ToString();
            string month = period.ToString("MM");
            string formatedDate = period.ToString("yyyyMMdd");
            string targetFileName = String.Format(Config.FileNameTemplate, formatedDate, Config.LastDayHourReport);
            string targetFileNameNoExt = String.Format(Config.FileNameRawTemplate, formatedDate, Config.LastDayHourReport);

            this.SourceUrl = String.Format(Config.PageViewBaseUrlTemplate, year, year, month, formatedDate, Config.LastDayHourReport);
            this.TargetFile = string.Concat(folderName, "\\", targetFileName);
            this.TargetFileNoExt = string.Concat(folderName, "\\", targetFileNameNoExt);
            this.TargetDirectory = folderName;
        }
        
        #region async 
        public void DownloadDataAsync()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += OnDownloadProgressChanged;
                wc.DownloadFileCompleted += OnDownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(this.SourceUrl), this.TargetFile); //here private 
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

        #region other methods
        public string GetDataPath(DateTime period)
        {
            return string.Concat(Config.TempFolderPath, period.Ticks.ToString());
        }
        public string GetTargetFileNoExt()
        {
            return this.TargetFileNoExt;
        }
        #endregion
    }
}

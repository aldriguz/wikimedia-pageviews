using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Library
{
    public class FileDataSource
    {   
        //https://dumps.wikimedia.org/other/pageviews/2015/2015-05/pageviews-20150501-010000.gz
        private readonly string PageViewBaseUrlTemplate = "https://dumps.wikimedia.org/other/pageviews/{0}/{1}-{2}/pageviews-{3}-{4}.gz";
        private readonly string FileNameTemplate = "pageviews-{0}-{1}.gz";
        private readonly string FileNameRawTemplate = "pageviews-{0}-{1}";
        private readonly string TempFolderPath = "C:\\TempWiki\\";
        private readonly string TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string LastDayHourReport = "000000"; //range 23hrs to 00hrs (last report)
        private ProgressBar ProgressBar;


        public FileDataSource()
        {
            //this.ProgressBar = new ProgressBar();
        }

        public string GetDataPath(string folderName)
        {
            return string.Concat(TempFolderPath, folderName);
        }

        public string GetPathRawFileName(DateTime fileDate)
        {
            string year = fileDate.Year.ToString();
            string month = fileDate.ToString("MM");
            string formatedDate = fileDate.ToString("yyyyMMdd");
            string fileName = String.Format(FileNameRawTemplate, formatedDate, LastDayHourReport);

            return string.Concat(TempFolderPath, fileDate.Ticks.ToString(), "\\", fileName);
        }

        public string VerifyFolder(string folderName)
        {
            string path = string.Concat(TempFolderPath, folderName , "\\");

            if (string.IsNullOrEmpty(folderName))
                throw new ArgumentNullException("Ooops! Folder name is needed to process the data");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
                
            return path;
        }


        public void DownloadFile(DateTime fileDate, string file)
        {

            string year = fileDate.Year.ToString();
            string month = fileDate.ToString("MM");
            string formatedDate = fileDate.ToString("yyyyMMdd");
            string fileUrl = String.Format(PageViewBaseUrlTemplate, year, year, month, formatedDate, LastDayHourReport);
            string fileName = String.Format(FileNameTemplate, formatedDate, LastDayHourReport);

            string path = VerifyFolder(fileDate.Ticks.ToString());

            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(new Uri(fileUrl), string.Concat(path, fileName));
            }
        }

        
        public void DownloadFileAsync(DateTime fileDate, string file)
        {
            string year = fileDate.Year.ToString();
            string month = fileDate.ToString("MM");
            string formatedDate = fileDate.ToString("yyyyMMdd");
            string fileUrl = String.Format(PageViewBaseUrlTemplate, year, year, month, formatedDate, LastDayHourReport);
            string fileName = String.Format(FileNameTemplate, formatedDate, LastDayHourReport);

            string path = VerifyFolder(fileDate.Ticks.ToString());

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += OnDownloadProgressChanged;
                wc.DownloadFileCompleted += OnDownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(fileUrl), string.Concat(path, fileName));
            }
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.Clear();
            Console.WriteLine(+ e.ProgressPercentage + "%");            
            //this.ProgressBar.Report(e.ProgressPercentage / 100);
            //Console.WriteLine(e.BytesReceived + " bytes of " + e.TotalBytesToReceive + " bytes");
        }

        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                Console.WriteLine("Oops! An error occurred when download the file");
            }

            Console.WriteLine("Download complete, press any key to continue...");
            string key = Console.ReadLine();
            //Console.WriteLine("Thanks!" + key);

            this.ProgressBar.Dispose();
        }
    }
}

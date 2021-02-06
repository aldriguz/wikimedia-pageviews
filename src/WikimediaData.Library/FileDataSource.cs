using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Library
{
    public class FileDataSource
    {
        //https://dumps.wikimedia.org/other/pageviews/2015/2015-05/pageviews-20150501-010000.gz
        private readonly string PageViewBaseUrl = "https://dumps.wikimedia.org/other/pageviews/{0}/{1}-{2}/pageviews-{3}-{4}.gz";
        private readonly string TempFolderPath = "D:\\TempWiki\\";
        private readonly string LastDayHourReport = "000000"; //range 23hrs to 00hrs (last report)

        public void DownloadFile(DateTime fileDate, string file)
        {

            string year = fileDate.Year.ToString();
            string month = fileDate.Month.ToString();
            string formatedDate = fileDate.ToString("yyyyMMdd");
            string fileUrl = String.Format(PageViewBaseUrl, year, year, month, formatedDate, LastDayHourReport);


            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(fileUrl, string.Concat(TempFolderPath, file));
            }
        }
    }
}

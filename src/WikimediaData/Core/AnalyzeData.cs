using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Compression;
using WikimediaData.Data;
using WikimediaData.Entities;
using WikimediaData.Library.FileFormat;

namespace WikimediaData.Core
{
    public class AnalyzeData
    {
        private GZip GZip;
        private FileProvider FileData;
        private int DaysNumber;
        private DateTime StartPeriod;

        #region constructor
        public AnalyzeData(int daysNumber, DateTime startPeriod)
        {
            this.GZip = new GZip();
            this.FileData = new FileProvider();
            this.DaysNumber = daysNumber;
            this.StartPeriod = startPeriod;
        }
        #endregion

        public PageViewCollection GetContentByPeriod(DateTime periodDate)
        {
            PageViewCollection entries = new PageViewCollection();

            return entries;
        }

        public void RunMainProcess()
        {
            LanguageDomainReport firstReport = new LanguageDomainReport();
            LanguagePageReport secondReport = new LanguagePageReport();


            DateTime endPeriod = StartPeriod.AddDays(this.DaysNumber * Config.OperatorBackDays);
            DateTime startPeriod = StartPeriod;

            string path = FileData.GetDataPath(startPeriod);

            PageViewsRawData pageViewData = new PageViewsRawData(GZip, FileData, this.DaysNumber);
            pageViewData.DownloadAllPeriodsData(startPeriod, endPeriod);
            pageViewData.DecompressData(path);

            CollectionsData processData = new CollectionsData();
            
            //Process each file (period) and get the ressults
            do
            {
                startPeriod = startPeriod.AddDays(Config.OperatorBackDays);

                PageViewCollection periodCollection =  FileData.GetDataToCollection(startPeriod);
                //First report
                firstReport.AddLanguageDomain(processData.GetLanguageAndDomainCount(periodCollection));

                //Second report
                secondReport.AddLanguagePage(processData.GetLanguagePageCount(periodCollection));

            } while (!startPeriod.Equals(endPeriod));

            //Report the results

        }
    }
}

﻿using System;
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
        private InMemoryDomainData domainData;
        private FileProvider FileData;
        private int DaysNumber;
        private DateTime StartPeriod;

        #region constructor
        public AnalyzeData(int daysNumber, DateTime startPeriod)
        {
            this.GZip = new GZip();
            this.FileData = new FileProvider();
            this.domainData = new InMemoryDomainData();
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
            string targetFile;

            DateTime endPeriod = StartPeriod.AddDays(this.DaysNumber * Config.OperatorBackDays);
            DateTime startPeriod = StartPeriod;

            string directoryPath = FileData.GetDataPath(startPeriod);

            PageViewsRawData pageViewData = new PageViewsRawData(GZip, FileData, this.DaysNumber);
            pageViewData.DownloadAllPeriodsData(startPeriod, endPeriod, directoryPath);
            pageViewData.DecompressData(directoryPath);

            CollectionsData processData = new CollectionsData(domainData);
            
            startPeriod = StartPeriod;
            //Process each file (period) and get the ressults
            do
            {
                FileData.SetConfigurationByPeriod(startPeriod, directoryPath);
                targetFile = FileData.GetTargetFileNoExt();

                //for free memory related to last analysis
                using (FileReader fr = new FileReader(targetFile))
                {
                    Console.WriteLine(string.Concat("Processing data in file ", targetFile, "..."));

                    //container of data to analyze
                    PageViewCollection periodCollection = fr.GetDataToCollection();

                    //First report
                    LanguageDomain languageDomain = processData.GetLanguageAndDomainCount(periodCollection);
                    languageDomain.Period = startPeriod;
                    firstReport.AddLanguageDomain(languageDomain);

                    //Second report
                    LanguagePage languagePage = processData.GetLanguagePageCount(periodCollection);
                    languagePage.Period = startPeriod;
                    secondReport.AddLanguagePage(languagePage);
                }

                startPeriod = startPeriod.AddDays(Config.OperatorBackDays);

            }
            while (startPeriod.CompareTo(endPeriod) != 0);

            //Report the results
            ConsoleReport.DisplayLanguageDomainCount(firstReport);
            ConsoleReport.DisplayLanguagePageMaxCount(secondReport);
        }
    }
}

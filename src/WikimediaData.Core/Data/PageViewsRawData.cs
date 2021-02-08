using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Entities;
using WikimediaData.Interfaces;

namespace WikimediaData.Data
{
    public class PageViewsRawData
    {       
        private ICompression Compresor;
        private IDataProvider DataProvider;
        private int LastNumberDays;

        #region constructor
        public PageViewsRawData(ICompression compressor, IDataProvider dataProvider, int lastNumberDays)
        {
            this.DataProvider = dataProvider;
            this.Compresor = compressor;
            this.LastNumberDays = lastNumberDays;
        }
        #endregion


        #region Download data
        public void DownloadAllPeriodsData(DateTime startPeriod, DateTime endPeriod)
        {
            //DateTime endPeriod = startPeriod.AddDays(LastNumberDays * Config.OperatorBackDays);
            do 
            {
                DownloadByPeriod(startPeriod);
                startPeriod = startPeriod.AddDays(Config.OperatorBackDays);

            } while (!startPeriod.Equals(endPeriod));
        }
        
        public void DownloadByPeriod(DateTime period)
        {
            DataProvider.SetConfigurationByPeriod(period);
            DataProvider.DownloadData();
        }
        #endregion

        #region Decompressing data
        public void DecompressData(string folderPath)
        {
            DirectoryInfo directorySelected = new DirectoryInfo(folderPath);

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles(Compresor.GetFileExtensionPattern()))
            {
                Compresor.Decompress(fileToDecompress);
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Entities;

namespace WikimediaData.Interfaces
{
    public interface IDataProvider
    {
        void VerifyDataTempLocation(string path);
        void SetConfigurationByPeriod(DateTime period);
        void DownloadData();
        void CleaningData();

        #region async methods
        void DownloadDataAsync();
        #endregion

        #region read data
        PageViewCollection GetDataToCollection(DateTime period);
        #endregion
    }
}

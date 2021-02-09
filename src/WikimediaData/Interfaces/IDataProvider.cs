using System;

namespace WikimediaData.Interfaces
{
    public interface IDataProvider
    {
        void VerifyDataTempLocation();
        void SetConfigurationByPeriod(DateTime period, string folderName);
        void DownloadData();
        void CleaningData();

        #region async methods
        void DownloadDataAsync();
        #endregion
    }
}

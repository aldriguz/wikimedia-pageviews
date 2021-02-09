using WikimediaData.Entities;

namespace WikimediaData.Interfaces
{
    public interface IDataReader
    {
        #region read data
        PageViewCollection GetDataToCollection();
        #endregion
    }
}

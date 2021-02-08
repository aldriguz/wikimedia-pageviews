using System;
using System.Configuration;

namespace WikimediaData.Entities
{
    public static class Config
    {
        public static string TempFolderPath = ConfigurationManager.AppSettings["TempFolderPath"];
        public static string PageViewBaseUrlTemplate = ConfigurationManager.AppSettings["PageViewBaseUrlTemplate"];
        public static string FileNameTemplate = ConfigurationManager.AppSettings["FileNameTemplate"];
        public static string FileNameRawTemplate = ConfigurationManager.AppSettings["FileNameRawTemplate"];
        public static string LastDayHourReport = ConfigurationManager.AppSettings["LastDayHourReport"];
        public static string TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public const int OperatorBackDays = -1;
    }
}

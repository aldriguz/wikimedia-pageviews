using System;

namespace WikimediaData.Entities
{
    public class LanguageDomain
    {
        public DateTime Period { get; set; }
        public string LanguageCode { get; set; }
        public string Domain { get; set; }
        public uint ViewCount { get; set; }
    }
}

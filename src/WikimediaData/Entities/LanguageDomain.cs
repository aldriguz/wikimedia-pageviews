using System;

namespace WikimediaData.Entities
{
    public class LanguageDomain
    {
        public DateTime Period { get; set; }
        public string LanguageCode { get; set; }
        public string Domain { get; set; }
        public uint ViewCount { get; set; }

        public override string ToString()
        {
            return string.Concat("\t", this.Period.ToString("yyyyMMdd"), "\t ", this.LanguageCode, "\t\t", this.Domain, "\t", this.ViewCount);
        }
    }
}

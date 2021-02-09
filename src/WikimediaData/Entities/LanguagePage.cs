using System;

namespace WikimediaData.Entities
{
    public class LanguagePage
    {
        public DateTime Period { get; set; }
        public string Page { get; set; }
        public uint ViewCount { get; set; }

        public override string ToString()
        {
            return string.Concat("\t", this.Period.ToString("yyyyMMdd"), "\t", this.Page, "\t", this.ViewCount);
        }
    }
}

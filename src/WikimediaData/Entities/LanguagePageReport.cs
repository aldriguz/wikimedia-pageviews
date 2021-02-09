using System.Collections.Generic;

namespace WikimediaData.Entities
{
    public class LanguagePageReport
    {
        public List<LanguagePage> Data { get; set; }

        public LanguagePageReport()
        {
            this.Data = new List<LanguagePage>();
        }

        public void AddLanguagePage(LanguagePage item)
        {
            if (this.Data != null)
                this.Data.Add(item);
        }
    }
}

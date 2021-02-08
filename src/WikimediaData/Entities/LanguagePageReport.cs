using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Entities
{
    public class LanguagePageReport
    {
        public List<LanguagePage> Data { get; set; }

        public string ProcessIdentifier { get; set; }

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

using System.Collections.Generic;

namespace WikimediaData.Entities
{
    public class LanguageDomainReport
    {
        public List<LanguageDomain> Data { get; set; }
        public string ProcessIdentifier { get; set; }

        public LanguageDomainReport()
        {
            this.Data = new List<LanguageDomain>();
        }

        public void AddLanguageDomain(LanguageDomain item)
        {
            if (this.Data != null)
                this.Data.Add(item);
        }
    }
}

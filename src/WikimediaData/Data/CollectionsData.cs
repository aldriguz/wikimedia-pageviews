using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Entities;

namespace WikimediaData.Data
{
    public class CollectionsData
    {
        public LanguageDomain GetLanguageAndDomainCount(PageViewCollection periodCollection)
        {
            LanguageDomain report = new LanguageDomain();

            var topEntry = periodCollection.Data.Where(x => x.ViewCount > 0)
                                .OrderByDescending(x => x.ViewCount)
                                .FirstOrDefault();


            report.Domain = ""; //GetDomain
            report.LanguageCode = "";
            report.ViewCount = topEntry.ViewCount;

            return report;
        }

        public LanguagePage GetLanguagePageCount(PageViewCollection periodCollection)
        {
            LanguagePage report = new LanguagePage();




            return report;
        }
    }
}

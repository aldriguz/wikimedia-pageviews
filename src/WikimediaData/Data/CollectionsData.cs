using System;
using System.Linq;
using WikimediaData.Entities;
using WikimediaData.Interfaces;

namespace WikimediaData.Data
{
    public class CollectionsData
    {
        private readonly IDomainData domainData;
        
        #region constructor
        public CollectionsData(IDomainData domainData) 
        {
            this.domainData = domainData;
        }
        #endregion

        public LanguageDomain GetLanguageAndDomainCount(PageViewCollection periodCollection)
        {
            LanguageDomain report = new LanguageDomain();

            var entry = periodCollection.Data.Where(e => e.ViewCount > 0)
                .GroupBy(x => x.DomainCode)
                .Select(y => new PageViewEntry
                {
                    DomainCode = y.Key,
                    ViewCount = Convert.ToUInt32(y.Sum(s => s.ViewCount)),
                })
                .OrderByDescending(x => x.ViewCount)
                .FirstOrDefault();

            report.Domain = domainData.GetDomainNameByCode(entry.DomainCode); //domain
            report.LanguageCode = domainData.GetLanguage(entry.DomainCode); //language from domain
            report.ViewCount = entry.ViewCount;

            return report;
        }

        public LanguagePage GetLanguagePageCount(PageViewCollection periodCollection)
        {
            LanguagePage report = new LanguagePage();

            var entry = periodCollection.Data.Where(e => e.ViewCount > 0)
                .GroupBy(x => x.PageTitle)
                .Select(y => new PageViewEntry
                {
                    PageTitle = y.Key,
                    ViewCount = Convert.ToUInt32(y.Sum(s => s.ViewCount)),
                })
                .OrderByDescending(x => x.ViewCount)
                .FirstOrDefault();

            report.Page = entry.PageTitle; //page tittle
            report.ViewCount = entry.ViewCount;

            return report;
        }
    }
}

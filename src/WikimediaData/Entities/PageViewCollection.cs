using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Entities
{
    public class PageViewCollection : IDisposable
    {
        public List<PageViewEntry> Data;
        private DateTime? PeriodDate;
        public string StrPeriodDate;

        #region constructors
        public PageViewCollection()
        {
            this.Data = new List<PageViewEntry>();
        }

        public PageViewCollection(DateTime periodDate)
        {
            this.Data = new List<PageViewEntry>();
            this.PeriodDate = periodDate;
            this.StrPeriodDate = periodDate.ToString("yyyyMMdd");
        }
        #endregion

        public void SetPeriodDate(DateTime periodDate)
        {
            this.PeriodDate = periodDate;
            this.StrPeriodDate = periodDate.ToString("yyyyMMdd");
        }

        public string GetPeriodDate()
        {
            return this.StrPeriodDate;
        }

        public void AddPageView(PageViewEntry entry)
        {
            if (this.Data != null)
                this.Data.Add(entry);
        }

        public void Dispose()
        {
            this.Data = null;
        }
    }
}

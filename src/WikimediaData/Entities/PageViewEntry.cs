using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Entities
{
    public class PageViewEntry
    {
        public string DomainCode { get; set; }
        public string PageTitle { get; set; }
        public uint ViewCount { get; set; } //max value 4200M
        //public ushort ResponseSize { get; set; }//max value ~32K
    }
}

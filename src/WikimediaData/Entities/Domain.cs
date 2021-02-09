using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Entities
{
    public class Domain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string TrailingPart { get; set; }
    }
}

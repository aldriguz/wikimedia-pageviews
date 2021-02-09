using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Entities;

namespace WikimediaData.Interfaces
{
    public interface IPageViewRule
    {
        PageViewEntry ProcessEntryLine(StreamReader reader);
    }
}

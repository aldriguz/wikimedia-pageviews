using System.IO;
using WikimediaData.Entities;

namespace WikimediaData.Interfaces
{
    public interface IPageViewRule
    {
        PageViewEntry ProcessEntryLine(StreamReader reader);
    }
}

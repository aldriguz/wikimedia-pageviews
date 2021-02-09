using System.Collections.Generic;
using WikimediaData.Entities;

namespace WikimediaData.Interfaces
{
    public interface IDomainData
    {
        IEnumerable<Domain> GetAllDomains();
        Domain GetDomainByCode(string code);
        string GetDomainNameByCode(string code);
        Domain GetDomainById(int id);
        string GetLanguage(string code);
    }
}

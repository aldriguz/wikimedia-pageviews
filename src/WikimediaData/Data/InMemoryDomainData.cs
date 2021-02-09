using System.Collections.Generic;
using WikimediaData.Entities;
using WikimediaData.Interfaces;
using System.Linq;

namespace WikimediaData.Data
{
    public class InMemoryDomainData : IDomainData
    {
        private readonly List<Domain> domains;
        public InMemoryDomainData()
        {
            domains = new List<Domain>()
            {
                new Domain { Id = 1,  Name = "Wikipedia",   Code = "", TrailingPart = ".wikipedia.org"},
                new Domain { Id = 2,  Name = "Wikibooks", Code = "b", TrailingPart = ".wikibooks.org"},
                new Domain { Id = 3,  Name = "Wiktionary", Code = "d", TrailingPart = ".wiktionary.org"},
                new Domain { Id = 4,  Name = "Wikimedia Foundation", Code = "f", TrailingPart = ".wikimediafoundation.org"},
                new Domain { Id = 5,  Name = "Wikimedia", Code = "m", TrailingPart = ".wikimedia.org"},
                new Domain { Id = 6,  Name = "Whitelisted Project", Code = "mv", TrailingPart = ".m.${WHITELISTED_PROJECT}.org"},
                new Domain { Id = 7,  Name = "Wikinews", Code = "n", TrailingPart = ".wikinews.org"},
                new Domain { Id = 8,  Name = "Wikiquote", Code = "q", TrailingPart = ".wikiquote.org"},
                new Domain { Id = 9,  Name = "Wikisource", Code = "s", TrailingPart = ".wikisource.org"},
                new Domain { Id = 10, Name = "Wikiversity", Code = "v", TrailingPart = ".wikiversity.org"},
                new Domain { Id = 11, Name = "Wikivoyage", Code = "voy", TrailingPart = ".wikivoyage.org"},
                new Domain { Id = 12, Name = "MediaWiki", Code = "w", TrailingPart = ".mediawiki.org"},
                new Domain { Id = 13, Name = "Wikidata", Code = "wd", TrailingPart = ".wikidata.org"}
            };
        }


        public IEnumerable<Domain> GetAllDomains()
        {
            return domains;
        }

        public Domain GetDomainByCode(string code)
        {
            string[] domainParts = code.Split('.');
            string domainCode = "";

            if (domainParts.Length > 1)
                domainCode = domainParts[1]; //get domain from format documentation

            return domains.SingleOrDefault(d => d.Code.Equals(domainCode));
        }

        public Domain GetDomainById(int id)
        {
            return domains.SingleOrDefault(d => d.Id == id);
        }

        public string GetDomainNameByCode(string code)
        {
            return domains.SingleOrDefault(d => d.Code.Equals(code))?.Name;
        }

        public string GetLanguage(string code)
        {
            string[] domainParts = code.Split('.');

            //get domain from format documentation
            return domainParts[0];
        }
    }
}

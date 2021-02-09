using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikimediaData.Entities;

namespace WikimediaData.Core
{
    public static class ConsoleReport
    {
        const string LanguageDomainHeader = "\t Period \t Language \t Domain \t ViewCount";
        //const string LanguageDomainLineTemplate = "{0} \t {1} \t {2} \t {3}";

        const string LanguagePageMaxViewHeader = "Period \t Page \t ViewCount";
        //const string LanguagePageMaxViewTemplate = "{0} \t {1} \t {2}";

        public static void DisplayLanguageDomainCount(LanguageDomainReport report)
        {
            Console.WriteLine("Language & Domain count");
            Console.WriteLine(LanguageDomainHeader);

            foreach(LanguageDomain item in report.Data)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");
        }

        public static void DisplayLanguagePageMaxCount(LanguagePageReport report)
        {
            Console.WriteLine("Language page max view count");
            Console.WriteLine(LanguagePageMaxViewHeader);

            foreach (LanguagePage item in report.Data)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");
        }
    }
}

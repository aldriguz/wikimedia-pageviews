using System;
using System.Linq;
using WikimediaData.Entities;

namespace WikimediaData.Core
{
    public static class ConsoleReport
    {
        const string LanguageDomainHeader = "\t Period \t Language \t Domain \t ViewCount";
        const string LanguagePageMaxViewHeader = "\t Period \t Page \t\t ViewCount";

        public static void DisplayLanguageDomainCount(LanguageDomainReport report)
        {
            Console.WriteLine("\n -Language & Domain count");
            Console.WriteLine(LanguageDomainHeader);

            foreach(LanguageDomain item in report.Data.OrderByDescending(l => l.Period))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");
        }

        public static void DisplayLanguagePageMaxCount(LanguagePageReport report)
        {
            Console.WriteLine("\n -Language page max view count");
            Console.WriteLine(LanguagePageMaxViewHeader);

            foreach (LanguagePage item in report.Data.OrderByDescending(l => l.Period))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n\n");
        }
    }
}

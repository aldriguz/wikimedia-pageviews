using System;
using WikimediaData.Core;

namespace WikimediaData
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentPeriod = DateTime.Now.ToUniversalTime();
            int lastDaysNumber = 5;

            AnalyzeData dataProcessor = new AnalyzeData(lastDaysNumber, currentPeriod);
            dataProcessor.RunMainProcess();

            Console.WriteLine("Press enter to quit.");
            Console.ReadLine();
        }
    }
}

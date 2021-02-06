using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WikimediaData.Library;
using WikimediaData.Library.FileLib;

namespace WikimediaData.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessTest();
        }

        public static void ProcessTest()
        {
            Console.Write("Performing some task... ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
        public static void process()
        {
            //Process identifier
            DateTime startUtcDate = DateTime.Now.ToUniversalTime();

            Console.WriteLine("Downloading files...");
            FileDataSource file = new FileDataSource();
            file.DownloadFile(startUtcDate, startUtcDate.Ticks + "_myfile.gz");

            Console.WriteLine("Decompress files");
            DataRaw dataToDecompress = new DataRaw();
            string path = file.GetDataPath(startUtcDate.Ticks.ToString());
            dataToDecompress.DecompressData(path);

            Console.WriteLine("Fast read process");
            ReadProcess read = new ReadProcess();
            string filePath = file.GetPathRawFileName(startUtcDate);
            //read.BasicRead(filePath);
            read.FastRead(filePath);


            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();

            /*Console.Write("Performing some task... ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine("Done.");
            Console.ReadLine();*/


        }
    }
}

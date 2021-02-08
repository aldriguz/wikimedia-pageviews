using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.FileLib
{
    public class ReadProcess
    {

        public void FastRead(string filePath)
        {
            int counter = 0;
            int counterNoValid = 0;
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    counter++;
                    string[] data = line.Split(' ');
                    
                    if(data.Length < 4)
                        counterNoValid++;
                }

                Console.WriteLine("There were {0} lines.", counter);
            }
        }

        public void BasicRead(string filePath)
        {
            int counter = 0;
            int counterNoValid = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                counter++;
                string[] data = line.Split(' ');

                if (data.Length < 4)
                    counterNoValid++;
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();
        }
    }
}

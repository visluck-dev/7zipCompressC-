using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressAndMove
{
    class SevenZip
    {
        // function for compressing all items within the mentioned directory(path)
        public static void CompressDirectoryItems(string destination_Path = @"D:\TestResult\", string folderToCompress = @"D:\Testc\", string zipName = "abc", string password = "")
        {
            // 7zip application path 
            string exe7ZipPath = @"C:\Program Files\7-Zip\7z.exe";

            try
            {
                ProcessStartInfo processCompress = new ProcessStartInfo();

                // adding 7zip exe path to processStartInfo object
                processCompress.FileName = exe7ZipPath;
                //condtional selection of switches based on default argument corresponding to password
                string currentCommand = (password.Length > 0) ? $"a  -p{password}" + " -sdel -mhe=on -y \"" : "a " + " -sdel -y \"";

                // creating command line string  that is used to pass argument to 7zip process 
                string commandLineString = currentCommand + destination_Path + zipName + "\" \"" + folderToCompress + @"*";


                processCompress.Arguments = commandLineString;

                // hiding the process window
                processCompress.WindowStyle = ProcessWindowStyle.Hidden;

                //starting the 7zip process for compressing items
                Process p = Process.Start(processCompress);
                p.WaitForExit();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public static void ExtractZip(string zipPath = @"D:\TestResult\abc.7z", string extractpath = @"D:\TestC\")
        {
            string pZipPath = @"C:\Program Files\7-Zip\7z.exe";
            try
            {
                ProcessStartInfo processExtract = new ProcessStartInfo();
                processExtract.FileName = pZipPath;
                string commandLineString = "x  -o" + extractpath + " \"" + zipPath + @"""";
                processExtract.Arguments = commandLineString;

                processExtract.WindowStyle = ProcessWindowStyle.Hidden;
                Process x = Process.Start(processExtract);
                x.WaitForExit();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

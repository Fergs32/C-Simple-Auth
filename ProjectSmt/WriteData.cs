using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace ProjectSmt
{
    class WriteData
    {
        public static string CurrentDir = Directory.GetCurrentDirectory();
        public static string d = CurrentDir + "\\Userprofiles";

        public static void WriteInformation(string email, string password, string Country, byte Age)
        {
            Thread.Sleep(5000);
            string obj = (object)"{Email: \"" + email + "\", Password: \"" + password + "\", Country: \"" + Country + "\", Age: \"" + Age + "\"}";
            try
            {
                if (!Directory.Exists(d))
                {
                    Directory.CreateDirectory(d);

                }
                else
                {
                    if (Directory.Exists(d))
                    {
                        File.AppendAllText("Userprofiles/log2.txt", obj + Environment.NewLine);
                        DuplicateCheck();
                        Console.WriteLine("Duplicate check done... Press enter to continue...");
                        Console.ReadLine();
                    }
                }
            } catch(Exception ex) { Console.WriteLine(ex); Console.ReadLine(); }
               
        }
        static void DuplicateCheck()
        {
            try
            {
                string[] FileLines = File.ReadAllLines(d + "\\log2.txt");
                var noDupes = FileLines.Distinct().ToList();
                if (File.Exists(d + "\\log2.txt"))
                {
                    File.Delete(d + "\\log2.txt");
                }
                Thread.Sleep(1200);
                foreach (string line in noDupes)
                {
                    File.AppendAllText("Userprofiles/log2.txt", line + Environment.NewLine);
                }
            } catch(Exception ex) { Console.WriteLine(ex); Console.ReadLine(); }
            
        }
 
    }
}

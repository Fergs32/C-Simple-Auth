using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectSmt
{
    internal class Options : ProcessData
    {
        // Register Data
        private static string Registeremail;
        private static string Password;
        private static string Country;
        private static int Age;

        // Login Data
        private static string LoginEmail;
        private static string LoginPassword;
        public static void Register()
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\t[Register]\n");
                Console.Write("[!] Email: ");
                Registeremail = Console.ReadLine();
                Console.Write("[!] Password: ");
                Password = Console.ReadLine();
                Console.Write("[!] Country: ");
                Country = Console.ReadLine();
                Console.Write("[!] Age: ");
                int.TryParse(Console.ReadLine(), out Age);
            } 
            catch(Exception ex) 
            { 
                Console.WriteLine(ex); 
            }
            if (Registeremail != "" && Password != "" && Country != "")
            {
                Console.Clear();
                Console.WriteLine("\n\n\t[Confirmation]\n");
                Console.Write("Email: " + Registeremail + " | Password: " + Password + " | Country: " + Country + " | Age: " + Age + "\n");
                Console.WriteLine("[Input (OK | CANCEL) ]: "); string ureply;
                ureply = Console.ReadLine();
                switch (ureply)
                {
                    case "OK":
                        Console.WriteLine("Successfully registered...");
                        Thread.Sleep(1000);
                        ProcessInfo(Registeremail, Password, Country, (byte)Age);
                        Console.Clear();
                        break;
                    case "CANCEL":
                        Thread.Sleep(-1);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("One of the answers you didn't enter anything, please restart and enter valid information in each field.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }

        }

        public static void Login()
        {
            int LoginRetries;
            string username = "";
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                string[] Users = File.ReadAllLines(d + "\\log2.txt");
                Console.Clear();
                Console.WriteLine("\n\n\t[Login   | Users: {0} ]\n", (object)Users.Count());
                Console.Write("[!] Email: ");
                LoginEmail = Console.ReadLine();
                Console.Write("[!] Password: ");
                LoginPassword = Console.ReadLine();
                bool Result = ProcessData.RetreiveInformation(LoginEmail, LoginPassword);
                if (Result)
                {
                    try
                    {
                        string s = LoginEmail;
                        username = s.Substring(0, s.IndexOf('@'));                       
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex); Console.ReadLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[!] Login Successful, welcome back {0}!", username);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Login Failed!");
                    Console.ResetColor();
                }
                Console.ReadLine();
            } 
            catch(Exception ex) { 
                Console.WriteLine(ex); Console.ReadLine(); 
            }
        }

        public static void Help()
        {

        }

    }
}

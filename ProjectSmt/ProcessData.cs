using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Collections.Concurrent;
using System.Threading;

namespace ProjectSmt
{
    class ProcessData : WriteData
    {
        protected static string UserEmail;
        protected static string UserPassword;
        protected static string UserCountry;
        protected static byte UserAge;
        private static int Strength;

        public static void ProcessInfo(string email, string password, string Country, byte Age)
        {
            Program.UserEmail = email; Program.UserPassword = password; Program.UserCountry = Country; Program.UserAge = Age;
            Console.Write("Processing your data"); Thread.Sleep(1000);
            Program.ProccessEmail(email);
            Console.Write(".");
            Program.ProcessAge(Age);
            Thread.Sleep(1000);
            Console.Write(".");
            Program.ProcessPassword(password);
            Thread.Sleep(1000);
            Console.Write(".\n");
            Console.WriteLine("[!] All checks passed, now setting up account");
            WriteData.WriteInformation(UserEmail, UserPassword, UserCountry, UserAge);
            Console.Clear();
            Console.WriteLine("[!] Account created, redirecting to login.");
            Program.Login();
            Console.ReadLine();


        }
        protected static void ProccessEmail(string Email)
        {
            try
            {
                if (!Email.Contains("@"))
                {
                    Console.Write("\n[Email Error]: Invalid email entered, would you like to re-enter? (OK | CANCEL): "); string ureply;
                    ureply = Console.ReadLine();
                    switch (ureply)
                    {
                        case "OK":
                            Console.Write("New Email: ");
                            Program.UserEmail = Console.ReadLine();
                            if (!Program.UserEmail.Contains("@"))
                            {
                                Environment.Exit(0);
                            }
                            Console.WriteLine("Redirecting to menu..."); Thread.Sleep(1000);
                            break;
                        case "CANCEL":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid reply entered, closing application.");
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); Console.ReadLine();
            }
        }
        protected static void ProcessAge(byte Age)
        {
            try
            {
                if (Age >= 100)
                {
                    Console.Write("\n[Age Error]: Invalid Age entered, would you like to re-enter? (OK | CANCEL): "); string ureply;
                    ureply = Console.ReadLine();
                    switch (ureply)
                    {
                        case "OK":
                            Console.Write("New Age: ");
                            byte.TryParse(Console.ReadLine(), out Program.UserAge);
                            if (Program.UserAge >= 100)
                            {
                                Environment.Exit(0);
                            }
                            Console.WriteLine("Redirecting to menu..."); Thread.Sleep(1000);
                            break;
                        case "CANCEL":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid reply entered, closing application.");
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); Console.ReadLine();
            }
        }
        protected static void ProcessPassword(string Pass)
        {
            var Inputpass = Pass;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            try
            {
                if (!hasLowerChar.IsMatch(Inputpass))
                {
                    Program.Strength++;
                }
                if (!hasUpperChar.IsMatch(Inputpass))
                {
                    Program.Strength++;
                }
                if (!hasNumber.IsMatch(Inputpass))
                {
                    Program.Strength++;
                }
                if (!hasSymbols.IsMatch(Inputpass))
                {
                    Program.Strength++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); Console.ReadLine();
            }
            if (Program.Strength > 1)
            {
                Console.Write("\n[Password authentication]: Password is not strong enough! Would you like to re-enter it? (OK | CANCEL): "); string ureply;
                ureply = Console.ReadLine();
                switch (ureply)
                {
                    case "OK":
                        try
                        {
                            Console.Write("New password (must contain [symbols, uppercase, lowercase, numbers]): ");
                            Program.UserPassword = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex); Console.ReadLine();
                        }
                        Console.WriteLine("Redirecting to menu..."); Thread.Sleep(1000);
                        break;
                    case "CANCEL":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid reply entered, closing application.");
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static bool RetreiveInformation(string email, string password)
        {
            bool CC = false;
            int profiles = 0;
            string CurrentDirectory = WriteData.CurrentDir;
            string Folder = CurrentDirectory + "\\Userprofiles";
            string[] Database = File.ReadAllLines(Folder + "\\log2.txt");
            try
            {
                foreach (string line in Database)
                {
                    if (line.Contains(email) && line.Contains(password))
                    {
                        CC = true;
                        profiles++;
                    }
                    else
                    {
                        profiles++;
                    }
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex); Console.ReadLine(); 
            }
            return CC;
        }
    }
}


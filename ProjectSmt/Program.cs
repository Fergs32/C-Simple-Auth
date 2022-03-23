using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ProjectSmt
{
    internal class Program : Options
    {
        private static int Option;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t[Options]\n");
                Thread.Sleep(150);
                Console.WriteLine("[1] Register");
                Thread.Sleep(150);
                Console.WriteLine("[2] Login");
                Thread.Sleep(150);
                Console.WriteLine("[3] Help\n");
                Thread.Sleep(150);
                Console.Write("[Input]: ");
            } 
            while (!int.TryParse(Console.ReadLine(), out Option));
            switch (Option)
            {
                case 1:
                    Options.Register();
                    break;
                case 2:
                    Options.Login();
                    break;
                case 3:
                    Options.Help();
                    break;
                default:
                    Console.WriteLine("No Input selected or invalid.");
                    Console.ReadLine();
                    break;
            }
            
        }
    }
}

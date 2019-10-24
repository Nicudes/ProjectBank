using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProject
{
    class Colours
    {
        public static void Red(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ResetColor();
        }

        public static void Green(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input);
            Console.ResetColor();
        }

        public static void Cyan(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(input);
            Console.ResetColor();
        }
    }
}

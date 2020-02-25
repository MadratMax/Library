using System;

namespace Library
{
    class Logger
    {
        public static void PrintMessage(string message)
        {
            Console.Clear();
            Console.WriteLine("---");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("---\nPress any key to back to main");
            Console.ReadKey();
        }

        public static void PrintError(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine("---");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + errorMessage);
            Console.ResetColor();
            Console.WriteLine("---\nPress any key to back to main");
            Console.ReadKey();
        }

        public static void PrintCriticalError(string errorMessage)
        {
            Console.Clear();
            Console.WriteLine("---");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CRITICAL ERROR: " + errorMessage);
            Console.ResetColor();
            Console.WriteLine("---\nPress any key to exit");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(-1);
        }
    }
}
using System;
using ANSIConsole;

namespace ExampleANSIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // AnsiCodes();
            AnsiConsole();
        }

        static void AnsiConsole()
        {
            ANSIInitializer.Init();
            Console.WriteLine("Test");
            Console.WriteLine("Test".Bold());
        }

        static void AnsiCodes()
        {
            Console.WriteLine("\u001b[31mHello World!\u001b[0m");
            Console.WriteLine("\u001b[31;1;4mHello World!\u001b[0m");
            Console.WriteLine("\u001b[31m\u001b[1;4mHello World!\u001b[0m");
            Console.WriteLine("\u001b[31m\u001b[1mHello World!\u001b[0m");
            // Console.WriteLine("\u001b[2J"); // Clear the screan
        }
    }
}

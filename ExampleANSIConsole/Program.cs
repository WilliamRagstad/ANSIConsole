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
            Console.Write("Test".Bold().Color("#ffbb00").NoClear());
            Console.WriteLine("Spill".Clear());
            Console.WriteLine("Test");
            Console.WriteLine("Test".Color("#ffbb00"));
            Console.WriteLine("Test".Color("#ffbb00").Bold());
            Console.WriteLine("Test".Italic());
            Console.WriteLine("Test".Underlined());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Test".StrikeThrough().Color(ConsoleColor.Red));
            Console.WriteLine("Test".Bold().Color(ConsoleColor.Red));
            Console.WriteLine("Test".Faint().Color(ConsoleColor.Red));
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

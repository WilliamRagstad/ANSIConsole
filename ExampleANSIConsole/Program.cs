using System;
using ANSIConsole;

namespace ExampleANSIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiCodes();
            AnsiConsole();
        }

        static void AnsiConsole()
        {
            ANSIInitializer.Init();
            Console.Write("Test".Bold().Color("#ffbb00").NoClear());
            Console.WriteLine("Spill".Clear());
            Console.WriteLine("Test");
            Console.WriteLine("Test".Color("#775500"));
            Console.WriteLine("Test".Color("#775500").Bold());
            Console.WriteLine("Test".Italic());
            Console.WriteLine("Test".Underlined());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Test".StrikeThrough().Color(ConsoleColor.Red));
            Console.WriteLine("Test".Bold().Color(ConsoleColor.Red));
            Console.WriteLine("Test".Faint().Color(ConsoleColor.Red).Link("https://www.williamragstad.com/"));
            Console.WriteLine("I'm blinking".Blink());
        }

        static void AnsiCodes()
        {
            Console.WriteLine("\u001b[30mHello World!\u001b[0m");
            Console.WriteLine("\u001b[31;1;4mHello World!\u001b[0m");
            Console.WriteLine("\u001b[31m\u001b[1;4mHello World!\u001b[0m");
            Console.WriteLine("\u001b[31m\u001b[1mHello World!\u001b[0m");
            // Console.WriteLine("\u001b]8;;https://www.youtube.com/\aHello World!\u001b]8;;\a");
            Console.WriteLine("\u001b]8;;https://www.youtube.com/\a\u001b[31mHello World!\u001b]8;;\a\u001b[0m");
            // Console.WriteLine("\u001b[2J"); // Clear the screan
            Console.WriteLine("\u001b[5mI'm blinking\u001b[0m");
            Console.WriteLine("\u001b[51mFramed\u001b[0m");
            Console.WriteLine("\u001b[52mEncircled\u001b[0m");
            Console.WriteLine("\u001b[53mOverlined\u001b[0m");
        }
    }
}

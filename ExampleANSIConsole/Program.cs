using System;
using System.Drawing;
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
            Console.Write("Bold with no clear - ".Bold().Color("#ffbb00").NoClear()); Console.WriteLine("formatting spills over".Clear());
            Console.WriteLine("No formatting");
            Console.WriteLine("Colored!!!".Color("#775500"));
            Console.WriteLine("Bold colored".Color("#775500").Bold());
            Console.WriteLine("Italic".Italic().Color(Color.Black).Background(ConsoleColor.Cyan));
            Console.WriteLine("Underlined".Underlined());
            Console.WriteLine("Strike through".StrikeThrough().Color(ConsoleColor.Red));
            Console.WriteLine("Bold and Overlined".Bold().Color(ConsoleColor.Red).Overlined());
            Console.WriteLine("Very faint link".Faint().Color(ConsoleColor.Red).Link("https://www.williamragstad.com/"));
            Console.WriteLine("I'm blinking".Blink());
            Console.WriteLine($"\n   This `Green|text´ has `Black|Gray|inline {"formatted".Italic().NoClear()}´ `Yellow|c´`Orange|o´`Red|l´`Purple|o´`Blue|r´`Aqua|s´\n".FormatANSI());
            Console.WriteLine("`Red|This´ is `|Green|a´ `Blue|formatted´ `string´".FormatANSI(ANSIFormatting.Bold | ANSIFormatting.Overlined, ANSIFormatting.None, ANSIFormatting.Blink, ANSIFormatting.Inverted));
            // Console.WriteLine($"`Red|{"O".Opacity(20)}{"p".Opacity(40)}{"a".Opacity(60)}{"c".Opacity(80)}{"i".Opacity(100)}{"t".Opacity(120)}{"y".Opacity(140)}´".FormatANSI());
        }

        static void AnsiCodes()
        {
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

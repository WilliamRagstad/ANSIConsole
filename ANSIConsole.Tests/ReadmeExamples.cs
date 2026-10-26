// Compiled examples from README.md. Keep these in sync when changing its C# snippets.
using System;
using System.Drawing;
using Xunit;

namespace ANSIConsole.Tests
{
    public class ReadmeExamples : IDisposable
    {
        private readonly bool wasEnabled = ANSIInitializer.Enabled;
        public ReadmeExamples() => ANSIInitializer.Enabled = true;
        public void Dispose() => ANSIInitializer.Enabled = wasEnabled;

        [Fact]
        public void Example01()
        {
            if (!ANSIInitializer.Init(false)) ANSIInitializer.Enabled = false;
        }

        [Fact]
        public void Example02()
        {
            "My text".Color(ConsoleColor.Red).ToString();
        }

        [Fact]
        public void Example03()
        {
            "My text".Color(Color.IndianRed).ToString();
        }

        [Fact]
        public void Example04()
        {
            "My text".Color("IndianRed").ToString();
        }

        [Fact]
        public void Example05()
        {
            "My text".Color("#775500").ToString();
        }

        [Fact]
        public void Example06()
        {
            "My text".Color(255, 127, 0).ToString();
        }

        [Fact]
        public void Example07()
        {
            "My text".Bold().Italic().Color("IndianRed").Underlined().StrikeThrough().Blink().ToString();
        }

        [Fact]
        public void Example08()
        {
            Console.WriteLine($"{"O".Opacity(10)}{"p".Opacity(20)}{"a".Opacity(30)}{"c".Opacity(50)}{"i".Opacity(60)}{"t".Opacity(80)}{"y".Opacity(90)}");
        }

        [Fact]
        public void Example09()
        {
            "https://www.nuget.org/packages/ANSI.Console".Link().Bold().ToString();
        }

        [Fact]
        public void Example10()
        {
            "ANSI.Console".Bold().Link("https://www.nuget.org/packages/ANSI.Console").ToString();
        }

        [Fact]
        public void Example11()
        {
            Console.WriteLine("Every second letter is yellow".MapANSI((c, i) => i % 2 == 0 ? c.Color(ConsoleColor.Yellow) : c.ToANSI()));
        }

        [Fact]
        public void Example12()
        {
            Console.WriteLine("This is a gradient".Gradient(Color.Black, Color.Yellow, Color.Red, Color.Blue, Color.Cyan));
        }

        [Fact]
        public void Example13()
        {
            Console.WriteLine("This is a gradient".GradientBackground(Color.Black, Color.Yellow, Color.Red, Color.Blue, Color.Cyan));
        }

        [Fact]
        public void Example14()
        {
            Console.WriteLine($"This `Green|text´ has `Black|Gray|inline {"formatted".Italic().NoClear()}´ `Yellow|c´`Orange|o´`Red|l´`Purple|o´`Blue|r´`Aqua|s´".FormatANSI());
        }

        [Fact]
        public void Example15()
        {
            Console.WriteLine("`Red|This´ is `|Green|a´ `Blue|formatted´ `string´".FormatANSI(ANSIFormatting.Bold | ANSIFormatting.Overlined, ANSIFormatting.None, ANSIFormatting.Blink, ANSIFormatting.Inverted));
        }

        [Fact]
        public void Example16()
        {
            Console.WriteLine($"This `text´ has `inline {"formatted".Italic().NoClear()}´ `c´`o´`l´`o´`r´`s´".FormatColor(ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.DarkMagenta, ConsoleColor.Blue, ConsoleColor.Cyan));
        }
    }
}

using System;
using System.Drawing;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace ANSIConsole.Tests
{
    public class FormattingTests : IDisposable
    {
        private readonly bool wasEnabled = ANSIInitializer.Enabled;
        public FormattingTests() => ANSIInitializer.Enabled = true;
        public void Dispose() => ANSIInitializer.Enabled = wasEnabled;

        [Theory]
        [InlineData(17, 83, 241)]
        [InlineData(0, 255, 0)]
        [InlineData(255, 0, 255)]
        public void RgbOverloadsKeepChannelOrder(int r, int g, int b)
        {
            string fg = $"\u001b[38;2;{r};{g};{b}mx\u001b[0m";
            string bg = $"\u001b[48;2;{r};{g};{b}mx\u001b[0m";
            Assert.Equal(fg, "x".Color(r, g, b).ToString());
            Assert.Equal(fg, "x".ToANSI().Color(r, g, b).ToString());
            Assert.Equal(fg, "x".Color(r, g, b, 128).ToString());
            Assert.Equal(fg, "x".ToANSI().Color(r, g, b, 128).ToString());
            Assert.Equal(bg, "x".Background(r, g, b).ToString());
            Assert.Equal(bg, "x".ToANSI().Background(r, g, b).ToString());
            Assert.Equal(bg, "x".Background(r, g, b, 128).ToString());
            Assert.Equal(bg, "x".ToANSI().Background(r, g, b, 128).ToString());
            Assert.Equal(bg, "x".Background(b: b, r: r, g: g).ToString());
        }

        [Theory]
        [InlineData(ANSIFormatting.Bold, 1)]
        [InlineData(ANSIFormatting.Faint, 2)]
        [InlineData(ANSIFormatting.Italic, 3)]
        [InlineData(ANSIFormatting.Underlined, 4)]
        [InlineData(ANSIFormatting.Blink, 5)]
        [InlineData(ANSIFormatting.Inverted, 7)]
        [InlineData(ANSIFormatting.StrikeThrough, 9)]
        [InlineData(ANSIFormatting.Overlined, 53)]
        public void StylesHaveExactSgrAndReset(ANSIFormatting style, int code) =>
            Assert.Equal($"\u001b[{code}mx\u001b[0m", "x".AddFormatting(style).ToString());

        [Fact]
        public void StyleExtensionsComposeInStableOrder()
        {
            Assert.Equal("\u001b[9m\u001b[7m\u001b[5m\u001b[53m\u001b[4m\u001b[3m\u001b[2m\u001b[1mx\u001b[0m",
                "x".Bold().Faint().Italic().Underlined().Overlined().Blink().Inverted().StrikeThrough().ToString());
            Assert.Equal("\u001b[48;2;4;5;6m\u001b[38;2;1;2;3m\u001b[3m\u001b[1mx\u001b[0m",
                "x".Bold().Color(1, 2, 3).Italic().Background(4, 5, 6).ToString());
        }

        [Fact]
        public void ResetCanBeSuppressedAndRestored()
        {
            Assert.Equal("x\u001b[0m", "x".Clear().ToString());
            Assert.Equal("\u001b[1mx", "x".Bold().NoClear().ToString());
            Assert.Equal("\u001b[1mx\u001b[0m", "x".Bold().NoClear().Clear().ToString());
            Assert.Equal("\u001b[38;2;17;83;241mx", "x".Color(17, 83, 241).NoClear().ToString());
            Assert.Equal("\u001b[48;2;17;83;241mx", "x".Background(17, 83, 241).NoClear().ToString());
            Assert.Equal("x", "x".ToANSI().NoClear().ToString());
        }

        [Fact]
        public void BackgroundGradientKeepsGreenAndBlueDistinct() =>
            Assert.Equal("\u001b[48;2;10;20;100m\u001b[38;2;255;255;255ma\u001b[0m" +
                "\u001b[48;2;20;40;150m\u001b[38;2;255;255;255mb\u001b[0m\u001b[0m",
                "ab".GradientBackground(Color.White, Color.FromArgb(10, 20, 100), Color.FromArgb(30, 60, 200)).ToString());

        [Fact]
        public void DisabledFormattingReturnsPlainText()
        {
            ANSIInitializer.Enabled = false;
            Assert.Equal("Mixed", "Mixed".Bold().Color(1, 2, 3).Background(4, 5, 6).UpperCase().Link("https://example.com").ToString());
        }

        [Fact]
        public void OpacityBlendsExplicitColors()
        {
            Assert.Equal("\u001b[48;2;0;0;0m\u001b[38;2;100;50;20mx\u001b[0m",
                "x".Color(200, 100, 40).Background(0, 0, 0).Opacity(50).ToString());
            // Also exercises unknown terminal defaults under redirected Unix output.
            Assert.Contains("\u001b[38;2;", "x".Opacity(50).ToString());
        }

        [Fact]
        public void NamedHexAndConsoleColorsAgree()
        {
            Assert.Equal("x".Color(Color.Red).ToString(), "x".Color("Red").ToString());
            Assert.Equal("x".Color(119, 85, 0).ToString(), "x".Color("#775500").ToString());
            Assert.Equal("x".Background(0, 255, 255).ToString(), "x".Background(ConsoleColor.Cyan).ToString());
        }

        [Fact]
        public void HyperlinksAndInlineFormattingKeepTheirResets()
        {
            Assert.Equal("\u001b]8;;https://example.com\ax\u001b]8;;\a\u001b[0m", "x".Link("https://example.com").ToString());
            Assert.Equal("a \u001b[38;2;255;0;0m\u001b[1mb\u001b[0m c\u001b[0m", "a `Red|b´ c".FormatANSI(ANSIFormatting.Bold).ToString());
            Assert.Equal("\u001b[38;2;255;0;0mx\u001b[0m\u001b[0m", "`x´".FormatColor(ConsoleColor.Red).ToString());
        }
    }
}

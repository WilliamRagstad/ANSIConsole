using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSIConsole
{
    public static class StringExtensions
    {
        private static ANSIString ToANSI(this string text) => new ANSIString(text);
        private static ANSIString AddFormatting(this string text, ANSIFormatting formatting) => AddFormatting(new ANSIString(text), formatting);
        private static ANSIString AddFormatting(this ANSIString text, ANSIFormatting formatting) => text.AddFormatting(formatting);
        public static ANSIString Bold(this string text) => Bold(new ANSIString(text));
        public static ANSIString Bold(this ANSIString text) => text.AddFormatting(ANSIFormatting.Bold);
        public static ANSIString Faint(this string text) => Faint(new ANSIString(text));
        public static ANSIString Faint(this ANSIString text) => text.AddFormatting(ANSIFormatting.Faint);
        public static ANSIString Italic(this string text) => Italic(new ANSIString(text));
        public static ANSIString Italic(this ANSIString text) => text.AddFormatting(ANSIFormatting.Italic);
        public static ANSIString Underlined(this string text) => Underlined(new ANSIString(text));
        public static ANSIString Underlined(this ANSIString text) => text.AddFormatting(ANSIFormatting.Underlined);
        public static ANSIString Overlined(this string text) => Overlined(new ANSIString(text));
        public static ANSIString Overlined(this ANSIString text) => text.AddFormatting(ANSIFormatting.Overlined);
        public static ANSIString Inverted(this string text) => Inverted(new ANSIString(text));
        public static ANSIString Inverted(this ANSIString text) => text.AddFormatting(ANSIFormatting.Inverted);
        public static ANSIString StrikeThrough(this string text) => StrikeThrough(new ANSIString(text));
        public static ANSIString StrikeThrough(this ANSIString text) => text.AddFormatting(ANSIFormatting.StrikeThrough);
        public static ANSIString UpperCase(this string text) => UpperCase(new ANSIString(text));
        public static ANSIString UpperCase(this ANSIString text) => text.AddFormatting(ANSIFormatting.UpperCase);
        public static ANSIString LowerCase(this string text) => LowerCase(new ANSIString(text));
        public static ANSIString LowerCase(this ANSIString text) => text.AddFormatting(ANSIFormatting.LowerCase);
        /// <summary>
        /// Warning! Using this will "spill" the current formatting onto all text after it.
        /// Manually use Clear() on some text after it to stop this from happening.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ANSIString NoClear(this ANSIString text) => text.RemoveFormatting(ANSIFormatting.Clear);
        /// <summary>
        /// Manually clear formatting after text is printed.
        /// This is done automatically unless NoClear() is used.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ANSIString Clear(this string text) => Clear(new ANSIString(text));
        /// <summary>
        /// Manually clear formatting after text is printed.
        /// This is done automatically unless NoClear() is used.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ANSIString Clear(this ANSIString text) => text.AddFormatting(ANSIFormatting.Clear);
        
        public static ANSIString Color(this string text, ConsoleColor color) => Color(new ANSIString(text), color);
        public static ANSIString Color(this ANSIString text, ConsoleColor color) => text.SetForegroundColor(color);
        public static ANSIString Color(this string text, Color color) => Color(new ANSIString(text), color);
        public static ANSIString Color(this ANSIString text, Color color) => text.SetForegroundColor(color);
        public static ANSIString Color(this string text, int r, int b, int g) => Color(new ANSIString(text), System.Drawing.Color.FromArgb(r, g, b));
        public static ANSIString Color(this string text, int r, int b, int g, int alpha) => Color(new ANSIString(text), System.Drawing.Color.FromArgb(alpha, r, g, b));
        public static ANSIString Color(this string text, ConsoleColor color, int alpha) => Color(new ANSIString(text), System.Drawing.Color.FromArgb(alpha, ANSIString.FromConsoleColor(color)));
        public static ANSIString Color(this string text, Color color, int alpha) => Color(new ANSIString(text), System.Drawing.Color.FromArgb(alpha, color));
        public static ANSIString Color(this string text, string nameOrHex) => Color(new ANSIString(text), nameOrHex);
        public static ANSIString Color(this ANSIString text, string nameOrHex) => Color(text, nameOrHex.StartsWith('#') ?
            System.Drawing.ColorTranslator.FromHtml(nameOrHex) :
            System.Drawing.Color.FromName(nameOrHex));

        public static ANSIString Background(this string text, ConsoleColor color) => Background(new ANSIString(text), color);
        public static ANSIString Background(this ANSIString text, ConsoleColor color) => text.SetBackgroundColor(color);
        public static ANSIString Background(this string text, Color color) => Background(new ANSIString(text), color);
        public static ANSIString Background(this ANSIString text, Color color) => text.SetBackgroundColor(color);
        public static ANSIString Background(this string text, int r, int b, int g) => Background(new ANSIString(text), System.Drawing.Color.FromArgb(r, g, b));
        public static ANSIString Background(this string text, int r, int b, int g, int alpha) => Background(new ANSIString(text), System.Drawing.Color.FromArgb(alpha, r, g, b));
        public static ANSIString Background(this string text, ConsoleColor color, int alpha) => Background(new ANSIString(text), System.Drawing.Color.FromArgb(alpha, ANSIString.FromConsoleColor(color)));
        public static ANSIString Background(this string text, Color color, int alpha) => Background(new ANSIString(text), System.Drawing.Color.FromArgb(alpha, color));
        public static ANSIString Background(this string text, string nameOrHex) => Background(new ANSIString(text), nameOrHex);
        public static ANSIString Background(this ANSIString text, string nameOrHex) => Background(text, nameOrHex.StartsWith('#') ?
            System.Drawing.ColorTranslator.FromHtml(nameOrHex) :
            System.Drawing.Color.FromName(nameOrHex));
        
        public static ANSIString Opacity(this string text, int alpha) => Opacity(new ANSIString(text), alpha);
        public static ANSIString Opacity(this ANSIString text, int alpha) => text.SetForegroundColor(System.Drawing.Color.FromArgb(alpha, text.GetForegroundColor()));
        public static ANSIString Blink(this string text) => Blink(new ANSIString(text));
        public static ANSIString Blink(this ANSIString text) => text.AddFormatting(ANSIFormatting.Blink);
        public static ANSIString Link(this string text, string url) => Link(new ANSIString(text), url);
        public static ANSIString Link(this ANSIString text, string url) => text.SetHyperlink(url);
        /// <summary>
        /// If string represents a URL, make that string a click-able hyperlink.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ANSIString Link(this string text) => Link(new ANSIString(text), text);
        /// <summary>
        /// Format text, applying the corresponding ANSI format in the formatting array to the matching `(color|(background|))text´ in the text.
        /// Use `|background|text` to only add background color.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="formatting"></param>
        /// <returns></returns>
        public static ANSIString FormatANSI(this string text, params ANSIFormatting[] formatting)
        {
            if (text.Count(c => c == '`') < formatting.Length) throw new FormatException("Cannot have more formatting arguments than there are corresponding `...´ pairs.");
            string result = string.Empty;
            int formatIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '`')
                {
                    string colorFG = null;
                    string colorBG = null;
                    string match = string.Empty;
                    i++;
                    while (text[i] != '´' && i < text.Length)
                    {
                        if (text[i] == '|')
                        {
                            if (colorFG == null) colorFG = match;
                            else if (colorBG == null) colorBG = match;
                            match = string.Empty;
                            i++;
                            continue;
                        }
                        match += text[i];
                        i++;
                    }

                    ANSIString ansi = match.ToANSI();
                    if (!string.IsNullOrEmpty(colorFG)) ansi = ansi.Color(colorFG);
                    if (!string.IsNullOrEmpty(colorBG)) ansi = ansi.Background(colorBG);
                    if (formatIndex < formatting.Length) ansi = ansi.AddFormatting(formatting[formatIndex]);
                    result += ansi;
                    formatIndex++;
                }
                else result += text[i];
            }

            return new ANSIString(result);
        }
    }
}

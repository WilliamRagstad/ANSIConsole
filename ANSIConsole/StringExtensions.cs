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
        public static ANSIString Bold(this string text) => Bold(new ANSIString(text));
        public static ANSIString Bold(this ANSIString text) => text.AddFormatting(ANSIFormatting.Bold);
        public static ANSIString Faint(this string text) => Faint(new ANSIString(text));
        public static ANSIString Faint(this ANSIString text) => text.AddFormatting(ANSIFormatting.Faint);
        public static ANSIString Italic(this string text) => Italic(new ANSIString(text));
        public static ANSIString Italic(this ANSIString text) => text.AddFormatting(ANSIFormatting.Italic);
        public static ANSIString Underlined(this string text) => Underlined(new ANSIString(text));
        public static ANSIString Underlined(this ANSIString text) => text.AddFormatting(ANSIFormatting.Underlined);
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
        public static ANSIString Color(this string text, string nameOrHex)
            => Color(new ANSIString(text), nameOrHex);

        public static ANSIString Color(this ANSIString text, string nameOrHex) => text.SetForegroundColor(nameOrHex.StartsWith('#') ?
            System.Drawing.ColorTranslator.FromHtml(nameOrHex) :
            System.Drawing.Color.FromName(nameOrHex));

        public static ANSIString Opacity(this string text, int alpha) => Opacity(new ANSIString(text), alpha);
        public static ANSIString Opacity(this ANSIString text, int alpha) => text.SetForegroundColor(System.Drawing.Color.FromArgb(alpha, text.GetForegroundColor()));
    }
}

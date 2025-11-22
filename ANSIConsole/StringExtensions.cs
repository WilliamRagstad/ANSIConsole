using System;
using System.Drawing;
using System.Linq;

namespace ANSIConsole
{
    public static class StringExtensions
    {
        public static ANSIString ToANSI(this string text) => new ANSIString(text);
        public static ANSIString AddFormatting(this string text, ANSIFormatting formatting) => AddFormatting(ToANSI(text), formatting);
        public static ANSIString AddFormatting(this ANSIString text, ANSIFormatting formatting) => text.AddFormatting(formatting);
        public static ANSIString Bold(this string text) => Bold(ToANSI(text));
        public static ANSIString Bold(this ANSIString text) => text.AddFormatting(ANSIFormatting.Bold);
        public static ANSIString Faint(this string text) => Faint(ToANSI(text));
        public static ANSIString Faint(this ANSIString text) => text.AddFormatting(ANSIFormatting.Faint);
        public static ANSIString Italic(this string text) => Italic(ToANSI(text));
        public static ANSIString Italic(this ANSIString text) => text.AddFormatting(ANSIFormatting.Italic);
        public static ANSIString Underlined(this string text) => Underlined(ToANSI(text));
        public static ANSIString Underlined(this ANSIString text) => text.AddFormatting(ANSIFormatting.Underlined);
        public static ANSIString Overlined(this string text) => Overlined(ToANSI(text));
        public static ANSIString Overlined(this ANSIString text) => text.AddFormatting(ANSIFormatting.Overlined);
        public static ANSIString Inverted(this string text) => Inverted(ToANSI(text));
        public static ANSIString Inverted(this ANSIString text) => text.AddFormatting(ANSIFormatting.Inverted);
        public static ANSIString StrikeThrough(this string text) => StrikeThrough(ToANSI(text));
        public static ANSIString StrikeThrough(this ANSIString text) => text.AddFormatting(ANSIFormatting.StrikeThrough);
        public static ANSIString UpperCase(this string text) => UpperCase(ToANSI(text));
        public static ANSIString UpperCase(this ANSIString text) => text.AddFormatting(ANSIFormatting.UpperCase);
        public static ANSIString LowerCase(this string text) => LowerCase(ToANSI(text));
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
        public static ANSIString Clear(this string text) => Clear(ToANSI(text));
        /// <summary>
        /// Manually clear formatting after text is printed.
        /// This is done automatically unless NoClear() is used.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ANSIString Clear(this ANSIString text) => text.AddFormatting(ANSIFormatting.Clear);
        
        public static ANSIString Color(this string text, ConsoleColor color) => Color(ToANSI(text), color);
        public static ANSIString Color(this ANSIString text, ConsoleColor color) => text.SetForegroundColor(color);
        public static ANSIString Color(this string text, Color color) => Color(ToANSI(text), color);
        public static ANSIString Color(this ANSIString text, Color color) => text.SetForegroundColor(color);
        public static ANSIString Color(this string text, int r, int g, int b) => Color(ToANSI(text), System.Drawing.Color.FromArgb(r, g, b));
        public static ANSIString Color(this ANSIString text, int r, int g, int b) => Color(text, System.Drawing.Color.FromArgb(r, g, b));
        public static ANSIString Color(this string text, int r, int g, int b, int alpha) => Color(ToANSI(text), System.Drawing.Color.FromArgb(alpha, r, g, b));
        public static ANSIString Color(this ANSIString text, int r, int g, int b, int alpha) => Color(text, System.Drawing.Color.FromArgb(alpha, r, g, b));
        public static ANSIString Color(this string text, ConsoleColor color, int alpha) => Color(ToANSI(text), System.Drawing.Color.FromArgb(alpha, ANSIString.FromConsoleColor(color)));
        public static ANSIString Color(this ANSIString text, ConsoleColor color, int alpha) => Color(text, System.Drawing.Color.FromArgb(alpha, ANSIString.FromConsoleColor(color)));
        public static ANSIString Color(this string text, Color color, int alpha) => Color(ToANSI(text), System.Drawing.Color.FromArgb(alpha, color));
        public static ANSIString Color(this ANSIString text, Color color, int alpha) => Color(text, System.Drawing.Color.FromArgb(alpha, color));
        public static ANSIString Color(this string text, string nameOrHex) => Color(ToANSI(text), nameOrHex);
        public static ANSIString Color(this ANSIString text, string nameOrHex) => Color(text, nameOrHex.StartsWith('#') ?
            System.Drawing.ColorTranslator.FromHtml(nameOrHex) :
            System.Drawing.Color.FromName(nameOrHex));

        public static ANSIString Background(this string text, ConsoleColor color) => Background(ToANSI(text), color);
        public static ANSIString Background(this ANSIString text, ConsoleColor color) => text.SetBackgroundColor(color);
        public static ANSIString Background(this string text, Color color) => Background(ToANSI(text), color);
        public static ANSIString Background(this ANSIString text, Color color) => text.SetBackgroundColor(color);
        public static ANSIString Background(this string text, int r, int g, int b) => Background(ToANSI(text), System.Drawing.Color.FromArgb(r, g, b));
        public static ANSIString Background(this ANSIString text, int r, int g, int b) => Background(text, System.Drawing.Color.FromArgb(r, g, b));
        public static ANSIString Background(this string text, int r, int g, int b, int alpha) => Background(ToANSI(text), System.Drawing.Color.FromArgb(alpha, r, g, b));
        public static ANSIString Background(this ANSIString text, int r, int g, int b, int alpha) => Background(text, System.Drawing.Color.FromArgb(alpha, r, g, b));
        public static ANSIString Background(this string text, ConsoleColor color, int alpha) => Background(ToANSI(text), System.Drawing.Color.FromArgb(alpha, ANSIString.FromConsoleColor(color)));
        public static ANSIString Background(this ANSIString text, ConsoleColor color, int alpha) => Background(text, System.Drawing.Color.FromArgb(alpha, ANSIString.FromConsoleColor(color)));
        public static ANSIString Background(this string text, Color color, int alpha) => Background(ToANSI(text), System.Drawing.Color.FromArgb(alpha, color));
        public static ANSIString Background(this ANSIString text, Color color, int alpha) => Background(text, System.Drawing.Color.FromArgb(alpha, color));
        public static ANSIString Background(this string text, string nameOrHex) => Background(ToANSI(text), nameOrHex);
        public static ANSIString Background(this ANSIString text, string nameOrHex) => Background(text, nameOrHex.StartsWith('#') ?
            System.Drawing.ColorTranslator.FromHtml(nameOrHex) :
            System.Drawing.Color.FromName(nameOrHex));
        
        public static ANSIString Opacity(this string text, int percent) => Opacity(ToANSI(text), percent);
        public static ANSIString Opacity(this ANSIString text, int percent) => text.SetOpacity((float)percent / 100);
        public static ANSIString Blink(this string text) => Blink(ToANSI(text));
        public static ANSIString Blink(this ANSIString text) => text.AddFormatting(ANSIFormatting.Blink);
        public static ANSIString Link(this string text, string url) => Link(ToANSI(text), url);
        public static ANSIString Link(this ANSIString text, string url) => text.SetHyperlink(url);
        /// <summary>
        /// If string represents a URL, make that string a click-able hyperlink.
        /// Make a link where the text is also the url.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ANSIString Link(this string text) => Link(ToANSI(text), text);
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

                    ANSIString ansi = ToANSI(match);
                    if (!string.IsNullOrEmpty(colorFG)) ansi = ansi.Color(colorFG);
                    if (!string.IsNullOrEmpty(colorBG)) ansi = ansi.Background(colorBG);
                    if (formatIndex < formatting.Length) ansi = ansi.AddFormatting(formatting[formatIndex]);
                    result += ansi;
                    formatIndex++;
                }
                else result += text[i];
            }

            return ToANSI(result);
        }
        /// <summary>
        /// Format using only foreground color.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static ANSIString FormatColor(this string text, params ConsoleColor[] colors) =>
            FormatColor(text, colors.Select(ANSIString.FromConsoleColor).ToArray());
        /// <summary>
        /// Format using only foreground color.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static ANSIString FormatColor(this string text, params Color[] colors)
        {
            if (text.Count(c => c == '`') < colors.Length) throw new FormatException("Cannot have more color arguments than there are corresponding `...´ pairs.");
            string result = string.Empty;
            int formatIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '`')
                {
                    string match = string.Empty;
                    i++;
                    while (text[i] != '´' && i < text.Length)
                    {
                        match += text[i];
                        i++;
                    }

                    ANSIString ansi = ToANSI(match);
                    if (formatIndex < colors.Length) ansi = ansi.SetForegroundColor(colors[formatIndex]);
                    result += ansi;
                    formatIndex++;
                }
                else result += text[i];
            }

            return ToANSI(result);
        }
        /// <summary>
        /// Map over a text to produce generative formattings
        /// </summary>
        /// <param name="text"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public static ANSIString MapANSI(this string text, Func<string, int, ANSIString> generator) => ToANSI(string.Join("", text.Select((c, i) => generator(c.ToString(), i))));
        /// <summary>
        /// Map over a text to produce generative formattings
        /// </summary>
        /// <param name="text"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public static ANSIString MapANSI(this string text, Func<string, ANSIString> generator) => ToANSI(string.Join("", text.Select(c => generator(c.ToString()))));
        
        public static ANSIString Gradient(this string text, Color background, params Color[] colors) => text.MapANSI((c, i) =>
        {
            float percentage = (colors.Length - 1) * ((float)i / text.Length);
            int colorPrevIndex = (int)percentage;
            int colorNextIndex = (int)Math.Ceiling(percentage);
            Color colorPrev = colors[colorPrevIndex];
            Color colorNext = colors[colorNextIndex];
            float ltrOffset = percentage - colorPrevIndex;
            float rtlOffset = 1 - ltrOffset;
                
            int r = (byte)(rtlOffset * colorPrev.R + ltrOffset * colorNext.R);
            int g = (byte)(rtlOffset * colorPrev.G + ltrOffset * colorNext.G);
            int b = (byte)(rtlOffset * colorPrev.B + ltrOffset * colorNext.B);
                
            return c.ToString().Background(background).Color(r, g, b);
        });
        public static ANSIString GradientBackground(this string text, Color foreground, params Color[] colors) => text.MapANSI((c, i) =>
        {
            float percentage = (colors.Length - 1) * ((float)i / text.Length);
            int colorPrevIndex = (int)percentage;
            int colorNextIndex = (int)Math.Ceiling(percentage);
            Color colorPrev = colors[colorPrevIndex];
            Color colorNext = colors[colorNextIndex];
            float ltrOffset = percentage - colorPrevIndex;
            float rtlOffset = 1 - ltrOffset;
                
            int r = (byte)(rtlOffset * colorPrev.R + ltrOffset * colorNext.R);
            int g = (byte)(rtlOffset * colorPrev.G + ltrOffset * colorNext.G);
            int b = (byte)(rtlOffset * colorPrev.B + ltrOffset * colorNext.B);
                
            return c.ToString().Background(r, g, b).Color(foreground);
        });
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSIConsole
{
    public class ANSIString
    {
        private readonly string _text;
        private string _hyperlink;
        private Color? _colorForeground;
        private Color? _colorBackground;
        private ANSIFormatting _formatting;
        
        public ANSIString(string text)
        {
            _text = text;
            _formatting = ANSIFormatting.Clear;
        }

        internal ANSIString AddFormatting(ANSIFormatting add)
        {
            _formatting |= add;
            if (_formatting.HasFlag(ANSIFormatting.UpperCase | ANSIFormatting.LowerCase))
                throw new ArgumentException("formatting cannot include both UpperCase and LowerCase!",
                    nameof(_formatting));
            return this;
        }

        internal ANSIString RemoveFormatting(ANSIFormatting rem)
        {
            _formatting &= ~rem;
            return this;
        }
        
        internal Color GetForegroundColor() => _colorForeground ?? FromConsoleColor(Console.ForegroundColor);
        internal Color GetBackgroundColor() => _colorBackground ?? FromConsoleColor(Console.BackgroundColor);

        internal ANSIString SetForegroundColor(Color color)
        {
            _colorForeground = color;
            return this;
        }

        internal ANSIString SetForegroundColor(ConsoleColor color)
        {
            _colorForeground = FromConsoleColor(color);
            return this;
        }

        internal ANSIString SetBackgroundColor(Color color)
        {
            _colorBackground = color;
            return this;
        }

        internal ANSIString SetBackgroundColor(ConsoleColor color)
        {
            _colorBackground = FromConsoleColor(color);
            return this;
        }

        internal ANSIString SetHyperlink(string link)
        {
            _hyperlink = link;
            return this;
        }

        public override string ToString()
        {
            if (!ANSIInitializer.Enabled || _formatting == ANSIFormatting.None) return _text;
            string result = _text;
            if (_formatting.HasFlag(ANSIFormatting.UpperCase)) result = result.ToUpper();
            if (_formatting.HasFlag(ANSIFormatting.LowerCase)) result = result.ToLower();
            if (_formatting.HasFlag(ANSIFormatting.Bold)) result = ANSI.Bold + result;
            if (_formatting.HasFlag(ANSIFormatting.Faint)) result = ANSI.Faint + result;
            if (_formatting.HasFlag(ANSIFormatting.Italic)) result = ANSI.Italic + result;
            if (_formatting.HasFlag(ANSIFormatting.Underlined)) result = ANSI.Underlined + result;
            if (_formatting.HasFlag(ANSIFormatting.Overlined)) result = ANSI.Overlined + result;
            if (_formatting.HasFlag(ANSIFormatting.Blink)) result = ANSI.Blink + result;
            if (_formatting.HasFlag(ANSIFormatting.Inverted)) result = ANSI.Inverted + result;
            if (_formatting.HasFlag(ANSIFormatting.StrikeThrough)) result = ANSI.StrikeThrough + result;
            
            if (_colorForeground != null) result = ANSI.Foreground((Color)_colorForeground) + result;
            if (_colorBackground != null) result = ANSI.Background((Color)_colorBackground) + result;
            if (_hyperlink != null) result = ANSI.Hyperlink(result, _hyperlink);
            if (_formatting.HasFlag(ANSIFormatting.Clear)) result += ANSI.Clear;
            return result;
        }

        internal static Color FromConsoleColor(ConsoleColor color)
        {
            try {
                return Color.FromArgb(ConsoleColors[(int)color]);
            } catch {
                throw new ArgumentOutOfRangeException(nameof(color), $"{color} is not a valid color");
            }
        }

        internal static readonly int[] ConsoleColors = {
            0x000000, //Black = 0
            0x000080, //DarkBlue = 1
            0x008000, //DarkGreen = 2
            0x008080, //DarkCyan = 3
            0x800000, //DarkRed = 4
            0x800080, //DarkMagenta = 5
            0x808000, //DarkYellow = 6
            0xC0C0C0, //Gray = 7
            0x808080, //DarkGray = 8
            0x0000FF, //Blue = 9
            0x00FF00, //Green = 10
            0x00FFFF, //Cyan = 11
            0xFF0000, //Red = 12
            0xFF00FF, //Magenta = 13
            0xFFFF00, //Yellow = 14
            0xFFFFFF  //White = 15
        };
    }
}

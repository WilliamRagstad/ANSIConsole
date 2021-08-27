using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSIConsole
{
    public static class ANSI
    {
        public static string Clear = "\u001b[0m";
        public static string Bold = "\u001b[1m";
        public static string Faint = "\u001b[2m";
        public static string Italic = "\u001b[3m";
        public static string Underlined = "\u001b[4m";
        public static string StrikeThrough = "\u001b[53m";
        
        public static string Foreground(Color color) => $"\u001b[38;2;{color.R};{color.G};{color.B}m";
        public static string Background(Color color) => $"\u001b[48;2;{color.R};{color.G};{color.B}m";
    }
}

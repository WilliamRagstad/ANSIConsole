using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSIConsole
{
    [Flags]
    public enum ANSIFormatting
    {
        None = 0,
        Bold = 1 << 0,
        Faint = 1 << 1,
        Italic = 1 << 2,
        Underlined = 1 << 3,
        Overlined = 1 << 4,
        Blink = 1 << 5,
        Inverted = 1 << 6,
        StrikeThrough = 1 << 7,
        LowerCase = 1 << 8,
        UpperCase = 1 << 9,
        Clear = 1 << 10,
    }
}

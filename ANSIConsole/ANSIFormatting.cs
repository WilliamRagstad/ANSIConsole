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
        Italic = 1 << 1,
        Underlined = 1 << 2,
        StrikeThrough = 1 << 3,
        LowerCase = 1 << 4,
        UpperCase = 1 << 5,
        /// <summary>
        /// Do not clear formatting after text is printed
        /// </summary>
        NoClear = 1 << 6
    }
}

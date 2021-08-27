using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSIConsole
{
    public static class StringExtensions
    {
        public static ANSIString Bold(this string text) => new ANSIString(text, ANSIFormatting.Bold);
        public static ANSIString Bold(this ANSIString text) => text.AddFormatting(ANSIFormatting.Bold);
    }
}

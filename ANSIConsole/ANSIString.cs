using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSIConsole
{
    public class ANSIString
    {
        private readonly string _text;
        internal ANSIFormatting Formatting;
        
        public ANSIString(string text) : this(text, ANSIFormatting.None) { }
        public ANSIString(string text, ANSIFormatting formatting)
        {
            _text = text;
            Formatting = formatting;
            if (formatting.HasFlag(ANSIFormatting.UpperCase | ANSIFormatting.LowerCase))
                throw new ArgumentException("formatting cannot include both UpperCase and LowerCase!",
                    nameof(formatting));
        }

        internal ANSIString AddFormatting(ANSIFormatting add)
        {
            Formatting |= add;
            return this;
        }

        public override string ToString()
        {
            if (Formatting == ANSIFormatting.None) return _text;
            string result = _text;
            if (Formatting.HasFlag(ANSIFormatting.UpperCase)) result = result.ToUpper();
            if (Formatting.HasFlag(ANSIFormatting.LowerCase)) result = result.ToLower();

            if (!Formatting.HasFlag(ANSIFormatting.NoClear)) result += ANSI.Clear;
            return result;
        }
    }
}

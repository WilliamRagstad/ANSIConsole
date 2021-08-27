using System;
using System.Runtime.InteropServices;

namespace ANSIConsole
{
    public static class ANSIInitializer
    {
        private static readonly int STD_OUTPUT_HANDLE = -11;
        private static readonly uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        private static readonly uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();

        /// <summary>
        /// Run once before using the console.
        /// You may not need to initialize the ANSI console mode.
        /// </summary>
        /// <returns>true if initialization was successful</returns>
        public static bool Init(bool printError = true)
        {
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            if (!GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                if (printError) Console.WriteLine("failed to get output console mode");
                return false;
            }

            outConsoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;
            if (!SetConsoleMode(iStdOut, outConsoleMode))
            {
                if (printError) Console.WriteLine($"failed to set output console mode, error code: {GetLastError()}");
                return false;
            }

            return true;
        }

        private static bool? _enabled;
        public static bool Enabled
        {
            get
            {
                if (_enabled != null) return (bool)_enabled;
                _enabled = Environment.GetEnvironmentVariable("NO_COLOR") == null;
                return Enabled;
            }
            set => _enabled = value;
        }
    }
}

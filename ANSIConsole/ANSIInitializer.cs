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
        public static void Init()
        {
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            if (!GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                System.Console.WriteLine("failed to get output console mode");
                System.Console.ReadKey();
                return;
            }

            outConsoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;
            if (!SetConsoleMode(iStdOut, outConsoleMode))
            {
                System.Console.WriteLine($"failed to set output console mode, error code: {GetLastError()}");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine("\u001b[31mHello World!\u001b[0m");
            System.Console.WriteLine("\u001b[31;1;4mHello World!\u001b[0m");
            System.Console.WriteLine("\u001b[31m\u001b[1;4mHello World!\u001b[0m");
            System.Console.WriteLine("\u001b[31m\u001b[1mHello World!\u001b[0m");
            // Console.WriteLine("\u001b[2J"); // Clear the screan
        }
    }
}

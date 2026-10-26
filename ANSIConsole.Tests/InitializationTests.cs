using System.Runtime.InteropServices;
using Xunit;

namespace ANSIConsole.Tests
{
    public class InitializationTests
    {
        [Fact]
        public void UnixInitializationDoesNotCallKernel32()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Assert.True(ANSIInitializer.Init(false));
        }
    }
}

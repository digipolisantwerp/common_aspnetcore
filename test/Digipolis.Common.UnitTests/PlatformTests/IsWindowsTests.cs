using System;
using Digipolis.Common.Handlers;
using Xunit;
using System.Runtime.InteropServices;

namespace Digipolis.Common.UnitTests.PlatformTests
{
    public class IsWindowsTests
    {
        [Fact]
        private void Win32NTReturnsTrue()
        {
            var platform = new Platform(OSPlatform.Windows);
            Assert.True(platform.IsWindows);
        }

        [Fact]
        private void OtherReturnsFalse()
        {
            var platform = new Platform(OSPlatform.Linux);
            Assert.False(platform.IsWindows);
        }
    }
}

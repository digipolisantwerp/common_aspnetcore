using System;
using Digipolis.Common.Handlers;
using Xunit;
using System.Runtime.InteropServices;

namespace Digipolis.Common.UnitTests.PlatformTests
{
    public class IsMacTests
    {
        [Fact]
        private void MaxOSXReturnsTrue()
        {
            var platform = new Platform(OSPlatform.OSX);
            Assert.True(platform.IsMac);
        }

        [Fact]
        private void OtherReturnsFalse()
        {
            var platform = new Platform(OSPlatform.Windows);
            Assert.False(platform.IsMac);
        }
    }
}

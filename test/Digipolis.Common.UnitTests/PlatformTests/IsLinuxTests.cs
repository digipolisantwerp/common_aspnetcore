using System;
using Digipolis.Common.Handlers;
using Xunit;
using System.Runtime.InteropServices;

namespace Digipolis.Common.UnitTests.PlatformTests
{
    public class IsLinuxTests
    {
       [Fact]
        private void UnixReturnsTrue()
        {
            var platform = new Platform(OSPlatform.Linux);
            Assert.True(platform.IsLinux);
        }

        [Fact]
        private void OtherReturnsFalse()
        {
            var platform = new Platform(OSPlatform.Windows);
            Assert.False(platform.IsLinux);
        }
    }
}

using System;
using Digipolis.Common.Handlers;
using Xunit;
using System.Runtime.InteropServices;

namespace Digipolis.Common.UnitTests.PlatformTests
{
    public class PlatformIDTests
    {
       [Fact]
        private void PlatformIDIsSet()
        {
            var platform = new Platform(OSPlatform.Linux);
            Assert.Equal(OSPlatform.Linux, platform.OSPlatform);
        }
    }
}

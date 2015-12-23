using System;
using Toolbox.Common.Handlers;
using Xunit;

namespace Toolbox.Common.UnitTests.PlatformTests
{
    public class IsXboxTests
    {
        [Fact]
        private void XBoxPlatformReturnsTrue()
        {
            var platform = new Platform(PlatformID.Xbox);
            Assert.True(platform.IsXbox);
        }

        [Fact]
        private void OtherPlatformReturnsFalse()
        {
            var platform = new Platform(PlatformID.Win32NT);
            Assert.False(platform.IsXbox);
        }
    }
}

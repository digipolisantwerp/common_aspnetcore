using System;
using Toolbox.Common.Handlers;
using Xunit;

namespace Toolbox.Common.UnitTests.PlatformTests
{
    public class IsMacTests
    {
        [Fact]
        private void MaxOSXReturnsTrue()
        {
            var platform = new Platform(PlatformID.MacOSX);
            Assert.True(platform.IsMac);
        }

        [Fact]
        private void OtherReturnsFalse()
        {
            var platform = new Platform(PlatformID.Win32NT);
            Assert.False(platform.IsMac);
        }
    }
}

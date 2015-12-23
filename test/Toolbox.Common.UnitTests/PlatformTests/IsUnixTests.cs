using System;
using Toolbox.Common.Handlers;
using Xunit;

namespace Toolbox.Common.UnitTests.PlatformTests
{
    public class IsUnixTests
    {
        [Fact]
        private void UnixReturnsTrue()
        {
            var platform = new Platform(PlatformID.Unix);
            Assert.True(platform.IsUnix);
        }

        [Fact]
        private void OtherReturnsFalse()
        {
            var platform = new Platform(PlatformID.Win32NT);
            Assert.False(platform.IsUnix);
        }
    }
}

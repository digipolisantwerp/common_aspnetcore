using System;
using Toolbox.Common.Handlers;
using Xunit;

namespace Toolbox.Common.UnitTests.PlatformTests
{
    public class PlatformIDTests
    {
       [Fact]
        private void PlatformIDIsSet()
        {
            var platform = new Platform(PlatformID.Unix);
            Assert.Equal(PlatformID.Unix, platform.PlatformID);
        }
    }
}

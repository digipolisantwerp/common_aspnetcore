using System;
using Toolbox.Common.Handlers;
using Xunit;

namespace Toolbox.Common.UnitTests.PlatformTests
{
    public class IsWindowsTests
    {
        [Fact]
        private void Win32NTReturnsTrue()
        {
            var platform = new Platform(PlatformID.Win32NT);
            Assert.True(platform.IsWindows);
        }

        [Fact]
        private void Win32SReturnsTrue()
        {
            var platform = new Platform(PlatformID.Win32S);
            Assert.True(platform.IsWindows);
        }

        [Fact]
        private void Win32WindowsReturnsTrue()
        {
            var platform = new Platform(PlatformID.Win32Windows);
            Assert.True(platform.IsWindows);
        }

        [Fact]
        private void WinCEReturnsTrue()
        {
            var platform = new Platform(PlatformID.WinCE);
            Assert.True(platform.IsWindows);
        }

        [Fact]
        private void OtherReturnsFalse()
        {
            var platform = new Platform(PlatformID.Unix);
            Assert.False(platform.IsWindows);
        }
    }
}

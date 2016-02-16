using System;
using Toolbox.Common.Helpers;
using Xunit;

namespace Digipolis.Toolbox.Common.UnitTests.Helpers
{
    
    public class GetPrimaryHostNameStringTests
    {
        [Fact]
        public void InvalidUriThrowsArgumentException()
        {
            var invalidUri = "aaff";
            var ex = Assert.Throws<ArgumentException>(() => UriHelper.GetPrimaryHostName(invalidUri));
            Assert.Contains("is not a valid uri", ex.Message);
        }

        [Fact]
        public void ValidUrlDoesNotThrow()
        {
            var validUri = "http://www.google.com";
            Assert.Equal("www.google.com", UriHelper.GetPrimaryHostName(validUri));
        }
    }
}

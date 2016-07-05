using System;
using Digipolis.Common.Helpers;
using Xunit;
using System.Threading.Tasks;

namespace Digipolis.Common.UnitTests.Helpers
{
    
    public class GetPrimaryHostNameStringTests
    {
        [Fact]
        public async Task InvalidUriThrowsArgumentException()
        {
            var invalidUri = "aaff";
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => UriHelper.GetPrimaryHostName(invalidUri));
            Assert.Contains("is not a valid uri", ex.Message);
        }

        [Fact]
        public async Task ValidUrlDoesNotThrow()
        {
            var validUri = "http://www.google.com";
            Assert.Equal("www.google.com", await UriHelper.GetPrimaryHostName(validUri));
        }
    }
}

using System;
using Toolbox.Common.Helpers;
using Xunit;


namespace Digipolis.Toolbox.Common.UnitTests.Helpers
{
    
    public class IsValidUriTests
    {
        [Fact]
        public void ValidUriReturnsTrue()
        {
            var uri = "http://www.mysite.local";
            var ret = UriHelper.IsValidUri(uri);
            Assert.True(ret);
        }
        
        [Fact]
        public void InvalidUriReturnsFalse()
        {
            var uri = "c:/www.mysite.local";
            var ret = UriHelper.IsValidUri(uri);
            Assert.False(ret);
        }
    }
}

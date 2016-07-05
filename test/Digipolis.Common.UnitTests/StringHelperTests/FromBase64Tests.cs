using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.Helpers
{
    
    public class FromBase64Tests
    {
        [Fact]
        public void NullReturnsNull()
        {
            string nullString = null;
            var result = StringHelper.FromBase64(nullString);
            Assert.Null(result);
        }

        [Fact]
        public void EmptyStringReturnsEmpty()
        {
            var empty = "";
            var result = StringHelper.FromBase64(empty);
            Assert.Equal("", result);
        }

        [Fact]
        public void WhiteSpacesReturnsEmptyString()
        {
            var spaces = "  ";
            var result = StringHelper.FromBase64(spaces);
            Assert.Equal("", result);
        }

        [Fact]
        public void Base64ValueReturnsValue()
        {
            var base64 = "YXplcnR5";
            var result = StringHelper.FromBase64(base64);
            Assert.Equal("azerty", result);
        }
    }
}

using Toolbox.Common.Helpers;
using Xunit;

namespace Digipolis.Toolbox.Common.UnitTests.Helpers
{
   
    public class ToBase64Tests
    {
        [Fact]
        public void NullReturnsNull()
        {
            string nullString = null;
            var result = StringHelper.ToBase64(nullString);
            Assert.Null(result);
        }

        [Fact]
        public void EmptyStringReturnsEmptyString()
        {
            var empty = "";
            var result = StringHelper.ToBase64(empty);
            Assert.Equal("", result);
        }

        [Fact]
        public void WhiteSpacesReturnsBase64Value()
        {
            var spaces = "    ";
            var result = StringHelper.ToBase64(spaces);
            Assert.Equal("ICAgIA==", result);
        }

        [Fact]
        public void ValueReturnsBase64Value()
        {
            var value = "azerty";
            var result = StringHelper.ToBase64(value);
            Assert.Equal("YXplcnR5", result);
        }
    }
}

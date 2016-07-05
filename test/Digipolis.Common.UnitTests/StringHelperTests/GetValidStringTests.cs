using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.Helpers
{
    public class TestObject
    {
        public string Name { get; set; }
    }

    
    public class GetValidStringTests
    {
        [Fact]
        public void NullStringReturnsNull()
        {
            string nullString = null;
            var ret = StringHelper.GetValidString(nullString);
            Assert.Equal("null", ret);
        }

        [Fact]
        public void EmptyStringReturnsEmpty()
        {
            string empty = "";
            var ret = StringHelper.GetValidString(empty);
            Assert.Equal("empty", ret);
        }
        
        [Fact]
        public void WhitespaceReturnsEmptyString()
        {
            string whitespace = "   ";
            var ret = StringHelper.GetValidString(whitespace);
            Assert.Equal("empty", ret);
        }

        [Fact]
        public void ValidStringReturnsContent()
        {
            string valid = "aValue";
            var ret = StringHelper.GetValidString(valid);
            Assert.Equal("aValue", ret);
        }

        [Fact]
        public void NullObjectReturnsNull()
        {
            TestObject obj = null;
            var ret = StringHelper.GetValidString(obj);
            Assert.Equal("null", ret);
        }

        [Fact]
        public void ValidObjectReturnsToString()
        {
            TestObject obj = new TestObject() { Name = "myTest" };
            var ret = StringHelper.GetValidString(obj);
            Assert.Equal(obj.ToString(), ret);
        }
    }
}

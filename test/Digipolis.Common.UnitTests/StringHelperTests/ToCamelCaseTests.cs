using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.Helpers
{
    
    public class ToCamelCaseTests
    {
        [Fact]
        public void NullReturnsNull()
        {
            string nullString = null;
            var result = StringHelper.ToCamelCase(nullString);
            Assert.Null(result);
        }

        [Fact]
        public void EmptyReturnsEmpty()
        {
            var empty = "";
            var result = StringHelper.ToCamelCase(empty);
            Assert.Equal("", result);
        }

        [Fact]
        public void WhiteSpaceReturnsWhiteSpace()
        {
            var spaces = "  ";
            var result = StringHelper.ToCamelCase(spaces);
            Assert.Equal("  ", result);
        }

        [Fact]
        public void UperCaseReturnsCamelCase()
        {
            var upper = "Hello";
            var result = StringHelper.ToCamelCase(upper);
            Assert.Equal("hello", result);
        }

        [Fact]
        public void LowerCaseReturnsCamelCase()
        {
            var lower = "groovy";
            var result = StringHelper.ToCamelCase(lower);
            Assert.Equal("groovy", result);
        }

        [Fact]
        public void NumericReturnsInput()
        {
            var numeric = "1337";
            var result = StringHelper.ToCamelCase(numeric);
            Assert.Equal("1337", result);
        }

        [Fact]
        public void TwoLowerCaseWordsReturnsCamelCase()
        {
            var twoLower = "hello world";
            var result = StringHelper.ToCamelCase(twoLower);
            Assert.Equal("helloWorld", result);
        }

        [Fact]
        public void TwoUpperCaseWordsReturnsCamelCase()
        {
            var twoUpper = "Dream Big";
            var result = StringHelper.ToCamelCase(twoUpper);
            Assert.Equal("dreamBig", result);
        }

        [Fact]
        public void WordsWithNumbersReturnsCamelCase()
        {
            var grimm = "snowwhite and the 7 dwarves";
            var result = StringHelper.ToCamelCase(grimm);
            Assert.Equal("snowwhiteAndThe7Dwarves", result);
        }

        [Fact]
        public void WordsWithNonAlphaNumericReturnsCamelCase()
        {
            var barrywhite = "You are the first, my last, my everything";
            var result = StringHelper.ToCamelCase(barrywhite);
            Assert.Equal("youAreTheFirstMyLastMyEverything", result);
        }
    }
}
using Toolbox.Common.Helpers;
using Xunit;

namespace Digipolis.Toolbox.Common.UnitTests.Helpers
{
    
    public class ToPascalCaseTests
    {
        [Fact]
        public void NullReturnsNull()
        {
            string nullString = null;
            var result = StringHelper.ToPascalCase(nullString);
            Assert.Null(result);
        }

        [Fact]
        public void EmptyReturnsEmpty()
        {
            var empty = "";
            var result = StringHelper.ToPascalCase(empty);
            Assert.Equal("", result);
        }

        [Fact]
        public void WhiteSpaceReturnsWhiteSpace()
        {
            var spaces = "  ";
            var result = StringHelper.ToPascalCase(spaces);
            Assert.Equal("  ", result);
        }

        [Fact]
        public void UperCaseReturnsPascalCase()
        {
            var upper = "Dragons";
            var result = StringHelper.ToPascalCase(upper);
            Assert.Equal("Dragons", result);
        }

        [Fact]
        public void LowerCaseReturnsPascalCase()
        {
            var lower = "supafly";
            var result = StringHelper.ToPascalCase(lower);
            Assert.Equal("Supafly", result);
        }

        [Fact]
        public void NumericReturnsInput()
        {
            var numeric = "666";
            var result = StringHelper.ToPascalCase(numeric);
            Assert.Equal("666", result);
        }

        [Fact]
        public void TwoLowerCaseWordsReturnsPascalCase()
        {
            var twoLower = "let it go";
            var result = StringHelper.ToPascalCase(twoLower);
            Assert.Equal("LetItGo", result);
        }

        [Fact]
        public void TwoUpperCaseWordsReturnsPascalCase()
        {
            var twoUpper = "The Cold Never Bothered Me Anyway";
            var result = StringHelper.ToPascalCase(twoUpper);
            Assert.Equal("TheColdNeverBotheredMeAnyway", result);
        }

        [Fact]
        public void WordsWithNumbersReturnsPascalCase()
        {
            var input = "snowwhite and the 7 dwarves";
            var result = StringHelper.ToPascalCase(input);
            Assert.Equal("SnowwhiteAndThe7Dwarves", result);
        }

        [Fact]
        public void WordsWithNonAlphaNumericReturnsPascalCase()
        {
            var kiekes = "Me, myself and I";
            var result = StringHelper.ToPascalCase(kiekes);
            Assert.Equal("MeMyselfAndI", result);
        }
    }
}

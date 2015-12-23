using System;
using Toolbox.Common.Validation;
using Xunit;

namespace Toolbox.Common.UnitTests.ArgumentValidatorTests
{
    public class AssertNotEmptyTests
    {
        [Fact]
        private void EmptyStringRaisesArgumentException()
        {
            var emptyString = "";
            var ex = Assert.Throws<ArgumentException>(() => ArgumentValidator.AssertNotEmpty(emptyString, nameof(emptyString)));
            Assert.Equal(nameof(emptyString), ex.ParamName);
        }

        [Fact]
        private void NullStringDoesNotRaiseException()
        {
            string nullString = null;
            ArgumentValidator.AssertNotEmpty(nullString, nameof(nullString));
        }

        [Fact]
        private void WhiteSpacesDoesNotRaiseException()
        {
            var spaces = "   ";
            ArgumentValidator.AssertNotEmpty(spaces, nameof(spaces));
        }

        [Fact]
        private void WordDoesNotRaiseException()
        {
            var word = "dragons";
            ArgumentValidator.AssertNotEmpty(word, nameof(word));
        }

        [Fact]
        private void SentenceDoesNotRaiseException()
        {
            var sentence = "Frankly, my dear, I don't give a damn.";
            ArgumentValidator.AssertNotEmpty(sentence, nameof(sentence));
        }
    }
}

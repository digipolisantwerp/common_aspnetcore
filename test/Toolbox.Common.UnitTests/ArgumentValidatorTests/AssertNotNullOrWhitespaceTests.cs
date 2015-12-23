using System;
using Toolbox.Common.Validation;
using Xunit;

namespace Toolbox.Common.UnitTests.ArgumentValidatorTests
{
    public class AssertNotNullOrWhitespaceTests
    {
        [Fact]
        private void EmptyStringRaisesArgumentException()
        {
            var emptyString = "";
            var ex = Assert.Throws<ArgumentException>(() => ArgumentValidator.AssertNotNullOrWhiteSpace(emptyString, nameof(emptyString)));
            Assert.Equal(nameof(emptyString), ex.ParamName);
        }

        [Fact]
        private void NullStringRaisesArgumentNullException()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => ArgumentValidator.AssertNotNullOrWhiteSpace(nullString, nameof(nullString)));
            Assert.Equal(nameof(nullString), ex.ParamName);
        }

        [Fact]
        private void WhiteSpaceRaisesArgumentException()
        {
            var spaces = "    ";
            var ex = Assert.Throws<ArgumentException>(() => ArgumentValidator.AssertNotNullOrWhiteSpace(spaces, nameof(spaces)));
            Assert.Equal(nameof(spaces), ex.ParamName);
        }

        [Fact]
        private void WordDoesNotRaiseException()
        {
            var word = "pigs";
            ArgumentValidator.AssertNotNullOrWhiteSpace(word, nameof(word));
        }

        [Fact]
        private void SentenceDoesNotRaiseException()
        {
            var sentence = "My name is Bond, James Bond.";
            ArgumentValidator.AssertNotNullOrWhiteSpace(sentence, nameof(sentence));
        }
    }
}

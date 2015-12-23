using System;
using Toolbox.Common.Validation;
using Xunit;

namespace Toolbox.Common.UnitTests.ArgumentValidatorTests
{
    public class AssertNotNullOrEmptyTests
    {
        [Fact]
        private void EmptyStringRaisesArgumentException()
        {
            var emptyString = "";
            var ex = Assert.Throws<ArgumentException>(() => ArgumentValidator.AssertNotNullOrEmpty(emptyString, nameof(emptyString)));
            Assert.Equal(nameof(emptyString), ex.ParamName);
        }

        [Fact]
        private void NullStringRaisesArgumentNullException()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => ArgumentValidator.AssertNotNullOrEmpty(nullString, nameof(nullString)));
            Assert.Equal(nameof(nullString), ex.ParamName);
        }

        [Fact]
        private void WhiteSpacesDoesNotRaiseException()
        {
            var spaces = "   ";
            ArgumentValidator.AssertNotNullOrEmpty(spaces, nameof(spaces));
        }

        [Fact]
        private void WordDoesNotRaiseException()
        {
            var word = "chickens";
            ArgumentValidator.AssertNotNullOrEmpty(word, nameof(word));
        }

        [Fact]
        private void SentenceDoesNotRaiseException()
        {
            var sentence = "I've got a bad feeling about this.";
            ArgumentValidator.AssertNotNullOrEmpty(sentence, nameof(sentence));
        }
    }
}

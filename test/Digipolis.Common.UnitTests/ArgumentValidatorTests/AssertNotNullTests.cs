using System;
using Digipolis.Common.Validation;
using Xunit;

namespace Digipolis.Common.UnitTests.ArgumentValidatorTests
{
    public class AssertNotNullTests
    {
        [Fact]
        private void NullStringRaisesArgumentNullException()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => ArgumentValidator.AssertNotNull(nullString, nameof(nullString)));
            Assert.Equal(nameof(nullString), ex.ParamName);
        }

        [Fact]
        private void EmptyStringDoesNotRaiseException()
        {
            var emptyString = "";
            ArgumentValidator.AssertNotNull(emptyString, nameof(emptyString));
        }

        [Fact]
        private void WhiteSpacesDoesNotRaiseException()
        {
            var spaces = "   ";
            ArgumentValidator.AssertNotNull(spaces, nameof(spaces));
        }

        [Fact]
        private void WordDoesNotRaiseException()
        {
            var word = "horses";
            ArgumentValidator.AssertNotNull(word, nameof(word));
        }

        [Fact]
        private void SentenceDoesNotRaiseException()
        {
            var sentence = "Life is like a box of chocolates.";
            ArgumentValidator.AssertNotNull(sentence, nameof(sentence));
        }

        [Fact]
        private void NullObjectRaisesArgumentNullException()
        {
            object nullObject = null;
            var ex = Assert.Throws<ArgumentNullException>(() => ArgumentValidator.AssertNotNull(nullObject, nameof(nullObject)));
            Assert.Equal(nameof(nullObject), ex.ParamName);
        }

        [Fact]
        private void ValidObjectDoesNotRaiseException()
        {
            var validObject = new object();
            ArgumentValidator.AssertNotNull(validObject, nameof(validObject));
        }
    }
}

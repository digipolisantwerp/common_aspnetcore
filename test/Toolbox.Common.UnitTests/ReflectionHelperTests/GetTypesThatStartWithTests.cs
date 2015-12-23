using System;
using System.Linq;
using Toolbox.Common.Helpers;
using Xunit;

namespace Toolbox.Common.UnitTests.ReflectionHelperTests
{
    public class GetTypesThatStartWithTests
    {
        [Fact]
        private void ValueNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetTypesThatStartWith(null));
            Assert.Equal("value", ex.ParamName);
        }

        [Fact]
        private void ValueEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ReflectionHelper.GetTypesThatStartWith(""));
            Assert.Equal("value", ex.ParamName);
        }

        [Fact]
        private void ValueWhiteSpaceRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ReflectionHelper.GetTypesThatStartWith("   "));
            Assert.Equal("value", ex.ParamName);
        }

        [Fact]
        private void KnownTypeReturnsList()
        {
            var typePrefix = this.GetType().Name.Substring(0, 10);
            var lijst = ReflectionHelper.GetTypesThatStartWith(typePrefix);
            Assert.Equal(1, lijst.Count());
        }

        [Fact]
        private void NonExistingTypeReturnsEmptyList()
        {
            var unknown = "NonExisting";
            var lijst = ReflectionHelper.GetTypesThatStartWith(unknown);
            Assert.Equal(0, lijst.Count());
        }
    }
}

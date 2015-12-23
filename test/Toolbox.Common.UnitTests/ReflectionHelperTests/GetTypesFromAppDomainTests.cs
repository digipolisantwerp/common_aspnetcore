using System;
using System.Linq;
using Toolbox.Common.Helpers;
using Xunit;

namespace Toolbox.Common.UnitTests.ReflectionHelperTests
{
    public class GetTypesFromAppDomainTests
    {
        [Fact]
        private void TypeNameNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetTypesFromAppDomain(null));
            Assert.Equal("typeName", ex.ParamName);
        }

        [Fact]
        private void TypeNameEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ReflectionHelper.GetTypesFromAppDomain(""));
            Assert.Equal("typeName", ex.ParamName);
        }

        [Fact]
        private void TypeNameWhiteSpaceRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ReflectionHelper.GetTypesFromAppDomain("   "));
            Assert.Equal("typeName", ex.ParamName);
        }

        [Fact]
        private void TypeDefinedInAppDomainReturnsList()
        {
            var typeName = this.GetType().Name;
            var lijst = ReflectionHelper.GetTypesFromAppDomain(typeName);
            Assert.Equal(1, lijst.Count());
        }

        [Fact]
        private void UnknownTypeNameReturnsEmptyList()
        {
            var unknown = "UnknownType";
            var lijst = ReflectionHelper.GetTypesFromAppDomain(unknown);
            Assert.Equal(0, lijst.Count());
        }
    }
}

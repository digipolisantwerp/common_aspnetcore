using System;
using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.ReflectionHelperTests
{
    public class GetAttributeFromTests
    {
        [Fact]
        private void NullTypeRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetAttributeFrom<Attribute>(null));
            Assert.Equal("type", ex.ParamName);
        }

        [Fact]
        private void DefinedAttributeReturnsAttribute()
        {
            var attrib = ReflectionHelper.GetAttributeFrom<CustomAttribute>(typeof(ClassWithAttribute));
            Assert.NotNull(attrib);
        }

        [Fact]
        private void NonDefinedAttributeReturnsNull()
        {
            var attrib = ReflectionHelper.GetAttributeFrom<CustomAttribute>(typeof(ClassWithoutAttribute));
            Assert.Null(attrib);
        }

        [AttributeUsage(AttributeTargets.Class)]
        private class CustomAttribute : Attribute
        { }

        [CustomAttribute]
        private class ClassWithAttribute
        { }

        private class ClassWithoutAttribute
        { }
    }
}

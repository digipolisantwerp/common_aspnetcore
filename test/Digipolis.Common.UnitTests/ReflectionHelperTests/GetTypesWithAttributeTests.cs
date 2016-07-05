using System;
using System.Linq;
using System.Reflection;
using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.ReflectionHelperTests
{
    public class GetTypesWithAttributeTests
    {
        [Fact]
        private void AssemblyNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetTypesWithAttribute<CustomAttribute>(null, false));
            Assert.Equal("assembly", ex.ParamName);
        }

        [Fact]
        private void TypeWithAttributeIsInList()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var lijst = ReflectionHelper.GetTypesWithAttribute<CustomAttribute>(assembly, false);
            Assert.Equal(1, lijst.Count());
        }

        [Fact]
        private void InheritedTypesWithBaseClassAttributedAreReturned()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var lijst = ReflectionHelper.GetTypesWithAttribute<CustomAttribute>(assembly, true);
            Assert.Equal(2, lijst.Count());
        }

        [Fact]
        private void UnusedAttributeReturnsEmptyList()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var lijst = ReflectionHelper.GetTypesWithAttribute<UnusedAttribute>(assembly, false);
            Assert.Equal(0, lijst.Count());
        }

        [AttributeUsage(AttributeTargets.Class)]
        private class CustomAttribute : Attribute
        { }

        [CustomAttribute]
        private class ClassWithAttribute
        { }

        private class InheritedClass : ClassWithAttribute
        { }

        [AttributeUsage(AttributeTargets.Class)]
        private class UnusedAttribute : Attribute
        { }
    }
}

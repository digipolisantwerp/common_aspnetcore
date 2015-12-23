using System;
using System.Linq;
using System.Reflection;
using Toolbox.Common.Helpers;
using Xunit;

namespace Toolbox.Common.UnitTests.ReflectionHelperTests
{
    public class GetClassesInheritingFromTests
    {
        [Fact]
        private void NullAssemblyRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetClassesInheritingFrom(null, this.GetType()));
            Assert.Equal("assembly", ex.ParamName);
        }

        [Fact]
        private void NullBaseClassRaisesArgumentNullException()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetClassesInheritingFrom(assembly, null));
            Assert.Equal("baseClass", ex.ParamName);
        }

        [Fact]
        private void InheritingClassIsReturned()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var baseClass = typeof(CustomBaseClass);
            var lijst = ReflectionHelper.GetClassesInheritingFrom(assembly, baseClass);
            Assert.Equal(1, lijst.Count());
            Assert.Equal("ConcreteClassThatInherits", lijst.First().Name);
        }

        [Fact]
        private void NonInheritingReturnsEmptyList()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var baseClass = this.GetType();
            var lijst = ReflectionHelper.GetClassesInheritingFrom(assembly, baseClass);
            Assert.Equal(0, lijst.Count());
        }

        private class CustomBaseClass
        { }

        private class ConcreteClassThatInherits : CustomBaseClass
        { }
    }
}

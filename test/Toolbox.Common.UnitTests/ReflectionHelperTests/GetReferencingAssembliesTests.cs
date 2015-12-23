using System;
using System.Linq;
using Toolbox.Common.Helpers;
using Xunit;

namespace Toolbox.Common.UnitTests.ReflectionHelperTests
{
    public class GetReferencingAssembliesTests
    {
        [Fact]
        private void FilenameNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetReferencingAssemblies(null));
            Assert.Equal("filename", ex.ParamName);
        }

        [Fact]
        private void FilenameEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ReflectionHelper.GetReferencingAssemblies(""));
            Assert.Equal("filename", ex.ParamName);
        }

        [Fact]
        private void FilenameWhitespaceRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => ReflectionHelper.GetReferencingAssemblies("  "));
            Assert.Equal("filename", ex.ParamName);
        }

        [Fact]
        private void NonExistingFileReturnsEmptyList()
        {
            var assemblies = ReflectionHelper.GetReferencingAssemblies(@"d:\zzzzz.txt");
            Assert.Equal(0, assemblies.Count());
        }

        [Fact]
        private void ExistingFileReturnsList()
        {
            var assembly = typeof(ReflectionHelper).Assembly;
            var assemblies = ReflectionHelper.GetReferencingAssemblies("Toolbox.Common.dll");
            Assert.Equal(1, assemblies.Count());
            Assert.Contains("Toolbox.Common.UnitTests", assemblies.First().FullName);
        }
    }
}

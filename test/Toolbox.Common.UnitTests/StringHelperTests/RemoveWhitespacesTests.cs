using System;
using System.Collections.Generic;
using System.Linq;
using Toolbox.Common.Helpers;
using Xunit;

namespace Digipolis.Toolbox.Common.UnitTests.Helpers
{
    
    public class RemoveWhitespacesTests
    {
        [Fact]
        public void NullReturnsNull()
        {
            string nullString = null;
            var result = StringHelper.RemoveWhitespaces(nullString);
            Assert.Null(result);
        }

        [Fact]
        public void NormalSpacesAreRemoved()
        {
            var normalSpaces = "this is a string with normal spaces";
            var result = StringHelper.RemoveWhitespaces(normalSpaces);
            Assert.Equal("thisisastringwithnormalspaces", result);
        }

        [Fact]
        public void DoubleSpacesAreRemoved()
        {
            var doubleSpaces = "this is a string with  double  spaces";
            var result = StringHelper.RemoveWhitespaces(doubleSpaces);
            Assert.Equal("thisisastringwithdoublespaces", result);
        }

        [Fact]
        public void CRLFAreRemoved()
        {
            var crlf = "this is a string \r\n with crlf";
            var result = StringHelper.RemoveWhitespaces(crlf);
            Assert.Equal("thisisastringwithcrlf", result);
        }

        [Fact]
        public void TabsAreRemoved()
        {
            var tabs = "this is \t a string with \t tabs";
            var result = StringHelper.RemoveWhitespaces(tabs);
            Assert.Equal("thisisastringwithtabs", result);
        }
    }
}

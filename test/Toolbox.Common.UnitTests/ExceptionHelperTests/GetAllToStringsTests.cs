using System;
using Toolbox.Common.Helpers;
using Xunit;

namespace Toolbox.Common.UnitTests.ExceptionHelperTests
{
    public class GetAllToStringsTests
    {
        [Fact]
        public void NullExceptionReturnsStringWithNull()
        {
            Exception nullEx = null;
            var result = ExceptionHelper.GetAllToStrings(nullEx);
            Assert.Contains("null", result);
        }

        [Fact]
        public void OneExceptionReturnsMessage()
        {
            var ex = new Exception("message");
            var result = ExceptionHelper.GetAllToStrings(ex);
            Assert.Contains("message", result);
        }

        [Fact]
        public void TwoExceptionsReturnsAllMessages()
        {
            var innerEx = new Exception("inner");
            var outerEx = new Exception("outer", innerEx);
            var result = ExceptionHelper.GetAllToStrings(outerEx);
            Assert.Contains("outer", result);
            Assert.Contains("inner", result);
        }
    }
}

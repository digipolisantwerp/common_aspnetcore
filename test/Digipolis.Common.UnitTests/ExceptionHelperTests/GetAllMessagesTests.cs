using System;
using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.ExceptionHelperTests
{
    public class GetAllMessagesTests
    {
        [Fact]
        public void NullExceptionReturnsStringWithNull()
        {
            Exception nullEx = null;
            var result = ExceptionHelper.GetAllMessages(nullEx);
            Assert.Contains("null", result);
        }

        [Fact]
        public void OneExceptionReturnsMessage()
        {
            var ex = new Exception("message");
            var result = ExceptionHelper.GetAllMessages(ex);
            Assert.Contains("message", result);
        }

        [Fact]
        public void TwoExceptionsReturnsAllMessages()
        {
            var innerEx = new Exception("inner");
            var outerEx = new Exception("outer", innerEx);
            var result = ExceptionHelper.GetAllMessages(outerEx);
            Assert.Contains("outer", result);
            Assert.Contains("inner", result);
        }
    }
}

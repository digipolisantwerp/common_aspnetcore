using System;
using Digipolis.Common.Helpers;
using Xunit;

namespace Digipolis.Common.UnitTests.ExceptionHelperTests
{
    public class GetAllStackTracesTests
    {
        [Fact]
        public void NullExceptionsReturnsStringWithNull()
        {
            Exception nullEx = null;
            var result = ExceptionHelper.GetAllStacktraces(nullEx);
            Assert.Contains("null", result);
        }

        [Fact]
        public void OneExceptionReturnsMessage()
        {
            try
            {
                throw new Exception("message");
            }
            catch ( Exception ex )
            {
                var result = ExceptionHelper.GetAllStacktraces(ex);
                Assert.Contains("OneExceptionReturnsMessage()", result);
            }
        }

        [Fact]
        public void TwoExceptionsReturnsAllMessages()
        {
            try
            {
                var innerEx = new Exception("inner");
                throw new Exception("outer", innerEx);
            }
            catch ( Exception ex )
            {
                var result = ExceptionHelper.GetAllStacktraces(ex);
                Assert.Contains("TwoExceptionsReturnsAllMessages()", result);
            }
        }
    }
}

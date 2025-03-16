using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ToStringTests
    {
        [Fact]
        public void ToString_returns_failure_with_error_when_failure()
        {
            Return subject = Return.Failure("BigError");
            Assert.Equal("Failure(BigError)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_failure_with_generic_result_error_when_failure()
        {
            Return<string> subject = Return.Failure<string>("BigError");
            Assert.Equal("Failure(BigError)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_failure_with_generic_error_when_failure()
        {
            Return<string, ErrorType> subject = Return.Failure<String, ErrorType>(ErrorType.Error1);
            Assert.Equal("Failure(Error1)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_failure_with_generic_error_when_UnitResult_failure()
        {
            UnitResult<ErrorType> subject = UnitResult.Failure(ErrorType.Error1);
            Assert.Equal("Failure(Error1)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_success()
        {
            Return subject = Return.Success();
            Assert.Equal("Success", subject.ToString());
        }

        [Fact]
        public void ToString_returns_success_for_UnitResult()
        {
            UnitResult<ErrorType> result = Return.Success<ErrorType>();
            Assert.Equal("Success", result.ToString());
        }

        [Fact]
        public void ToString_returns_success_with_generic_result()
        {
            Return<int> subject = Return.Success(1);
            Assert.Equal("Success(1)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_success_with_generic_result_and_generic_error()
        {
            Return<int, ErrorType> subject = Return.Success<int, ErrorType>(1);
            Assert.Equal("Success(1)", subject.ToString());
        }

        enum ErrorType
        {
            Error1
        }
    }
}

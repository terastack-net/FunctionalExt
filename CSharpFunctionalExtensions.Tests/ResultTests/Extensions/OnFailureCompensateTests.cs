using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensate : TestBase
    {
        [Fact]
        public void OnFailureCompensate_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage);
            var newResult = myResult.OnFailureCompensate(Return.Success);

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public void OnFailureCompensate_func_string_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage);
            var newResult = myResult.OnFailureCompensate(errorMessage => Return.Success());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void OnFailureCompensate_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage);
            var newResult = myResult.OnFailureCompensate(() => Return.Success(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public void OnFailureCompensate_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage);
            var newResult = myResult.OnFailureCompensate(error => Return.Success(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public void OnFailureCompensate_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value);
            var newResult = myResult.OnFailureCompensate(error => Return.Success<T, E>(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public void OnFailureCompensate_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value);
            var newResult = myResult.OnFailureCompensate(() => Return.Success<T, E>(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}
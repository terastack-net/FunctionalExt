using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods
{
    public class FirstFailureOrSuccessTests
    {
        [Fact]
        public void FirstFailureOrSuccess_returns_the_first_failed_result()
        {
            Return result1 = Return.Success();
            Return result2 = Return.Failure("Failure 1");
            Return result3 = Return.Failure("Failure 2");

            Return result = Return.FirstFailureOrSuccess(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Failure 1");
            result.Should().Be(result2);
        }

        [Fact]
        public void FirstFailureOrSuccess_returns_success_if_no_failures()
        {
            Return result1 = Return.Success();
            Return result2 = Return.Success();
            Return result3 = Return.Success();

            Return result = Return.FirstFailureOrSuccess(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
            result.Should().Be(Return.Success());
        }
    }
}

using FluentAssertions;
using System.Threading.Tasks;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods
{
    public class SuccessIfTests
    {
        [Fact]
        public void Create_value_is_null_Success_result_expected()
        {
            Return result = Return.SuccessIf(true, 7, null);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_error_is_null_Exception_expected()
        {
            Action resultAction = () =>
                Return.SuccessIf<int, string>(false, 7, null);

            FluentActions.Invoking(resultAction).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Create_error_is_default_Failure_result_expected()
        {
            Return<bool, int> result = Return.SuccessIf<bool, int>(false, false, 0);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(0);
        }

        [Fact]
        public void Create_argument_is_true_Success_result_expected()
        {
            Return result = Return.SuccessIf(true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_argument_is_false_Failure_result_expected()
        {
            Return result = Return.SuccessIf(false, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void Create_predicate_is_true_Success_result_expected()
        {
            Return result = Return.SuccessIf(() => true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_predicate_is_false_Failure_result_expected()
        {
            Return result = Return.SuccessIf(() => false, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task Create_async_predicate_is_true_Success_result_expected()
        {
            Return result = await Return.SuccessIf(() => Task.FromResult(true), string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Create_async_predicate_is_false_Failure_result_expected()
        {
            Return result = await Return.SuccessIf(() => Task.FromResult(false), "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public void Create_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Return<byte> result = Return.SuccessIf(true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            Return<double> result = Return.SuccessIf(false, val, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void Create_generic_predicate_is_true_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Return<DateTime> result = Return.SuccessIf(() => true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_generic_predicate_is_false_Failure_result_expected()
        {
            string val = "string value";

            Return<string> result = Return.SuccessIf(() => false, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task Create_generic_async_predicate_is_true_Success_result_expected()
        {
            int val = 42;

            Return<int> result = await Return.SuccessIf(() => Task.FromResult(true), val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task Create_generic_async_predicate_is_false_Failure_result_expected()
        {
            bool val = true;

            Return<bool> result = await Return.SuccessIf(() => Task.FromResult(false), val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        private class Error
        {
        }

        [Fact]
        public void Create_error_generic_argument_is_true_Success_UnitResult_expected()
        {
            UnitResult<Error> result = UnitResult.SuccessIf(true, new Error());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_error_generic_argument_is_false_Failure_UnitResult_expected()
        {
            var error = new Error();

            UnitResult<Error> result = UnitResult.SuccessIf(false, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Create_error_generic_predicate_is_true_Success_UnitResult_expected()
        {
            UnitResult<Error> result = UnitResult.SuccessIf(() => true, new Error());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_error_generic_predicate_is_false_Failure_UnitResult_expected()
        {
            var error = new Error();

            UnitResult<Error> result = UnitResult.SuccessIf(() => false, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_true_Success_UnitResult_expected()
        {
            UnitResult<Error> result = await UnitResult.SuccessIf(() => Task.FromResult(true), new Error());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_false_Failure_UnitResult_expected()
        {
            var error = new Error();

            UnitResult<Error> result = await UnitResult.SuccessIf(() => Task.FromResult(false), error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Create_error_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Return<byte, Error> result = Return.SuccessIf(true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_error_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            var error = new Error();

            Return<double, Error> result = Return.SuccessIf(false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Create_error_generic_predicate_is_true_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Return<DateTime, Error> result = Return.SuccessIf(() => true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_error_generic_predicate_is_false_Failure_result_expected()
        {
            string val = "string value";
            var error = new Error();

            Return<string, Error> result = Return.SuccessIf(() => false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_true_Success_result_expected()
        {
            int val = 42;

            Return<int, Error> result = await Return.SuccessIf(() => Task.FromResult(true), val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_false_Failure_result_expected()
        {
            bool val = true;
            var error = new Error();

            Return<bool, Error> result = await Return.SuccessIf(() => Task.FromResult(false), val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
    }
}

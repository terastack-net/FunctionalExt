using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ResultTests : TestBase
    { 
        [Fact]
        public void Success_argument_is_null_Success_result_expected()
        {
            Return result = Return.Success<string>(null);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Fail_argument_is_default_Fail_result_expected()
        {
            Return<string, int> result = Return.Failure<string, int>(0);

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Fail_argument_is_not_default_Fail_result_expected()
        {
            Return<string, int> result = Return.Failure<string, int>(1);

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Fail_argument_is_null_Exception_expected()
        {
            var exception = Record.Exception(() =>
                Return.Failure<string, string>(null));
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void CreateFailure_value_is_null_Success_result_expected()
        {
            Return result = Return.FailureIf<string>(false, null, null);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreateFailure_error_is_null_Exception_expected()
        {
            var exception = Record.Exception(() =>
                Return.FailureIf<string, string>(true, null, null));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void CreateFailure_error_is_default_Failure_result_expected()
        {
            Return<bool, int> result = Return.FailureIf<bool, int>(true, false, 0);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(0);
        }

        [Fact]
        public void CreateFailure_argument_is_false_Success_result_expected()
        {
            Return result = Return.FailureIf(false, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreateFailure_argument_is_true_Failure_result_expected()
        {
            Return result = Return.FailureIf(true, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void CreateFailure_predicate_is_false_Success_result_expected()
        {
            Return result = Return.FailureIf(() => false, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreateFailure_predicate_is_true_Failure_result_expected()
        {
            Return result = Return.FailureIf(() => true, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task CreateFailure_async_predicate_is_false_Success_result_expected()
        {
            Return result = await Return.FailureIf(() => Task.FromResult(false), string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task CreateFailure_async_predicate_is_true_Failure_result_expected()
        {
            Return result = await Return.FailureIf(() => Task.FromResult(true), "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public void CreateFailure_generic_argument_is_false_Success_result_expected()
        {
            byte val = 7;
            Return<byte> result = Return.FailureIf(false, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_generic_argument_is_true_Failure_result_expected()
        {
            double val = .56;
            Return<double> result = Return.FailureIf(true, val, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void CreateFailure_generic_predicate_is_false_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Return<DateTime> result = Return.FailureIf(() => false, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_generic_predicate_is_true_Failure_result_expected()
        {
            string val = "string value";

            Return<string> result = Return.FailureIf(() => true, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task CreateFailure_generic_async_predicate_is_false_Success_result_expected()
        {
            int val = 42;

            Return<int> result = await Return.FailureIf(() => Task.FromResult(false), val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task CreateFailure_generic_async_predicate_is_true_Failure_result_expected()
        {
            bool val = true;

            Return<bool> result = await Return.FailureIf(() => Task.FromResult(true), val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }


        [Fact]
        public void CreateFailure_error_generic_argument_is_false_Success_result_expected()
        {
            byte val = 7;
            Return<byte, Error> result = Return.FailureIf(false, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_error_generic_argument_is_true_Failure_result_expected()
        {
            double val = .56;
            var error = new Error();

            Return<double, Error> result = Return.FailureIf(true, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void CreateFailure_error_generic_predicate_is_false_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Return<DateTime, Error> result = Return.FailureIf(() => false, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_error_generic_predicate_is_true_Failure_result_expected()
        {
            string val = "string value";
            var error = new Error();

            Return<string, Error> result = Return.FailureIf(() => true, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task CreateFailure_error_generic_async_predicate_is_false_Success_result_expected()
        {
            int val = 42;

            Return<int, Error> result = await Return.FailureIf(() => Task.FromResult(false), val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task CreateFailure_error_generic_async_predicate_is_true_Failure_result_expected()
        {
            bool val = true;
            var error = new Error();

            Return<bool, Error> result = await Return.FailureIf(() => Task.FromResult(true), val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Can_work_with_nullable_sructs()
        {
            Return<DateTime?> result = Return.Success((DateTime?)null);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(null);
        }

        [Fact]
        public void Can_work_with_maybe_of_struct()
        {
            Maybe<DateTime> maybe = Maybe<DateTime>.None;

            Return<Maybe<DateTime>> result = Return.Success(maybe);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(Maybe<DateTime>.None);
        }

        [Fact]
        public void Can_work_with_maybe_of_ref_type()
        {
            Maybe<string> maybe = Maybe<string>.None;

            Return<Maybe<string>> result = Return.Success(maybe);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(Maybe<string>.None);
        }
    }
}
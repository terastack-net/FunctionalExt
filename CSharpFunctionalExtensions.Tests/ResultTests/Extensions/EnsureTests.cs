using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureTests : TestBase
    {
        [Fact]
        public void Ensure_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Return sut = Return.Failure("some error");

            Return result = sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Return sut = Return.Success();

            Return result = sut.Ensure(() => false, "predicate failed");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate failed");
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Return sut = Return.Success();

            Return result = sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Return sut = Return.Failure("some error");

            Return result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Return sut = Return.Success();

            Return result = await sut.Ensure(() => Task.FromResult(false), "predicate problems");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }

        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Return sut = Return.Success();

            Return result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_passed_error_predicate_is_not_invoked()
        {
            Task<Return<int?>> sut = Task.FromResult(Return.Success<int?>(null));

            Return<int?> result = await sut.Ensure(value => !value.HasValue,
                value => Task.FromResult($"should be null but found {value.Value}"));

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Return> sut = Task.FromResult(Return.Failure("some error"));

            Return result = await sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Task<Return> sut = Task.FromResult(Return.Success());

            Return result = await sut.Ensure(() => false, "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Task<Return> sut = Task.FromResult(Return.Success());

            Return result = await sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Return> sut = Task.FromResult(Return.Failure("some error"));

            Return result = await sut.Ensure(() => Task.FromResult(false), string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Task<Return> sut = Task.FromResult(Return.Success());

            Return result = await sut.Ensure(() => Task.FromResult(false), "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Task<Return> sut = Task.FromResult(Return.Success());

            Return result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public void Ensure_generic_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Return<TimeSpan> sut = Return.Failure<TimeSpan>("some error");

            Return<TimeSpan> result = sut.Ensure(time => true, "test error");

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Return<int> sut = Return.Success(10101);

            Return<int> result = sut.Ensure(i => false, "test error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test error");
        }

        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Return<decimal> sut = Return.Success(.03m);

            Return<decimal> result = sut.Ensure(d => true, "test error");

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Return<DateTimeOffset> sut = Return.Failure<DateTimeOffset>("some result error");

            Return<DateTimeOffset> result = await sut.Ensure(d => Task.FromResult(true), "test ensure error");

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Return<int> sut = Return.Success(333);

            Return<int> result = await sut.Ensure(i => Task.FromResult(false), "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Return<decimal> sut = Return.Success(.33m);

            Return<decimal> result = await sut.Ensure(d => Task.FromResult(true), "test error");

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Return<TimeSpan>> sut = Task.FromResult(Return.Failure<TimeSpan>("some result error"));

            Return<TimeSpan> result = await sut.Ensure(t => Task.FromResult(true), "test ensure error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Task<Return<long>> sut = Task.FromResult(Return.Success<long>(333));

            Return<long> result = await sut.Ensure(l => Task.FromResult(false), "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Task<Return<double>> sut = Task.FromResult(Return.Success(.33));

            Return<double> result = await sut.Ensure(d => Task.FromResult(true), "test error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Return<TimeSpan>> sut = Task.FromResult(Return.Failure<TimeSpan>("some result error"));

            Return<TimeSpan> result = await sut.Ensure(t => true, "test ensure error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Task<Return<long>> sut = Task.FromResult(Return.Success<long>(333));

            Return<long> result = await sut.Ensure(l => false, "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Task<Return<double>> sut = Task.FromResult(Return.Success(.33));

            Return<double> result = await sut.Ensure(d => true, "test error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_with_error_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Return<DateTime, Error> sut = Return.Failure<DateTime, Error>(new Error());

            Return<DateTime, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_with_error_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Return<int, Error> sut = Return.Success<int, Error>(101);
            var error = new Error();

            Return<int, Error> result = await sut.Ensure(i => Task.FromResult(false), error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_with_error_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Return<decimal, Error> sut = Return.Success<decimal, Error>(.0003m);

            Return<decimal, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_failure_async_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Return<DateTime, Error>> sut = Task.FromResult(Return.Failure<DateTime, Error>(new Error()));

            Return<DateTime, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_async_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Return<int, Error>> sut = Task.FromResult(Return.Success<int, Error>(100));
            var error = new Error();

            Return<int, Error> result = await sut.Ensure(i => Task.FromResult(false), error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_async_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Return<decimal, Error>> sut = Task.FromResult(Return.Success<decimal, Error>(.3m));

            Return<decimal, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Return<TimeSpan, Error>> sut = Task.FromResult(Return.Failure<TimeSpan, Error>(new Error()));

            Return<TimeSpan, Error> result = await sut.Ensure(t => true, new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Return<byte, Error>> sut = Task.FromResult(Return.Success<byte, Error>(32));
            var error = new Error();

            Return<byte, Error> result = await sut.Ensure(b => false, error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Return<double, Error>> sut = Task.FromResult(Return.Success<double, Error>(.35));

            Return<double, Error> result = await sut.Ensure(d => true, new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public void Ensure_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Return<TimeSpan, Error> sut = Return.Failure<TimeSpan, Error>(new Error());

            Return<TimeSpan, Error> result = sut.Ensure(t => true, new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Return<byte, Error> sut = Return.Success<byte, Error>(32);
            var error = new Error();

            Return<byte, Error> result = sut.Ensure(b => false, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Return<double, Error> sut = Return.Success<double, Error>(.35);

            Return<double, Error> result = sut.Ensure(d => true, new Error());

            result.Should().Be(sut);
        }


        [Fact(DisplayName = "Given failed UnitResult, when predicate is true, Ensure() yields original UnitResult")]
        public void Given_failed_UnitResult__when_predicate_is_true__Ensure_yields_original_UnitResult()
        {
            var sut = UnitResult.Failure<Error>(new Error());

            var result = sut.Ensure(() => true, new Error());

            result.Should().Be(sut);
        }

        [Fact(DisplayName = "Given failed UnitResult, when predicate is false, Ensure() yields original UnitResult")]
        public void Given_failed_UnitResult__when_predicate_is_false__Ensure_yields_original_UnitResult()
        {
            var sut = UnitResult.Failure<Error>(new Error());

            var result = sut.Ensure(() => false, new Error());

            result.Should().Be(sut);
        }

        [Fact(DisplayName =
            "Given successful UnitResult, when predicate is false, Ensure() yields original successful UnitResult")]
        public void Given_successful_UnitResult__when_predicate_is_false__Ensure_yields_original_UnitResult()
        {
            var sut = UnitResult.Success<Error>();
            var error = new Error();

            var result = sut.Ensure(() => false, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact(DisplayName = "Given successful UnitResult, when predicate is false, Ensure() yields failed UnitResult")]
        public void Given_successfu_UnitResult__when_predicate_is_false__Ensure_yields_failed_UnitResult()
        {
            var sut = UnitResult.Success<Error>();

            var result = sut.Ensure(() => true, new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_with_successInput_and_successPredicate()
        {
            var initialResult = Return.Success("Initial message");

            var result = initialResult.Ensure(() => Return.Success("Success message"));

            result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
            result.Value.Should().Be("Initial message");
        }

        [Fact]
        public void Ensure_with_successInput_and_failurePredicate()
        {
            var initialResult = Return.Success("Initial Result");

            var result = initialResult.Ensure(() => Return.Failure("Error message"));

            result.IsSuccess.Should().BeFalse("Predicate is failure result");
            result.Error.Should().Be("Error message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_successPredicate()
        {
            var initialResult = Return.Failure("Initial Error message");

            var result = initialResult.Ensure(() => Return.Success("Success message"));

            result.IsSuccess.Should().BeFalse("Initial result is failure result");
            result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_failurePredicate()
        {
            var initialResult = Return.Failure("Initial Error message");

            var result = initialResult.Ensure(() => Return.Failure("Error message"));

            result.IsSuccess.Should().BeFalse("Initial result is failure result");
            result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public void Ensure_with_successInput_and_parameterisedFailurePredicate()
        {
            var initialResult = Return.Success("Initial Success message");

            var result = initialResult.Ensure(_ => Return.Failure("Error Message"));

            result.IsSuccess.Should().BeFalse("Predicate is failure result");
            result.Error.Should().Be("Error Message");
        }

        [Fact]
        public void Ensure_with_successInput_and_parameterisedSuccessPredicate()
        {
            var initialResult = Return.Success("Initial Success message");

            var result = initialResult.Ensure(_ => Return.Success("Success Message"));

            result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
            ;
            result.Value.Should().Be("Initial Success message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_parameterisedSuccessPredicate()
        {
            var initialResult = Return.Failure<string>("Initial Error message");

            var result = initialResult.Ensure(_ => Return.Success("Success Message"));

            result.IsSuccess.Should().BeFalse("Initial result is failure result");
            ;
            result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_parameterisedFailurePredicate()
        {
            var initialResult = Return.Failure<string>("Initial Error message");

            var result = initialResult.Ensure(_ => Return.Failure("Success Message"));

            result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");
            ;
            result.Error.Should().Be("Initial Error message");
        }
    }
}

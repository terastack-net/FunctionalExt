using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests : CompensateTestsBase
    {
        [Fact]
        public void Compensate_returns_success_and_does_not_execute_func()
        {
            Return input = Return.Success();

            Return output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_returns_failure_and_execute_func_returns_success()
        {
            Return input = Return.Failure(ErrorMessage);

            Return output = input.Compensate(GetSuccessResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_returns_failure_and_execute_func_returns_failure()
        {
            Return input = Return.Failure(ErrorMessage);

            Return output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_returns_E_success_and_does_not_execute_func()
        {
            Return input = Return.Success();

            UnitResult<E> output = input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_returns_E_failure_and_execute_func_returns_success()
        {
            Return input = Return.Failure(ErrorMessage);

            UnitResult<E> output = input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_returns_E_failure_and_execute_func_returns_failure()
        {
            Return input = Return.Failure(ErrorMessage);

            UnitResult<E> output = input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_success_and_does_not_execute_func()
        {
            Return<T> input = Return.Success(T.Value);

            Return output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_returns_failure_and_execute_func_returns_success()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return output = input.Compensate(GetSuccessResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_failure_and_execute_func_returns_failure()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_T_success_and_does_not_execute_func()
        {
            Return<T> input = Return.Success(T.Value);

            Return<T> output = input.Compensate(GetErrorValueResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_returns_T_failure_and_execute_func_returns_success()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T> output = input.Compensate(GetSuccessValueResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_T_failure_and_execute_func_returns_failure()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T> output = input.Compensate(GetErrorValueResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_T_E_success_and_does_not_execute_func()
        {
            Return<T> input = Return.Success(T.Value);

            Return<T, E> output = input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_returns_T_E_failure_and_execute_func_returns_success()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T, E> output = input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_T_E_failure_and_execute_func_returns_failure()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T, E> output = input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_E_returns_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            Return output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_E_returns_failure_and_execute_func_returns_success()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Return output = input.Compensate(GetSuccessResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_E_returns_failure_and_execute_func_returns_failure()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Return output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_E_returns_E2_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_E_returns_E2_failure_and_execute_func_returns_success()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_E_returns_E2_failure_and_execute_func_returns_failure()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_success_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Success<T, E>(T.Value);

            Return output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_E_returns_failure_and_execute_func_returns_success()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return output = input.Compensate(GetSuccessResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_failure_and_execute_func_returns_failure()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Success<T, E>(T.Value);

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_E_returns_E2_failure_and_execute_func_returns_success()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            UnitResult<E2> output = input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_E2_failure_and_execute_func_returns_failure()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public void Compensate_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Success<T, E>(T.Value);

            Return<T, E2> output = input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_E_returns_T_E2_failure_and_execute_func_returns_success()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return<T, E2> output = input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_T_E2_failure_and_execute_func_returns_failure()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return<T, E2> output = input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }
    }
}

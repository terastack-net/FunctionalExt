using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests_ValueTask_Left : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_ValueTask_Left_returns_success_and_does_not_execute_func()
        {
            ValueTask<Return> input = Return.Success().AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_returns_failure_and_does_not_execute_func()
        {
            ValueTask<Return> input = Return.Failure(ErrorMessage).AsValueTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_returns_success_and_execute_func()
        {
            ValueTask<Return> input = Return.Failure(ErrorMessage).AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_returns_E_success_and_does_not_execute_func()
        {
            ValueTask<Return> input = Return.Success().AsValueTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_returns_E_failure_and_does_not_execute_func()
        {
            ValueTask<Return> input = Return.Failure(ErrorMessage).AsValueTask();

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_returns_E_success_and_execute_func()
        {
            ValueTask<Return> input = Return.Failure(ErrorMessage).AsValueTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_success_and_does_not_execute_func()
        {
            ValueTask<Return<T>> input = Return.Success(T.Value).AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_failure_and_does_not_execute_func()
        {
            ValueTask<Return<T>> input = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_success_and_execute_func()
        {
            ValueTask<Return<T>> input = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_T_success_and_does_not_execute_func()
        {
            ValueTask<Return<T>> input = Return.Success(T.Value).AsValueTask();

            Return<T> output = await input.Compensate(GetErrorValueResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_T_failure_and_does_not_execute_func()
        {
            ValueTask<Return<T>> input = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return<T> output = await input.Compensate(GetSuccessValueResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_T_success_and_execute_func()
        {
            ValueTask<Return<T>> input = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return<T> output = await input.Compensate(GetErrorValueResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_T_E_success_and_does_not_execute_func()
        {
            ValueTask<Return<T>> input = Return.Success(T.Value).AsValueTask();

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_T_E_failure_and_does_not_execute_func()
        {
            ValueTask<Return<T>> input = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return<T, E> output = await input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_returns_T_E_success_and_execute_func()
        {
            ValueTask<Return<T>> input = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_E_returns_success_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Success<E>().AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_E_returns_failure_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_E_returns_success_and_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_E_returns_E2_success_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Success<E>().AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_E_returns_E2_failure_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_E_returns_E2_success_and_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_success_and_does_not_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Success<T, E>(T.Value).AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_failure_and_does_not_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsValueTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_success_and_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsValueTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_E2_success_and_does_not_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Success<T, E>(T.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_E2_success_and_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Success<T, E>(T.Value).AsValueTask();

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsValueTask();

            Return<T, E2> output = await input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_Left_T_E_returns_T_E2_success_and_execute_func()
        {
            ValueTask<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsValueTask();

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }
    }
}

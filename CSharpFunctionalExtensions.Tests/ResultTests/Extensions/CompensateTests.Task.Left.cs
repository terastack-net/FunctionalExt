using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests_Task_Left : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_Task_Left_returns_success_and_does_not_execute_func()
        {
            Task<Return> input = Return.Success().AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_returns_failure_and_does_not_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_returns_success_and_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_returns_E_success_and_does_not_execute_func()
        {
            Task<Return> input = Return.Success().AsTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_returns_E_failure_and_does_not_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_returns_E_success_and_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_success_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Success(T.Value).AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_failure_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_success_and_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_T_success_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Success(T.Value).AsTask();

            Return<T> output = await input.Compensate(GetErrorValueResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_T_failure_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T> output = await input.Compensate(GetSuccessValueResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_T_success_and_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T> output = await input.Compensate(GetErrorValueResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_T_E_success_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Success(T.Value).AsTask();

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_T_E_failure_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T, E> output = await input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_returns_T_E_success_and_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_E_returns_success_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Success<E>().AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_E_returns_failure_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_E_returns_success_and_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_E_returns_E2_success_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Success<E>().AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_E_returns_E2_failure_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_E_returns_E2_success_and_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_success_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Success<T, E>(T.Value).AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_failure_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return output = await input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_success_and_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return output = await input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Success<T, E>(T.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_E2_success_and_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Success<T, E>(T.Value).AsTask();

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return<T, E2> output = await input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Left_T_E_returns_T_E2_success_and_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }
    }
}

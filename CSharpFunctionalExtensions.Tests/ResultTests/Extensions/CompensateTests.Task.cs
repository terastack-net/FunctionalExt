using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests_Task : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_Task_returns_success_and_does_not_execute_func()
        {
            Task<Return> input = Return.Success().AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_returns_failure_and_does_not_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_returns_success_and_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_returns_E_success_and_does_not_execute_func()
        {
            Task<Return> input = Return.Success().AsTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_returns_E_failure_and_does_not_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_returns_E_success_and_execute_func()
        {
            Task<Return> input = Return.Failure(ErrorMessage).AsTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_success_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Success(T.Value).AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_failure_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_success_and_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_T_success_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Success(T.Value).AsTask();

            Return<T> output = await input.Compensate(GetErrorValueResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_T_failure_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T> output = await input.Compensate(GetSuccessValueResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_T_success_and_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T> output = await input.Compensate(GetErrorValueResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_T_E_success_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Success(T.Value).AsTask();

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_T_E_failure_and_does_not_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T, E> output = await input.Compensate(GetSuccessValueErrorResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_T_returns_T_E_success_and_execute_func()
        {
            Task<Return<T>> input = Return.Failure<T>(ErrorMessage).AsTask();

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_E_returns_success_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Success<E>().AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_E_returns_failure_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_E_returns_success_and_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_E_returns_E2_success_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Success<E>().AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_E_returns_E2_failure_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_E_returns_E2_success_and_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_success_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Success<T, E>(T.Value).AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_failure_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_success_and_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Success<T, E>(T.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_E2_success_and_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_Task_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Success<T, E>(T.Value).AsTask();

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return<T, E2> output = await input.Compensate(GetSuccessValueErrorResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_T_E_returns_T_E2_success_and_execute_func()
        {
            Task<Return<T, E>> input = Return.Failure<T, E>(E.Value).AsTask();

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertFailure(output, executed: true);
        }
    }
}

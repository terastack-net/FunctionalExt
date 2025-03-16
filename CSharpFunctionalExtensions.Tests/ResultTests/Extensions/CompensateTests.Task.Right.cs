using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests_Task_Right : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_Task_Right_returns_success_and_does_not_execute_func()
        {
            Return input = Return.Success();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_returns_failure_and_does_not_execute_func()
        {
            Return input = Return.Failure(ErrorMessage);

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_returns_success_and_execute_func()
        {
            Return input = Return.Failure(ErrorMessage);

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_returns_E_success_and_does_not_execute_func()
        {
            Return input = Return.Success();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_returns_E_failure_and_does_not_execute_func()
        {
            Return input = Return.Failure(ErrorMessage);

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_returns_E_success_and_execute_func()
        {
            Return input = Return.Failure(ErrorMessage);

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_success_and_does_not_execute_func()
        {
            Return<T> input = Return.Success(T.Value);

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_failure_and_does_not_execute_func()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_success_and_execute_func()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_T_success_and_does_not_execute_func()
        {
            Return<T> input = Return.Success(T.Value);

            Return<T> output = await input.Compensate(GetErrorValueResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_T_failure_and_does_not_execute_func()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T> output = await input.Compensate(GetSuccessValueResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_T_success_and_execute_func()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T> output = await input.Compensate(GetErrorValueResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_T_E_success_and_does_not_execute_func()
        {
            Return<T> input = Return.Success(T.Value);

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_T_E_failure_and_does_not_execute_func()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T, E> output = await input.Compensate(GetSuccessValueErrorResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_returns_T_E_success_and_execute_func()
        {
            Return<T> input = Return.Failure<T>(ErrorMessage);

            Return<T, E> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_E_returns_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_E_returns_success_and_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_E_returns_E2_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_E_returns_E2_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_E_returns_E2_success_and_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_success_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Success<T, E>(T.Value);

            Return output = await input.Compensate(GetErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_failure_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return output = await input.Compensate(GetSuccessResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_success_and_execute_func()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return output = await input.Compensate(GetErrorResultTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Success<T, E>(T.Value);

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_E2_success_and_execute_func()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultTask);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Success<T, E>(T.Value);

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return<T, E2> output = await input.Compensate(GetSuccessValueErrorResultTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_Task_Right_T_E_returns_T_E2_success_and_execute_func()
        {
            Return<T, E> input = Return.Failure<T, E>(E.Value);

            Return<T, E2> output = await input.Compensate(GetErrorValueErrorResultTask);

            AssertFailure(output, executed: true);
        }
    }
}

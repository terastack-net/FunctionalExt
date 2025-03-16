using System.Threading.Tasks;
using Xunit;
using CSharpFunctionalExtensions.ValueTasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapTryTests_ValueTask_Left : MapTryTestsBase
    {
        #region MapTry for ValueTask<Result> with function returning K
        [Fact]
        public async ValueTask MapTry_execute_func_K_on_valuetask_success_returns_success()
        {
            ValueTask<Return> sut = Return.Success().AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Func_K);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_func_K_on_valuetask_failure_returns_failure()
        {
            ValueTask<Return> sut = Return.Failure(ErrorMessage).AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Func_K);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_throwing_func_K_on_taks_success_returns_failure_with_exception_message()
        {
            ValueTask<Return> sut = Return.Success().AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Throwing_K);

            AssertFailureFromDefaultHandler(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            ValueTask<Return> sut = Return.Success().AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Throwing_K, ErrorHandler);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for ValueTask<Result<T>> with function returning K
        [Fact]
        public async ValueTask MapTry_execute_func_K_on_valuetask_success_T_returns_success()
        {
            ValueTask<Return<T>> sut = Return.Success(T.Value).AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Func_T_K);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_func_K_on_valuetask_failure_T_returns_failure()
        {
            ValueTask<Return<T>> sut = Return.Failure<T>(ErrorMessage).AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Func_T_K);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_throwing_func_K_on_taks_success_T_returns_failure_with_exception_message()
        {
            ValueTask<Return<T>> sut = Return.Success(T.Value).AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Throwing_T_K);

            AssertFailureFromDefaultHandler(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_throwing_func_K_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            ValueTask<Return<T>> sut = Return.Success(T.Value).AsValueTask();

            Return<K> result = await sut.MapTry(valueTask:Throwing_T_K, ErrorHandler);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for ValueTask<Result<T,E>> with function returning K
        [Fact]
        public async ValueTask MapTry_execute_func_T_K_on_valuetask_success_T_E_returns_success()
        {
            ValueTask<Return<T, E>> sut = Return.Success<T, E>(T.Value).AsValueTask();

            Return<K, E> result = await sut.MapTry(valueTask:Func_T_K, ErrorHandler_E);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_func_T_K_on_valuetask_failure_T_E_returns_failure()
        {
            ValueTask<Return<T, E>> sut = Return.Failure<T, E>(E.Value).AsValueTask();

            Return<K, E> result = await sut.MapTry(valueTask:Func_T_K, ErrorHandler_E);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_throwing_func_T_K_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            ValueTask<Return<T, E>> sut = Return.Success<T, E>(T.Value).AsValueTask();

            Return<K, E> result = await sut.MapTry(valueTask:Throwing_T_K, ErrorHandler_E);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for ValueTask<UnitResult<E>> with function returning K
        [Fact]
        public async ValueTask MapTry_execute_func_K_on_valuetask_success_E_returns_success()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            Return<K, E> result = await sut.MapTry(valueTask:Func_K, ErrorHandler_E);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_func_K_on_valuetask_failure_E_returns_failure()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Failure(E.Value).AsValueTask();

            Return<K, E> result = await sut.MapTry(valueTask:Func_K, ErrorHandler_E);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask MapTry_execute_throwing_func_K_on_success_E_returns_failure_with_value_from_error_handler()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            Return<K, E> result = await sut.MapTry(valueTask:Throwing_K, ErrorHandler_E);

            AssertFailureFromHandler(result);
        }
        #endregion        
    }
}

using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests
{
    public abstract class BindTestsBase : TestBase
    {
        private bool _funcExecuted;
        protected T FuncParam;

        protected BindTestsBase()
        {
            _funcExecuted = false;
            FuncParam = null;
        }

        protected bool FuncExecuted => _funcExecuted;

        protected Return Success()
        {
            _funcExecuted = true;
            return Return.Success();
        }

        protected Return Failure()
        {
            _funcExecuted = false;
            return Return.Failure(ErrorMessage);
        }

        protected Return<T> Success_T(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return Return.Success(value);
        }

        protected Return<T> Failure_T()
        {
            _funcExecuted = false;
            return Return.Failure<T>(ErrorMessage);
        }

        protected Return<T, E> Failure_T_E()
        {
            _funcExecuted = false;
            return Return.Failure<T, E>(E.Value);
        }

        protected Return<K> Success_K()
        {
            _funcExecuted = true;
            return Return.Success(K.Value);
        }
        protected Return<K> Failure_K()
        {
            _funcExecuted = false;
            return Return.Failure<K>(ErrorMessage);
        }

        protected Return<K> Success_T_Func_K(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return Return.Success(K.Value);
        }

        protected Return<K, E> Success_T_E_Func_K(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return Return.Success<K, E>(K.Value);
        }

        protected Return<K, E> Failure_T_E_Func_K(T value)
        {
            _funcExecuted = false;
            FuncParam = value;
            return Return.Failure<K, E>(E.Value);
        }

        protected Return<T, E> Success_T_E()
        {
            _funcExecuted = true;
            return Return.Success<T, E>(T.Value);
        }

        protected UnitResult<E> UnitResult_Success_E()
        {
            _funcExecuted = true;
            return UnitResult.Success<E>();
        }

        protected UnitResult<E> UnitResult_Failure_E()
        {
            _funcExecuted = false;
            return UnitResult.Failure(E.Value);
        }

        protected UnitResult<E> UnitResult_E_T(T value)
        {
            _funcExecuted = true;
            FuncParam = value;
            return UnitResult.Success<E>();
        }

        protected Task<Return> Task_Success()
        {
            return Success().AsTask();
        }

        protected Task<Return> Task_Failure()
        {
            return Failure().AsTask();
        }

        protected Task<Return<T>> Task_Success_T(T value)
        {
            return Success_T(value).AsTask();
        }

        protected Task<Return<T>> Task_Failure_T()
        {
            return Failure_T().AsTask();
        }

        protected Task<Return<T, E>> Task_Failure_T_E()
        {
            return Failure_T_E().AsTask();
        }

        protected Task<Return<K>> Task_Success_K()
        {
            return Success_K().AsTask();
        }

        protected Task<Return<K>> Task_Failure_K()
        {
            return Failure_K().AsTask();
        }

        protected Task<Return<K>> Func_T_Task_Success_K(T value)
        {
            return Success_T_Func_K(value).AsTask();
        }

        protected Task<Return<K, E>> Task_Success_K_E(T value)
        {
            return Success_T_E_Func_K(value).AsTask();
        }

        protected Task<Return<K, E>> Task_Failure_K_E(T value)
        {
            return Failure_T_E_Func_K(value).AsTask();            
        }

        protected Task<Return<T, E>> Task_Success_T_E()
        {            
            return Success_T_E().AsTask();
        }

        protected Task<UnitResult<E>> Task_UnitResult_Success_E()
        {
            return UnitResult_Success_E().AsTask();
        }

        protected Task<UnitResult<E>> Task_UnitResult_Failure_E()
        {
            return UnitResult_Failure_E().AsTask();
        }

        protected Task<UnitResult<E>> Func_T_Task_UnitResult_E(T value)
        {
            return UnitResult_E_T(value).AsTask();
        }

        protected ValueTask<Return> ValueTask_Success()
        {
            return Success().AsValueTask();
        }

        protected ValueTask<Return> ValueTask_Failure()
        {
            return Failure().AsValueTask();
        }

        protected ValueTask<Return<T>> ValueTask_Success_T(T value)
        {
            return Success_T(value).AsValueTask();
        }

        protected ValueTask<Return<T>> ValueTask_Failure_T()
        {
            return Failure_T().AsValueTask();
        }
        protected ValueTask<Return<T, E>> ValueTask_Success_T_E()
        {
            return Success_T_E().AsValueTask();
        }

        protected ValueTask<Return<T, E>> ValueTask_Failure_T_E()
        {
            return Failure_T_E().AsValueTask();
        }

        protected ValueTask<Return<K>> ValueTask_Success_K()
        {
            return Success_K().AsValueTask();
        }
        protected ValueTask<Return<K>> ValueTask_Failure_K()
        {
            return Failure_K().AsValueTask();
        }

        protected ValueTask<Return<K>> Func_T_ValueTask_Success_K(T value)
        {
            return Success_T_Func_K(value).AsValueTask();
        }

        protected ValueTask<Return<K, E>> ValueTask_Success_K_E(T value)
        {
            return Success_T_E_Func_K(value).AsValueTask();
        }

        protected ValueTask<Return<K, E>> ValueTask_Failure_K_E(T value)
        {
            return Failure_T_E_Func_K(value).AsValueTask();
        }

        protected ValueTask<Return<T, E>> Func_ValueTask_Success_T_E()
        {
            return Success_T_E().AsValueTask();
        }

        protected ValueTask<UnitResult<E>> ValueTask_UnitResult_Success_E()
        {
            return UnitResult_Success_E().AsValueTask();
        }

        protected ValueTask<UnitResult<E>> ValueTask_UnitResult_Failure_E()
        {
            return UnitResult_Failure_E().AsValueTask();
        }

        protected ValueTask<UnitResult<E>> Func_T_ValueTask_UnitResult_E(T value)
        {
            return UnitResult_E_T(value).AsValueTask();
        }

        protected void AssertFailure(Return output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Return<K> output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Return<K, E> output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertFailure(UnitResult<E> output)
        {
            _funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertSuccess(Return output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(Return<K> output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(Return<K, E> output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(UnitResult<E> output)
        {
            _funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
        }
    }
}
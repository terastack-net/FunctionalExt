using FluentAssertions;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CompensateTestsBase : TestBase
    {
        protected bool funcExecuted;

        protected CompensateTestsBase()
        {
            funcExecuted = false;
        }

        protected Return GetSuccessResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Success();
        }

        protected Return GetErrorResult(string error)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Failure(error);
        }

        protected Return GetSuccessResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Success();
        }

        protected Return GetErrorResult(E error)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Failure(ErrorMessage);
        }

        protected UnitResult<E> GetSuccessUnitResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Success<E>();
        }

        protected UnitResult<E> GetErrorUnitResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Failure(E.Value);
        }

        protected UnitResult<E2> GetSuccessUnitResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Success<E2>();
        }

        protected UnitResult<E2> GetErrorUnitResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Failure(E2.Value);
        }

        protected Return<T> GetSuccessValueResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Success(T.Value);
        }

        protected Return<T> GetErrorValueResult(string error)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Failure<T>(error);
        }

        protected Return<T, E> GetSuccessValueErrorResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Success<T, E>(T.Value);
        }

        protected Return<T, E> GetErrorValueErrorResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Failure<T, E>(E.Value);
        }

        protected Return<T, E2> GetSuccessValueErrorResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Success<T, E2>(T.Value);
        }

        protected Return<T, E2> GetErrorValueErrorResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Return.Failure<T, E2>(E2.Value);
        }

        protected Task<Return> GetSuccessResultTask(string error) => GetSuccessResult(error).AsTask();

        protected Task<Return> GetErrorResultTask(string error) => GetErrorResult(error).AsTask();

        protected Task<Return> GetSuccessResultTask(E error) => GetSuccessResult(error).AsTask();

        protected Task<Return> GetErrorResultTask(E error) => GetErrorResult(error).AsTask();

        protected Task<UnitResult<E>> GetSuccessUnitResultTask(string error) => GetSuccessUnitResult(error).AsTask();

        protected Task<UnitResult<E>> GetErrorUnitResultTask(string error) => GetErrorUnitResult(error).AsTask();

        protected Task<UnitResult<E2>> GetSuccessUnitResultTask(E error) => GetSuccessUnitResult(error).AsTask();

        protected Task<UnitResult<E2>> GetErrorUnitResultTask(E error) => GetErrorUnitResult(error).AsTask();

        protected Task<Return<T>> GetSuccessValueResultTask(string error) => GetSuccessValueResult(error).AsTask();

        protected Task<Return<T>> GetErrorValueResultTask(string error) => GetErrorValueResult(error).AsTask();

        protected Task<Return<T, E>> GetSuccessValueErrorResultTask(string error) => GetSuccessValueErrorResult(error).AsTask();

        protected Task<Return<T, E>> GetErrorValueErrorResultTask(string error) => GetErrorValueErrorResult(error).AsTask();

        protected Task<Return<T, E2>> GetSuccessValueErrorResultTask(E error) => GetSuccessValueErrorResult(error).AsTask();

        protected Task<Return<T, E2>> GetErrorValueErrorResultTask(E error) => GetErrorValueErrorResult(error).AsTask();

        protected ValueTask<Return> GetSuccessResultValueTask(string error) => GetSuccessResult(error).AsValueTask();

        protected ValueTask<Return> GetErrorResultValueTask(string error) => GetErrorResult(error).AsValueTask();

        protected ValueTask<Return> GetSuccessResultValueTask(E error) => GetSuccessResult(error).AsValueTask();

        protected ValueTask<Return> GetErrorResultValueTask(E error) => GetErrorResult(error).AsValueTask();

        protected ValueTask<UnitResult<E>> GetSuccessUnitResultValueTask(string error) => GetSuccessUnitResult(error).AsValueTask();

        protected ValueTask<UnitResult<E>> GetErrorUnitResultValueTask(string error) => GetErrorUnitResult(error).AsValueTask();

        protected ValueTask<UnitResult<E2>> GetSuccessUnitResultValueTask(E error) => GetSuccessUnitResult(error).AsValueTask();

        protected ValueTask<UnitResult<E2>> GetErrorUnitResultValueTask(E error) => GetErrorUnitResult(error).AsValueTask();

        protected ValueTask<Return<T>> GetSuccessValueResultValueTask(string error) => GetSuccessValueResult(error).AsValueTask();

        protected ValueTask<Return<T>> GetErrorValueResultValueTask(string error) => GetErrorValueResult(error).AsValueTask();

        protected ValueTask<Return<T, E>> GetSuccessValueErrorResultValueTask(string error) => GetSuccessValueErrorResult(error).AsValueTask();

        protected ValueTask<Return<T, E>> GetErrorValueErrorResultValueTask(string error) => GetErrorValueErrorResult(error).AsValueTask();

        protected ValueTask<Return<T, E2>> GetSuccessValueErrorResultValueTask(E error) => GetSuccessValueErrorResult(error).AsValueTask();

        protected ValueTask<Return<T, E2>> GetErrorValueErrorResultValueTask(E error) => GetErrorValueErrorResult(error).AsValueTask();
        
        protected void AssertFailure(Return output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Return<K> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Return<K, E> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertFailure(UnitResult<E> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertFailure(UnitResult<E2> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E2.Value);
        }

        protected void AssertSuccess(Return output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(Return<K> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(Return<K, E> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(UnitResult<E> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(UnitResult<E2> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
        }
    }
}

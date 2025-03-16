using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapError_ValueTask_Tests : TapErrorTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_executes_action_on_result_failure_and_returns_self(bool isSuccess)
        {
            Return result = Return.SuccessIf(isSuccess, ErrorMessage);

            Return returned = await result.AsValueTask().TapError(ValueTaskAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_executes_action_string_on_result_failure_and_returns_self(bool isSuccess)
        {
            Return result = Return.SuccessIf(isSuccess, ErrorMessage);

            Return returned = await result.AsValueTask().TapError(ValueTaskActionString);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_T_executes_action_on_result_failure_and_returns_self(bool isSuccess)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Return<T> returned = await result.AsValueTask().TapError(ValueTaskAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_T_executes_action_string_on_result_failure_and_returns_self(bool isSuccess)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Return<T> returned = await result.AsValueTask().TapError(ValueTaskActionString);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_UnitResult_E_executes_action_on_failure_and_returns_self(bool isSuccess)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            UnitResult<E> returned = await result.AsValueTask().TapError(ValueTaskAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_UnitResult_E_executes_E_action_on_failure_and_returns_self(bool isSuccess)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            UnitResult<E> returned = await result.AsValueTask().TapError(ValueTaskActionError);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_T_E_executes_action_on_result_failure_and_returns_self(bool isSuccess)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);

            Return<T, E> returned = await result.AsValueTask().TapError(ValueTaskAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task TapError_ValueTask_T_E_executes_action_T_on_result_failure_and_returns_self(bool isSuccess)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);

            Return<T, E> returned = await result.AsValueTask().TapError(ValueTaskActionError);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }
    }
}
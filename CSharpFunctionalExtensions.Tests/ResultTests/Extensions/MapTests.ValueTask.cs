using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapTests_ValueTask : MapTestsBase
    {
        [Fact]
        public async Task Map_ValueTask_executes_on_success_returns_new_success()
        {
            ValueTask<Return> result = Return.Success().AsValueTask();
            Return<K> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_executes_on_failure_returns_new_failure()
        {
            ValueTask<Return> result = Return.Failure(ErrorMessage).AsValueTask();
            Return<K> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeFalse();
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_T_executes_on_success_returns_new_success()
        {
            ValueTask<Return<T>> result = Return.Success(T.Value).AsValueTask();
            Return<K> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_T_executes_on_failure_returns_new_failure()
        {
            ValueTask<Return<T>> result = Return.Failure<T>(ErrorMessage).AsValueTask();
            Return<K> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_T_E_executes_on_success_returns_new_success()
        {
            ValueTask<Return<T, E>> result = Return.Success<T, E>(T.Value).AsValueTask();
            Return<K, E> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_T_E_executes_on_failure_returns_new_failure()
        {
            ValueTask<Return<T, E>> result = Return.Failure<T, E>(E.Value).AsValueTask();
            Return<K, E> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_UnitResult_E_executes_on_success_returns_success()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            Return<K, E> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_UnitResult_E_executes_on_failure_returns_failure()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            Return<K, E> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_with_context_executes_on_success_and_passes_correct_context()
        {
            ValueTask<Return> result = Return.Success().AsValueTask();
            Return<K> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_with_context_executes_on_failure_and_passes_correct_context()
        {
            ValueTask<Return> result = Return.Failure(ErrorMessage).AsValueTask();
            Return<K> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_T_with_context_executes_on_success_and_passes_correct_context()
        {
            ValueTask<Return<T>> result = Return.Success(T.Value).AsValueTask();
            Return<K> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_T_with_context_executes_on_failure_and_passes_correct_context()
        {
            ValueTask<Return<T>> result = Return.Failure<T>(ErrorMessage).AsValueTask();
            Return<K> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_T_E_with_context_executes_on_success_and_passes_correct_context()
        {
            ValueTask<Return<T, E>> result = Return.Success<T, E>(T.Value).AsValueTask();
            Return<K, E> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_T_E_with_context_executes_on_failure_and_passes_correct_context()
        {
            ValueTask<Return<T, E>> result = Return.Failure<T, E>(E.Value).AsValueTask();
            Return<K, E> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_UnitResult_E_with_context_executes_on_success_and_passes_correct_context()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            Return<K, E> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_UnitResult_E_with_context_executes_on_failure_and_passes_correct_context()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            Return<K, E> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return ValueTask_Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }
    }
}

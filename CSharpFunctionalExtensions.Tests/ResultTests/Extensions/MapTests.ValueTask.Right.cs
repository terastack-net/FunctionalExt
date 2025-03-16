using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapTests_ValueTask_Right : MapTestsBase
    {
        [Fact]
        public async Task Map_ValueTask_Right_executes_on_success_returns_new_success()
        {
            Return result = Return.Success();
            Return<K> actual = await result.Map(valueTask: ValueTask_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_Right_executes_on_failure_returns_new_failure()
        {
            Return result = Return.Failure(ErrorMessage);
            Return<K> actual = await result.Map(valueTask: ValueTask_Func_K);

            actual.IsSuccess.Should().BeFalse();
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_Right_T_executes_on_success_returns_new_success()
        {
            Return<T> result = Return.Success(T.Value);
            Return<K> actual = await result.Map(valueTask: ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_Right_T_executes_on_failure_returns_new_failure()
        {
            Return<T> result = Return.Failure<T>(ErrorMessage);
            Return<K> actual = await result.Map(valueTask: ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_Right_T_E_executes_on_success_returns_new_success()
        {
            Return<T, E> result = Return.Success<T, E>(T.Value);
            Return<K, E> actual = await result.Map(valueTask: ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_Right_T_E_executes_on_failure_returns_new_failure()
        {
            Return<T, E> result = Return.Failure<T, E>(E.Value);
            Return<K, E> actual = await result.Map(valueTask: ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_Right_UnitResult_E_executes_on_success_returns_success()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            Return<K, E> actual = await result.Map(valueTask: ValueTask_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_Right_UnitResult_E_executes_on_failure_returns_failure()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            Return<K, E> actual = await result.Map(valueTask: ValueTask_Func_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_Right_with_context_executes_on_success_and_passes_correct_context()
        {
            Return result = Return.Success();
            Return<K> actual = await result.Map(
                valueTask: context =>
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
        public async Task Map_ValueTask_Right_with_context_executes_on_failure_and_passes_correct_context()
        {
            Return result = Return.Failure(ErrorMessage);
            Return<K> actual = await result.Map(
                valueTask: context =>
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
        public async Task Map_ValueTask_Right_T_with_context_executes_on_success_and_passes_correct_context()
        {
            Return<T> result = Return.Success(T.Value);
            Return<K> actual = await result.Map(
                valueTask: (value, context) =>
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
        public async Task Map_ValueTask_Right_T_with_context_executes_on_failure_and_passes_correct_context()
        {
            Return<T> result = Return.Failure<T>(ErrorMessage);
            Return<K> actual = await result.Map(
                valueTask: (value, context) =>
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
        public async Task Map_ValueTask_Right_T_E_with_context_executes_on_success_and_passes_correct_context()
        {
            Return<T, E> result = Return.Success<T, E>(T.Value);
            Return<K, E> actual = await result.Map(
                valueTask: (value, context) =>
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
        public async Task Map_ValueTask_Right_T_E_with_context_executes_on_failure_and_passes_correct_context()
        {
            Return<T, E> result = Return.Failure<T, E>(E.Value);
            Return<K, E> actual = await result.Map(
                valueTask: (value, context) =>
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
        public async Task Map_ValueTask_Right_UnitResult_E_with_context_executes_on_success_and_passes_correct_context()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            Return<K, E> actual = await result.Map(
                valueTask: context =>
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
        public async Task Map_ValueTask_Right_UnitResult_E_with_context_executes_on_failure_and_passes_correct_context()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            Return<K, E> actual = await result.Map(
                valueTask: context =>
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

using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapTests_Task_Left : MapTestsBase
    {
        [Fact]
        public async Task Map_Task_Left_executes_on_success_returns_new_success()
        {
            Task<Return> result = Return.Success().AsTask();
            Return<K> actual = await result.Map(Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_executes_on_failure_returns_new_failure()
        {
            Task<Return> result = Return.Failure(ErrorMessage).AsTask();
            Return<K> actual = await result.Map(Func_K);

            actual.IsSuccess.Should().BeFalse();
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_T_executes_on_success_returns_new_success()
        {
            Task<Return<T>> result = Return.Success(T.Value).AsTask();
            Return<K> actual = await result.Map(Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_T_executes_on_failure_returns_new_failure()
        {
            Task<Return<T>> result = Return.Failure<T>(ErrorMessage).AsTask();
            Return<K> actual = await result.Map(Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_T_E_executes_on_success_returns_new_success()
        {
            Task<Return<T, E>> result = Return.Success<T, E>(T.Value).AsTask();
            Return<K, E> actual = await result.Map(Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_T_E_executes_on_failure_returns_new_failure()
        {
            Task<Return<T, E>> result = Return.Failure<T, E>(E.Value).AsTask();
            Return<K, E> actual = await result.Map(Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_UnitResult_E_executes_on_success_returns_success()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            Return<K, E> actual = await result.Map(Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_UnitResult_E_executes_on_failure_returns_failure()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            Return<K, E> actual = await result.Map(Func_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_with_context_executes_on_success_and_passes_correct_context()
        {
            Task<Return> result = Return.Success().AsTask();
            Return<K> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_with_context_executes_on_failure_and_passes_correct_context()
        {
            Task<Return> result = Return.Failure(ErrorMessage).AsTask();
            Return<K> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_T_with_context_executes_on_success_and_passes_correct_context()
        {
            Task<Return<T>> result = Return.Success(T.Value).AsTask();
            Return<K> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_T_with_context_executes_on_failure_and_passes_correct_context()
        {
            Task<Return<T>> result = Return.Failure<T>(ErrorMessage).AsTask();
            Return<K> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_T_E_with_context_executes_on_success_and_passes_correct_context()
        {
            Task<Return<T, E>> result = Return.Success<T, E>(T.Value).AsTask();
            Return<K, E> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_T_E_with_context_executes_on_failure_and_passes_correct_context()
        {
            Task<Return<T, E>> result = Return.Failure<T, E>(E.Value).AsTask();
            Return<K, E> actual = await result.Map(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_T_K(value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Left_UnitResult_E_with_context_executes_on_success_and_passes_correct_context()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            Return<K, E> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_Task_Left_UnitResult_E_with_context_executes_on_failure_and_passes_correct_context()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            Return<K, E> actual = await result.Map(
                (context) =>
                {
                    context.Should().Be(ContextMessage);
                    return Func_K();
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }
    }
}

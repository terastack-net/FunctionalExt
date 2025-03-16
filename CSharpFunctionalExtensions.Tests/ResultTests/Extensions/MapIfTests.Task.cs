using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapIfTests_Task : MapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_T_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsTask();
            Return<T> returned = await resultTask.MapIf(condition, GetTaskAction());
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_T_E_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T, E>> resultTask = Return.SuccessIf(isSuccess, T.Value, E.Value).AsTask();
            Return<T, E> returned = await resultTask.MapIf(condition, GetTaskAction());
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_computes_predicate_T_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsTask();
            Return<T> returned = await resultTask.MapIf(
                GetValuePredicate(condition),
                GetTaskAction()
            );
            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T, E>> resultTask = Return.SuccessIf(isSuccess, T.Value, E.Value).AsTask();
            Return<T, E> returned = await resultTask.MapIf(
                GetValuePredicate(condition),
                GetTaskAction()
            );
            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_T_with_context_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsTask();
            Return<T> returned = await resultTask.MapIf(
                condition,
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_T_E_with_context_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T, E>> resultTask = Return.SuccessIf(isSuccess, T.Value, E.Value).AsTask();
            Return<T, E> returned = await resultTask.MapIf(
                condition,
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_computes_predicate_T_with_context_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsTask();
            Return<T> returned = await resultTask.MapIf(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return GetValuePredicate(condition)(value);
                },
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );
            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_computes_predicate_T_E_with_context_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Task<Return<T, E>> resultTask = Return.SuccessIf(isSuccess, T.Value, E.Value).AsTask();
            Return<T, E> returned = await resultTask.MapIf(
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return GetValuePredicate(condition)(value);
                },
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );
            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}

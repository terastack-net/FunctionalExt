using FluentAssertions;
using CSharpFunctionalExtensions.ValueTasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapIfTests_ValueTask_Right : TapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_ValueTask_Right_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return result = Return.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapIf(condition, ValueTask_Action).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_ValueTask_Right_T_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.TapIf(condition, ValueTask_Action).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_Task_Right_T_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.TapIf(condition, ValueTask_Action_T).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_Task_Right_T_E_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.TapIf(condition, ValueTask_Action).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_Task_Right_T_E_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.TapIf(condition, ValueTask_Action_T).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_ValueTask_Right_T_executes_action_per_func_condition_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, ValueTask_Action).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_Task_Right_T_executes_action_T_per_func_condition_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, ValueTask_Action_T).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_Task_Right_T_E_executes_action_per_func_condition_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, ValueTask_Action).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_Task_Right_T_E_executes_action_T_per_func_condition_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, ValueTask_Action_T).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }
    }
}

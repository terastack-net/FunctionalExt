using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class BindIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected BindIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }

        protected Func<Return> GetAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return FailureAction;
            }

            return SuccessAction;
        }

        protected Func<Task<Return>> GetTaskAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return () => Task.FromResult(FailureAction());
            }

            return () => Task.FromResult(SuccessAction());
        }

        protected Func<ValueTask<Return>> GetValueTaskAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return () => FailureAction().AsCompletedValueTask();
            }

            return () => SuccessAction().AsCompletedValueTask();
        }
        
        protected Func<T, Return<T>> GetValueAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return FailureValueAction;
            }

            return SuccessValueAction;
        }

        protected Func<T, Task<Return<T>>> GetTaskValueAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return t => Task.FromResult(FailureValueAction(t));
            }

            return t => Task.FromResult(SuccessValueAction(t));
        }
        
        protected Func<T, ValueTask<Return<T>>> GetValueTaskValueAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return t => FailureValueAction(t).AsCompletedValueTask();
            }

            return t => SuccessValueAction(t).AsCompletedValueTask();
        }

        protected Func<UnitResult<E>> GetErrorAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return FailureErrorAction;
            }

            return SuccessErrorAction;
        }

        protected Func<Task<UnitResult<E>>> GetTaskErrorAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return () => Task.FromResult(FailureErrorAction());
            }

            return () => Task.FromResult(SuccessErrorAction());
        }
        
        protected Func<ValueTask<UnitResult<E>>> GetValueTaskErrorAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return () => FailureErrorAction().AsCompletedValueTask();
            }

            return () => SuccessErrorAction().AsCompletedValueTask();
        }

        protected Func<T, Return<T, E>> GetValueErrorAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return FailureValueErrorAction;
            }

            return SuccessValueErrorAction;
        }

        protected Func<T, Task<Return<T, E>>> GetTaskValueErrorAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return t => Task.FromResult(FailureValueErrorAction(t));
            }

            return t => Task.FromResult(SuccessValueErrorAction(t));
        }

        protected Func<T, ValueTask<Return<T, E>>> GetValueTaskValueErrorAction(bool isSuccess)
        {
            if (!isSuccess)
            {
                return t => FailureValueErrorAction(t).AsCompletedValueTask();
            }

            return t => SuccessValueErrorAction(t).AsCompletedValueTask();
        }

        
        protected Return SuccessAction()
        {
            actionExecuted.Should().BeFalse();

            actionExecuted = true;
            return Return.Success();
        }

        protected Return FailureAction()
        {
            actionExecuted.Should().BeFalse();

            actionExecuted = true;
            return Return.Failure(ErrorMessage2);
        }

        protected Return<T> SuccessValueAction(T value)
        {
            actionExecuted.Should().BeFalse();
            value.Should().Be(T.Value);

            actionExecuted = true;
            return Return.Success(T.Value2);
        }

        protected Return<T> FailureValueAction(T value)
        {
            actionExecuted.Should().BeFalse();
            value.Should().Be(T.Value);

            actionExecuted = true;
            return Return.Failure<T>(ErrorMessage2);
        }

        protected UnitResult<E> SuccessErrorAction()
        {
            actionExecuted.Should().BeFalse();

            actionExecuted = true;
            return UnitResult.Success<E>();
        }

        protected UnitResult<E> FailureErrorAction()
        {
            actionExecuted.Should().BeFalse();

            actionExecuted = true;
            return UnitResult.Failure(E.Value2);
        }

        protected Return<T, E> SuccessValueErrorAction(T value)
        {
            actionExecuted.Should().BeFalse();
            value.Should().Be(T.Value);

            actionExecuted = true;
            return Return.Success<T, E>(T.Value2);
        }

        protected Return<T, E> FailureValueErrorAction(T value)
        {
            actionExecuted.Should().BeFalse();
            value.Should().Be(T.Value);

            actionExecuted = true;
            return Return.Failure<T, E>(E.Value2);
        }

        protected Func<bool> GetPredicate(bool value)
        {
            return () =>
            {
                predicateExecuted.Should().BeFalse();

                predicateExecuted = true;
                return value;
            };
        }

        protected Func<T, bool> GetValuePredicate(bool value)
        {
            return t =>
            {
                predicateExecuted.Should().BeFalse();
                t.Should().Be(T.Value);

                predicateExecuted = true;
                return value;
            };
        }

        protected static Return GetExpectedResult(bool isSuccess, bool condition, bool isSuccessAction)
        {
            var success = CheckSuccess(isSuccess, condition, isSuccessAction);
            var resultChanged = isSuccess && condition;

            return Return.SuccessIf(success, !resultChanged ? ErrorMessage : ErrorMessage2);
        }

        protected static Return<T> GetExpectedValueResult(bool isSuccess, bool condition, bool isSuccessAction)
        {
            var success = CheckSuccess(isSuccess, condition, isSuccessAction);
            var resultChanged = isSuccess && condition;

            if (!resultChanged)
            {
                return Return.SuccessIf(success, T.Value, ErrorMessage);
            }

            return Return.SuccessIf(success, T.Value2, ErrorMessage2);
        }

        protected static UnitResult<E> GetExpectedErrorResult(bool isSuccess, bool condition, bool isSuccessAction)
        {
            var success = CheckSuccess(isSuccess, condition, isSuccessAction);
            var resultChanged = isSuccess && condition;

            if (!resultChanged)
            {
                return UnitResult.SuccessIf(success, E.Value);
            }

            return UnitResult.SuccessIf(success, E.Value2);
        }

        protected static Return<T, E> GetExpectedValueErrorResult(bool isSuccess, bool condition, bool isSuccessAction)
        {
            var success = CheckSuccess(isSuccess, condition, isSuccessAction);
            var resultChanged = isSuccess && condition;

            if (!resultChanged)
            {
                return Return.SuccessIf(success, T.Value, E.Value);
            }

            return Return.SuccessIf(success, T.Value2, E.Value2);
        }

        protected static bool CheckSuccess(bool isSuccess, bool condition, bool isSuccessAction)
        {
            if (!condition)
            {
                return isSuccess;
            }

            return isSuccess && isSuccessAction;
        }
    }
}
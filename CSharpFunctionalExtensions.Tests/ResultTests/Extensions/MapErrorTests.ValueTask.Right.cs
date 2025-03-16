using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapErrorTests_ValueTask_Right : TestBase
    {
        private const string ContextMessage = "Context-specific error";

        [Fact]
        public async Task MapError_ValueTask_Right_returns_success()
        {
            Return result = Return.Success();
            var invocations = 0;

            Return actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_success_with_context()
        {
            Return result = Return.Success();
            var invocations = 0;

            Return actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_new_failure()
        {
            Return result = Return.Failure(ErrorMessage);
            var invocations = 0;

            Return actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_new_failure_with_context()
        {
            Return result = Return.Failure(ErrorMessage);
            var invocations = 0;

            Return actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_UnitResult_success()
        {
            Return result = Return.Success();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_UnitResult_success_with_context()
        {
            Return result = Return.Success();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_new_UnitResult_failure()
        {
            Return result = Return.Failure(ErrorMessage);
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_returns_new_UnitResult_failure_with_context()
        {
            Return result = Return.Failure(ErrorMessage);
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_returns_success()
        {
            Return<T> result = Return.Success(T.Value);
            var invocations = 0;

            Return<T> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_returns_success_with_context()
        {
            Return<T> result = Return.Success(T.Value);
            var invocations = 0;

            Return<T> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_returns_new_failure()
        {
            Return<T> result = Return.Failure<T>(ErrorMessage);
            var invocations = 0;

            Return<T> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_returns_new_failure_with_context()
        {
            Return<T> result = Return.Failure<T>(ErrorMessage);
            var invocations = 0;

            Return<T> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_UnitResult_returns_success()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            var invocations = 0;

            Return actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_UnitResult_returns_success_with_context()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            var invocations = 0;

            Return actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_UnitResult_returns_new_failure()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            var invocations = 0;

            Return actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_UnitResult_returns_new_failure_with_context()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            var invocations = 0;

            Return actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult("error");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_E_UnitResult_returns_success()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_E_UnitResult_returns_success_with_context()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_E_UnitResult_returns_new_failure()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_E_UnitResult_returns_new_failure_with_context()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_returns_success()
        {
            Return<T> result = Return.Success(T.Value);
            var invocations = 0;

            Return<T, E> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_returns_success_with_context()
        {
            Return<T> result = Return.Success(T.Value);
            var invocations = 0;

            Return<T, E> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_returns_new_failure()
        {
            Return<T> result = Return.Failure<T>(ErrorMessage);
            var invocations = 0;

            Return<T, E> actual = await result.MapError(error =>
            {
                error.Should().Be(ErrorMessage);
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_returns_new_failure_with_context()
        {
            Return<T> result = Return.Failure<T>(ErrorMessage);
            var invocations = 0;

            Return<T, E> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(ErrorMessage);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_string_returns_success()
        {
            Return<T, E> result = Return.Success<T, E>(T.Value);
            var invocations = 0;

            Return<T> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_string_returns_success_with_context()
        {
            Return<T, E> result = Return.Success<T, E>(T.Value);
            var invocations = 0;

            Return<T> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult("error");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_E2_returns_success()
        {
            Return<T, E> result = Return.Success<T, E>(T.Value);
            var invocations = 0;

            Return<T, E2> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_E2_returns_success_with_context()
        {
            Return<T, E> result = Return.Success<T, E>(T.Value);
            var invocations = 0;

            Return<T, E2> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_string_returns_new_failure()
        {
            Return<T, E> result = Return.Failure<T, E>(E.Value);
            var invocations = 0;

            Return<T> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_string_returns_new_failure_with_context()
        {
            Return<T, E> result = Return.Failure<T, E>(E.Value);
            var invocations = 0;

            Return<T> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult("error");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_E2_returns_new_failure()
        {
            Return<T, E> result = Return.Failure<T, E>(E.Value);
            var invocations = 0;

            Return<T, E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Right_T_E_E2_returns_new_failure_with_context()
        {
            Return<T, E> result = Return.Failure<T, E>(E.Value);
            var invocations = 0;

            Return<T, E2> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }
    }
}

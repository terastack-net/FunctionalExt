using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensateTests_ValueTask_Right : TestBase
    {
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(() => Return.Success().AsValueTask());

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_func_string_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(_ => Return.Success().AsValueTask());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(() => Return.Success(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(_ => Return.Success(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value);
            var newResult = await myResult.OnFailureCompensate(_ => Return.Success<T, E>(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value);
            var newResult = await myResult.OnFailureCompensate(() => Return.Success<T, E>(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}
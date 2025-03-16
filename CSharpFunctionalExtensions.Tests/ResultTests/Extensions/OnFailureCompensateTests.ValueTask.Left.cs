using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensateTests_ValueTask_Left : TestBase
    {
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(Return.Success);

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_func_string_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(_ => Return.Success());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Return.Success(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(_ => Return.Success(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(_ => Return.Success<T, E>(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Return.Success<T, E>(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}
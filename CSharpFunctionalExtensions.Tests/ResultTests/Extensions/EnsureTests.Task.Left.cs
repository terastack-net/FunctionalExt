using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureTests_Task_Left
    {
        [Fact]
        public async Task Ensure_Task_Left_with_errorPredicate_does_not_throw_when_given_result_failure()
        {
            var result = Task.FromResult(Return.Failure<string>("initial error message"));
            Func<Task> ensure = () => result.Ensure(
                x => x != "", 
                x =>"new error message: string should not be empty");
            
            await ensure.Should().NotThrowAsync<Exception>("passing in a Result.Failure is a valid use case");
        }
        
        [Fact]
        public async Task Ensure_Task_Left_with_errorPredicate_initial_result_has_failure_state()
        {
            var tResult = Task.FromResult(Return.Failure<string>("initial error message"));

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeFalse("Input Result.Failure should be returned");
            result.Error.Should().Be("initial error message");
        }

        [Fact]
        public async Task Ensure_Task_Left_with_errorPredicate_predicate_passes()
        {
            var tResult = Task.FromResult(Return.Success("initial ok"));

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeTrue("Input Result passes predicate condition");
            result.Value.Should().Be("initial ok");
        }

        [Fact]
        public async Task Ensure_Task_Left_with_errorPredicate_does_not_execute_error_predicate_when_predicate_passes()
        {
            var tResult = Task.FromResult(Return.Success<int?>(null));

            Return<int?> result = await tResult.Ensure(value => !value.HasValue, value => $"should be null but found {value.Value}");

            result.Should().Be(tResult.Result);
        }

        [Fact]
        public async Task Ensure_Task_Left_with_errorPredicate_using_errorPredicate()
        {
            var tResult = Task.FromResult(Return.Success(""));

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeFalse("Input Result fails predicate condition");
            result.Error.Should().Be("new error message: string should not be empty");
        }

        [Fact]
        public async Task Ensure_Task_Left_with_successInput_and_successPredicate()
        {
          var initialResult = Task.FromResult(Return.Success("Initial message"));

          var result = await initialResult.Ensure(() => Return.Success("Success message"));

          result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
          result.Value.Should().Be("Initial message");
        }

        [Fact]
        public async Task Ensure_Task_Left_with_successInput_and_failurePredicate()
        {
          var initialResult = Task.FromResult(Return.Success("Initial Result"));

          var result = await initialResult.Ensure(() => Return.Failure("Error message"));

          result.IsSuccess.Should().BeFalse("Predicate is failure result");
          result.Error.Should().Be("Error message");
        }
        
        [Fact]
        public async Task Ensure_Task_Left_with_failureInput_and_successPredicate()
        {
          var initialResult = Task.FromResult(Return.Failure("Initial Error message"));

          var result = await initialResult.Ensure(() => Return.Success("Success message"));

          result.IsSuccess.Should().BeFalse("Initial result is failure result");
          result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public async Task Ensure_Task_Left_with_failureInput_and_failurePredicate()
        {
          var initialResult = Task.FromResult(Return.Failure("Initial Error message"));

          var result = await initialResult.Ensure(() => Return.Failure("Error message"));

          result.IsSuccess.Should().BeFalse("Initial result is failure result");
          result.Error.Should().Be("Initial Error message");
        }
        
        [Fact]
        public async Task Ensure_Task_Left_with_successInput_and_parameterisedFailurePredicate()
        {
          var initialResult = Task.FromResult(Return.Success("Initial Success message"));

          var result = await initialResult.Ensure(_ => Return.Failure("Error Message"));

          result.IsSuccess.Should().BeFalse("Predicate is failure result");
          result.Error.Should().Be("Error Message");
        }
    
        [Fact]
        public async Task Ensure_Task_Left_with_successInput_and_parameterisedSuccessPredicate()
        {
          var initialResult = Task.FromResult(Return.Success("Initial Success message"));

          var result = await initialResult.Ensure(_ => Return.Success("Success Message"));

          result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");;
          result.Value.Should().Be("Initial Success message");
        }
    
        [Fact]
        public async Task Ensure_Task_Left_with_failureInput_and_parameterisedSuccessPredicate()
        {
          var initialResult = Task.FromResult(Return.Failure<string>("Initial Error message"));

          var result = await initialResult.Ensure(_ => Return.Success("Success Message"));

          result.IsSuccess.Should().BeFalse("Initial result is failure result");;
          result.Error.Should().Be("Initial Error message");
        }
    
        [Fact]
        public async Task Ensure_Task_Left_with_failureInput_and_parameterisedFailurePredicate()
        {
          var initialResult = Task.FromResult(Return.Failure<string>("Initial Error message"));

          var result = await initialResult.Ensure(_ => Return.Failure("Success Message"));

          result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");;
          result.Error.Should().Be("Initial Error message");
        }
    }
}
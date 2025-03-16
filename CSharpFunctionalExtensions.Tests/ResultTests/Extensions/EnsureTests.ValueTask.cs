using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
  public class Ensure_ValueTask_Tests
  {
    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_successPredicate()
    {
      var initialResult = Return.Success("Initial message").AsCompletedValueTask();

      var result = await initialResult.Ensure(() => Return.Success("Success message").AsCompletedValueTask());

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
      result.Value.Should().Be("Initial message");
    }

    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_failurePredicate()
    {
      var initialResult = Return.Success("Initial Result").AsCompletedValueTask();

      var result = await initialResult.Ensure(() => Return.Failure("Error message").AsCompletedValueTask());

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_successPredicate()
    {
      var initialResult = Return.Failure("Initial Error message").AsCompletedValueTask();

      var result = await initialResult.Ensure(() => Return.Success("Success message").AsCompletedValueTask());

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }

    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_failurePredicate()
    {
      var initialResult = Return.Failure("Initial Error message").AsCompletedValueTask();

      var result = await initialResult.Ensure(() => Return.Failure("Error message").AsCompletedValueTask());

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_parameterisedFailurePredicate()
    {
      var initialResult = Return.Success("Initial Success message").AsCompletedValueTask();

      var result = await initialResult.Ensure(_ => Return.Failure("Error Message").AsCompletedValueTask());

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error Message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_parameterisedSuccessPredicate()
    {
      var initialResult = Return.Success("Initial Success message").AsCompletedValueTask();

      var result = await initialResult.Ensure(_ => Return.Success("Success Message").AsCompletedValueTask());

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");;
      result.Value.Should().Be("Initial Success message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_parameterisedSuccessPredicate()
    {
      var initialResult = Return.Failure<string>("Initial Error message").AsCompletedValueTask();

      var result = await initialResult.Ensure(_ => Return.Success("Success Message").AsCompletedValueTask());

      result.IsSuccess.Should().BeFalse("Initial result is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_parameterisedFailurePredicate()
    {
      var initialResult = Return.Failure<string>("Initial Error message").AsCompletedValueTask();

      var result = await initialResult.Ensure(_ => Return.Failure("Success Message").AsCompletedValueTask());

      result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
  }
}
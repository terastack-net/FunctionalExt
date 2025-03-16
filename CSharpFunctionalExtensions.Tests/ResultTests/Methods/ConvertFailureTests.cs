using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ConvertFailureTests : TestBase
    {
        [Fact]
        public void Can_not_convert_okResult_without_value_to_okResult_with_value()
        {
            var okResultWithoutValue = Return.Success();

            Action action = () => okResultWithoutValue.ConvertFailure<T>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_without_value_to_failedResult_with_value()
        {
            var failedResultWithoutValue = Return.Failure("Failed");

            Return<T> failedResultWithValue = failedResultWithoutValue.ConvertFailure<T>();

            failedResultWithValue.IsFailure.Should().BeTrue();
            failedResultWithValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_without_value()
        {
            var okResultWithValue = Return.Success(T.Value);

            Action action = () => okResultWithValue.ConvertFailure();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Return.Failure<T>(ErrorMessage);

            Return failedResultWithoutValue = failedResultWithValue;

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_with_otherValue()
        {
            var okResultWithValue = Return.Success(T.Value);

            Action action = () => okResultWithValue.ConvertFailure<K>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_with_other_value()
        {
            var failedResultWithValue = Return.Failure<T>(ErrorMessage);

            Return<K> failedResultWithOtherValue = failedResultWithValue.ConvertFailure<K>();

            failedResultWithOtherValue.IsFailure.Should().BeTrue();
            failedResultWithOtherValue.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void ErrorClass_Can_not_convert_okResult_with_value_to_okResult_with_value()
        {
            var okResultWithValue = Return.Success<T, E>(T.Value);

            Action action = () => okResultWithValue.ConvertFailure<K>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ErrorClass_Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Return.Failure<T, E>(E.Value);

            Return<K, E> failedResultWithoutValue = failedResultWithValue.ConvertFailure<K>();

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().BeEquivalentTo(E.Value);
        }

        [Fact]
        public void UnitResult_can_not_convert_okResult_with_value_to_okResult_with_value()
        {
            var okResultWithValue = UnitResult.Success<E>();

            Action action = () => okResultWithValue.ConvertFailure<K>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void UnitResult_can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = UnitResult.Failure(E.Value);

            Return<K, E> failedResultWithoutValue = failedResultWithValue.ConvertFailure<K>();

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().BeEquivalentTo(E.Value);
        }
    }
}

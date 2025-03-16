using FluentAssertions;
using System;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class SucceededResultTests
    {
        [Fact]
        public void Can_create_a_non_generic_version()
        {
            Return result = Return.Success();

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            var myClass = new MyClass();

            Return<MyClass> result = Return.Success(myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        [Fact]
        public void Can_create_a_UnitResult()
        {
            UnitResult<MyErrorClass> result = Return.Success<MyErrorClass>();

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_UnitResult_using_UnitResult_entry_point()
        {
            UnitResult<MyErrorClass> result = UnitResult.Success<MyErrorClass>();

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version_with_a_generic_error()
        {
            Can_create_a_generic_version_with_a_generic_error_typed<MyErrorClass>();
            Can_create_a_generic_version_with_a_generic_error_typed<MyErrorStruct>();
        }

        [Fact]
        public void Can_create_without_Value()
        {
            Return<MyClass> result = Return.Success((MyClass)null);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeNull();
        }

        [Fact]
        public void Cannot_access_Error_non_generic_version()
        {
            Return result = Return.Success();

            Action action = () =>
            {
                string error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_generic_version()
        {
            Return<MyClass> result = Return.Success(new MyClass());

            Action action = () =>
            {
                string error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_generic_error_version()
        {
            Return<MyClass, MyErrorClass> result = Return.Success<MyClass, MyErrorClass>(new MyClass());

            Action action = () =>
            {
                MyErrorClass error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_UnitResult_version()
        {
            UnitResult<MyErrorClass> result = Return.Success<MyErrorClass>();

            Action action = () =>
            {
                MyErrorClass error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        private void Can_create_a_generic_version_with_a_generic_error_typed<E>()
        {
            var myClass = new MyClass();

            Return<MyClass, E> result = Return.Success<MyClass, E>(myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        private class MyClass
        {
        }

        private class MyErrorClass
        {
        }

        private struct MyErrorStruct
        {
        }
    }
}

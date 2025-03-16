using FluentAssertions;
using System.Runtime.Serialization;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class SerializationTests
    {
        private static readonly string _errorMessage = "this failed";

        [Fact]
        public void GetObjectData_sets_correct_statuses_on_success_result()
        {
            Return okResult = Return.Success();
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetBoolean(nameof(Return.IsSuccess)).Should().BeTrue();
            serializationInfo.GetBoolean(nameof(Return.IsFailure)).Should().BeFalse();
        }

        [Fact]
        public void GetObjectData_sets_correct_statuses_on_failure_result()
        {
            Return failResult = Return.Failure(_errorMessage);
            ISerializable serializableObject = failResult;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetBoolean(nameof(Return.IsSuccess)).Should().BeFalse();
            serializationInfo.GetBoolean(nameof(Return.IsFailure)).Should().BeTrue();
        }

        [Fact]
        public void GetObjectData_adds_message_in_context_on_failure_result()
        {
            Return failResult = Return.Failure(_errorMessage);
            ISerializable serializableObject = failResult;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetString(nameof(Return.Error)).Should().Be(_errorMessage);
        }

        [Fact]
        public void GetObjectData_of_generic_result_adds_object_in_context_when_success_result()
        {
            TestObject language = new TestObject { Number = 232, String = "C#" };
            Return<TestObject> okResult = Return.Success(language);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetValue(nameof(Return<TestObject>.Value), typeof(TestObject))
                .Should().Be(language);
        }

        [Fact]
        public void GetObjectData_adds_error_object_in_serialization_context_when_failure_result()
        {
            TestObject errorObject = new TestObject { Number = 500, String = "Error message" };
            Return<object, TestObject> failResult = Return.Failure<object, TestObject>(errorObject);
            ISerializable serializableObject = failResult;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo
                .GetValue(nameof(Return<object, TestObject>.Error), typeof(TestObject))
                .Should().Be(errorObject);
        }

        [Fact]
        public void GetObjectData_of_successful_UnitResult()
        {
            UnitResult<TestObject> result = UnitResult.Success<TestObject>();
            ISerializable serializableObject = result;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetBoolean(nameof(Return.IsSuccess)).Should().BeTrue();
            serializationInfo.GetBoolean(nameof(Return.IsFailure)).Should().BeFalse();
        }

        [Fact]
        public void GetObjectData_of_failed_UnitResult()
        {
            TestObject errorObject = new TestObject { Number = 500, String = "Error message" };
            UnitResult<TestObject> result = UnitResult.Failure(errorObject);
            ISerializable serializableObject = result;

            var serializationInfo = new SerializationInfo(typeof(Return), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetBoolean(nameof(Return.IsSuccess)).Should().BeFalse();
            serializationInfo.GetBoolean(nameof(Return.IsFailure)).Should().BeTrue();
            serializationInfo
                .GetValue(nameof(Return<object, TestObject>.Error), typeof(TestObject))
                .Should().Be(errorObject);
        }

        private class TestObject
        {
            public string String { get; set; }
            public int Number { get; set; }
        }
    }
}

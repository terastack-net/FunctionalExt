#nullable enable

using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureNotNullTests : EnsureNotNullTests_Base
    {
        [Fact]
        public void EnsureNotNull_T_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?> result = Return.Failure<T?>(ErrorMessage);

            Return<T> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void EnsureNotNull_V_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?> result = Return.Failure<V?>(ErrorMessage);

            Return<V> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void EnsureNotNull_T_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?> result = Return.Success<T?>(T.Value);

            Return<T> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
        }

        [Fact]
        public void EnsureNotNull_V_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?> result = Return.Success<V?>(V.Value);

            Return<V> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
        }

        [Fact]
        public void EnsureNotNull_T_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?> result = Return.Success<T?>(null);

            Return<T> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
        }

        [Fact]
        public void EnsureNotNull_V_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?> result = Return.Success<V?>(null);

            Return<V> returned = result.EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
        }

        [Fact]
        public void EnsureNotNull_T_factory_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?> result = Return.Failure<T?>(ErrorMessage);

            Return<T> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_factory_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?> result = Return.Failure<V?>(ErrorMessage);

            Return<V> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_factory_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?> result = Return.Success<T?>(T.Value);

            Return<T> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_factory_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?> result = Return.Success<V?>(V.Value);

            Return<V> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_factory_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?> result = Return.Success<T?>(null);

            Return<T> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public void EnsureNotNull_V_factory_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?> result = Return.Success<V?>(null);

            Return<V> returned = result.EnsureNotNull(GetErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public void EnsureNotNull_T_E_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?, E> result = Return.Failure<T?, E>(E.Value);

            Return<T, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
        }

        [Fact]
        public void EnsureNotNull_V_E_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?, E> result = Return.Failure<V?, E>(E.Value);

            Return<V, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
        }

        [Fact]
        public void EnsureNotNull_T_E_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(T.Value);

            Return<T, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
        }

        [Fact]
        public void EnsureNotNull_V_E_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(V.Value);

            Return<V, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
        }

        [Fact]
        public void EnsureNotNull_T_E_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(null);

            Return<T, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
        }

        [Fact]
        public void EnsureNotNull_V_E_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(null);

            Return<V, E> returned = result.EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
        }

        [Fact]
        public void EnsureNotNull_T_E_factory_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?, E> result = Return.Failure<T?, E>(E.Value);

            Return<T, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_E_factory_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?, E> result = Return.Failure<V?, E>(E.Value);

            Return<V, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_E_factory_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(T.Value);

            Return<T, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_V_E_factory_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(V.Value);

            Return<V, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public void EnsureNotNull_T_E_factory_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(null);

            Return<T, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public void EnsureNotNull_V_E_factory_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(null);

            Return<V, E> returned = result.EnsureNotNull(GetErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
            factoryExecuted.Should().BeTrue();
        }
    }
}

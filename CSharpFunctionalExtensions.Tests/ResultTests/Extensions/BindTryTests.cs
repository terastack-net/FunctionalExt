using FluentAssertions;
using Xunit;
using System;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public sealed class BindTryTests : BindTryTestsBase
    {
        #region BindTry for Result with function returning Result
        [Fact]
        public void BindTry_execute_func_returning_success_on_success_returns_success()
        {
            Return sut = Return.Success();

            Return result = sut.BindTry(Success);

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_success_on_failure_returns_self()
        {
            Return sut = Return.Failure(new Exception(ErrorMessage));

            Return result = sut.BindTry(Success);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_failure_on_success_returns_failure()
        {
            Return sut = Return.Success();

            Return result = sut.BindTry(Failure);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_on_success_returns_failure_with_exception_message()
        {
            Return sut = Return.Success();

            Return result = sut.BindTry(Throwing);

            AssertFailure(result);
        }


        [Fact]
        public void BindTry_execute_throwing_func_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Return sut = Return.Success();

            Return result = sut.BindTry(Throwing, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result with function returning Result<K>
        [Fact]
        public void BindTry_execute_func_K_returning_success_on_success_returns_success()
        {
            Return sut = Return.Success();

            Return<K> result = sut.BindTry(Success_K);

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_K_returning_success_on_failure_returns_self()
        {
            Return sut = Return.Failure(ErrorMessage);

            Return<K> result = sut.BindTry(Success_K);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_K_returning_failure_on_success_returns_failure()
        {
            Return sut = Return.Success();

            Return<K> result = sut.BindTry(Failure_K);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_K_on_success_returns_failure_with_exception_message()
        {
            Return sut = Return.Success();

            Return<K> result = sut.BindTry(Throwing_K);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Return sut = Return.Success();

            Return<K> result = sut.BindTry(Throwing_K, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Result
        [Fact]
        public void BindTry_execute_func_returning_success_on_success_T_returns_success()
        {
            Return<T> sut = Return.Success(T.Value);

            Return result = sut.BindTry(t => Success());

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_success_on_failure_T_returns_self()
        {
            Return<T> sut = Return.Failure<T>(ErrorMessage);

            Return result = sut.BindTry(t => Success());

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_failure_on_success_T_returns_failure()
        {
            Return<T> sut = Return.Success(T.Value);

            Return result = sut.BindTry(t => Failure());

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_on_success_T_returns_failure_with_exception_message()
        {
            Return<T> sut = Return.Success(T.Value);

            Return result = sut.BindTry(t => Throwing());

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Return<T> sut = Return.Success(T.Value);

            Return result = sut.BindTry(t => Throwing(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Result<K>
        [Fact]
        public void BindTry_execute_func_T_K_returning_success_on_success_T_returns_success_K()
        {
            Return<T> sut = Return.Success(T.Value);

            Return<K> result = sut.BindTry(t => Success_K());

            AssertSuccess(result);            
        }
        [Fact]
        public void BindTry_execute_func_T_K_returning_success_on_failure_T_returns_failure_K()
        {
            Return<T> sut = Return.Failure<T>(ErrorMessage);

            Return<K> result = sut.BindTry(t => Success_K());

            AssertFailure(result);
            result.Should().BeOfType<Return<K>>();
        }
        [Fact]
        public void BindTry_execute_func_K_returning_failure_K_on_success_returns_failure_K()
        {
            Return<T> sut = Return.Success(T.Value);

            Return<K> result = sut.BindTry(t => Failure_K());

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_K_on_success_T_returns_failure_K_with_exception_message()
        {
            Return<T> sut = Return.Success(T.Value);

            Return<K> result = sut.BindTry(t => Throwing_K());

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_T_K_on_success_T_with_custom_error_handler_returns_failure_K_with_custom_message()
        {
            Return sut = Return.Success();

            Return<K> result = sut.BindTry(() => Throwing_K(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T,E> with function returning Result<K,E>
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_success_on_success_T_E_returns_success_K_E()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            Return<K, E> result = sut.BindTry(Success_T_E_Func_K, e => E.Value);

            AssertSuccess(result);
            result.Should().BeOfType<Return<K, E>>();
        }
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_success_on_failure_T_E_returns_failure_K_E()
        {
            Return<T, E> sut = Return.Failure<T, E>(E.Value);

            Return<K, E> result = sut.BindTry(Success_T_E_Func_K, e => E.Value);

            AssertFailure(result);
            result.Should().BeOfType<Return<K, E>>();
        }
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_failure_on_success_T_E_returns_failure_K_E()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);
            System.Func<T, Return<K, E>> func = Return<K, E> (T _) => Return.Failure<K, E>(E.Value);

            Return<K, E> result = sut.BindTry(func, e => E.Value2);

            AssertFailure(result);
            result.Should().BeOfType<Return<K, E>>();
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_K_E_on_success_T_E_returns_failure_K_E_with_value_from_error_handler()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            Return<K, E> result = sut.BindTry(t => Throwing_K_E(), e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value2);
            result.Should().BeOfType<Return<K, E>>();
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning UnitResult<E>
        [Fact]
        public void BindTry_execute_func_E_returning_unitresult_success_on_success_E_returns_success_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = sut.BindTry(UnitResult_Success_E, e => E.Value2);

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_failure_E_returns_failure_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            UnitResult<E> result = sut.BindTry(UnitResult_Success_E, e => E.Value2);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_E_returning_failure_on_success_E_returns_failure_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = sut.BindTry(UnitResult_Failure_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_E_on_success_E_returns_failure_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = sut.BindTry(Throwing_K_E, e => E.Value2);

            AssertFailure(result, E.Value2);            
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning Result<T,E>
        [Fact]
        public void BindTry_execute_func_T_E_returning_success_on_success_E_returns_success_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Return<T, E> result = sut.BindTry(Success_T_E, e => E.Value2);

            AssertSuccess(result);            
        }
        [Fact]
        public void BindTry_execute_func_T_E_returning_success_on_failure_E_returns_failure_T_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            Return<T, E> result = sut.BindTry(Success_T_E, e => E.Value2);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_T_E_returning_failure_on_success_E_returns_failure_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Return<T, E> result = sut.BindTry(Failure_T_E, e => E.Value2);

            AssertFailure(result);            
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_E_on_success_E_returns_failure_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Return<T, E> result = sut.BindTry(Throwing_T_E, e => E.Value2);

            AssertFailure(result, E.Value2);            
        }
        #endregion

        #region BindTry for Result<T,E> with function returning UnitResult<E>
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_success_T_E_returns_success_E()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            UnitResult<E> result = sut.BindTry(UnitResult_E_T, e => E.Value2);

            AssertSuccess(result);            
        }
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_failure_T_E_returns_failure_E()
        {
            Return<T, E> sut = Return.Failure<T, E>(E.Value);            

            UnitResult<E> result = sut.BindTry(UnitResult_E_T, e => E.Value2);

            AssertFailure(result);            
        }
        [Fact]
        public void BindTry_execute_func_E_returning_failure_on_success_T_E_returns_failure_E()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            UnitResult<E> result = sut.BindTry(t=> UnitResult_Failure_E(), e => E.Value2);

            AssertFailure(result);            
        }

        [Fact]
        public void BindTry_execute_throwing_func_E_on_success_T_E_returns_failure_E_with_value_from_error_handler()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            UnitResult<E> result = sut.BindTry(t => Throwing_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

    }
}

using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Return> Compensate(this Return result, Func<Exception, Task<Return>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitResult<E>> Compensate<E>(this Return result, Func<Exception, Task<UnitResult<E>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Return> Compensate<T>(this Return<T> result, Func<Exception, Task<Return>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Return<T>> Compensate<T>(this Return<T> result, Func<Exception, Task<Return<T>>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value).AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Return<T, E>> Compensate<T, E>(this Return<T> result, Func<Exception, Task<Return<T, E>>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value).AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Return> Compensate<E>(this UnitResult<E> result, Func<E, Task<Return>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitResult<E2>> Compensate<E, E2>(this UnitResult<E> result, Func<E, Task<UnitResult<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Return> Compensate<T, E>(this Return<T, E> result, Func<E, Task<Return>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitResult<E2>> Compensate<T, E, E2>(this Return<T, E> result, Func<E, Task<UnitResult<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Return<T, E2>> Compensate<T, E, E2>(this Return<T, E> result, Func<E, Task<Return<T, E2>>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value).AsCompletedTask();
            }

            return func(result.Error);
        }
    }
}
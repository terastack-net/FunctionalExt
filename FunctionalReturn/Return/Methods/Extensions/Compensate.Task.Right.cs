using System;
using System.Threading.Tasks;

namespace FunctionalReturn
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

        public static Task<UnitReturn<E>> Compensate<E>(this Return result, Func<Exception, Task<UnitReturn<E>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>().AsCompletedTask();
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

        public static Task<Return> Compensate<E>(this UnitReturn<E> result, Func<E, Task<Return>> func)
        {
            if (result.IsSuccess)
            {
                return Return.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitReturn<E2>> Compensate<E, E2>(this UnitReturn<E> result, Func<E, Task<UnitReturn<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>().AsCompletedTask();
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

        public static Task<UnitReturn<E2>> Compensate<T, E, E2>(this Return<T, E> result, Func<E, Task<UnitReturn<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>().AsCompletedTask();
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
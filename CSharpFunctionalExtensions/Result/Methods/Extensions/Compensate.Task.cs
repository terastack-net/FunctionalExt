using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<Return> Compensate(this Task<Return> resultTask, Func<Exception, Task<Return>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<UnitResult<E>> Compensate<E>(this Task<Return> resultTask, Func<Exception, Task<UnitResult<E>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<Return> Compensate<T>(this Task<Return<T>> resultTask, Func<Exception, Task<Return>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<Return<T>> Compensate<T>(this Task<Return<T>> resultTask, Func<Exception, Task<Return<T>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<Return<T, E>> Compensate<T, E>(this Task<Return<T>> resultTask, Func<Exception, Task<Return<T, E>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<Return> Compensate<E>(this Task<UnitResult<E>> resultTask, Func<E, Task<Return>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<UnitResult<E2>> Compensate<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, Task<UnitResult<E2>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<Return> Compensate<T, E>(this Task<Return<T, E>> resultTask, Func<E, Task<Return>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<UnitResult<E2>> Compensate<T, E, E2>(this Task<Return<T, E>> resultTask, Func<E, Task<UnitResult<E2>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }

        public static async Task<Return<T, E2>> Compensate<T, E, E2>(this Task<Return<T, E>> resultTask, Func<E, Task<Return<T, E2>>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.Compensate(func).DefaultAwait();
        }
    }
}

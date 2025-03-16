using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Bind<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, Task<Return<K, E>>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Bind<T, K>(this Task<Return<T>> resultTask, Func<T, Task<Return<K>>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Bind<K>(this Task<Return> resultTask, Func<Task<Return<K>>> func)
        {
            Return result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return> Bind<T>(this Task<Return<T>> resultTask, Func<T, Task<Return>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return> Bind(this Task<Return> resultTask, Func<Task<Return>> func)
        {
            Return result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitResult<E>> Bind<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<T, E>> Bind<T, E>(this Task<UnitResult<E>> resultTask, Func<Task<Return<T, E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitResult<E>> Bind<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }
    }
}
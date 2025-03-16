using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<T> Finally<T>(this Task<Return> resultTask, Func<Return, Task<T>> func)
        {
            Return result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K>(this Task<Return<T>> resultTask, Func<Return<T>, Task<K>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<K, E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>, Task<K>> func) 
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K, E>(this Task<Return<T, E>> resultTask,
            Func<Return<T, E>, Task<K>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }
    }
}

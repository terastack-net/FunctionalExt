using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<T> Finally<T>(this Task<Return> resultTask, Func<Return, T> func)
        {
            Return result = await resultTask.DefaultAwait();
            return result.Finally(func);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K>(this Task<Return<T>> resultTask, Func<Return<T>, K> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Finally(func);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<K, E>(this Task<UnitReturn<E>> resultTask, Func<UnitReturn<E>, K> func)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.Finally(func);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K, E>(this Task<Return<T, E>> resultTask,
            Func<Return<T, E>, K> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Finally(func);
        }
    }
}

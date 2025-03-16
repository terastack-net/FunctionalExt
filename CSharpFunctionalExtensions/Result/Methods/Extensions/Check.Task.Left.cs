using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Return<T>> Check<T>(this Task<Return<T>> resultTask, Func<T, Return> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Return<T>> Check<T, K>(this Task<Return<T>> resultTask, Func<T, Return<K>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Return<T, E>> Check<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, Return<K, E>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Return<T, E>> Check<T, E>(this Task<Return<T, E>> resultTask, Func<T, UnitReturn<E>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<UnitReturn<E>> Check<E>(this Task<UnitReturn<E>> resultTask, Func<UnitReturn<E>> func)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }
    }
}
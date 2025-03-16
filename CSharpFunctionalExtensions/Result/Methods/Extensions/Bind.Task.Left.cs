using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Bind<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, Return<K, E>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Bind<T, K>(this Task<Return<T>> resultTask, Func<T, Return<K>> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Bind<K>(this Task<Return> resultTask, Func<Return<K>> func)
        {
            Return result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return> Bind<T>(this Task<Return<T>> resultTask, Func<T, Return> func)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return> Bind(this Task<Return> resultTask, Func<Return> func)
        {
            Return result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitReturn<E>> Bind<E>(this Task<UnitReturn<E>> resultTask, Func<UnitReturn<E>> func)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<T, E>> Bind<T, E>(this Task<UnitReturn<E>> resultTask, Func<Return<T, E>> func)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitReturn<E>> Bind<T, E>(this Task<Return<T, E>> resultTask, Func<T, UnitReturn<E>> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }
    }
}
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<T, K, E>(
            this Task<Return<T, E>> resultTask,
            Func<T, K> func
        )
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<T, K, E, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<K, E>(
            this Task<UnitResult<E>> resultTask,
            Func<K> func
        )
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<K, E, TContext>(
            this Task<UnitResult<E>> resultTask,
            Func<TContext, K> func,
            TContext context
        )
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K>(
            this Task<Return<T>> resultTask,
            Func<T, K> func
        )
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K, TContext>(
            this Task<Return<T>> resultTask,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<K>(this Task<Return> resultTask, Func<K> func)
        {
            Return result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<K, TContext>(
            this Task<Return> resultTask,
            Func<TContext, K> func,
            TContext context
        )
        {
            Return result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }
    }
}

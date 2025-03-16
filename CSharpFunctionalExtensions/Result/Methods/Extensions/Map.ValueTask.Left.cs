#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<T, K, E>(
            this ValueTask<Return<T, E>> resultTask,
            Func<T, K> valueTask
        )
        {
            Return<T, E> result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<T, K, E, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<T, TContext, K> valueTask,
            TContext context
        )
        {
            Return<T, E> result = await resultTask;
            return result.Map(valueTask, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<K, E>(
            this ValueTask<UnitResult<E>> resultTask,
            Func<K> valueTask
        )
        {
            UnitResult<E> result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<K, E, TContext>(
            this ValueTask<UnitResult<E>> resultTask,
            Func<TContext, K> valueTask,
            TContext context
        )
        {
            UnitResult<E> result = await resultTask;
            return result.Map(valueTask, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K>(
            this ValueTask<Return<T>> resultTask,
            Func<T, K> valueTask
        )
        {
            Return<T> result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<T, TContext, K> valueTask,
            TContext context
        )
        {
            Return<T> result = await resultTask;
            return result.Map(valueTask, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<K>(
            this ValueTask<Return> resultTask,
            Func<K> valueTask
        )
        {
            Return result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<K, TContext>(
            this ValueTask<Return> resultTask,
            Func<TContext, K> valueTask,
            TContext context
        )
        {
            Return result = await resultTask;
            return result.Map(valueTask, context);
        }
    }
}
#endif

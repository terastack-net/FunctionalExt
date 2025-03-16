#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<T, K, E>(
            this ValueTask<Return<T, E>> resultTask,
            Func<T, ValueTask<K>> valueTask
        )
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value);

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<T, K, E, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value, context);

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<K, E>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<ValueTask<K>> valueTask
        )
        {
            UnitReturn<E> result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<K, E, TContext>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            UnitReturn<E> result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask(context);

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K>(
            this ValueTask<Return<T>> resultTask,
            Func<T, ValueTask<K>> valueTask
        )
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask(result.Value);

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask(result.Value, context);

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<K>(
            this ValueTask<Return> resultTask,
            Func<ValueTask<K>> valueTask
        )
        {
            Return result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<K, TContext>(
            this ValueTask<Return> resultTask,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Return result = await resultTask;

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask(context);

            return Return.Success(value);
        }
    }
}
#endif

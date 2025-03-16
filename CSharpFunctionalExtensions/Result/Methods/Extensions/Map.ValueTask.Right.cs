#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<T, K, E>(
            this Return<T, E> result,
            Func<T, ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value);

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<T, K, E, TContext>(
            this Return<T, E> result,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value, context);

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<K, E>(
            this UnitReturn<E> result,
            Func<ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Map<K, E, TContext>(
            this UnitReturn<E> result,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await valueTask(context);

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K>(
            this Return<T> result,
            Func<T, ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask(result.Value);

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K, TContext>(
            this Return<T> result,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask(result.Value, context);

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K>(
            this Return<T> result,
            Func<T, ValueTask<Return<K>>> valueTask
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            Return<K> value = await valueTask(result.Value);
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<T, K, TContext>(
            this Return<T> result,
            Func<T, TContext, ValueTask<Return<K>>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            Return<K> value = await valueTask(result.Value, context);
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<K>(
            this Return result,
            Func<ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Map<K, TContext>(
            this Return result,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await valueTask(context);

            return Return.Success(value);
        }
    }
}
#endif

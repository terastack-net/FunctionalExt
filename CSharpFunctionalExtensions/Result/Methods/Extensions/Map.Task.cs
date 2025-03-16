using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<T, K, E>(
            this Task<Return<T, E>> resultTask,
            Func<T, Task<K>> func
        )
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func(result.Value).DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<T, K, E, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<T, TContext, Task<K>> func,
            TContext context
        )
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func(result.Value, context).DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<K, E>(
            this Task<UnitResult<E>> resultTask,
            Func<Task<K>> func
        )
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func().DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<K, E, TContext>(
            this Task<UnitResult<E>> resultTask,
            Func<TContext, Task<K>> func,
            TContext context
        )
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func(context).DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K>(
            this Task<Return<T>> resultTask,
            Func<T, Task<K>> func
        )
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func(result.Value).DefaultAwait();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K, TContext>(
            this Task<Return<T>> resultTask,
            Func<T, TContext, Task<K>> func,
            TContext context
        )
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func(result.Value, context).DefaultAwait();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<K>(this Task<Return> resultTask, Func<Task<K>> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func().DefaultAwait();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<K, TContext>(
            this Task<Return> resultTask,
            Func<TContext, Task<K>> func,
            TContext context
        )
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func(context).DefaultAwait();

            return Return.Success(value);
        }
    }
}

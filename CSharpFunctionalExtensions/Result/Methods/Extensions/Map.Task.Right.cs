using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<T, K, E>(
            this Return<T, E> result,
            Func<T, Task<K>> func
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func(result.Value).DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<T, K, E, TContext>(
            this Return<T, E> result,
            Func<T, TContext, Task<K>> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func(result.Value, context).DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<K, E>(
            this UnitResult<E> result,
            Func<Task<K>> func
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func().DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K, E>> Map<K, E, TContext>(
            this UnitResult<E> result,
            Func<TContext, Task<K>> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            K value = await func(context).DefaultAwait();

            return Return.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K>(this Return<T> result, Func<T, Task<K>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func(result.Value).DefaultAwait();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K, TContext>(
            this Return<T> result,
            Func<T, TContext, Task<K>> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func(result.Value, context).DefaultAwait();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K>(
            this Return<T> result,
            Func<T, Task<Return<K>>> func
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            Return<K> value = await func(result.Value).DefaultAwait();
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<T, K, TContext>(
            this Return<T> result,
            Func<T, TContext, Task<Return<K>>> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            Return<K> value = await func(result.Value, context).DefaultAwait();
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<K>(this Return result, Func<Task<K>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func().DefaultAwait();

            return Return.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Return<K>> Map<K, TContext>(
            this Return result,
            Func<TContext, Task<K>> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            K value = await func(context).DefaultAwait();

            return Return.Success(value);
        }
    }
}

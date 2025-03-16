using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K, E> Map<T, K, E>(this Return<T, E> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            return Return.Success<K, E>(func(result.Value));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K, E> Map<T, K, E, TContext>(
            this Return<T, E> result,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            return Return.Success<K, E>(func(result.Value, context));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K, E> Map<K, E>(this UnitResult<E> result, Func<K> func)
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            return Return.Success<K, E>(func());
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K, E> Map<K, E, TContext>(
            this UnitResult<E> result,
            Func<TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error);

            return Return.Success<K, E>(func(context));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K> Map<T, K>(this Return<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            return Return.Success(func(result.Value));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K> Map<T, K, TContext>(
            this Return<T> result,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            return Return.Success(func(result.Value, context));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K> Map<K>(this Return result, Func<K> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            return Return.Success(func());
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Return<K> Map<K, TContext>(
            this Return result,
            Func<TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error);

            return Return.Success(func(context));
        }
    }
}

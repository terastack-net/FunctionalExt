using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static Return<K, E> MapTry<T, K, E>(this Return<T, E> result, Func<T, K> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : Return.Try(() => func(result.Value), errorHandler);  
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static Return<K, E> MapTry<K, E>(this UnitReturn<E> result, Func<K> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : Return.Try(() => func(), errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static Return<K> MapTry<T, K>(this Return<T> result, Func<T, K> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : Return.Try(() => func(result.Value), errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static Return<K> MapTry<K>(this Return result, Func<K> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : Return.Try(() => func(), errorHandler);
        }
    }
}

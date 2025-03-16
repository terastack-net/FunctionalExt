using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K, E>> MapTry<T, K, E>(this Return<T, E> result, Func<T, Task<K>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : await Return.Try(() => func(result.Value), errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K, E>> MapTry<K, E>(this UnitResult<E> result, Func<Task<K>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : await Return.Try(() => func(), errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K>> MapTry<T, K>(this Return<T> result, Func<T, Task<K>> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : await Return.Try(() => func(result.Value), errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K>> MapTry<K>(this Return result, Func<Task<K>> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : await Return.Try(() => func(), errorHandler).DefaultAwait();
        }
    }
}

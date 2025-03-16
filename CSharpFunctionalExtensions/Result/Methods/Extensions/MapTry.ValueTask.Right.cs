#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K, E>> MapTry<T, K, E>(this Return<T, E> result, Func<T, ValueTask<K>> valueTask,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : await Return.Try(async () => await valueTask(result.Value), errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K, E>> MapTry<K, E>(this UnitReturn<E> result, Func<ValueTask<K>> valueTask,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : await Return.Try(async () => await valueTask(), errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K>> MapTry<T, K>(this Return<T> result, Func<T, ValueTask<K>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : await Return.Try(async () => await valueTask(result.Value), errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K>> MapTry<K>(this Return result, Func<ValueTask<K>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : await Return.Try(async () => await valueTask(), errorHandler).DefaultAwait();
        }
    }
}
#endif

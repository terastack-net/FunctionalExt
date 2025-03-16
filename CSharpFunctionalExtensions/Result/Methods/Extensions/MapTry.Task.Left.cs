using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K, E>> MapTry<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, K> func,
            Func<Exception, E> errorHandler)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K, E>> MapTry<K, E>(this Task<UnitResult<E>> resultTask, Func<K> func,
            Func<Exception, E> errorHandler)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K>> MapTry<T, K>(this Task<Return<T>> resultTask, Func<T, K> func,
            Func<Exception, Exception> errorHandler = null)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Return<K>> MapTry<K>(this Task<Return> resultTask, Func<K> func,
            Func<Exception, Exception> errorHandler = null)
        {
            Return result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }
    }
}

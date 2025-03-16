#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K, E>> MapTry<T, K, E>(this ValueTask<Return<T, E>> resultTask, Func<T, K> valueTask,
            Func<Exception, E> errorHandler)
        {
            Return<T, E> result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K, E>> MapTry<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> valueTask,
            Func<Exception, E> errorHandler)
        {
            UnitResult<E> result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K>> MapTry<T, K>(this ValueTask<Return<T>> resultTask, Func<T, K> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            Return<T> result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Return<K>> MapTry<K>(this ValueTask<Return> resultTask, Func<K> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            Return result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }
    }
}
#endif
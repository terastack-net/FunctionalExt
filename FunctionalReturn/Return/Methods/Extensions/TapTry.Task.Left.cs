using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapTry(this Task<Return> resultTask, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapTry<T>(this Task<Return<T>> resultTask, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapTry<T>(this Task<Return<T>> resultTask, Action<T> action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitReturn<E>> TapTry<E>(this Task<UnitReturn<E>> resultTask, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapTry<T, E>(this Task<Return<T, E>> resultTask, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapTry<T, E>(this Task<Return<T, E>> resultTask, Action<T> action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action, errorHandler);
        }
    }
}

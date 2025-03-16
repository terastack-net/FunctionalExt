using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return> TapIfTry(this Task<Return> resultTask, bool condition, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(condition, action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, bool condition, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(condition, action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, bool condition, Action<T> action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(condition, action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<UnitResult<E>> TapIfTry<E>(this Task<UnitResult<E>> resultTask, bool condition, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(condition, action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, bool condition, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(condition, action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, bool condition, Action<T> action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(condition, action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(predicate, action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Action<T> action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(predicate, action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(predicate, action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Action<T> action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapIfTry(predicate, action, errorHandler);
        }
    }
}

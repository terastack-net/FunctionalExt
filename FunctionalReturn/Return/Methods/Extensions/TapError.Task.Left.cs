using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapError<T>(this Task<Return<T>> resultTask, Action action)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapError(this Task<Return> resultTask, Action action)
        {
            Return result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapError<T, E>(this Task<Return<T, E>> resultTask, Action action)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitReturn<E>> TapError<E>(this Task<UnitReturn<E>> resultTask, Action action)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitReturn<E>> TapError<E>(this Task<UnitReturn<E>> resultTask, Action<E> action)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapError<T>(this Task<Return<T>> resultTask, Action<Exception> action)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapError<T, E>(this Task<Return<T, E>> resultTask, Action<E> action)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapError(this Task<Return> resultTask, Action<Exception> action)
        {
            Return result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }
    }
}

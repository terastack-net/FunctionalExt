#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapError<T>(this ValueTask<Return<T>> resultTask, Action action)
        {
            Return<T> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapError(this ValueTask<Return> resultTask, Action action)
        {
            Return result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapError<T, E>(this ValueTask<Return<T, E>> resultTask, Action action)
        {
            Return<T, E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitReturn<E>> TapError<E>(this ValueTask<UnitReturn<E>> resultTask, Action action)
        {
            UnitReturn<E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitReturn<E>> TapError<E>(this ValueTask<UnitReturn<E>> resultTask, Action<E> action)
        {
            UnitReturn<E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapError<T>(this ValueTask<Return<T>> resultTask, Action<Exception> action)
        {
            Return<T> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapError<T, E>(this ValueTask<Return<T, E>> resultTask, Action<E> action)
        {
            Return<T, E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapError(this ValueTask<Return> resultTask, Action<Exception> action)
        {
            Return result = await resultTask;
            return result.TapError(action);
        }
    }
}
#endif

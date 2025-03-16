#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> Tap(this ValueTask<Return> resultTask, Action action)
        {
            Return result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> Tap<T>(this ValueTask<Return<T>> resultTask, Action action)
        {
            Return<T> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> Tap<T>(this ValueTask<Return<T>> resultTask, Action<T> action)
        {
            Return<T> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this ValueTask<UnitResult<E>> resultTask, Action action)
        {
            UnitResult<E> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Tap<T, E>(this ValueTask<Return<T, E>> resultTask, Action action)
        {
            Return<T, E> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Tap<T, E>(this ValueTask<Return<T, E>> resultTask, Action<T> action)
        {
            Return<T, E> result = await resultTask;
            return result.Tap(action);
        }
    }
}
#endif

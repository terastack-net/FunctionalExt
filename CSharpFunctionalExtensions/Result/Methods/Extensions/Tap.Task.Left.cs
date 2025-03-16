using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return> Tap(this Task<Return> resultTask, Action action)
        {
            Return result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> Tap<T>(this Task<Return<T>> resultTask, Action action)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> Tap<T>(this Task<Return<T>> resultTask, Action<T> action)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitReturn<E>> Tap<E>(this Task<UnitReturn<E>> resultTask, Action action)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> Tap<T, E>(this Task<Return<T, E>> resultTask, Action action)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> Tap<T, E>(this Task<Return<T, E>> resultTask, Action<T> action)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }
    }
}

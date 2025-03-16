using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return> Tap(this Task<Return> resultTask, Func<Task> func)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> Tap<T>(this Task<Return<T>> resultTask, Func<Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> Tap<T>(this Task<Return<T>> resultTask, Func<T, Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitReturn<E>> Tap<E>(this Task<UnitReturn<E>> resultTask, Func<Task> func)
        {
            UnitReturn<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> Tap<T, E>(this Task<Return<T, E>> resultTask, Func<Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> Tap<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }
    }
}

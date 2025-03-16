#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> Tap(this ValueTask<Return> resultTask, Func<ValueTask> valueTask)
        {
            Return result = await resultTask;

            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> Tap<T>(this ValueTask<Return<T>> resultTask, Func<ValueTask> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> Tap<T>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsSuccess)
                await valueTask(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Tap<T, E>(this ValueTask<Return<T, E>> resultTask, Func<ValueTask> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Tap<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsSuccess)
                await valueTask(result.Value);

            return result;
        }
    }
}
#endif
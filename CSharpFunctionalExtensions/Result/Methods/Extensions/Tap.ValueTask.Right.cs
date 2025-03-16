#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> Tap(this Return result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> Tap<T>(this Return<T> result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> Tap<T>(this Return<T> result, Func<T, ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this UnitResult<E> result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Tap<T, E>(this Return<T, E> result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Tap<T, E>(this Return<T, E> result, Func<T, ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask(result.Value);

            return result;
        }
    }
}
#endif
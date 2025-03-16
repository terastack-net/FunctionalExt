#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T>> Check<T>(this ValueTask<Return<T>> resultTask,
            Func<T, ValueTask<Return>> valueTask)
        {
            Return<T> result = await resultTask;
            return await result.Bind(valueTask).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T>> Check<T, K>(this ValueTask<Return<T>> resultTask,
            Func<T, ValueTask<Return<K>>> valueTask)
        {
            Return<T> result = await resultTask;
            return await result.Bind(valueTask).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T, E>> Check<T, K, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, ValueTask<Return<K, E>>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return await result.Bind(valueTask).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T, E>> Check<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return await result.Bind(valueTask).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<ValueTask<UnitResult<E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return await result.Bind(valueTask).Map(() => result);
        }
    }
}
#endif
#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T>> Check<T>(this ValueTask<Return<T>> resultTask, Func<T, Return> valueTask)
        {
            Return<T> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T>> Check<T, K>(this ValueTask<Return<T>> resultTask,
            Func<T, Return<K>> valueTask)
        {
            Return<T> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T, E>> Check<T, K, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, Return<K, E>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Return<T, E>> Check<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, UnitResult<E>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<UnitResult<E>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return result.Check(valueTask);
        }
    }
}
#endif
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
        public static async ValueTask<Return<T, E>> TapError<T, E>(this ValueTask<Return<T, E>> resultTask, Func<ValueTask> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapError<T>(this ValueTask<Return<T>> resultTask, Func<ValueTask> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapError(this ValueTask<Return> resultTask, Func<ValueTask> valueTask)
        {
            Return result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapError(this ValueTask<Return> resultTask, Func<Exception, ValueTask> valueTask)
        {
            Return result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapError<T>(this ValueTask<Return<T>> resultTask, Func<Exception, ValueTask> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapError<T, E>(this ValueTask<Return<T, E>> resultTask, Func<E, ValueTask> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }
    }
}
#endif

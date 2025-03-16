#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, bool condition, Func<Exception, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, bool condition, Func<Exception, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Func<E, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<E, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, Func<Exception, bool> predicate, Func<ValueTask> valueTask)
        {
            Return result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, Func<Exception, bool> predicate, Func<Exception, ValueTask> valueTask)
        {
            Return result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, Func<Exception, bool> predicate, Func<ValueTask> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, Func<Exception, bool> predicate, Func<Exception, ValueTask> valueTask)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, Func<E, bool> predicate, Func<ValueTask> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, Func<E, bool> predicate, Func<E, ValueTask> valueTask)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<E, ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }
    }
}
#endif
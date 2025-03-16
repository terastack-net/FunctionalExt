#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, bool condition, Action<Exception> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, bool condition, Action<Exception> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, bool condition, Action<E> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action<E> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, Func<Exception, bool> predicate, Action action)
        {
            Return result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return> TapErrorIf(this ValueTask<Return> resultTask, Func<Exception, bool> predicate, Action<Exception> action)
        {
            Return result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, Func<Exception, bool> predicate, Action action)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T>> TapErrorIf<T>(this ValueTask<Return<T>> resultTask, Func<Exception, bool> predicate, Action<Exception> action)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, Func<E, bool> predicate, Action action)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Return<T, E>> TapErrorIf<T, E>(this ValueTask<Return<T, E>> resultTask, Func<E, bool> predicate, Action<E> action)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Action action)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Action<E> action)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }
    }
}
#endif
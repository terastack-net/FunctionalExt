using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapErrorIf(this Task<Return> resultTask, bool condition, Action action)
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
        public static Task<Return> TapErrorIf(this Task<Return> resultTask, bool condition, Action<Exception> action)
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
        public static Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, bool condition, Action action)
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
        public static Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, bool condition, Action<Exception> action)
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
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Action action)
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
        public static Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Action<E> action)
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
        public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Action action)
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
        public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Action<E> action)
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
        public static async Task<Return> TapErrorIf(this Task<Return> resultTask, Func<Exception, bool> predicate, Action action)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return> TapErrorIf(this Task<Return> resultTask, Func<Exception, bool> predicate, Action<Exception> action)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, Func<Exception, bool> predicate, Action action)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapErrorIf<T>(this Task<Return<T>> resultTask, Func<Exception, bool> predicate, Action<Exception> action)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, Func<E, bool> predicate, Action action)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapErrorIf<T, E>(this Task<Return<T, E>> resultTask, Func<E, bool> predicate, Action<E> action)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Action action)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Action<E> action)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }
    }
}

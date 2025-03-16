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
        public static ValueTask<Return> TapErrorIf(this Return result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this Return result, bool condition, Func<Exception, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this Return<T> result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this Return<T> result, bool condition, Func<Exception, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, bool condition, Func<E, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitReturn<E>> TapErrorIf<E>(this UnitReturn<E> result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitReturn<E>> TapErrorIf<E>(this UnitReturn<E> result, bool condition, Func<E, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this Return result, Func<Exception, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return> TapErrorIf(this Return result, Func<Exception, bool> predicate, Func<Exception, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this Return<T> result, Func<Exception, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T>> TapErrorIf<T>(this Return<T> result, Func<Exception, bool> predicate, Func<Exception, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, Func<E, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Return<T, E>> TapErrorIf<T, E>(this Return<T, E> result, Func<E, bool> predicate, Func<E, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitReturn<E>> TapErrorIf<E>(this UnitReturn<E> result, Func<E, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitReturn<E>> TapErrorIf<E>(this UnitReturn<E> result, Func<E, bool> predicate, Func<E, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }
    }
}
#endif

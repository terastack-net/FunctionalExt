#if !NET40
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapIf(this Return result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapIf<T>(this Return<T> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapIf<T>(this Return<T> result, bool condition, Func<T, Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapIf<T, E>(this Return<T, E> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapIf<T, E>(this Return<T, E> result, bool condition, Func<T, Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitReturn<E>> TapIf<E>(this UnitReturn<E> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapIf<T>(this Return<T> result, Func<T, bool> predicate, Func<Task> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapIf<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Task> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<Task> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapIf<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Task> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitReturn<E>> TapIf<E>(this UnitReturn<E> result, Func<bool> predicate, Func<Task> func)
        {
            if (result.IsSuccess && predicate())
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }
    }
}
#endif

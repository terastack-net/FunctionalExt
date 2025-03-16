using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return> TapIf(this Task<Return> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapIf<T>(this Task<Return<T>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T>> TapIf<T>(this Task<Return<T>> resultTask, bool condition, Func<T, Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Return<T, E>> TapIf<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<T, Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapIf<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T>> TapIf<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Task> func)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapIf<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapIf<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate())
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }
        
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapIf<T, E>(this Task<Return<T, E>> resultTask, Func<Task<bool>> predicate, Func<T, Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            
            if (result.IsSuccess && await predicate().DefaultAwait())
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Return<T, E>> TapIf<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task> func)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            
            if (result.IsSuccess && await predicate(result.Value).DefaultAwait())
                return await result.Tap(func).DefaultAwait();
            else
                return result;
        }

    }
}

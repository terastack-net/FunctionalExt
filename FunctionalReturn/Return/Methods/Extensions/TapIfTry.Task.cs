using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return> TapIfTry(this Task<Return> resultTask, bool condition, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return Return.Failure(message);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, bool condition, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return new Return<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, bool condition, Func<T, Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
                    await func(result.Value);

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return new Return<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<UnitReturn<E>> TapIfTry<E>(this Task<UnitReturn<E>> resultTask, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (condition && result.IsSuccess)
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new UnitReturn<E>(true, error);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (condition && result.IsSuccess)
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Return<T, E>(true, error, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, bool condition, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (condition && result.IsSuccess)
                    await func(result.Value);

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Return<T, E>(true, error, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess && predicate(result.Value) && result.IsSuccess)
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return new Return<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapIfTry<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess && predicate(result.Value))
                    await func(result.Value);

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return new Return<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess && predicate(result.Value))
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Return<T, E>(true, error, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Task<Return<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess && predicate(result.Value))
                    await func(result.Value);

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Return<T, E>(true, error, default);
            }
        }
    }
}

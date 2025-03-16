using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return> TapTry(this Task<Return> resultTask, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return Return.Failure(message);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapTry<T>(this Task<Return<T>> resultTask, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();
            
            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return new Return<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T>> TapTry<T>(this Task<Return<T>> resultTask, Func<T, Task> func, Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    await func(result.Value).DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return new Return<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<UnitResult<E>> TapTry<E>(this Task<UnitResult<E>> resultTask, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new UnitResult<E>(true, error);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapTry<T, E>(this Task<Return<T, E>> resultTask, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Return<T, E>(true, error, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapTry<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess)
                    await func(result.Value).DefaultAwait();

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

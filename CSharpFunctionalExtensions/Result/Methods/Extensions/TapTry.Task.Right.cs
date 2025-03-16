using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return> TapTry(this Return result, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<Return<T>> TapTry<T>(this Return<T> result, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<Return<T>> TapTry<T>(this Return<T> result, Func<T, Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<UnitReturn<E>> TapTry<E>(this UnitReturn<E> result, Func<Task> func, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new UnitReturn<E>(true, error);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapTry<T, E>(this Return<T, E> result, Func<Task> func, Func<Exception, E> errorHandler)
        {
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
        public static async Task<Return<T, E>> TapTry<T, E>(this Return<T, E> result, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
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

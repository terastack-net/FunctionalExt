using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return> TapIfTry(this Return result, bool condition, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<Return<T>> TapIfTry<T>(this Return<T> result, bool condition, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<Return<T>> TapIfTry<T>(this Return<T> result, bool condition, Func<T, Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<UnitResult<E>> TapIfTry<E>(this UnitResult<E> result, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
                    await func();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new UnitResult<E>(true, error);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Return<T, E> result, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
        {
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
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Return<T, E> result, bool condition, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
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
        public static async Task<Return<T>> TapIfTry<T>(this Return<T> result, Func<T, bool> predicate, Func<Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<Return<T>> TapIfTry<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, Exception> errorHandler = null)
        {
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
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<Task> func, Func<Exception, E> errorHandler)
        {
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
        public static async Task<Return<T, E>> TapIfTry<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
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

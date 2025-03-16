using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Return TapIfTry(this Return result, bool condition, Action action, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
                    action();

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
        public static Return<T> TapIfTry<T>(this Return<T> result, bool condition, Action action, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
                    action();

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
        public static Return<T> TapIfTry<T>(this Return<T> result, bool condition, Action<T> action, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
                    action(result.Value);

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
        public static UnitResult<E> TapIfTry<E>(this UnitResult<E> result, bool condition, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
                    action();

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
        public static Return<T, E> TapIfTry<T, E>(this Return<T, E> result, bool condition, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
                    action();

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
        public static Return<T, E> TapIfTry<T, E>(this Return<T, E> result, bool condition, Action<T> action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
                    action(result.Value);

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
        public static Return<T> TapIfTry<T>(this Return<T> result, Func<T, bool> predicate, Action action, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess && predicate(result.Value) && result.IsSuccess)
                    action();

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
        public static Return<T> TapIfTry<T>(this Return<T> result, Func<T, bool> predicate, Action<T> action, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Return.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess && predicate(result.Value))
                    action(result.Value);

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
        public static Return<T, E> TapIfTry<T, E>(this Return<T, E> result, Func<T, bool> predicate, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess && predicate(result.Value))
                    action();

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
        public static Return<T, E> TapIfTry<T, E>(this Return<T, E> result, Func<T, bool> predicate, Action<T> action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess && predicate(result.Value))
                    action(result.Value);

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

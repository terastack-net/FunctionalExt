using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public partial struct Return
    {
        /// <summary>
        ///     Attempts to execute the supplied action. Returns a Result indicating whether the action executed successfully.
        /// </summary>
        public static Return Try(Action action, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Configuration.DefaultTryErrorHandler;

            try
            {
                action();
                return Success();
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return Failure(message);
            }
        }

        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Result indicating whether the function executed successfully.
        ///     If the function executed successfully, the result contains its return value.
        /// </summary>
        public static Return<T> Try<T>(Func<T> func, Func<Exception, Exception> errorHandler = null)
        {
            errorHandler ??= Configuration.DefaultTryErrorHandler;

            try
            {
                return Success(func());
            }
            catch (Exception exc)
            {
                var message = errorHandler(exc);
                return Failure<T>(message);
            }
        }

        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Result indicating whether the function executed successfully.
        ///     If the function executed successfully, the result contains its return value.
        /// </summary>
        public static Return<T, E> Try<T, E>(Func<T> func, Func<Exception, E> errorHandler)
        {
            try
            {
                return Success<T, E>(func());
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Failure<T, E>(error);
            }
        }

        /// <summary>
        ///     Attempts to execute the supplied action. Returns a UnitResult indicating whether the action executed successfully.
        /// </summary>
        public static UnitResult<E> Try<E>(Action action, Func<Exception, E> errorHandler)
        {
          try
          {
            action();
            return UnitResult.Success<E>();
          }
          catch (Exception exc)
          {
            E error = errorHandler(exc);
            return UnitResult.Failure(error);
          }
        }
        
        /// <summary>
        ///     Attempts to execute the supplied action. Returns a UnitResult indicating whether the action executed successfully.
        /// </summary>
        public static async Task<UnitResult<E>> Try<E>(Func<Task> action, Func<Exception, E> errorHandler)
        {
          try
          {
              await action().DefaultAwait();
              return UnitResult.Success<E>();
          }
          catch (Exception exc)
          {
              E error = errorHandler(exc);
              return UnitResult.Failure(error);
          }
        }
    }
}

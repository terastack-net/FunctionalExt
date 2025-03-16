using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T, Task<bool>> predicate, Exception errorMessage)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task<bool>> predicate, E error)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task<bool>> predicate, Func<T, E> errorPredicate)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task<E>> errorPredicate)
        {
            Return<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T, E>(await errorPredicate(result.Value).DefaultAwait());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T, Task<bool>> predicate, Func<T, Exception> errorPredicate)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task<Exception>> errorPredicate)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T>(await errorPredicate(result.Value).DefaultAwait());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure(this Task<Return> resultTask, Func<Task<bool>> predicate, Exception errorMessage)
        {
            Return result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (!await predicate().DefaultAwait())
                return Return.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure(this Task<Return> resultTask, Func<Task<Return>> predicate)
        {
          Return result = await resultTask.DefaultAwait();
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<Task<Return>> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure<T>(this Task<Return> resultTask, Func<Task<Return<T>>> predicate)
        {
          Return result = await resultTask.DefaultAwait();
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<Task<Return<T>>> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          
          if (result.IsFailure)
            return result;
        
          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T,Task<Return>> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T,Task<Return<T>>> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}

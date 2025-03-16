using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<T, Task<bool>> predicate, Exception errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Return<T, E> result,
            Func<T, Task<bool>> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Return<T, E> result,
            Func<T, Task<bool>> predicate, Func<T, E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Return<T, E> result,
            Func<T, Task<bool>> predicate, Func<T, Task<E>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T, E>(await errorPredicate(result.Value).DefaultAwait());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<T, Task<bool>> predicate, Func<T, Exception> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<T, Task<bool>> predicate, Func<T, Task<Exception>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Return.Failure<T>(await errorPredicate(result.Value).DefaultAwait());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure(this Return result, Func<Task<bool>> predicate, Exception errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate().DefaultAwait())
                return Return.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure(this Return result, Func<Task<Return>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Return.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<Task<Return>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure<T>(this Return result, Func<Task<Return<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<Task<Return<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<T,Task<Return>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value).DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Return<T> result, Func<T,Task<Return<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value).DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}

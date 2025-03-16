#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<T, ValueTask<bool>> predicate, Exception errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Return.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this Return<T, E> result,
            Func<T, ValueTask<bool>> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Return.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this Return<T, E> result,
            Func<T, ValueTask<bool>> predicate, Func<T, E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Return.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this Return<T, E> result,
            Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<E>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Return.Failure<T, E>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<T, ValueTask<bool>> predicate, Func<T, Exception> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Return.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<string>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Return.Failure<T>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure(this Return result, Func<ValueTask<bool>> predicate, Exception errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate())
                return Return.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure(this Return result, Func<ValueTask<Return>> predicate)
        {
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
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<ValueTask<Return>> predicate)
        {
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
        public static async ValueTask<Return> Ensure<T>(this Return result, Func<ValueTask<Return<T>>> predicate)
        {
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
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<ValueTask<Return<T>>> predicate)
        {
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
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<T,ValueTask<Return>> predicate)
        {
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
        public static async ValueTask<Return<T>> Ensure<T>(this Return<T> result, Func<T,ValueTask<Return<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}
#endif
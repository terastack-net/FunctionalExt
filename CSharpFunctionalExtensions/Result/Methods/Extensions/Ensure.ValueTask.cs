#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Exception errorMessage)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Return.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, E error)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Return.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, E> valueTaskErrorPredicate)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Return.Failure<T, E>(valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, ValueTask<E>> valueTaskErrorPredicate)
        {
            Return<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Return.Failure<T, E>(await valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<bool>> predicateValueTask, Func<T, string> valueTaskErrorPredicate)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicateValueTask(result.Value))
                return Return.Failure<T>(valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, ValueTask<string>> valueTaskErrorPredicate)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Return.Failure<T>(await valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure(this ValueTask<Return> resultTask, Func<ValueTask<bool>> valueTaskPredicate, Exception errorMessage)
        {
            Return result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate())
                return Return.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure(this ValueTask<Return> resultTask, Func<ValueTask<Return>> valueTaskPredicate)
        {
          Return result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<ValueTask<Return>> valueTaskPredicate)
        {
          Return<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure<T>(this ValueTask<Return> resultTask, Func<ValueTask<Return<T>>> valueTaskPredicate)
        {
          Return result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<ValueTask<Return<T>>> valueTaskPredicate)
        {
          Return<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;
        
          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T,ValueTask<Return>> valueTaskPredicate)
        {
          Return<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T,ValueTask<Return<T>>> valueTaskPredicate)
        {
          Return<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}
#endif
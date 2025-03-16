using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Return<T, E> Ensure<T, E>(this Return<T, E> result, Func<T, bool> predicate, Func<T, E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Return.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Return<T, E> Ensure<T, E>(this Return<T, E> result, Func<T, bool> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Return.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> Ensure<T>(this Return<T> result, Func<T, bool> predicate, Exception errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Return.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> Ensure<T>(this Return<T> result, Func<T, bool> predicate, Func<T, Exception> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Return.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Return Ensure(this Return result, Func<bool> predicate, Exception errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return Return.Failure(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Return Ensure(this Return result, Func<Return> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> Ensure<T>(this Return<T> result, Func<Return> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Return Ensure<T>(this Return result, Func<Return<T>> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> Ensure<T>(this Return<T> result, Func<Return<T>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);

          return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> Ensure<T>(this Return<T> result, Func<T,Return> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Return<T> Ensure<T>(this Return<T> result, Func<T,Return<T>> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Return.Failure<T>(predicateResult.Error);
        
          return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static UnitReturn<E> Ensure<E>(this UnitReturn<E> result, Func<bool> predicate, Func<E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return UnitReturn.Failure<E>(errorPredicate());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static UnitReturn<E> Ensure<E>(this UnitReturn<E> result, Func<bool> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return UnitReturn.Failure<E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static UnitReturn<E> Ensure<E>(this UnitReturn<E> result, Func<UnitReturn<E>> predicate)
        {
            if (result.IsFailure)
                return result;

            var predicateResult = predicate();

            if (predicateResult.IsFailure)
                return UnitReturn.Failure<E>(predicateResult.Error);

            return result;
        }
    }
}

#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T, bool> predicate, Exception errorMessage)
        {
            Return<T> result = await resultTask;
            return result.Ensure(predicate, errorMessage);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, bool> predicate, E error)
        {
            Return<T, E> result = await resultTask;
            return result.Ensure(predicate, error);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T, E>> Ensure<T, E>(this ValueTask<Return<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, E> errorPredicate)
        {
            Return<T, E> result = await resultTask;
            return result.Ensure(predicate, errorPredicate);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Exception> errorPredicate)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            return result.Ensure(predicate, errorPredicate);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<string>> errorPredicate)
        {
            Return<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (predicate(result.Value))
                return result;

            return Return.Failure<T>(await errorPredicate(result.Value));
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure(this ValueTask<Return> resultTask, Func<bool> predicate, Exception errorMessage)
        {
            Return result = await resultTask;
            return result.Ensure(predicate, errorMessage);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure(this ValueTask<Return> resultTask, Func<Return> predicate)
        {
          Return result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<Return> predicate)
        {
          Return<T> result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return> Ensure<T>(this ValueTask<Return> resultTask, Func<Return<T>> predicate)
        {
          Return result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<Return<T>> predicate)
        {
          Return<T> result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T,Return> predicate)
        {
          Return<T> result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Return<T>> Ensure<T>(this ValueTask<Return<T>> resultTask, Func<T,Return<T>> predicate)
        {
          Return<T> result = await resultTask;
          return result.Ensure(predicate);
        }
    }
}
#endif

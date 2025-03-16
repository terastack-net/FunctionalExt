using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Exception errorMessage)
        {
            Return<T> result = await resultTask.DefaultAwait();
            return result.Ensure(predicate, errorMessage);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Task<Return<T, E>> resultTask,
            Func<T, bool> predicate, E error)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Ensure(predicate, error);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T, E>> Ensure<T, E>(this Task<Return<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, E> errorPredicate)
        {
            Return<T, E> result = await resultTask.DefaultAwait();
            return result.Ensure(predicate, errorPredicate);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Exception> errorPredicate)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            return result.Ensure(predicate, errorPredicate);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Exception>> errorPredicate)
        {
            Return<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return result;

            if (predicate(result.Value))
                return result;

            return Return.Failure<T>(await errorPredicate(result.Value).DefaultAwait());
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure(this Task<Return> resultTask, Func<bool> predicate, Exception errorMessage)
        {
            Return result = await resultTask.DefaultAwait();
            return result.Ensure(predicate, errorMessage);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure(this Task<Return> resultTask, Func<Return> predicate)
        {
          Return result = await resultTask.DefaultAwait();
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<Return> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return> Ensure<T>(this Task<Return> resultTask, Func<Return<T>> predicate)
        {
          Return result = await resultTask.DefaultAwait();
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<Return<T>> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T,Return> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Return<T>> Ensure<T>(this Task<Return<T>> resultTask, Func<T,Return<T>> predicate)
        {
          Return<T> result = await resultTask.DefaultAwait();
          return result.Ensure(predicate);
        }
    }
}

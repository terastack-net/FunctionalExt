using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions
{
	public static partial class AsyncResultExtensionsBothOperands
	{
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Return> BindTry(this Task<Return> resultTask, Func<Task<Return>> func,
			Func<Exception, Exception> errorHandler = null)
		{
			var result = await resultTask.DefaultAwait();
			return await result.BindTry(func, errorHandler).DefaultAwait();
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Return<K>> BindTry<K>(this Task<Return> resultTask, Func<Task<Return<K>>> func,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindTry(func, errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Return> BindTry<T>(this Task<Return<T>> resultTask, Func<T, Task<Return>> func,
			Func<Exception, Exception> errorHandler = null)
		{
			var result = await resultTask.DefaultAwait();
			return await result.BindTry(func, errorHandler).DefaultAwait();
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Return<K>> BindTry<T, K>(this Task<Return<T>> resultTask, Func<T, Task<Return<K>>> func,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindTry(func, errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<UnitResult<E>> BindTry<T, E>(this Task<Return<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindTry(func, errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Return<K, E>> BindTry<T, K, E>(this Task<Return<T, E>> resultTask, Func<T, Task<Return<K, E>>> func,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask.DefaultAwait();
			return await result.BindTry(func, errorHandler).DefaultAwait();
		}

        /// <summary>
		///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
		///     If a given function throws an exception, an error is returned from the given error handler
		/// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
		public static async Task<Return<T, E>> BindTry<T, E>(this Task<UnitResult<E>> resultTask, Func<Task<Return<T, E>>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return await result.BindTry(func, errorHandler).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<UnitResult<E>> BindTry<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask.DefaultAwait();
			return await result.BindTry(func, errorHandler).DefaultAwait();
		}			
	}
}

#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions.ValueTasks
{
	public static partial class AsyncResultExtensionsBothOperands
	{
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return> BindTry(this ValueTask<Return> resultTask, Func<ValueTask<Return>> valueTask,
			Func<Exception, Exception> errorHandler = null)
		{            
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K>> BindTry<K>(this ValueTask<Return> resultTask, Func<ValueTask<Return<K>>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return> BindTry<T>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<Return>> valueTask,
			Func<Exception, Exception> errorHandler = null)
		{
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>    
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K>> BindTry<T, K>(this ValueTask<Return<T>> resultTask, Func<T, ValueTask<Return<K>>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K, E>> BindTry<T, K, E>(this ValueTask<Return<T, E>> resultTask, Func<T, ValueTask<Return<K, E>>> valueTask,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}

        /// <summary>
		///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
		///     If a given function throws an exception, an error is returned from the given error handler
		/// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
		public static async ValueTask<Return<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Return<T, E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }


        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler        ///             ///     
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}			
	}
}
#endif
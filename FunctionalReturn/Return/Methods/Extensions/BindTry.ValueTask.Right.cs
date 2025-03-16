#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K, E>> BindTry<T, K, E>(this Return<T, E> result, Func<T, ValueTask<Return<K, E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<K, E>(result.Error)
                : await Return.Try(async () => await valueTask(result.Value),errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K>> BindTry<T, K>(this Return<T> result, Func<T, ValueTask<Return<K>>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : await Return.Try(async () => await valueTask(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K>> BindTry<K>(this Return result, Func<ValueTask<Return<K>>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : await Return.Try(async () => await valueTask(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return> BindTry<T>(this Return<T> result, Func<T, ValueTask<Return>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure(result.Error)
                : await Return.Try(async () => await valueTask(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return> BindTry(this Return result, Func<ValueTask<Return>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure(result.Error)
                : await Return.Try(async () => await valueTask(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitReturn<E>> BindTry<E>(this UnitReturn<E> result, Func<ValueTask<UnitReturn<E>>> valueTask,
            Func<Exception, E> errorHandler)
        {            
            return result.IsFailure
                ? UnitReturn.Failure(result.Error)
                : await Return.Try(async () => await valueTask(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<T, E>> BindTry<T, E>(this UnitReturn<E> result, Func<ValueTask<Return<T, E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<T,E>(result.Error)
                : await Return.Try(async () => await valueTask(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitReturn<E>> BindTry<T, E>(this Return<T, E> result, Func<T, ValueTask<UnitReturn<E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? UnitReturn.Failure(result.Error)
                : await Return.Try(async () => await valueTask(result.Value), errorHandler).Bind(r => r);           
        }
    }
}
#endif
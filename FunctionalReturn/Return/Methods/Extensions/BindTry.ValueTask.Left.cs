﻿#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return> BindTry(this ValueTask<Return> resultValueTask, Func<Return> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K>> BindTry<K>(this ValueTask<Return> resultValueTask, Func<Return<K>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return> BindTry<T>(this ValueTask<Return<T>> resultValueTask, Func<T, Return> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K>> BindTry<T, K>(this ValueTask<Return<T>> resultValueTask, Func<T, Return<K>> valueTask,
            Func<Exception, Exception> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitReturn<E>> BindTry<T, E>(this ValueTask<Return<T, E>> resultValueTask, Func<T, UnitReturn<E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<K, E>> BindTry<T, K, E>(this ValueTask<Return<T, E>> resultValueTask, Func<T, Return<K, E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitReturn<E>> BindTry<E>(this ValueTask<UnitReturn<E>> resultValueTask, Func<UnitReturn<E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Return<T, E>> BindTry<T, E>(this ValueTask<UnitReturn<E>> resultValueTask, Func<Return<T, E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }        
    }
}
#endif
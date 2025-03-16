using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static Return BindTry(this Return result, Func<Return> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure(result.Error)
                : Return.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static Return<K> BindTry<K>(this Return result, Func<Return<K>> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : Return.Try(() => func(), errorHandler).Bind(r => r);
        }


        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static Return BindTry<T>(this Return<T> result, Func<T, Return> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure(result.Error)
                : Return.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static Return<K> BindTry<T, K>(this Return<T> result, Func<T, Return<K>> func,
            Func<Exception, Exception> errorHandler = null)
        {
            return result.IsFailure
                ? Return.Failure<K>(result.Error)
                : Return.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///    Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.        
        ///    If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static Return<K, E> BindTry<T, K, E>(this Return<T, E> result, Func<T, Return<K, E>> func,
            Func<Exception, E> errorHandler)
        {            
            return result.IsFailure
                ? Return.Failure<K,E>(result.Error)
                : Return.Try(() => func(result.Value), errorHandler).Bind(r => r);           
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling UnitResult is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static UnitResult<E> BindTry<E>(this UnitResult<E> result, Func<UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? UnitResult.Failure(result.Error)
                : Return.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling UnitResult is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static Return<T, E> BindTry<T, E>(this UnitResult<E> result, Func<Return<T, E>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<T, E>(result.Error)
                : Return.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static UnitResult<E> BindTry<T, E>(this Return<T, E> result, Func<T, UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Return.Failure<T, E>(result.Error)
                : Return.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }
    }
}
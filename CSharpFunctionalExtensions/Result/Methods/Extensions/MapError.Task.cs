using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return> MapError(
            this Task<Return> resultTask,
            Func<Exception, Task<string>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<Return> MapError<TContext>(
            this Task<Return> resultTask,
            Func<Exception, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitReturn<E>> MapError<E>(
            this Task<Return> resultTask,
            Func<Exception, Task<E>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<UnitReturn<E>> MapError<E, TContext>(
            this Task<Return> resultTask,
            Func<Exception, TContext, Task<E>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T>> MapError<T>(
            this Task<Return<T>> resultTask,
            Func<Exception, Task<string>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<Return<T>> MapError<T, TContext>(
            this Task<Return<T>> resultTask,
            Func<Exception, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T, E>> MapError<T, E>(
            this Task<Return<T>> resultTask,
            Func<Exception, Task<E>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<Return<T, E>> MapError<T, E, TContext>(
            this Task<Return<T>> resultTask,
            Func<Exception, TContext, Task<E>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return> MapError<E>(
            this Task<UnitReturn<E>> resultTask,
            Func<E, Task<string>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<Return> MapError<E, TContext>(
            this Task<UnitReturn<E>> resultTask,
            Func<E, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitReturn<E2>> MapError<E, E2>(
            this Task<UnitReturn<E>> resultTask,
            Func<E, Task<E2>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<UnitReturn<E2>> MapError<E, E2, TContext>(
            this Task<UnitReturn<E>> resultTask,
            Func<E, TContext, Task<E2>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T>> MapError<T, E>(
            this Task<Return<T, E>> resultTask,
            Func<E, Task<string>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<Return<T>> MapError<T, E, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<E, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T, E2>> MapError<T, E, E2>(
            this Task<Return<T, E>> resultTask,
            Func<E, Task<E2>> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory).DefaultAwait();
        }

        public static async Task<Return<T, E2>> MapError<T, E, E2, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<E, TContext, Task<E2>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapError(errorFactory, context).DefaultAwait();
        }
    }
}

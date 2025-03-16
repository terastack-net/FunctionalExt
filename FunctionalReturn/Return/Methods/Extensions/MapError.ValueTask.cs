#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError(
            this ValueTask<Return> resultTask,
            Func<Exception, ValueTask<string>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<Return> MapError<TContext>(
            this ValueTask<Return> resultTask,
            Func<Exception, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitReturn<E>> MapError<E>(
            this ValueTask<Return> resultTask,
            Func<Exception, ValueTask<E>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<UnitReturn<E>> MapError<E, TContext>(
            this ValueTask<Return> resultTask,
            Func<Exception, TContext, ValueTask<E>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, ValueTask<string>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<Return<T>> MapError<T, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E>> MapError<T, E>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, ValueTask<E>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<Return<T, E>> MapError<T, E, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, TContext, ValueTask<E>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError<E>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, ValueTask<string>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<Return> MapError<E, TContext>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitReturn<E2>> MapError<E, E2>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, ValueTask<E2>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<UnitReturn<E2>> MapError<E, E2, TContext>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, TContext, ValueTask<E2>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T, E>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, ValueTask<string>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<Return<T>> MapError<T, E, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E2>> MapError<T, E, E2>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, ValueTask<E2>> errorFactory
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        public static async ValueTask<Return<T, E2>> MapError<T, E, E2, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, TContext, ValueTask<E2>> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            return await result.MapError(errorFactory, context);
        }
    }
}
#endif

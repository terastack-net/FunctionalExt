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
            Func<Exception, Exception> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error);
            return Return.Failure(error);
        }

        public static async ValueTask<Return> MapError<TContext>(
            this ValueTask<Return> resultTask,
            Func<Exception, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitReturn<E>> MapError<E>(
            this ValueTask<Return> resultTask,
            Func<Exception, E> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>();
            }

            var error = errorFactory(result.Error);
            return UnitReturn.Failure(error);
        }

        public static async ValueTask<UnitReturn<E>> MapError<E, TContext>(
            this ValueTask<Return> resultTask,
            Func<Exception, TContext, E> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>();
            }

            var error = errorFactory(result.Error, context);
            return UnitReturn.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, Exception> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T>(error);
        }

        public static async ValueTask<Return<T>> MapError<T, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E>> MapError<T, E>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, E> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T, E>(error);
        }

        public static async ValueTask<Return<T, E>> MapError<T, E, TContext>(
            this ValueTask<Return<T>> resultTask,
            Func<Exception, TContext, E> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError<E>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, Exception> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error);
            return Return.Failure(error);
        }

        public static async ValueTask<Return> MapError<E, TContext>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitReturn<E2>> MapError<E, E2>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, E2> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>();
            }

            var error = errorFactory(result.Error);
            return UnitReturn.Failure(error);
        }

        public static async ValueTask<UnitReturn<E2>> MapError<E, E2, TContext>(
            this ValueTask<UnitReturn<E>> resultTask,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>();
            }

            var error = errorFactory(result.Error, context);
            return UnitReturn.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T, E>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, Exception> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T>(error);
        }

        public static async ValueTask<Return<T>> MapError<T, E, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E2>> MapError<T, E, E2>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, E2> errorFactory
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T, E2>(error);
        }

        public static async ValueTask<Return<T, E2>> MapError<T, E, E2, TContext>(
            this ValueTask<Return<T, E>> resultTask,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T, E2>(error);
        }
    }
}
#endif

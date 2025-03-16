#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError(
            this Return result,
            Func<Exception, ValueTask<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError<TContext>(
            this Return result,
            Func<Exception, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error, context);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E>> MapError<E>(
            this Return result,
            Func<Exception, ValueTask<E>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = await errorFactory(result.Error);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E>> MapError<E, TContext>(
            this Return result,
            Func<Exception, TContext, ValueTask<E>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = await errorFactory(result.Error, context);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T>(
            this Return<T> result,
            Func<Exception, ValueTask<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T, TContext>(
            this Return<T> result,
            Func<Exception, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error, context);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E>> MapError<T, E>(
            this Return<T> result,
            Func<Exception, ValueTask<E>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error);
            return Return.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E>> MapError<T, E, TContext>(
            this Return<T> result,
            Func<Exception, TContext, ValueTask<E>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error, context);
            return Return.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError<E>(
            this UnitResult<E> result,
            Func<E, ValueTask<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return> MapError<E, TContext>(
            this UnitResult<E> result,
            Func<E, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error, context);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E2>> MapError<E, E2>(
            this UnitResult<E> result,
            Func<E, ValueTask<E2>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = await errorFactory(result.Error);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E2>> MapError<E, E2, TContext>(
            this UnitResult<E> result,
            Func<E, TContext, ValueTask<E2>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = await errorFactory(result.Error, context);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T, E>(
            this Return<T, E> result,
            Func<E, ValueTask<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T>> MapError<T, E, TContext>(
            this Return<T, E> result,
            Func<E, TContext, ValueTask<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error, context);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E2>> MapError<T, E, E2>(
            this Return<T, E> result,
            Func<E, ValueTask<E2>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error);
            return Return.Failure<T, E2>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Return<T, E2>> MapError<T, E, E2, TContext>(
            this Return<T, E> result,
            Func<E, TContext, ValueTask<E2>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error, context);
            return Return.Failure<T, E2>(error);
        }
    }
}
#endif

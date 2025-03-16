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
            this Return result,
            Func<Exception, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Return.Failure(error);
        }

        public static async Task<Return> MapError<TContext>(
            this Return result,
            Func<Exception, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitReturn<E>> MapError<E>(
            this Return result,
            Func<Exception, Task<E>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return UnitReturn.Failure(error);
        }

        public static async Task<UnitReturn<E>> MapError<E, TContext>(
            this Return result,
            Func<Exception, TContext, Task<E>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E>();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return UnitReturn.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T>> MapError<T>(
            this Return<T> result,
            Func<Exception, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Return.Failure<T>(error);
        }

        public static async Task<Return<T>> MapError<T, TContext>(
            this Return<T> result,
            Func<Exception, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T, E>> MapError<T, E>(
            this Return<T> result,
            Func<Exception, Task<E>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Return.Failure<T, E>(error);
        }

        public static async Task<Return<T, E>> MapError<T, E, TContext>(
            this Return<T> result,
            Func<Exception, TContext, Task<E>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Return.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return> MapError<E>(
            this UnitReturn<E> result,
            Func<E, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Return.Failure(error);
        }

        public static async Task<Return> MapError<E, TContext>(
            this UnitReturn<E> result,
            Func<E, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitReturn<E2>> MapError<E, E2>(
            this UnitReturn<E> result,
            Func<E, Task<E2>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return UnitReturn.Failure(error);
        }

        public static async Task<UnitReturn<E2>> MapError<E, E2, TContext>(
            this UnitReturn<E> result,
            Func<E, TContext, Task<E2>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return UnitReturn.Success<E2>();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return UnitReturn.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T>> MapError<T, E>(
            this Return<T, E> result,
            Func<E, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Return.Failure<T>(error);
        }

        public static async Task<Return<T>> MapError<T, E, TContext>(
            this Return<T, E> result,
            Func<E, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T, E2>> MapError<T, E, E2>(
            this Return<T, E> result,
            Func<E, Task<E2>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Return.Failure<T, E2>(error);
        }

        public static async Task<Return<T, E2>> MapError<T, E, E2, TContext>(
            this Return<T, E> result,
            Func<E, TContext, Task<E2>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Return.Failure<T, E2>(error);
        }
    }
}

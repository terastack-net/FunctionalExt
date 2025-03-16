using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return> MapError(
            this Task<Return> resultTask,
            Func<Exception, Exception> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error);
            return Return.Failure(error);
        }

        public static async Task<Return> MapError<TContext>(
            this Task<Return> resultTask,
            Func<Exception, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitResult<E>> MapError<E>(
            this Task<Return> resultTask,
            Func<Exception, E> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = errorFactory(result.Error);
            return UnitResult.Failure(error);
        }

        public static async Task<UnitResult<E>> MapError<E, TContext>(
            this Task<Return> resultTask,
            Func<Exception, TContext, E> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = errorFactory(result.Error, context);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T>> MapError<T>(
            this Task<Return<T>> resultTask,
            Func<Exception, Exception> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T>(error);
        }

        public static async Task<Return<T>> MapError<T, TContext>(
            this Task<Return<T>> resultTask,
            Func<Exception, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T, E>> MapError<T, E>(
            this Task<Return<T>> resultTask,
            Func<Exception, E> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T, E>(error);
        }

        public static async Task<Return<T, E>> MapError<T, E, TContext>(
            this Task<Return<T>> resultTask,
            Func<Exception, TContext, E> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success<T, E>(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return> MapError<E>(
            this Task<UnitResult<E>> resultTask,
            Func<E, Exception> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error);
            return Return.Failure(error);
        }

        public static async Task<Return> MapError<E, TContext>(
            this Task<UnitResult<E>> resultTask,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success();
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitResult<E2>> MapError<E, E2>(
            this Task<UnitResult<E>> resultTask,
            Func<E, E2> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = errorFactory(result.Error);
            return UnitResult.Failure(error);
        }

        public static async Task<UnitResult<E2>> MapError<E, E2, TContext>(
            this Task<UnitResult<E>> resultTask,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = errorFactory(result.Error, context);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T>> MapError<T, E>(
            this Task<Return<T, E>> resultTask,
            Func<E, Exception> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T>(error);
        }

        public static async Task<Return<T>> MapError<T, E, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Return<T, E2>> MapError<T, E, E2>(
            this Task<Return<T, E>> resultTask,
            Func<E, E2> errorFactory
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = errorFactory(result.Error);
            return Return.Failure<T, E2>(error);
        }

        public static async Task<Return<T, E2>> MapError<T, E, E2, TContext>(
            this Task<Return<T, E>> resultTask,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            if (result.IsSuccess)
            {
                return Return.Success<T, E2>(result.Value);
            }

            var error = errorFactory(result.Error, context);
            return Return.Failure<T, E2>(error);
        }
    }
}

using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Return MapError(this Return result, Func<Exception, Exception> errorFactory)
        {
            if (result.IsFailure)
                return Return.Failure(errorFactory(result.Error));

            return Return.Success();
        }

        public static Return MapError<TContext>(
            this Return result,
            Func<Exception, TContext, string> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure(errorFactory(result.Error, context));

            return Return.Success();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static UnitReturn<E> MapError<E>(this Return result, Func<Exception, E> errorFactory)
        {
            if (result.IsFailure)
                return UnitReturn.Failure(errorFactory(result.Error));

            return UnitReturn.Success<E>();
        }

        public static UnitReturn<E> MapError<E, TContext>(
            this Return result,
            Func<Exception, TContext, E> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return UnitReturn.Failure(errorFactory(result.Error, context));

            return UnitReturn.Success<E>();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Return<T> MapError<T>(
            this Return<T> result,
            Func<Exception, Exception> errorFactory
        )
        {
            if (result.IsFailure)
                return Return.Failure<T>(errorFactory(result.Error));

            return Return.Success(result.Value);
        }

        public static Return<T> MapError<T, TContext>(
            this Return<T> result,
            Func<Exception, TContext, Exception> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<T>(errorFactory(result.Error, context));

            return Return.Success(result.Value);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Return<T, E> MapError<T, E>(
            this Return<T> result,
            Func<Exception, E> errorFactory
        )
        {
            if (result.IsFailure)
                return Return.Failure<T, E>(errorFactory(result.Error));

            return Return.Success<T, E>(result.Value);
        }

        public static Return<T, E> MapError<T, E, TContext>(
            this Return<T> result,
            Func<Exception, TContext, E> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<T, E>(errorFactory(result.Error, context));

            return Return.Success<T, E>(result.Value);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Return MapError<E>(this UnitReturn<E> result, Func<E, Exception> errorFactory)
        {
            if (result.IsFailure)
                return Return.Failure(errorFactory(result.Error));

            return Return.Success();
        }

        public static Return MapError<E, TContext>(
            this UnitReturn<E> result,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure(errorFactory(result.Error, context));

            return Return.Success();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static UnitReturn<E2> MapError<E, E2>(
            this UnitReturn<E> result,
            Func<E, E2> errorFactory
        )
        {
            if (result.IsFailure)
                return UnitReturn.Failure(errorFactory(result.Error));

            return UnitReturn.Success<E2>();
        }

        public static UnitReturn<E2> MapError<E, E2, TContext>(
            this UnitReturn<E> result,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return UnitReturn.Failure(errorFactory(result.Error, context));

            return UnitReturn.Success<E2>();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Return<T> MapError<T, E>(
            this Return<T, E> result,
            Func<E, Exception> errorFactory
        )
        {
            if (result.IsFailure)
                return Return.Failure<T>(errorFactory(result.Error));

            return Return.Success(result.Value);
        }

        public static Return<T> MapError<T, E, TContext>(
            this Return<T, E> result,
            Func<E, TContext, Exception> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<T>(errorFactory(result.Error, context));

            return Return.Success(result.Value);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Return<T, E2> MapError<T, E, E2>(
            this Return<T, E> result,
            Func<E, E2> errorFactory
        )
        {
            if (result.IsFailure)
                return Return.Failure<T, E2>(errorFactory(result.Error));

            return Return.Success<T, E2>(result.Value);
        }

        public static Return<T, E2> MapError<T, E, E2, TContext>(
            this Return<T, E> result,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Return.Failure<T, E2>(errorFactory(result.Error, context));

            return Return.Success<T, E2>(result.Value);
        }
    }
}

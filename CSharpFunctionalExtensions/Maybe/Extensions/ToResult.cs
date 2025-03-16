using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Return<T> ToResult<T>(in this Maybe<T> maybe, string errorMessage)
        {
            if (maybe.HasNoValue)
                return Return.Failure<T>(errorMessage);

            return Return.Success(maybe.GetValueOrThrow());
        }

        public static Return<T, E> ToResult<T, E>(in this Maybe<T> maybe, E error)
        {
            if (maybe.HasNoValue)
                return Return.Failure<T, E>(error);

            return Return.Success<T, E>(maybe.GetValueOrThrow());
        }

        public static Return<T, E> ToResult<T, E>(in this Maybe<T> maybe, Func<E> errorFunc)
        {
            if (maybe.HasNoValue)
                return Return.Failure<T, E>(errorFunc());

            return Return.Success<T, E>(maybe.GetValueOrThrow());
        }
    }
}

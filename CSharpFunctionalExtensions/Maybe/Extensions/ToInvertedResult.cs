﻿using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Return ToInvertedResult<T>(in this Maybe<T> maybe, string errorMessage)
        {
            if (maybe.HasValue)
                return Return.Failure<T>(errorMessage);

            return Return.Success();
        }
        
        public static UnitResult<E> ToInvertedResult<T, E>(in this Maybe<T> maybe, E error)
        {
            if (maybe.HasValue)
                return UnitResult.Failure(error);
        
            return UnitResult.Success<E>();
        }
        
        public static UnitResult<E> ToInvertedResult<T, E>(in this Maybe<T> maybe, Func<E> errorFunc)
        {
            if (maybe.HasValue)
                return UnitResult.Failure(errorFunc());
        
            return UnitResult.Success<E>();
        }
    }
}

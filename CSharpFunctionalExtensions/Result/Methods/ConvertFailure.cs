using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Return<K> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Messages.ConvertFailureExceptionOnSuccess);

            return Failure<K>(Error);
        }
    }

    public partial struct Return<T>
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result.
        /// </summary>
        public Return ConvertFailure()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Return.Messages.ConvertFailureExceptionOnSuccess);

            return Return.Failure(Error);
        }

        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Return<K> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Return.Messages.ConvertFailureExceptionOnSuccess);

            return Return.Failure<K>(Error);
        }
    }

    public partial struct Return<T, E>
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Return<K, E> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Return.Messages.ConvertFailureExceptionOnSuccess);

            return Return.Failure<K, E>(Error);
        }
    }

    public partial struct UnitResult<E> 
    {
        /// <summary>
        ///     Throws if the result is a success. Else returns a new failure result of the given type.
        /// </summary>
        public Return<K, E> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Return.Messages.ConvertFailureExceptionOnSuccess);

            return Return.Failure<K, E>(Error);
        }
    }
}

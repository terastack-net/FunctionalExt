using System;
using System.Runtime.Serialization;
using FunctionalReturn.Internal;

namespace FunctionalReturn
{
    /// <summary>
    ///     Represents the result of an operation that has no return value on success, or an error on failure.
    /// </summary>
    /// <typeparam name="E">
    ///     The error type returned by a failed operation.
    /// </typeparam>
    [Serializable]
    public readonly partial struct UnitReturn<E> : IUnitReturn<E>, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly E _error;
        public E Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        internal UnitReturn(bool isFailure, in E error)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
        }

        private UnitReturn(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<E> values = ResultCommonLogic.Deserialize<E>(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public static implicit operator UnitReturn<E>(E error)
        {
            if (error is IUnitReturn<E> result)
            {
                E resultError = result.IsFailure ? result.Error : default;
                return new UnitReturn<E>(result.IsFailure, resultError);
            }

            return UnitReturn.Failure(error);
        }
    }

    /// <summary>
    /// Alternative entrypoint for <see cref="UnitReturn{E}" /> to avoid ambiguous calls
    /// </summary>
    public static partial class UnitReturn
    {
        /// <summary>
        ///     Creates a failure result with the given error.
        /// </summary>
        public static UnitReturn<E> Failure<E>(in E error)
        {
            return new UnitReturn<E>(true, error);
        }

        /// <summary>
        ///     Creates a success result containing the given error.
        /// </summary>
        public static UnitReturn<E> Success<E>()
        {
            return Return.Success<E>();
        }
    }
}

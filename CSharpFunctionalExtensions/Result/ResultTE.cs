using FunctionalReturn.Internal;
using System;
using System.Runtime.Serialization;

namespace FunctionalReturn
{
    [Serializable]
    public readonly partial struct Return<T, E> : IResult<T, E>, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly E _error;
        public E Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailureException<E>(Error);

        internal Return(bool isFailure, E error, T value)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
            _value = value;
        }

        private Return(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<E> values = ResultCommonLogic.Deserialize<E>(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
            _value = IsFailure ? default : (T)info.GetValue("Value", typeof(T));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public T GetValueOrDefault(T defaultValue = default)
        {
            if (IsFailure)
                return defaultValue;

            return Value;
        }

        public static implicit operator Return<T, E>(T value)
        {
            if (value is IResult<T, E> result)
            {
                E resultError = result.IsFailure ? result.Error : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Return<T, E>(result.IsFailure, resultError, resultValue);
            }

            return Return.Success<T, E>(value);
        }

        public static implicit operator Return<T, E>(E error)
        {
            if (error is IResult<T, E> result)
            {
                E resultError = result.IsFailure ? result.Error : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Return<T, E>(result.IsFailure, resultError, resultValue);
            }

            return Return.Failure<T, E>(error);
        }

        public static implicit operator UnitResult<E>(Return<T, E> result)
        {
            if (result.IsSuccess)
                return UnitResult.Success<E>();
            else
                return UnitResult.Failure(result.Error);
        }
    }
}

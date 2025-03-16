using FunctionalReturn.Internal;
using System;
using System.Runtime.Serialization;

namespace FunctionalReturn
{
    [Serializable]
    public readonly partial struct Return<T> : IReturn<T>, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly Exception _error;
        public Exception Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ReturnFailureException(Error);

        internal Return(bool isFailure, Exception error, T value)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
            _value = value;
        }

        private Return(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<Exception> values = ResultCommonLogic.Deserialize(info);
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

        public static implicit operator Return<T>(T value)
        {
            if (value is IReturn<T> result)
            {
                Exception resultError = result.IsFailure ? result.Error : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Return<T>(result.IsFailure, resultError, resultValue);
            }

            return Return.Success(value);
        }

        public static implicit operator Return<T>(Exception value)
        {
            return Return.Failure<T>(value);
        }

        public static implicit operator Return(Return<T> result)
        {
            if (result.IsSuccess)
                return Return.Success();
            else
                return Return.Failure(result.Error);
        }

        public static implicit operator UnitReturn<Exception>(Return<T> result)
        {
            if (result.IsSuccess)
                return UnitReturn.Success<Exception>();
            else
                return UnitReturn.Failure(result.Error);
        }
    }
}

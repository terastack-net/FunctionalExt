using FunctionalReturn.Internal;
using System;
using System.Runtime.Serialization;

namespace FunctionalReturn
{
    [Serializable]
    public readonly partial struct Return : IResult, ISerializable, IError<Exception>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly Exception _error;
        public Exception Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private Return(bool isFailure, Exception error)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
        }

        private Return(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<Exception> values = ResultCommonLogic.Deserialize(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public static implicit operator UnitResult<Exception>(Return result)
        {
            if (result.IsSuccess)
                return UnitResult.Success<Exception>();
            else
                return UnitResult.Failure(result.Error);
        }
    }
}

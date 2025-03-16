using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FunctionalReturn.Internal
{
    internal static class ResultCommonLogic
    {
        internal static void GetObjectDataCommon(IReturn result, SerializationInfo info)
        {
            info.AddValue("IsFailure", result.IsFailure);
            info.AddValue("IsSuccess", result.IsSuccess);
        }

        internal static void GetObjectData(Return result, SerializationInfo info)
        {
            GetObjectDataCommon(result, info);
            if (result.IsFailure)
            {
                info.AddValue("Error", result.Error);
            }
        }

        internal static void GetObjectData<T>(Return<T> result, SerializationInfo info)
        {
            GetObjectDataCommon(result, info);
            if (result.IsFailure)
            {
                info.AddValue("Error", result.Error);
            }

            if (result.IsSuccess)
            {
                info.AddValue("Value", result.Value);
            }
        }

        internal static void GetObjectData<T, E>(Return<T, E> result, SerializationInfo info)
        {
            GetObjectDataCommon(result, info);
            if (result.IsFailure)
            {
                info.AddValue("Error", result.Error);
            }

            if (result.IsSuccess)
            {
                info.AddValue("Value", result.Value);
            }
        }

        internal static void GetObjectData<E>(UnitReturn<E> result, SerializationInfo info)
        {
            GetObjectDataCommon(result, info);
            if (result.IsFailure)
            {
                info.AddValue("Error", result.Error);
            }
        }

        internal static bool ErrorStateGuard<E>(bool isFailure, E error)
        {
            if (isFailure)
            {
                if (error == null || (error is string && error.Equals(string.Empty)))
                    throw new ArgumentNullException(nameof(error), Return.Messages.ErrorObjectIsNotProvidedForFailure);
            }
            else
            {
                if (!EqualityComparer<E>.Default.Equals(error, default))
                    throw new ArgumentException(Return.Messages.ErrorObjectIsProvidedForSuccess, nameof(error));
            }

            return isFailure;
        }

        internal static E GetErrorWithSuccessGuard<E>(bool isFailure, E error) =>
            isFailure ? error : throw new ReturnSuccessException();

        internal static SerializationValue<Exception> Deserialize(SerializationInfo info) => Deserialize<Exception>(info);

        internal static SerializationValue<E> Deserialize<E>(SerializationInfo info)
        {
            bool isFailure = info.GetBoolean("IsFailure");
            E error = isFailure ? (E)info.GetValue("Error", typeof(E)) : default;
            return new SerializationValue<E>(isFailure, error);
        }
    }
}

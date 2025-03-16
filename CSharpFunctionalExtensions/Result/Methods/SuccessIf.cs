using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
        /// </summary>
        public static Return SuccessIf(bool isSuccess, Exception error)
        {
            return isSuccess
                ? Success()
                : Failure(error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static Return SuccessIf(Func<bool> predicate, Exception error)
        {
            return SuccessIf(predicate(), error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
        /// </summary>
        public static Return<T> SuccessIf<T>(bool isSuccess, in T value, Exception error)
        {
            return isSuccess
                ? Success(value)
                : Failure<T>(error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static Return<T> SuccessIf<T>(Func<bool> predicate, in T value, Exception error)
        {
            return SuccessIf(predicate(), value, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
        /// </summary>
        public static Return<T, E> SuccessIf<T, E>(bool isSuccess, in T value, in E error)
        {
            return isSuccess
                ? Success<T, E>(value)
                : Failure<T, E>(error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static Return<T, E> SuccessIf<T, E>(Func<bool> predicate, in T value, in E error)
        {
            return SuccessIf(predicate(), value, error);
        }
        
    }

    /// <summary>
    /// Alternative entrypoint for <see cref="UnitResult{E}" /> to avoid ambiguous calls
    /// </summary>
    public static partial class UnitResult
    {
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of FailureIf().
        /// </summary>
        public static UnitResult<E> SuccessIf<E>(bool isSuccess, in E error)
        {
            return isSuccess
                ? Success<E>()
                : Failure(error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static UnitResult<E> SuccessIf<E>(Func<bool> predicate, in E error)
        {
            return SuccessIf(predicate(), error);
        }
    }
}

﻿#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<Return> SuccessIf(Func<ValueTask<bool>> predicate, Exception error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<Return<T>> SuccessIf<T>(Func<ValueTask<bool>> predicate, T value, Exception error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, value, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<Return<T, E>> SuccessIf<T, E>(Func<ValueTask<bool>> predicate, T value, E error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, value, error);
        }
    }

    /// <summary>
    /// Alternative entrypoint for <see cref="UnitReturn{E}" /> to avoid ambiguous calls
    /// </summary>
    public static partial class UnitReturn
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<UnitReturn<E>> SuccessIf<E>(Func<ValueTask<bool>> predicate, E error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, error);
        }
    }
}
#endif

#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async ValueTask<Return> FailureIf(Func<ValueTask<bool>> failurePredicate, Exception error)
        {
            bool isFailure = await failurePredicate();
            return SuccessIf(!isFailure, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async ValueTask<Return<T>> FailureIf<T>(Func<ValueTask<bool>> failurePredicate, T value, Exception error)
        {
            bool isFailure = await failurePredicate();
            return SuccessIf(!isFailure, value, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async ValueTask<Return<T, E>> FailureIf<T, E>(Func<ValueTask<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate();
            return SuccessIf(!isFailure, value, error);
        }
    }
}
#endif

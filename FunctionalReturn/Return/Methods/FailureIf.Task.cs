using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Return> FailureIf(Func<Task<bool>> failurePredicate, Exception error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Return<T>> FailureIf<T>(Func<Task<bool>> failurePredicate, T value, Exception error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, value, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Return<T, E>> FailureIf<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, value, error);
        }
    }
}

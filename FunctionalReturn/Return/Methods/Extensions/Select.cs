using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Map method.
        /// </summary>
        public static Return<K> Select<T, K>(in this Return<T> result, Func<T, K> selector)
        {
            return result.Map(selector);
        }
    }
}

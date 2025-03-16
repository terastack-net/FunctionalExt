#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Return<K> MapWithTransactionScope<T, K>(this Return<T> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        public static Return<K> MapWithTransactionScope<K>(this Return self, Func<K> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif

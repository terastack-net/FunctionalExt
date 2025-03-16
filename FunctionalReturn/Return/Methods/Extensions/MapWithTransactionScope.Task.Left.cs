#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<K>> MapWithTransactionScope<T, K>(this Task<Return<T>> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Return<K>> MapWithTransactionScope<K>(this Task<Return> self, Func<K> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif

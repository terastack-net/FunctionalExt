#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<K>> MapWithTransactionScope<T, K>(this Return<T> self, Func<T, Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Return<K>> MapWithTransactionScope<K>(this Return self, Func<Task<K>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif

#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Return<K>> MapWithTransactionScope<T, K>(this Task<Return<T>> self, Func<T, Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Return<K>> MapWithTransactionScope<K>(this Task<Return> self, Func<Task<K>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif

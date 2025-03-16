#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<K, E>> BindWithTransactionScope<T, K, E>(this Task<Return<T, E>> self, Func<T, Return<K, E>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return<K>> BindWithTransactionScope<T, K>(this Task<Return<T>> self, Func<T, Return<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return<K>> BindWithTransactionScope<K>(this Task<Return> self, Func<Return<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return> BindWithTransactionScope<T>(this Task<Return<T>> self, Func<T, Return> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return> BindWithTransactionScope(this Task<Return> self, Func<Return> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif

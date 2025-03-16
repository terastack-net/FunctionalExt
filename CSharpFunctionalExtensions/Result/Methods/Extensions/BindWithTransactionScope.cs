#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Return<K> BindWithTransactionScope<T, K>(this Return<T> self, Func<T, Return<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Return<K> BindWithTransactionScope<K>(this Return self, Func<Return<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Return BindWithTransactionScope<T>(this Return<T> self, Func<T, Return> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Return BindWithTransactionScope(this Return self, Func<Return> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Return<K, E> BindWithTransactionScope<T, K, E>(this Return<T, E> self, Func<T, Return<K, E>> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif

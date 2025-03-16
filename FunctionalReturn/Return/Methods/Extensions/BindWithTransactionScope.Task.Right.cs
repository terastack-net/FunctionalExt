#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static Task<Return<K, E>> BindWithTransactionScope<T, K, E>(this Return<T, E> self, Func<T, Task<Return<K, E>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return<K>> BindWithTransactionScope<T, K>(this Return<T> self, Func<T, Task<Return<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return<K>> BindWithTransactionScope<K>(this Return self, Func<Task<Return<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return> BindWithTransactionScope<T>(this Return<T> self, Func<T, Task<Return>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Return> BindWithTransactionScope(this Return self, Func<Task<Return>> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif

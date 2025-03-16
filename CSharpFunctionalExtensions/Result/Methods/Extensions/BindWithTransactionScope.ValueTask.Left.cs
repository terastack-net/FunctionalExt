#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return<K, E>> BindWithTransactionScope<T, K, E>(this ValueTask<Return<T, E>> self, Func<T, Return<K, E>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return<K>> BindWithTransactionScope<T, K>(this ValueTask<Return<T>> self, Func<T, Return<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return<K>> BindWithTransactionScope<K>(this ValueTask<Return> self, Func<Return<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return> BindWithTransactionScope<T>(this ValueTask<Return<T>> self, Func<T, Return> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return> BindWithTransactionScope(this ValueTask<Return> self, Func<Return> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif

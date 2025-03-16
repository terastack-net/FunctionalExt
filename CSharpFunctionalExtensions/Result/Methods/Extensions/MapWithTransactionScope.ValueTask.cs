#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return<K>> MapWithTransactionScope<T, K>(this ValueTask<Return<T>> self, Func<T, ValueTask<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static ValueTask<Return<K>> MapWithTransactionScope<K>(this ValueTask<Return> self, Func<ValueTask<K>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif

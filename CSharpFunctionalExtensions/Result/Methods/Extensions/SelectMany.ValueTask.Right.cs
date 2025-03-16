#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static ValueTask<Return<TR>> SelectMany<T, TK, TR>(
            this Return<T> result,
            Func<T, ValueTask<Return<TK>>> valueTask,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(valueTask)
                .Map(x => project(result.Value, x));
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static ValueTask<Return<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Return<T, TE> result,
            Func<T, ValueTask<Return<TK, TE>>> valueTask,
            Func<T, TK, TR> project)
        {
            return result
                .Bind(valueTask)
                .Map(x => project(result.Value, x));
        }
    }
}
#endif
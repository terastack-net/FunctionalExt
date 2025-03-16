using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CheckTestsBase : TestBase
    {
        protected bool actionExecuted;
        
        protected Return GetResult(bool isSuccess)
        {
            actionExecuted = true;
            return isSuccess
                ? Return.Success()
                : FailedResult;
        }
        
        protected Func<T, Return<K>> Func_Result_K(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Return<K>>(t =>
                {
                    actionExecuted = true;
                    return Return.Success(K.Value);
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultK;
                };
        }

        protected Func<T, Return<K, E>> Func_Result_KE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Return<K, E>>(t =>
                {
                    actionExecuted = true;
                    return Return.Success<K, E>(K.Value);
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultKE;
                };
        }

        protected Func<T, UnitResult<E>> Func_Result_TE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, UnitResult<E>>(t =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE;
                };
        }

        protected Func<UnitResult<E>> Func_UnitResult_E(bool isSuccess)
        {
            return isSuccess
                ? new Func<UnitResult<E>>(() =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>();
                })
                : () =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE;
                };
        }

        protected Func<T, Task<Return<K>>> Func_Task_Result_K(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Task<Return<K>>>(t =>
                {
                    actionExecuted = true;
                    return Return.Success(K.Value).AsTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultK.AsTask();
                };
        }

        protected Func<T, Task<Return<K, E>>> Func_Task_Result_KE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Task<Return<K, E>>>(t =>
                {
                    actionExecuted = true;
                    return Return.Success<K, E>(K.Value).AsTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultKE.AsTask();
                };
        }

        protected Func<T, Task<UnitResult<E>>> Func_Task_Result_TE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, Task<UnitResult<E>>>(t =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsTask();
                };
        }

        protected Func<Task<UnitResult<E>>> Func_Task_UnitResult_E(bool isSuccess)
        {
            return isSuccess
                ? new Func<Task<UnitResult<E>>>(() =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsTask();
                })
                : () =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsTask();
                };
        }

        protected Func<T, ValueTask<Return<K>>> Func_ValueTask_Result_K(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, ValueTask<Return<K>>>(t =>
                {
                    actionExecuted = true;
                    return Return.Success(K.Value).AsValueTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultK.AsValueTask();
                };
        }

        protected Func<T, ValueTask<Return<K, E>>> Func_ValueTask_Result_KE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, ValueTask<Return<K, E>>>(t =>
                {
                    actionExecuted = true;
                    return Return.Success<K, E>(K.Value).AsValueTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedResultKE.AsValueTask();
                };
        }

        protected Func<T, ValueTask<UnitResult<E>>> Func_ValueTask_Result_TE(bool isSuccess)
        {
            return isSuccess
                ? new Func<T, ValueTask<UnitResult<E>>>(t =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsValueTask();
                })
                : t =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsValueTask();
                };
        }

        protected Func<ValueTask<UnitResult<E>>> Func_ValueTask_UnitResult_E(bool isSuccess)
        {
            return isSuccess
                ? new Func<ValueTask<UnitResult<E>>>(() =>
                {
                    actionExecuted = true;
                    return UnitResult.Success<E>().AsValueTask();
                })
                : () =>
                {
                    actionExecuted = true;
                    return FailedUnitResultE.AsValueTask();
                };
        }
        
        protected Return<T> FailedResultT => Return.Failure<T>(ErrorMessage);
        protected Return<K> FailedResultK => Return.Failure<K>(ErrorMessage);
        protected Return<K, E> FailedResultKE => Return.Failure<K, E>(E.Value);
        protected UnitResult<E> FailedUnitResultE => UnitResult.Failure(E.Value);
        protected Return FailedResult => Return.Failure(ErrorMessage);
    }
}
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CheckIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected CheckIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }
        
        protected Return Func_Result(bool _) { actionExecuted = true; return Return.Success(); } 
        
        protected Return<K> Func_Result_K(bool _) { actionExecuted = true; return Return.Success(K.Value); }
        protected Return<K,E> Func_Result_K_E(bool _) { actionExecuted = true; return Return.Success<K, E>(K.Value); }
        protected UnitResult<E> Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>(); }
        protected UnitResult<E> Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>(); }

        protected Task<Return> Task_Func_Result(bool _) { actionExecuted = true; return Return.Success().AsTask(); }
        protected Task<Return<K>> Task_Func_Result_K(bool _) { actionExecuted = true; return Return.Success(K.Value).AsTask(); }
        protected Task<Return<K, E>> Task_Func_Result_K_E(bool _) { actionExecuted = true; return Return.Success<K, E>(K.Value).AsTask(); }
        protected Task<UnitResult<E>> Task_Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>().AsTask(); }
        protected Task<UnitResult<E>> Task_Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>().AsTask(); }

        protected ValueTask<Return> ValueTask_Func_Result(bool _) { actionExecuted = true; return Return.Success().AsValueTask(); }
        protected ValueTask<Return<K>> ValueTask_Func_Result_K(bool _) { actionExecuted = true; return Return.Success(K.Value).AsValueTask(); }
        protected ValueTask<Return<K, E>> ValueTask_Func_Result_K_E(bool _) { actionExecuted = true; return Return.Success<K, E>(K.Value).AsValueTask(); }
        protected ValueTask<UnitResult<E>> ValueTask_Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>().AsValueTask(); }
        protected ValueTask<UnitResult<E>> ValueTask_Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>().AsValueTask(); }
        
        protected bool Predicate(bool b) { predicateExecuted = true; return b; }
    }
}
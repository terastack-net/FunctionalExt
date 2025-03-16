using System.Threading.Tasks;
using System;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class TapIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected TapIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }

        protected void Action()
        {
            actionExecuted = true;
        }

        protected void Action_T(T _)
        {
            actionExecuted = true;
        }

        protected void Action_T(bool _)
        {
            actionExecuted = true;
        }

        protected Return Func_Result(bool _)
        {
            actionExecuted = true;
            return Return.Success();
        }

        protected Return<K> Func_Result_K(bool _)
        {
            actionExecuted = true;
            return Return.Success(K.Value);
        }

        protected Return<K, E> Func_Result_K_E(bool _)
        {
            actionExecuted = true;
            return Return.Success<K, E>(K.Value);
        }

        protected Task Task_Action()
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Task_Action_T(T _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Task_Action_T(bool _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }
        
        protected Task<Return> Task_Func_Result(bool _)
        {
            actionExecuted = true;
            return Return.Success().AsTask();
        }
        
        protected Task<Return<K>> Task_Func_Result_K(bool _)
        {
            actionExecuted = true;
            return Return.Success(K.Value).AsTask();
        }

        protected Task<Return<K, E>> Task_Func_Result_K_E(bool _)
        {
            actionExecuted = true;
            return Return.Success<K, E>(K.Value).AsTask();
        }

        protected ValueTask ValueTask_Action()
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTask_Action_T(T _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTask_Action_T(bool _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }
        
        protected ValueTask<Return> ValueTask_Func_Result(bool _)
        {
            actionExecuted = true;
            return Return.Success().AsValueTask();
        }

        protected ValueTask<Return<K>> ValueTask_Func_Result_K(bool _)
        {
            actionExecuted = true;
            return Return.Success(K.Value).AsValueTask();
        }

        protected ValueTask<Return<K, E>> ValueTask_Func_Result_K_E(bool _)
        {
            actionExecuted = true;
            return Return.Success<K, E>(K.Value).AsValueTask();
        }

        protected bool Predicate(bool b)
        {
            predicateExecuted = true;
            return b;
        }

        protected Func<bool> GetPredicate(bool value)
        {
            return () =>
            {
                predicateExecuted.Should().BeFalse();

                predicateExecuted = true;
                return value;
            };
        }
        
        protected Task<bool> Task_Predicate(bool a)
        {
            predicateExecuted = true;
            return Task.FromResult(a);
        }
    }
}

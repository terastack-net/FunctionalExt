using FluentAssertions;
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTryTestsBase : BindTestsBase
    {
        protected static Return Throwing() => throw new Exception(ErrorMessage);        
        protected static UnitResult<E> Throwing_E() => throw new Exception(ErrorMessage);
        protected static Return<T, E> Throwing_T_E() => throw new Exception(ErrorMessage);
        protected static Return<K> Throwing_K() => throw new Exception(ErrorMessage);        
        protected static Return<K, E> Throwing_K_E() => throw new Exception(ErrorMessage);

        protected static Task<Return> Task_Throwing() => throw new Exception(ErrorMessage);        
        protected static Task<UnitResult<E>> Task_Throwing_E() => throw new Exception(ErrorMessage);
        protected static Task<Return<T, E>> Task_Throwing_T_E() => throw new Exception(ErrorMessage);
        protected static Task<Return<K>> Task_Throwing_K() => throw new Exception(ErrorMessage);        
        protected static Task<Return<K, E>> Task_Throwing_K_E() => throw new Exception(ErrorMessage);

        protected static ValueTask<Return> ValueTask_Throwing() => throw new Exception(ErrorMessage);        
        protected static ValueTask<UnitResult<E>> ValueTask_Throwing_E() => throw new Exception(ErrorMessage);
        protected static ValueTask<Return<T, E>> ValueTask_Throwing_T_E() => throw new Exception(ErrorMessage);
        protected static ValueTask<Return<K>> ValueTask_Throwing_K() => throw new Exception(ErrorMessage);        
        protected static ValueTask<Return<K, E>> ValueTask_Throwing_K_E() => throw new Exception(ErrorMessage);


        protected void AssertFailure(Return result, string message)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(message);
            FuncExecuted.Should().BeFalse();
        }
        protected void AssertFailure(UnitResult<E> result, E errorValue)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(errorValue);
            FuncExecuted.Should().BeFalse();
        }
    }
}

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods;

public class OfTests
{
    [Fact]
    public void Of_can_create_ResultT_from_value()
    {
        string value = "value";

        Return<string> result = Return.Of(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void Of_can_create_ResultT_from_func()
    {
        string value = "value";
        Func<string> func = () => value;

        Return<string> result = Return.Of(func);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public async Task Of_can_create_ResultT_from_valueTask()
    {
        string value = "value";
        Task<string> valueTask = Task.FromResult(value);

        Return<string> result = await Return.Of(valueTask);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public async Task Of_can_create_ResultT_from_valueTaskFunc()
    {
        string value = "value";
        Task<string> valueTask = Task.FromResult(value);
        Func<Task<string>> valueTaskFunc = () => valueTask;

        Return<string> result = await Return.Of(valueTaskFunc);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void Of_can_create_ResultTE_from_value()
    {
        string value = "value";

        Return<string, object> result = Return.Of<string, object>(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void Of_can_create_ResultTE_from_func()
    {
        string value = "value";
        Func<string> func = () => value;

        Return<string, object> result = Return.Of<string, object>(func);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public async Task Of_can_create_ResultTE_from_valueTask()
    {
        string value = "value";
        Task<string> valueTask = Task.FromResult(value);

        Return<string, object> result = await Return.Of<string, object>(valueTask);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public async Task Of_can_create_ResultTE_from_valueTaskFunc()
    {
        string value = "value";
        Task<string> valueTask = Task.FromResult(value);
        Func<Task<string>> valueTaskFunc = () => valueTask;

        Return<string, object> result = await Return.Of<string, object>(valueTaskFunc);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }
}

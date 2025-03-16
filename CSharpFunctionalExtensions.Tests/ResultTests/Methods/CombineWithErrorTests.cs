using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class CombineWithErrorTests : TestBase
    {
        private Error ComposeErrors(IEnumerable<Error> errors) =>
            new Error(errors.SelectMany(e => e.Errors).ToList());

        [Fact]
        public void Combine_all_UnitResults_errors_together()
        {
            IEnumerable<UnitResult<Error>> results = new UnitResult<Error>[]
            {
                UnitResult.Success<Error>(),
                UnitResult.Failure<Error>(new Error("Failure 1")),
                UnitResult.Failure<Error>(new Error("Failure 2")),
            };
            
            UnitResult<Error> result = Return.Combine(results, ComposeErrors);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_UnitResults_returns_Ok_if_no_failures() {
            IEnumerable<UnitResult<Error>> results = new UnitResult<Error>[]
            {
                UnitResult.Success<Error>(),
                UnitResult.Success<Error>(),
                UnitResult.Success<Error>(),
            };

            UnitResult<Error> result = Return.Combine(results, ComposeErrors);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_error_together()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Failure<Error>(new Error("Failure 1"));
            UnitResult<Error> result3 = UnitResult.Failure<Error>(new Error("Failure 2"));

            UnitResult<Error> result = Return.Combine(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_returns_Ok_if_no_failures()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Success<Error>();
            UnitResult<Error> result3 = UnitResult.Success<Error>();

            UnitResult<Error> result = Return.Combine(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_error_generic_results_together()
        {
            Return<int, Error> result1 = Return.Success<int, Error>(7);
            Return<string, Error> result2 = Return.Failure<string, Error>(new Error("Failure 1"));
            Return<double, Error> result3 = Return.Failure<double, Error>(new Error("Failure 2"));

            UnitResult<Error> result = Return.Combine<Error>(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_compose_method_success_generic_results_together()
        {
            Return<int, Error> result1 = Return.Success<int, Error>(7);
            Return<string, Error> result2 = Return.Success<string, Error>("msg");
            Return<double, Error> result3 = Return.Success<double, Error>(60.54);

            UnitResult<Error> result = Return.Combine<Error>(ComposeErrors, result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_error_together()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Failure<Error>(new Error("Failure 1"));
            UnitResult<Error> result3 = UnitResult.Failure<Error>(new Error("Failure 2"));

            UnitResult<Error> result = Return.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_returns_Ok_if_no_failures()
        {
            UnitResult<Error> result1 = UnitResult.Success<Error>();
            UnitResult<Error> result2 = UnitResult.Success<Error>();
            UnitResult<Error> result3 = UnitResult.Success<Error>();

            UnitResult<Error> result = Return.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_array_UnitResults_error_generic_results_together()
        {
            Return<int, Error> result1 = Return.Success<int, Error>(7);
            Return<string, Error> result2 = Return.Failure<string, Error>(new Error("Failure 1"));
            Return<double, Error> result3 = Return.Failure<double, Error>(new Error("Failure 2"));

            UnitResult<Error> result = Return.Combine<Error>(result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_array_UnitResults_success_generic_results_together()
        {
            Return<int, Error> result1 = Return.Success<int, Error>(7);
            Return<string, Error> result2 = Return.Success<string, Error>("msg");
            Return<double, Error> result3 = Return.Success<double, Error>(60.54);

            UnitResult<Error> result = Return.Combine<Error>(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_errors_together()
        {
            Return<bool, Error> result1 = Return.Success<bool, Error>(true);
            Return<bool, Error> result2 = Return.Failure<bool, Error>(new Error("Failure 1"));
            Return<bool, Error> result3 = Return.Failure<bool, Error>(new Error("Failure 2"));

            Return<bool, Error> result = Return.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures()
        {
            Return<bool, Error> result1 = Return.Success<bool, Error>(true);
            Return<bool, Error> result2 = Return.Success<bool, Error>(true);
            Return<bool, Error> result3 = Return.Success<bool, Error>(false);

            Return<bool, Error> result = Return.Combine<bool, Error>(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_success()
        {
            Return<string, Error>[] results = new Return<string, Error>[] { Return.Success<string, Error>(""), Return.Success<string, Error>("") };

            Return<bool, Error> result = Return.Combine(results);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_failure()
        {
            Return<string, Error>[] results = new Return<string, Error>[] { Return.Success<string, Error>(""), Return.Failure<string, Error>(new Error("m")) };

            Return<bool, Error> result = Return.Combine(results);

            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void Combine_combines_all_collection_errors_together()
        {
            IEnumerable<Return<bool, Error>> results = new Return<bool, Error>[]
            {
                Return.Success<bool,Error>(true),
                Return.Failure<bool,Error>(new Error("Failure 1")),
                Return.Failure<bool,Error>(new Error("Failure 2"))
            };

            Return<string, Error> result = results.Combine(b => b.ToString());

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_collection()
        {
            IEnumerable<Return<bool, Error>> results = new Return<bool, Error>[]
            {
                Return.Success<bool, Error>(false),
                Return.Success<bool, Error>(true),
                Return.Success<bool, Error>(false)
            };

            Return<IEnumerable<bool>, Error> result = results.Combine();

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_Generic_results_collection_errors_together()
        {
            IEnumerable<Return<string, Error>> results = new Return<string, Error>[]
            {
                Return.Success<string,Error>("str 1"),
                Return.Failure<string,Error>(new Error("Failure 1")),
                Return.Failure<string,Error>(new Error("Failure 2"))
            };

            Return<IEnumerable<string>, Error> result = results.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Failure 1", "Failure 2" });
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_Generic_results_collection()
        {
            IEnumerable<Return<int, Error>> results = new Return<int, Error>[]
            {
                Return.Success<int,Error>(21),
                Return.Success<int,Error>(34),
                Return.Success<int,Error>(55)
            };

            Return<IEnumerable<int>, Error> result = results.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 21, 34, 55 });
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_success()
        {
            IEnumerable<Return<string, Error>> results = new Return<string, Error>[]
            {
                Return.Success<string, Error>("one"),
                Return.Success<string, Error>("two"),
                Return.Success<string, Error>("three")
            };

            Return<IEnumerable<string>, Error> result = results.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("one", "two", "three");
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_failure()
        {
            IEnumerable<Return<string, Error>> results = new Return<string, Error>[]
            {
                Return.Success<string,Error>(""),
                Return.Failure<string,Error>(new Error("m")),
                Return.Failure<string,Error>(new Error("o"))
            };

            Return<IEnumerable<string>, Error> result = results.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "m", "o" });
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_combines_all_collection_errors_together()
        {
            IEnumerable<Task<Return<bool, Error>>> tasks = new Task<Return<bool, Error>>[]
            {
                Task.FromResult(Return.Success<bool, Error>(true)),
                Task.FromResult(Return.Failure<bool, Error>(new Error("e"))),
                Task.FromResult(Return.Failure<bool, Error>(new Error("r"))),
                Task.FromResult(Return.Failure<bool, Error>(new Error("r")))
            };

            Return<IEnumerable<bool>, Error> result = await tasks.Combine();

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "e", "r", "r" });
        }

        [Fact]
        public async Task Combine_combines_all_tasks_of_Generic_results_collection_errors_together()
        {
            IEnumerable<Task<Return<string, Error>>> tasks = new Task<Return<string, Error>>[]
            {
                Task.FromResult(Return.Success<string,Error>("str 1")),
                Task.FromResult(Return.Failure<string,Error>(new Error("Error 1"))),
                Task.FromResult(Return.Failure<string,Error>(new Error("Error 2")))
            };

            Return<IEnumerable<string>, Error> result = await tasks.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "Error 1", "Error 2" });
        }

        [Fact]
        public async Task Combine_returns_Ok_if_no_failures_in_Generic_results_collection_of_tasks()
        {
            IEnumerable<Task<Return<int, Error>>> tasks = new Task<Return<int, Error>>[]
            {
                Task.FromResult(Return.Success<int,Error>(8)),
                Task.FromResult(Return.Success<int,Error>(16)),
                Task.FromResult(Return.Success<int,Error>(32))
            };

            Return<IEnumerable<int>, Error> result = await tasks.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 8, 16, 32 });
        }


        [Fact]
        public async Task Combine_works_with_task_with_collection_of_results_failure()
        {
            IEnumerable<Return<bool, Error>> results = new Return<bool, Error>[]
            {
                Return.Success<bool,Error>(true),
                Return.Failure<bool,Error>(new Error("b")),
                Return.Failure<bool,Error>(new Error("y"))
            };
            var task = Task.FromResult(results);

            Return<IEnumerable<bool>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "b", "y" });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_Generic_results_success()
        {
            IEnumerable<Return<string, Error>> results = new Return<string, Error>[]
            {
                Return.Success<string,Error>("1"),
                Return.Success<string,Error>("3"),
                Return.Success<string,Error>("7")
            };
            var task = Task.FromResult(results);

            Return<IEnumerable<string>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("1", "3", "7");
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_Generic_results_failure()
        {
            IEnumerable<Return<int, Error>> results = new Return<int, Error>[]
            {
                Return.Success<int, Error>(7),
                Return.Failure<int, Error>(new Error("b")),
                Return.Failure<int, Error>(new Error("2"))
            };
            var task = Task.FromResult(results);

            Return<IEnumerable<int>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "b", "2" });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_results_failure()
        {
            IEnumerable<Task<Return<bool, Error>>> tasks = new Task<Return<bool, Error>>[]
            {
                Task.FromResult(Return.Success<bool, Error>(true)),
                Task.FromResult(Return.Failure<bool, Error>(new Error("x"))),
                Task.FromResult(Return.Failure<bool, Error>(new Error("y"))),
                Task.FromResult(Return.Failure<bool, Error>(new Error("z")))
            };
            Task<IEnumerable<Task<Return<bool, Error>>>> task = Task.FromResult(tasks);

            Return<IEnumerable<bool>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "x", "y", "z" });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_success()
        {
            IEnumerable<Task<Return<int, Error>>> tasks = new Task<Return<int, Error>>[]
            {
                Task.FromResult(Return.Success<int, Error>(7)),
                Task.FromResult(Return.Success<int, Error>(77)),
                Task.FromResult(Return.Success<int, Error>(777))
            };
            Task<IEnumerable<Task<Return<int, Error>>>> task = Task.FromResult(tasks);

            Return<IEnumerable<int>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(7, 77, 777);
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_failure()
        {
            IEnumerable<Task<Return<int, Error>>> tasks = new Task<Return<int, Error>>[]
            {
                Task.FromResult(Return.Success<int,Error>(13)),
                Task.FromResult(Return.Failure<int,Error>(new Error("error"))),
                Task.FromResult(Return.Failure<int,Error>(new Error("fail")))
            };
            Task<IEnumerable<Task<Return<int, Error>>>> task = Task.FromResult(tasks);

            Return<IEnumerable<int>, Error> result = await task.Combine();

            result.IsSuccess.Should().BeFalse();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "error", "fail" });
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Return<int, Error>> results = new Return<int, Error>[]
            {
                Return.Success<int,Error>(10),
                Return.Success<int,Error>(20),
                Return.Success<int,Error>(30),
            };

            Return<double, Error> result = results.Combine(values => (double)values.Max() / 100);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.3);
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Return<string, Error>> results = new Return<string, Error>[]
            {
                Return.Success<string,Error>("one"),
                Return.Success<string,Error>("five"),
                Return.Success<string,Error>("three"),
                Return.Failure<string,Error>(new Error("error 1")),
                Return.Failure<string,Error>(new Error("error 2"))
            };

            Return<string, Error> result = results.Combine(values => values.OrderBy(e => e.Length).First());

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "error 1", "error 2" });
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Return<int, Error>>> tasks = new Task<Return<int, Error>>[]
            {
                Task.FromResult(Return.Success<int, Error>(90)),
                Task.FromResult(Return.Success<int, Error>(95)),
                Task.FromResult(Return.Success<int, Error>(99)),
            };

            Return<double, Error> result = await tasks.Combine(values => (double)values.Min() / 1000);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.09);
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Return<string, Error>>> tasks = new Task<Return<string, Error>>[]
            {
                Task.FromResult(Return.Success<string,Error>("ho")),
                Task.FromResult(Return.Success<string,Error>("Hi")),
                Task.FromResult(Return.Success<string,Error>("No")),
                Task.FromResult(Return.Failure<string,Error>(new Error("exc 1"))),
                Task.FromResult(Return.Failure<string,Error>(new Error("exc 2")))
            };

            Return<string, Error> result = await tasks.Combine<string, string, Error>(values => values.Min());

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "exc 1", "exc 2" });
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Return<int, Error>>> tasks = new Task<Return<int, Error>>[]
            {
                Task.FromResult(Return.Success<int, Error>(90)),
                Task.FromResult(Return.Success<int, Error>(95)),
                Task.FromResult(Return.Success<int, Error>(99)),
            };
            Task<IEnumerable<Task<Return<int, Error>>>> task = Task.FromResult(tasks);

            Return<double, Error> result = await task.Combine(values => (double)values.Max() / 100);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.99);
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Return<string, Error>>> tasks = new Task<Return<string, Error>>[]
            {
                Task.FromResult(Return.Success<string,Error>("ho")),
                Task.FromResult(Return.Success<string,Error>("Hi")),
                Task.FromResult(Return.Success<string,Error>("No")),
                Task.FromResult(Return.Failure<string,Error>(new Error("e 1"))),
                Task.FromResult(Return.Failure<string,Error>(new Error("e 2")))
            };
            Task<IEnumerable<Task<Return<string, Error>>>> task = Task.FromResult(tasks);

            Return<string, Error> result = await task.Combine(composer: values => values.Max());

            result.IsFailure.Should().BeTrue();
            result.Error.Errors.Should().BeEquivalentTo(new[] { "e 1", "e 2" });
        }
    }
}

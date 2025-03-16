using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    [Collection(NonParallelTestCollectionDefinition.Name)]
    public class CombineTests : TestBase
    {
        [Fact]
        public void Combine_combines_all_errors_together()
        {
            Return result1 = Return.Success();
            Return result2 = Return.Failure("Failure 1");
            Return result3 = Return.Failure("Failure 2");

            Return result = Return.Combine(";", result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        [Fact]
        public void Combine_aggregates_identical_errors_with_count()
        {
            Return result1 = Return.Success();
            Return result2 = Return.Failure("Failure 1");
            Return result3 = Return.Failure("Failure 1");
            Return result4 = Return.Failure("Failure 2");

            Return result = Return.Combine(";", result1, result2, result3, result4);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1 (2×);Failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures()
        {
            Return result1 = Return.Success();
            Return result2 = Return.Success();
            Return<string> result3 = Return.Success("Some string");

            Return result = Return.Combine(";", result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void ErrorMessagesSeparator_Combine_combines_all_errors_with_configured_ErrorMessagesSeparator_together()
        {
            var previousErrorMessagesSeparator = Return.Configuration.ErrorMessagesSeparator;

            Return result1 = Return.Failure("E1");
            Return result2 = Return.Failure("E2");

            Return.Configuration.ErrorMessagesSeparator = "{Separator}";
            Return result = Return.Combine(result1, result2);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("E1{Separator}E2");

            Return.Configuration.ErrorMessagesSeparator = previousErrorMessagesSeparator;
        }

        [Fact]
        public void ErrorMessagesSeparator_Combine_combines_all_collection_errors_with_configured_ErrorMessagesSeparator_together()
        {
            var previousErrorMessagesSeparator = Return.Configuration.ErrorMessagesSeparator;

            IEnumerable<Return> results = new Return[]
            {
                Return.Failure("E1"),
                Return.Failure("E2")
            };

            Return.Configuration.ErrorMessagesSeparator = "{Separator}";
            Return result = results.Combine();

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("E1{Separator}E2");

            Return.Configuration.ErrorMessagesSeparator = previousErrorMessagesSeparator;
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_success()
        {
            Return<string>[] results = new Return<string>[] { Return.Success(""), Return.Success("") };

            Return result = Return.Combine(";", results);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_works_with_array_of_Generic_results_failure()
        {
            Return<string>[] results = new Return<string>[] { Return.Success(""), Return.Failure<string>("m") };

            Return result = Return.Combine(";", results);

            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void Combine_combines_all_collection_errors_together()
        {
            IEnumerable<Return> results = new Return[]
            {
                Return.Success(),
                Return.Failure("Failure 1"),
                Return.Failure("Failure 2")
            };

            Return result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        [Fact]
        public void Combine_aggregates_all_identical_collection_errors_together_with_count()
        {
            IEnumerable<Return> results = new Return[]
            {
                Return.Success(),
                Return.Failure("Failure 1"),
                Return.Failure("Failure 1"),
                Return.Failure("Failure 2")
            };

            Return result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1 (2×);Failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_collection()
        {
            IEnumerable<Return> results = new Return[]
            {
                Return.Success(),
                Return.Success(),
                Return.Success("Some string")
            };

            Return result = results.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_Generic_results_collection_errors_together()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success<string>("str 1"),
                Return.Failure<string>("Failure 1"),
                Return.Failure<string>("Failure 2")
            };

            Return<IEnumerable<string>> result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
        }

        [Fact]
        public void Combine_aggregates_all_identical_Generic_results_collection_errors_together_with_count()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success<string>("str 1"),
                Return.Failure<string>("Failure 1"),
                Return.Failure<string>("Failure 1"),
                Return.Failure<string>("Failure 2")
            };

            Return<IEnumerable<string>> result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1 (2×);Failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures_in_Generic_results_collection()
        {
            IEnumerable<Return<int>> results = new Return<int>[]
            {
                Return.Success(21),
                Return.Success(34),
                Return.Success(55)
            };

            Return<IEnumerable<int>> result = results.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 21, 34, 55 });
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_success()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success("one"),
                Return.Success("two"),
                Return.Success("three")
            };

            Return<IEnumerable<string>> result = results.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("one", "two", "three");
        }

        [Fact]
        public void Combine_works_with_collection_of_Generic_results_failure()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success(""),
                Return.Failure<string>("m"),
                Return.Failure<string>("o")
            };

            Return result = results.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("m;o");
        }

        [Fact]
        public void Combine_T_E_results_in_only_one_iteration_over_input_enumerable()
        {
            var count = 0;
            Return<int, Error> CountIterations(int input)
            {
                count++;
                return input;
            };

            IEnumerable<Return<int, Error>> results = Enumerable.Range(0, 1)
                .Select(CountIterations);

            var result = results.Combine().Value.ToList();

            count.Should().Be(1);
        }

        [Fact]
        public void Combine_T_E_with_composer_results_in_only_one_iteration_over_input_enumerable()
        {
            var count = 0;
            Return<int, Exception> CountIterations(int input)
            {
                count++;
                return input;
            };

            IEnumerable<Return<int, Exception>> results = Enumerable.Range(0, 1)
                .Select(CountIterations);

            var result = results.Combine(exs => new AggregateException(exs)).Value.ToList();

            count.Should().Be(1);
        }

        [Fact]
        public void Combine_T_results_in_only_one_iteration_over_input_enumerable()
        {
            var count = 0;
            Return<int> CountIterations(int input)
            {
                count++;
                return input;
            };

            IEnumerable<Return<int>> results = Enumerable.Range(0, 1)
                .Select(CountIterations);

            var result = results.Combine().Value.ToList();

            count.Should().Be(1);
        }

        [Fact]
        public void Combine_T_K_E_with_composer_error_results_in_only_one_iteration_over_input_enumerable()
        {
            var count = 0;
            Return<int, Exception> CountIterations(int input)
            {
                count++;
                return input;
            };

            IEnumerable<Return<int, Exception>> results = Enumerable.Range(0, 1)
                .Select(CountIterations);

            var result = results.Combine(v => v.Sum(), exs => new AggregateException(exs)).Value;

            count.Should().Be(1);
        }

        [Fact]
        public void Combine_T_K_E_results_in_only_one_iteration_over_input_enumerable()
        {
            var count = 0;
            Return<int, Error> CountIterations(int input)
            {
                count++;
                return input;
            };

            IEnumerable<Return<int, Error>> results = Enumerable.Range(0, 1)
                .Select(CountIterations);

            var result = results.Combine(v => v.Sum()).Value;

            count.Should().Be(1);
        }

        [Fact]
        public void Combine_T_K_results_in_only_one_iteration_over_input_enumerable()
        {
            var count = 0;
            Return<int> CountIterations(int input)
            {
                count++;
                return input;
            };

            IEnumerable<Return<int>> results = Enumerable.Range(0, 1)
                .Select(CountIterations);

            var result = results.Combine(v => v.Sum()).Value;

            count.Should().Be(1);
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_results_success()
        {
            IEnumerable<Task<Return>> tasks = new Task<Return>[]
            {
                Task.FromResult(Return.Success()),
                Task.FromResult(Return.Success()),
                Task.FromResult((Return)Return.Success("some text")),
            };

            Return result = await tasks.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_combines_all_collection_errors_together()
        {
            IEnumerable<Task<Return>> tasks = new Task<Return>[]
            {
                Task.FromResult(Return.Success()),
                Task.FromResult(Return.Failure("e")),
                Task.FromResult(Return.Failure("r"))
            };

            Return result = await tasks.Combine(";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e;r");
        }

        [Fact]
        public async Task Combine_works_with_collection_of_Tasks_aggregates_all_identical_collection_errors_together_with_count()
        {
            IEnumerable<Task<Return>> tasks = new Task<Return>[]
            {
                Task.FromResult(Return.Success()),
                Task.FromResult(Return.Failure("e")),
                Task.FromResult(Return.Failure("r")),
                Task.FromResult(Return.Failure("r"))
            };

            Return result = await tasks.Combine(";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e;r (2×)");
        }

        [Fact]
        public async Task Combine_combines_all_tasks_of_Generic_results_collection_errors_together()
        {
            IEnumerable<Task<Return<string>>> tasks = new Task<Return<string>>[]
            {
                Task.FromResult(Return.Success<string>("str 1")),
                Task.FromResult(Return.Failure<string>("Error 1")),
                Task.FromResult(Return.Failure<string>("Error 2"))
            };

            Return<IEnumerable<string>> result = await tasks.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error 1;Error 2");
        }

        [Fact]
        public async Task Combine_returns_Ok_if_no_failures_in_Generic_results_collection_of_tasks()
        {
            IEnumerable<Task<Return<int>>> tasks = new Task<Return<int>>[]
            {
                Task.FromResult(Return.Success(8)),
                Task.FromResult(Return.Success(16)),
                Task.FromResult(Return.Success(32))
            };

            Return<IEnumerable<int>> result = await tasks.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(new[] { 8, 16, 32 });
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_results_success()
        {
            IEnumerable<Return> results = new Return[]
            {
                Return.Success(),
                Return.Success(),
                Return.Success("some-text")
            };
            var task = Task.FromResult(results);

            Return result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_results_failure()
        {
            IEnumerable<Return> results = new Return[]
            {
                Return.Success(),
                Return.Failure<string>("b"),
                Return.Failure<string>("y")
            };
            var task = Task.FromResult(results);

            Return result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("b;y");
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_Generic_results_success()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success("1"),
                Return.Success("3"),
                Return.Success("7")
            };
            var task = Task.FromResult(results);

            Return<IEnumerable<string>> result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo("1", "3", "7");
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_Generic_results_failure()
        {
            IEnumerable<Return<int>> results = new Return<int>[]
            {
                Return.Success<int>(7),
                Return.Failure<int>("b"),
                Return.Failure<int>("2")
            };
            var task = Task.FromResult(results);

            Return<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("b;2");
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_results_success()
        {
            IEnumerable<Task<Return>> tasks = new Task<Return>[]
            {
                Task.FromResult(Return.Success()),
                Task.FromResult(Return.Success()),
                Task.FromResult((Return)Return.Success("some-text"))
            };
            Task<IEnumerable<Task<Return>>> task = Task.FromResult(tasks);

            Return result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_results_failure()
        {
            IEnumerable<Task<Return>> tasks = new Task<Return>[]
            {
                Task.FromResult(Return.Success()),
                Task.FromResult(Return.Failure("x")),
                Task.FromResult(Return.Failure("y")),
                Task.FromResult(Return.Failure("z"))
            };
            Task<IEnumerable<Task<Return>>> task = Task.FromResult(tasks);

            Return result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("x;y;z");
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_success()
        {
            IEnumerable<Task<Return<int>>> tasks = new Task<Return<int>>[]
            {
                Task.FromResult(Return.Success(7)),
                Task.FromResult(Return.Success(77)),
                Task.FromResult(Return.Success(777))
            };
            Task<IEnumerable<Task<Return<int>>>> task = Task.FromResult(tasks);

            Return<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(7, 77, 777);
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_failure()
        {
            IEnumerable<Task<Return<int>>> tasks = new Task<Return<int>>[]
            {
                Task.FromResult(Return.Success(13)),
                Task.FromResult(Return.Failure<int>("error")),
                Task.FromResult(Return.Failure<int>("fail"))
            };
            Task<IEnumerable<Task<Return<int>>>> task = Task.FromResult(tasks);

            Return<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("error;fail");
        }

        [Fact]
        public async Task Combine_works_with_task_with_collection_of_tasks_of_Generic_results_failure_with_identical_errors_aggregated_with_count()
        {
            IEnumerable<Task<Return<int>>> tasks = new Task<Return<int>>[]
            {
                Task.FromResult(Return.Success(13)),
                Task.FromResult(Return.Failure<int>("error")),
                Task.FromResult(Return.Failure<int>("error")),
                Task.FromResult(Return.Failure<int>("fail"))
            };
            Task<IEnumerable<Task<Return<int>>>> task = Task.FromResult(tasks);

            Return<IEnumerable<int>> result = await task.Combine(";");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("error (2×);fail");
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Return<int>> results = new Return<int>[]
            {
                Return.Success(10),
                Return.Success(20),
                Return.Success(30),
            };

            Return<double> result = results.Combine(values => (double)values.Max() / 100, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.3);
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success("one"),
                Return.Success("five"),
                Return.Success("three"),
                Return.Failure<string>("error 1"),
                Return.Failure<string>("error 2")
            };

            Return<string> result = results.Combine(values => values.OrderBy(e => e.Length).First(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("error 1;error 2");
        }

        [Fact]
        public void Combine_works_with_collection_of_results_and_compose_to_new_result_failure_with_identical_errors_aggregated_with_count()
        {
            IEnumerable<Return<string>> results = new Return<string>[]
            {
                Return.Success("one"),
                Return.Success("five"),
                Return.Success("three"),
                Return.Failure<string>("error 1"),
                Return.Failure<string>("error 1"),
                Return.Failure<string>("error 2")
            };

            Return<string> result = results.Combine(values => values.OrderBy(e => e.Length).First(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("error 1 (2×);error 2");
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Return<int>>> tasks = new Task<Return<int>>[]
            {
                Task.FromResult(Return.Success(90)),
                Task.FromResult(Return.Success(95)),
                Task.FromResult(Return.Success(99)),
            };

            Return<double> result = await tasks.Combine(values => (double)values.Min() / 1000, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.09);
        }

        [Fact]
        public async Task Combine_works_with_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Return<string>>> tasks = new Task<Return<string>>[]
            {
                Task.FromResult(Return.Success("ho")),
                Task.FromResult(Return.Success("Hi")),
                Task.FromResult(Return.Success("No")),
                Task.FromResult(Return.Failure<string>("exc 1")),
                Task.FromResult(Return.Failure<string>("exc 2"))
            };

            Return<string> result = await tasks.Combine(values => values.Min(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("exc 1;exc 2");
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_success()
        {
            IEnumerable<Task<Return<int>>> tasks = new Task<Return<int>>[]
            {
                Task.FromResult(Return.Success(90)),
                Task.FromResult(Return.Success(95)),
                Task.FromResult(Return.Success(99)),
            };
            Task<IEnumerable<Task<Return<int>>>> task = Task.FromResult(tasks);

            Return<double> result = await task.Combine(values => (double)values.Max() / 100, ";");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(.99);
        }

        [Fact]
        public async Task Combine_works_with_task_of_collection_of_tasks_of_results_and_compose_to_new_result_failure()
        {
            IEnumerable<Task<Return<string>>> tasks = new Task<Return<string>>[]
            {
                Task.FromResult(Return.Success("ho")),
                Task.FromResult(Return.Success("Hi")),
                Task.FromResult(Return.Success("No")),
                Task.FromResult(Return.Failure<string>("e 1")),
                Task.FromResult(Return.Failure<string>("e 2"))
            };
            Task<IEnumerable<Task<Return<string>>>> task = Task.FromResult(tasks);

            Return<string> result = await task.Combine(values => values.Max(), ";");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("e 1;e 2");
        }
    }
}

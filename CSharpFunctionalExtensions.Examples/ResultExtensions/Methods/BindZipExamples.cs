using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Examples.ResultExtensions.Methods
{
    public class BindZipExamples
    {
        public async Task BindZipAsyncSample()
        {
            await FetchFirstEntity()
                .BindZip(FetchSecondEntity)
                .Map(x => $"{x.First}, {x.Second}!");

            return;

            Task<Return<string>> FetchFirstEntity() =>
                Task.FromResult(Return.Success("Hello"));

            Return<string> FetchSecondEntity(string _) =>
                "World";
        }
    }
}

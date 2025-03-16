using System;


namespace CSharpFunctionalExtensions.Examples.ResultExtensions
{
    public class PassingResultThroughOnSuccessMethods
    {
        public void Example1()
        {
            Return<DateTime> result = FunctionInt()
                .Bind(x => FunctionString(x))
                .Bind(x => FunctionDateTime(x));
        }

        public void Example2()
        {
            Return<DateTime> result = FunctionInt()
                .Bind(_ => FunctionString())
                .Bind(x => FunctionDateTime(x));
        }

        private Return<int> FunctionInt()
        {
            return Return.Success(1);
        }

        private Return<string> FunctionString(int intValue)
        {
            return Return.Success("Ok");
        }

        private Return<string> FunctionString()
        {
            return Return.Success("Ok");
        }

        private Return<DateTime> FunctionDateTime(string stringValue)
        {
            return Return.Success(DateTime.Now);
        }
    }
}

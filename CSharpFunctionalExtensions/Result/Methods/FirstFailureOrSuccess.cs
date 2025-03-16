namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        /// <summary>
        ///     Returns the first failure from the supplied <paramref name="results"/>.
        ///     If there is no failure, a success result is returned.
        /// </summary>
        public static Return FirstFailureOrSuccess(params Return[] results)
        {
            foreach (Return result in results)
            {
                if (result.IsFailure)
                    return result;
            }

            return Success();
        }
    }
}

using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Return
    {
        public static class Configuration
        {
            public static string ErrorMessagesSeparator = ", ";

            public static bool DefaultConfigureAwait = false;

            public static Func<Exception, Exception> DefaultTryErrorHandler = exc => exc;    
        }
    }
}

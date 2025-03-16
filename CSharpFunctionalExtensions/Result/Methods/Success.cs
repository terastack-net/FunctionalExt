namespace FunctionalReturn
{
    public partial struct Return
    {
        /// <summary>
        ///     Creates a success result.
        /// </summary>
        public static Return Success()
        {
            return new Return(false, default);
        }

        /// <summary>
        ///     Creates a success result containing the given value.
        /// </summary>
        public static Return<T> Success<T>(T value)
        {
            return new Return<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a success result containing the given value.
        /// </summary>
        public static Return<T, E> Success<T, E>(T value)
        {
            return new Return<T, E>(false, default, value);
        }

        /// <summary>
        ///     Creates a success result containing the given error.
        /// </summary>
        public static UnitResult<E> Success<E>()
        {
            return new UnitResult<E>(false, default);
        }
    }
}

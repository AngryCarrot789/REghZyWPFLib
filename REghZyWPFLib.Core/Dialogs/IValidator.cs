namespace REghZyWPFLib.Core.Dialogs {
    public interface IValidator<in T> {
        /// <summary>
        /// Validates the given data
        /// </summary>
        /// <exception cref="ValidationFailedException">The data is invalid or unacceptable</exception>
        /// <param name="data">The data to validate</param>
        void Validate(T data);
    }
}
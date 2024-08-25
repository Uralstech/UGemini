namespace Uralstech.UGemini
{
    /// <summary>
    /// An interface for data that is to be appended to at runtime.
    /// </summary>
    /// <typeparam name="T">The type that can be appended to the <see cref="IAppendableData{T}"/>.</typeparam>
    public interface IAppendableData<T>
    {
        /// <summary>
        /// Appends the <paramref name="data"/> to the current <see cref="IAppendableData{T}"/>.
        /// </summary>
        /// <param name="data">The data to append.</param>
        public void Append(T data);
    }
}

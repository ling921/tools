namespace Ling.Tools.Random;

/// <summary>
/// Interface for generating a <typeparamref name="T"/> value.
/// </summary>
/// <typeparam name="T">The type of value to generate.</typeparam>
public interface IGenerator<T> where T : notnull
{
    /// <summary>
    /// Generates a <typeparamref name="T"/> value.
    /// </summary>
    /// <returns>Returns the generated <typeparamref name="T"/> value.</returns>
    T Generate();
}

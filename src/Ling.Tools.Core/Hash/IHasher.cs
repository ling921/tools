using System.Diagnostics.CodeAnalysis;

namespace Ling.Tools.Hash;

/// <summary>
/// Represents a hashing processor interface.
/// </summary>
public interface IHasher : IDisposable
{
    /// <summary>
    /// Computes the hash of the given plain text.
    /// </summary>
    /// <param name="plainText">The plain text to hash.</param>
    /// <returns>The hashed result. If the plain text is null, returns null.</returns>
    [return: NotNullIfNotNull(nameof(plainText))]
    string? ComputeHash(string? plainText);
}

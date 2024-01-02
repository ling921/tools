using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Ling.Tools.Hash;

/// <summary>
/// Represents a hashing processor.
/// </summary>
public class Hasher : IHasher
{
    private bool disposed;

    /// <summary>
    /// Gets the hashing algorithm.
    /// </summary>
    public HashAlgorithm Algorithm { get; protected set; } = default!;

    /// <summary>
    /// Constructor for inheritance
    /// </summary>
    protected Hasher() { }

    /// <summary>
    /// Initialize a new <see cref="Hasher"/>.
    /// </summary>
    /// <param name="type">The hash algorithm type.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public Hasher(HashAlgorithmType type)
    {
        Algorithm = type switch
        {
            HashAlgorithmType.SHA1 => SHA1.Create(),
            HashAlgorithmType.SHA256 => SHA256.Create(),
            HashAlgorithmType.SHA384 => SHA384.Create(),
            HashAlgorithmType.SHA512 => SHA512.Create(),
            HashAlgorithmType.SHA3_256 => SHA3_256.Create(),
            HashAlgorithmType.SHA3_384 => SHA3_384.Create(),
            HashAlgorithmType.SHA3_512 => SHA3_512.Create(),
            HashAlgorithmType.MD5 => MD5.Create(),
            _ => throw new InvalidOperationException()
        };
    }

    /// <inheritdoc/>
    [return: NotNullIfNotNull(nameof(plainText))]
    public virtual string? ComputeHash(string? plainText)
    {
        if (plainText is null) return null;

        var bytes = Encoding.UTF8.GetBytes(plainText);
        var hash = Algorithm.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    /// <summary>
    /// Dispose the managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">Whether to dispose managed resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Algorithm?.Dispose();
            }

            disposed = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

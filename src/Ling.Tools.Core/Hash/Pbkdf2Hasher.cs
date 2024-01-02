using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Ling.Tools.Hash;

/// <summary>
/// Represents a hashing processor for PBKDF2.
/// </summary>
public sealed class Pbkdf2Hasher : Hasher
{
    private readonly HashAlgorithmName _algorithmName;
    private readonly byte[] _salt;
    private readonly int _iterations;
    private readonly int _outputLength;

    /// <summary>
    /// Initialize a new <see cref="Pbkdf2Hasher"/>.
    /// </summary>
    /// <param name="type">The hash algorithm type.</param>
    /// <param name="salt">The salt.</param>
    /// <param name="iterations">The number of iterations.</param>
    /// <param name="outputLength">The output length.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public Pbkdf2Hasher(HashAlgorithmType type, string salt, int iterations, int outputLength)
    {
        _algorithmName = type switch
        {
            HashAlgorithmType.SHA1 => HashAlgorithmName.SHA1,
            HashAlgorithmType.SHA256 => HashAlgorithmName.SHA256,
            HashAlgorithmType.SHA384 => HashAlgorithmName.SHA384,
            HashAlgorithmType.SHA512 => HashAlgorithmName.SHA512,
            HashAlgorithmType.SHA3_256 => HashAlgorithmName.SHA3_256,
            HashAlgorithmType.SHA3_384 => HashAlgorithmName.SHA3_384,
            HashAlgorithmType.SHA3_512 => HashAlgorithmName.SHA3_512,
            HashAlgorithmType.MD5 => HashAlgorithmName.MD5,
            _ => throw new InvalidOperationException()
        };

        _salt = Encoding.UTF8.GetBytes(salt);
        _iterations = iterations;
        _outputLength = outputLength;
    }

    /// <inheritdoc/>
    [return: NotNullIfNotNull(nameof(plainText))]
    public override string? ComputeHash(string? plainText)
    {
        if (plainText is null) return null;

        var bytes = Encoding.UTF8.GetBytes(plainText);
        var hash = Rfc2898DeriveBytes.Pbkdf2(bytes, _salt, _iterations, _algorithmName, _outputLength);
        return Convert.ToBase64String(hash);
    }
}

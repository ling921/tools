using System.Security.Cryptography;
using System.Text;

namespace Ling.Tools.Hash;

/// <summary>
/// Represents a hashing processor that uses the HMAC algorithm.
/// </summary>
public sealed class HmacHasher : Hasher
{
    /// <summary>
    /// Initialize a new <see cref="HmacHasher"/>.
    /// </summary>
    /// <param name="type">The hash algorithm type.</param>
    /// <param name="key">The key.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public HmacHasher(HashAlgorithmType type, string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var bytes = Encoding.UTF8.GetBytes(key);

        Algorithm = type switch
        {
            HashAlgorithmType.SHA1 => new HMACSHA1(bytes),
            HashAlgorithmType.SHA256 => new HMACSHA256(bytes),
            HashAlgorithmType.SHA384 => new HMACSHA384(bytes),
            HashAlgorithmType.SHA512 => new HMACSHA512(bytes),
            HashAlgorithmType.SHA3_256 => new HMACSHA3_256(bytes),
            HashAlgorithmType.SHA3_384 => new HMACSHA3_384(bytes),
            HashAlgorithmType.SHA3_512 => new HMACSHA3_512(bytes),
            HashAlgorithmType.MD5 => new HMACMD5(bytes),
            _ => throw new InvalidOperationException()
        };
    }
}

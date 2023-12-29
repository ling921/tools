using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Ling.Tools.Hash;

/// <summary>
/// Represents a hashing processor.
/// </summary>
public sealed class Hasher : IDisposable
{
    private readonly HashAlgorithm algorithm;

    /// <summary>
    /// Gets the hashing algorithm to use.
    /// </summary>
    public HashType Type { get; init; }

    /// <summary>
    /// Gets whether to use HMAC algorithm.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Key))]
    public bool UseHmac { get; init; }

    /// <summary>
    /// Gets or sets the key to use for HMAC algorithm.
    /// </summary>
    public string? Key { get; private set; }

    private Hasher(HashType type, bool keyed = false)
    {
        Type = type;
        UseHmac = keyed;
        algorithm = type switch
        {
            HashType.SHA1 => keyed ? new HMACSHA1() : System.Security.Cryptography.SHA1.Create(),
            HashType.SHA256 => keyed ? new HMACSHA256() : System.Security.Cryptography.SHA256.Create(),
            HashType.SHA384 => keyed ? new HMACSHA384() : System.Security.Cryptography.SHA384.Create(),
            HashType.SHA512 => keyed ? new HMACSHA512() : System.Security.Cryptography.SHA512.Create(),
            HashType.SHA3_256 => keyed ? new HMACSHA3_256() : System.Security.Cryptography.SHA3_256.Create(),
            HashType.SHA3_384 => keyed ? new HMACSHA3_384() : System.Security.Cryptography.SHA3_384.Create(),
            HashType.SHA3_512 => keyed ? new HMACSHA3_512() : System.Security.Cryptography.SHA3_512.Create(),
            HashType.MD5 => keyed ? new HMACMD5() : System.Security.Cryptography.MD5.Create(),
            _ => throw new InvalidOperationException()
        };
    }

    /// <summary>
    /// Sets the key to use for HMAC algorithm.
    /// </summary>
    /// <param name="key">The key to use.</param>
    public void SetKey(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        if (!UseHmac) throw new InvalidOperationException();

        Key = key;
    }

    /// <summary>
    /// Computes the hash of the given plain text.
    /// </summary>
    /// <param name="plainText">The plain text to hash.</param>
    /// <returns>The hashed result.</returns>
    [return: NotNullIfNotNull(nameof(plainText))]
    public string? ComputeHash(string? plainText)
    {
        if (plainText is null) return null;

        var bytes = Encoding.UTF8.GetBytes(plainText);
        var hash = algorithm.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        algorithm?.Dispose();
    }

    public static Hasher SHA1() => new(HashType.SHA1);
    public static Hasher HmacSHA1(string key) => new(HashType.SHA1, true) { Key = key };
    public static Hasher SHA256() => new(HashType.SHA256);
    public static Hasher HmacSHA256(string key) => new(HashType.SHA256, true) { Key = key };
    public static Hasher SHA384() => new(HashType.SHA384);
    public static Hasher HmacSHA384(string key) => new(HashType.SHA384, true) { Key = key };
    public static Hasher SHA512() => new(HashType.SHA512);
    public static Hasher HmacSHA512(string key) => new(HashType.SHA512, true) { Key = key };
    public static Hasher MD5() => new(HashType.MD5);
    public static Hasher HmacMD5(string key) => new(HashType.MD5, true) { Key = key };
}

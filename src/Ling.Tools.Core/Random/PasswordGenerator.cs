using System.Diagnostics;
using System.Text;

namespace Ling.Tools.Random;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class PasswordGenerator : IGenerator<string>
{
    public const string NUMBERS = "0123456789";
    public const string LOWERCASE_LETTERS = "abcdefghijklmnopqrstuvwxyz";
    public const string UPPERCASE_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string SPECIAL_CHARACTERS = "`~!@#$%^&()-_=+[{]};:'\",<.>/?\\|";

    private char[] _allowedNumbers = NUMBERS.ToCharArray();
    private char[] _allowedLowercaseLetters = LOWERCASE_LETTERS.ToCharArray();
    private char[] _allowedUppercaseLetters = UPPERCASE_LETTERS.ToCharArray();
    private char[] _allowedSpecialChars = SPECIAL_CHARACTERS.ToCharArray();
    private int _length = 16;
    private CharType _allowedCharTyppes = CharType.None;

    private string DebuggerDisplay => new StringBuilder()
        .Append("Length: ")
        .Append(_length)
        .Append(", Characters: ")
        .AppendIf(_allowedCharTyppes.HasFlag(CharType.Number), _allowedNumbers)
        .AppendIf(_allowedCharTyppes.HasFlag(CharType.LowercaseLetter), _allowedLowercaseLetters)
        .AppendIf(_allowedCharTyppes.HasFlag(CharType.UppercaseLetter), _allowedUppercaseLetters)
        .AppendIf(_allowedCharTyppes.HasFlag(CharType.SpecialCharacter), _allowedSpecialChars)
        .ToString();

    public PasswordGenerator SetLength(int length)
    {
        _length = length;
        return this;
    }

    public PasswordGenerator AllowNumbers()
    {
        _allowedCharTyppes |= CharType.Number;
        _allowedNumbers = NUMBERS.ToCharArray();
        return this;
    }

    public PasswordGenerator AllowNumbers(ReadOnlySpan<char> numbers)
    {
        _allowedCharTyppes |= CharType.Number;

        var allowedNumbers = new List<char>(NUMBERS.Length);
        foreach (var number in numbers)
        {
            if (NUMBERS.Contains(number))
            {
                allowedNumbers.Add(number);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(numbers), $"'{number}' is not a valid number.");
            }
        }

        if (allowedNumbers.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numbers), "Numbers cannot be empty.");
        }

        _allowedNumbers = [.. allowedNumbers];

        return this;
    }

    public PasswordGenerator AllowAlphabet()
    {
        _allowedCharTyppes |= CharType.Alphabet;
        _allowedLowercaseLetters = LOWERCASE_LETTERS.ToCharArray();
        _allowedUppercaseLetters = UPPERCASE_LETTERS.ToCharArray();
        return this;
    }

    public PasswordGenerator AllowLowercaseLetters()
    {
        _allowedCharTyppes |= CharType.LowercaseLetter;
        _allowedLowercaseLetters = LOWERCASE_LETTERS.ToCharArray();
        return this;
    }

    public PasswordGenerator AllowLowercaseLetters(ReadOnlySpan<char> letters)
    {
        _allowedCharTyppes |= CharType.LowercaseLetter;

        var allowedLetters = new List<char>(LOWERCASE_LETTERS.Length);
        foreach (var letter in letters)
        {
            if (LOWERCASE_LETTERS.Contains(letter))
            {
                allowedLetters.Add(letter);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(letters), $"'{letter}' is not a valid lowercase letter.");
            }
        }

        if (allowedLetters.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(letters), "Letters cannot be empty.");
        }

        _allowedLowercaseLetters = [.. allowedLetters];

        return this;
    }

    public PasswordGenerator AllowUppercaseLetters()
    {
        _allowedCharTyppes |= CharType.UppercaseLetter;
        _allowedUppercaseLetters = UPPERCASE_LETTERS.ToCharArray();
        return this;
    }

    public PasswordGenerator AllowUppercaseLetters(ReadOnlySpan<char> letters)
    {
        _allowedCharTyppes |= CharType.UppercaseLetter;

        var allowedLetters = new List<char>(UPPERCASE_LETTERS.Length);
        foreach (var letter in letters)
        {
            if (UPPERCASE_LETTERS.Contains(letter))
            {
                allowedLetters.Add(letter);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(letters), $"'{letter}' is not a valid uppercase letter.");
            }
        }

        if (allowedLetters.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(letters), "Letters cannot be empty.");
        }

        _allowedUppercaseLetters = [.. allowedLetters];

        return this;
    }

    public PasswordGenerator AllowSpecialCharacters()
    {
        _allowedCharTyppes |= CharType.SpecialCharacter;
        _allowedSpecialChars = SPECIAL_CHARACTERS.ToCharArray();
        return this;
    }

    public PasswordGenerator AllowSpecialCharacters(ReadOnlySpan<char> specialChars)
    {
        _allowedCharTyppes |= CharType.SpecialCharacter;

        var allowedSpecialChars = new List<char>(SPECIAL_CHARACTERS.Length);
        foreach (var c in specialChars)
        {
            if (SPECIAL_CHARACTERS.Contains(c))
            {
                allowedSpecialChars.Add(c);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(specialChars), $"'{c}' is not a valid special character.");
            }
        }

        if (allowedSpecialChars.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(specialChars), "Special characters cannot be empty.");
        }

        _allowedSpecialChars = [.. allowedSpecialChars];

        return this;
    }

    public string Generate()
    {
        throw new NotImplementedException();
    }

    [Flags]
    private enum CharType : byte
    {
        None = 0b0000,
        Number = 0b0001,
        LowercaseLetter = 0b0010,
        UppercaseLetter = 0b0100,
        SpecialCharacter = 0b1000,

        Alphabet = UppercaseLetter | LowercaseLetter,
    }
}

/// <file>  CaesarCipher\CeaserCipherAlphabet.cs </file>
///
/// <copyright file="CeaserCipherAlphabet.cs" company="Guldmann">
/// Copyright (c) 2022 Guldmann. All rights reserved.
/// </copyright>
///
/// <summary>   Simple class providing alphabents that can be used with the <see cref="CaesarCipher.CaeserCipherEncryption"/> class.</summary>
namespace CaesarCipher
{
    using System.Collections.Immutable;

    public static class CaeserCipherAlphabet
    {
        public static readonly ImmutableArray<char> English = ImmutableArray.Create('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    }
}

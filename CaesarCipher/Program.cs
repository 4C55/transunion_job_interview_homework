/// <file>  CaesarCipher\Program.cs </file>
///
/// <copyright file="Program.cs" company="Guldmann">
/// Copyright (c) 2022 Guldmann. All rights reserved.
/// </copyright>
///
/// <summary>   Provides example use of <see cref="CaesarCipher.CeaserCipherEncryption"/>. </summary>
namespace CaesarCipher
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            CeaserCipherEncryption ceaserCipher = new CeaserCipherEncryption(CeaserCipherAlphabet.English, 4);


            String text = "HELLOWORLD";
            String cipher = ceaserCipher.Encrypt(text);

            Console.WriteLine($"Encrypted string \"{text}\" resulted in cipher \"{cipher}\"");
            Console.WriteLine($"Decrypting the cipher \"{cipher}\" resulted in string \"{ceaserCipher.Decrypt(cipher)}\"");
        }
    }
}

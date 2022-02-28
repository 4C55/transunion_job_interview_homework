/// <file>  CaesarCipher\Program.cs </file>
///
/// <copyright file="Program.cs" company="Guldmann">
/// Copyright (c) 2022 Guldmann. All rights reserved.
/// </copyright>
///
/// <summary>   Provides example use of <see cref="CaesarCipher.CaeserCipherEncryption"/>. </summary>
namespace CaesarCipher
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            CaeserCipherEncryption caeserCipher = new CaeserCipherEncryption(CaeserCipherAlphabet.English, 4);


            String text = "HELLOWORLD";
            String cipher = caeserCipher.Encrypt(text);

            Console.WriteLine($"Encrypted string \"{text}\" resulted in cipher \"{cipher}\"");
            Console.WriteLine($"Decrypting the cipher \"{cipher}\" resulted in string \"{caeserCipher.Decrypt(cipher)}\"");
        }
    }
}

/// <file>  CaesarCipher\CeaserCipherEncryption.cs </file>
///
/// <copyright file="CeaserCipherEncryption.cs">
/// Copyright (c) 2022 Guldmann. All rights reserved.
/// </copyright>
///
/// <summary>   Implements the ceaser cipher encryption class. </summary>
namespace CaesarCipher
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    public class CaeserCipherEncryption
    {
        private readonly ImmutableArray<char> _alphabet;

        private readonly Dictionary<char, int> _characterToIndexMap;

        private readonly int _dictionaryLength;

        private readonly int _key;

        /// <summary>   Creates a new instance of the CeaserCipherEncryption. </summary>
        ///
        /// <remarks>   Lau, 2022-02-28. </remarks>
        ///
        /// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or
        /// illegal values. </exception>
        ///
        /// <param name="alphabet"> The alphabet of the encryption. Must contain unique character in the
        /// desired order. </param>
        /// <param name="key">      The key of the encryption. </param>
        public CaeserCipherEncryption(ImmutableArray<char> alphabet, int key)
        {
            this._alphabet = alphabet;
            this._dictionaryLength = alphabet.Length;
            this._key = key;

            this._characterToIndexMap = new Dictionary<char, int>();
            
            for (int i = 0; i < this._alphabet.Length; i++)
            {
                if (this._characterToIndexMap.ContainsKey(this._alphabet[i]))
                {
                    throw new ArgumentException("Provided alphabet array contains duplicate symbols.");
                }
                else
                {
                    this._characterToIndexMap.Add(this._alphabet[i], i);
                }
            }
        }

        /// <summary>   Encrypts provided string into cipher. </summary>
        ///
        /// <param name="text"> The text to encrypt. </param>
        ///
        /// <returns>   The cipher of the provided text. </returns>
        public string Encrypt(string text)
        {
            return this.ShiftCharacters(text, this._key);
        }

        /// <summary>   Decrypts the provided cipher into text. </summary>
        ///
        /// <param name="cipher"> The cipher to decrypt. </param>
        ///
        /// <returns>   The decrypted cipher. </returns>
        public string Decrypt(string cipher)
        {
            return this.ShiftCharacters(cipher, -this._key);
        }

        /// <summary>   Shift characters of the string by the provided offset. </summary>
        ///
        /// <remarks>
        /// This fucntion produces an output string by taking the input string's characters and replacing
        /// them with a corresponding character in the dictioary with the specified offset. Positive and
        /// negative offsets are allowed specifying characters after and before.
        /// </remarks>
        ///
        /// <exception cref="ArgumentException"> Thrown when the input string contains a character outside the configured dictioray. </exception>
        ///
        /// <param name="inputString">  The input string. </param>
        /// <param name="offset">       Amount to shift characters by. </param>
        ///
        /// <returns>   String containing the shifted characters of the input string. </returns>
        private String ShiftCharacters(String inputString, int offset)
        {
            try
            {
                IEnumerable<char> shiftedCharacters = inputString
                    .ToCharArray()
                    .Select(character => this.GetCharacterAtPosition(this._characterToIndexMap[character] + offset));

                return new string(shiftedCharacters.ToArray());
            }
            catch (KeyNotFoundException excpetion)
            {
                throw new ArgumentException("Provided input contains symbols that are not part of the configured dictioary.", excpetion);
            }
        }

        /// <summary>   Gets character at position from the alphabet. </summary>
        ///
        /// <remarks>
        /// This function takes care of wrapping positive and negative indexes around the boundaries of
        /// the configured dictionary. Any index (positive, negative, outside the length of the
        /// dictioary) will return the correct character in the dictioary.
        /// </remarks>
        ///
        /// <param name="position"> The position. </param>
        ///
        /// <returns>   The character at position. </returns>
        private char GetCharacterAtPosition(int position)
        {
            return this._alphabet[((position % this._dictionaryLength) + this._dictionaryLength) % this._dictionaryLength];
        }
    }
}

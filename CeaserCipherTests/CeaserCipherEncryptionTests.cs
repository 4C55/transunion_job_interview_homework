/// <file>  CeaserCipherTests\CeaserCipherEncryptionTests.cs </file>
///
/// <copyright file="CeaserCipherEncryptionTests.cs" company="Guldmann">
/// Copyright (c) 2022 Guldmann. All rights reserved.
/// </copyright>
///
/// <summary>   Implements unit tests for the <see cref="CaesarCipher.CeaserCipherEncryption"/> class.</summary>
namespace CeaserCipherTests
{
    using CaesarCipher;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    [TestClass]
    public class CeaserCipherEncryptionTests
    {
        /// <summary>   Unit Test Method checking the scenario when an alphabet with duplicate symbols is provided. </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidAlphabet()
        {
            new CeaserCipherEncryption(ImmutableArray.Create('A', 'B', 'A'), 0);
        }

        /// <summary>   Unit Test Method checking the scenario when an invlaid symbol is being encrypted. </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEncryptionInvalidSymbol()
        {
            CeaserCipherEncryption ceaserCipher = new CeaserCipherEncryption(CeaserCipherAlphabet.English, 1);
            ceaserCipher.Encrypt("HELLO*WORLD");
        }

        /// <summary>   Unit Test Method checking the scenario when an invlaid symbol is being encrypted. </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDecryptionInvalidSymbol()
        {
            CeaserCipherEncryption ceaserCipher = new CeaserCipherEncryption(CeaserCipherAlphabet.English, -1);
            ceaserCipher.Decrypt("HELLOWORLD|");
        }

        /// <summary>   Unit Test Method checking predefined encryption scenarios. </summary>
        [TestMethod]
        [DynamicData(nameof(EncryptionTestCases), DynamicDataSourceType.Property)]
        public void TestEncryption(ImmutableArray<char> alphabet, int key, string text, string expectedCipher)
        {
            CeaserCipherEncryption ceaserCipher = new CeaserCipherEncryption(alphabet, key);
            string actualCipher = ceaserCipher.Encrypt(text);
            Assert.AreEqual(actualCipher, expectedCipher);
        }

        /// <summary>   Unit Test Method checking predefined decryption scenarios. </summary>
        [TestMethod]
        [DynamicData(nameof(DecryptionTestCases), DynamicDataSourceType.Property)]
        public void TestDecryption(ImmutableArray<char> alphabet, int key, string cipher, string expectedText)
        {
            CeaserCipherEncryption ceaserCipher = new CeaserCipherEncryption(alphabet, key);
            string actualText = ceaserCipher.Decrypt(cipher);
            Assert.AreEqual(expectedText, actualText);
        }

        public static IEnumerable<object[]> DecryptionTestCases
        {
            get
            {
                yield return new object[] { CeaserCipherAlphabet.English, 21, "GJIBZMNOMDIBQVGPZAJMOZNON", "LONGERSTRINGVALUEFORTESTS" };
                yield return new object[] { CeaserCipherAlphabet.English, 0, "HELLOWORLD", "HELLOWORLD" };
                yield return new object[] { CeaserCipherAlphabet.English, -1, "QZMCNLSDWS", "RANDOMTEXT" };
                yield return new object[] { CeaserCipherAlphabet.English, -20, "YUSKZNOTM", "SOMETHING" }; 
            }
        }

        public static IEnumerable<object[]> EncryptionTestCases
        {
            get
            {
                yield return new object[] { CeaserCipherAlphabet.English, 0, "HELLOWORLD", "HELLOWORLD" };
                yield return new object[] { CeaserCipherAlphabet.English, 5, "HELLOWORLD", "MJQQTBTWQI" };
                yield return new object[] { CeaserCipherAlphabet.English, -100, "HELLOWORLD", "LIPPSASVPH" };
                yield return new object[] { CeaserCipherAlphabet.English, 55, "RANDOMTEXT", "UDQGRPWHAW" };
            }
        }
    }
}

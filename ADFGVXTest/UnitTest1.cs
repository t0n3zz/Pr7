using NUnit.Framework;
using System;
using pr7;

namespace ADFGVXTest
{
    /// <summary>
    /// Автоматизированные тесты для проверки шифра ADFGVX.
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Проверяет полный цикл шифрования и дешифрования.
        /// </summary>
        [Test]
        public void EncryptDecrypt_ValidText_ReturnsOriginalText()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            string original = "HELLO2026";
            string encrypted = cipher.Encrypt(original);
            string decrypted = cipher.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(original));
            Assert.That(encrypted, Is.Not.EqualTo(original));
        }

        /// <summary>
        /// Проверяет, что результат шифрования содержит только символы ADFGVX.
        /// </summary>
        [Test]
        public void Encrypt_ValidText_ReturnsOnlyAdfgvxSymbols()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            string encrypted = cipher.Encrypt("HELLO2026");

            foreach (char symbol in encrypted)
            {
                Assert.That("ADFGVX", Does.Contain(symbol.ToString()));
            }
        }

        /// <summary>
        /// Проверяет работу с другим ключом матрицы и транспозиции.
        /// </summary>
        [Test]
        public void EncryptDecrypt_WithDifferentKeys_ReturnsOriginalText()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("MATRIX", "TRAIN");

            string original = "TEST123";
            string encrypted = cipher.Encrypt(original);
            string decrypted = cipher.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(original));
        }

        /// <summary>
        /// Проверяет, что пробелы в исходном тексте удаляются при нормализации.
        /// </summary>
        [Test]
        public void EncryptDecrypt_TextWithSpaces_ReturnsTextWithoutSpaces()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            string encrypted = cipher.Encrypt("HELLO 2026");
            string decrypted = cipher.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo("HELLO2026"));
        }

        /// <summary>
        /// Проверяет шифрование текста с цифрами.
        /// </summary>
        [Test]
        public void EncryptDecrypt_TextWithDigits_ReturnsOriginalText()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            string original = "CODE12345";
            string encrypted = cipher.Encrypt(original);
            string decrypted = cipher.Decrypt(encrypted);

            Assert.That(decrypted, Is.EqualTo(original));
        }

        /// <summary>
        /// Проверяет, что пустой текст для шифрования вызывает исключение.
        /// </summary>
        [Test]
        public void Encrypt_EmptyText_ThrowsException()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            Assert.Throws<ArgumentException>(() => cipher.Encrypt(""));
        }

        /// <summary>
        /// Проверяет, что пустой текст для дешифрования вызывает исключение.
        /// </summary>
        [Test]
        public void Decrypt_EmptyText_ThrowsException()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            Assert.Throws<ArgumentException>(() => cipher.Decrypt(""));
        }

        /// <summary>
        /// Проверяет ошибку при пустом ключе матрицы.
        /// </summary>
        [Test]
        public void Constructor_EmptyMatrixKey_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new AdfgvxCipher("", "CARGO"));
        }

        /// <summary>
        /// Проверяет ошибку при пустом ключе транспозиции.
        /// </summary>
        [Test]
        public void Constructor_EmptyTranspositionKey_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new AdfgvxCipher("SECRET", ""));
        }

        /// <summary>
        /// Проверяет ошибку при использовании русских букв в исходном тексте.
        /// </summary>
        [Test]
        public void Encrypt_RussianText_ThrowsException()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            Assert.Throws<ArgumentException>(() => cipher.Encrypt("ПРИВЕТ"));
        }

        /// <summary>
        /// Проверяет ошибку при использовании недопустимых символов в зашифрованном тексте.
        /// </summary>
        [Test]
        public void Decrypt_InvalidCipherSymbols_ThrowsException()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            Assert.Throws<ArgumentException>(() => cipher.Decrypt("ABC123"));
        }

        /// <summary>
        /// Проверяет генерацию матрицы 6x6.
        /// </summary>
        [Test]
        public void GetMatrixAsText_ValidKey_ReturnsMatrixText()
        {
            AdfgvxCipher cipher = new AdfgvxCipher("SECRET", "CARGO");

            string matrix = cipher.GetMatrixAsText();

            Assert.That(matrix, Does.Contain("S"));
            Assert.That(matrix, Does.Contain("E"));
            Assert.That(matrix, Does.Contain("0"));
            Assert.That(matrix, Does.Contain("9"));
        }
    }
}
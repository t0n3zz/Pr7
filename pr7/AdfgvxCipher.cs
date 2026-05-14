using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pr7
{
    /// <summary>
    /// Реализует шифр ADFGVX с матрицей 6x6 и транспозицией по ключу.
    /// </summary>
    public class AdfgvxCipher
    {
        private static readonly char[] Coordinates = { 'A', 'D', 'F', 'G', 'V', 'X' };
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private readonly char[,] _matrix;
        private readonly Dictionary<char, string> _encryptMap;
        private readonly Dictionary<string, char> _decryptMap;
        private readonly string _transpositionKey;

        /// <summary>
        /// Создаёт объект шифра ADFGVX.
        /// </summary>
        /// <param name="matrixKey">Ключевая фраза для генерации матрицы.</param>
        /// <param name="transpositionKey">Ключ для транспозиции.</param>
        public AdfgvxCipher(string matrixKey, string transpositionKey)
        {
            if (string.IsNullOrWhiteSpace(matrixKey))
                throw new ArgumentException("Ключевая фраза для матрицы не может быть пустой.");

            if (string.IsNullOrWhiteSpace(transpositionKey))
                throw new ArgumentException("Ключ транспозиции не может быть пустым.");

            _transpositionKey = NormalizeKey(transpositionKey);
            _matrix = GenerateMatrix(matrixKey);
            _encryptMap = CreateEncryptMap();
            _decryptMap = CreateDecryptMap();
        }

        /// <summary>
        /// Шифрует текст с помощью подстановки и транспозиции.
        /// </summary>
        /// <param name="plainText">Исходный текст.</param>
        /// <returns>Зашифрованный текст.</returns>
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                throw new ArgumentException("Текст для шифрования не может быть пустым.");

            string normalizedText = NormalizeText(plainText);
            string substitutedText = Substitute(normalizedText);

            return Transpose(substitutedText);
        }

        /// <summary>
        /// Дешифрует текст, выполняя обратную транспозицию и обратную подстановку.
        /// </summary>
        /// <param name="cipherText">Зашифрованный текст.</param>
        /// <returns>Расшифрованный текст.</returns>
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
                throw new ArgumentException("Текст для дешифрования не может быть пустым.");

            string normalizedCipherText = NormalizeCipherText(cipherText);
            string substitutedText = ReverseTranspose(normalizedCipherText);

            return ReverseSubstitute(substitutedText);
        }

        /// <summary>
        /// Возвращает матрицу 6x6 в виде строки.
        /// </summary>
        /// <returns>Строковое представление матрицы.</returns>
        public string GetMatrixAsText()
        {
            StringBuilder builder = new StringBuilder();

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    builder.Append(_matrix[row, column]);
                    builder.Append(' ');
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        /// <summary>
        /// Генерирует матрицу 6x6 на основе ключевой фразы.
        /// </summary>
        private char[,] GenerateMatrix(string matrixKey)
        {
            string normalizedKey = NormalizeText(matrixKey);
            string uniqueCharacters = "";

            foreach (char symbol in normalizedKey + Alphabet)
            {
                if (!uniqueCharacters.Contains(symbol))
                    uniqueCharacters += symbol;
            }

            char[,] matrix = new char[6, 6];
            int index = 0;

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    matrix[row, column] = uniqueCharacters[index];
                    index++;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Создаёт таблицу для шифрования символов.
        /// </summary>
        private Dictionary<char, string> CreateEncryptMap()
        {
            Dictionary<char, string> map = new Dictionary<char, string>();

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    string code = $"{Coordinates[row]}{Coordinates[column]}";
                    map[_matrix[row, column]] = code;
                }
            }

            return map;
        }

        /// <summary>
        /// Создаёт таблицу для дешифрования символов.
        /// </summary>
        private Dictionary<string, char> CreateDecryptMap()
        {
            Dictionary<string, char> map = new Dictionary<string, char>();

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {
                    string code = $"{Coordinates[row]}{Coordinates[column]}";
                    map[code] = _matrix[row, column];
                }
            }

            return map;
        }

        /// <summary>
        /// Выполняет этап подстановки.
        /// </summary>
        private string Substitute(string text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (char symbol in text)
            {
                builder.Append(_encryptMap[symbol]);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Выполняет обратную подстановку.
        /// </summary>
        private string ReverseSubstitute(string text)
        {
            if (text.Length % 2 != 0)
                throw new ArgumentException("Длина текста после обратной транспозиции должна быть чётной.");

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < text.Length; i += 2)
            {
                string pair = text.Substring(i, 2);

                if (!_decryptMap.ContainsKey(pair))
                    throw new ArgumentException($"Недопустимая пара символов: {pair}");

                builder.Append(_decryptMap[pair]);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Выполняет транспозицию по ключу.
        /// </summary>
        private string Transpose(string text)
        {
            int keyLength = _transpositionKey.Length;
            List<int> columnOrder = GetColumnOrder();

            StringBuilder result = new StringBuilder();

            foreach (int columnIndex in columnOrder)
            {
                for (int i = columnIndex; i < text.Length; i += keyLength)
                {
                    result.Append(text[i]);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Выполняет обратную транспозицию по ключу.
        /// </summary>
        private string ReverseTranspose(string text)
        {
            int keyLength = _transpositionKey.Length;
            int textLength = text.Length;
            int fullRows = textLength / keyLength;
            int remainingColumns = textLength % keyLength;

            int[] columnLengths = new int[keyLength];

            for (int i = 0; i < keyLength; i++)
            {
                columnLengths[i] = fullRows;

                if (i < remainingColumns)
                    columnLengths[i]++;
            }

            List<int> columnOrder = GetColumnOrder();
            char[][] columns = new char[keyLength][];

            int textIndex = 0;

            foreach (int columnIndex in columnOrder)
            {
                int length = columnLengths[columnIndex];
                columns[columnIndex] = text.Substring(textIndex, length).ToCharArray();
                textIndex += length;
            }

            StringBuilder result = new StringBuilder();

            int rows = (int)Math.Ceiling((double)textLength / keyLength);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < keyLength; column++)
                {
                    if (row < columns[column].Length)
                        result.Append(columns[column][row]);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Возвращает порядок чтения столбцов по ключу транспозиции.
        /// </summary>
        private List<int> GetColumnOrder()
        {
            return _transpositionKey
                .Select((symbol, index) => new { Symbol = symbol, Index = index })
                .OrderBy(item => item.Symbol)
                .ThenBy(item => item.Index)
                .Select(item => item.Index)
                .ToList();
        }

        /// <summary>
        /// Нормализует обычный текст.
        /// </summary>
        private string NormalizeText(string text)
        {
            string upperText = text.ToUpper();
            StringBuilder builder = new StringBuilder();

            foreach (char symbol in upperText)
            {
                if (char.IsWhiteSpace(symbol))
                    continue;

                if (!Alphabet.Contains(symbol))
                    throw new ArgumentException("Текст может содержать только латинские буквы A-Z и цифры 0-9.");

                builder.Append(symbol);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Нормализует ключ транспозиции.
        /// </summary>
        private string NormalizeKey(string key)
        {
            string upperKey = key.ToUpper();
            StringBuilder builder = new StringBuilder();

            foreach (char symbol in upperKey)
            {
                if (char.IsWhiteSpace(symbol))
                    continue;

                if (!Alphabet.Contains(symbol))
                    throw new ArgumentException("Ключ может содержать только латинские буквы A-Z и цифры 0-9.");

                builder.Append(symbol);
            }

            if (builder.Length == 0)
                throw new ArgumentException("Ключ транспозиции не может быть пустым.");

            return builder.ToString();
        }

        /// <summary>
        /// Нормализует зашифрованный текст.
        /// </summary>
        private string NormalizeCipherText(string cipherText)
        {
            string upperText = cipherText.ToUpper();
            StringBuilder builder = new StringBuilder();

            foreach (char symbol in upperText)
            {
                if (char.IsWhiteSpace(symbol))
                    continue;

                if (!Coordinates.Contains(symbol))
                    throw new ArgumentException("Зашифрованный текст может содержать только символы A, D, F, G, V, X.");

                builder.Append(symbol);
            }

            return builder.ToString();
        }
    }
}
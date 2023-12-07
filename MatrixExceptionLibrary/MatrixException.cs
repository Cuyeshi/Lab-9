using System;

namespace MatrixExceptionLibrary
{
    /// <summary>
    /// Класс с методами исключения.
    /// </summary>
    public class MatrixException : Exception
    {
        public int ErrorCode { get; }

        public MatrixException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Метод исключения для переменных типа Double.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="MatrixException"></exception>
        public static void ValidateDouble(string input, out double result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new MatrixException("Строка пуста!", 1);
            }

            if (!double.TryParse(input, out result))
            {
                throw new MatrixException("Строка содержит символ или текст!", 2);
            }
        }

        /// <summary>
        /// Метод исключения для переменных тип Int.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="MatrixException"></exception>
        public static void ValidateInt(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new MatrixException("Строка пуста!", 1);
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new MatrixException("Строка содержит вещественное число или текст!", 2);
            }
        }

        /// <summary>
        /// Метод исключения для значений выбора в меню.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="MatrixException"></exception>
        public static void ValidateChoice(string input, out int result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new MatrixException("Строка пуста!\n", 1);
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new MatrixException("Строка содержит вещественное число или текст!\n", 2);
            }
        }
    }
}

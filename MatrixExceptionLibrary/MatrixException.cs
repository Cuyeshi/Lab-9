using System;

namespace MatrixExceptionLibrary
{
    /// <summary>
    /// Класс с методами исключения.
    /// </summary>
    public class MatrixException : Exception
    {
        /// <summary>
        /// Конструктор для создания исключений.
        /// </summary>
        /// <param name="message"></param>
        public MatrixException(string message) : base(message)
        {
           
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
                throw new MatrixException("Строка пуста. Ожидалось вещественное число.");
            }

            if (!double.TryParse(input, out result))
            {
                throw new MatrixException("Строка содержит неподходящее значение. Ожидалось вещественное число.");
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
                throw new MatrixException("Строка пуста. Ожидалось целое число.");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new MatrixException("Строка содержит неподходящее значение. Ожидалось целое число.");
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
                throw new MatrixException("Строка пуста. Ожидалось целое число.\n");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new MatrixException("Строка содержит неподходящее значение. Ожидалось целое число.\n");
            }
        }
    }
}

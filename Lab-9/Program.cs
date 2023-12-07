using System;
using LibraryForMatrix;


namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Matrixs matrixA = new Matrixs(), matrixB = new Matrixs(), matrixC = new Matrixs(); // Создание переменных типа Matrixs.
            int lineA, columnA, lineB, columnB, choice = 0; // Создание переменных для обозначения строчек и столбцов матриц.
            double[,] valuesA = new double[1000, 1000], valuesB = new double[1000, 1000]; // Создание двумерных массивов для обозначения элементов матриц.
            bool inputValid = false;

            while (!inputValid)
            {
                try
                {
                    Console.Write("Введите число строк для матрицы А: ");
                    string inputLineA = Console.ReadLine();
                    MatrixException.ValidateInt(inputLineA, out lineA);
                    Console.Write("\nВведите число столбцов для матрицы А: ");
                    string inputColumnA = Console.ReadLine();
                    MatrixException.ValidateInt(inputColumnA, out columnA);
                    Console.Write("\nВведите число строк для матрицы B: ");
                    string inputLineB = Console.ReadLine();
                    MatrixException.ValidateInt(inputLineB, out lineB);
                    Console.Write("\nВведите число столбцов для матрицы B: ");
                    string inputColumnB = Console.ReadLine();
                    MatrixException.ValidateInt(inputColumnB, out columnB);
                    Console.Write("\nВведите значение для матрицы A(запись по строке): ");
                    valuesA = Program.InputMatrix(lineA, columnA);
                    Console.Write("\nВведите значение для матрицы B(запись по строке): ");
                    valuesB = Program.InputMatrix(lineB, columnB);
                    matrixA = new Matrixs(lineA, columnA, valuesA); // Метод создания матрицы из полученной информации.
                    matrixB = new Matrixs(lineB, columnB, valuesB);

                    inputValid = true;
                }
                catch (MatrixException ex)
                {
                    Console.Clear();
                    Console.WriteLine($"Ошибочный ввод (Код {ex.ErrorCode}): {ex.Message}");
                }
            }

            bool isRun = true;  // Присваивание переменной IsRun значения true.

            while (isRun) // Консольное меню.
            {
                Console.WriteLine("\n          Выберите действие:");
                Console.WriteLine(" ----------------------------------------");
                Console.WriteLine("|          1 - Вывод Матрицы A;          |");
                Console.WriteLine("|          2 - Вывод Матрицы B;          |");
                Console.WriteLine("|     3 - Перемножение Матриц A и B;     |");
                Console.WriteLine("|     4 - Умножение Матрицы на число;    |");
                Console.WriteLine("|        0 - Выход из программы;         |");
                Console.WriteLine(" ----------------------------------------\n");

                bool ValidateChoice = false;
                while (!ValidateChoice)
                {
                    try
                    {
                        string inputChoice = Console.ReadLine();
                        MatrixException.ValidateChoice(inputChoice, out choice);

                        ValidateChoice = true;
                    }
                    catch (MatrixException ex)
                    {
                        Console.WriteLine($"Ошибочный ввод (Код {ex.ErrorCode}): {ex.Message}");
                    }
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n");
                        Program.OutputMatrix(matrixA);  // Метод вывода матрицы А.
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        Program.OutputMatrix(matrixB); // Метод вывода матрицы Б.
                        break;

                    case 3:
                        Console.WriteLine("\n");
                        matrixC = matrixA * matrixB; // Операция умножения матриц.
                        if (matrixC.Line != 0)
                        {
                            Program.OutputMatrix(matrixC);
                        }
                        else
                        {
                            Console.WriteLine("Умножение не возможно.");
                        }
                        break;

                    case 4:
                        bool input = true;
                        double number = 0;
                        Console.WriteLine("\nВведите число, на которое будете умножать.");
                        bool ValidateNumber = false;
                        while (!ValidateNumber)
                        {
                            try
                            {
                                string inputNumber = Console.ReadLine();
                                MatrixException.ValidateDouble(inputNumber, out number);

                                ValidateNumber = true;
                            }
                            catch (MatrixException ex)
                            {
                                Console.WriteLine($"Ошибочный ввод (Код {ex.ErrorCode}): {ex.Message}");
                            }
                        }

                        while (input)
                        {
                            Console.Write("\nВыберите Матрицу(A - 1, B - 2, C - 3, Выход - 0): ");

                            ValidateChoice = false;
                            while (!ValidateChoice)
                            {
                                try
                                {
                                    string inputChoice = Console.ReadLine();
                                    MatrixException.ValidateChoice(inputChoice, out choice);

                                    ValidateChoice = true;
                                }
                                catch (MatrixException ex)
                                {
                                    Console.WriteLine($"Ошибочный ввод (Код {ex.ErrorCode}): {ex.Message}");
                                }
                            }

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("\n");
                                    matrixA = number * matrixA; // Операция умножения матрицы на число.
                                    Program.OutputMatrix(matrixA);
                                    input = false;
                                    break;

                                case 2:
                                    Console.WriteLine("\n");
                                    matrixB = number * matrixB;
                                    Program.OutputMatrix(matrixB);
                                    input = false;
                                    break;

                                case 3:
                                    Console.WriteLine("\n");
                                    matrixC = number * matrixC;
                                    Program.OutputMatrix(matrixC);
                                    input = false;
                                    break;

                                case 0:
                                    input = false; // Выход из программы.
                                    break;

                                default:
                                    Console.WriteLine("Некорректный выбор функции!");
                                    break;

                            }
                        }
                        break;

                    case 0:
                        isRun = false; // Выход из программы.
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор функции!");
                        break;
                }
            }
        }
        /// <summary>
        /// Метод ввода матрицы из консоли.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static double[,] InputMatrix(int line, int column)
        {
            int i = 0;
            double[,] value = new double[1000, 1000];
            while (i < line)
            {
                int j = 0;
                while (j < column)
                {
                    string inputValue = Console.ReadLine();
                    MatrixException.ValidateDouble(inputValue, out value[i, j]);
                    j++;
                }
                i++;
            }
            return value;
        }
        /// <summary>
        /// Метод вывода матрицы в консоль.
        /// </summary>
        /// <param name="A"></param>
        public static void OutputMatrix(Matrixs A)
        {
            int i = 0;
            while (i < A.Line)
            {
                int j = 0;
                while (j < A.Column)
                {
                    Console.Write(String.Format("{0,4:0.0}", A.Value[i, j]));
                    Console.Write(" ");
                    j++;
                }
                Console.WriteLine("\n");
                i++;
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryForMatrix;

namespace TestForMatrix
{
    /// <summary>
    /// Тестовый класс, в котором хранятся модульные тесты.
    /// </summary>
    [TestClass]
    public class TestMatrix
    {
        /// <summary>
        /// Метод сравнения матриц между собой.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool CompareMatrixs(Matrixs A, Matrixs B)
        {
            if (A.Line != B.Line || A.Column != B.Column)
            {
                return false;
            }
            int i = 0;
            while (i < A.Line)
            {
                int j = 0;
                while (j < A.Column)
                {
                    if (A.Value[i, j] != B.Value[i, j])
                    {
                        return false;
                    }
                    j++;
                }
                i++;
            }
            return true;
        }
        /// <summary>
        /// Тест, проверяющий умножения одноэлементной матрицы.
        /// </summary>
        [TestMethod]
        public void SingleElementMatrixMultiplication()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 1;
            matrix1.Column = 1;
            matrix1.Value[0, 0] = 3;

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 1;
            matrix2.Column = 3;
            matrix2.Value = new double[1, 3] { { 1, 2, 3 } };

            Matrixs matrix3 = matrix1 * matrix2;

            Matrixs result = new Matrixs();
            result.Line = 1;
            result.Column = 3;
            result.Value = new double[1, 3] { { 3, 6, 9 } };

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий умножение матриц, в результате которого получается одноэлементная матрица. 
        /// </summary>
        [TestMethod]
        public void ResultMultiplicationIsSingleElementMatrix()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 1;
            matrix1.Column = 3;
            matrix1.Value = new double[1, 3] { { 1, 2, 3 } };

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 3;
            matrix2.Column = 1;
            matrix2.Value = new double[3, 1] { { 1 }, { 2 }, { 3 } };

            Matrixs matrix3 = matrix1 * matrix2;

            Matrixs result = new Matrixs();
            result.Line = 1;
            result.Column = 1;
            result.Value[0, 0] = 14;

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий умножение квадратных матриц.
        /// </summary>
        [TestMethod]
        public void MultiplicationOfSquareMatrixs()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1.Value = new double[2, 2] { { 2, 3 }, { 3, 2 } };

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 2;
            matrix2.Column = 2;
            matrix2.Value = new double[2, 2] { { 1, 2 }, { 3, 2 } };

            Matrixs matrix3 = matrix1 * matrix2;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result.Value = new double[2, 2] { { 11, 10 }, { 9, 10 } };

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий умножение столбца на строчку.
        /// </summary>
        [TestMethod]
        public void MultiplicationColumnByLine()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 1;
            matrix1.Column = 2;
            matrix1.Value = new double[1, 2] { { 1, 2 } };

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 2;
            matrix2.Column = 1;
            matrix2.Value = new double[2, 1] { { 3 }, { 2 } };

            Matrixs matrix3 = matrix2 * matrix1;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result.Value = new double[2, 2] { { 3, 6 }, { 2, 4 } };

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий возможность умножения матриц.
        /// </summary>
        [TestMethod]
        public void MatrixMultiplicationCheck()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 1;
            matrix1.Column = 1;
            matrix1.Value[0, 0] = 1;

            Matrixs matrix2 = new Matrixs();
            matrix2.Line = 2;
            matrix2.Column = 1;
            matrix2.Value = new double[2, 1] { { 1 }, { 2 } };

            Matrixs matrix3 = matrix1 * matrix2;

            Matrixs result = new Matrixs();

            Assert.IsTrue(CompareMatrixs(result, matrix3));
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на число.
        /// </summary>
        [TestMethod]
        public void MatrixMultiplicationByNumber()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1.Value = new double[2, 2] { { 2, 2 }, { 2, 2 } };

            double number = 5;

            Matrixs matrix2 = number * matrix1;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result.Value = new double[2, 2] { { 10, 10 }, { 10, 10 } };

            Assert.IsTrue(CompareMatrixs(result, matrix2));
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицу на вещественное число.
        /// </summary>
        [TestMethod]
        public void MatrixMultiplicationByNumber2()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1.Value = new double[2, 2] { { 5, 5 }, { 5, 5 } };

            double number = 2.5;

            Matrixs matrix2 = number * matrix1;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result.Value = new double[2, 2] { { 12.5, 12.5 }, { 12.5, 12.5 } };

            Assert.IsTrue(CompareMatrixs(result, matrix2));
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на единицу.
        /// </summary>
        [TestMethod]
        public void MatrixMultiplicationByOne()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 3;
            matrix1.Column = 3;
            matrix1.Value = new double[3, 3] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };

            double number = 1;

            Matrixs matrix2 = number * matrix1;

            Matrixs result = new Matrixs();
            result.Line = 3;
            result.Column = 3;
            result.Value = new double[3, 3] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };

            Assert.IsTrue(CompareMatrixs(result, matrix2));
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на отрицательное число.
        /// </summary>
        [TestMethod]
        public void MatrixMultiplicationByNegativeNumber()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1.Value = new double[2, 2] { { 2, 2 }, { 2, 2 } };

            double number = -3;

            Matrixs matrix2 = number * matrix1;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result.Value = new double[2, 2] { { -6, -6 }, { -6, -6 } };

            Assert.IsTrue(CompareMatrixs(result, matrix2));
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на ноль.
        /// </summary>
        [TestMethod]
        public void MatrixMultiplicationByZero()
        {
            Matrixs matrix1 = new Matrixs();
            matrix1.Line = 2;
            matrix1.Column = 2;
            matrix1.Value = new double[2, 2] { { 2, 2 }, { -2, 2 } };

            double number = 0;

            Matrixs matrix2 = number * matrix1;

            Matrixs result = new Matrixs();
            result.Line = 2;
            result.Column = 2;
            result.Value = new double[2, 2] { { 0, 0 }, { 0, 0 } };
        }
    }
}

namespace LibraryForMatrix
{
    /// <summary>
    /// Класс, в котором находятся данные косающиеся матрицы, методы и операции, совершаемые над матрицами. 
    /// </summary>
    public class Matrixs
    {
        public int Line;

        public int Column;

        public double[,] Value = new double[1000, 1000];
        /// <summary>
        /// Конструктор пустой матрицы.
        /// </summary>
        public Matrixs()
        {
            this.Line = 0;
            this.Column = 0;
            this.Value[Line, Column] = 0;
        }
        /// <summary>
        /// Конструктор матрицы по вводимым данным.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="values"></param>
        public Matrixs(int line, int column, double[,] values)
        {
            this.Line = line;
            this.Column = column;
            int stepLine = 0, stepColumn = 0;
            while (stepLine < line)
            {
                stepColumn = 0;
                while (stepColumn < column)
                {
                    Value[stepLine, stepColumn] = values[stepLine, stepColumn];
                    stepColumn++;
                }
                stepLine++;
            }
        }
        /// <summary>
        /// Операция умножения матрицы на матрицу.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrixs operator *(Matrixs A, Matrixs B)
        {
            if (A.Column == B.Line)
            {
                int stepLineA = 0, stepColumnB = 0;
                Matrixs C = new Matrixs();
                C.Line = A.Line;
                C.Column = B.Column;
                while (stepLineA < A.Line)
                {
                    stepColumnB = 0;
                    while (stepColumnB < B.Column)
                    {
                        int stepColumnA = 0, stepLineB = 0;
                        while (stepColumnA < A.Column)
                        {
                            C.Value[stepLineA, stepColumnB] = C.Value[stepLineA, stepColumnB] + A.Value[stepLineA, stepColumnA] * B.Value[stepLineB, stepColumnB];
                            stepColumnA++;
                            stepLineB++;
                        }
                        stepColumnB++;
                    }
                    stepLineA++;
                }
                return C;
            }
            Matrixs D = new Matrixs();
            return D;
        }
        /// <summary>
        /// Операция умножения матрицы на число.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Matrixs operator *(double number, Matrixs A)
        {
            int stepLine = 0, stepColumn = 0;
            Matrixs C = new Matrixs();
            C.Line = A.Line;
            C.Column = A.Column;
            while (stepLine < A.Line)
            {
                stepColumn = 0;
                while (stepColumn < A.Column)
                {
                    C.Value[stepLine, stepColumn] = A.Value[stepLine, stepColumn] * number;
                    stepColumn++;
                }
                stepLine++;
            }
            return C;
        }
    }
}

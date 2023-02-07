using System.Collections;




namespace MatrixLib
{
    public class Matrix : IEnumerable
    {
        // Properties
        private int Rows { get;}

        private int Columns { get;}

        private double[,] Data { get;}

        // Constructors

        /// <summary>
        /// Creates matrix from given double[,] array.
        /// </summary>
        /// <param name="array"></param>а
        public Matrix(double[,] array)
        {
            Data = (double[,])array.Clone();
            Rows = array.GetUpperBound(0) + 1;
            Columns = array.Length / Rows;
        }

        /// <summary>
        /// Creates matrix from given rows and columns
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Data = new double[Rows, Columns];
        }

        private double this[int rowIndex, int colIndex]
        {
            get => Data[rowIndex, colIndex];

            set => Data[rowIndex, colIndex] = value;
        }

        // Operators

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            var result = new Matrix(m1.Rows, m2.Columns);

            if ((m1.Rows == m2.Rows) && (m1.Columns == m2.Columns))
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m2.Columns; j++)
                    {
                        result[i, j] = m1[i, j] + m2[i, j];
                    }
                }
            }
            else
                throw new OperationException();

            return result;
        }

        public static Matrix operator +(Matrix m, double number)
        {
            var result = new Matrix(m.Rows, m.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    result[i, j] = m[i, j] + number;
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            var result = new Matrix(m1.Rows, m2.Columns);

            if ((m1.Rows == m2.Rows) && (m1.Columns == m2.Columns))
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m2.Columns; j++)
                    {
                        result[i, j] = m1[i, j] - m2[i, j];
                    }
                }
            }
            else
                throw new OperationException();

            return result;
        }

        public static Matrix operator -(Matrix m, double number)
        {
            var result = new Matrix(m.Rows, m.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    result[i, j] = m[i, j] - number;
                }
            }

            return result;
        }


        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            var result = new Matrix(m1.Rows, m2.Columns);
            if ((m1.Rows) != (m2.Columns))
                throw new OperationException();

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    for (int k = 0; k < m2.Rows; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix m, double number)
        {
            var result = new Matrix(m.Rows, m.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    result[i, j] = m[i, j] * number;
                }
            }

            return result;
        }

        public static Matrix operator /(Matrix m, double number)
        {
            var result = new Matrix(m.Rows, m.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    result[i, j] = m[i, j] / number;
                }
            }

            return result;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if ((m1.Columns == m2.Columns) && (m1.Rows == m2.Rows))
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Columns; j++)
                    {
                        if (Math.Abs(m1[i, j] - m2[i, j]) > 0.0000000001)
                            return false;
                    }
                }
                return true;
            }
            else
            {
                throw new OperationException();
            }
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            if ((m1.Columns == m2.Columns) && (m1.Rows == m2.Rows))
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Columns; j++)
                    {
                        if (Math.Abs(m1[i, j] - m2[i, j]) > 0.0000000001)
                            return true;
                    }
                }
                return false;
            }
            else
            {
                throw new OperationException();
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            var m = (Matrix)obj;

            if ((Rows == m.Rows) && (Columns == m.Columns))
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (Math.Abs(this[i, j] - m[i, j]) > 0.0000000001)
                            return false;
                    }
                }
            }
            else
                return false;

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        public override int GetHashCode()
        {
            return Data.GetHashCode() + Rows.GetHashCode() + Columns.GetHashCode();
        }

        // Methods

        /// <summary>
        /// Checks if a matrix is square, returns true/false
        /// </summary>
        /// <returns></returns>
        public bool IsSquare()
        {
            if (Rows == Columns)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns matrix in Console
        /// </summary>
        public void DisplayMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{this[i, j]}, ");
                }
                Console.WriteLine();
            }
        }

        public Matrix Transpose()
        {
            var matrix = new Matrix(Columns, Rows);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = this[j, i];
                }
            }

            return matrix;
        }

        private double DetCalc(int n, double[,] matrix)
        {
            double d = 0;

            int subi, subj;

            double[,] subMatrix = new double[n, n];

            if (n == 1)
                return matrix[0, 0];
            else if (n == 2)
                return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
            else
            {
                for (int k = 0; k < n; k++)
                {
                    subi = 0;
                    for (int i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            subMatrix[subi, subj] = matrix[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * matrix[0, k] * DetCalc(n - 1, subMatrix));
                }
            }
            return d;
        }

        public double Det()
        {
            if (Rows != Columns)
                throw new Exception("Matrix must be square matrix");
            else
                return DetCalc(Convert.ToInt32(Math.Sqrt(Data.Length)), Data);
        }

        public double[,] ToDoubleArray()
        {
            return Data;
        }

        public double[] GetRow(int number)
        {
            if ((number >= Rows) || (number < 0))
            {
                throw new GetRowAndColumnsException();
            }

            double[] row = new double[Rows];

            for (int i = 0; i < Rows; i++)
            {
                row[i] = this[number, i];
            }

            return row;
        }

        public double[] GetColumn(int number)
        {
            if ((number >= Columns) || (number < 0))
            {
                throw new GetRowAndColumnsException();
            }

            double[] column = new double[Columns];

            for (int i = 0; i < Columns; i++)
            {
                column[i] = this[i, number];
            }

            return column;
        }

        /// <summary>
        /// Returns new Minor Matrix from this matrix.
        /// </summary>
        /// <param name="orderRow">Row Number</param>
        /// <param name="orderColumn">Column Number</param>
        /// <returns></returns>
        public Matrix MinorMatrix(int orderRow, int orderColumn)
        {
            if (!IsSquare())
                throw new OperationException();
            if ((orderRow > Rows - 1) || (orderColumn > Columns - 1))
                throw new GetRowAndColumnsException();

            Matrix matrix = new Matrix(Rows, Columns);
            Matrix Mmatrix = new Matrix(Rows - 1, Columns - 1);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if ((i == orderRow) || (j == orderColumn))
                        matrix[i, j] = 1;
                }
            }

            int x = 0;
            int y = 0;
            for (int i = 0; i < matrix.Rows; i++)
            {

                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (Math.Abs(matrix[i, j] - 1) > 0.0000000001)
                    {
                        Mmatrix[x, y] = this[i, j];
                        y++;
                        if (y == Mmatrix.Columns)
                        {
                            y = 0;
                            x++;
                        }
                    }
                }
            }
            return Mmatrix;
        }

        /// <summary>
        /// Updates the current matrix by replacing the selected row with a double array.
        /// </summary>
        /// <param name="rowIndex">The index of the row to be replaced.</param>
        /// <param name="rowArray">Double array to insert.</param>
        /// <exception cref="GetRowAndColumnsException"></exception>
        public void ReplaceRow(int rowIndex, double[] rowArray)
        {
            if ((rowIndex > Rows) || (rowIndex < 0) || (rowArray.Length > Columns))
                throw new GetRowAndColumnsException();

            for (int i = 0; i < rowArray.Length; i++)
            {
                this[rowIndex, i] = rowArray[i];
            }
        }

        /// <summary>
        /// Updates the current matrix by replacing the selected column with a double array.
        /// </summary>
        /// <param name="colIndex">The index of the column to be replaced</param>
        /// <param name="colArray">Double array to insert.</param>
        /// <exception cref="GetRowAndColumnsException"></exception>
        public void ReplaceColumn(int colIndex, double[] colArray)
        {
            if ((colIndex > Columns) || (colIndex < 0) || (colArray.Length > Columns))
                throw new GetRowAndColumnsException();

            for (int i = 0; i < colArray.Length; i++)
            {
                this[i, colIndex] = colArray[i];
            }
        }
    }
}
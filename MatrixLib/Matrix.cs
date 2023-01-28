using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MatrixLib
{
    public class Matrix : IEnumerable
    {
        // Fields
        public int rows { get; private set; }

        public int columns { get; private set; }

        public double[,] data { get; private set; }

        // Constructors

        /// <summary>
        /// Creates matrix from given double[,] array.
        /// </summary>
        /// <param name="array"></param>а
        public Matrix(double[,] array)
        {
            data = (double[,])array.Clone();
            rows = array.GetUpperBound(0) + 1;
            columns = array.Length / rows;
        }

        /// <summary>
        /// Creates matrix from given rows and colums
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="colums"></param>
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            data = new double[this.rows, this.columns];
        }

        public double this[int rowIndex, int colIndex]
        {
            get { return data[rowIndex, colIndex]; }

            set { data[rowIndex, colIndex] = value; }
        }

        // Operators

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.rows, m2.columns);

            if ((m1.rows == m2.rows) && (m1.columns == m2.columns))
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
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
            Matrix result = new Matrix(m.rows, m.columns);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    result[i, j] = m[i, j] + number;
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.rows, m2.columns);

            if ((m1.rows == m2.rows) && (m1.columns == m2.columns))
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
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
            Matrix result = new Matrix(m.rows, m.columns);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    result[i, j] = m[i, j] - number;
                }
            }

            return result;
        }


        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.rows, m2.columns);
            if ((m1.rows) != (m2.columns))
                throw new OperationException();

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m2.columns; j++)
                {
                    for (int k = 0; k < m2.rows; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix m, double number)
        {
            Matrix result = new Matrix(m.rows, m.columns);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    result[i, j] = m[i, j] * number;
                }
            }

            return result;
        }

        public static Matrix operator /(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.rows, m2.columns);

            if ((m1.rows == m2.rows) && (m1.columns == m2.columns))
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m2.columns; j++)
                    {
                        result[i, j] = m1[i, j] / m2[i, j];
                    }
                }
            }
            else
                throw new OperationException();

            return result;
        }

        public static Matrix operator /(Matrix m, double number)
        {
            Matrix result = new Matrix(m.rows, m.columns);

            for (int i = 0; i < m.rows; i++)
            {
                for (int j = 0; j < m.columns; j++)
                {
                    result[i, j] = m[i, j] / number;
                }
            }

            return result;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if ((m1.columns == m2.columns) && (m1.rows == m2.rows))
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m1.columns; j++)
                    {
                        if (m1[i, j] != m2[i, j])
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
            if ((m1.columns == m2.columns) && (m1.rows == m2.rows))
            {
                for (int i = 0; i < m1.rows; i++)
                {
                    for (int j = 0; j < m1.columns; j++)
                    {
                        if (m1[i, j] != m2[i, j])
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

            Matrix m = (Matrix)obj;

            if ((this.rows == m.rows) && (this.columns == m.columns))
            {
                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        if (this[i, j] != m[i, j])
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
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        public override int GetHashCode()
        {
            return data.GetHashCode() + rows.GetHashCode() + columns.GetHashCode();

            // i dont know how is it must working, but i hope i did it good
        }

        // Methods

        /// <summary>
        /// Checks if a matrix is square, returns true/false
        /// </summary>
        /// <returns></returns>
        public bool isSquare()
        {
            if (this.rows == this.columns)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns matrix in Console
        /// </summary>
        public void CWGetMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{this[i, j]}, ");
                }
                Console.WriteLine();
            }
        }

        public Matrix Transpose()
        {
            Matrix Tmatrix = new Matrix(this.columns, this.rows);

            for (int i = 0; i < Tmatrix.rows; i++)
            {
                for (int j = 0; j < Tmatrix.columns; j++)
                {
                    Tmatrix[i, j] = this[j, i];
                }
            }

            return Tmatrix;
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
            if (rows != columns)
                throw new Exception("Matrix must be square matrix");
            else
                return DetCalc(Convert.ToInt32(Math.Sqrt(data.Length)), data);
        }

        public double[,] ToDoubleArray()
        {
            return data;
        }

        public double[] GetRow(int number)
        {
            if ((number >= rows) || (number < 0))
            {
                throw new GetRowAndColumnsException();
            }

            double[] row = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                row[i] = this[number, i];
            }

            return row;
        }

        public double[] GetColumn(int number)
        {
            if ((number >= columns) || (number < 0))
            {
                throw new GetRowAndColumnsException();
            }

            double[] column = new double[columns];

            for (int i = 0; i < columns; i++)
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
            if (!isSquare())
                throw new OperationException();
            if ((orderRow > this.rows - 1) || (orderColumn > this.columns - 1))
                throw new GetRowAndColumnsException();

            Matrix matrix = new Matrix(this.rows, this.columns);
            Matrix Mmatrix = new Matrix(this.rows - 1, this.columns - 1);

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if ((i == orderRow) || (j == orderColumn))
                        matrix[i, j] = 1;
                }
            }

            int x = 0;
            int y = 0;
            for (int i = 0; i < matrix.rows; i++)
            {

                for (int j = 0; j < matrix.columns; j++)
                {
                    if (matrix[i, j] != 1)
                    {
                        Mmatrix[x, y] = this[i, j];
                        y++;
                        if (y == Mmatrix.columns)
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
        public void AddAsRow(int rowIndex, double[] rowArray)
        {
            if ((rowIndex > rows) || (rowIndex < 0) || (rowArray.Length > columns))
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
        public void AddAsColumn(int colIndex, double[] colArray)
        {
            if ((colIndex > columns) || (colIndex < 0) || (colArray.Length > columns))
                throw new GetRowAndColumnsException();

            for (int i = 0; i < colArray.Length; i++)
            {
                this[i, colIndex] = colArray[i];
            }
        }
    }
}
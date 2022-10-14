using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{

        public class MatrixExceptions : Exception
        {
            /// <summary>
            /// Root error for matrices: matrix error
            /// </summary>
            public MatrixExceptions()
                : base("Matrix Error")
            {

            }

            /// <summary>
            /// Root error for matrices: matrix error with additional message
            /// </summary>
            public MatrixExceptions(string message)
                : base("Matrix Error\n" + message)
            {

            }
        }

        /// <summary>
        /// Matrix operation Error
        /// </summary>
        public class OperationException : MatrixExceptions
        {
            public OperationException()
                : base("Rows and Columns are not equal!")
            {

            }
        }

        public class GetRowAndColumnsException : MatrixExceptions
        {
            public GetRowAndColumnsException()
                : base("The number is greater than the number of rows/columns or less than 0")
            {

            }
        }
 }



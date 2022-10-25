# About MatrixLib
 A simple library for working with matrices, contains the basic functionality and api that may be useful to you :)

# Changes in the new version 1.0.1

Major changes:
- **NEW!** MinorMatrix(); <br />
Returns a new minor matrix from an existing one.
- **NEW!** isSquare(); <br />
Returns boolean. Checks whether the matrix is square (rows == columns)
- Updated the documentation in the readme.
# Installation

#### Package Manager

```NuGet\Install-Package Zabulonov.MatrixLib -Version 1.0.1```

#### .NET CLI

```dotnet add package Zabulonov.MatrixLib --version 1.0.1```

# Working with the matrix

First, include the library:

```csharp
using MatrixLib;

```

## Creating a matrix

To create a matrix, just type:

```csharp
Matrix matrix = new Matrix(rowsLength, columnsLength);

```
You can also create a matrix from a double[,] array:

```csharp
double[,] arr1 = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };

Matrix m1 = new Matrix(arr1);
```

## Accessing Matrix Elements
Implemented indexed access to matrix elements using `matrixName[row, column]`
For example:

```csharp
Matrix m1 = new Matrix(arr1);

Console.WriteLine(m1[2,2]);
```

You can also run `foreach` in the matrix, it will go through all the elements of the matrix.

```csharp
foreach (var item in m1)
{
    Console.WriteLine(item);
}
```

## Operators

For ease of use, all operators have been overloaded:  +, -, *, /, !=, ==

So for example you can use * to multiply 2 matrices or to multiply an entire matrix by a number:

```csharp
var m3 = m1 * m2;

m3 *= 5;
```
Or if you want to compare 2 matrices or 2 matrix elements:

```csharp
if (m1 == m2)
    Console.WriteLine("true");
// - - -
if (m1[1,1] == m2[1,1])
    Console.WriteLine("true");
```

## Functions

Available Functions:
- **isSquare();** <br />
Returns boolean. Checks whether the matrix is square (rows == columns)
- **MinorMatrix();** <br />
Returns a new minor matrix from an existing one.
- **Det();**<br />
Returns a double, determine the current matrix. The matrix must be square!
- **Equals();**<br />
Returns boolean. Compares 2 matrices, you can also use the ```==``` operator.
- **GetHashCode();**<br />
Returns unique(I hope) hash code
- **GetRow(int number);**<br />
Returns the selected row/column as a double array.
- **GetColumn(int number);**<br />
Returns the selected row/column as a double array.
- **Transpose();**<br />
Returns a new transposed matrix from the current one.
- **ToDoubleArray();**<br />
Converts the current matrix to a double array.
- **CWGetMatrix();**<br />
Displays the current matrix in the console.

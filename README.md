# About MatrixLib
 A simple library for working with matrices, contains the basic functionality and api that may be useful to you :)

# Installation

#### Package Manager

NuGet\Install-Package Zabulonov.MatrixLib -Version 1.0.0

#### .NET CLI

dotnet add package Zabulonov.MatrixLib --version 1.0.0

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
- Det();
- Equals();
- GetHashCode();
- GetRow(int number);
- GetColumn(int number);
- Transpose();
- ToDoubleArray();
- CWGetMatrix();

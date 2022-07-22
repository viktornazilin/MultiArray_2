/* 
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
1 2 4 7
2 3 5 9
2 4 4 8
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
Задача 62. Заполните спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
1 2 3 4
12 13 14 5
11 16 15 6
10 9 8 7
*/

using System;

namespace MultiArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задача 54
            Console.WriteLine("Задача 54");
            Console.WriteLine();
            int[,] array54 = IntArray(5, 5);
            Console.WriteLine();
            BubbleSort(array54);
            Console.WriteLine();

            //Задача 56
            Console.WriteLine("Задача 56");
            Console.WriteLine();
            int minSumLine = 0;
            int sumLine = SumLine(array54, 0);
            for (int i = 1; i < array54.GetLength(0); i++)
            {
                int tempSumLine = SumLine(array54, i);
                if (sumLine > tempSumLine)
                {
                    sumLine = tempSumLine;
                    minSumLine = i;
                }
            }

            Console.WriteLine($"\n{minSumLine + 1} - строкa с наименьшей суммой элементов ");
            Console.WriteLine();

            //Задача 62
            Console.WriteLine("Задача 62");
            Console.WriteLine();
            int n = 4;
            int[,] matrix = new int[n, n];

            int temp = 1;
            int count = 0;
            int j = 0;

            while (temp <= matrix.GetLength(0) * matrix.GetLength(1))
            {
                matrix[count, j] = temp;
                temp++;
                if (count <= j + 1 && count + j < matrix.GetLength(1) - 1)
                    j++;
                else if (count < j && count + j >= matrix.GetLength(0) - 1)
                    count++;
                else if (count >= j && count + j > matrix.GetLength(1) - 1)
                    j--;
                else
                    count--;
            }

            SpiralArray(matrix);

        }

        static int[,] IntArray(int m, int n)
        {
            int rows = m;
            int columns = n;

            Random rand = new Random();

            int[,] numbers = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    numbers[i, j] = rand.Next(0, 100);

                    Console.Write($"{numbers[i, j]} ");

                }
                Console.WriteLine();
            }

            return numbers;
        }

        static int[,] BubbleSort(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(1) - 1; k++)
                    {
                        if (array[i, k] < array[i, k + 1])
                        {
                            int temp = array[i, k + 1];
                            array[i, k + 1] = array[i, k];
                            array[i, k] = temp;
                        }
                    }
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {

                    Console.Write($"{array[i, j]} ");

                }
                Console.WriteLine();
            }

            return array;
        }

        static int SumLine(int[,] array, int lineNumber)
        {
            int sum = array[lineNumber, 0];

            for (int j = 1; j < array.GetLength(1); j++)
            {
                sum += array[lineNumber, j];
            }
            return sum;

        }

        static void SpiralArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] / 10 <= 0)
                        Console.Write($" {array[i, j]} ");

                    else Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
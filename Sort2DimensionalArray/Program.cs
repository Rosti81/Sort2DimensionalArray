using System;

namespace Sort2DimensionalArray
{
    class Program
    {
        static void InitializeArray(int[,] array)
        {
            var rand = new Random();
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(0, 99);
                }
            }
        }

        static void DisplayArray(int[,] array, string title)
        {
            Console.WriteLine(title);
            for (var i = 0; i < array.GetLength(0); i++)
            {
                var sum = 0;
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                    Console.Write($"{array[i, j].ToString().PadLeft(2, ' ')}, ");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Sum = {sum}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }

        static void SortArray(int[,] array)
        {
            bool isSorted;
            var iterationCount = 0;
            do
            {
                isSorted = true;
                var previousLine = new int[array.GetLength(1)];
                var previousSum = 0;
                for (var i = 0; i < array.GetLength(0); i++)
                {
                    var currentLine = new int[array.GetLength(1)];
                    var currentSum = 0;
                    for (var j = 0; j < array.GetLength(1); j++)
                    {
                        currentLine[j] = array[i, j];
                        currentSum += array[i, j];
                    }

                    // Starting from the second line
                    if (i > 0)
                    {
                        // Switch lines if current sum is less than previous one
                        if (currentSum < previousSum)
                        {
                            isSorted = false;
                            for (var j = 0; j < array.GetLength(1); j++)
                            {
                                array[i - 1, j] = currentLine[j];
                                array[i, j] = previousLine[j];
                            }
                        }
                        else
                        {
                            previousLine = currentLine;
                            previousSum = currentSum;
                        }
                    }
                    else
                    {
                        previousLine = currentLine;
                        previousSum = currentSum;
                    }
                }
                DisplayArray(array, $"Iteration {++iterationCount}");
            } while (!isSorted);
        }

        static void Main(string[] args)
        {
            var array = new int[10, 10];
            InitializeArray(array);
            DisplayArray(array, "Unsorted");
            SortArray(array);
            DisplayArray(array, "Sorted");
        }
    }
}

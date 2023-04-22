using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4_2_semestr
{
    public partial class Shab
    {
        static void Task1()
        {
            Console.WriteLine("Enter number of array filling type: \n1 - with console in 1 row\n2 - randomly");
            int num = int.Parse(Console.ReadLine());
            int[] intarray = new int[100];
            switch (num)
            {
                case 1:
                     intarray = Array1dFilling();
                    break;
                case 2:
                    intarray = RandomArray1dFilling();
                    break;
            }

            int[] resarray = new int[intarray.Length + TwinCount(intarray)];
            ResarrayFilling(intarray, resarray);
            Console.WriteLine("Result array: ");
            PrintArray(resarray);
        }
        static void Task2()
        {
           
            Console.WriteLine("Enter number of jagged array filling type: \n1 - with console\n2 - randomly");
            int num = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[100][];
            switch (num)
            {
                case 1:
                    jaggedArray = JaggedArrayFilling();
                    break;
                case 2:
                    jaggedArray = JaggedArrayRandomFilling();
                    break;
            }
            
            Console.WriteLine("Jagged array: ");
            PrintJaggedArray(jaggedArray);

            Console.WriteLine("Result: ");
            PrintJaggedArray(JaggedArrayRowAdder(jaggedArray));
        }
        static void Task3()
        {
            int[,] array2d = new int[100,100];
            int[][] jaggedArray = new int[100][];
            Console.WriteLine("Enter number of matrix filling type: \n1 - with console\n2 - randomly");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    array2d = Array2dFilling();
                    Console.WriteLine("Matrix: ");
                    PrintArray2d(array2d);
                    break;
                case 2:
                    array2d = Array2dRandomFilling();
                    Console.WriteLine("Matrix: ");
                    PrintArray2d(array2d);
                    break;
            }
            Console.WriteLine("Enter number of jagged array filling type: \n1 - with console\n2 - randomly");
            int num1 = int.Parse(Console.ReadLine());
            switch (num1)
            {
                case 1:
                    jaggedArray = JaggedArrayFilling();
                    Console.WriteLine("Jagged array: ");
                    PrintJaggedArray(jaggedArray);
                    break;
                case 2:
                    jaggedArray = JaggedArrayRandomFilling();
                    Console.WriteLine("Jagged array: ");
                    PrintJaggedArray(jaggedArray);
                    break;
            }
            int[,] sum = SumOfMatrices(array2d, jaggedArray);
            Console.WriteLine("Sum matrix: ");
            PrintArray2d(sum);
            Console.WriteLine("Result matrix: ");
            PrintArray2d(InvertMatrix(sum));
        }
        public void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("Задача 1 - 1");
                Console.WriteLine("Задача 2 - 2");
                Console.WriteLine("Задача 3 - 3");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                }
            } while (choice != 0);
        }
         static int[] RandomArray1dFilling()
        {
            Console.WriteLine("Enter count of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bounds of elements size: ");
            string[] bounds = Console.ReadLine().Trim().Split();
            int a = int.Parse(bounds[0]);
            int b = int.Parse(bounds[1]);
            int[] intarray = new int[n];
            Random rand = new Random();
            for (int i = 0; i < intarray.Length; i++)
            {
                intarray[i] = rand.Next(a,b);
            }
            return intarray;
        }
        static int[] Array1dFilling()
        {
            string[] array = Console.ReadLine().Trim().Split();
            int[] intarray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                intarray[i] = int.Parse(array[i]);
            }
            return intarray;
        }
          static int TwinCount(int[] intarray)
        {
            int count = 0;
            for (int i = 0; i < intarray.Length; i++)
            {
                if (intarray[i] % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        static void ResarrayFilling(int[] intarray, int[] resarray)
        {
            for (int i = 0, j = 0; i < intarray.Length; i++, j += 2)
            {
                resarray[j] = intarray[i];
                if (intarray[i] % 2 == 0)
                {
                    resarray[j + 1] = 0;
                }
                else
                {
                    j--;
                }
            }
        }
         static void PrintArray(int[] resarray)
        {
            for (int i = 0; i < resarray.Length; i++)
            {
                Console.Write(resarray[i] + " ");
            }
            Console.WriteLine();
        }
         static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
          static int[][] JaggedArrayFilling()

        {
            Console.WriteLine("Enter count of rows in jagged array: ");
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];
            Console.WriteLine("Enter a jagged array: ");

            for (int i = 0; i < n; i++)
            {
                int[] row = Array1dFilling();
                jaggedArray[i] = new int[row.Length];

                for (int j = 0; j < row.Length; j++)
                {
                    jaggedArray[i][j] = row[j];
                }
            }
            return jaggedArray;
        }
        static int FindMinElRow(int[][] jaggedArray)
        {
            int min = jaggedArray[0][0]; // пошук мінімального елемента
            int minRowIndex = 0;
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] < min)
                    {
                        min = jaggedArray[i][j];
                        minRowIndex = i;
                    }
                }
            }
            return minRowIndex;
        }
         static int[][] JaggedArrayRowAdder(int[][] jaggedArray)
        {
            int minRowIndex = FindMinElRow(jaggedArray);
            int[] newRow = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Array.Resize(ref jaggedArray, jaggedArray.Length + 1);
            for (int i = jaggedArray.Length - 1; i > minRowIndex; i--)
            {
                jaggedArray[i] = jaggedArray[i - 1];
            }
            jaggedArray[minRowIndex] = newRow;
            return jaggedArray;
        }
         static int[][] JaggedArrayRandomFilling()
        {
            Console.WriteLine("Enter count of rows in jagged array: ");
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];
            Console.WriteLine("Enter a jagged array: ");

            for (int i = 0; i < n; i++)
            {
                int[] row = RandomArray1dFilling();
                jaggedArray[i] = new int[row.Length];

                for (int j = 0; j < row.Length; j++)
                {
                    jaggedArray[i][j] = row[j];
                }
            }
            return jaggedArray;
        }
         static int[,] Array2dRandomFilling()
        {
            Console.WriteLine("Enter size of matrix: ");
            string[] size = Console.ReadLine().Trim().Split();
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);
            Console.WriteLine("Enter bounds of elements size: ");
            string[] bounds = Console.ReadLine().Trim().Split();
            int a = int.Parse(bounds[0]);
            int b = int.Parse(bounds[1]);
            int[,] array2d = new int[n, m];
            Random rand = new Random();
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    array2d[y, x] = rand.Next(a,b);
                }
            }
            return array2d;
        }
      static int[,] Array2dFilling()
        {
            Console.WriteLine("Enter size of matrix: ");
            string[] size = Console.ReadLine().Trim().Split();
            int n = int.Parse(size[0]);
            int m = int.Parse(size[1]);
            int[,] array2d = new int[n, m];
            Console.WriteLine("Enter the matrix: ");
            for (int y = 0; y < n; y++)
            {
                size = Console.ReadLine().Trim().Split();
                for (int x = 0; x < m; x++)
                {
                    array2d[y, x] = int.Parse(size[x]);
                }
            }
            return array2d;
        }
         static int[,] SumOfMatrices(int[,] s1matrix, int[][] s2matrix)
        {
            int rows = Math.Max(s1matrix.GetLength(0), s2matrix.Length);
            int cols = Math.Max(s1matrix.GetLength(1), getMaxRowLength(s2matrix));


            int[,] sum = new int[rows, cols];

 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i < s1matrix.GetLength(0) && j < s1matrix.GetLength(1))
                    {
                        sum[i, j] += s1matrix[i, j];
                    }
                    if (i < s2matrix.Length && j < s2matrix[i].Length)
                    {
                        sum[i, j] += s2matrix[i][j];
                    }
                }
            }
            return sum;
        }
        static int getMaxRowLength(int[][] s2matrix)
        {
            int maxLength = 0;
            foreach (int[] row in s2matrix)
            {
                if (row.Length > maxLength)
                {
                    maxLength = row.Length;
                }
            }
            return maxLength;
        }
        static int[,] InvertMatrix(int[,]sum)
        {
            for (int y = 0; y < sum.GetLength(0); y++)
            {
                for (int x = 0; x < sum.GetLength(1) / 2; x++)
                {
                    int temp = sum[y, x];
                    sum[y, x] = sum[y, sum.GetLength(1) - x - 1];
                    sum[y, sum.GetLength(1) - x - 1] = temp;
                }
            }
            return sum;
        }
        static void PrintArray2d(int[,]array2d)
        {
            for (int y = 0; y < array2d.GetLength(0); y++)
            {
                for (int x = 0; x < array2d.GetLength(1); x++)
                {
                    Console.Write(array2d[y,x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

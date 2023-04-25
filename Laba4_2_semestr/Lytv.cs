using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4_2_semestr
{
    public partial class Lytv
    {
        static void Task1()
        {
            int[] arr = FillArray();
            Console.Write("Введіть елемент масиву з якого начнеться видалення: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Введіть к-ть елементів яку хочите видалити: ");
            int t = int.Parse(Console.ReadLine());

            RemoveElementsFromArray(ref arr, k, t);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.ReadKey();
        }
        static void Task2()
        {
            Console.Write("Введіть розмірність масиву (рядки стовпці): ");
            string[] size = Console.ReadLine().Split();
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            int[][] array = new int[rows][];

            Console.WriteLine($"Введіть {rows} рядків по {cols} елементів кожен:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Рядок {i + 1}: ");
                string[] values = Console.ReadLine().Split();

                array[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    if (j < values.Length)
                    {
                        array[i][j] = int.Parse(values[j]);
                    }
                    else
                    {
                        array[i][j] = 0;
                    }
                }
            }
            Console.WriteLine("Масив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введіть індекс рядка, який потрібно видалити: ");
            int k = int.Parse(Console.ReadLine());

            int[][] newArray = new int[rows - 1][];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i != k)
                {
                    newArray[index] = new int[cols];

                    for (int j = 0; j < cols; j++)
                    {
                        newArray[index][j] = array[i][j];
                    }

                    index++;
                }
            }
            Console.WriteLine("Масив після видалення:");
            for (int i = 0; i < newArray.Length; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(newArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static void Task3()
        {
            Console.WriteLine("Введіть розмір матриці P у форматі 'рядки стовпці':");
            string[] sizes = Console.ReadLine().Split(' ');
            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);

            int[,] P = new int[rows, cols];

            Console.WriteLine("Введіть елементи матриці P:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"P[{i},{j}] = ");
                    P[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[] Z = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int lastZero = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (P[i, j] == 0)
                    {
                        lastZero = j;
                    }
                }
                if (lastZero == -1)
                {
                    Z[i] = cols;
                }
                else
                {
                    Z[i] = lastZero + 1;
                }
            }

            int[][] Q = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Q[i] = new int[Z[i]];
                Random rand = new Random();
                for (int j = 0; j < Z[i]; j++)
                {
                    Q[i][j] = rand.Next(10);
                }
                SelectionSort(Q[i]);
            }

            Console.WriteLine("\nМатриця Z:");
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Z[{i}] = {Z[i]}");
            }

            Console.WriteLine("\nМатриця Q:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < Z[i]; j++)
                {
                    Console.Write($"{Q[i][j]} ");
                }
                Console.WriteLine();

            }
            Console.ReadKey();
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
        static int[] FillArray()
        {
            Console.WriteLine("Ввеліть к-ть елементі масиву");
            int arrayLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть елементи масиву, розділені пробілами: ");
            string input = Console.ReadLine();
            string[] strArr = input.Split();

            int[] arr = new int[strArr.Length];

            for (int i = 0; i < arrayLength; i++)
            {
                arr[i] = int.Parse(strArr[i]);
            }
            return arr;
        }
        static void RemoveElementsFromArray(ref int[] arr, int k, int t)
        {
            int elementsToRemove = Math.Min(t, arr.Length - k); // це к-ть ел дня видалення

            if (elementsToRemove <= 0) // той випадок якщо елементів нема
            {
                return;
            }

            int newLength = arr.Length - elementsToRemove; // нова довжина масиву
            int[] newArr = new int[newLength];

            for (int i = 0; i < k; i++) // переношу чистину масиву
            {
                newArr[i] = arr[i];
            }

            for (int i = k + elementsToRemove; i < arr.Length; i++)
            {
                newArr[i - elementsToRemove] = arr[i]; // копія масиву вже після видалення
            }

            arr = newArr;
        }
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
}

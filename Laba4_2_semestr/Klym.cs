using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Laba4_2_semestr
{
    public partial class Klym
    {
        static int[] Rand1(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 7);
            }
            return arr;
        }

        static int[] KeyBoard1(int[]arr)
        {
            arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            return arr;
        }
        static int[][] Rand(int[][]arr,int n)
        {
            for (int i = 0; i < n; i++)
            {
                global::System.Console.Write("Введiть довжину :");
                int k = int.Parse(Console.ReadLine());
                arr[i] = new int[k];
            }
            Random rnd= new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(-10, 10);
                }
            }
            return arr;
        }

        static int[][] KeyBoard(int[][]arr,int n)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            }
            Console.Clear();
            return arr;
        }

        static void CW(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void CW1(int[] arr)
        {
           string str = string.Join(" ", arr);
            Console.WriteLine(str);
        }

        static void CW2(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Zapov(int[][] arr,int n)
        {
            int choice;
            do
            {
                Console.WriteLine("Рандомне заповнення     - 1");
                Console.WriteLine("Заповнення з клавiатури - 2");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Rand(arr,n);
                        CW(arr);
                        Console.WriteLine();
                        return;
                        break;
                    case 2:
                        KeyBoard(arr,n);
                        CW(arr);
                        Console.WriteLine();
                        return;
                        break;
                }
            } while (choice!=0);
        }

        static void Zapov1(int[] arr)
        {
            int choice;
            do
            {
                Console.WriteLine("Рандомне заповнення     - 1");
                Console.WriteLine("Заповнення з клавiатури - 2");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Rand1(arr);
                        CW1(arr);
                        Console.WriteLine();
                        return;
                        break;
                    case 2:
                        KeyBoard1(arr);
                        CW1(arr);
                        Console.WriteLine();
                        return;
                        break;
                }
            } while (choice != 0);
        }
        static void Task1()
        {

            Console.Write("Введiть кiлькiсть рядкiв в зубчастому масивi :");
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
            Zapov(arr,n);
            for (int i = 0; i < arr.Length; i++)
            {
                int[] innerArray = arr[i];
                int newSize = innerArray.Length / 2 + innerArray.Length % 2;
                int[] newArray = new int[newSize];
                int newIndex = 0;
                for (int j = 0; j < innerArray.Length; j += 2)
                {
                    newArray[newIndex] = innerArray[j];
                    newIndex++;
                }
                arr[i] = newArray;
            }
            CW(arr);
            Console.WriteLine();


        }
        static void Task2()
        {
            Console.Write("Введiть кiлькiсть рядкiв в зубчастому масивi :");
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
           
            Zapov(arr,n);
            
            int newLength = 0;
            foreach (int[] row in arr)
            {
                if (!row.Contains(0))
                {
                    newLength++;
                }
            }

           
            int[][] newMatrix = new int[newLength][];
            int i = 0;
            foreach (int[] row in arr)
            {
                if (!row.Contains(0))
                {
                    newMatrix[i] = row;
                    i++;
                }
            }

            int[][] finalMatrix = newMatrix;
            CW(finalMatrix);
        }
        static void Task3()
        {
            int[] R = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int numRows = R.Length / 3; 
            int numCols = R.Max();
            int[,] H = new int[numRows, numCols];
            int index = 0;
            for (int row = 0; row < numRows; row++)
            {
                int rowLength = R[index++];
                for (int col = 0; col < rowLength; col++)
                {
                    H[row, col] = R[index++];
                }
            }
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Console.Write(H[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Array.Sort(R);
            Array.Reverse(R);
            Console.WriteLine(string.Join(" ", R));
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
    }
}

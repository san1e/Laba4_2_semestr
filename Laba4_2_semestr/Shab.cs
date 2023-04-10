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

        }
        static void Task2()
        {

        }
        static void Task3()
        {

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

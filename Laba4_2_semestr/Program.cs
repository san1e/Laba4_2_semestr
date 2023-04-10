namespace Laba4_2_semestr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                
                Console.WriteLine("Клименко   - 1");
                Console.WriteLine("Литвиненко - 2");
                Console.WriteLine("Шаблiй     - 3");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Klym klym= new Klym();
                        klym.Main();
                    break;

                    case 2:
                        Lytv lytv= new Lytv();
                        lytv.Main();
                    break;

                    case 3:
                        Shab shab= new Shab();
                        shab.Main();
                    break;
                }
            } while (choice != 0) ;
        }
    }
}
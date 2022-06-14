using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal class SprzedazeStrategy : IMenuStrategy
    {
        public void ShowMenuFor(string connString)
        {
            string sprz = "SELECT * FROM sprzedaże"; // 10
            Console.WriteLine("SPRZEDAŻE");
            if (Program.ReadView(sprz, 10, connString))
            {
                Console.WriteLine(" Menu SPRZEDAŻE");
                Console.WriteLine(" 1) Dodaj sprzedaż");
                Console.WriteLine(" 0) Powrót");
                int subchoice;
                try
                {
                    subchoice = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Błąd wyboru opcji");
                    subchoice = 0;
                }
                switch (subchoice)
                {
                    case 0:
                        break;
                    case 1:
                        Program.InsertSprzedaze(connString);
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
            }
        }
    }
}

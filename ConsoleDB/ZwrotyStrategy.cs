using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal class ZwrotyStrategy :IMenuStrategy
    {
        public void ShowMenuFor(string connString)
        {
            string zwroty = "SELECT * FROM zwroty"; // 10
            Console.WriteLine("ZWROTY");
            if (Program.ReadView(zwroty, 10, connString))
            {
                Console.WriteLine(" Menu ZWROTY");
                Console.WriteLine(" 1) Dodaj zwrot");

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
                        Program.InsertZwroty(connString);
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
            }
        }
    }
}

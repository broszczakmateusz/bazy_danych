using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal class ZamowieniaStrategy :IMenuStrategy
    {
        public void ShowMenuFor(string connString)
        {
            string zam = "SELECT * FROM zamówienia"; // 8
            Console.WriteLine("ZAMÓWIENIA");
            if (Program.ReadView(zam, 8, connString))
            {
                Console.WriteLine(" Menu ZAMÓWIENIA");
                Console.WriteLine(" 1) Dodaj zamówienie");
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
                        Program.InsertZamowienia(connString);
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
            }
        }
    }
}

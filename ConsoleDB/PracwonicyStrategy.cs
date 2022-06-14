using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal class PracwonicyStrategy : IMenuStrategy
    {
        public void ShowMenuFor(string connString)
        {
            string prac = "SELECT * FROM pracownicy"; // 8
            Console.WriteLine("PRACOWNICY");
            if (Program.ReadView(prac, 8, connString))
            {
                Console.WriteLine(" Menu PRACOWNICY");
                Console.WriteLine(" 1) Dodaj pracownika");
                Console.WriteLine(" 2) Edytuj pracownika");
                Console.WriteLine(" 3) Usuń pracownika");
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
                        Program.InsertPracownicy(connString);
                        break;
                    case 2:
                        Program.UpdatePracownicy(connString);
                        break;
                    case 3:
                        Program.DeletePracownicy(connString);
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
            }
        }
    }
}

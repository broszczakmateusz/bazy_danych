using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal class OfertaStrategy : IMenuStrategy
    {
        public void ShowMenuFor(string connString)
        {
            string ofer = "SELECT * FROM oferta"; // 6
            Console.WriteLine("OFERTA");
            if (Program.ReadView(ofer, 6, connString))
            {
                Console.WriteLine(" Menu OFERTA");
                Console.WriteLine(" 1) Dodaj do oferty");
                Console.WriteLine(" 2) Edytuj ofertę");
                Console.WriteLine(" 3) Usuń z oferty");
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
                        Program.InsertOferta(connString);
                        break;
                    case 2:
                        Program.UpdateOferta(connString);
                        break;
                    case 3:
                        Program.DeleteOferta(connString);
                        break;

                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
            }
        }
    }
}

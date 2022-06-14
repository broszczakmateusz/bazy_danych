using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    internal class KlienciStrategy : IMenuStrategy
    {
        public void ShowMenuFor(string connString)
        {
            string klie = "SELECT * FROM klienci"; // 9
            Console.WriteLine("KLIENCI");
            if (Program.ReadView(klie, 9, connString))
            {
                Console.WriteLine(" Menu KLIENCI");
                Console.WriteLine(" 1) Dodaj klienta - firma");
                Console.WriteLine(" 2) Dodaj klienta - osoba");
                Console.WriteLine(" 3) Edytuj klienta - firma");
                Console.WriteLine(" 4) Edytuj klienta - osoba");
                Console.WriteLine(" 5) Usuń klienta");
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
                        Program.InsertKlienciFirma(connString);
                        break;
                    case 2:
                        Program.InsertKlienciOsoba(connString);
                        break;
                    case 3:
                        Program.UpdatelienciFirma(connString);
                        break;
                    case 4:
                        Program.UpdateKlienciOsoba(connString);
                        break;
                    case 5:
                        Program.DeleteKlienci(connString);
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
            }
        }
    }
}

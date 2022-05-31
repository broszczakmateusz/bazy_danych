using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace ConsoleDB
{
    internal class Program
    {
        private static string Host = "localhost";
        private static string DBname = "sklep_komputerowy";
        private static string Port = "5432";

        private static string prac = "SELECT * FROM pracownicy"; // 8
        private static string zwroty = "SELECT * FROM zwroty"; // 10
        private static string zam = "SELECT * FROM zamówienia"; // 8
        private static string sprz = "SELECT * FROM sprzedaże"; // 10
        private static string ofer = "SELECT * FROM oferta"; // 6
        private static string klie = "SELECT * FROM klienci"; // 9


        static void Main(string[] args)
        {
            string connString = null;
            while (connString is null)
            {
                connString = ConnectAs();
            }

            while (true)
            {
                Console.WriteLine(" 1) Pokaż widok PRACOWNICY ");
                Console.WriteLine(" 2) Pokaż widok ZWROTY ");
                Console.WriteLine(" 3) Pokaż widok ZAMÓWIENIA ");
                Console.WriteLine(" 4) Pokaż widok SPRZEDAŻE ");
                Console.WriteLine(" 5) Pokaż widok OFERTA ");
                Console.WriteLine(" 6) Pokaż widok KLIENCI ");
                Console.WriteLine(" 0) Wyjście z programu ");
                Console.WriteLine("Podaj akcję: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Wybrano wyjście!");
                        return;
                    case 1:
                        Console.WriteLine("PRACOWNICY");
                        ReadView(prac, 8, connString);
                        break;
                    case 2:
                        Console.WriteLine("ZWROTY");
                        ReadView(zwroty, 10, connString);
                        break;
                    case 3:
                        Console.WriteLine("ZAMÓWIENIA");
                        ReadView(zam, 8, connString);
                        break;
                    case 4:
                        Console.WriteLine("SPRZEDAŻE");
                        ReadView(sprz, 10, connString);
                        break;
                    case 5:
                        Console.WriteLine("OFERTA");
                        ReadView(ofer, 6, connString);
                        break;
                    case 6:
                        Console.WriteLine("KLIENCI");
                        ReadView(klie, 9, connString);
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }

                Console.WriteLine("Powrót do menu");
                Console.ReadLine();
            }
            
        }
        static string ConnectAs()
        {
            Dictionary<string, string> usersAndPasswords = new Dictionary<string, string>();
            usersAndPasswords.Add("pr_kierownik", "kierownik");
            usersAndPasswords.Add("pr_sprzedawca1", "sprzedawca1");
            usersAndPasswords.Add("pr_sprzedawca2", "sprzedawca2");
            usersAndPasswords.Add("pr_magazynier1", "magazynier1");
            usersAndPasswords.Add("pr_magazynier2", "magazynier2");

            Console.WriteLine("Sklep komputerowy");
            Console.WriteLine("Podaj nazwe użytkownika: ");
            string user = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string password = Console.ReadLine();
            

            if (usersAndPasswords.ContainsKey(user)) {
                if (usersAndPasswords[user] == password)
                {
                    string connString =
                       String.Format(
                           "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                           Host,
                           user,
                           DBname,
                           Port,
                           password);
                    Console.WriteLine("Connection OK");
                    return connString;
                }
                Console.WriteLine("Haslo niepoprawne");
                return null;
            }
            Console.WriteLine("Login nieporpawny");
            return null;
        }

        static void ReadView(string myQuery, int numberOfColumns, string connString)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string columnLabels = "";

                DataTable Table = new DataTable("MyView");
                using(var cmd = new NpgsqlCommand(myQuery, conn))
                {
                    NpgsqlDataAdapter dap = new NpgsqlDataAdapter(cmd);
                    conn.Open();
                    try 
                    {
                        dap.Fill(Table); 
                        var rdr = cmd.ExecuteReader();
                        for (int i = 0; i < numberOfColumns; i++)
                        {
                            columnLabels += rdr.GetName(i) + " | ";
                        }
                    }
                    catch (Npgsql.PostgresException e)
                    {
                        Console.WriteLine("Brak dostępu!, " + e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }


                Console.WriteLine(Table.Rows.Count);
                Console.WriteLine(columnLabels);
                foreach (DataRow dataRow in Table.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.Write(item + " | ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

   
}

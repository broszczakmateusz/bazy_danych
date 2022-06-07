using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace ConsoleDB
{
    public class Program
    {
        private static string Host = "localhost";
        private static string DBname = "sklep_komputerowy";
        private static string Port = "5432";

        private static readonly string prac = "SELECT * FROM pracownicy"; // 8
        private static readonly string zwroty = "SELECT * FROM zwroty"; // 10
        private static readonly string zam = "SELECT * FROM zamówienia"; // 8
        private static readonly string sprz = "SELECT * FROM sprzedaże"; // 10
        private static readonly string ofer = "SELECT * FROM oferta"; // 6
        private static readonly string klie = "SELECT * FROM klienci"; // 9


        static void Main(string[] args)
        {
            string connString = null;
            while (connString is null)
            {
                connString = ConnectAs();
            }
            ShowMenu(connString);
        }

        public static void ShowMenu(string connString)
        {
            while (true)
            {
                Console.WriteLine(" 1) Pokaż widok PRACOWNICY ");
                Console.WriteLine(" 2) Pokaż widok ZWROTY ");
                Console.WriteLine(" 3) Pokaż widok ZAMÓWIENIA ");
                Console.WriteLine(" 4) Pokaż widok SPRZEDAŻE ");
                Console.WriteLine(" 5) Pokaż widok OFERTA ");
                Console.WriteLine(" 6) Pokaż widok KLIENCI ");
                Console.WriteLine(" 0) Wyjście z programu ");
                Console.WriteLine("Wybierz opcję: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Wybrano wyjście!");
                        return;
                    case 1:
                        Console.WriteLine("PRACOWNICY");
                        if (ReadView(prac, 8, connString))
                        {
                            Console.WriteLine(" Menu PRACOWNICY");
                            Console.WriteLine(" 1) Dodaj pracownika");
                            Console.WriteLine(" 2) Edytuj pracownika");
                            Console.WriteLine(" 3) Usuń pracownika");
                            Console.WriteLine(" 0) Powrót");
                            int subchoice = int.Parse(Console.ReadLine());
                            switch (subchoice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    InsertPracownicy(connString);
                                    break;
                                case 2:
                                    UpdatePracownicy(connString);
                                    break;
                                case 3:
                                    DeletePracownicy(connString);
                                   break;
                                default:
                                    Console.WriteLine("Zła opcja!");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("ZWROTY");
                        if (ReadView(zwroty, 10, connString))
                        {
                           Console.WriteLine(" Menu ZWROTY");
                           Console.WriteLine(" 1) Dodaj zwrot");

                            Console.WriteLine(" 0) Powrót");
                            int subchoice = int.Parse(Console.ReadLine());
                            switch (subchoice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    InsertZwroty(connString);
                                    break;
                                default:
                                    Console.WriteLine("Zła opcja!");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("ZAMÓWIENIA");
                        if (ReadView(zam, 8, connString))
                        {
                            Console.WriteLine(" Menu ZAMÓWIENIA");
                            Console.WriteLine(" 1) Dodaj zamówienie");
                            Console.WriteLine(" 0) Powrót");
                            int subchoice = int.Parse(Console.ReadLine());
                            switch (subchoice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    InsertZamowienia(connString);
                                    break;
                                default:
                                    Console.WriteLine("Zła opcja!");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("SPRZEDAŻE");
                        if (ReadView(sprz, 10, connString))
                        {
                            Console.WriteLine(" Menu SPRZEDAŻE");
                            Console.WriteLine(" 1) Dodaj sprzedaż");
                            Console.WriteLine(" 0) Powrót");
                            int subchoice = int.Parse(Console.ReadLine());
                            switch (subchoice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    InsertSprzedaze(connString);
                                    break;
                                default:
                                    Console.WriteLine("Zła opcja!");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("OFERTA");
                        if (ReadView(ofer, 6, connString))
                        {
                            Console.WriteLine(" Menu OFERTA");
                            Console.WriteLine(" 1) Dodaj do oferty");
                            Console.WriteLine(" 2) Edytuj ofertę");
                            Console.WriteLine(" 3) Usuń z oferty");
                            Console.WriteLine(" 0) Powrót");
                            int subchoice = int.Parse(Console.ReadLine());
                            switch (subchoice)
                            {
                                case 0:
                                    
                                    break;
                                case 1:
                                    InsertOferta(connString);
                                    break;
                                case 2:
                                    UpdateOferta(connString);
                                    break;
                                case 3:
                                    DeleteOferta(connString);
                                    break;

                                default:
                                    Console.WriteLine("Zła opcja!");
                                    break;
                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine("KLIENCI");
                        if (ReadView(klie, 9, connString))
                        {
                            Console.WriteLine(" Menu KLIENCI");
                            Console.WriteLine(" 1) Dodaj klienta - firma");
                            Console.WriteLine(" 2) Dodaj klienta - osoba");
                            Console.WriteLine(" 3) Edytuj klienta - firma");
                            Console.WriteLine(" 4) Edytuj klienta - osoba");
                            Console.WriteLine(" 5) Usuń klienta");
                            Console.WriteLine(" 0) Powrót");
                            int subchoice = int.Parse(Console.ReadLine());
                            switch (subchoice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    InsertKlienciFirma(connString);
                                    break;
                                case 2:
                                    InsertKlienciOsoba(connString);
                                    break;
                                case 3:
                                    UpdatelienciFirma(connString);
                                    break;
                                case 4:
                                    UpdateKlienciOsoba(connString);
                                    break;
                                case 5:
                                    DeleteKlienci(connString);
                                    break;
                                default:
                                    Console.WriteLine("Zła opcja!");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }

                Console.WriteLine("Powrót do menu");
                Console.ReadLine();
            }
        }

         public static string ConnectAs()
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


            if (usersAndPasswords.ContainsKey(user))
            {
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

        public static bool ReadView(string myQuery, int numberOfColumns, string connString)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                string columnLabels = "";

                DataTable Table = new DataTable("MyView");
                using (var cmd = new NpgsqlCommand(myQuery, conn))
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
                        conn.Close();
                    }
                    catch (PostgresException e)
                    {
                        Console.WriteLine("Brak dostępu!, " + e.Message);
                        conn.Close();
                        return false;
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
                return true;
            }
        }
        public static string QueryArguments(List<string> arguments)
        {
            
            string queryArgs = "";
            foreach (string argument in arguments)
            {
                queryArgs += "'" + argument + "',";
            }
            return queryArgs.TrimEnd(','); 
        }

        //public static void InsertData(string connString, string[] aText, string procedure)
        //{
        //    string tmp = null;
        //    List<string> arguments = new List<string>();

        //    foreach (string argument in aText)
        //    {
        //        Console.WriteLine(argument + ": ");
        //        tmp = Console.ReadLine();
        //        arguments.Add(tmp);

        //    }

        //    using (var conn = new NpgsqlConnection(connString))
        //    {
        //        procedure  = procedure.TrimEnd(')',';');
        //        string myQuery = String.Format("call {0}{1});", procedure, QueryArguments(arguments));

        //        using (var cmd = new NpgsqlCommand(myQuery, conn))
        //        {
        //            conn.Open();
        //            try
        //            {
        //                var rdr = cmd.ExecuteReader();
        //                Console.WriteLine("Dodano wpis do bazy");
        //            }
        //            catch (PostgresException e)
        //            {
        //                Console.WriteLine("Próba wpisu nieudana!, " + e.Message);
        //            }
        //            finally
        //            {
        //                conn.Close();
        //            }
        //        }
        //    }
        //}

        public static void InsertData(string connString, List<String> arguments, string procedure)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                procedure = procedure.TrimEnd(')', ';');
                string myQuery = String.Format("call {0}{1});", procedure, QueryArguments(arguments));
                Console.WriteLine(myQuery);
                using (var cmd = new NpgsqlCommand(myQuery, conn))
                {
                    conn.Open();
                    try
                    {
                        var rdr = cmd.ExecuteReader();
                        Console.WriteLine("Dodano wpis do bazy");
                    }
                    catch (PostgresException e)
                    {
                        Console.WriteLine("Próba wpisu nieudana!, " + e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateData(string connString, List<String> arguments, string procedure)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                procedure = procedure.TrimEnd(')', ';');
                string myQuery = String.Format("call {0}{1});", procedure, QueryArguments(arguments));

                using (var cmd = new NpgsqlCommand(myQuery, conn))
                {
                    conn.Open();
                    try
                    {
                        var rdr = cmd.ExecuteReader();
                        Console.WriteLine("Edytowano wpis w bazie");
                    }
                    catch (PostgresException e)
                    {
                        Console.WriteLine("Próba edycji nieudana!, " + e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void DeleteData(string connString, List<String> arguments, string procedure)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                procedure = procedure.TrimEnd(')', ';');
                string myQuery = String.Format("call {0}{1});", procedure, QueryArguments(arguments));

                using (var cmd = new NpgsqlCommand(myQuery, conn))
                {
                    conn.Open();
                    try
                    {
                        var rdr = cmd.ExecuteReader();
                        Console.WriteLine("Usunięyto pomyślnie");
                    }
                    catch (PostgresException e)
                    {
                        Console.WriteLine("Próba usunięcia nieudana!, " + e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void DeletePracownicy(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Imię: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "deletePracownik();";
            DeleteData(connString, arguments, procedure);
        }

        public static void DeleteKlienci(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "deleteKlient();";
            DeleteData(connString, arguments, procedure);
        }
        public static void DeleteOferta(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "deleteAsortyment();";
            DeleteData(connString, arguments, procedure);
        }

        static void InsertPracownicy(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Imię: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Miejscowość: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Ulica: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr domu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr lokalu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Kod pocztowy: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Stanowisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "createPracownik();";
            InsertData(connString, arguments, procedure);
        }

        static void InsertKlienciOsoba(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Imię: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);
                
            string procedure = "createklientosoba();";
            InsertData(connString, arguments, procedure);
        }

        static void InsertKlienciFirma(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Nazwa: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("NIP: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Miejscowość: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Ulica: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr domu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr lokalu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Kod pocztowy: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "createklientfirma();";
            InsertData(connString, arguments, procedure);
        }
        static void InsertOferta(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Nazwa: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr egzemplarza: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Liczba sztuk: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "createasortyment();";
            InsertData(connString, arguments, procedure);
        }
        static void InsertSprzedaze(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id asortyemntu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Id pracownika: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Cena: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Data sprzedaży: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Id klienta: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Id zwrotu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "createsprzedaż();";
            InsertData(connString, arguments, procedure);
        }


        static void InsertZamowienia(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id asortyemntu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Id pracownika: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Cena: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Data zamównienia: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "createzamówienie();";
            InsertData(connString, arguments, procedure);
        }

        static void InsertZwroty(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id sprzedaży: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Id pracownika: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr komórkowy telefonu zwracającego: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Data zwrotu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Czy to zwrot gwarancyjny(true/false): ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "createzwrot();";
            InsertData(connString, arguments, procedure);
        }

        static void UpdatePracownicy(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Imię: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Miejscowość: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Ulica: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr domu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr lokalu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Kod pocztowy: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Stanowisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "updatePracownik();";
            UpdateData(connString, arguments, procedure);
        }
        static void UpdateKlienciOsoba(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Imię: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwisko: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "updateklientosoba();";
            UpdateData(connString, arguments, procedure);
        }

        static void UpdatelienciFirma(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwa: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("NIP: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Miejscowość: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Ulica: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr domu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr lokalu: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Kod pocztowy: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "updateklientfirma();";
            UpdateData(connString, arguments, procedure);
        }

        static void UpdateOferta(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            Console.WriteLine("Id: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nazwa: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr seryjny: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Producent: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Nr egzemplarza: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Kategoria: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            Console.WriteLine("Liczba sztuk: ");
            tmp = Console.ReadLine();
            arguments.Add(tmp);

            string procedure = "updateOferta();";
            UpdateData(connString, arguments, procedure);
        }
    }

}


using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Npgsql;

namespace ConsoleDB
{
    public class Program
    {
        private static string Host = "localhost";
        private static string DBname = "sklep_komputerowy";
        private static string Port = "5432";

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
            IMenuStrategy subMenu = null;
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
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Błąd wyboru opcji");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Wybrano wyjście!");
                        return;
                    case 1:
                        subMenu = new PracwonicyStrategy();
                        break;
                    case 2:
                        subMenu = new ZwrotyStrategy();
                        break;
                    case 3:
                        subMenu = new ZamowieniaStrategy();
                        break;
                    case 4:
                        subMenu = new SprzedazeStrategy();
                        break;
                    case 5:
                        subMenu = new OfertaStrategy();
                        break;
                    case 6:
                        subMenu = new KlienciStrategy();
                        break;
                    default:
                        Console.WriteLine("Zła opcja!");
                        break;
                }
                
                if(subMenu is not null)                
                {
                    subMenu.ShowMenuFor(connString);
                    subMenu = null;
                }
            }
        }

        public static bool IsOnlyNumbersValid(string number)
        {
            if (number == "") 
            {
                Console.WriteLine("Błąd, nic nie wprowadzono");
                return false;
            } 
            else if (Regex.IsMatch(number, @"\D+")) 
            {
                Console.WriteLine("Wprowadż tylko cyfry.");
                return false;
            } 
            else 
            {
                return true;
            }
        }
        public static bool IsOnlyTextValid(string str) 
        {
            if (str == "")
            {
                Console.WriteLine("Błąd, nic nie wprowadzono");
                return false;
            }
            else if (IsOnlyTextAndNumbersValid(str))
            {
                if (Regex.IsMatch(str, @"\d+"))
                {
                    Console.WriteLine("Wprowadż tylko litery.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool IsOnlyTextAndNumbersValid(string str)
        {
            if (str == "")
            {
                Console.WriteLine("Błąd, nic nie wprowadzono");
                return false;
            } 
            else if (Regex.IsMatch(str, @"\W+")) 
            {
                Console.WriteLine("Wprowadż tylko litery i cyfry.");
                return false;
            } 
            else 
            {
                return true;
            }
        }

        public static bool IsPhoneNumberValid(string number)
        {
            if (IsOnlyNumbersValid(number))
            {
                if (number.Length == 9)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("To nie jest poprawny nr telefonu");
                }
            }
            return false;
        }
        public static bool IsNIPValid(string number)
        {
            if (IsOnlyNumbersValid(number))
            {
                if (number.Length == 10)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("To nie jest poprawny NIP");
                }
            }
            return false;
        }

        public static bool IsDateValid(string str)
        {
            if (str == "")
            {
                Console.WriteLine("Błąd, nic nie wprowadzono");
                return false;
            }
            else if (Regex.IsMatch(str, @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Błąd, data jest niepoprawny");
                return false;
            }
        }

        public static bool IsPostalCodeValid(string str)
        {
            if (str == "")
            {
                Console.WriteLine("Błąd, nic nie wprowadzono");
                return false;
            }
            else if (Regex.IsMatch(str, @"^\d{2}-\d{3}$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Błąd, kod pocztowy jest niepoprawny");
                return false;
            }
        }

        public static bool IsPriceValid(string str)
        {
            if (str == "")
            {
                Console.WriteLine("Błąd, nic nie wprowadzono");
                return false;
            }
            else if (Regex.IsMatch(str, @"^\d{0,8}(\.\d{1,2})?$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Błąd, podana cena nie jest prawidłowa");
                return false;
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
                if (argument == "null")
                {
                    queryArgs +=  argument + ",";
                } else
                {
                    queryArgs += "'" + argument + "',";
                }
            }
            return queryArgs.TrimEnd(','); 
        }

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

        static List<string> GetOsobaData(List<string> arguments)
        {
            string tmp = null;
            do
            {
                Console.WriteLine("Imię: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nazwisko: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            return arguments;
        }
        static List<string> GetAdresData(List<string> arguments)
        {
            string tmp = null;
            do
            {
                Console.WriteLine("Miejscowość: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Ulica: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nr domu: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nr lokalu: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Kod pocztowy: ");
                tmp = Console.ReadLine();
            } while (!IsPostalCodeValid(tmp));
            arguments.Add(tmp);
            return arguments;
        }

        static List<String> GetIdData(List<string> arguments)
        {
            string tmp = null;
            do
            {
                Console.WriteLine("Id: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            return arguments;
        }


        public static void DeletePracownicy(string connString)
        {
            List<string> arguments = new List<string>();

            GetOsobaData(arguments);

            string procedure = "deletePracownik();";
            DeleteData(connString, arguments, procedure);
        }

        public static void DeleteKlienci(string connString)
        {
            List<string> arguments = new List<string>();

            GetIdData(arguments);

            string procedure = "deleteKlient();";
            DeleteData(connString, arguments, procedure);
        }
        public static void DeleteOferta(string connString)
        {

            List<string> arguments = new List<string>();

            GetIdData(arguments);

            string procedure = "deleteAsortyment();";
            DeleteData(connString, arguments, procedure);
        }
        

        internal static void InsertPracownicy(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            GetOsobaData(arguments);
            GetAdresData(arguments);

            do
            {
                Console.WriteLine("Stanowisko: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            string procedure = "createPracownik();";
            InsertData(connString, arguments, procedure);
        }

        internal static void InsertKlienciOsoba(string connString)
        {
            List<string> arguments = new List<string>();

            GetOsobaData(arguments);

            string procedure = "createklientosoba();";
            InsertData(connString, arguments, procedure);
        }

        internal static void InsertKlienciFirma(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            do
            {
                Console.WriteLine("Nazwa: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("NIP: ");
                tmp = Console.ReadLine();
            } while (!IsNIPValid(tmp));
            arguments.Add(tmp);

            GetAdresData(arguments);

            string procedure = "createklientfirma();";
            InsertData(connString, arguments, procedure);
        }
        internal static void InsertOferta(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            do
            {
                Console.WriteLine("Nazwa: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nr egzemplarza: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Liczba sztuk: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            string procedure = "createasortyment();";
            InsertData(connString, arguments, procedure);
        }
        internal static void InsertSprzedaze(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            do
            {
                Console.WriteLine("Id asortyemntu: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Id pracownika: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Cena: ");
                tmp = Console.ReadLine();
            } while (!IsPriceValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Data sprzedaży: ");
                tmp = Console.ReadLine();
            } while (!IsDateValid(tmp));
            arguments.Add(tmp);

            do 
            { 
                Console.WriteLine("Id klienta: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Id zwrotu: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            string procedure = "createsprzedaż();";
            InsertData(connString, arguments, procedure);
        }


        internal static void InsertZamowienia(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            do
            {
                Console.WriteLine("Id asortyemntu: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Id pracownika: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Cena: ");
                tmp = Console.ReadLine();
            } while (!IsPriceValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Data zamównienia: ");
                tmp = Console.ReadLine();
            } while (!IsDateValid(tmp));
            arguments.Add(tmp);

            string procedure = "createzamówienie();";
            InsertData(connString, arguments, procedure);
        }

        internal static void InsertZwroty(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            do
            {
                Console.WriteLine("Id sprzedaży: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Id pracownika: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nr komórkowy telefonu zwracającego: ");
                tmp = Console.ReadLine();
            } while (!IsPhoneNumberValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Data zwrotu: ");
                tmp = Console.ReadLine();
            } while (!IsPriceValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Czy to zwrot gwarancyjny(true/false): ");
                tmp = Console.ReadLine();
            } while (tmp != "true" | tmp != "false");
            arguments.Add(tmp);

            string procedure = "createzwrot();";
            InsertData(connString, arguments, procedure);
        }

        internal static void UpdatePracownicy(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            GetIdData(arguments);
            GetOsobaData(arguments);
            GetAdresData(arguments);

            do
            {
                Console.WriteLine("Stanowisko: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            string procedure = "updatePracownik();";
            UpdateData(connString, arguments, procedure);
        }
        internal static void UpdateKlienciOsoba(string connString)
        {
            List<string> arguments = new List<string>();

            GetIdData(arguments);

            GetOsobaData(arguments);

            string procedure = "updateklientosoba();";
            UpdateData(connString, arguments, procedure);
        }

        internal static void UpdatelienciFirma(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            GetIdData(arguments);

            do
            {
                Console.WriteLine("Nazwa: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("NIP: ");
                tmp = Console.ReadLine();
            } while (!IsNIPValid(tmp));
            arguments.Add(tmp);

            GetAdresData(arguments);

            string procedure = "updateklientfirma();";
            UpdateData(connString, arguments, procedure);
        }

        internal static void UpdateOferta(string connString)
        {
            string tmp = null;
            List<string> arguments = new List<string>();

            GetIdData(arguments);

            do
            {
                Console.WriteLine("Nazwa: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nr seryjny: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Producent: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Nr egzemplarza: ");
                tmp = Console.ReadLine();
                if (tmp == "null") break;
            } while (!IsOnlyTextAndNumbersValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Kategoria: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyTextValid(tmp));
            arguments.Add(tmp);

            do
            {
                Console.WriteLine("Liczba sztuk: ");
                tmp = Console.ReadLine();
            } while (!IsOnlyNumbersValid(tmp));
            arguments.Add(tmp);

            string procedure = "updateOferta();";
            UpdateData(connString, arguments, procedure);
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
    }
}


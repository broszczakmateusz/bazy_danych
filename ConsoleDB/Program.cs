using System;
using System.Data;
using Npgsql;

namespace ConsoleDB
{
    internal class Program
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "sklep_komputerowy";
        private static string Password = "mateusz";
        private static string Port = "5432";

        static void Main(string[] args)
        {
            // Build connection string using parameters from portal
            //
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Opening connection\n");
                conn.Open();

                string prac = "SELECT * FROM pracownicy";
                string zwroty = "SELECT * FROM zwroty";
                string zam = "SELECT * FROM zamówienia";
                string sprz = "SELECT * FROM sprzedaże";
                string ofer = "SELECT * FROM oferta";
                string klie = "SELECT * FROM klienci";

                /*Pracownicy*/
                Console.Out.WriteLine("Pracownicy: \n");
                var cmd = new NpgsqlCommand(prac, conn);
                
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", rdr.GetName(0), rdr.GetName(1),
                rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2), rdr.GetString(3), (rdr.IsDBNull(4)) ? "-" : rdr.GetString(4), rdr.GetString(5), (rdr.IsDBNull(6)) ? "-" :  rdr.GetString(6), rdr.GetString(7));
                    //string tmp = "";
                    //for (int i = 0; i < 8; i++)
                    //{
                    //    tmp = rdr.IsDBNull(i)) ?  "-" :  rdr.GetInt32(i);
                    //}
                }
                rdr.Close();
                Console.WriteLine("\n");

                /*zwroty*/
                Console.Out.WriteLine("Zwroty: \n");
                cmd = new NpgsqlCommand(zwroty, conn);
                rdr = cmd.ExecuteReader();
                
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9}", rdr.GetName(0), rdr.GetName(1),
                rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7), rdr.GetName(8), rdr.GetName(9));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9}", rdr.GetInt32(0), rdr.GetDate(1),
                     rdr.GetInt32(2), rdr.GetBoolean(3), rdr.GetString(4), (rdr.IsDBNull(5)) ? "-" : rdr.GetString(5), (rdr.IsDBNull(6)) ? "-" : rdr.GetString(6), rdr.GetString(7), rdr.GetInt32(8), (rdr.IsDBNull(9)) ? "-" : rdr.GetString(9));
                }
                rdr.Close();

                Console.WriteLine("\n");

                /*zamówienia*/
                Console.Out.WriteLine("Zamówienia: \n");
                cmd = new NpgsqlCommand(zam, conn);
                rdr = cmd.ExecuteReader();

                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} ", rdr.GetName(0), rdr.GetName(1),
                     rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}", rdr.GetInt32(0), rdr.GetInt32(1),
                     rdr.GetString(2), (rdr.IsDBNull(3)) ? "-" : rdr.GetString(3), rdr.GetDate(4), rdr.GetDouble(5).ToString("N2"), rdr.GetInt32(6), rdr.GetString(7));
                }
                rdr.Close();
                Console.WriteLine("\n");

                /*Sprzedaże*/
                Console.Out.WriteLine("Sprzedaże: \n");
                cmd = new NpgsqlCommand(sprz, conn);
                rdr = cmd.ExecuteReader();

                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9}", rdr.GetName(0), rdr.GetName(1),
                    rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7), rdr.GetName(8), rdr.GetName(9));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} ", rdr.GetInt32(0), rdr.GetInt32(1),
                     rdr.GetString(2), (rdr.IsDBNull(3)) ? "-" : rdr.GetString(3), rdr.GetDate(4), rdr.GetDouble(5).ToString("N2"), rdr.GetInt32(6), rdr.GetString(7), (rdr.IsDBNull(8)) ? "-" : rdr.GetString(8), (rdr.IsDBNull(9)) ? "-" : rdr.GetInt64(9));
                }
                rdr.Close();
                Console.WriteLine("\n");

                /*Oferta*/
                Console.Out.WriteLine("Oferta: \n");
                cmd = new NpgsqlCommand(ofer, conn);
                rdr = cmd.ExecuteReader();

                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", rdr.GetName(0), rdr.GetName(1),
                    rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", rdr.GetString(0), (rdr.IsDBNull(1)) ? "-" : rdr.GetString(1),
                     (rdr.IsDBNull(2)) ? "-" : rdr.GetString(2), (rdr.IsDBNull(3)) ? "-" : rdr.GetString(3), rdr.GetString(4), rdr.GetInt32(5));
                }
                rdr.Close();
                Console.WriteLine("\n");

                /*Klienci*/
                Console.Out.WriteLine("Klienci: \n");
                cmd = new NpgsqlCommand(klie, conn);
                rdr = cmd.ExecuteReader();

                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}", rdr.GetName(0), rdr.GetName(1),
                     rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7), rdr.GetName(8));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}", rdr.GetInt32(0), (rdr.IsDBNull(1)) ? "-" : rdr.GetString(1),
                     (rdr.IsDBNull(2)) ? "-" : rdr.GetString(2), (rdr.IsDBNull(3)) ? "-" : rdr.GetInt64(3), (rdr.IsDBNull(4)) ? "-" : rdr.GetString(4), (rdr.IsDBNull(5)) ? "-" : rdr.GetString(5)
                     , (rdr.IsDBNull(6)) ? "-" : rdr.GetString(6), (rdr.IsDBNull(7)) ? "-" : rdr.GetString(7), (rdr.IsDBNull(8)) ? "-" : rdr.GetString(8));
                }
                rdr.Close();

            }
            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }




    }
}

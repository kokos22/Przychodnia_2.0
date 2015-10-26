using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Przychodnia
{
    static class TworzenieZapytan
    {
        //test
        public delegate void ZarzadzajDanymiZselecta(MySqlDataReader dr);
        //static TworzenieZapytan() { };

        /// <summary>
        /// Uniwersalne tworzenie SELECTÓw
        /// </summary>
        /// <param name="iSelectColumns">[0]: nazwa tabeli, [1..n]: nazwy kolumn</param>
        /// <param name="iParamsList">WhereParams(Nazwa_kolumny, wartość_kolumny)</param>
        /// <returns>Cały gotowy select</returns>
        public static string StworzSelecta(string[] iSelectColumns, params WhereParams[] iParamsList)
        {
            bool jest = false;
            string select = "";
            string where = "";

            for (int i = 0; i < iParamsList.Length; i++)
            {
                if(iParamsList[i].GetParams() != "")
                {
                    if (jest) { select += " and"; }
                    select += iParamsList[i].GetParams();
                    jest = true;
                }
            }
            
            if (jest) { where = " where" + select; }
            /*
            iSelectList:
            0: FROM [table name]
            1...n: columns
            */

            string columnNames = "";
            for (int i = 1; i < iSelectColumns.Length; i++)
            {
                if (i == 1)
                    columnNames += " " + iSelectColumns[i];
                else
                    columnNames += ", " + iSelectColumns[i];
            }

            return "SELECT " + columnNames + " FROM " + iSelectColumns[0] + " " + where + ";";
        }


        /// <summary>
        /// Wykonuje iSelecta na bazie, zwraca MySqlDataReader z wynikami
        /// </summary>
        /// <param name="iSelect">string z SELECTEM</param>
        /// <param name="iGetReaderData">Funkcja(MySqlDataReader), ogarniająca dane</param>
        public static void WykonajSelecta(string iSelect, Action<MySqlDataReader> iGetReaderData)
        {
            //MySqlDataReader readerToReturn;

            string MyConnectionString = "Server=localhost;Database=mydb1;Uid=root;";
            MySqlConnection con = new MySqlConnection(MyConnectionString);
            con.Open();

            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = iSelect;
                MySqlDataReader reader = cmd.ExecuteReader();

                //Delegata, który ogarnie dane

                iGetReaderData(reader);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            //no i chuj, żeby zamknąć połączenie trzeba tutaj wjebać delegata
            //return readerToReturn;
        }

        /// <summary>
        /// To trzeba podpiąć pod StworzSelecta()
        /// </summary>
        /// <param name="iLogin"></param>
        /// <returns></returns>
        public static string StworzSelectaLoginu(string iLogin)
        {
            return  "SELECT login, haslo FROM user WHERE login = " + iLogin + ";";
        }
    }
}

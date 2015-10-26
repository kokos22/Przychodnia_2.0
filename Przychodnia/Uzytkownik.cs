using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    static class Uzytkownik
    {
        static Uzytkownik()
        {
            Login = null;
            PoziomDostepu = 0;
        }

        public static string Login { get; private set; }
        public static int PoziomDostepu { get; private set; }
        

        /// <summary>
        /// Sprawdza hasło.
        /// Jeśli nie ma rekordu z loginem, zwraca "brak loginu"
        /// Jeśli rekord jest, ale hasło nie pasuje, zwraca "złe hasło"
        /// Jeśli wszystko się zgadza, zwraca "t"
        /// </summary>
        /// <param name="iLogin"></param>
        /// <param name="iHaslo"></param>
        /// <returns></returns>
        public static string SprawdzHaslo(string iLogin, string iHaslo)
        {
            TworzenieZapytan.StworzSelectaLoginu(iLogin);
            //sprawdz haslo

            //ustaw poziom dostepu

            return "";
        }
    }
}

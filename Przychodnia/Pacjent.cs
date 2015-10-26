using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    class Pacjent
    {
        public int ID { get; private set; }
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Adres { get; private set; }
        public string Email { get; private set; }

        public Pacjent(int iId, string iImie, string iNazwisko, string iAdres, string iEmail)
        {
            this.ID = iId;
            this.Imie = iImie;
            this.Nazwisko = iNazwisko;
            this.Adres = iAdres;
            this.Email = iEmail;
        }
    }
}
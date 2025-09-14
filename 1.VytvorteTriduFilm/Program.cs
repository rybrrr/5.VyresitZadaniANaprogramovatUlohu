using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.VytvorteTriduFilm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Film film1 = new Film("Princezna Nevěsta", "Rob", "Reiner", 1987);
            Film film2 = new Film("Nevěsta Princezna", "Rob2", "Reiner2", 1990);
            Film film3 = new Film("Privěsta Nencezna", "Rob3", "Reiner3", 1993);
        
            List<Film> films = new List<Film>();
            films.Add(film1);
            films.Add(film2);
            films.Add(film3);

            Random rnd = new Random();
            foreach (Film film in films)
            {
                for (int i = 0; i<15; i++)
                {
                    film.PridejHodnoceni(rnd.Next(0, 6));
                }
            }

            Film nejlepsiFilm = null;
            Film filmSNejdelsimNazvem = null;
            foreach (Film film in films)
            {
                if (nejlepsiFilm == null || nejlepsiFilm.Hodnoceni < film.Hodnoceni)
                    nejlepsiFilm = film;
                if (filmSNejdelsimNazvem == null || filmSNejdelsimNazvem.Nazev.Length < film.Nazev.Length)
                    filmSNejdelsimNazvem = film;
            }

            Console.WriteLine($"Nejlepsi film: {nejlepsiFilm.Nazev}");
            Console.WriteLine($"Film s nejdelsim nazvem: {filmSNejdelsimNazvem.Nazev}");

            foreach (Film film in films)
            {
                if (film.Hodnoceni < 3)
                    Console.WriteLine($"{film.Nazev} je odpad! Má hodnocení jen {film.Hodnoceni}.");
            }

            foreach (Film film in films)
                Console.WriteLine(film.ToString());
        }
    }

    class Film
    {
        public string Nazev;
        public string JmenoRezisera;
        public string PrijmeniRezisera;
        public int RokVzniku;

        public double Hodnoceni { get; private set; }
        private List<int> ListHodnoceni;

        public Film(string nazev, string reziserJmeno, string resizerPrijmeni, int rok)
        {
            Nazev = nazev;
            JmenoRezisera = reziserJmeno;
            PrijmeniRezisera= resizerPrijmeni;
            RokVzniku = rok;
            ListHodnoceni = new List<int>();
        }

        public void PridejHodnoceni(int hodnoceni)
        {
            ListHodnoceni.Add(hodnoceni);

            int sum = ListHodnoceni.Sum(x => x);
            int pocet = ListHodnoceni.Count;

            Hodnoceni = (double) sum / pocet;
        }

        public void VypisVsechHodnoceni()
        {
            foreach (int i in ListHodnoceni)
            {
                Console.WriteLine(i);
            }
        }

        public override string ToString()
        {
            return $"{Nazev} ({RokVzniku}; {PrijmeniRezisera}, {JmenoRezisera[0]}): {Hodnoceni}";
        }
    }
}

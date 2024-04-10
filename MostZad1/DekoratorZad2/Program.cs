namespace DekoratorZad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrzedmiotBiblioteki ksiazka = new Ksiazka("Worley", "Inside ASP.NET", 10);
            PrzedmiotBiblioteki film = new Film("Spielberg", "Jaws", 92, 23);

            Wypozyczalny wypozyczalnyFilm = new Wypozyczalny(film);
            wypozyczalnyFilm.WypozyczPrzedmiot("Czytelnik #1");
            wypozyczalnyFilm.WypozyczPrzedmiot("Czytelnik #2");

            ksiazka.Pokaz();
            film.Pokaz();

            Console.WriteLine("\nDodawanie funkcjonalności wypożyczania do filmu:");
            wypozyczalnyFilm.Pokaz();
        }
    }

    abstract class PrzedmiotBiblioteki
    {
        public int LiczbaKopii { get; set; }

        public abstract void Pokaz();
    }

    class Ksiazka : PrzedmiotBiblioteki
    {
        private string _autor;
        private string _tytul;

        public Ksiazka(string autor, string tytul, int liczbaKopii)
        {
            _autor = autor;
            _tytul = tytul;
            LiczbaKopii = liczbaKopii;
        }

        public override void Pokaz()
        {
            Console.WriteLine("\nKsiążka -----");
            Console.WriteLine(" Autor: " + _autor);
            Console.WriteLine(" Tytuł: " + _tytul);
            Console.WriteLine(" # Kopie: " + LiczbaKopii);
        }
    }

    class Film : PrzedmiotBiblioteki
    {
        private string _rezyser;
        private string _tytul;
        private int _czasTrwania;

        public Film(string rezyser, string tytul, int czasTrwania, int liczbaKopii)
        {
            _rezyser = rezyser;
            _tytul = tytul;
            _czasTrwania = czasTrwania;
            LiczbaKopii = liczbaKopii;
        }

        public override void Pokaz()
        {
            Console.WriteLine("\nFilm -----");
            Console.WriteLine(" Reżyser: " + _rezyser);
            Console.WriteLine(" Tytuł: " + _tytul);
            Console.WriteLine(" # Kopie: " + LiczbaKopii);
            Console.WriteLine(" Czas trwania: " + _czasTrwania);
        }
    }
    abstract class Dekorator : PrzedmiotBiblioteki
    {
        protected PrzedmiotBiblioteki przedmiotBiblioteki;

        public Dekorator(PrzedmiotBiblioteki przedmiot)
        {
            przedmiotBiblioteki = przedmiot;
        }

        public override void Pokaz()
        {
            przedmiotBiblioteki.Pokaz();
        }
    }

    class Wypozyczalny : Dekorator
    {
        protected List<string> wypozyczajacy = new List<string>();

        public Wypozyczalny(PrzedmiotBiblioteki przedmiot) : base(przedmiot) { }

        public void WypozyczPrzedmiot(string nazwaWypozyczajacego)
        {
            wypozyczajacy.Add(nazwaWypozyczajacego);
            przedmiotBiblioteki.LiczbaKopii--;
        }

        public override void Pokaz()
        {
            base.Pokaz();
            foreach (string wypozyczajacy in wypozyczajacy)
            {
                Console.WriteLine(" czytelnik: " + wypozyczajacy);
            }
        }
    }
}

namespace PelnomocnikZad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Przedmiot pelnomocnik = new Pelnomocnik();
            pelnomocnik.Zapytanie();
        }
    }

    abstract class Przedmiot
    {
        public abstract void Zapytanie();
    }

    class KonkretnyPrzedmiot : Przedmiot
    {
        public override void Zapytanie()
        {
            Console.WriteLine("Wywołanie KonkretnyPrzedmiot.Zapytanie()");
        }
    }

    class Pelnomocnik : Przedmiot
    {
        private KonkretnyPrzedmiot _konkretnyPrzedmiot;

        public override void Zapytanie()
        {
            if (_konkretnyPrzedmiot == null)
            {
                _konkretnyPrzedmiot = new KonkretnyPrzedmiot();
            }

            _konkretnyPrzedmiot.Zapytanie();
        }
    }
}

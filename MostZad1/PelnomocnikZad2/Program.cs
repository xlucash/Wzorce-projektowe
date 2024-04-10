namespace PelnomocnikZad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pelnomocnik pelnomocnikZAutoryzacja = new Pelnomocnik("dobrehaslo");
            Console.WriteLine(pelnomocnikZAutoryzacja.PobierzDane());

            Pelnomocnik pelnomocnikBezAutoryzacji = new Pelnomocnik("zlehaslo");
            Console.WriteLine(pelnomocnikBezAutoryzacji.PobierzDane());
        }
    }

    abstract class Folder
    {
        public abstract string PobierzDane();
    }

    class KonkretnyFolder : Folder
    {
        private string Dane = "Bardzo ważne dane";

        public override string PobierzDane()
        {
            Console.WriteLine("KonkretnyFolder: Uruchomiony");
            return Dane;
        }
    }

    class Pelnomocnik : Folder
    {
        private KonkretnyFolder _konkretnyFolder;
        private bool _autoryzowany = false;
        private string _haslo = "dobrehaslo";

        public Pelnomocnik(string haslo)
        {
            if (haslo == _haslo)
            {
                _autoryzowany = true;
                Console.WriteLine("Pełnomocnik: Uruchomiony");
            }
            else
            {
                Console.WriteLine("Pełnomocnik: Odmowa dostępu");
            }
        }

        public override string PobierzDane()
        {
            if (_autoryzowany)
            {
                if (_konkretnyFolder == null)
                {
                    _konkretnyFolder = new KonkretnyFolder();
                }
                return "Dane z pełnomocnika to " + _konkretnyFolder.PobierzDane();
            }
            else
            {
                return "Pełnomocnik: Odmowa dostępu";
            }
        }
    }
}

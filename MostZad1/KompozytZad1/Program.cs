namespace KompozytZad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kompozyt root = new Kompozyt("root");
            root.Dodaj(new Lisc("Liść A"));
            root.Dodaj(new Lisc("Liść B"));

            Kompozyt comp = new Kompozyt("Kompozyt X");
            comp.Dodaj(new Lisc("Liść XA"));
            comp.Dodaj(new Lisc("Liść XB"));

            root.Dodaj(comp);
            root.Dodaj(new Lisc("Liść C"));

            root.Pokaz(0);
        }
    }

    abstract class Element
    {
        protected string nazwa;

        public Element(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public abstract void Dodaj(Element c);
        public abstract void Usun(Element c);
        public abstract void Pokaz(int poziom);
    }

    class Kompozyt : Element
    {
        private List<Element> _dzieci = new List<Element>();

        public Kompozyt(string nazwa) : base(nazwa) { }

        public override void Dodaj(Element c)
        {
            _dzieci.Add(c);
        }

        public override void Usun(Element c)
        {
            _dzieci.Remove(c);
        }

        public override void Pokaz(int poziom)
        {
            Console.WriteLine(new String('-', poziom) + nazwa);
            foreach (Element element in _dzieci)
            {
                element.Pokaz(poziom + 2);
            }
        }
    }

    class Lisc : Element
    {
        public Lisc(string nazwa) : base(nazwa) { }

        public override void Dodaj(Element c)
        {
            Console.WriteLine("Nie można dodać do liścia");
        }

        public override void Usun(Element c)
        {
            Console.WriteLine("Nie można usunąć z liścia");
        }

        public override void Pokaz(int poziom)
        {
            Console.WriteLine(new String('-', poziom) + nazwa);
        }
    }
}

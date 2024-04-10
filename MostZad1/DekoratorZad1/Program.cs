namespace DekoratorZad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Komponent produkt = new Produkt();
            Komponent dekoratorA = new DekoratorA(produkt);
            Komponent dekoratorB = new DekoratorB(dekoratorA);

            dekoratorB.Operacja();
        }
    }

    abstract class Komponent
    {
        public abstract void Operacja();
    }

    class Produkt : Komponent
    {
        public override void Operacja()
        {
            Console.WriteLine("Produkt.Operacja()");
        }
    }

    abstract class Dekorator : Komponent
    {
        protected Komponent komponent;

        public Dekorator(Komponent komponent)
        {
            this.komponent = komponent;
        }

        public override void Operacja()
        {
            komponent.Operacja();
        }
    }

    class DekoratorA : Dekorator
    {
        public DekoratorA(Komponent komponent) : base(komponent) { }

        public override void Operacja()
        {
            base.Operacja();
            Console.WriteLine("DekoratorA.Operacja()");
        }
    }

    class DekoratorB : Dekorator
    {
        public DekoratorB(Komponent komponent) : base(komponent) { }

        public override void Operacja()
        {
            base.Operacja();
            DodatkowaFunkcjonalnosc();
        }

        private void DodatkowaFunkcjonalnosc()
        {
            Console.WriteLine("Wywołano dodatkową funkcjonalność z dekoratora B");
        }
    }
}

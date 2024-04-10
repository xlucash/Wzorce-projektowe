namespace MostZad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstrakcjaPochodna abstrakcja = new AbstrakcjaPochodna();

            abstrakcja.Implementacja = new SpecyficznaImplementacja();
            abstrakcja.MetodaImplementacji();

            abstrakcja.Implementacja = new JakasInnaImplementacja();
            abstrakcja.MetodaImplementacji();
        }
    }

    abstract class Implementacja
    {
        public abstract void MetodaImplementacji();
    }

    class Abstrakcja
    {
        protected Implementacja implementacja;

        public Implementacja Implementacja
        {
            set { implementacja = value; }
        }

        public virtual void MetodaImplementacji()
        {
            implementacja.MetodaImplementacji();
        }
    }

    class AbstrakcjaPochodna : Abstrakcja
    {
        public override void MetodaImplementacji()
        {
            implementacja.MetodaImplementacji();
        }
    }

    class SpecyficznaImplementacja : Implementacja
    {
        public override void MetodaImplementacji()
        {
            Console.WriteLine("SpecyficznaImplementacja MetodaImplementacji");
        }
    }

    class JakasInnaImplementacja : Implementacja
    {
        public override void MetodaImplementacji()
        {
            Console.WriteLine("JakasInnaImplementacja MetodaImplementacji");
        }
    }
}

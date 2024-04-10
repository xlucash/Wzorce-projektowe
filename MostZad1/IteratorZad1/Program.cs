using System.Collections;

namespace IteratorZad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpecyficznyKontener kontener = new SpecyficznyKontener();
            kontener[0] = "Element A";
            kontener[1] = "Element B";
            kontener[2] = "Element C";
            kontener[3] = "Element D";

            Console.WriteLine("Iteracja kolekcji:");
            Iterator iterator = kontener.StworzIterator();
            object item = iterator.Pierwszy();
            Console.WriteLine(item);
            while (!iterator.CzyKoniec())
            {
                item = iterator.Nastepny();
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

    public abstract class Iterator
    {
        public abstract object Pierwszy();
        public abstract object Nastepny();
        public abstract object PobierzElement();
        public abstract bool CzyKoniec();
    }

    public class SpecyficznyIterator : Iterator
    {
        private SpecyficznyKontener _kontener;
        private int _obecny = 0;

        public SpecyficznyIterator(SpecyficznyKontener kontener)
        {
            _kontener = kontener;
        }

        public override object Pierwszy()
        {
            _obecny = 0;
            return _kontener[_obecny];
        }

        public override object Nastepny()
        {
            object ret = null;
            if (_obecny < _kontener.Ilosc - 1)
            {
                ret = _kontener[++_obecny];
            }
            return ret;
        }

        public override object PobierzElement()
        {
            return _kontener[_obecny];
        }

        public override bool CzyKoniec()
        {
            return _obecny >= _kontener.Ilosc;
        }
    }

    public abstract class Kontener
    {
        public abstract Iterator StworzIterator();
    }

    public class SpecyficznyKontener : Kontener
    {
        private ArrayList _elementy = new ArrayList();

        public object this[int index]
        {
            get { return _elementy[index]; }
            set
            {
                if (index >= _elementy.Count)
                    _elementy.Add(value);
                else
                    _elementy[index] = value;
            }
        }

        public override Iterator StworzIterator()
        {
            return new SpecyficznyIterator(this);
        }

        public int Ilosc
        {
            get { return _elementy.Count; }
        }
    }
}

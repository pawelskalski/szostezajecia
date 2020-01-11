using System;
using System.Collections.Generic;
using System.Linq;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;

namespace lab6
{
    class Osoba
    {
        public int id;
        public string imie;
        public string nazwisko;

        public Osoba(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<int> lista = Enumerable.Range(100, 150).ToList();
            List<int> podzeilnaPrze3 = lista.Where(x => x % 3==0).ToList();
            int elNaStr = 25;
            int nrStr = 2;
            List<int> strona = lista.Skip(elNaStr * (nrStr - 1)).Take(elNaStr).ToList();

            double srednia = lista.Average();

            foreach(var item in strona)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(srednia);

            List<Osoba> osoby = Enumerable.Range(1, 50).Select(x => new Osoba() { id= x, imie = x.ToString(), nazwisko = "aaa" }).ToList();
            osoby[30].nazwisko = "bbb";

            List<string> nazwiska = osoby.Select(x => x.nazwisko).Distinct().ToList();

            foreach(var item in osoby)
            {
                Console.WriteLine($"{item.id} : {item.imie} {item.nazwisko}");
            }

            foreach (var item in nazwiska)
            {
                Console.WriteLine(item);
            }

            osoby.Select(x => x.nazwisko).Distinct().ToList().ForEach(Console.WriteLine);

            int pierwszy = lista.FirstOrDefault(x => x % 300 == 0);
            Console.WriteLine(pierwszy);
            */
            var intGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsInteger());
            var nameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var lastnameGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            Osoba random = new Osoba(intGenerator.Generate().Value, nameGenerator.Generate(), lastnameGenerator.Generate());


            List<Osoba> osoby = Enumerable.Range(1, 100).
                Select(x => new Osoba(intGenerator.Generate().Value, nameGenerator.Generate(), lastnameGenerator.Generate())).
                OrderBy(x => x.nazwisko).
                ThenBy(x => x.nazwisko).
                ToList();

            foreach (var item in osoby)
            {
                Console.WriteLine($"{item.id} : {item.imie} {item.nazwisko}");
            }
            //wygeneruj 100 osob i posortuj po nazwisku puzniej po imieniu

        }
    }
}

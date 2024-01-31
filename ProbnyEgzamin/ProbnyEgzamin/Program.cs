using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProbnyEgzamin
{
    public class Program
    {
        public static List<Serwis> listaserwisow = new List<Serwis>();
        public static List<Serwis> wynikWyszukiwania = new List<Serwis>();

        static void Main(string[] args)
        {
            ListaSerwisow listaSerwisow = new ListaSerwisow();
            Wlasciciel wlasciciel1 = new Wlasciciel("Jan", "Kowalski");
            Samochod samochod1 = new Samochod("ABC123", "Toyota", wlasciciel1);
            listaSerwisow.Dodaj(samochod1, "Przegląd roczny");
            listaSerwisow.Dodaj(samochod1, "Wymiana opon");

            Wlasciciel wlasciciel2 = new Wlasciciel("Anna", "Nowak");
            Samochod samochod2 = new Samochod("XYZ789", "Ford", wlasciciel2);
            listaSerwisow.Dodaj(samochod2, "Wymiana oleju", new DateTime(2024, 1, 25));
            wynikWyszukiwania = listaSerwisow.Wyszukaj(wlasciciel1);

            //Console.WriteLine("Serwisy dla właściciela Jan Kowalski:");
            foreach (Serwis serwis in wynikWyszukiwania)
            {
                Console.WriteLine(serwis.ToString());
            }
            //foreach (Serwis serwis in listaserwisow)
            //{
            //    Console.WriteLine(serwis.ToString());
            //}

        }

        public class Samochod
        {
            public string nrRejestracyjny;
            public string marka;
            public Wlasciciel wlasciciel;

            public Samochod(string nrRejestracyjny, string marka, Wlasciciel wlasciciel)
            {
                this.nrRejestracyjny = nrRejestracyjny;
                this.marka = marka;
                this.wlasciciel = wlasciciel;
            }
        }

        public class Serwis
        {
            DateTime data;
            public Samochod samochod;
            public string usluga;

            public Serwis(Samochod samochod, string usluga)
            {
                this.samochod = samochod;
                this.usluga = usluga;
                this.data = DateTime.Now;
            }

            public Serwis(DateTime data, Samochod samochod, string usluga)
            {
                this.data = data;
                this.samochod = samochod;
                this.usluga = usluga;
            }

            

            public override string ToString()
            {
                return $"{data:f}, {samochod.nrRejestracyjny}, {samochod.marka}, {usluga}";
            }
        }

        public class ListaSerwisow
        {
            // Removed the static keyword to have an instance-specific list
            

            public void Dodaj(Samochod s, string usluga)
            {
                Serwis serwis = new Serwis(s, usluga);
                listaserwisow.Add(serwis);
            }

            public void Dodaj(Samochod s, string usluga, DateTime data)
            {
                Serwis serwis = new Serwis(data, s, usluga);
                listaserwisow.Add(serwis);
            }

            public List<Serwis> Wyszukaj(Wlasciciel w)
            {
                List<Serwis> wynik = new List<Serwis>();
                foreach (var serwis in listaserwisow)
                {
                    if (serwis.samochod.wlasciciel.Equals(w))
                    {
                        wynik.Add(serwis);
                    }
                }
                return wynik;
            }
            public List<Serwis> Wszystkie()
            {
                List<Serwis> wynik = new List<Serwis>();
                foreach (var serwis in listaserwisow)
                {
                    wynik.Add(serwis);
                }
                return wynik;
            }
            
        }

        public struct Wlasciciel
        {
            public string imie;
            public string nazwisko;

            public Wlasciciel(string _imie, string _nazwisko)
            {
                this.imie = _imie;
                this.nazwisko = _nazwisko;
            }
        }
    }
}

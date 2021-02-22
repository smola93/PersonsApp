using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProjektApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void FindPerson()
        {
            Console.Clear();
            string chosenOption;
            Console.WriteLine("Nacisnij dany klawisz aby wybrac jedna z opcji, po czym wcisnij ENTER:");
            Console.WriteLine("1: Znajdź pracownika po numerze PESEL");
            Console.WriteLine("2: Znajdź pracownika po imieniu i nazwisku");
            Console.WriteLine("3: Wyjdź do menu glownego");
            chosenOption = Console.ReadLine();
            switch (chosenOption)
            {
                case "1":
                    FindByPesel();
                    break;
                case "2":
                    FindByNameAndSurname();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Podales niewlasciwą liczbe!");
                    Thread.Sleep(2000);
                    MainMenu();
                    break;

            }

            void FindByPesel()
            {
                Console.Clear();
                string pesel;
                string quit = "";
                Console.WriteLine("Podaj numer PESEL:");
                pesel = Console.ReadLine();
                Data data = new Data();
                List<Person> persons = data.GetByPesel(pesel).ToList();
                foreach (Person person in persons)
                {
                    Console.WriteLine($"Imie: {person.name}, Nazwisko: {person.surname}, Pesel: {person.pesel}, Typ zatrudnienia: {person.employmentType}, Pensja brutto: {person.bruttoString},");
                    Console.WriteLine($"Pensja netto: {person.nettoString}, Podatek dochodowy: {person.taxString}, Skladka emerytalna: {person.pensionContributionString}, Skladka rentowa: {person.disabilityPensionContributionString}");
                    Console.WriteLine("");
                }
                bool isEmpty = !persons.Any();
                if (isEmpty)
                {
                    Console.WriteLine("Nie znaleziono!");
                }
                do
                {
                    Console.WriteLine("Aby wrocic do menu nacisnij klawisz 'q' po czym wcisnij ENTER");
                    quit = Console.ReadLine();
                }
                while (quit != "q");
                if (quit == "q")
                {
                    Console.Clear();
                    MainMenu();
                }
            }
            void FindByNameAndSurname()
            {
                Console.Clear();
                string name;
                string surname;
                string quit = "";
                Console.WriteLine("Podaj imie:");
                name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko:");
                surname = Console.ReadLine();
                Data data = new Data();
                List<Person> persons = data.GetByNameAndSurname(name, surname).ToList();
                foreach (Person person in persons)
                {
                    Console.WriteLine($"Imie: {person.name}, Nazwisko: {person.surname}, Pesel: {person.pesel}, Typ zatrudnienia: {person.employmentType}, Pensja brutto: {person.bruttoString},");
                    Console.WriteLine($"Pensja netto: {person.nettoString}, Podatek dochodowy: {person.taxString}, Skladka emerytalna: {person.pensionContributionString}, Skladka rentowa: {person.disabilityPensionContributionString}");
                    Console.WriteLine("");
                }
                bool isEmpty = !persons.Any();
                if (isEmpty)
                {
                    Console.WriteLine("Nie znaleziono!");
                }
                do
                {
                    Console.WriteLine("Aby wrocic do menu nacisnij klawisz 'q' po czym wcisnij ENTER");
                    quit = Console.ReadLine();
                }
                while (quit != "q");
                if (quit == "q")
                {
                    Console.Clear();
                    MainMenu();
                }
            }
        }
        static void GetPerson()
        {
            string quit = "";
            do
            {
                Console.Clear();
                Data data = new Data();
                List<Person> persons = data.GetAllPersons().ToList();
                foreach (Person person in persons)
                {
                    Console.WriteLine($"Imie: {person.name}, Nazwisko: {person.surname}, Pesel: {person.pesel}, Typ zatrudnienia: {person.employmentType}, Pensja brutto: {person.bruttoString},");
                    Console.WriteLine($"Pensja netto: {person.nettoString}, Podatek dochodowy: {person.taxString}, Skladka emerytalna: {person.pensionContributionString}, Skladka rentowa: {person.disabilityPensionContributionString}");
                    Console.WriteLine("");
                }
                Console.WriteLine("Aby wrocic do menu nacisnij klawisz 'q' po czym wcisnij ENTER");
                quit = Console.ReadLine();
            }
            while (quit != "q");
            if (quit == "q")
            {
                Console.Clear();
                MainMenu();
            }

        }

        static void MainMenu()
        {
            Console.Clear();
            string chosenOption;
            Console.WriteLine("Witam w programie!");
            Console.WriteLine("Nacisnij dany klawisz aby wybrac jedna z opcji, po czym wcisnij ENTER:");
            Console.WriteLine("1: Dodaj pracownika");
            Console.WriteLine("2: Wyswietl wszystkich pracownikow");
            Console.WriteLine("3: Znajdz pracownika");
            Console.WriteLine("4: Wyjscie z programu");
            chosenOption = Console.ReadLine();
            switch (chosenOption)
            {
                case "1":
                    AddPerson();
                    break;
                case "2":
                    GetPerson();
                    break;
                case "3":
                    FindPerson();
                    break;
                case "4":
                    Environment.Exit(1);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Podales niewlasciwą liczbe!");
                    Thread.Sleep(2000);
                    MainMenu();
                    break;

            }
        }

        static void AddPerson()
        {
            Console.Clear();
            string quit;
            Person person = new Person();
            Console.WriteLine("Podaj imie:");
            person.name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            person.surname = Console.ReadLine();
            Console.WriteLine("Podaj numer PESEL: (11 znakow)");
            person.pesel = Console.ReadLine();
            while (person.pesel.Length != 11)
            {
                Console.WriteLine("numer PESEL nieprawidlowy! Podaj jeszcze raz:");
                Console.WriteLine("Gdy nie posiadasz numeru PESEL wcisnij klawisz 'q' po czym nacisnij ENETER:");
                person.pesel = Console.ReadLine();
                if (person.pesel == "q")
                {
                    person.pesel = "";
                    break;
                }
            }
            void EmploymentType()
            {
                string employment;
                Console.WriteLine("Podaj typ zatrudnienia:");
                Console.WriteLine("1: Pelny Etat, 2: Pol Etatu, 3: Bezrobotny:");
                employment = Console.ReadLine();
                switch (employment)
                {
                    case "1":
                        person.employmentType = "Pelny etat";
                        Console.WriteLine("Pracujesz na pelny etat!");
                        break;
                    case "2":
                        person.employmentType = "Pol etatu";
                        Console.WriteLine("Pracujesz na pol etatu!");
                        break;
                    case "3":
                        person.employmentType = "Bezrobotny";
                        Console.WriteLine("Jesteś bezrobotny!");
                        break;
                    default:
                        Console.WriteLine("Podales niewlasciwą liczbe! ");
                        employment = null;
                        EmploymentType();
                        break;

                }
            }
            EmploymentType();
            Console.WriteLine("Podaj wartosc pensji brutto:");
            person.brutto = float.Parse(Console.ReadLine());
            person.netto = person.brutto - (person.brutto * 17 / 100) - (person.brutto * 10 / 100) - (person.brutto * 1.5F / 100);
            person.tax = person.brutto - person.netto;
            person.pensionContribution = (person.brutto * 10 / 100);
            person.disabilityPensionContribution = (person.brutto * 1.5F / 100);

            person.bruttoString = person.brutto.ToString();
            person.nettoString = person.netto.ToString();
            person.taxString = person.tax.ToString();
            person.pensionContributionString = person.pensionContribution.ToString();
            person.disabilityPensionContributionString = person.disabilityPensionContribution.ToString();

            Data data = new Data();
            data.SavePerson(person);
            Console.Clear();
            Console.WriteLine("Dodawanie zakońcczone sukcesem!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Dodany pracownik:");
            Console.WriteLine($"Imie: {person.name}, Nazwisko: {person.surname}, Pesel: {person.pesel}, Typ zatrudnienia: {person.employmentType}, Pensja brutto: {person.bruttoString},");
            Console.WriteLine($"Pensja netto: {person.nettoString}, Podatek dochodowy: {person.taxString}, Skladka emerytalna: {person.pensionContributionString}, Skladka rentowa: {person.disabilityPensionContributionString}");
            Console.WriteLine("");
            do
            {
                Console.WriteLine("Aby wrocic do menu nacisnij klawisz 'q' po czym wcisnij ENTER");
                quit = Console.ReadLine();
            }
            while (quit != "q");
            if (quit == "q")
            {
                Console.Clear();
                MainMenu();
            }
        }
    }
}

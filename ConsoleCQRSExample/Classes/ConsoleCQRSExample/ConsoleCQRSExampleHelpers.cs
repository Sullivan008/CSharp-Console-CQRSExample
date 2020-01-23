

using ConsoleCQRSExample.Classes.CQRS.Commands.PersonCommands;
using ConsoleCQRSExample.Classes.CQRS.EventBrokers;
using ConsoleCQRSExample.Classes.CQRS.Events.PersonEvents;
using ConsoleCQRSExample.Classes.CQRS.Queries.PersonQueries;
using ConsoleCQRSExample.Models;
using System;
using System.Collections.Generic;

namespace ConsoleCQRSExample.Classes.ConsoleCQRSExample
{
    public class ConsoleCQRSExampleHelpers
    {
        /// <summary>
        ///     Az EventBrokerhez (Eseménykezelő osztályhoz) tartozó Person objektumban található
        ///     Age Attribútum értékét megváltoztatja, a paraméterben megadott értékre.
        /// </summary>
        /// <param name="eventBroker">A példányosított eseménykezelő osztály</param>
        /// <param name="newAgeValue">Az "Age" attribútum új értéke</param>
        public void ChangePersonAge(EventBroker eventBroker, int newAgeValue)
        {
            eventBroker.Command(new ChangeAgeCommand(newAgeValue));
        }

        /// <summary>
        ///     AzEventBrokerhez (Eseménykezelő osztályhoz) tartozó Person objektumban található
        ///     "Name" Attribútum értékét megváltoztatja, a paraméterben megadott értékre.
        /// </summary>
        /// <param name="eventBroker">A példányosított eseménykezelő osztály</param>
        /// <param name="newNameValue">A "Name" attribútum új értéke</param>
        public void ChangePersonName(EventBroker eventBroker, string newNameValue)
        {
            eventBroker.Command(new ChangeNameCommand(newNameValue));
        }

        /// <summary>
        ///     A paraméterben átadott Listában található objektumok-ban található egyéni eseménykezelő
        ///     objektumaiban található események naplózását írja ki a Console-ra, formázott módon.
        /// </summary>
        /// <param name="personList">
        ///     Az a lista, amely tartalmazza azokat az objektumokat, amelyeknek
        ///     a naplózását szeretnénk megjeleníteni a Console-on
        /// </param>
        public void GetAllEventsHistory(List<Person> personList)
        {
            int index = 0;

            Console.WriteLine("\t\t\t\tAz objektumok Historijának lekérdezése: \n\n");

            foreach (Person person in personList)
            {
                Console.WriteLine($"{index + 1}. Person objektum esemény változásai: ");

                foreach (var personHistoryItem in person.EventBroker.AllEvents)
                {
                    Console.WriteLine($"\t\t{personHistoryItem}");
                }

                Console.WriteLine("\n");

                index++;
            }
        }

        /// <summary>
        ///     A Personokat tartalmazó Listát feltöltjük új Person objektumokkal.
        /// </summary>
        /// <returns>Egy olyan Lista amely példányosított Person objektumokat tartalmaz</returns>
        public List<Person> FillPersonListWithNewPersons()
        {
            const int N = 3;

            List<Person> personList = new List<Person>();

            for (int i = 0; i < N; i++)
            {
                personList.Add(new Person(new EventBroker()));
            }

            return personList;
        }

        /// <summary>
        ///     A paraméterben megadott Person objektum Age property értékének a módosítgatását 
        ///     hajtja végre, majd a műveletek eredményeit meg is jeleníti a felhasználónak.
        /// </summary>
        /// <param name="targetPerson">A módosítandó TargetObject</param>
        public void ChangeOfAPersonsAge(Person targetPerson)
        {
            Console.WriteLine("\t\t\tA 3. \"Person\" objektum \"Age\" Attribútumának \"Change\" tesztje: \n\n");

            Console.WriteLine("+++++ A 3. \"Person\" objektum aktuális életkorának az értéke: " +
                $"{targetPerson.EventBroker.Query<int>(new AgeQuery())}\n");

            Console.WriteLine("----- A 3. \"Person\" objektum aktuális életkorának az értékének 1 korábbi állapotával való visszaállás...\n");

            targetPerson.EventBroker.UndoLast(new AgeChangedEvent());

            Console.WriteLine("+++++ A 3. \"Person\" objektum aktuális életkorának az értéke: " +
                $"{targetPerson.EventBroker.Query<int>(new AgeQuery())}\n");

            Console.WriteLine("----- A 3. \"Person\" objektum aktuális életkorának új érték adása...\n");

            ChangePersonAge(targetPerson.EventBroker, 500);

            Console.WriteLine("+++++ A 3. \"Person\" objektum aktuális életkorának az értéke: " +
                $"{targetPerson.EventBroker.Query<int>(new AgeQuery())}\n");

            Console.WriteLine("\n\n");
        }

        /// <summary>
        ///     A paraméterben megadott Person objektum Name Property értékének a módosítgatását
        ///     hajtja végre, majd a műveletek eredményeit meg is jeleníti a felhasználónak.
        /// </summary>
        /// <param name="targetPerson">A módosítandó TargetObject</param>
        public void ChangeOfAPersonName(Person targetPerson)
        {
            Console.WriteLine("\t\t\tA 3. \"Person\" objektum \"Name\" Attribútumának \"Change\" tesztje: \n\n");

            Console.WriteLine("+++++ A 3. \"Person\" objektum aktuális nevének az értéke: " +
                $"{targetPerson.EventBroker.Query<string>(new NameQuery())}\n");

            Console.WriteLine("----- A 3. \"Person\" objektum aktuális nevének az értékének 1 korábbi állapotával való visszaállás...\n");

            targetPerson.EventBroker.UndoLast(new NameChangedEvent());

            Console.WriteLine("+++++ A 3. \"Person\" objektum aktuális nevének az értéke: " +
                $"{targetPerson.EventBroker.Query<string>(new NameQuery())}\n");

            Console.WriteLine("----- A 3. \"Person\" objektum aktuális nevének új érték adása...\n");

            ChangePersonName(targetPerson.EventBroker, "Teszt_Person_3_Change_Test");

            Console.WriteLine("+++++ A 3. \"Person\" objektum aktuális nevének az értéke: " +
                $"{targetPerson.EventBroker.Query<string>(new NameQuery())}\n");

            Console.WriteLine("\n\n");
        }
    }
}
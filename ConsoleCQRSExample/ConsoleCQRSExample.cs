using ConsoleCQRSExample.Classes.ConsoleCQRSExample;
using ConsoleCQRSExample.Models;
using System;
using System.Collections.Generic;

namespace ConsoleCQRSExample
{
    class ConsoleCQRSExample
    {
        private static ConsoleCQRSExampleHelpers _consoleCqrsExampleHelpers;

        static void Main(string[] args)
        {
            _consoleCqrsExampleHelpers = new ConsoleCQRSExampleHelpers();

            List<Person> personList = _consoleCqrsExampleHelpers.FillPersonListWithNewPersons();

            _consoleCqrsExampleHelpers.ChangePersonAge(personList[0].EventBroker, 23);
            _consoleCqrsExampleHelpers.ChangePersonName(personList[0].EventBroker, "Teszt_Person_1");
            _consoleCqrsExampleHelpers.ChangePersonAge(personList[1].EventBroker, 30);
            _consoleCqrsExampleHelpers.ChangePersonName(personList[1].EventBroker, "Teszt_Person_2");
            _consoleCqrsExampleHelpers.ChangePersonAge(personList[2].EventBroker, 400);
            _consoleCqrsExampleHelpers.ChangePersonName(personList[2].EventBroker, "Teszt_Person_3");
            _consoleCqrsExampleHelpers.ChangePersonAge(personList[0].EventBroker, 50);
            _consoleCqrsExampleHelpers.ChangePersonName(personList[0].EventBroker, "Teszt_Person_1[UPDATE]");
            _consoleCqrsExampleHelpers.ChangePersonAge(personList[1].EventBroker, 80);
            _consoleCqrsExampleHelpers.ChangePersonName(personList[1].EventBroker, "Teszt_Person_2[UPDATE]");

            _consoleCqrsExampleHelpers.GetAllEventsHistory(personList);

            _consoleCqrsExampleHelpers.ChangeOfAPersonsAge(personList[2]);

            _consoleCqrsExampleHelpers.ChangeOfAPersonName(personList[2]);

            _consoleCqrsExampleHelpers.GetAllEventsHistory(personList);

            Console.ReadKey();
        }
    }
}

using ConsoleCQRSExample.Classes.CQRS.Commands.PersonCommands;
using ConsoleCQRSExample.Classes.CQRS.EventBrokers;
using ConsoleCQRSExample.Classes.CQRS.Queries.PersonQueries;
using ConsoleCQRSExample.Classes.SwitchingOnTypes;
using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Models
{
    public class Person
    {
        private readonly PersonCommandMethods _personCommandMethods;
        private readonly PersonQueriesMethods _personQueriesMethods;

        private int _age;
        private string _name;

        public EventBroker EventBroker { get; }

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="eventBroker">A korábban példányosított eseménykezelő objektum referenciája</param>
        public Person(EventBroker eventBroker)
        {
            EventBroker = eventBroker;

            _personCommandMethods = new PersonCommandMethods();
            _personQueriesMethods = new PersonQueriesMethods();

            EventBroker.Commands += CommandsExecuteEvent;
            EventBroker.Queries += QueriesExecuteEvent;
        }

        /// <summary>
        ///     Metódus, amely a paraméterben végrehajtott "Parancsot" végrehajtja
        /// </summary>
        /// <param name="sender">A hívást kezdeményező objektum</param>
        /// <param name="command">A végrehajtandó parancs</param>
        private void CommandsExecuteEvent(object sender, Command command)
        {
            TypeSwitch.Do(command,
                TypeSwitch.Case<ChangeAgeCommand>(() => _personCommandMethods.ChangeAge(ref _age, command, this)),
                          TypeSwitch.Case<ChangeNameCommand>(() => _personCommandMethods.ChangeName(ref _name, command, this)));
        }

        private void QueriesExecuteEvent(object sender, Query query)
        {
            TypeSwitch.Do(query,
                TypeSwitch.Case<AgeQuery>(() => _personQueriesMethods.GetAge(query, ref _age)),
                          TypeSwitch.Case<NameQuery>(() => _personQueriesMethods.GetName(query, ref _name)));
        }
    }
}

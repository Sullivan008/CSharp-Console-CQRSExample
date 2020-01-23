using ConsoleCQRSExample.Classes.CQRS.Events.PersonEvents;
using ConsoleCQRSExample.Models;
using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Classes.CQRS.Commands.PersonCommands
{
    public class PersonCommandMethods
    {
        /// <summary>
        ///     Megváltoztatja a TargetObject-hez tartozó Age Property értékét
        ///     a paraméterben átadott új értékre.
        /// </summary>
        /// <param name="age">A Property, amely tartalmazza a "TargetObject"-hez tartozó "Age" property értékét</param>
        /// <param name="command">A végrehajtandó parancs objektum</param>
        /// <param name="targetObject">A cél objektum, amely tartalmazza azt a Property-t amelyet meg kell változtatni</param>
        public void ChangeAge(ref int age, Command command, Person targetObject)
        {
            if (command is ChangeAgeCommand changeAgeCommand)
            {
                targetObject.EventBroker.AllEvents.Add(new AgeChangedEvent(age, changeAgeCommand.Age));

                age = changeAgeCommand.Age;
            }
        }

        /// <summary>
        ///     Megváltoztatja a "TargetObject"-hez tartozó "Name" Property értékét
        ///     a paraméterben átadott új értékre.
        /// </summary>
        /// <param name="name">A Property, amely tartalmazza a "TargetObject"-hez tartozó "Name" Property értékét</param>
        /// <param name="command">A végrehajtandó parancs objektum</param>
        /// <param name="targetObject">A cél objektum, amely tartalmazza azt a Property-t amelyet meg kell változtatni</param>
        public void ChangeName(ref string name, Command command, Person targetObject)
        {
            if (command is ChangeNameCommand changeNameCommand)
            {
                targetObject.EventBroker.AllEvents.Add(new NameChangedEvent(name, changeNameCommand.Name));

                name = changeNameCommand.Name;
            }
        }
    }
}

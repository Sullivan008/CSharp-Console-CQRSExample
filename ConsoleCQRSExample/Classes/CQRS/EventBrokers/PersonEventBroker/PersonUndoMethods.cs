using ConsoleCQRSExample.Classes.CQRS.Commands.PersonCommands;
using ConsoleCQRSExample.Classes.CQRS.Events.PersonEvents;
using ConsoleCQRSExample.Models.CQRSModels;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCQRSExample.Classes.CQRS.EventBrokers.PersonEventBroker
{
    public class PersonUndoMethods
    {
        /// <summary>
        ///     A "TargetObject"-tben található "Age" Property értékét visszaállítja az előző állapotra.
        /// </summary>
        /// <param name="ageChangedEventList">
        ///     Tartalmazza azoknak az eseményeknek a listáját, amely az "Age" Property-n végrehajtódtak
        /// </param>
        /// <param name="allEvents">
        ///     Az adott "TargetObject" amely meghívja ezt a metódust-t, az ahhoz az objektumhoz tartozó végrehajtott események listája.
        /// </param>
        /// <param name="targetEventBroker">
        ///     Annak a "TargetObject"-nek az eseménykezelő objektuma, amely kiváltotta az "Undo" Parancsot.
        /// </param>
        public void UndoLastAgeChanged(List<object> ageChangedEventList, IList<Event> allEvents, EventBroker targetEventBroker)
        {
            if (ageChangedEventList.LastOrDefault(x => x.GetType() == typeof(AgeChangedEvent)) is AgeChangedEvent ageChangedEvent)
            {
                targetEventBroker.Command(new ChangeAgeCommand(ageChangedEvent.OldValue));

                allEvents.Remove(ageChangedEvent);
            }
        }

        /// <summary>
        ///     A TargetObject-tben található Name Property értékét visszaállítja az előző állapotra.
        /// </summary>
        /// <param name="nameChangedEventList">
        ///     Tartalmazza azoknak az eseményeknek a listáját, amely az Name Property-n végrehajtódtak
        /// </param>
        /// <param name="allEvents">
        ///     Az adott TargetObject amely meghívja ezt a metódust-t, az ahhoz az objektumhoz tartozó végrehajtott események listája.
        /// </param>
        /// <param name="targetEventBroker">
        ///     Annak a TargetObject-nek az eseménykezelő objektuma, amely kiváltotta az Undo Parancsot.
        /// </param>
        public void UndoLastNameChanged(List<object> nameChangedEventList, IList<Event> allEvents, EventBroker targetEventBroker)
        {
            if (nameChangedEventList.LastOrDefault(x => x.GetType() == typeof(NameChangedEvent)) is NameChangedEvent
                nameChangedEvent)
            {
                targetEventBroker.Command(new ChangeNameCommand(nameChangedEvent.OldValue));

                allEvents.Remove(nameChangedEvent);
            }
        }
    }
}

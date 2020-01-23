using ConsoleCQRSExample.Classes.CQRS.EventBrokers.PersonEventBroker;
using ConsoleCQRSExample.Classes.CQRS.Events.PersonEvents;
using ConsoleCQRSExample.Classes.SwitchingOnTypes;
using ConsoleCQRSExample.Models.CQRSModels;
using System;
using System.Collections.Generic;

namespace ConsoleCQRSExample.Classes.CQRS.EventBrokers
{
    public class EventBroker
    {
        private readonly PersonEventBrokerHelpers _personEventBrokerHelpers;
        private readonly PersonUndoMethods _personUndoMethods;

        #region Definition Event Handlers

        public IList<Event> AllEvents = new List<Event>();

        public event EventHandler<Command> Commands;

        public event EventHandler<Query> Queries;

        #endregion

        public EventBroker()
        {
            _personEventBrokerHelpers = new PersonEventBrokerHelpers();
            _personUndoMethods = new PersonUndoMethods();
        }

        #region Commands and Queries Methods

        /// <summary>
        ///     Metódus, amely végrehajtja a paraméterben átadott parancsot, az adott
        ///     eseményközvetítő osztályban.
        /// </summary>
        /// <param name="command">A végrehajtandó Command (Parancs) objektum</param>
        public void Command(Command command)
        {
            Commands?.Invoke(this, command);
        }

        /// <summary>
        ///     Függvény, amely végrehajtja a paraméterben átadott lekérdezést, az
        ///     adott eseményközvetítő osztályban.
        /// </summary>
        /// <typeparam name="T">Generikus típus. Tetszőleges típusú lekérdezés hajtható végre a függvényen.</typeparam>
        /// <param name="query">A végrehajtandó Query (Lekérdezés) objektum</param>
        /// <returns>Az adott típusú lekérdezésnek megfelelő "T" típusú lekérdezés eredményhalmaza.</returns>
        public T Query<T>(Query query)
        {
            Queries?.Invoke(this, query);

            return (T)query.Result;
        }

        /// <summary>
        ///     Az adott "Target Object"-en végrehajt egy állapot visszaállítást. Tehát az objektum
        ///     új értéke, az előzőleg megadott érték lesz. 
        ///     (Például: CurrentValue = 20; OldValue = 15; -> Undo -> CurrentValue = 15; OldValue = )
        /// </summary>
        /// <param name="eventType">
        ///     Az az esemény típus amely meghatározza, hogy a TargetObject-en milyen típusú végrehajtott
        ///     eseményeket kell kiválasztani, majd meghatározza, hogy melyik esemény "Parancsot" kell 
        ///     visszavonni.
        /// </param>
        public void UndoLast(object eventType)
        {
            List<object> currentEventTypeList = _personEventBrokerHelpers.FillCurrentEventTypeList(eventType.GetType(), this.AllEvents);

            TypeSwitch.Do(eventType,
                TypeSwitch.Case<AgeChangedEvent>(() => _personUndoMethods.UndoLastAgeChanged(currentEventTypeList, AllEvents, this)),
                          TypeSwitch.Case<NameChangedEvent>(() => _personUndoMethods.UndoLastNameChanged(currentEventTypeList, AllEvents, this)));
        }

        #endregion
    }
}

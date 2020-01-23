using ConsoleCQRSExample.Models.CQRSModels;
using System;
using System.Collections.Generic;

namespace ConsoleCQRSExample.Classes.CQRS.EventBrokers.PersonEventBroker
{
    public class PersonEventBrokerHelpers
    {
        /// <summary>
        ///     A paraméterben átadott esemény típusnak megfelelően kivállogatja annaka TargetObject-nek az 
        ///     eseményei közül azokat az eseményeket, amely TargetObject meghívta ezt az eseményt. 
        /// </summary>
        /// <param name="eventType">
        ///     Az az esemény típus amely meghatározza, hogy a TargetObject-en milyen típusú végrehajtott
        ///     eseményeket kell kiválasztani, majd meghatározza, hogy melyik esemény "Parancsot" kell
        ///     visszavonni.
        /// </param>
        /// <param name="allEvents">
        ///     Az adott "TargetObject" amely meghívja ezt a metódust-t, az ahhoz az objektumhoz tartozó végrehajtott események listája.
        /// </param>
        /// <returns>Az esemény típusnak megfelelően összegyűjtött a "TargetObject"-hez tartozó események listája</returns>
        public List<object> FillCurrentEventTypeList(Type eventType, IList<Event> allEvents)
        {
            List<object> currentEventTypeList = new List<object>();

            foreach (Event item in allEvents)
            {
                if (item.GetType() == eventType)
                {
                    currentEventTypeList.Add(item);
                }
            }

            return currentEventTypeList;
        }
    }
}


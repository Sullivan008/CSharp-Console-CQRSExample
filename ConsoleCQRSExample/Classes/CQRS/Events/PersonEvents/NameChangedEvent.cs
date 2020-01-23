using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Classes.CQRS.Events.PersonEvents
{
    public class NameChangedEvent : Event
    {
        private readonly string _newValue;

        public string OldValue { get; }

        public NameChangedEvent()
        { }

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="oldValue">Az objektumhoz tartozó paraméterben megkapott attribútum régi értéke</param>
        /// <param name="newValue">Az objektumhoz tartozó paraméterben megkapot attribútum új értéke</param>
        public NameChangedEvent(string oldValue, string newValue)
        {
            _newValue = newValue;
            OldValue = oldValue;
        }

        /// <summary>
        ///     Az osztály ToString metódusa Felüldefiniálva (Override).
        ///     Ha az objektum kiíratásra kerül (pl.: Consolra) akkor a függvényben
        ///     deffiniált érték kerül kiíratásra.
        /// </summary>
        /// <returns>Kiírja a Person objektumhoz tartozó "Name" attribútumának régi és aktuális értékét</returns>
        public override string ToString()
        {
            return $"A személy régi neve {OldValue}. Az új neve: {_newValue}";
        }
    }
}

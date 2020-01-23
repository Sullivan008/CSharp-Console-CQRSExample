using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Classes.CQRS.Events.PersonEvents
{
    public class AgeChangedEvent : Event
    {
        private readonly int _newValue;

        public int OldValue { get; }

        public AgeChangedEvent()
        { }

        /// <summary>
        ///     Konstruktor.
        /// </summary>
        /// <param name="oldValue">Az objektumhoz tartozó paraméterben megkapott attribútum régi értéke</param>
        /// <param name="newValue">Az objektumhoz tartozó paraméterben megkapott attribútum új értéke</param>
        public AgeChangedEvent(int oldValue, int newValue)
        {
            _newValue = newValue;
            OldValue = oldValue;
        }

        /// <summary>
        ///     Az osztály ToString metódusa Felüldefiniálva (Override)
        ///     Ha az objektum kiíratásra kerül (pl.: Consolra) akkor a függvényben
        ///     deffinált érték kerül kiíratásra.
        /// </summary>
        /// <returns>Kiírja a Person objektumhoz tartozó "Age" attribútumának régi és aktuális értékét</returns>
        public override string ToString()
        {
            return $"A személy régi életkora {OldValue}. Az új életkora: {_newValue}";
        }
    }
}

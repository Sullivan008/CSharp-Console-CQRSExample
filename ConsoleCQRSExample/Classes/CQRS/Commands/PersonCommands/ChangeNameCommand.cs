using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Classes.CQRS.Commands.PersonCommands
{
    /// <summary>
    ///     Osztály, amely definiál egy olyan parancsot, amely a cél objektum
    ///     egy adott attribútum értékét megváltoztatja (Jelen esetben a Person object, Name attribútumát)
    /// </summary>
    public class ChangeNameCommand : Command
    {
        public string Name { get; }

        /// <summary>
        ///     Konstruktor.
        ///     
        ///     Beállítja az osztályváltozók értékeit, a paraméterben átadott
        ///     értékekre.
        /// </summary>
        /// <param name="name">A módosítandó attribútum új értéke</param>
        public ChangeNameCommand(string name)
        {
            Name = name;
        }
    }
}

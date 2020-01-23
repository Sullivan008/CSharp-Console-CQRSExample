using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Classes.CQRS.Commands.PersonCommands
{
    public class ChangeAgeCommand : Command
    {
        public int Age { get; }

        /// <summary>
        ///     Konstruktor.
        ///     
        ///     Beállítja az osztályváltozók értékeit, a paraméterben átadott
        ///     értékekre.
        /// </summary>
        /// <param name="age">A módosítandó attribútum új értéke</param>
        public ChangeAgeCommand(int age)
        {
            Age = age;
        }
    }
}

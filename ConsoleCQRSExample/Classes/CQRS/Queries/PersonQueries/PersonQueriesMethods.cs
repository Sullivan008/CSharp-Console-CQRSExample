using ConsoleCQRSExample.Models.CQRSModels;

namespace ConsoleCQRSExample.Classes.CQRS.Queries.PersonQueries
{
    public class PersonQueriesMethods
    {
        /// <summary>
        ///     Végrehajt egy lekérdezést annak a TargetObject-nek az Age attribútumának
        ///     jelenlegi értékére, amely TargetObject kiváltotta a lekérdezést.
        /// </summary>
        /// <param name="query">A végrehajtandó Query (Lekérdezés) objektum</param>
        /// <param name="age">
        ///     A TargetObject-ben található "Age" attribútum értéke. 
        ///     Ez fog a Query Result Property-be bele kerülni.
        /// </param>
        public void GetAge(Query query, ref int age)
        {
            if (query is AgeQuery ageQuery)
            {
                ageQuery.Result = age;
            }
        }

        /// <summary>
        ///     Végrehajt egy lekérdezést annak a TargetObject-nek a Name attribútumának
        ///     jelenlegi értékére, amely TargetObject kiváltotta a lekérdezést.
        /// </summary>
        /// <param name="query">A végrehajtandó Query (Lekérdezés) objektum</param>
        /// <param name="name">
        ///     A TargetObject-ben található "Name" attribútum értéke.
        ///     Ez fog a Query Result Property-be bele kerülni.
        /// </param>
        public void GetName(Query query, ref string name)
        {
            if (query is NameQuery nameQuery)
            {
                nameQuery.Result = name;
            }
        }
    }
}

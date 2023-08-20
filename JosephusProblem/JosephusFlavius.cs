using System;
using System.Collections.Generic;

namespace JosephusProblem
{
    /// <summary>
    /// Providing functionality for the Josephus Flavius problem.
    /// <see>You can find more details on this problem in Wikipedia - https://en.wikipedia.org/wiki/Josephus_problem</see>.
    /// </summary>
    public static class JosephusFlavius
    {
        /// <summary>
        /// Returns the iterator that generates a list of persons that are crossed out.
        /// </summary>
        /// <returns>Returns the iterator that generates a list of persons that are crossed out.</returns>
        /// <exception cref="ArgumentException"><paramref>
        ///         <name>count</name>
        ///     </paramref>
        ///     is less than 1.</exception>
        /// <exception cref="ArgumentException"><paramref>
        ///         <name>crossedOut</name>
        ///     </paramref>
        ///     is less than 1.</exception>
        public static IEnumerable<int> GetCrossedOutPersons(int n, int k)
        {
            List<int> persons = new List<int>(n);
            for (int i = 1; i <= n; i++)
            {
                persons.Add(i);
            }

            int current = 0;
            while (persons.Count > 0)
            {
                current = (current + k - 1) % persons.Count;
                yield return persons[current];
                persons.RemoveAt(current);
            }
        }

        /// <summary>
        /// Returns order number of survivor.
        /// </summary>
        /// <returns>The order number of the last survivor.</returns>
        /// <exception cref="ArgumentException"><paramref>
        ///         <name>count</name>
        ///     </paramref>
        ///     is less than 1.</exception>
        /// <exception cref="ArgumentException"><paramref>
        ///         <name>crossedOut</name>
        ///     </paramref>
        ///     is less than 1.</exception>
        public static int GetSurvivor(int n, int k)
        {
            int survivor = 0;
            for (int i = 2; i <= n; i++)
            {
                survivor = (survivor + k) % i;
            }

            return survivor + 1;
        }
    }
}

using System;

#pragma warning disable CA1062

namespace LookingForArrayElementsRecursion
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            // #1. Implement the method using recursion.
            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            int count = 0;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                if (elementsToSearchFor[^1] == arrayToSearch[i])
                {
                    count++;
                }
            }

            return GetIntegersCount(arrayToSearch, elementsToSearchFor[..^1]) + count;
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            // #2. Implement the method using recursion.
            CheckExceptions(arrayToSearch, elementsToSearchFor, startIndex, count);

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            int cnt = 0;
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (elementsToSearchFor[^1] == arrayToSearch[i])
                {
                    cnt++;
                }
            }

            return GetIntegersCount(arrayToSearch, elementsToSearchFor[..^1], startIndex, count) + cnt;
        }

        private static void CheckExceptions(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater or equals arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }
        }
    }
}

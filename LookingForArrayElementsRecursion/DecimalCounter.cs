using System;

#pragma warning disable S2368
#pragma warning disable CA1062

namespace LookingForArrayElementsRecursion
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            // #5. Implement the method using recursion.
            CheckExceptions(arrayToSearch, ranges);

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int cnt = 0;
            for (int rangeIdx = 0; rangeIdx < ranges.Length; rangeIdx++)
            {
                if (ranges[rangeIdx].Length == 0)
                {
                    return cnt;
                }

                if (arrayToSearch[0] >= ranges[rangeIdx][0] && arrayToSearch[0] <= ranges[rangeIdx][1])
                {
                    cnt++;
                    break;
                }
            }

            return GetDecimalsCount(arrayToSearch[1..], ranges) + cnt;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            // #6. Implement the method using recursion.
            CheckExceptions(arrayToSearch, ranges, startIndex, count);

            return GetDecimalsCount(arrayToSearch[startIndex.. (startIndex + count)], ranges);
        }

        private static void CheckExceptions(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            foreach (decimal[] row in ranges)
            {
                if (row is null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
            }

            for (int x = 0; x < ranges.Length; x++)
            {
                if (ranges[x].Length > 0 && ranges[x].Length != 2)
                {
                    throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
                }
            }
        }

        private static void CheckExceptions(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            foreach (decimal[] row in ranges)
            {
                if (row is null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].Length > 0 && ranges[i].Length != 2)
                {
                    throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.");
                }
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"Method throws ArgumentOutOfRangeException in case start index is negative.");
            }

            if (startIndex >= arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException($"Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"Method throws ArgumentOutOfRangeException in case count is less than zero.");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException($"Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
            }
        }
    }
}

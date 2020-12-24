using System;

#pragma warning disable CA1062

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            // #3. Implement the method using recursion.
            CheckExceptions(arrayToSearch, rangeStart, rangeEnd);
            if (arrayToSearch.Length == 0 || rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            return GetCount(arrayToSearch, rangeStart, rangeEnd);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            // #4. Implement the method using recursion.
            CheckExceptions(arrayToSearch, rangeStart, rangeEnd, startIndex, count);
            if (arrayToSearch.Length == 0 || rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            return GetCount(arrayToSearch, rangeStart, rangeEnd, startIndex, count);
        }

        private static int GetCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            int cnt = 0;

            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                if (arrayToSearch[i] >= rangeStart[^1] && arrayToSearch[i] <= rangeEnd[^1])
                {
                    cnt++;
                }
            }

            if (rangeEnd.Length <= 1)
            {
                return cnt;
            }
            else
            {
                return GetCount(arrayToSearch, rangeStart[..^1], rangeEnd[..^1]) + cnt;
            }
        }

        private static int GetCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            int cnt = 0;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (arrayToSearch[i] >= rangeStart[^1] && arrayToSearch[i] <= rangeEnd[^1])
                {
                    cnt++;
                }
            }

            if (rangeEnd.Length <= 1)
            {
                return cnt;
            }
            else
            {
                return GetCount(arrayToSearch, rangeStart[..^1], rangeEnd[..^1], startIndex, count) + cnt;
            }
        }

        private static void CheckExceptions(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
            }

            for (int i = 0; i < rangeEnd.Length; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
                }
            }
        }

        private static void CheckExceptions(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
            }

            for (int i = 0; i < rangeEnd.Length; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
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

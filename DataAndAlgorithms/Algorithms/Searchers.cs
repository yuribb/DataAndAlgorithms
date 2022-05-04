using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndAlgorithms.Algorithms
{
    public static class Searchers
    {
        /// <summary>
        /// Linear search O(n)
        /// </summary>
        public static bool LinearSearch<T>(T[] arr, T searchFor, Comparer<T> comparer)
        {
            foreach (var item in arr)
            {
                if (comparer.Compare(item, searchFor) == 1)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Binary search O(log n)
        /// </summary>
        public static int BinarySearch<T>(T[] array, T searchFor, Comparer<T> comparer)
        {
            var high = array.Length - 1;
            var low = 0;
            if (array[0]!.Equals(searchFor))
            {
                return 0;
            }

            if (array[high]!.Equals(searchFor))
            {
                return high;
            }
            while (low <= high)
            {
                var mid = (high + low) / 2;
                switch (comparer.Compare(array[mid], searchFor))
                {
                    case 0:
                        return mid;
                    case > 0:
                        high = mid - 1;
                        break;
                    default:
                        low = mid + 1;
                        break;
                }
            }
            return -1;
        }


    }
}

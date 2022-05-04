namespace DataAndAlgorithms.Algorithms
{
    public static class Sorters
    {
        /// <summary>
        /// Its meaning is to go through the arr, from left to right,
        /// each time to look for the min item of the arr and exchange it with the first item
        /// of the unsorted part of the arr.
        /// </summary>
        /// <param name="arr">arr</param>
        /// <returns>sorted arr</returns>
        public static int[] SelectionSort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++) //iterate through the arr from beginning to end
            {
                var min = i; //var to store the index of the min element of the arr
                for (var j = i; j < arr.Length; j++) //looking for the min item in the unsorted part
                {
                    if (arr[j] < arr[min])
                    {
                        min = j; //found in the arr a number less than arr[min] - store its index in the arr
                    }
                }
                //if the min is equal to the current val - skip
                if (arr[min] == arr[i])
                {
                    continue;
                }
                //swap the min item and the first item in the unsorted part
                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
            return arr;
        }

        /// <summary>
        /// Complexity O(n^2)
        /// Each element of the arr is compared with the next one and if
        /// element[i] > element[i+1] the replacement takes place.
        ///
        /// Step 1 is repeated n-1 times, where n is the number of elements in the arr.
        /// </summary>
        /// <param name="arr">arr</param>
        /// <returns>sorted arr</returns>
        public static int[] BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Shaker sort is a sort like Bubble but
        /// the algorhitm moves into two sizes - from the top and from the bottom
        /// </summary>
        /// <param name="arr">arr</param>
        /// <returns>sorted arr</returns>
        public static int[] ShakerSort(int[] arr)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                for (var i = left; i < right; i++) //forward bubble
                {
                    if (arr[i] > arr[i + 1])
                    {
                        (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]); //swap
                    }
                }
                right--;
                for (var i = right; i > left; i--) //backward bubble
                {
                    if (arr[i - 1] > arr[i])
                    {
                        (arr[i], arr[i]) = (arr[i], arr[i - 1]); //swap
                    }
                }
                left++;
            }

            return arr;
        }

        /// <summary>
        /// The loop starts not from 0, but from the first element of the arr.
        /// Depending on how the two elements are compared, we either swap them and go one step back,
        /// or we don't change them and go one step forward.
        /// </summary>
        /// <param name="arr">arr</param>
        /// <returns>sorted arr</returns>
        public static int[] GnomeSort(int[] arr)
        {
            var i = 1;
            var j = 2;
            while (i < arr.Length)
            {
                if (arr[i - 1] < arr[i])
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    (arr[i - 1], arr[i]) = (arr[i], arr[i - 1]); //swap
                    i -= 1;
                    if (i != 0)
                    {
                        continue;
                    }
                    i = j;
                    j += 1;
                }
            }
            return arr;
        }

        /// <summary>
        /// The outer loop starts at the second element of the array.
        /// We remember the value of the second element of the array.
        /// In the inner loop, we compare each previous element of the array
        /// with the current one and, if necessary, swap them
        /// until we reach the beginning of the loop or until we meet an element less than the current one.
        /// </summary>
        /// <param name="arr">arr</param>
        /// <returns>sorted arr</returns>
        public static int[] InsertionSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var x = arr[i];
                var j = i;
                while (j > 0 && arr[j - 1] > x)
                {
                    (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]); //swap
                    j -= 1;
                }
                arr[j] = x;
            }
            return arr;
        }
    }
}

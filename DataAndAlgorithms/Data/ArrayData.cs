namespace DataAndAlgorithms.Data
{
    public static class ArrayData
    {
        public static void Show()
        {
            //All arrays in C# based on Array class
            //This class defines a number of props and methods that we can use
            
            var arr = new int[5];
            arr[0] = 1;
            arr[1] = 4;
            arr[2] = 3;
            arr[3] = 2;
            arr[4] = 5;
            Console.WriteLine($"Array: {arr.Write()}");

            var arrLength = arr.Length; //Lenght
            Console.WriteLine($"Length: {arrLength}"); //5

            var arrRank = arr.Rank; //Rank
            Console.WriteLine($"Rank: {arrRank}"); //1

            var arrCopy = new int[5]; //Copy
            arr.CopyTo(arrCopy, 0);

            var indOf = Array.IndexOf(arr, 3); //IndexOf
            Console.WriteLine($"Index of 3: {indOf}"); //2

            Array.Resize(ref arr, 7); //resize of array
            Console.WriteLine($"New arr size: {arr.Length}"); //7

            arr[5] = 7;
            arr[6] = 6;
            Console.WriteLine($"Resized arr: {arr.Write()}");

            Array.Sort(arr); //Sort items
            Console.WriteLine($"Sorted arr: {arr.Write()}");

            var lastIndOf = Array.LastIndexOf(arr, 7); //Last index
            Console.WriteLine($"Last index after sorting: {lastIndOf}"); //6

            Array.Reverse(arr); // reverse array
            Console.WriteLine($"Reversed art: {arr.Write()}");

            var min = arr.FindMin(); //Find mimimal item
            var max = arr.FindMax(); //Find maximum item
            Console.WriteLine($"Min: {min}, Max: {max}"); //1, 7

            var numOf = arr.NumOf(3); //Num of occurencies of 3
            Console.WriteLine($"Num of 3: {numOf}"); //1

            Console.WriteLine();
        }

        private static string Write(this int[] arr)
        {
            return string.Join(", ", arr);
        }

        /// <summary>
        /// Find minimal item in array
        /// </summary>
        /// <param name="arr">array</param>
        /// <returns>minimal item</returns>
        private static int FindMin(this int[] arr)
        {
            var min = arr[0];
            foreach (var item in arr)
            {
                if (item < min)
                    min = item;
            }
            return min;
        }

        /// <summary>
        /// Find max item in array
        /// </summary>
        /// <param name="arr">array</param>
        /// <returns>maximum item</returns>
        private static int FindMax(this int[] arr)
        {
            var max = arr[0];
            foreach (var item in arr)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }

        /// <summary>
        /// num of occurrences of an item in an array
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="ind">item</param>
        /// <returns>num</returns>
        private static int NumOf(this int[] arr, int ind)
        {
            var count = 0;

            foreach (var item in arr)
            {
                if (item == ind)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

namespace DataAndAlgorithms.Algorithms
{
    public static class Sorters
    {

        public static int[] SelectionSort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++) //iterate through the array from beginning to end
            {
                var min = i; //var to store the index of the min element of the arr
                for (var j = i; j < arr.Length; j++) //looking for the min item in the unsorted part
                {
                    if (arr[j] < arr[min])
                    {
                        min = j; //found in the array a number less than arr[min] - store its index in the array
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
    }
}

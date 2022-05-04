namespace DataAndAlgorithms.Data
{
    public static class HashSetData
    {
        public static void Show()
        {
            //HashSet is an unordered collection of unique elements.
            //It is generally used when we want to prevent duplicate elements
            //Order of the element is not defined. You cannot sort the elements of HashSet.
            //The elements must be unique.
            //Is provides many mathematical set operations, such as intersection, union, and difference.
            //The capacity of a HashSet is the number of elements it can hold.

            var hs = new HashSet<string>(5)
            {
                "Hello",
                "Dolly",
                "This",
                "Is",
                "Louis"
            };

            Console.WriteLine($"HashSet: {hs.Write()}");

            hs.Add("Yeah!"); //Add value
            Console.WriteLine($"Added val HashSet: {hs.Write()}");

            hs.Remove("Yeah!"); //Remove value
            Console.WriteLine($"Removed val HashSet: {hs.Write()}");

            Console.WriteLine();
        }

        public static string Write(this HashSet<string> hs)
        {
            return $"Total: {hs.Count}. {string.Join(", ", hs)}";
        }
    }
}

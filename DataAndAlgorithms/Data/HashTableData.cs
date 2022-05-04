using System.Collections;

namespace DataAndAlgorithms.Data
{
    public static class HashTableData
    {
        public static void Show()
        {
            //Hashtable is a collection of key/value pairs that
            //are arranged based on the hash code of the key
            //Hashtable is used to create a collection which uses a hash table for storage
            //It generally optimized the lookup by calculating
            //the hash code of every key and store into another basket automatically
            //When you accessing the value from the hashtable
            //at that time it matches the hashcode with the specified key.


            //Initialize
            var ht = new Hashtable
            {
                {"Hello", "HelloValue"},
                {"Word", "WordValue"},
                {"HashKey", "DataValue"}
            };
            Console.WriteLine($"HashTable: {ht.Write()}");

            //Add new key
            ht.Add("NewKey", "NewValue");
            Console.WriteLine($"Added val HashTable: {ht.Write()}");

            //Remove values
            ht.Remove("Hello");
            Console.WriteLine($"Removed val HashTable: {ht.Write()}");

            //Contains
            Console.WriteLine($"\"Word\" key exist?: {ht.ContainsKey("Word")}");
            Console.WriteLine($"\"LoL\" key exist?: {ht.ContainsKey("Lol")}");
            Console.WriteLine($"\"DataValue\" val exist?: {ht.ContainsValue("DataValue")}");
            Console.WriteLine($"\"OloloValue\" val exist?: {ht.ContainsValue("OloloValue")}");

            Console.WriteLine();
        }

        public static string Write(this Hashtable ht)
        {
            var arr = new string[ht.Count];
            var count = 0;
            foreach (DictionaryEntry item in ht)
            {
                arr[count] = $"{count+1}. {item.Key}: {item.Value}";
                count++;
            }
            return $"\"Total: {ht.Count}: {string.Join(", ", arr)}\"";
        }
    }
}

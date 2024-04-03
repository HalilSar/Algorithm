using static System.Console;
using System.Collections;

namespace Algorithm.Search.HashTableAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("key1", "value1");
            hashtable.Add("key2", "value2");
            hashtable.Add("key3", "value3");
            hashtable.Add("key4", "value4");

            string key = "key3";

            if (hashtable.ContainsKey(key)) WriteLine($"key.: {key}  value: {hashtable[key]}");

            else WriteLine("key not found.");

        }
    }
}

using System;
using static System.Console;
namespace Algorithm.Search.LinearProbingHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearProbing hashtable = new LinearProbing(10);

            hashtable.Put("1", "Ritchie Blackmore");
            hashtable.Put("2", "Eric Clapton");
            hashtable.Put("3", "Jeff Beck");
            hashtable.Put("4", "George Harrison");
            hashtable.Put("5", "J. Page");
            WriteLine("Hash Table: ");

            hashtable.Display();

            WriteLine("\nValue of key '3':" + hashtable.Get("1"));

        }
    }


    class LinearProbing
    {
        private string[] keys;
        private string[] values;
        private int capacity;
        private int size;

        public LinearProbing(int capacity)
        {
            this.capacity = capacity;
            this.keys = new string[capacity];
            this.values = new string[capacity];
            this.size = 0;
        }

        private int Hash(string key)
        {
            return key.Length % capacity;
        }

        public void Put(string key, string value)
        {
            if (size == capacity)
            {
                WriteLine("Hash table full");
                return;
            }

            int index = Hash(key);

            while (keys[index] != null)
            {
                index = (index + 1) % capacity;
            }

            keys[index] = key;
            values[index] = value;
            size++;

        }

        public string Get(string key)
        {
            int index = Hash(key);

            while (keys[index] != key)
            {
                if (keys[index] != key)
                    return values[index];
                index = (index + 1) % capacity;
            }
            return null;
        }

        public void Display()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (keys[i] != null)
                    WriteLine("Key: " + keys[i] + " , Value: " + values[i]);
            }
        }
    }
}

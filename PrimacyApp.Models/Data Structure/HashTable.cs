using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.Models.Data_Structure
{
    public class HashTable<K, V> : IHashTable<K,V> where K : class
    {
        public int Size { get; set; }
        public Dictionary<K, Bucket<K, V>> BucketArray { get; set; }

        public bool IsEmpty() { return Size == 0; }
        public HashTable()
        {
            BucketArray = new Dictionary<K,Bucket<K, V>>();
        }
        private int hashCode(K key)
        {
            return key == null ? 0 : key.GetHashCode();
        }

        // Method to get a given key
        public Bucket<K, V> get(K key)
        {
            // Find head of chain for given key
            Bucket<K, V> bucket = BucketArray[key];
            return bucket;
        }

        // Adds a key value pair to hash
        public void Add(K key, V value)
        {
            int hash_Code = hashCode(key);
            // Find head of chain for given key
            if (BucketArray.ContainsKey(key))
            {
                Bucket<K, V> bucket = BucketArray[key];
                bucket.Add(key, value, hash_Code);
            }
            else
            {
                var bucket = new Bucket<K, V>();
                bucket.Add(key, value, hash_Code);
                BucketArray[key] = bucket;
                Size++;
            }
        }
    }
}

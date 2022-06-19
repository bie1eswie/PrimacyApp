using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.Models.Data_Structure
{
    public interface IHashTable<K,V> where K : class
    {
        public Dictionary<K, Bucket<K, V>> BucketArray { get; set; }
        void Add(K key, V value);
    }
}

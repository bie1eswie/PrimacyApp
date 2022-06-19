using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.Models.Data_Structure
{
    public class Node<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        private readonly int hashCode;
        // Reference to next node
        public Node<K, V>? Next { get; set; }

        // Constructor
        public Node(K key, V value, int hashCode)
        {
            this.Key = key;
            this.Value = value;
            this.hashCode = hashCode;
        }
    }
}

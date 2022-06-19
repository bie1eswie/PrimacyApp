using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.Models.Data_Structure
{
    public class Bucket<K, V>
    {
        public Node<K, V>? Head { get; set; }
        public int Size { get; set; }
        public Bucket()
        {
        }

        public void Add(K key, V value, int hash)
        {
            Node<K, V> newNode = new Node<K, V>(key, value, hash);
            if(Head == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Size++;
        }
    }
}

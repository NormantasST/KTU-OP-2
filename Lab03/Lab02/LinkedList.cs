using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02
{
    /// <summary>
    /// Linked List Class Object
    /// </summary>
    /// <typeparam name="T">Object Type</typeparam>
    public class LinkedList<T> : IEnumerable<T> where T : IComparable<T>, IEquatable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private Node<T> d;

        /// <summary>
        /// Construcotr
        /// </summary>
        public LinkedList()
        {
            head = null;
            tail = null;
        }

        //Deprecated, Use Foreach with IEnumerable 
        /** Address of the head of the list is assigned */
        //public void Begin()
        //{ d = head; }
        /** Interface variable gets address of the next entry*/
        //public void Next()
        //{ d = d.next; }
        /** Return true, if list is empty*/
        //public bool Exist()
        //{ return d != null; }
        //-----------------------------------------------
        /** Return data according to the interface address*/
        //public T Get()
        //{ return d.Data; }

        /// <summary>
        /// Adds T object to  Linked List
        /// </summary>
        /// <param name="data"> <T> Type Object</param>
        public void Add(T data)
        {
            // If No citizen was found, adds the citizen to Linked List
            if (head == null)
            {
                head = new Node<T>(data, null);
                tail = head;
            }
            else
            {
                tail.next = new Node<T>(data, null);
                tail = tail.next;
            }
        }

        /// <summary>
        /// Sort Function using iComprable
        /// </summary>
        public void Sort()
        {

            Node<T> timer = head;
            while (timer != null)
            {
                Node<T> curr = head;
                Node<T> next = head.next;
                while (next != null)
                {
                    if (curr.Data.CompareTo(next.Data) > 0)
                    {
                        curr.SwapData(next);
                    }
                    curr = next;
                    next = next.next;
                }
                timer = timer.next;
            }
        }

        /// <summary>
        /// IEnumerable implementation
        /// </summary>
        /// <returns>yield of T data</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> dd = head; dd != null; dd = dd.next)
            {
                yield return dd.Data;
            }
        }

        /// <summary>
        /// Obligatory, since IEnumerable<T> inherits IEnumerable
        /// </summary>
        /// <returns>none</returns>
        /// <exception cref="NotImplementedException">Not Implemented</exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Node class to be used to save every citizen seperately 
        /// </summary>
        class Node<T>
        {
            public T Data { get; set; }
            public Node<T> next { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="data">CitizenData pointer</param>
            public Node(T data, Node<T> link)
            {
                Data = data;
                next = link;
            }

            /// <summary>
            /// Swaps the DATA, keeps the pointers
            /// </summary>
            /// <param name="other">Other node to be swapped with</param>
            public void SwapData(Node<T> other)
            {
                T temp = Data;
                Data = other.Data;
                other.Data = temp;
            }
        }
    }
}
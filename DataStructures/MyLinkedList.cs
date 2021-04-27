using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace DataStructures
{
    public class MyLinkedList<T> : ICollection<T>
    {
        public T Head
        {
            get { return head.Value; }
        }
        private Node<T> head { get; set; }
        private Node<T> tail { get; set; }
        public int Count
        {
            get;
            private set;
        }
        ///
        public  void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> newNode = new Node<T>(item);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            Count++;
        }
        /// <summary>
        /// Appends a Node to the tail of the linked list
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The size of the linked list </returns>
        public int AddLast(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> newNode = new Node<T>(item);
            //if the list is empty, point head and tail to the new node
            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            //if the list isn't empty, reference the new node from the current tail, point the tail to the new node. 
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            Count++;
            return Count;
        }
        /// <summary>
        /// Removes a node from the linked list
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if successful otherwise false</returns>
        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> previous = null;
            Node<T> current = this.head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //If we are on a node asides the first node
                    if (previous != null)
                    {
                        previous.Next =  current.Next;
                        //if the next node is null, set the previous node to be the tail.
                        if (current.Next == null)
                        {
                            this.tail = previous;
                        }
                    }
                    //we are on the first node, point the head to the second node
                    else 
                    {
                        this.head = this.head.Next;
                    }
                    this.Count--;
                    //if the linked list is empty, set tail to null.
                    if (Count == 0)
                    {
                        this.tail = null;
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        /// <summary>
        /// Checks if a node exists in the linked list
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if there is a node otherwise false</returns>
        public bool Check(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> current = this.head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        /// <summary>
        /// checks for the index of a node in the linked list
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The index of the node, or -1 if the node doesn't exist in the list</returns>
        public  int Index(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> current = this.head;
            int index = 0;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            index = -1;
            return index;
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool IsReadOnly => throw new NotImplementedException();
    }
}

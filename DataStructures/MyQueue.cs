using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private Node<T> First { get; set; }
        private Node<T> Last { get; set; }
        public int Count
        {
            get;
            private set;
        }
        /// <summary>
        /// Checks if the queue is empty
        /// </summary>
        /// <returns>returns true if empty or false otherwise.</returns>
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Adds an object to the end of the queue
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if successful or false otherwise</returns>
        public bool Enqueue(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> newNode = new Node<T>(item);
            //if the queue is empty
            if (this.First == null)
            {
                this.First = newNode;
                this.Last = this.First;
            }
            else
            {
                this.Last.Next = newNode;
                this.Last = newNode;
            }
            this.Count++;
            return true;
        }

        /// <summary>
        /// Removes and returns the element at the beginning of the Queue.
        /// </summary>
        /// <returns>The element that is removed at the beginning of the queue</returns>
        public T Dequeue()
        {
            //if the stack is empty
            if (this.First == null) throw new InvalidOperationException("Queue is empty");
            Node<T> temp = this.First;
            //if there is only one item in the stack
            if (this.First == this.Last)
            {
                this.Last = null;
            }
            this.First = temp.Next;
            this.Count--;
            return temp.Value;
        }
        /// <summary>
        /// Returns the number of objects in the Queue
        /// </summary>
        /// <returns>the number of objects in the Queue</returns>
        public int Size()
        {
            return this.Count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.First;
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
    }
}

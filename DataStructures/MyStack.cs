using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class MyStack<T> : IEnumerable<T>
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
        /// Inserts an object at the top of the stack
        /// </summary>
        /// <param name="item"></param>
        /// <returns>returns true if added successfully</returns>

        public bool Push(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Argument Value cannot be null");
            }
            Node<T> newNode = new Node<T>(item);
            if (this.First == null)
            {
                this.First = newNode;
                this.Last = this.First;
            }
            else
            {
                newNode.Next = this.First;
                this.First = newNode;            
            }
            this.Count++;
            return true;
        } 

        /// <summary>
        /// Removes and returns the object at the top of the stack
        /// </summary>
        /// <returns>The object removed</returns>
        public T Pop()
        {
            //if the stack is empty
            if (this.First == null) throw new InvalidOperationException("Stack is empty");
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
        /// Returns the object at the top of the stack without removing it;
        /// </summary>
        /// <returns>The object at the top of the stack </returns>
        public T Peek()
        {
            //if the stack is empty
            if (this.First == null) throw new InvalidOperationException("stack is empty");
            T value = this.First.Value;           
            return value;
        }
        /// <summary>
        /// Returns the number of objects in the Stack
        /// </summary>
        /// <returns>the number of objects in a Stack</returns>
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

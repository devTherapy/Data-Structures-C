using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyLinkedList<int>();
            var state =  list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);



            
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}


            var ans2 = list.Check(4);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(ans2);
            Console.WriteLine(state);
        }
    }
}

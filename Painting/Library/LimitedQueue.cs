using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Painting
{
    class LimitedQueue<T>
    {
        public int Count
        {
            get { return count; }
        }

        T[] objectArray;
        int count;
        int first;
        int last;
        int MAXSIZE;

        /// <summary>
        /// A queue for objects of any single type.
        /// </summary>
        /// <param name="size">Maximum size of queue</param>
        public LimitedQueue(int size)
        {
            MAXSIZE = size;
            objectArray = new T[size];
            count = 0;
            first = 0;
            last = 0; //points to the space after the last in the array   
        }

        public T Pop()
        {
            if (count > 0)
            {
                int temp = first;

                count--;
                first++;
                if (first == MAXSIZE)
                    first = 0;

                return objectArray[temp];
            }
            else
            {
                throw new InvalidOperationException("Nothing in Queue.");
            }
        }

        public void Push(T newobject)
        {
            if (count == MAXSIZE)
            {
                Pop(); //discard an old object
                //throw new InvalidOperationException("Queue Overflow.");
            }
            
            count++;
            objectArray[last] = newobject;

            last++;
            if (last == MAXSIZE)
                last = 0;
        }

        /// <summary>
        /// Lets you see an entry without being able to modify it.
        /// </summary>
        /// <param name="index">0 - most recently added to queue.</param>
        /// <returns></returns>
        public T Peek(int index)
        {
            if (index >= count)
                throw new IndexOutOfRangeException("InputQueue index >= number in queue.");

            return objectArray[(MAXSIZE + last - 1 - index) % MAXSIZE];
        }

        /// <summary>
        /// Clears the LimitedQueue.
        /// WARNING: Not a deep clean.
        /// </summary>
        public void Flush()
        {
            count = 0;
            first = 0;
            last = 0;
        }
    }
}

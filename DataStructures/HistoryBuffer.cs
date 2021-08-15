using System.Collections.Generic;

namespace ImageProcessing.DataStructures
{
    /// <summary>
    /// History buffer - a queue that will store the last 5 (or MaxCapacity)
    /// data types (like bitmaps of past images)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class HistoryBuffer<T> : Queue<T>
    {
        public int MaxCapacity { get; internal set; }

        //default max capacity size is 5
        public HistoryBuffer(int maxCapacity = 5)
        {
            MaxCapacity = maxCapacity;
        }

        /// <summary>
        /// Add a new item to the HistoryBuffer. If the current Count == the 
        /// MaxCapacity, then dequeue the oldest item (ie first item added)
        /// </summary>
        /// <param name="newElement"></param>
        public void Add(T newElement)
        {
            if (Count == MaxCapacity)
            {
                Dequeue();
            }
            Enqueue(newElement);
        }
    }
}

using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class MyQueueData
    {
        public static void Show()
        {
            var q = new MyQueue<string>();
            q.Enqueue("Daniel");
            q.Enqueue("Émilien");
            q.Enqueue("Lilly");
            q.Enqueue("Petra");

            Console.WriteLine($"MyQueue: {q}");

            var item = q.Dequeue();
            Console.WriteLine($"Dequeued: {q}. Item: {item}");

            item = q.First();
            Console.WriteLine($"First: {item}");

            item = q.Last();
            Console.WriteLine($"Last: {item}");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Queue is a data structure which works by using FIFO (First In First Out) principle.
    /// When adding a new element, it is placed at the end of the queue or its tail
    /// And the removal goes from the beginning of the queue or the head of the queue.
    ///
    /// The complexity of the algorithms for adding and removing from the queue is O(1).
    /// </summary>
    /// <typeparam name="T">Queue Data type</typeparam>
    public class MyQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Head/First item
        /// </summary>
        public MyNode<T> Head { get; private set; } = null!;

        /// <summary>
        /// Last/Tail item
        /// </summary>
        public MyNode<T> Tail { get; private set; } = null!;

        /// <summary>
        /// Total count of items in linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If linked list is empty
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add item into queue
        /// To add to the queue, we need to reset the reference to the last element of Tail
        /// </summary>
        /// <param name="item">item</param>
        public void Enqueue(T item)
        {
            var node = new MyNode<T>(item);
            var tempNode = Tail;
            Tail = node;
            if (Count == 0)
            {
                Head = Tail;
            }
            else
            {
                tempNode.Next = Tail;
            }
            Count++;
        }

        /// <summary>
        /// Execute item from queue
        /// When deleting, you need to reinstall the reference to the first element.
        /// Since the first element is removed, the next element becomes the new first element.
        /// </summary>
        /// <returns>item</returns>
        /// <exception cref="InvalidOperationException">If queue is empty</exception>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var output = Head.Data;
            Head = Head.Next;
            Count--;
            return output;
        }
        
        /// <summary>
        /// Get first item
        /// </summary>
        public T First
        {
            get
            {
                if (IsEmpty) //If queue is empty
                {
                    throw new InvalidOperationException();
                }
                return Head.Data;
            }
        }
        
        /// <summary>
        /// Get last item
        /// </summary>
        public T Last
        {
            get
            {
                if (IsEmpty) //If queue is empty
                {
                    throw new InvalidOperationException();
                }
                return Tail.Data;
            }
        }

        /// <summary>
        /// Clear queue
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Is queue contains item?
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>Is contains?</returns>
        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return $"Total: {this.Count}. {string.Join(", ", this)}";
        }
    }
}

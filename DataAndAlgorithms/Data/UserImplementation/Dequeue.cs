using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class DequeueData
    {
        public static void Show()
        {
            var dq = new Dequeue<string>();
            dq.AddFirst("Otto");
            dq.AddLast("Reggie");
            dq.AddFirst("Twister");
            dq.AddLast("Squid");

            Console.WriteLine($"Dequeue: {dq}");

            var item = dq.First();
            Console.WriteLine($"First: {dq}. Item: {item}");

            item = dq.Last();
            Console.WriteLine($"Last: {item}");

            item = dq.RemoveFirst();
            Console.WriteLine($"Removed First: {item}");

            item = dq.RemoveLast();
            Console.WriteLine($"Removed Last: {item}");

            Console.WriteLine($"Dequeue after removing: {dq}");

            Console.WriteLine($"Reggie exist?: {dq.Contains("Reggie")}");
            Console.WriteLine($"Lars exist?: {dq.Contains("Lars")}");

            Console.WriteLine();
        }
    }

    public class Dequeue<T> : IEnumerable<T>  // двусвязный список
    {
        /// <summary>
        /// Head/First item
        /// </summary>
        public DoublyNode<T> Head { get; private set; } = null!;

        /// <summary>S
        /// Last/Tail item
        /// </summary>
        public DoublyNode<T> Tail { get; private set; } = null!;

        /// <summary>
        /// Total Count of items in linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If linked list is empty
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add item to the tail
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            var node = new DoublyNode<T>(item);

            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }
        /// <summary>
        /// Add item to the head
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            var node = new DoublyNode<T>(item);
            var temp = Head;
            node.Next = temp;
            Head = node;
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = node;
            }
            Count++;
        }

        /// <summary>
        /// Execute item from Head
        /// </summary>
        /// <returns>Item</returns>
        /// <exception cref="InvalidOperationException">If dequeue is empty</exception>
        public T RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("Dequeue is empty");
            var output = Head.Data;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            Count--;
            return output;
        }

        /// <summary>
        /// Execute item from Tail
        /// </summary>
        /// <returns>Item</returns>
        /// <exception cref="InvalidOperationException">If dequeue is empty</exception>
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Dequeue is empty");
            }
            var output = Tail.Data;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            Count--;
            return output;
        }

        /// <summary>
        /// Head item
        /// </summary>
        public T First
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Dequeue is empty");
                }
                return Head.Data;
            }
        }

        /// <summary>
        /// Tail item
        /// </summary>
        public T Last
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException();
                }
                return Tail.Data;
            }
        }

        /// <summary>
        /// Clear dequeue
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Is dequeue contains item?
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>is contains?</returns>
        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
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

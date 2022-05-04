using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class MyLinkedListData
    {
        public static void Show()
        {
            var mll = new MyLinkedList<string>
            {
                "Tom",
                "Jerry",
                "Spike",
                "Mammy",
                "Butch"
            };

            Console.WriteLine($"MyLinkedList: {mll}");

            mll.Add("Nimbus");
            Console.WriteLine($"Added val: {mll}");

            mll.Remove("Mammy");
            Console.WriteLine($"Removed val: {mll}");

            Console.WriteLine($"Jerry exist?: {mll.Contains("Jerry")}");

            mll.AppendFirst("Cartoon");
            Console.WriteLine($"Appended first: {mll}");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Linked List is a set of linked nodes,
    /// each of which stores its own item and a link to the next node.
    /// </summary>
    /// <typeparam name="T">Linked list item type</typeparam>
    public class MyLinkedList<T> : IEnumerable<T> // My linked list
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
        /// Add item
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            var node = new MyNode<T>(item);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            Count++;
        }

        /// <summary>
        /// Remove item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            var current = Head;
            MyNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    // If the node in the middle or in the end
                    if (previous != null)
                    {
                        // Deop current node, previous got reference to the current.Next
                        previous.Next = current.Next;

                        // If current.Next doesn't, then it's the last node,
                        // set Tail
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        // If it's first node
                        // set Head
                        Head = Head.Next;

                        // if list is empty after removing then drop Tail
                        if (Head == null)
                            Tail = null;
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// If linked list contains item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>contains?</returns>
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

        /// <summary>
        /// Add to Head
        /// </summary>
        /// <param name="item">item</param>
        public void AppendFirst(T item)
        {
            var node = new MyNode<T>(item)
            {
                Next = Head
            };
            Head = node;
            if (Count == 0)
            {
                Tail = Head;
            }
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public override string ToString()
        {
            return $"Total: {this.Count}. {string.Join(", ", this)}";
        }
    }
}

using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class CircularLinkedListData
    {
        public static void Show()
        {
            var cll = new CircularLinkedList<string>
            {
                "Batman",
                "Robin",
                "Catwoman",
                "Batgirl"
            };

            Console.WriteLine($"CircularLinkedList: {cll}");

            cll.Remove("Robin");
            Console.WriteLine($"Removed val: {cll}");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Circular lists are a kind of linked lists.
    /// They can be single-linked or double-linked.
    /// Their distinguishing feature is that the conditional last element
    /// stores a reference to the first element, so the list is closed or circular.
    ///
    /// We need references to the conditionally first and last element
    /// in the form of head and tail variables,
    /// although the list will be circular and will not have a beginning and end.
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class CircularLinkedList<T> : IEnumerable<T>  // кольцевой связный список
    {
        /// <summary>
        /// Head/First item
        /// </summary>
        public MyNode<T> Head { get; private set; } = null!;

        /// <summary>S
        /// Last/Tail item
        /// </summary>
        public MyNode<T> Tail { get; private set; } = null!;

        /// <summary>
        /// Total Count of items in linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If linked list is empty
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add item
        ///
        /// The addition boils down to resetting the pointer to the last element of tail,
        /// and the new element is placed between tail and head.
        /// </summary>
        /// <param name="item">Item</param>
        public void Add(T item)
        {
            var node = new MyNode<T>(item);
            
            //if the list is empty
            if (Head == null)
            {
                Head = node;
                Tail = node;
                Tail.Next = Head;
            }
            else
            {
                node.Next = Head;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Remove item
        ///
        /// When removing, we reset the pointer to the next element of the previous element
        /// in relation to the one being removed
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>is removed?</returns>
        public bool Remove(T item)
        {
            var current = Head;
            MyNode<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Data.Equals(item))
                {
                    // if the node in the middle or in the end
                    if (previous != null)
                    {
                        // drop current, now previous referenced to current.Next
                        previous.Next = current.Next;

                        // if it's the last node,
                        // set Tail
                        if (current == Tail)
                            Tail = previous;
                    }
                    else // if removing the first node
                    {

                        // if it has only one item
                        if (Count == 1)
                        {
                            Head = Tail = null;
                        }
                        else
                        {
                            Head = current.Next;
                            Tail.Next = current.Next;
                        }
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != Head);

            return false;
        }

        /// <summary>
        /// Clear list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// If linked list contains item
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>contains?</returns>
        public bool Contains(T item)
        {
            var current = Head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(item))
                    return true;
                current = current.Next;
            }
            while (current != Head);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = Head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != Head);
        }

        public override string ToString()
        {
            return $"Total: {this.Count}. {string.Join(", ", this)}";
        }
    }
}

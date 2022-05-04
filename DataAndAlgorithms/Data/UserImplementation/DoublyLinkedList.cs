using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class DoublyLinkedListData
    {
        public static void Show()
        {
            var mdll = new DoublyLinkedList<string>
            {
                "Leonard",
                "Sheldon",
                "Howard",
                "Radjesh",
                "Penny"
            };

            Console.WriteLine($"MyLinkedList: {mdll}");

            mdll.Add("Bernadette");
            Console.WriteLine($"Added val: {mdll}");

            mdll.Remove("Howard");
            Console.WriteLine($"Removed val: {mdll}");

            Console.WriteLine($"Penny exist?: {mdll.Contains("Penny")}");
            Console.WriteLine($"Amy exist?: {mdll.Contains("Amy")}");

            // Reverse enum
            foreach (var t in mdll.BackEnumerator())
            {
                Console.WriteLine(t);
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Doubly linked list
    /// Doubly linked lists also represent a sequence of linked nodes,
    /// but now each node stores a link to the next and previous elements.
    /// It works like MyLinked list but you should add Node to Previous property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : IEnumerable<T>
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
        /// Total count of items in linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If linked list is empty
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add item
        ///
        /// If there are already elements in the list,
        /// then the Previous property of the added node points to the node
        /// that was previously stored in the Tail variable.
        /// </summary>
        /// <param name="item">Item</param>
        public void Add(T item)
        {
            var node = new DoublyNode<T>(item);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }

        /// <summary>
        /// Add item to head
        /// if there are already elements in the list,
        /// then the Previous property of the node being added points to the node
        /// that was previously stored in the Tail variable
        /// </summary>
        /// <param name="item">item</param>
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
        /// Remove item
        ///
        /// When remving, we need to find the element to be removed.
        /// Then, we need to reset two references
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>Is removed?</returns>
        public bool Remove(T item)
        {
            var current = Head;

            // looking for the node should be removed
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    break;
                }
                current = current.Next;
            }

            if (current == null)
            {
                return false;
            }

            // If the node isn't last
            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                // If node is last thant set new Tail
                Tail = current.Previous;
            }

            // If the node isn't first
            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                // If node is first thant set new Head
                Head = current.Next;
            }
            Count--;
            return true;
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
        /// Is list contains item?
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

        /// <summary>
        /// Iterate over the elements from the end.
        /// </summary>
        /// <returns>Reverse list</returns>
        public IEnumerable<T> BackEnumerator()
        {
            var current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public override string ToString()
        {
            return $"Total: {this.Count}. {string.Join(", ", this)}";
        }
    }
}

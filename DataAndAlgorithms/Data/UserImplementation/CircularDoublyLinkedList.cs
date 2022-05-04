using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class CircularDoublyLinkedListData
    {
        public static void Show()
        {
            var cll = new CircularDoublyLinkedList<string>
            {
                "Gordon",
                "Alyx",
                "Barney",
                "G-Man"
            };

            Console.WriteLine($"CircularDoublyLinkedList: {cll}");

            cll.Remove("Barney");
            Console.WriteLine($"Removed val: {cll}");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// A circular doubly linked list is a closed list in which
    /// the pointer to an element can move both forward and backward around the circle.
    ///
    /// Each node of a list will represent an element
    /// that stores pointers to the next and previous nodes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularDoublyLinkedList<T> : IEnumerable<T>  // кольцевой двусвязный список
    {
        /// <summary>
        /// Head/First item
        /// </summary>
        public DoublyNode<T> Head { get; private set; } = null!;


        /// <summary>
        /// Total Count of items in linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If linked list is empty
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        ///
        ///
        /// Adding is that we reset the previous element in relation to head
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            var node = new DoublyNode<T>(item);

            if (Head == null)
            {
                Head = node;
                Head.Next = node;
                Head.Previous = node;
            }
            else
            {
                node.Previous = Head.Previous;
                node.Next = Head;
                Head.Previous.Next = node;
                Head.Previous = node;
            }
            Count++;
        }

        /// <summary>
        /// Remove item
        ///
        /// When remving, we need to find the element to be removed.
        /// Then, we need to reset reference
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>Is removed?</returns>
        public bool Remove(T item)
        {
            var current = Head;

            DoublyNode<T> removedItem = null;
            if (Count == 0)
            {
                return false;
            }

            // looking for the element should be deleted
            do
            {
                if (current.Data != null && current.Data.Equals(item))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != Head);

            if (removedItem == null)
            {
                return false;
            }
            // if it delete the only one item
            if (Count == 1)
            {
                Head = null;
            }
            else
            {
                // If it's first item
                if (removedItem == Head)
                {
                    Head = Head.Next;
                }
                removedItem.Previous.Next = removedItem.Next;
                removedItem.Next.Previous = removedItem.Previous;
            }
            Count--;
            return true;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            if (current == null)
            {
                return false;
            }
            do
            {
                if (current.Data != null && current.Data.Equals(item))
                {
                    return true;
                }
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
                if (current == null)
                {
                    continue;
                }
                yield return current.Data;
                current = current.Next;
            }
            while (current != Head);
        }

        public override string ToString()
        {
            return $"Total: {this.Count}. {string.Join(", ", this)}";
        }
    }
}

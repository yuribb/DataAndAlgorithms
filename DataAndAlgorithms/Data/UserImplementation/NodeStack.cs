using System.Collections;

namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class NodeStackData
    {
        public static void Show()
        {
            var nst = new NodeStack<string>();
            nst.Push("Odin");
            nst.Push("Thor");
            nst.Push("Loki");
            nst.Push("Heimdall");

            Console.WriteLine($"NodeStack: {nst}");

            var pop = nst.Pop();
            Console.WriteLine($"Stack pop: {nst}. Popped: {pop}");

            var peek = nst.Peek();
            Console.WriteLine($"Stack peek: {nst}. Peeked: {peek}");

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Stack is a data structure which works by using LIFO (Last in First out) principle.
    /// Stack has a top that forms the last added element.
    /// When added, the new element is placed on top of the stack and forms a new top.
    /// When deleting, an element is removed from the top of the stack, and the previous element forms a new top.
    ///
    /// On the node stack we just need to reset the reference to the head element,
    /// which is the top of the stack.
    ///
    /// The algorithmic complexity of the Push and Pop methods is O(1).
    /// </summary>
    /// <typeparam name="T">Stack data type</typeparam>
    public class NodeStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Head/First item
        /// </summary>
        public MyNode<T> Head { get; private set; } = null!;

        /// <summary>
        /// Total count of items in linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// If linked list is empty
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Add item into stack
        /// </summary>
        /// <param name="item">item</param>
        public void Push(T item)
        {
            // Increase stack
            var node = new MyNode<T>(item)
            {
                Next = Head // Set head to the NEW item
            };
            Head = node;
            Count++;
        }

        /// <summary>
        /// Execute item from stack
        /// </summary>
        /// <returns>Item</returns>
        /// <exception cref="InvalidOperationException">Throws when stack is empty</exception>
        public T Pop()
        {
            // if the stack is empty throw ex
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var temp = Head;
            Head = Head.Next; // Set head to the NEXT item
            Count--;
            return temp.Data;
        }

        /// <summary>
        /// Get last item from stack without execution
        /// </summary>
        /// <returns>item</returns>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return Head.Data;
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

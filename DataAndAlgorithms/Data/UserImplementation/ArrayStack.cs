namespace DataAndAlgorithms.Data.UserImplementation
{
    public static class ArrayStackData
    {
        public static void Show()
        {
            var ast = new ArrayStack<string>(3);
            ast.Push("Any");
            ast.Push("Many");
            ast.Push("Money");
            ast.Push("More");

            Console.WriteLine($"ArrayStack: {ast}");

            var pop = ast.Pop();
            Console.WriteLine($"Stack pop: {ast}. Popped: {pop}");

            var peek = ast.Peek();
            Console.WriteLine($"Stack peek: {ast}. Peeked: {peek}");

            Console.WriteLine();
        }
    }


    /// <summary>
    /// Stack is a data structure which works by using LIFO (Last in First out) principle.
    /// Stack has a top that forms the last added element.
    /// When added, the new element is placed on top of the stack and forms a new top.
    /// When deleting, an element is removed from the top of the stack, and the previous element forms a new top.
    ///
    /// This implementation represents a generic class,
    /// and therefore allows you to store elements of any type.
    /// The elements themselves on the stack will actually be stored in the items array.
    /// </summary>
    /// <typeparam name="T">Stack data type</typeparam>
    public class ArrayStack<T>
    {
        private T[] items;
        const int n = 10;

        public ArrayStack()
        {
            items = new T[n];
        }
        public ArrayStack(int capacity)
        {
            items = new T[capacity];
        }

        public bool IsEmpty => Count == 0;

        public int Count { get; private set; }

        /// <summary>
        /// Add item into stack
        ///
        /// We add an element to the array,
        /// while increasing the value of the count variable.
        /// If the stack is already full, then we throw an exception.
        /// </summary>
        /// <param name="item">item</param>
        public void Push(T item)
        {
            // increase stack
            if (Count == items.Length)
            {
                Resize(items.Length + 10);
            }

            items[Count++] = item;
        }

        /// <summary>
        /// Execute item from stack
        ///
        /// We pop an element from the top of the stack,
        /// while decrementing the value of the count variable.
        /// If there are no elements on the stack, then we throw an exception.
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
            var item = items[--Count];
            items[Count] = default(T); // drop the reference

            if (Count > 0 && Count < items.Length - 10)
            {
                Resize(items.Length - 10);
            }

            return item;
        }

        /// <summary>
        /// Get last item from stack without execution
        /// </summary>
        /// <returns>item</returns>
        public T Peek()
        {
            return items[Count - 1];
        }

        /// <summary>
        /// Resize basic array when it's full
        /// </summary>
        /// <param name="max">new capacity</param>
        private void Resize(int max)
        {
            var tempItems = new T[max];
            for (var i = 0; i < Count; i++)
            {
                tempItems[i] = items[i];
            }
            items = tempItems;
        }

        public override string ToString()
        {
            return $"Total: {this.Count}. {string.Join(", ", items)}";
        }
    }
}

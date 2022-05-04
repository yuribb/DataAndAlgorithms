using DataAndAlgorithms.Common;

namespace DataAndAlgorithms.Algorithms
{
    public static class BinaryTree
    {
        /// <summary>
        /// Unbalanced Binary Search Tree sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void UnbalancedTreeSort<T>(this List<T> collection) where T : IComparable<T>
        {
            if (collection.Count == 0)
                return;

            var treeRoot = new TreeNode<T>
            {
                Value = collection[0]
            };

            // Get a handle on root.
            for (var i = 1; i < collection.Count; ++i)
            {
                var currentNode = treeRoot;
                var newNode = new TreeNode<T>
                {
                    Value = collection[i]
                };

                while (true)
                {
                    // Go left
                    if (newNode.Value.IsLessThan(currentNode.Value))
                    {
                        if (currentNode.Left == null)
                        {
                            newNode.Parent = currentNode;
                            currentNode.Left = newNode;
                            break;
                        }

                        currentNode = currentNode.Left;
                    }
                    // Go right
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            newNode.Parent = currentNode;
                            currentNode.Right = newNode;
                            break;
                        }

                        currentNode = currentNode.Right;
                    }
                }//end-while
            }//end-for

            // Reference handle to root again.
            collection.Clear();
            var treeRootReference = treeRoot;
            OrderTravelAndAdd(treeRootReference, ref collection);
            treeRootReference = treeRoot = null;
        }


        /// <summary>
        /// Used to travel a node's subtrees and add the elements to the collection.
        /// </summary>
        /// <typeparam name="T">Type of tree elements.</typeparam>
        /// <param name="currentTreeNode">TreeNode to start from.</param>
        /// <param name="collection">Collection to add elements to.</param>
        private static void OrderTravelAndAdd<T>(TreeNode<T> currentTreeNode, ref List<T> collection) where T : IComparable<T>
        {
            if (currentTreeNode == null)
            {
                return;
            }

            OrderTravelAndAdd(currentTreeNode.Left, ref collection);
            collection.Add(currentTreeNode.Value);
            OrderTravelAndAdd(currentTreeNode.Right, ref collection);
        }


        /// <summary>
        /// Minimal BST TreeNode class, used only for unbalanced binary search tree sort.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
        {
            public T Value { get; init; }
            public TreeNode<T> Parent { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }

            public TreeNode()
            {
                Value = default!;
                Parent = null!;
                Left = null!;
                Right = null!;
            }

            public int CompareTo(TreeNode<T> other)
            {
                if (other == null)
                {
                    return -1;
                }
                return this.Value.CompareTo(other.Value);
            }
        }
    }
}

namespace DataAndAlgorithms.Data.UserImplementation
{
    /// <summary>
    /// Node. Item with link to nex item
    /// </summary>
    /// <typeparam name="T">Item data type</typeparam>
    public class MyNode<T>
    {
        public MyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public MyNode<T> Next { get; set; }
    }
}

namespace DataStructures.Trees
{
  public class Node<T>
  {
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }

    public static implicit operator Node<T>(T value)
    {
      return new Node<T> { Value = value };
    }
  }
}

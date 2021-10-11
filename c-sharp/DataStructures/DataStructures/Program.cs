using System;
namespace DataStructures
{
  public class Program
  {
    public static void Main(string[] args) 
    {
      Console.WriteLine("hi");

      LinkedList ll = new LinkedList();
      ll.Insert(42);

      Console.WriteLine(ll);

      int[] arr = new int[] { 1, 2, 3 };
      Console.WriteLine(arr);
    }
  }
}

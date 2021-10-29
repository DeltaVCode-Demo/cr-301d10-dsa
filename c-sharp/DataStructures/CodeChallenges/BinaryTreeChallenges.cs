using DataStructures.Trees;
using System;
using System.Collections.Generic;

namespace CodeChallenges
{
  public class BinaryTreeChallenges
  {
    public static int Sum(BinaryTree<int> tree)
    {
      return Sum(tree.Root);
    }

    private static int Sum(Node<int> node)
    {
      if (node == null) return 0;

      return node.Value
        + Sum(node.Left)
        + Sum(node.Right);
    }

    public static int SumOdds(BinaryTree<int> tree)
    {
      return SumOdds(tree.Root);

      // Local Function - even more private than private
      int SumOdds(Node<int> node)
      {
        if (node == null) return 0;

        int sum = 0;

        // Only add odd value
        if (node.Value % 2 != 0)
        {
          sum += node.Value;
        }

        sum += SumOdds(node.Left);
        sum += SumOdds(node.Right);

        return sum;
      }
    }

    public static int CountLeafNodes(BinaryTree<int> tree)
    {
      //return CountLeafNodes(tree.Root);

      // Breadth-First
      Queue<Node<int>> q = new Queue<Node<int>>();
      q.Enqueue(tree.Root);

      int count = 0; // No files yet
      while (q.Count > 0)
      {
        Node<int> next = q.Dequeue();

        if (next == null) continue; // skip null; not a file

        if (next.Left == null && next.Right == null)
        {
          count++;
        }
        else
        {
          q.Enqueue(next.Left);
          q.Enqueue(next.Right);
        }
      }
      return count;
    }

    private static int CountLeafNodes(Node<int> node)
    {
      if (node == null) return 0;

      if (node.Left == null && node.Right == null) return 1;

      return CountLeafNodes(node.Left) + CountLeafNodes(node.Right);
    }
  }
}

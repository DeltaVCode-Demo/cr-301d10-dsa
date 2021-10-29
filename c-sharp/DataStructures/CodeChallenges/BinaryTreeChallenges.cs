using DataStructures.Trees;
using System;

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
  }
}

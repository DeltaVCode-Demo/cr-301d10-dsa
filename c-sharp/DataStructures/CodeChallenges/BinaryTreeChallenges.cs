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
  }
}

using DataStructures;

namespace CodeChallenges
{
  public static class LinkedListChallenges
  {
    public static LinkedList ZipTwoLists(LinkedList list1, LinkedList list2)
    {
      if (list1.Head == null)
        return list2;

      Node c1 = list1.Head;
      Node c2 = list2.Head;

      while (c1 != null && c2 != null)
      {
        // list1: (A) -> (C) -> (E) ->
        // list2: (B) -> (D) -> (F) ->

        Node n1 = c1.Next;
        c1.Next = c2; // point at (B)
        c1 = n1;      // Move c1 to (C)

        Node n2 = c2.Next;

        // Don't lose the rest of l2 if c1 is done
        if (c1 != null)
        {
          c2.Next = c1; // point at (C)
        }
        c2 = n2;      // Move c2 to (D)
      }

      // We think we're done!
      return list1;
    }
  }
}

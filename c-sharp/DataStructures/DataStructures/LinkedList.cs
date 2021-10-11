using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  public class LinkedList
  {
    public Node Head { get; set; }

    public void Insert(int value)
    {
      Node newNode = new Node();
      newNode.Value = value;

      // Point new node at the rest of the list
      newNode.Next = this.Head;

      this.Head = newNode;
    }

    public bool Includes(int valueToFind)
    {
      Node current = Head;

      while (current != null)
      {
        // Do something interesting with current
        if (current.Value == valueToFind)
        {
          return true;
        }

        current = current.Next;
      }

      return false;
    }

    // For now, just use override because Keith said so
    public override string ToString()
    {
      // TODO: Traverse to build the string
      return "NULL";
    }
  }
}

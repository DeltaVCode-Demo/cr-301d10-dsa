using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
  public class LinkedList : IEnumerable<int>
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
      string output = "";

      Node current = Head;
      while (current != null)
      {
        // Do something interesting with current
        output += current.Value;
        output += " -> ";

        // Traverse to Next
        current = current.Next;
      }

      // Got to the end
      output = output + "NULL";

      return output;
    }

    public IEnumerator<int> GetEnumerator()
    {
      Node current = Head;

      while (current != null)
      {
        // Include this value in our sequence
        yield return current.Value;

        // Move to next node
        current = current.Next;
      }
    }

    // Explicit implementation because legacy code
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}

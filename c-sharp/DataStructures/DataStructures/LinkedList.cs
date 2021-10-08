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

      this.Head = newNode;
    }

    public bool Includes(int valueToFind)
    {
      // TODO: finish me!
      return false;
    }
  }
}

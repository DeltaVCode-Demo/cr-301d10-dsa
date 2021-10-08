using System;
using Xunit;

using DataStructures;

namespace DataStructuresTests
{
  public class LinkedListTests
  {
    [Fact]
    public void Empty_list_has_null_Head()
    {
      // Arrange
      LinkedList list = new LinkedList();

      // Act
      Node head = list.Head;

      // Assert
      Assert.Null(head);
    }

    [Fact]
    public void Insert_into_empty_LinkedList_adds_Node_with_Value_at_Head()
    {
      // Arrange
      LinkedList list = new LinkedList();

      // Act
      list.Insert(1);

      // Assert
      Assert.NotNull(list.Head);
      Assert.Equal(1, list.Head.Value);
    }
  }
}

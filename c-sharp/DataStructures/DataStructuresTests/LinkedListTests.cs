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
      // Make sure we have a Head node
      Assert.NotNull(list.Head);

      // Make sure the Head node has the inserted Value
      Assert.Equal(1, list.Head.Value);

      // Make sure the Head node does not have a Next
      Assert.Null(list.Head.Next);
    }

    [Fact]
    public void Insert_into_list_not_empty_works()
    {
      // Arrange
      LinkedList list = new LinkedList();
      list.Insert(5);

      // Act
      list.Insert(3);

      // Assert
      Assert.NotNull(list.Head);
      Assert.Equal(3, list.Head.Value);
      Assert.NotNull(list.Head.Next);
      Assert.Equal(5, list.Head.Next.Value);
      Assert.Null(list.Head.Next.Next);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    public void Includes_finds_value_or_not(int valueToFind, bool expected)
    {
      // Arrange
      LinkedList list = new LinkedList();
      list.Insert(2);
      list.Insert(3);

      // Act
      bool result = list.Includes(valueToFind);

      // Assert
      Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_returns_NULL_for_empty_list()
    {
      // Arrange
      LinkedList list = new LinkedList();

      // Act
      string result = list.ToString();

      // Assert
      Assert.Equal("NULL", result);
    }

    [Fact]
    public void ToString_returns_the_list()
    {
      // Arrange
      LinkedList list = new LinkedList();
      list.Insert(3);
      list.Insert(2);
      list.Insert(1);

      // Act
      string result = list.ToString();

      // Assert
      Assert.Equal("1 -> 2 -> 3 -> NULL", result);
    }
  }
}

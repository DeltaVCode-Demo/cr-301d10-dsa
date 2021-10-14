using System;
using CodeChallenges;
using DataStructures;
using Xunit;

namespace CodeChallengesTests
{
  public class LinkedListCodeChallengeTests
  {
    [Fact]
    public void ZipTwoLists_with_both_empty_returns_empty_list()
    {
      // Arrange
      LinkedList list1 = new LinkedList();

      LinkedList list2 = new LinkedList();

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Empty(result);
    }

    [Fact]
    public void ZipTwoLists_with_empty_list1_returns_list2()
    {
      // Arrange
      LinkedList list1 = new LinkedList();

      LinkedList list2 = new LinkedList();
      list2.Insert(1);

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void ZipTwoLists_with_empty_list2_returns_list1()
    {
      // Arrange
      LinkedList list1 = new LinkedList();
      list1.Insert(1);

      LinkedList list2 = new LinkedList();

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void ZipTwoLists_with_singleton_lists()
    {
      // Arrange
      LinkedList list1 = new LinkedList();
      list1.Insert(1);

      LinkedList list2 = new LinkedList();
      list2.Insert(2);

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Equal(new[] { 1, 2 }, result);
    }

    [Fact]
    public void ZipTwoLists_with_bigger_equal_length_lists()
    {
      // Arrange
      LinkedList list1 = new LinkedList();
      list1.Insert(1, 3, 5);

      LinkedList list2 = new LinkedList();
      list2.Insert(2, 4, 6);

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Fact]
    public void ZipTwoLists_with_larger_list1()
    {
      // Arrange
      LinkedList list1 = new LinkedList();
      list1.Insert(1, 3, 5, 7);

      LinkedList list2 = new LinkedList();
      list2.Insert(2, 4);

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Equal(new[] { 1, 2, 3, 4, 5, 7 }, result);
    }

    [Fact]
    public void ZipTwoLists_with_larger_list2()
    {
      // Arrange
      LinkedList list1 = new LinkedList();
      list1.Insert(1, 3);

      LinkedList list2 = new LinkedList();
      list2.Insert(2, 4, 6, 8);

      // Act
      LinkedList result = LinkedListChallenges.ZipTwoLists(list1, list2);

      // Assert
      Assert.Equal(new[] { 1, 2, 3, 4, 6, 8 }, result);
    }
  }
}

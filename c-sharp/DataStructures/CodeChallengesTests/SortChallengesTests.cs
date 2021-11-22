using System.Linq;
using CodeChallenges;
using Xunit;

namespace CodeChallengesTests
{
  public class SortChallengesTests
  {
    [Theory]
    [InlineData(new[] { 9 })]
    [InlineData(new[] { 9, 6 })]
    [InlineData(new[] { 9, 6, 8 })]
    [InlineData(new[] { 9, 6, 8, 2 })]
    [InlineData(new[] { 9, 6, 8, 2, 7 })]
    [InlineData(new[] { 9, 6, 8, 2, 7, 1 })]
    public void MergeSort_works(int[] arr)
    {
      // Arrange
      int[] expected = arr.OrderBy(n => n).ToArray();

      // Act
      SortChallenges.MergeSort(arr);

      // Assert
      Assert.Equal(expected, arr);
    }
  }
}
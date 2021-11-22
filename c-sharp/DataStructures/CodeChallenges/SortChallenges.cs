using System;
using System.Collections.Generic;

namespace CodeChallenges
{
  public static class SortChallenges
  {
    public static void MergeSort<T>(T[] input) where T : IComparable<T>
      => MergeSort(input, Comparer<T>.Default);

    public static void MergeSort<T>(T[] input, IComparer<T> comparer) where T : IComparable<T>
    {
      if (input.Length <= 1) return;

      int mid = input.Length / 2;
      T[] left = input[..mid];
      T[] right = input[mid..];

      MergeSort(left, comparer);
      MergeSort(right, comparer);

      Merge(left, right, input, comparer);
    }

    private static void Merge<T>(T[] left, T[] right, T[] input, IComparer<T> comparer) where T : IComparable<T>
    {
      int i = 0, l = 0, r = 0;

      while (l < left.Length && r < right.Length)
        input[i++] = comparer.Compare(left[l], right[r]) <= 0 ? left[l++] : right[r++];

      while (l < left.Length)
        input[i++] = left[l++];

      while (r < right.Length)
        input[i++] = right[r++];
    }
  }
}

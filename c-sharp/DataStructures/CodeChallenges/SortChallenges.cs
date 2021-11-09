namespace CodeChallenges
{
  public static class SortChallenges
  {
    public static void MergeSort(int[] input)
    {
      if (input.Length <= 1) return;

      int mid = input.Length / 2;
      int[] left = input[..mid];
      int[] right = input[mid..];

      MergeSort(left);
      MergeSort(right);

      Merge(left, right, input);
    }

    private static void Merge(int[] left, int[] right, int[] input)
    {
      int i = 0, l = 0, r = 0;

      while (l < left.Length && r < right.Length)
        input[i++] = left[l] < right[r] ? left[l++] : right[r++];

      while (l < left.Length)
        input[i++] = left[l++];

      while (r < right.Length)
        input[i++] = right[r++];
    }
  }
}

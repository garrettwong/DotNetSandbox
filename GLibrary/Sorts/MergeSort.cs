namespace GLibrary.Sorts;
public class Mergesort : ISort
{
    public void Sort(int[] arr)
    {
        arr = MS(arr);
    }

    public int[] MS(int[] data)
    {
        if (data.Length < 2)
        {
            return data;
        }

        int mid = data.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[data.Length - mid];

        Array.Copy(data, left, left.Length);
        Array.Copy(data, mid, right, 0, right.Length);

        MS(left);
        MS(right);

        return Merge(data, left, right);
    }

    /// <summary>
    /// merge two smaller arrays into a larger array
    /// </summary>
    /// <param name="dest"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private int[] Merge(int[] dest, int[] left, int[] right)
    {
        int destIdx = 0;
        int leftIdx = 0;
        int rightIdx = 0;

        // merge arrays while there are elements in both
        while (leftIdx < left.Length && rightIdx < right.Length)
        {
            if (left[leftIdx] <= right[rightIdx])
            {
                dest[destIdx++] = left[leftIdx++];
            }
            else
            {
                dest[destIdx++] = right[rightIdx++];
            }
        }

        // copy rest of array
        while (leftIdx < left.Length)
        {
            dest[destIdx++] = left[leftIdx++];
        }
        while (rightIdx < right.Length)
        {
            dest[destIdx++] = right[rightIdx++];
        }

        return dest;
    }
}

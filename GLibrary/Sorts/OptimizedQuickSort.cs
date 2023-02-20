namespace GLibrary.Sorts;
public class OptimizedQuicksort : ISort
{
    public void Sort(int[] arr)
    {
        QS(arr, 0, arr.Length);
    }

    public void QS(int[] data, int start, int length)
    {
        if (length < 2) return;

        int pivotIndex = start + length / 2; // use middle as pivot index

        int pivotValue = data[pivotIndex];
        int end = start + length;
        int cur = start;

        // swap pivot to end
        SortUtils.Swap(data, pivotIndex, --end);

        // partition rest of array
        while (cur < end)
        {
            if (data[cur] < pivotValue)
            {
                cur++;
            }
            else
            {
                SortUtils.Swap(data, cur, --end);
            }
        }

        // swap pivot back to its final destination
        SortUtils.Swap(data, end, start + length - 1);

        // apply algorithm to each partition
        int leftLen = end - start;
        int rightLen = length - leftLen - 1;

        if (leftLen > 1)
        {
            QS(data, start, leftLen);
        }
        if (rightLen > 1)
        {
            QS(data, end + 1, rightLen);
        }
    }
}
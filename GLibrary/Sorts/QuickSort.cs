namespace GLibrary.Sorts;
public class Quicksort : ISort
{
    public void Sort(int[] arr)
    {
        QS(arr, 0, arr.Length - 1);
    }

    public void QS(int[] arr, int lo, int hi)
    {
        if (lo < hi)
        {
            var pivotIndex = Partition(arr, lo, hi);
            QS(arr, lo, pivotIndex);
            QS(arr, pivotIndex + 1, hi);
        }
    }

    public int Partition(int[] arr, int lo, int hi)
    {
        int pivot = arr[lo];

        int i = lo - 1;
        int j = hi + 1;

        do
        {
            do
            {
                i = i + 1;
            } while (arr[i] < pivot);

            do
            {
                j = j - 1;
            } while (arr[j] > pivot);

            if (i >= j)
            {
                return j;
            }

            SortUtils.Swap(arr, i, j);
        } while (true);
    }
}

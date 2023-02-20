namespace GLibrary.Sorts;
/// <summary>
/// https://github.com/harichinnan/Java-Algorithms/blob/master/Introsort.java
/// </summary>
public class Introsort2 : ISort
{
    private const int SIZE_THRESHOLD = 16;

    public void Sort(int[] arr)
    {
        IntroSortLoop(arr, 0, arr.Length, 2 * FloorLg(arr.Length));
    }

    private void IntroSortLoop(int[] arr, int lo, int hi, int depth_limit)
    {
        while (hi - lo > SIZE_THRESHOLD)
        {
            if (depth_limit == 0)
            {
                Heapsort(arr, lo, hi);
                return;
            }
            depth_limit = depth_limit - 1;
            int p = Partition(arr, lo, hi,
                    Medianof3(arr, lo, lo + ((hi - lo) / 2) + 1, hi - 1));

            IntroSortLoop(arr, p, hi, depth_limit);
            hi = p;
        }

        Insertionsort(arr, lo, hi);
    }

    /*
     * Quicksort algorithm modified for Introsort
     */
    private int Partition(int[] arr, int lo, int hi, int x)
    {
        int i = lo, j = hi;
        while (true)
        {
            while (arr[i].CompareTo(x) < 0)
                i++;
            j = j - 1;
            while (x.CompareTo(arr[j]) < 0)
                j = j - 1;
            if (!(i < j))
                return i;

            Exchange(arr, i, j);
            i++;
        }
    }

    private int Medianof3(int[] arr, int lo, int mid, int hi)
    {
        if (arr[mid].CompareTo(arr[lo]) < 0)
        {
            if (arr[hi].CompareTo(arr[mid]) < 0)
            {
                return arr[mid];
            }
            else
            {
                if (arr[hi].CompareTo(arr[lo]) < 0)
                    return arr[hi];
                else
                    return arr[lo];
            }
        }
        else
        {
            if (arr[hi].CompareTo(arr[mid]) < 0)
            {
                if (arr[hi].CompareTo(arr[lo]) < 0)
                    return arr[lo];
                else
                    return arr[hi];
            }
            else
                return arr[mid];
        }
    }

    /*
     * Heapsort algorithm
     */
    private void Heapsort(int[] arr, int lo, int hi)
    {
        int n = hi - lo;
        for (int i = n / 2; i >= 1; i = i - 1)
        {
            Downheap(arr, i, n, lo);
        }
        for (int i = n; i > 1; i = i - 1)
        {
            Exchange(arr, lo, lo + i - 1);
            Downheap(arr, 1, i - 1, lo);
        }
    }

    private void Downheap(int[] arr, int i, int n, int lo)
    {
        int d = arr[lo + i - 1];
        int child;
        while (i <= n / 2)
        {
            child = 2 * i;
            if (child < n && (arr[lo + child - 1].CompareTo(arr[lo + child]) < 0))
            {
                child++;
            }
            if (d.CompareTo(arr[lo + child - 1]) >= 0)
                break;
            arr[lo + i - 1] = arr[lo + child - 1];
            i = child;
        }

        arr[lo + i - 1] = d;
    }

    /*
     * Insertion sort algorithm
     */
    private void Insertionsort(int[] arr, int lo, int hi)
    {
        int i, j;
        int t;
        for (i = lo; i < hi; i++)
        {
            j = i;
            t = arr[i];
            while (j != lo && t.CompareTo(arr[j - 1]) < 0)
            {
                arr[j] = arr[j - 1];
                j--;
            }
            arr[j] = t;
        }
    }

    /*
     * Common methods for all algorithms
     */
    private void Exchange(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    private int FloorLg(int a)
    {
        return (int)(Math.Floor(Math.Log(a) / Math.Log(2)));
    }
}
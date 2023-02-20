namespace GLibrary.Sorts;
public class Insertionsort : ISort
{
    public void Sort(int[] arr)
    {
        InsertionSort(ref arr);
    }

    public void InsertionSort(ref int[] data)
    {
        for (int i = 1; i < data.Length; ++i)
        {
            int j = i;

            while ((j > 0))
            {
                if (data[j - 1] > data[j])
                {
                    data[j - 1] ^= data[j];
                    data[j] ^= data[j - 1];
                    data[j - 1] ^= data[j];

                    --j;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
namespace GLibrary.Sorts;
public class DotNetArraySort : ISort
{
    public void Sort(int[] arr)
    {
        Array.Sort(arr);
    }
}
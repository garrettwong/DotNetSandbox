using System;
namespace GLibrary.Sorts
{
    public class DataGenerator
    {
        public static int[] GenerateRandomArray(int numElements)
        {
            var r = new Random();
            r.Next(int.MinValue, int.MaxValue);

            int[] arr = new int[numElements];
            for (var i = 0; i < numElements; i++)
            {
                arr[i] = r.Next(int.MinValue, int.MaxValue);
            }

            return arr;
        }
    }
}


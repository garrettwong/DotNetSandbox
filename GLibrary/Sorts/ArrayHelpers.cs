using System.Collections;
using System.Reflection;

namespace GLibrary.Sorts;
public class ArrayHelpers
{
    /// <summary>
    /// Returns true if an array is sorted.
    /// Relies on CompareTo().
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static bool IsInSortedOrder<T>(T[] arr)
        where T : IComparable
    {
        if (arr.Length == 0) return true;

        T prev = arr[0];

        for (var x = 1; x < arr.Length; x++)
        {
            var cur = arr[x];

            if (prev != null &&
                prev.CompareTo(cur) > 0)
            {
                return false;
            }

            prev = arr[x];
        }
        return true;
    }

    /// <summary>
    /// Returns a list of types that implement a common interface
    /// For example, find me all Sorters that implement the ISort interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetSubtypesOfType<T>() where T : class
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var matchingTypes = new List<Type>();
        foreach(var t in types)
        {
            var interfaces = t.GetInterfaces();
            if (interfaces.Contains(typeof(T)))
            {
                matchingTypes.Add(t);
            }
        }
        return new List<T>(matchingTypes.Select(x => Activator.CreateInstance(x)).ToList().Cast<T>());
    }

    /// <summary>
    /// Prints a comma-separated-list of all elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void Print<T>(T[] arr)
        where T : IEnumerable
    {
        for (var x = 0; x < arr.Length; x++)
        {
            Console.Write(arr[x] + ", ");
        }
        Console.WriteLine();
    }
}


using System.Collections.Generic;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 5, 6 };

            var evenNumbers = numbers.Where(number => number % 2 == 0);
            Console.WriteLine($"Where: {string.Join(", ", evenNumbers)}");
            Console.WriteLine($"FirstOrDefault: {numbers.FirstOrDefault(number => number > 3)}");
            Console.WriteLine($"Any: {numbers.Any(number => number > 5)}");
            Console.WriteLine($"All: {numbers.All(number => number > 0)}");
            Console.WriteLine($"Count: {numbers.Count()}");
            Console.WriteLine($"Count with condition: {numbers.Count(number => number % 2 == 0)}");
        }
    }

    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static T? FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static int Count<T>(this IEnumerable<T> source)
        {
            int count = 0;
            foreach (T item in source)
            {
                count++;
            }

            return count;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int count = 0;
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }
    }
}

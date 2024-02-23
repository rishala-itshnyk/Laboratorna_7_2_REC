using System;

namespace Laboratorna_7_2_ITER;
public class Program
{
    static void Main()
    {
        Random rand = new Random();

        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        int[][] a = new int[k][];
        for (int i = 0; i < k; i++)
            a[i] = new int[n];

        int Low = 7, High = 65;
        Create(a, k, n, Low, High, 0, 0);
        Print(a, 0, 0, k, n);

        int minOfMax;

        if (SearchMinOfMaxRecursive(a, k, n, 0, int.MaxValue, out minOfMax))
            Console.WriteLine("min of max = " + minOfMax);
        else
            Console.WriteLine("there are no even elements in even rows");

        Console.ReadKey();
    }

    public static void Create(int[][] a, int k, int n, int Low, int High, int i, int j)
    {
        Random rand = new Random();

        if (i < k)
        {
            if (j < n)
            {
                a[i][j] = Low + rand.Next(High - Low + 1);
                Create(a, k, n, Low, High, i, j + 1);
            }
            else
            {
                Create(a, k, n, Low, High, i + 1, 0);
            }
        }
    }

    public static void Print(int[][] a, int i, int j, int k, int n)
    {
        if (i < k)
        {
            if (j < n)
            {
                Console.Write($"{a[i][j],4}");
                Print(a, i, j + 1, k, n);
            }
            else
            {
                Console.WriteLine();
                Print(a, i + 1, 0, k, n);
            }
        }
    }

    public static bool SearchMinOfMaxRecursive(int[][] a, int k, int n, int i, int minOfMax, out int result)
    {
        result = minOfMax;

        if (i >= k)
            return result != int.MaxValue;

        int maxInRow = GetMaxInRow(a[i], 0, n);

        if (i % 2 == 1)
        {
            result = Math.Min(result, maxInRow);
        }

        return SearchMinOfMaxRecursive(a, k, n, i + 1, result, out result);
    }

    public static int GetMaxInRow(int[] row, int j, int n)
    {
        if (j >= n)
            return int.MinValue;

        int currentMax = GetMaxInRow(row, j + 1, n);
        return Math.Max(row[j], currentMax);
    }
}

using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int K = 28;
        int N = (int)(20 + 0.6 * K);
        int[] a = new int[N];
        Random r = new Random();

        for (int i = 0; i < N; i++)
            a[i] = r.Next(10, 101);

        Console.WriteLine("Початковий масив:");
        Console.WriteLine(string.Join(" ", a));

        QuickSort(a, 0, a.Length - 1);
        Console.WriteLine("\nВідсортований масив:");
        Console.WriteLine(string.Join(" ", a));

        Console.Write("\nВведіть ключ: ");
        int key = int.Parse(Console.ReadLine());

        int count = CountKey(a, key);
        Console.WriteLine(count > 0
            ? $"\nЧисло {key} зустрічається {count} раз(и)."
            : "\nЧисло не знайдено.");
    }

    static void QuickSort(int[] a, int l, int r)
    {
        int i = l, j = r, p = a[(l + r) / 2];
        while (i <= j)
        {
            while (a[i] < p) i++;
            while (a[j] > p) j--;
            if (i <= j)
            {
                (a[i], a[j]) = (a[j], a[i]);
                i++; j--;
            }
        }
        if (l < j) QuickSort(a, l, j);
        if (i < r) QuickSort(a, i, r);
    }

    static int BinarySearch(int[] a, int key)
    {
        int l = 0, r = a.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            if (a[m] == key) return m;
            if (a[m] < key) l = m + 1; else r = m - 1;
        }
        return -1;
    }

    static int CountKey(int[] a, int key)
    {
        int idx = BinarySearch(a, key);
        if (idx == -1) return 0;
        int c = 1, i = idx - 1, j = idx + 1;
        while (i >= 0 && a[i--] == key) c++;
        while (j < a.Length && a[j++] == key) c++;
        return c;
    }
}

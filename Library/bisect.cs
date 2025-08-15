namespace AtCoder.MyLib;

public static class Bisect
{
    public static int Find<T>(ReadOnlySpan<T> items, T target) where T : IComparable<T>
    {
        var min = 0;
        var max = items.Length - 1;
        while (min <= max)
        {
            var mid = (min + max) / 2;
            var val = items[mid];
            var compareResult = val.CompareTo(target);
            if (compareResult == 0)
            {
                return mid;
            }

            if (compareResult > 0)
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return -1;
    }

    /// <summary>
    /// A[i] >= target なる最小のiを返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int LowerBound<T>(ReadOnlySpan<T> list, T target) where T : IComparable<T>
    {
        int left = 0;
        int right = list.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int res = list[mid].CompareTo(target);
            if (res == -1)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;
    }

    /// <summary>
    /// A[i] > target なる最小のiを返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int UpperBound<T>(ReadOnlySpan<T> list, T target) where T : IComparable<T>
    {
        int left = 0;
        int right = list.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int res = list[mid].CompareTo(target);
            if (res <= 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;
    }
}


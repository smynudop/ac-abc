using System.Buffers;

namespace AtCoder.MyLib;

public static class Util
{
    /// <summary>
    /// 長さcapacityのリストを作ります。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="capacity"></param>
    /// <returns></returns>
    public static List<T> List<T>(T value, int capacity)
    {
        return Enumerable.Repeat(value, capacity).ToList();
    }

    public static List<T> List<T>(Func<T> func, int capacity)
    {
        var result = new List<T>(capacity);
        for (var i = 0; i < capacity; i++)
        {
            result.Add(func());
        }
        return result;
    }

    /// <summary>
    /// 累積和
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<long> Ruiseki(IEnumerable<int> list)
    {
        var len = list.Count();
        var result = new List<long>(len);
        long s = 0;
        foreach (var n in list)
        {
            s += n;
            result.Add(s);
        }
        return result;
    }

    public static void Swap<T>(Span<T> s1, Span<T> s2)
    {
        var buffer = ArrayPool<T>.Shared.Rent(s1.Length);
        var tmp = buffer.AsSpan().Slice(0, s1.Length);
        s1.CopyTo(tmp);
        s2.CopyTo(s1);
        tmp.CopyTo(s2);
        ArrayPool<T>.Shared.Return(buffer);
    }
}
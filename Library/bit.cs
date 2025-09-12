using System;

namespace AtCoder.MyLib;
public class BIT
{
    private int Size;
    private long[] array;

    public BIT(ICollection<long> items)
    {
        var Size = items.Count + 1;
        this.array = new long[Size + 1];

        int i = 0;
        foreach (var item in items)
        {
            Add(i++, item);
        }

    }

    /// <summary>
    /// 値を更新する。
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Add(int index, long value)
    {
        for(int i = index + 1; i <= Size; i += (i & -i))
        {
            array[i] += value;
        }
    }

    /// <summary>
    /// [0, x)の和を取得する
    /// </summary>
    /// <param name="x"></param>
    public long Sum(int x)
    {
        long result = 0;
        for(int i = x; i > 0; i -= (i & -i))
        {
            result += array[i];
        }
        return result;
    }

    /// <summary>
    /// 半開区間[l, r)の計算値を取得する。
    /// </summary>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public long Range(int l, int r)
    {
        return Sum(r) - Sum(l);
    }
}

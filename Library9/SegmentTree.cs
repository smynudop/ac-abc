using System.Numerics;
using System.Runtime.CompilerServices;

namespace AtCoder.MyLib;

public abstract class SegmentTreeAbstract<T>
{
    /// <summary>
    /// 配列のサイズ。2べきになるように決定する。
    /// </summary>
    private int Size;

    /// <summary>
    /// ツリーとなる配列。Size * 2の大きさを持つ。
    /// </summary>
    private T[] tree;

    public SegmentTreeAbstract(ICollection<T> items)
    {
        var count = items.Count;

        this.Size = 1;
        while(Size < count)
        {
            Size *= 2;
        }
        this.tree = new T[Size * 2];

        for(var i = 0; i <  Size * 2; i++)
        {
            tree[i] = DefaultValue;
        }
        items.CopyTo(this.tree, Size);

        //木の上のほうを埋める
        for(var i = Size - 1; i >= 1; i--)
        {
            tree[i] = Calc(tree[i*2], tree[i*2+1]);
        }
    }

    protected abstract T DefaultValue { get; }

    protected abstract T Calc(T a, T b);

    /// <summary>
    /// 値を更新する。
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Update(int index, T value)
    {
        var i = Size + index;
        tree[i] = value;
        for(var ii = i/2; ii >= 1; ii/=2)
        {
            tree[ii] = Calc(tree[ii * 2], tree[ii * 2 + 1]);
        }
    }

    /// <summary>
    /// 半開区間[l, r)の計算値を取得する。
    /// </summary>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public T Range(int l, int r)
    {
        var lindex = l + Size;
        var rindex = r + Size;
        T result = DefaultValue;

        while(lindex < rindex)
        {
            if(lindex % 2 == 1)
            {
                result = Calc(result, tree[lindex]);
                lindex++;
            }
            if(rindex % 2 == 1)
            {
                rindex--;
                result = Calc(result, tree[rindex]);
            }
            lindex = lindex / 2;
            rindex = rindex / 2;
        }

        return result;
    }
}

/// <summary>
/// 最小値を求めるセグ木
/// </summary>
public sealed class SegmentTreeMin<T> : SegmentTreeAbstract<T> where T: IComparable<T>, IMinMaxValue<T>
{
    public SegmentTreeMin(ICollection<T> items) : base(items) { }
    protected override T DefaultValue { get => T.MaxValue; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override T Calc(T a, T b)
    {
        return a.CompareTo(b) < 0 ? a : b;
    }
}

/// <summary>
/// 最大値を求めるセグ木
/// </summary>
public sealed class SegmentTreeMax<T> : SegmentTreeAbstract<T> where T : IComparable<T>, IMinMaxValue<T>
{
    public SegmentTreeMax(ICollection<T> items) : base(items) { }
    protected override T DefaultValue { get => T.MinValue; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override T Calc(T a, T b)
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}

/// <summary>
/// 和を求めるセグ木
/// </summary>
public sealed class SegmentTreeSum<T> : SegmentTreeAbstract<T> where T : INumber<T>
{
    public SegmentTreeSum(ICollection<T> items) : base(items) { }
    protected override T DefaultValue { get => T.Zero; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override T Calc(T a, T b)
    {
        return a + b;
    }
}
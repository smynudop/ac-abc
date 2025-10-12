
namespace AtCoder.MyLib;

using System.Runtime.InteropServices;

public static class BisectExtension
{
    /// <summary>
    /// 二分探索によってtargetを探し、Hitした場合はインデックスを返します。
    /// 存在しない場合は-1を返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int BisectFind<T>(this List<T> list, T target) where T : IComparable<T>
    {
        return Bisect.Find(CollectionsMarshal.AsSpan(list), target);
    }

    /// <summary>
    /// 二分探索によってtargetを探し、Hitした場合はインデックスを返します。
    /// 存在しない場合は-1を返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int BisectFind<T>(this ReadOnlySpan<T> list, T target) where T : IComparable<T>
    {
        return Bisect.Find(list, target);
    }

    /// <summary>
    /// A[i] >= target なる最小のiを返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int LowerBound<T>(this List<T> list, T target) where T : IComparable<T>
    {
        return Bisect.LowerBound(CollectionsMarshal.AsSpan(list), target);
    }

    /// <summary>
    /// A[i] >= target なる最小のiを返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int LowerBound<T>(this ReadOnlySpan<T> list, T target) where T : IComparable<T>
    {
        return Bisect.LowerBound(list, target);
    }

    /// <summary>
    /// A[i] > target なる最小のiを返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int UpperBound<T>(this List<T> list, T target) where T : IComparable<T>
    {
        return Bisect.UpperBound(CollectionsMarshal.AsSpan(list), target);
    }

    /// <summary>
    /// A[i] > target なる最小のiを返します。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="target"></param>
    public static int UpperBound<T>(this ReadOnlySpan<T> list, T target) where T : IComparable<T>
    {
        return Bisect.UpperBound(list, target);
    }
}
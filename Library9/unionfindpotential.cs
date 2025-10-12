using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AtCoder.MyLib;

public abstract class UnionFindPotentialAbstract<T> where T : struct, IAdditionOperators<T, T, T>, INumberBase<T>
{
    protected int[] rootNodes;
    protected int[] sizes;
    protected T[] potentials;

    public UnionFindPotentialAbstract(int size)
    {
        rootNodes = new int[size];
        sizes = new int[size];
        potentials = new T[size];
        for (var i = 0; i < size; i++)
        {
            this.rootNodes[i] = i;
            this.sizes[i] = 1;
            this.potentials[i] = default;
        }
    }

    public (int, T) Find(int x)
    {
        if (rootNodes[x] == x)
        {
            return (x, T.Zero);
        }

        var (r, p) = Find(rootNodes[x]);
        rootNodes[x] = r;
        potentials[x] += p;

        return (r, potentials[x]);
    }

    /// <summary>
    /// x と y を結合し、potential[x] - potential[y] = w という制約を追加する
    /// </summary>
    /// <param name="x">ノードx</param>
    /// <param name="y">ノードy</param>
    /// <param name="w">potential[x] - potential[y] = w</param>
    /// <returns>制約に矛盾がない場合true、矛盾がある場合false</returns>
    public bool Union(int x, int y, T w)
    {
        var (rx, px) = Find(x);
        var (ry, py) = Find(y);

        if (rx == ry)
        {
            // すでに同じ連結成分にある場合、制約が満たされているかチェック
            return px - py == w;
        }

        // サイズの小さい木を大きい木にくっつける
        if (sizes[rx] < sizes[ry])
        {
            (rx, ry) = (ry, rx);
            (px, py) = (py, px);
            w = -w;
        }

        // 木をくっつける
        rootNodes[ry] = rx;
        potentials[ry] = px - py - w;

        // 木のサイズを更新
        sizes[rx] += sizes[ry];

        // 継承先にunion時の処理をさせる
        OnUnion(rx, ry);

        return true;
    }

    protected abstract void OnUnion(int root, int branch);

    public int Size(int x)
    {
        return sizes[Find(x).Item1];
    }

    public bool Same(int x, int y)
    {
        return Find(x).Item1 == Find(y).Item1;
    }

    public T Potential(int x)
    {
        return Find(x).Item2;
    }

    public T Diff(int x, int y)
    {
        if (!Same(x, y))
        {
            return T.Zero;
        }

        return Potential(x) - Potential(y);
    }

    public bool TryDiff(int x, int y, out T diff)
    {
        if (!Same(x, y))
        {
            diff = default;
            return false;
        }

        diff = Potential(x) - Potential(y);
        return true;
    }
}

public class UnionFindPotential<T> : UnionFindPotentialAbstract<T> where T: struct, IAdditionOperators<T, T, T>, INumberBase<T>

{
    public UnionFindPotential(int size) : base(size) { }

    protected override void OnUnion(int root, int branch)
    {
        // pass
    }
}
namespace AtCoder.MyLib;

public abstract class UnionFindAbstract
{
    protected int[] root;
    protected int[] sizes;
    public UnionFindAbstract(int size)
    {
        root = new int[size];
        sizes = new int[size];
        for (var i = 0; i < size; i++)
        {
            this.root[i] = i;
            this.sizes[i] = 1;
        }
    }

    public int Find(int x)
    {
        if (root[x] == x)
        {
            return x;
        }
        return root[x] = Find(root[x]);
    }

    public void Union(int x, int y)
    {
        var xx = Find(x);
        var yy = Find(y);
        if (xx == yy) return;

        // サイズが大きい方に小さい方をくっつける
        if (sizes[xx] < sizes[yy])
        {
            root[xx] = yy;
            sizes[yy] += sizes[xx];
            OnUnion(yy, xx);
        }
        else
        {
            root[yy] = xx;
            sizes[xx] += sizes[yy];
            OnUnion(xx, yy);
        }
    }

    protected abstract void OnUnion(int root, int branch);

    public int Size(int x)
    {
        return sizes[Find(x)];
    }

    public bool Same(int x, int y)
    {
        return Find(x) == Find(y);
    }
}

public class UnionFind : UnionFindAbstract
{
    public UnionFind(int size) : base(size) { }

    protected override void OnUnion(int root, int branch)
    {
        // pass
    }
}
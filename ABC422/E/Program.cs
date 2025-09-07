using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();





var (N, Q) = io.ReadInt2();
var uf = new UnionFindBlack(N);
for (var _ = 0; _ < Q; _++)
{
    var (type, content) = io.ReadQuery();
    if (type == 1)
    {
        var (u, v) = content.SplitAs<int, int>();
        uf.Union(u, v);
    }
    else if (type == 2)
    {
        var u = content.AsInt() - 1;
        uf.toggleBlack(u);
    }
    else
    {
        var u = content.AsInt() - 1;
        io.WriteLine(uf.Black(u) > 0 ? "Yes" : "No");
    }
}

class UnionFindBlack : UnionFindAbstract
{
    private int[] black { get; init; }
    private bool[] isBlack { get; init; }

    public UnionFindBlack(int size) : base(size)
    {
        this.black = new int[size];
        this.isBlack = new bool[size];
    }
    public void toggleBlack(int x)
    {
        isBlack[x] = !isBlack[x];
        var xx = Find(x);
        black[xx] += (isBlack[x] ? 1 : -1);
    }

    protected override void OnUnion(int root, int branch)
    {
        black[root] += black[branch];
    }

    public int Black(int x)
    {
        return this.black[Find(x)];
    }
}
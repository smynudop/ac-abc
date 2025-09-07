using System.Diagnostics;
using System.Globalization;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();




void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var uf = new UnionFindPotential<ModInt>(N);
    for (var i = 0; i < Q; i++)
    {
        var (t, c) = io.ReadQuery();
        if (t == 0)
        {
            var (u, v, x) = c.SplitAs<int, int, int>();
            io.WriteLine(uf.Union(u, v, x) ? 1 : 0);
        }
        else
        {
            var (u, v) = c.SplitAs<int, int>();
            io.WriteLine(uf.TryDiff(u, v, out var diff) ? diff.Value : -1);
        }
    }
}

#if DEBUG
var sw = Stopwatch.StartNew();
using var reader = new StreamReader("input.txt");
using var stringWriter = new StringWriter();

using (var io = new MyIO(reader, stringWriter))
{
    _main(io);
}
sw.Stop();
Console.Write(stringWriter.ToString());
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");

#else
    using var io = new MyIO();
    _main(io); 
#endif

class UFPotential : UnionFindAbstract
{
    public ModInt[] nums;
    public UFPotential(int size) : base(size)
    {
        this.nums = new ModInt[size];
        for (var i = 0; i < size; i++)
        {
            this.nums[i] = new ModInt(0);
        }
    }

    protected override void OnUnion(int root, int branch)
    {

    }
}
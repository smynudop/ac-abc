using System.Diagnostics;
using System.Numerics;
using AtCoder.MyLib;
using AtCoder;
using System.Dynamic;

using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var seg = new LazySegtree<(int max, int min), int, IL2>(N);
    seg.Apply(0, N, 1);
    for (var i = 0; i < Q; i++)
    {
        var (A, B) = io.ReadInt2();
        var l = seg[A - 1];
        var r = seg[B - 1];
        var p = seg.Prod(A - 1, B);
        if (l.min == r.min && r.min == p.min)
        {
            io.WriteLine("Yes");
            seg.Apply(A - 1, B - 1, 1);
        }
        else
        {
            io.WriteLine("No");
        }
    }
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif

public struct IL2 : ILazySegtreeOperator<(int max, int min), int>
{
    public IL2() { }
    public int FIdentity { get => 0; }
    public (int max, int min) Mapping(int f, (int max, int min) x) => (x.max + f, x.min + f);
    public int Composition(int f, int g) => f + g;
    public (int max, int min) Identity { get => (int.MinValue, int.MaxValue); }
    public (int max, int min) Operate((int max, int min) a, (int max, int min) b) => (Math.Max(a.max, b.max), Math.Min(a.min, b.min));

}
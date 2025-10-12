using System.Diagnostics;
using System.Numerics;
using AtCoder.MyLib;
using AtCoder;
using System.Dynamic;

using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var T = io.ReadLine();
    var l = new List<int>();
    var d = new Dictionary<int, ModInt>();
    var TT = T;
    while (TT.Length > 0)
    {
        var TTT = TT.TrimStart(TT[0]);
        l.Add(TT.Length - TTT.Length);
        TT = TTT;
    }
    ModInt kai(int n)
    {
        if (d.ContainsKey(n))
        {
            return d[n];
        }
        ModInt ans = 1;
        for (var i = 1; i <= N; i++)
        {
            ans *= i;
            d[i] = ans;
        }
        return ans;
    }

    var ans = kai(N);
    foreach (var i in l)
    {
        ans /= kai(i);
    }
    io.WriteLine(ans);
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
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (T, M) = io.ReadInt2();
    while (T-- > 0)
    {
        var N = io.ReadInt();
        var C = io.ReadIntArray(N);

        long ans = 1;
        var bunsi = N;
        foreach (var ci in C)
        {
            for (var i = 1; i <= ci; i++)
            {
                ans = ans * N / i;
                ans %= M;
                N--;
            }
        }
        io.WriteLine(ans);
    }

}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif

public class IntCDesc : IComparer<double>
{
    public int Compare(double a, double b)
    {
        return b.CompareTo(a);
    }
}
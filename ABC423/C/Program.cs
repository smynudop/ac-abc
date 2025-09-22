using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, R) = io.ReadInt2();
    var L = io.ReadIntArray(N);

    if (L.All(x => x == 1))
    {
        io.WriteLine(0);
        return;
    }

    var i1 = Math.Min(Array.IndexOf(L, 0), R);
    var i2 = Math.Max(Array.LastIndexOf(L, 0), R - 1);
    var LL = L.AsSpan().Slice(i1, i2 - i1 + 1);
    N = LL.Length;
    R -= i1;



    var close = 0;
    var open = 0;
    for (var i = 0; i < N; i++)
    {
        if (LL[i] == 1)
        {
            close++;
        }
        else
        {
            open++;
        }
    }

    io.WriteLine(close * 2 + open);
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif






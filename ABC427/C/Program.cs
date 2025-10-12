using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, M) = io.ReadInt2();
    var edges = new List<(int, int)>();
    for (var i = 0; i < M; i++)
    {
        var (u, v) = io.ReadInt2();
        edges.Add((u - 1, v - 1));
    }

    var min = int.MaxValue;
    for (var i = 0; i < (1 << N); i++)
    {
        var cnt = 0;
        foreach (var edge in edges)
        {
            var n1 = (i & (1 << edge.Item1)) >> edge.Item1;
            var n2 = (i & (1 << edge.Item2)) >> edge.Item2;
            if (n1 == n2)
            {
                cnt++;
            }
        }
        min = Math.Min(min, cnt);
    }
    io.WriteLine(min);
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif






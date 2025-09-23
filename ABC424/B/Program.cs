using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, M, K) = io.ReadInt3();
    var l = Enumerable.Repeat(0, N + 1).ToList();
    var all = new List<int>();
    for (var i = 0; i < K; i++)
    {
        var (A, B) = io.ReadInt2();
        l[A]++;
        if (l[A] == M)
        {
            all.Add(A);
        }
    }
    if (all.Count > 0)
    {
        io.WriteLine(all);
    }
}
#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif

using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var T = io.ReadInt();
    while (T-- > 0)
    {
        var (N, K, X) = io.ReadInt3();
        var A = io.ReadIntArray(N);

        var Q = new PriorityQueue<(double length, int size), double>(
            A.GroupBy(x => x).Select(g => (((double)g.Key, g.Count()), (double)g.Key)),
            new IntCDesc()
        );
        while (K > 0)
        {
            var i = Q.Dequeue();
            if (i.size <= K)
            {
                Q.Enqueue((i.length / 2, i.size * 2), i.length / 2);
            }
            else
            {
                Q.Enqueue((i.length / 2, K * 2), i.length / 2);
                Q.Enqueue((i.length, i.size - K), i.length);
            }
            K -= Math.Min(K, i.size);
        }
        var cnt = 0;
        while (cnt < X)
        {
            var item = Q.Dequeue();
            cnt += item.size;
            if (cnt >= X)
            {
                io.WriteLine(item.length);
                break;
            }
        }
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
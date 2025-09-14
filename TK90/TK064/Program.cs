using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var A = io.ReadIntArray(N);
    var diff = new long[N - 1];
    for (var i = 0; i < N - 1; i++)
    {
        diff[i] = (long)A[i + 1] - A[i];
    }
    long huben = 0;
    for (var i = 0; i < N - 1; i++)
    {
        huben += Math.Abs(diff[i]);
    }
    for (var _ = 0; _ < Q; _++)
    {
        var (L, R, V) = io.ReadInt3();
        L--;
        R--;
        if (L > 0)
        {
            huben -= Math.Abs(diff[L - 1]);
            diff[L - 1] += V;
            huben += Math.Abs(diff[L - 1]);
        }
        if (R < N - 1)
        {
            huben -= Math.Abs(diff[R]);
            diff[R] -= V;
            huben += Math.Abs(diff[R]);
        }
        io.WriteLine(huben);
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif
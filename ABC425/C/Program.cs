using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var A = io.ReadIntArray(N);

    var ruiseki = Util.Ruiseki(A);

    var head = 0;
    for (var _ = 0; _ < Q; _++)
    {
        var (t, content) = io.ReadQuery();
        if (t == 1)
        {
            var c = content.AsInt();
            head += c;
            head %= N;
        }
        else
        {
            var (l, r) = content.SplitAs<int, int>();
            l--;
            r--;
            l += head;
            r += head;
            l %= N;
            r %= N;
            if (l < r)
            {
                var ans = ruiseki[r] - (l > 0 ? ruiseki[l - 1] : 0);
                io.WriteLine(ans);
            }
            else if (l == r)
            {
                io.WriteLine(A[r]);
            }
            else
            {
                var ans = ruiseki[N - 1] - ruiseki[l - 1] + ruiseki[r];
                io.WriteLine(ans);
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






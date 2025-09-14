using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var A = io.ReadIntArray(N);
    var B = io.ReadIntArray(N);
    Array.Sort(A);
    Array.Sort(B);
    long ans = 0;
    for(var i = 0; i < N; i++)
    {
        ans += Math.Abs(A[i] - B[i]);
    }
    io.WriteLine(ans);
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif
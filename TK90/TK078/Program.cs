using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, M) = io.ReadInt2();
    var graph = new int[N+1];
    for (int i = 0; i < M; i++)
    {
        var (a, b) = io.ReadInt2();
        if(a>b) (a,b) = (b,a);
        graph[b]++;
    }
    var ans = 0;
    for (int i = 1; i <= N; i++)
    {
        if(graph[i] == 1) ans++;
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
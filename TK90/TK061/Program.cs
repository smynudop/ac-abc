using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var que = new Deque<int>(100_000);
    var Q = io.ReadInt();
    foreach(var _ in Enumerable.Range(0, Q))
    {
        var (i, x) = io.ReadInt2();
        if (i == 1)
        {
            que.Unshift(x);
        }
        else if(i == 2)
        {
            que.Push(x);
        }
        else
        {
            io.WriteLine(que[x-1]);
        }
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif
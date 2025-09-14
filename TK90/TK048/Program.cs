using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, K)  = io.ReadInt2();
    var q = new PriorityQueue<(int point, int next), int>(new intComparerDesc());
    for(var i = 0; i < N; i++)
    {
        var (A,B) = io.ReadInt2();
        q.Enqueue((B, A-B), B);
    }
    long ans = 0;
    while(K-- > 0)
    {
        var item = q.Dequeue();
        ans += item.point;
        q.Enqueue((item.next, 0), item.next);
    }
    io.WriteLine(ans.ToString());
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif

class intComparerDesc : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}
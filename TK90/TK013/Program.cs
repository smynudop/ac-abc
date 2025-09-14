using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, M) = io.ReadInt2();
    var map = new List<(int To, int Cost)>[N+1];
    for (var i = 0; i < N+1; i++) map[i] = new List<(int To, int Cost)>();

    for(var i = 0; i < M; i++)
    {
        var (a, b, c) = io.ReadInt3();
        map[a].Add((b, c));
        map[b].Add((a, c));
    }
    var from1 = new long[N + 1];
    var fromN = new long[N + 1];
    for(var i = 1; i <= N; i++)
    {
        from1[i] = -1;
        fromN[i] = -1;
    }
    var pq = new PriorityQueue<(int Node, long Cost), long>();
    pq.Enqueue((1, 0), 0);

    while(pq.Count > 0)
    {
        var (node, cost) = pq.Dequeue();
        if (from1[node] != -1) continue;
        from1[node] = cost;
        foreach (var (to, c) in map[node])
        {
            if (from1[to] != -1) continue;
            pq.Enqueue((to, cost + c), cost + c);
        }
    }
    
    pq.Clear();

    pq.Enqueue((N, 0), 0);
    while (pq.Count > 0)
    {
        var (node, cost) = pq.Dequeue();
        if (fromN[node] != -1) continue;
        fromN[node] = cost;
        foreach (var (to, c) in map[node])
        {
            if (fromN[to] != -1) continue;
            pq.Enqueue((to, cost + c), cost + c);
        }
    }
    for(var i = 1; i <= N; i++)
    {
        var ans = from1[i] + fromN[i];
        io.WriteLine(ans.ToString());
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif
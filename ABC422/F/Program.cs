using System.Reflection.Metadata;
using AtCoder.MyLib;
using static AtCoder.MyLib.Util;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, M) = io.ReadInt2();
var W = io.ReadLongList(N);

var l = new List<HashSet<int>>(N + 1);
for (var i = 0; i < N + 1; i++)
{
    l.Add(new HashSet<int>());
}

for (var i = 0; i < M; i++)
{
    var (u, v) = io.ReadInt2();
    l[u].Add(v);
    l[v].Add(u);
}



for (var i = 1; i <= N; i++)
{
    var visited = new HashSet<int>();
    var q = new PriorityQueue<(int node, long weight, long fuel), long>();
    q.Enqueue((1, 0, 0), 0);

    while (q.Count > 0)
    {
        var item = q.Dequeue();
        if (item.node == i)
        {
            io.WriteLine(item.fuel);
            break;
        }
        visited.Add(item.node);

        foreach (var x in l[item.node])
        {
            if (visited.Contains(x))
            {
                continue;
            }
            var fuel = item.fuel + item.weight + W[item.node - 1];
            var w = item.weight + W[item.node - 1];
            q.Enqueue((x, w, fuel), fuel);
        }
    }

}

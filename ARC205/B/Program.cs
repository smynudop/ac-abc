using System.Globalization;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

checked
{
    var (N, M) = io.ReadInt2();
    var Nodes = new List<HashSet<int>>(N);
    for (int i = 0; i < N; i++)
    {
        Nodes.Add(new HashSet<int>());
    }

    for (int i = 0; i < M; i++)
    {
        var (U, V) = io.ReadInt2();
        Nodes[U - 1].Add(V - 1);
        Nodes[V - 1].Add(U - 1);
    }

    if (N % 2 == 0)
    {
        for (int i = 0; i < N / 2; i++)
        {
            var a = i;
            var b = i + N / 2;
            if (Nodes[a].Contains(b))
            {
                Nodes[a].Remove(b);
                Nodes[b].Remove(a);
            }
            else
            {
                Nodes[a].Add(b);
                Nodes[b].Add(a);
            }
        }
    }

    var SortedNodes = Nodes.OrderBy(x => x.Count % 2).ThenByDescending(x => x.Count).ToList();
    for (var i = 0; i < N; i++)
    {
        var l = SortedNodes[i].ToList();
        var cnt = l.Count;
        for (var j = 0; j < cnt / 2; j++)
        {
            var a = l[2 * j];
            var b = l[2 * j + 1];
            if (Nodes[a].Contains(b))
            {
                Nodes[a].Remove(b);
                Nodes[b].Remove(a);
            }
            else
            {
                Nodes[a].Add(b);
                Nodes[b].Add(a);
            }
            SortedNodes[i].Remove(a);
            SortedNodes[i].Remove(b);
        }
    }


    long black = 0;
    foreach (var ns in Nodes)
    {
        black += ns.Count;
    }
    black /= 2;

    var ans = (long)N * (N - 1) / 2 - black;
    io.WriteLine(ans);
}
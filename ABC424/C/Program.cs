using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var graph = new List<int>[N + 1];
    for (var i = 1; i <= N; i++)
    {
        graph[i] = new List<int>();
    }

    var initial = new HashSet<int>();
    for (var i = 1; i <= N; i++)
    {
        var (A, B) = io.ReadInt2();
        if (A == 0 && B == 0)
        {
            initial.Add(i);
        }
        else
        {
            graph[A].Add(i);
            graph[B].Add(i);
        }
    }

    var Q = new Queue<int>(initial.ToList());
    var visited = new HashSet<int>();
    while (Q.Count > 0)
    {
        var item = Q.Dequeue();
        if (visited.Contains(item))
        {
            continue;
        }
        visited.Add(item);
        foreach (var to in graph[item])
        {
            Q.Enqueue(to);
        }
    }
    io.WriteLine(visited.Count);

}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif






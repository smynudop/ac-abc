using System.Diagnostics;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var uf = new UnionFind(N);
    for(var i = 0; i < Q; i++)
    {
        var (t, c) = io.ReadQuery();
        if(t == 0)
        {
            var (u, v) = c.SplitAs<int, int>();
            uf.Union(u, v);
        } 
        else
        {
            var (u, v) = c.SplitAs<int, int>();
            io.WriteLine(uf.Same(u, v) ? 1 : 0);

        }
    }
}

#if DEBUG
var sw = Stopwatch.StartNew();
using var reader = new StreamReader("input.txt");
using var stringWriter = new StringWriter();

using (var io = new MyIO(reader, stringWriter))
{
    _main(io);
}
sw.Stop();
Console.Write(stringWriter.ToString());
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");

#else
    using var io = new MyIO();
    _main(io); 
#endif
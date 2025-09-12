using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();




void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var a = io.ReadIntList(N);
    var rui = Util.Ruiseki(a);
    for(var _ = 0; _ < Q; _++)
    {
        var (l, r) = io.ReadInt2();
        io.WriteLine(rui[r - 1] - (l > 0 ? rui[l - 1] : 0));
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
using System.Diagnostics;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var list = io.ReadIntList(N);
    io.WriteLine(list.Sum());
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
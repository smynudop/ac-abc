using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();




void _main(MyIO io)
{
    //ライブラリ化の必要はあるんだろうか……？
    var N = io.ReadLong();
    var sqrt = (long)Math.Sqrt(N);
    var Result = new List<long>(2*(int)sqrt);
    long last = 0;
    for(long i = 1; i <= sqrt; i++)
    {
        Result.Add(i);
        last = i;
    }
    if(N/sqrt != sqrt)
    {
        Result.Add(N/sqrt);
    }
    for (long i = sqrt-1; i >= 1; i--)
    {
        Result.Add(N/i);
    }
    io.WriteLine(Result.Count);
    io.WriteLine(Result);
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
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();




void _main(MyIO io)
{
    var Q = io.ReadInt();
    var dic = new Dictionary<long, long>(new LongComparer());
    for(var i = 0; i < Q; i++)
    {
        var (type, content) = io.ReadQuery();
        if(type == 0)
        {
            var (k,v) = content.SplitAs<long, long>();
            dic[k] = v;
        } 
        else
        {
            var k = long.Parse(content);
            io.WriteLine(dic.GetValueOrDefault(k, 0));
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

public class LongComparer : EqualityComparer<long>
{
    public override int GetHashCode(long obj)
    {
        return obj.ToString().GetHashCode();
    }

    public override bool Equals(long a, long b)
    {
        return a == b;
    }
}
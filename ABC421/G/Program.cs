using System.Buffers;
using System.Net;
using System.Xml.Linq;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var X = io.ReadLong();
long sq = (long)Math.Ceiling(Math.Sqrt(Math.Abs(X)));

var l = new List<long>();

for (long c = -sq; c <= sq; c++)
{
    if ((X - c * c) % (2 * c - 1) == 0)
    {
        l.Add((X - c * c) / (2 * c - 1));
    }
}

l = l.Distinct().OrderBy(x => x).ToList();
io.WriteLine(l.Count);
io.WriteLine(l);